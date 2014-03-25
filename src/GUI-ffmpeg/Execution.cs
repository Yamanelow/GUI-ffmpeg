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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ffmpeg {
	
	public static class Execution {
		
		#region ffmpeg & ffprobe check
		public static bool ffmpegPresent() {
			return ffmpegPresent(true);
		}
		public static bool ffmpegPresent(bool advertise) {
			if(File.Exists(Common.ffmpeg))
				return true;
			if(advertise)
				MessageBox.Show("ffmpeg est introuvable, vérifiez qu'il se trouve bien dans le répertoire de l'application");
			return false;
		}
		public static bool ffprobePresent() {
			return ffprobePresent(true);
		}
		public static bool ffprobePresent(bool advertise) {
			if(File.Exists(Common.ffmpeg))
				return true;
			if(advertise)
				MessageBox.Show("ffmpeg est introuvable, vérifiez qu'il se trouve bien dans le répertoire de l'application");
			return false;
		}
		#endregion
		
		#region Concatenation
		public static void Concat() {
			if(!ffmpegPresent() || !ffprobePresent())
				return;
			Concat(null);
		}
		public static void Concat(IList<string> files) {
			if(!ffmpegPresent() || !ffprobePresent())
				return;
			try {
				CommandLineBuilder builder = null;
				using(ConcatSelector cs = new ConcatSelector()) {
					if(files != null) {
						int j = 0;
						for(int i = 0; i < files.Count && j < 3; i++) {
							if(!string.IsNullOrWhiteSpace(files[i])) {
								if(File.Exists(files[i]) && MediaInfo.Check(files[i], null, null)) {
									cs.SetSelection(i, files[i]);
									if(j++ == 0)
										cs.Lock1stLine();
								}
							}
						}
					}
					if(cs.ShowDialog() != DialogResult.OK)
						return;
					builder = cs.Builder;
					
					// Choix du format de sortie
					using(FormatSelector fs = new FormatSelector(
						builder,
						cs.Mode == ConcatMode.Audio ? Common.GetVideoFormats(new MediaFormat[] { MediaFormat.DEFAULT }) : Common.GetAudioFormats(new MediaFormat[] { MediaFormat.DEFAULT }),
						new VideoEncoding[] { VideoEncoding.COPY, VideoEncoding.DEFAULT, VideoEncoding.NOVIDEO },
						new AudioEncoding[] { AudioEncoding.COPY, AudioEncoding.DEFAULT, AudioEncoding.NOAUDIO })
					     ) {
						if(cs.Mode == ConcatMode.Video)
							fs.DisableAudio();
						if(cs.Mode == ConcatMode.Audio)
							fs.DisableVideo();
						if(fs.ShowDialog() != DialogResult.OK)
							return;
					}
				}
				
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = "Tout type de fichier media|*.*";
				if(sfd.ShowDialog() != DialogResult.OK)
					return;
				string str = builder.Output(sfd.FileName);
				
				LogWindow lw = new LogWindow();
				lw.Show();
				using(Process p = new Process()) {
					ProcessStartInfo psi = new ProcessStartInfo(Common.ffmpeg, str);
					psi.UseShellExecute = false;
					psi.CreateNoWindow = true;
					psi.RedirectStandardError = true;
					p.StartInfo = psi;
					p.Start();
					string line;
					while ((line = p.StandardError.ReadLine()) != null) {
						lw.Log(line);
						Application.DoEvents();
					}
					p.WaitForExit();
				}
				lw.Log("\r\n---------------------------------------------\r\nFin de l'opération\r\n---------------------------------------------");
				lw.CanBeClosed = true;
			} catch(Exception ex) {
				MessageBox.Show(ex.Message);
				MessageBox.Show(ex.StackTrace);
			}
		}
		#endregion
		
		#region No sound
		public static void NoSound() {
			if(!ffmpegPresent() || !ffprobePresent())
				return;
			using(OpenFileDialog ofd = new OpenFileDialog()) {
				ofd.Title = "Fichier à traiter";
				ofd.Filter = "Fichier à traiter|*.*";
				if(ofd.ShowDialog() != DialogResult.OK)
					return;
				NoSound(ofd.FileNames);
			}
		}
		
		public static void NoSound(IList<string> files) {
			if(!ffmpegPresent() || !ffprobePresent())
				return;
			if(files == null)
				throw new ArgumentNullException("files");
			try {
				foreach(string path in files) {
					// Checks
					if(!File.Exists(path)) {
						MessageBox.Show("Le fichier demandé n'existe pas !\r\n" + path);
						continue;
					}
					if(!MediaInfo.Check(path, true, true, true))
						continue;
					
					// Processing
					using(SaveFileDialog sfd = new SaveFileDialog()) {
						sfd.Title = "Sortie : " + Path.GetFileName(path);
						string ext = Path.GetExtension(path);
						sfd.Filter = "*" + ext + "|*" + ext;
						sfd.DefaultExt = ext.Substring(1);
						if(sfd.ShowDialog() != DialogResult.OK)
							continue;
						
						LogWindow lw = new LogWindow();
						lw.Show();
						using(Process p = new Process()) {
							ProcessStartInfo psi = new ProcessStartInfo(Common.ffmpeg, CommandLineBuilder.RemoveSound(path, sfd.FileName));
							psi.UseShellExecute = false;
							psi.CreateNoWindow = true;
							psi.RedirectStandardError = true;
							p.StartInfo = psi;
							p.Start();
							string line;
							while ((line = p.StandardError.ReadLine()) != null) {
								lw.Log(line);
								Application.DoEvents();
							}
							p.WaitForExit();
						}
						lw.Log("\r\n---------------------------------------------\r\nFin de l'opération\r\n---------------------------------------------");
						lw.CanBeClosed = true;
					}
				}
			} catch(Exception ex) {
				MessageBox.Show(ex.Message);
				MessageBox.Show(ex.StackTrace);
			}
		}
		#endregion
		
		#region Mp3 extraction
		public static void GetMp3() {
			if(!ffmpegPresent() || !ffprobePresent())
				return;
			using(OpenFileDialog ofd = new OpenFileDialog()) {
				ofd.Title = "Fichier à traiter";
				ofd.Filter = "Fichier à traiter|*.*";
				if(ofd.ShowDialog() != DialogResult.OK)
					return;
				GetMp3(ofd.FileNames);
			}
		}
		
		public static void GetMp3(IList<string> files) {
			if(!ffmpegPresent() || !ffprobePresent())
				return;
			if(files == null)
				throw new ArgumentNullException("files");
			try {
				foreach(string path in files) {
					// Checks
					if(!File.Exists(path)) {
						MessageBox.Show("Le fichier demandé n'existe pas !\r\n" + path);
						continue;
					}
					if(!MediaInfo.Check(path, null, true, true))
						continue;
					
					// Processing
					using(SaveFileDialog sfd = new SaveFileDialog()) {
						sfd.Title = "Sortie : " + Path.GetFileName(path);
						sfd.Filter = "Fichier de sortie mp3|*.mp3";
						sfd.DefaultExt = "mp3";
						if(sfd.ShowDialog() != DialogResult.OK)
							return;
						
						LogWindow lw = new LogWindow();
						lw.Show();
						using(Process p = new Process()) {
							ProcessStartInfo psi = new ProcessStartInfo(Common.ffmpeg, CommandLineBuilder.ExtractMp3(path, sfd.FileName, BitrateMp3.Standard, SamplingRate.AudioCD));
							psi.UseShellExecute = false;
							psi.CreateNoWindow = true;
							psi.RedirectStandardError = true;
							p.StartInfo = psi;
							p.Start();
							string line;
							while ((line = p.StandardError.ReadLine()) != null) {
								lw.Log(line);
								Application.DoEvents();
							}
							p.WaitForExit();
						}
						lw.Log("\r\n---------------------------------------------\r\nFin de l'opération\r\n---------------------------------------------");
						lw.CanBeClosed = true;
					}
				}
			} catch(Exception ex) {
				MessageBox.Show(ex.Message);
				MessageBox.Show(ex.StackTrace);
			}
		}
		#endregion
		
		#region Gui
		public static void Gui() {
			(new MainForm()).ShowDialog();
		}
		public static void Gui(IList<string> files, bool transform = false) {
			if(transform) {
				List<VideoTask> tasks = new List<VideoTask>();
				foreach(string file in files) {
					if(!File.Exists(file))
						continue;
					VideoTask task = new VideoTask() {
						FileFullPath = file,
						LengthOnTn = true,
						MP4 = true,
						MP4_ba = "128k",
						MP4_bv = "5000k",
						Overwrite = true
					};
					tasks.Add(task);
				}
				(new MainForm(tasks)).ShowDialog();
			} else {
				(new MainForm(files)).ShowDialog();
			}
		}
		#endregion
		
		#region FileEncoder
		public static void FileEncode() {
			FileEncoder.Run();
		}
		#endregion
		
	}
	
}
