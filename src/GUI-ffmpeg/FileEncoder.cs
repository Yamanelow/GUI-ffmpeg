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
using System.Linq;
using System.Windows.Forms;

namespace ffmpeg {
	
	public partial class FileEncoder : Form {
		
		#region Ctor
		public FileEncoder() : this(new List<MediaFormat>(), new List<VideoEncoding>(), new List<AudioEncoding>()) {}
		public FileEncoder(IList<MediaFormat> forbiddenFormat, IList<VideoEncoding> forbiddenVideoCodec, IList<AudioEncoding> forbiddenAudioCodec) {
			InitializeComponent();
			
			cbFormat.DataSource = Enum.GetValues(typeof(MediaFormat))
				.Cast<MediaFormat>()
				.Where(p => { return forbiddenFormat == null || !forbiddenFormat.Contains(p); })
				.Select(p => new { Key = p.LongName(), Value = p.Command() })
				.ToList();
			cbFormat.DisplayMember = "Key";
			cbFormat.ValueMember = "Value";
			
			cbCV.DataSource = Enum.GetValues(typeof(VideoEncoding))
				.Cast<VideoEncoding>()
				.Where(p => { return forbiddenVideoCodec == null || !forbiddenVideoCodec.Contains(p); })
				.Select(p => new { Key = p.LongName(), Value = (int)p })
				.ToList();
			cbCV.DisplayMember = "Key";
			cbCV.ValueMember = "Value";
			
			cbCA.DataSource = Enum.GetValues(typeof(AudioEncoding))
				.Cast<AudioEncoding>()
				.Where(p => { return forbiddenAudioCodec == null || !forbiddenAudioCodec.Contains(p); })
				.Select(p => new { Key = p.LongName(), Value = (int)p })
				.ToList();
			cbCA.DisplayMember = "Key";
			cbCA.ValueMember = "Value";
			
			cbBA.DataSource = Enum.GetValues(typeof(BitrateMp3))
				.Cast<BitrateMp3>()
				.Select(p => new { Key = p.ToString() + (p == BitrateMp3.Defaut ? string.Empty : " (" + ((int)p).ToString() + ")"), Value = (int)p })
				.ToList();
			cbBA.DisplayMember = "Key";
			cbBA.ValueMember = "Value";
			
			cbSR.DataSource = Enum.GetValues(typeof(SamplingRate))
				.Cast<SamplingRate>()
				.Select(p => new { Key = p.ToString() + (p == SamplingRate.Defaut ? string.Empty : " (" + ((int)p).ToString() + ")"), Value = (int)p })
				.ToList();
			cbSR.DisplayMember = "Key";
			cbSR.ValueMember = "Value";
		}
		#endregion
		
		#region Vars / properties
		private CommandLineBuilder _builder;
		private MediaInfo _media;
		#endregion
		
		#region Disable/enable audio line
		private void DisableAudio() {
			gbAudio.Enabled = false;
			foreach(Control c in gbAudio.Controls)
				c.Enabled = false;
		}
		private void EnableAudio() {
			gbAudio.Enabled = true;
			foreach(Control c in gbAudio.Controls)
				c.Enabled = true;
		}
		#endregion
		
		#region Disable/enable video line
		private void DisableVideo() {
			gbVideo.Enabled = false;
			foreach(Control c in gbVideo.Controls)
				c.Enabled = false;
		}
		private void EnableVideo() {
			gbVideo.Enabled = true;
			foreach(Control c in gbVideo.Controls)
				c.Enabled = true;
		}
		#endregion
		
