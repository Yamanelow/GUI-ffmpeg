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
using System.Linq;
using System.Windows.Forms;

namespace ffmpeg {
	
	public partial class FormatSelector : Form {
		
		#region Ctor
		public FormatSelector(CommandLineBuilder builder) : this(builder, new List<MediaFormat>(), new List<VideoEncoding>(), new List<AudioEncoding>()) {}
		public FormatSelector(CommandLineBuilder builder, IList<MediaFormat> forbiddenFormat, IList<VideoEncoding> forbiddenVideoCodec, IList<AudioEncoding> forbiddenAudioCodec) {
			InitializeComponent();
			
			_builder = builder;
			
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
		#endregion
		
		#region Disable audio line
		public void DisableAudio() {
			gbAudio.Enabled = false;
			foreach(Control c in gbAudio.Controls)
				c.Enabled = false;
			_builder.AudioCodec(AudioEncoding.NOAUDIO);
		}
		#endregion
		
		#region Disable video line
		public void DisableVideo() {
			gbVideo.Enabled = false;
			foreach(Control c in gbVideo.Controls)
				c.Enabled = false;
			_builder.VideoCodec(VideoEncoding.NOVIDEO);
		}
		#endregion
		
		#region Validation
		private void Validate(object sender, EventArgs e) {
			int tmp;
			
			if(gbVideo.Enabled) {
				// Vérification CRF
				if(tbCRF.Text.Length != 0) {
					if(!int.TryParse(tbCRF.Text, out tmp)) {
						MessageBox.Show(string.Format(I18n.Get("FormatCrf"), Common.CRF_MIN, Common.CRF_MAX));
						return;
					}
					if(tmp < Common.CRF_MIN || tmp > Common.CRF_MAX) {
						MessageBox.Show(string.Format(I18n.Get("FormatCrf"), Common.CRF_MIN, Common.CRF_MAX));
						return;
					}
					_builder.Param(Parameter.V_CRF, tbCRF.Text);
				}
				
				// Vérification Qscale
				if(tbQscale.Text.Length != 0) {
					if(!int.TryParse(tbQscale.Text, out tmp)) {
						MessageBox.Show(string.Format(I18n.Get("FormatQscale"), Common.QSCALE_MIN, Common.QSCALE_MAX));
						return;
					}
					if(tmp < Common.QSCALE_MIN || tmp > Common.QSCALE_MAX) {
						MessageBox.Show(string.Format(I18n.Get("FormatQscale"), Common.QSCALE_MIN, Common.QSCALE_MAX));
						return;
					}
					_builder.Param(Parameter.V_QSCALE, tbQscale.Text);
				}
				
				// Vérification Qmin
				int qmin = 4;
				if(tbQmin.Text.Length != 0) {
					if(!int.TryParse(tbQmin.Text, out qmin)) {
						MessageBox.Show(string.Format(I18n.Get("FormatQmin"), Common.QMIN_MIN, Common.QMIN_MAX));
						return;
					}
					if(qmin < Common.QMIN_MIN || qmin > Common.QMIN_MAX) {
						MessageBox.Show(string.Format(I18n.Get("FormatQmin"), Common.QMIN_MIN, Common.QMIN_MAX));
						return;
					}
					_builder.Param(Parameter.V_QMIN, tbQmin.Text);
				}
				
				// Vérification Qmax
				if(tbQmax.Text.Length != 0) {
					if(!int.TryParse(tbQmax.Text, out tmp)) {
						MessageBox.Show(string.Format(I18n.Get("FormatQmax"), qmin, Common.QMAX_MAX));
						return;
					}
					if(tmp < qmin || tmp > Common.QMAX_MAX) {
						MessageBox.Show(string.Format(I18n.Get("FormatQmax"), qmin, Common.QMAX_MAX));
						return;
					}
					_builder.Param(Parameter.V_QMAX, tbQmax.Text);
				}
				
				// Vérification Bitrate
				if(tbBV.Text.Length != 0) {
					bool unit = tbBV.Text.EndsWith("k", StringComparison.CurrentCultureIgnoreCase) || tbBV.Text.EndsWith("m", StringComparison.CurrentCultureIgnoreCase);
					if(!int.TryParse(unit ? tbBV.Text.Substring(0, tbBV.Text.Length - 1) : tbBV.Text, out tmp)) {
						MessageBox.Show(I18n.Get("FormatBitrate"));
						return;
					}
					if(tmp <= 0) {
						MessageBox.Show(I18n.Get("FormatBitrate"));
						return;
					}
					_builder.Param(Parameter.V_BITRATE, tbBV.Text);
				}
				
				_builder.VideoCodec((VideoEncoding)cbCV.SelectedValue);
			}
			
			if(gbAudio.Enabled) {
				_builder.AudioCodec((AudioEncoding)cbCA.SelectedValue);
				BitrateMp3 br = (BitrateMp3)Enum.Parse(typeof(BitrateMp3), cbBA.SelectedValue.ToString());
				if(br != BitrateMp3.Defaut)
					_builder.Param(Parameter.A_BITRATE, ((int)br).ToString());
				SamplingRate sr = (SamplingRate)Enum.Parse(typeof(SamplingRate), cbSR.SelectedValue.ToString());
				if(sr != SamplingRate.Defaut)
					_builder.Param(Parameter.A_SAMPLE, ((int)sr).ToString());
			}
			
			_builder.Param(Parameter.NONE, cbFormat.SelectedValue.ToString());
			
			this.DialogResult = DialogResult.OK;
		}
		#endregion
		
		#region Cancel
		private void Cancel(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}
		#endregion
		
	}
	
}
