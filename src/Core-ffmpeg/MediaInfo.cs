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
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

using ffmpeg.Schemas;

namespace ffmpeg {
	
	public class MediaInfo {
		
		#region Vars / properties
		public formatType FormatInfo = null;
		public streamType VideoInfo = null;
		public streamType AudioInfo = null;
		#endregion
		
		#region Ctor
		public MediaInfo(string xml) {
			try {
				using(TextReader ms = new StringReader(xml)) {
					XmlSerializer xs = new XmlSerializer(typeof(ffprobeType));
					ffprobeType ff = xs.Deserialize(ms) as ffprobeType;
					if(ff == null || ff.streams == null || ff.format == null)
						throw new CoreException(I18n.Get("ErrorInvalidFormat"));
					if(ff.streams.Length > 2)
						throw new CoreException(I18n.Get("ErrorNoMore2Streams"));
					FormatInfo = ff.format;
					foreach(streamType st in ff.streams) {
						if("video".Equals(st.codec_type)) {
							if(VideoInfo != null)
								throw new CoreException(I18n.Get("ErrorNoMore1Video"));
							VideoInfo = st;
						} else {
							if(AudioInfo != null)
								throw new CoreException(I18n.Get("ErrorNoMore1Audio"));
							AudioInfo = st;
						}
					}
				}
			} catch(Exception ex) {
				FormatInfo = null;
				VideoInfo = null;
				AudioInfo = null;
				ex.PreserveStackTrace();
				throw new CoreException(ex.Message, ex);
			}
		}
		#endregion
		
		#region Media check
		public static bool Check(string file, bool? mustHaveVideo, bool? mustHaveAudio) {
			return Check(file, mustHaveVideo, mustHaveAudio, false);
		}
		public static bool Check(string file, bool? mustHaveVideo, bool? mustHaveAudio, bool advertise) {
			MediaInfo mi = Query(file);
			if(mi.FormatInfo == null) {
				if(advertise)
					MessageBox.Show("Le fichier n'est reconnu comme étant un fichier média.\r\n" + file);
				return false;
			}
			if(mustHaveAudio.HasValue) {
				if(mi.AudioInfo == null && mustHaveAudio.Value) {
					if(advertise)
						MessageBox.Show("Le fichier ne possède pas de flux audio.\r\n" + file);
					return false;
				}
				if(mi.AudioInfo != null && !mustHaveAudio.Value) {
					if(advertise)
						MessageBox.Show("Le fichier possède un flux audio.\r\n" + file);
					return false;
				}
			}
			if(mustHaveVideo.HasValue) {
				if(mi.VideoInfo == null && mustHaveVideo.Value) {
					if(advertise)
						MessageBox.Show("Le fichier ne possède pas de flux vidéo.\r\n" + file);
					return false;
				}
				if(mi.VideoInfo != null && !mustHaveVideo.Value) {
					if(advertise)
						MessageBox.Show("Le fichier possède un flux vidéo.\r\n" + file);
					return false;
				}
			}
			return true;
		}
		#endregion
		
		#region Media query
		public static MediaInfo Query(string file) {
			if(!File.Exists(file))
				throw new CoreException(I18n.Get("ErrorFileNotExists"));
			if(!File.Exists(Common.ffprobe))
				throw new CoreException(I18n.Get("ErrorFfprobeNotFound"));
			StringBuilder xml = new StringBuilder();
			ProcessStartInfo psi = new ProcessStartInfo(Common.ffprobe, "-i \"" + file + "\" -v quiet -of xml -show_format -show_streams");
			psi.UseShellExecute = false;
			psi.CreateNoWindow = true;
			psi.RedirectStandardError = true;
			psi.RedirectStandardOutput = true;
			using(Process p = new Process()) {
				p.StartInfo = psi;
				p.Start();
				string line;
				while ((line = p.StandardOutput.ReadLine()) != null) {
					xml.AppendLine(line);
					Application.DoEvents();
				}
				p.WaitForExit();
			}
			MediaInfo mi = new MediaInfo(xml.ToString());
			if(mi.FormatInfo == null)
				throw new CoreException(I18n.Get("ErrorInvalidFormat"));
			if(mi.AudioInfo == null && mi.VideoInfo == null)
				throw new CoreException(I18n.Get("ErrorNoAudioVideo"));
			
			return mi;
		}
		#endregion
		
	}
	
}