		#region Validation
		private void Validate(object sender, EventArgs e) {
			if(_media == null) {
				MessageBox.Show("Aucun fichier valable en entrée.");
				return;
			}
			
			if(tbOut.Text.Length == 0) {
				MessageBox.Show("Choisissez un fichier de sortie.");
				return;
			}
			
			if(tbFile.Text.Equals(tbOut.Text)) {
				MessageBox.Show(I18n.Get("ErrorSameInputOutput"));
				return;
			}
			
			_builder = new CommandLineBuilder();
			_builder.AddEntry(tbFile.Text);
			
			int tmp;
			if(gbVideo.Enabled) {
				// Vérification CRF
				if(tbCRF.Text.Length != 0) {
					if(!int.TryParse(tbCRF.Text, out tmp)) {
						MessageBox.Show(string.Format(I18n.Get("FormatCrf"), Common.CRF_MIN, Common.CRF_MAX));
						_builder = null;
						return;
					}
					if(tmp < Common.CRF_MIN || tmp > Common.CRF_MAX) {
						MessageBox.Show(string.Format(I18n.Get("FormatCrf"), Common.CRF_MIN, Common.CRF_MAX));
						_builder = null;
						return;
					}
					_builder.Param(Parameter.V_CRF, tbCRF.Text);
				}
				
				// Vérification Qscale
				if(tbQscale.Text.Length != 0) {
					if(!int.TryParse(tbQscale.Text, out tmp)) {
						MessageBox.Show(string.Format(I18n.Get("FormatQscale"), Common.QSCALE_MIN, Common.QSCALE_MAX));
						_builder = null;
						return;
					}
					if(tmp < Common.QSCALE_MIN || tmp > Common.QSCALE_MAX) {
						MessageBox.Show(string.Format(I18n.Get("FormatQscale"), Common.QSCALE_MIN, Common.QSCALE_MAX));
						_builder = null;
						return;
					}
					_builder.Param(Parameter.V_QSCALE, tbQscale.Text);
				}
				
				// Vérification Qmin
				int qmin = 4;
				if(tbQmin.Text.Length != 0) {
					if(!int.TryParse(tbQmin.Text, out qmin)) {
						MessageBox.Show(string.Format(I18n.Get("FormatQmin"), Common.QMIN_MIN, Common.QMIN_MAX));
						_builder = null;
						return;
					}
					if(qmin < Common.QMIN_MIN || qmin > Common.QMIN_MAX) {
						MessageBox.Show(string.Format(I18n.Get("FormatQmin"), Common.QMIN_MIN, Common.QMIN_MAX));
						_builder = null;
						return;
					}
					_builder.Param(Parameter.V_QMIN, tbQmin.Text);
				}
				
				// Vérification Qmax
				if(tbQmax.Text.Length != 0) {
					if(!int.TryParse(tbQmax.Text, out tmp)) {
						MessageBox.Show(string.Format(I18n.Get("FormatQmax"), qmin, Common.QMAX_MAX));
						_builder = null;
						return;
					}
					if(tmp < qmin || tmp > Common.QMAX_MAX) {
						MessageBox.Show(string.Format(I18n.Get("FormatQmax"), qmin, Common.QMAX_MAX));
						_builder = null;
						return;
					}
					_builder.Param(Parameter.V_QMAX, tbQmax.Text);
				}
				
				// Vérification Bitrate
				if(tbBV.Text.Length != 0) {
					bool unit = tbBV.Text.EndsWith("k", StringComparison.CurrentCultureIgnoreCase) || tbBV.Text.EndsWith("m", StringComparison.CurrentCultureIgnoreCase);
					if(!int.TryParse(unit ? tbBV.Text.Substring(0, tbBV.Text.Length - 1) : tbBV.Text, out tmp)) {
						MessageBox.Show(I18n.Get("FormatBitrate"));
						_builder = null;
						return;
					}
					if(tmp <= 0) {
						MessageBox.Show(I18n.Get("FormatBitrate"));
						_builder = null;
						return;
					}
					_builder.Param(Parameter.V_BITRATE, tbBV.Text);
				}
				
				_builder.VideoCodec((VideoEncoding)cbCV.SelectedValue);
			} else {
				_builder.VideoCodec(VideoEncoding.NOVIDEO);
			}
			
			if(gbAudio.Enabled) {
				_builder.AudioCodec((AudioEncoding)cbCA.SelectedValue);
				BitrateMp3 br = (BitrateMp3)Enum.Parse(typeof(BitrateMp3), cbBA.SelectedValue.ToString());
				if(br != BitrateMp3.Defaut)
					_builder.Param(Parameter.A_BITRATE, ((int)br).ToString());
				SamplingRate sr = (SamplingRate)Enum.Parse(typeof(SamplingRate), cbSR.SelectedValue.ToString());
				if(sr != SamplingRate.Defaut)
					_builder.Param(Parameter.A_SAMPLE, ((int)sr).ToString());
			} else {
				_builder.AudioCodec(AudioEncoding.NOAUDIO);
			}
			
			_builder.Param(Parameter.NONE, cbFormat.SelectedValue.ToString()).Param(Parameter.MISC_OVERWRITE_YES);
			
			this.DialogResult = DialogResult.OK;
		}
		#endregion
		
