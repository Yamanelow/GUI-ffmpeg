#region Licence
/*
 * ----------------------------------------------------------------------------
 * "LICENCE BEERWARE" (Révision 42):
 * <yamanelow@pando.fr> a créé ce fichier. Tant que vous conservez cet avertissement,
 * vous pouvez en faire ce que vous voulez. Si on se rencontre un jour et que vous
 * pensez que ca en valait le coup, vous pouvez me payer une bière en retour.
 * 
 * Yamanelow
 * ----------------------------------------------------------------------------
 */
#endregion

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace ffmpeg {
	
	public class VideoTask : IEquatable<VideoTask> {
		
		#region Variables
		public string FileFullPath = string.Empty;
		public bool MP4;
		public bool WEBM;
		public bool FLV;
		public bool MP3;
		
		public string MP4_bv = "5000k";
		public string WEBM_bv = "5000k";
		public string FLV_bv = "2000k";
		
		public string MP4_ba = "128k";
		public string WEBM_ba = "128k";
		public string FLV_ba = "128k";
		public string MP3_ba = "128k";
		
		public string FLV_sr = "44100";
		public string MP3_sr = "44100";
		
		public string ResizeWidth = string.Empty;
		public string ResizeHeight = string.Empty;
		
		public int TnWidth = 128;
		public int TnHeight = 72;
		
		public TimeSpan StartOffset = TimeSpan.Zero;
		public TimeSpan EndOffset = TimeSpan.Zero;
		
		public bool NoSound;
		public bool WebChar;
		public bool Thumbnail;
		public bool Json;
		public bool Poster;
		public bool LengthOnTn;
		
		public int Rotate = 4;
		
		public static readonly string[] OverlayValues = new string[] {
			"0:0",
			"main_w-overlay_w:0",
			"0:main_h-overlay_h",
			"main_w-overlay_w:main_h-overlay_h",
			"main_w/2-overlay_w/2:main_h/2-overlay_h/2"
		};
		public Tuple<int, string>[] Overlays = new Tuple<int, string>[] {
			new Tuple<int, string>(-1, string.Empty),
			new Tuple<int, string>(-1, string.Empty),
			new Tuple<int, string>(-1, string.Empty),
			new Tuple<int, string>(-1, string.Empty)
		};
		
		public bool Overwrite;
		
		private static Regex _webchar = new Regex(@"[^a-zA-Z0-9_\-\.]", RegexOptions.Compiled);
		
		private Process _currentProcess = null;
		private bool _cancelFlag;
		private string _outputForLength = null;
		#endregion
		
		#region Clone
		public VideoTask Clone() {
			VideoTask t = new VideoTask();
			t.MP4 = this.MP4;
			t.FLV = this.FLV;
			t.WEBM = this.WEBM;
			t.MP3 = this.MP3;
			t.MP4_bv = this.MP4_bv;
			t.WEBM_bv = this.WEBM_bv;
			t.FLV_bv = this.FLV_bv;
			t.MP4_ba = this.MP4_ba;
			t.WEBM_ba = this.WEBM_ba;
			t.FLV_ba = this.FLV_ba;
			t.MP3_ba = this.MP3_ba;
			t.FLV_sr = this.FLV_sr;
			t.MP3_sr = this.MP3_sr;
			t.WebChar = this.WebChar;
			t.Poster = this.Poster;
			t.Json = this.Json;
			t.Thumbnail = this.Thumbnail;
			t.LengthOnTn = this.LengthOnTn;
			t.Overwrite = this.Overwrite;
			t.Rotate = this.Rotate;
			t.ResizeWidth = this.ResizeWidth;
			t.ResizeHeight = this.ResizeHeight;
			t.StartOffset = this.StartOffset;
			t.EndOffset = this.EndOffset;
			t.TnWidth = this.TnWidth;
			t.TnHeight = this.TnHeight;
			t.Overlays = new Tuple<int, string>[4];
			this.Overlays.CopyTo(t.Overlays, 0);
			return t;
		}
		#endregion
		
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj) {
			if (obj is VideoTask)
				return Equals((VideoTask)obj); // use Equals method below
			else
				return false;
		}
		
		public bool Equals(VideoTask other) {
			if(ReferenceEquals(other, null))
				return false;
			return string.Equals(this.FileFullPath, other.FileFullPath, StringComparison.CurrentCultureIgnoreCase);
		}
		
		public override int GetHashCode() {
			return FileFullPath.GetHashCode();
		}
		
		public static bool operator ==(VideoTask left, VideoTask right) {
			if(ReferenceEquals(right, null) && ReferenceEquals(left, null))
				return true;
			if(ReferenceEquals(right, null) || ReferenceEquals(left, null))
				return false;
			return left.Equals(right);
		}
		
		public static bool operator !=(VideoTask left, VideoTask right) {
			if(ReferenceEquals(right, null) && ReferenceEquals(left, null))
				return false;
			if(ReferenceEquals(right, null) || ReferenceEquals(left, null))
				return true;
			return !left.Equals(right);
		}
		#endregion
		
		#region Private properties for encoding
		private string ParamOW {
			get {
				return Overwrite ? " -y" : " -n";
			}
		}
		
		private string ParamOffset {
			get {
				return (StartOffset == TimeSpan.Zero ? string.Empty : string.Format(" -ss {0:c}", StartOffset)) +
					(EndOffset == TimeSpan.Zero ? string.Empty : string.Format(" -to {0:c}", EndOffset));
			}
		}
		
		private string ParamAN {
			get {
				return NoSound ? " -an" : string.Empty;
			}
		}
		
		private string ParamI {
			get {
				StringBuilder rst = new StringBuilder();
				for(int i = 0; i < Overlays.Length; i++) {
					if(Overlays[i].Item1 >= 0 && !string.IsNullOrWhiteSpace(Overlays[i].Item2)) {
						if(File.Exists(Overlays[i].Item2)) {
							rst.Append(" -i \"").Append(Overlays[i].Item2).Append("\"");
						}
					}
				}
				return rst.ToString();
			}
		}
		
		private string ParamFilter {
			get {
				int op = 0;
				int ovi = 1;
				string prev = "[0:v]";
				StringBuilder rst = new StringBuilder();
				if(!string.IsNullOrWhiteSpace(ResizeHeight) || !string.IsNullOrWhiteSpace(ResizeWidth)) {
					rst.Append(prev)
						.Append(" scale=w=")
						.Append(string.IsNullOrWhiteSpace(ResizeWidth) ? "-1" : ResizeWidth)
						.Append(":h=")
						.Append(string.IsNullOrWhiteSpace(ResizeHeight) ? "-1" : ResizeHeight)
						.Append(" [tmp1];");
					op++;
					prev = "[tmp1]";
				}
				if(Rotate < 4) {
					rst.Append(prev).Append(" transpose=").Append(Rotate);
					if(op == 0) {
						rst.Append(" [tmp1];");
						op++;
						prev = "[tmp1]";
					} else {
						rst.AppendFormat(" [tmp{0}];", ++op);
						prev = string.Format("[tmp{0}]", op);
					}
				}
				for(int i = 0; i < Overlays.Length; i++) {
					if(Overlays[i].Item1 >= 0 && !string.IsNullOrWhiteSpace(Overlays[i].Item2)) {
						if(File.Exists(Overlays[i].Item2)) {
							rst.AppendFormat(" {0} [{1}] overlay={2} [tmp{3}];",
							                 prev,
							                 ovi++,
							                 OverlayValues[Overlays[i].Item1],
							                 ++op
							                );
							prev = string.Format("[tmp{0}]", op);
						}
					}
				}
				if(rst.Length > 0) {
					return rst.Remove(rst.Length - 8, 8).Insert(0, " -filter_complex \"").Append("\"").ToString();
				}
				return string.Empty;
			}
		}
		#endregion
		
		#region Events
		public event Action<string> Log;
		#endregion
		
		private void SendLog(string message) {
			if(Log != null)
				Log(message);
		}
		
		public void Cancel() {
			_cancelFlag = true;
			if(_currentProcess != null) {
				try {
					_currentProcess.Kill();
				} finally {}
			}
		}
		
		public void Execute() {
			if(_cancelFlag)
				return;
			
			// Paths check
			if(string.IsNullOrWhiteSpace(FileFullPath) || !File.Exists(FileFullPath)) {
				SendLog("NOT EXISTS " + FileFullPath);
				return;
			}
			string folder = FileFullPath.Substring(0, FileFullPath.LastIndexOf('\\'));
			if(!CanWriteDirectory(folder)) {
				SendLog("READONLY " + folder);
				return;
			}
			
			if(!File.Exists(Common.ffmpeg)) {
				SendLog(I18n.Get("ErrorFfmpegNotFound"));
				return;
			}
			if(!File.Exists(Common.ffprobe)) {
				SendLog(I18n.Get("ErrorFfprobeNotFound"));
				return;
			}
			
			// Extension check
			switch(Path.GetExtension(FileFullPath)) {
				case ".avi":
				case ".mp4":
				case ".webm":
				case ".ogv":
				case ".mp3":
				case ".flv":
				case ".3gp":
					break;
				default:
					Log("NOT VIDEO " + FileFullPath);
					return;
			}
			
			string cleanFileName = "_enc_" + (WebChar ? GetCleanFileName(Path.GetFileNameWithoutExtension(FileFullPath)) : Path.GetFileNameWithoutExtension(FileFullPath));
			
			Log("############################################################");
			Log(FileFullPath);
			Log("############################################################");
			
			if(MP4)
				EncodeMP4(Path.Combine(folder, cleanFileName + ".mp4"));
			
			if(FLV)
				EncodeFLV(Path.Combine(folder, cleanFileName + ".flv"));
			
			if(WEBM)
				EncodeWEBM(Path.Combine(folder, cleanFileName + ".webm"));
			
			if(MP3)
				EncodeMP3(Path.Combine(folder, cleanFileName + ".mp3"));
			
			if(Poster || Thumbnail)
				CreatePictures(Path.Combine(folder, cleanFileName + ".png"));
			
			if(Json)
				CreateJSON(Path.Combine(folder, cleanFileName + ".desc"));
			
		}
		
		public string GetCleanFileName(string fileName) {
			return _webchar.Replace(fileName, "_");
		}
		
		public void CreateJSON(string output) {
			if(_cancelFlag)
				return;
			
			//string txt = cleanFileFullPath.Substring(0, cleanFileFullPath.LastIndexOf('.')) + ".desc";
			SendLog("\r\nJSON description ......");
			SendLog("------------------------------------------------------------");
			
			string titre = Path.GetFileNameWithoutExtension(FileFullPath);
			string date = File.GetLastWriteTime(FileFullPath).ToUnixTimestamp().ToString();
			string description = "Aucune description.";
			
			using(StreamWriter sw = new StreamWriter(output)) {
				sw.Write("{ \"title\":\"" + titre + "\", \"description\":\"" + description + "\", \"date\":\"" + date + "\" }");
				sw.Flush();
			}
		}
		
		public void CreatePictures(string output) {
			if(_cancelFlag)
				return;
			
			string tn = output.Substring(0, output.LastIndexOf(".")) + "-tn.png";
			string cde = "-ss 00:00:01 -i \"" + FileFullPath + "\"" + ParamI + " -vframes 1 -an" + ParamFilter + ParamOW + " \"" + output + "\"";
			SendLog("\r\nffmpeg " + cde);
			SendLog("------------------------------------------------------------");
			ProcessStartInfo psi = new ProcessStartInfo(Common.ffmpeg, cde);
			psi.UseShellExecute = false;
			psi.CreateNoWindow = true;
			psi.RedirectStandardError = true;
			using(Process p = new Process()) {
				p.StartInfo = psi;
				p.Start();
				string line;
				while ((line = p.StandardError.ReadLine()) != null) {
					SendLog(line);
					Application.DoEvents();
				}
				p.WaitForExit();
			}
			
			if(Thumbnail) {
				using(Image org = Image.FromFile(output)) {
					Bitmap bmp = new Bitmap(TnWidth, TnHeight);
					Graphics g = Graphics.FromImage(bmp);
					g.DrawImage(org, new Rectangle(0, 0, TnWidth, TnHeight));
					
					if(LengthOnTn) {
						try {
							MediaInfo mi = MediaInfo.Query(string.IsNullOrWhiteSpace(_outputForLength) ? FileFullPath : _outputForLength);
							g.FillRectangle(Brushes.MidnightBlue, new Rectangle(5, 5, 45, 20));
							g.DrawRectangle(Pens.Black, new Rectangle(5, 5, 45, 20));
							using (Font f = new Font("Arial", 8, FontStyle.Bold))
								g.DrawString(
									string.Format("{0:g}", new TimeSpan(0, 0, (int)Math.Round(mi.FormatInfo.duration))),
									f, new SolidBrush(Color.White),
									8,
									8
								);
						} catch(Exception ex) {
							SendLog(ex.Message);
							SendLog(ex.StackTrace);
						}
					}
					bmp.Save(tn, ImageFormat.Png);
				}
			}
			if(!Poster)
				File.Delete(output);
		}
		
		public void EncodeFLV(string output) {
			if(_cancelFlag)
				return;
			
			_outputForLength = output;
			CommandLineBuilder cb = new CommandLineBuilder();
			
			if(StartOffset != TimeSpan.Zero)
				cb.Seek(string.Format("{0:c}", StartOffset));
			
			cb.AddEntry(FileFullPath);
			
			for(int i = 0; i < Overlays.Length; i++) {
				if(Overlays[i].Item1 >= 0 && !string.IsNullOrWhiteSpace(Overlays[i].Item2)) {
					cb.AddEntry(Overlays[i].Item2);
				}
			}
			if(EndOffset != TimeSpan.Zero)
				cb.To(string.Format("{0:c}", EndOffset - StartOffset));
			
			if(!string.IsNullOrWhiteSpace(ResizeHeight) || !string.IsNullOrWhiteSpace(ResizeWidth)) {
				cb.FilterComplex.Resize(ResizeWidth, ResizeHeight);
			}
			if(Rotate < 4) {
				cb.FilterComplex.Transpose((Transpose)Rotate);
			}
			int j = 1;
			for(int i = 0; i < Overlays.Length; i++) {
				if(Overlays[i].Item1 >= 0 && !string.IsNullOrWhiteSpace(Overlays[i].Item2)) {
					cb.FilterComplex.Overlay((Overlay)Overlays[i].Item1, string.Format("[{0}]", j++));
				}
			}
			
			cb.VideoCodec(VideoEncoding.FLV).Param(Parameter.V_BITRATE, FLV_bv);
			
			if(NoSound)
				cb.AudioCodec(AudioEncoding.NOAUDIO);
			else
				cb.AudioCodec(AudioEncoding.MP3).Param(Parameter.A_BITRATE, FLV_ba).Param(Parameter.A_SAMPLE, FLV_sr);
			
			if(Overwrite)
				cb.Param(Parameter.MISC_OVERWRITE_YES);
			else
				cb.Param(Parameter.MISC_OVERWRITE_NO);
			
			string cde = cb.Output(output);
			
			SendLog("\r\nffmpeg " + cde);
			SendLog("------------------------------------------------------------");
			if(output.Equals(FileFullPath, StringComparison.CurrentCultureIgnoreCase))
				SendLog(I18n.Get("ErrorSameInputOutput"));
			else {
				ProcessStartInfo psi = new ProcessStartInfo(Common.ffmpeg, cde);
				psi.UseShellExecute = false;
				psi.CreateNoWindow = true;
				psi.RedirectStandardError = true;
				using(Process p = new Process()) {
					_currentProcess = p;
					p.StartInfo = psi;
					p.Start();
					string line;
					while ((line = p.StandardError.ReadLine()) != null) {
						SendLog(line);
						Application.DoEvents();
					}
					p.WaitForExit();
				}
				_currentProcess = null;
			}
		}
		
		public void EncodeWEBM(string output) {
			if(_cancelFlag)
				return;
			
			_outputForLength = output;
			CommandLineBuilder cb = new CommandLineBuilder();
			
			if(StartOffset != TimeSpan.Zero)
				cb.Seek(string.Format("{0:c}", StartOffset));
			
			cb.AddEntry(FileFullPath);
			
			for(int i = 0; i < Overlays.Length; i++) {
				if(Overlays[i].Item1 >= 0 && !string.IsNullOrWhiteSpace(Overlays[i].Item2)) {
					cb.AddEntry(Overlays[i].Item2);
				}
			}
			if(EndOffset != TimeSpan.Zero)
				cb.To(string.Format("{0:c}", EndOffset - StartOffset));
			
			if(!string.IsNullOrWhiteSpace(ResizeHeight) || !string.IsNullOrWhiteSpace(ResizeWidth)) {
				cb.FilterComplex.Resize(ResizeWidth, ResizeHeight);
			}
			if(Rotate < 4) {
				cb.FilterComplex.Transpose((Transpose)Rotate);
			}
			int j = 1;
			for(int i = 0; i < Overlays.Length; i++) {
				if(Overlays[i].Item1 >= 0 && !string.IsNullOrWhiteSpace(Overlays[i].Item2)) {
					cb.FilterComplex.Overlay((Overlay)Overlays[i].Item1, string.Format("[{0}]", j++));
				}
			}
			
			cb.VideoCodec(VideoEncoding.VPX).Param(Parameter.V_BITRATE, WEBM_bv);
			
			if(NoSound)
				cb.AudioCodec(AudioEncoding.NOAUDIO);
			else
				cb.AudioCodec(AudioEncoding.VORBIS).Param(Parameter.A_BITRATE, WEBM_ba);
			
			if(Overwrite)
				cb.Param(Parameter.MISC_OVERWRITE_YES);
			else
				cb.Param(Parameter.MISC_OVERWRITE_NO);
			
			string cde = cb.Output(output);
			
			SendLog("\r\nffmpeg " + cde);
			SendLog("------------------------------------------------------------");
			if(output.Equals(FileFullPath, StringComparison.CurrentCultureIgnoreCase))
				SendLog(I18n.Get("ErrorSameInputOutput"));
			else {
				ProcessStartInfo psi = new ProcessStartInfo(Common.ffmpeg, cde);
				psi.UseShellExecute = false;
				psi.CreateNoWindow = true;
				psi.RedirectStandardError = true;
				using(Process p = new Process()) {
					_currentProcess = p;
					p.StartInfo = psi;
					p.Start();
					string line;
					while ((line = p.StandardError.ReadLine()) != null) {
						SendLog(line);
						Application.DoEvents();
					}
					p.WaitForExit();
				}
				_currentProcess = null;
			}
		}
		
		public void EncodeMP3(string output) {
			if(_cancelFlag)
				return;
			
			_outputForLength = output;
			string cde = "-i \"" + FileFullPath + "\" -c:a mp3 -b:a "+ MP3_ba +" -ar "+ MP3_sr +" -vn" + ParamOffset + ParamOW + " \"" + output + "\"";
			
			SendLog("\r\nffmpeg " + cde);
			SendLog("------------------------------------------------------------");
			if(output.Equals(FileFullPath, StringComparison.CurrentCultureIgnoreCase))
				SendLog(I18n.Get("ErrorSameInputOutput"));
			else {
				ProcessStartInfo psi = new ProcessStartInfo(Common.ffmpeg, cde);
				psi.UseShellExecute = false;
				psi.CreateNoWindow = true;
				psi.RedirectStandardError = true;
				using(Process p = new Process()) {
					_currentProcess = p;
					p.StartInfo = psi;
					p.Start();
					string line;
					while ((line = p.StandardError.ReadLine()) != null) {
						SendLog(line);
						Application.DoEvents();
					}
					p.WaitForExit();
				}
				_currentProcess = null;
			}
		}
		
		public void EncodeMP4(string output) {
			if(_cancelFlag)
				return;
			
			_outputForLength = output;
			CommandLineBuilder cb = new CommandLineBuilder();
			
			if(StartOffset != TimeSpan.Zero)
				cb.Seek(string.Format("{0:c}", StartOffset));
			
			cb.AddEntry(FileFullPath);
			
			for(int i = 0; i < Overlays.Length; i++) {
				if(Overlays[i].Item1 >= 0 && !string.IsNullOrWhiteSpace(Overlays[i].Item2)) {
					cb.AddEntry(Overlays[i].Item2);
				}
			}
			if(EndOffset != TimeSpan.Zero)
				cb.To(string.Format("{0:c}", EndOffset - StartOffset));
			
			if(!string.IsNullOrWhiteSpace(ResizeHeight) || !string.IsNullOrWhiteSpace(ResizeWidth)) {
				cb.FilterComplex.Resize(ResizeWidth, ResizeHeight);
			}
			if(Rotate < 4) {
				cb.FilterComplex.Transpose((Transpose)Rotate);
			}
			int j = 1;
			for(int i = 0; i < Overlays.Length; i++) {
				if(Overlays[i].Item1 >= 0 && !string.IsNullOrWhiteSpace(Overlays[i].Item2)) {
					cb.FilterComplex.Overlay((Overlay)Overlays[i].Item1, string.Format("[{0}]", j++));
				}
			}
			
			cb.VideoCodec(VideoEncoding.X264).Param(Parameter.V_BITRATE, MP4_bv);
			
			if(NoSound)
				cb.AudioCodec(AudioEncoding.NOAUDIO);
			else
				cb.AudioCodec(AudioEncoding.AAC).Param(Parameter.A_BITRATE, MP4_ba);
			
			if(Overwrite)
				cb.Param(Parameter.MISC_OVERWRITE_YES);
			else
				cb.Param(Parameter.MISC_OVERWRITE_NO);
			
			string cde = cb.Output(output);
			
			SendLog("\r\nffmpeg " + cde);
			SendLog("------------------------------------------------------------");
			if(output.Equals(FileFullPath, StringComparison.CurrentCultureIgnoreCase))
				SendLog(I18n.Get("ErrorSameInputOutput"));
			else {
				ProcessStartInfo psi = new ProcessStartInfo(Common.ffmpeg, cde);
				psi.UseShellExecute = false;
				psi.CreateNoWindow = true;
				psi.RedirectStandardError = true;
				using(Process p = new Process()) {
					_currentProcess = p;
					p.StartInfo = psi;
					p.Start();
					string line;
					while ((line = p.StandardError.ReadLine()) != null) {
						SendLog(line);
						Application.DoEvents();
					}
					p.WaitForExit();
				}
				_currentProcess = null;
			}
		}
		
		private static bool CanWriteDirectory(string directory) {
			if(!Directory.Exists(directory))
				return false;
			PermissionSet permissionSet = new PermissionSet(PermissionState.None);
			FileIOPermission writePermission = new FileIOPermission(FileIOPermissionAccess.Write, directory);
			permissionSet.AddPermission(writePermission);
			return permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet);
		}
		
	}
	
}