		#region Cancel
		private void Cancel(object sender, EventArgs e) {
			_builder = null;
			this.DialogResult = DialogResult.Cancel;
		}
		#endregion
		
		#region File selection
		private void SelectFile(object sender, EventArgs e) {
			using(OpenFileDialog ofd = new OpenFileDialog()) {
				ofd.Filter = I18n.Get("FilterAllMedia");
				if(ofd.ShowDialog() != DialogResult.OK)
					return;
				try {
					_media = MediaInfo.Query(ofd.FileName);
					tbFile.Text = ofd.FileName;
					if(_media.VideoInfo != null) {
						EnableVideo();
						lV.Text = I18n.Get("ConcatVideoStreamHeadDesc") +
							_media.VideoInfo.codec_name + " - " +
							_media.VideoInfo.width.ToString() + "x" + _media.VideoInfo.height.ToString()+ " - " +
							_media.VideoInfo.duration.ToString() + "s" +
							(_media.VideoInfo.bit_rateSpecified ? " - Bitrate " + _media.VideoInfo.bit_rate.ToReadableString() : string.Empty);
					} else {
						DisableVideo();
						lV.Text = I18n.Get("ConcatNoVideoStream");
					}
					if(_media.AudioInfo != null) {
						EnableAudio();
						lA.Text = I18n.Get("ConcatAudioStreamHeadDesc") +
							_media.AudioInfo.codec_name + " - " +
							_media.AudioInfo.duration.ToString() + "s" +
							(_media.AudioInfo.bit_rateSpecified ? " - Bitrate " + _media.AudioInfo.bit_rate.ToReadableString() : string.Empty) +
							(_media.AudioInfo.sample_rateSpecified ? " - SampleRate " + _media.AudioInfo.sample_rate.ToReadableString() : string.Empty);
					} else {
						DisableAudio();
						lA.Text = I18n.Get("ConcatNoAudioStream");
					}
				} catch(CoreException cex) {
					MessageBox.Show(cex.Message);
					_media = null;
					lV.Text = I18n.Get("ConcatNoVideoStream");
					lA.Text = I18n.Get("ConcatNoAudioStream");
					tbFile.Text = string.Empty;
				}
			}
		}
		#endregion
		
		#region Output selection
		private void SelectOutput(object sender, EventArgs e) {
			using(SaveFileDialog sfd = new SaveFileDialog()) {
				if(sfd.ShowDialog() != DialogResult.OK)
					return;
				if(sfd.FileName.Equals(tbFile.Text)) {
					MessageBox.Show("Vous ne pouvez pas choisir le même fichier que l'entrée.");
					return;
				}
				tbOut.Text = sfd.FileName;
			}
		}
		#endregion
		
		public static void Run() {
			using(FileEncoder fenc = new FileEncoder()) {
				if(fenc.ShowDialog() != DialogResult.OK)
					return;
				if(fenc._builder == null)
					return;
				try {
					string str = fenc._builder.Output(fenc.tbOut.Text);
					LogWindow lw = new LogWindow();
					lw.Show();
					lw.Log(str + "\r\n");
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
		}
		
	}
	
}
