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
	
	public partial class ConcatSelector : Form {
		
		#region Ctor
		public ConcatSelector() {
			InitializeComponent();
			Builder = new CommandLineBuilder();
			Mode = ConcatMode.Undefined;
			lblMode.Text = Mode.LongName();
		}
		#endregion
		
		#region Vars / Properties
		private MediaInfo[] _medias = new MediaInfo[3];
		
		public ConcatMode Mode { get; private set; }
		public CommandLineBuilder Builder { get; private set; }
		#endregion
		
		#region Select file handling
		public void SetSelection(int index, string file) {
			switch(index) {
				case 0:
					SetSelection(index, file, tbFile1, lA1, lV1);
					return;
				case 1:
					SetSelection(index, file, tbFile2, lA2, lV2);
					return;
				case 2:
					SetSelection(index, file, tbFile3, lA3, lV3);
					return;
			}
		}
		
		private void SetSelection(int index, string file, TextBox tb, Label lbAudio, Label lbVideo) {
			try {
				_medias[index] = MediaInfo.Query(file);
				tb.Text = file;
				if(_medias[index].VideoInfo != null)
					lbVideo.Text = I18n.Get("ConcatVideoStreamHeadDesc") +
						_medias[index].VideoInfo.codec_name + " - " +
						_medias[index].VideoInfo.width.ToString() + "x" + _medias[index].VideoInfo.height.ToString()+ " - " +
						_medias[index].VideoInfo.duration.ToString() + "s" +
						(_medias[index].VideoInfo.bit_rateSpecified ? " - Bitrate " + _medias[index].VideoInfo.bit_rate.ToReadableString() : string.Empty);
				else
					lbVideo.Text = I18n.Get("ConcatNoVideoStream");
				if(_medias[index].AudioInfo != null)
					lbAudio.Text = I18n.Get("ConcatAudioStreamHeadDesc") +
						_medias[index].AudioInfo.codec_name + " - " +
						_medias[index].AudioInfo.duration.ToString() + "s" +
						(_medias[index].AudioInfo.bit_rateSpecified ? " - Bitrate " + _medias[index].AudioInfo.bit_rate.ToReadableString() : string.Empty) +
						(_medias[index].AudioInfo.sample_rateSpecified ? " - SampleRate " + _medias[index].AudioInfo.sample_rate.ToReadableString() : string.Empty);
				else
					lbAudio.Text = I18n.Get("ConcatNoAudioStream");
			} catch(CoreException cex) {
				MessageBox.Show(cex.Message);
				_medias[index] = null;
				lbVideo.Text = I18n.Get("ConcatNoVideoStream");
				lbAudio.Text = I18n.Get("ConcatNoAudioStream");
				tb.Text = string.Empty;
			}
			
			if(_medias[0] != null) {
				if(_medias[0].VideoInfo != null && _medias[0].AudioInfo != null)
					Mode = ConcatMode.Both;
				else if(_medias[0].VideoInfo != null)
					Mode = ConcatMode.Video;
				else
					Mode = ConcatMode.Audio;
			} else if(_medias[1] != null) {
				if(_medias[1].VideoInfo != null && _medias[1].AudioInfo != null)
					Mode = ConcatMode.Both;
				else if(_medias[1].VideoInfo != null)
					Mode = ConcatMode.Video;
				else
					Mode = ConcatMode.Audio;
			} else if(_medias[2] != null) {
				if(_medias[2].VideoInfo != null && _medias[2].AudioInfo != null)
					Mode = ConcatMode.Both;
				else if(_medias[2].VideoInfo != null)
					Mode = ConcatMode.Video;
				else
					Mode = ConcatMode.Audio;
			} else {
				Mode = ConcatMode.Undefined;
			}
			lblMode.Text = Mode.LongName();
		}
		#endregion
		
		#region Lock 1st line in case of preselection from shell
		public void Lock1stLine() {
			tbFile1.Enabled = false;
			btnDelete1.Visible = false;
			btnSelect1.Visible = false;
		}
		#endregion
		
		#region Selection / Deletion events
		private void Select1(object sender, EventArgs e) {
			using(OpenFileDialog ofd = new OpenFileDialog()) {
				ofd.Filter = I18n.Get("FilterAllMedia");
				if(ofd.ShowDialog() != DialogResult.OK)
					return;
				SetSelection(0, ofd.FileName);
			}
		}
		
		private void Delete1(object sender, EventArgs e) {
			_medias[0] = null;
			lV1.Text = I18n.Get("ConcatNoVideoStream");
			lA1.Text = I18n.Get("ConcatNoAudioStream");
			tbFile1.Text = string.Empty;
		}
		
		private void Select2(object sender, EventArgs e) {
			
			using(OpenFileDialog ofd = new OpenFileDialog()) {
				ofd.Filter = I18n.Get("FilterAllMedia");
				if(ofd.ShowDialog() != DialogResult.OK)
					return;
				SetSelection(1, ofd.FileName);
			}
		}
		
		private void Delete2(object sender, EventArgs e) {
			_medias[1] = null;
			lV2.Text = I18n.Get("ConcatNoVideoStream");
			lA2.Text = I18n.Get("ConcatNoAudioStream");
			tbFile2.Text = string.Empty;
		}
		
		private void Select3(object sender, EventArgs e) {
			using(OpenFileDialog ofd = new OpenFileDialog()) {
				ofd.Filter = I18n.Get("FilterAllMedia");
				if(ofd.ShowDialog() != DialogResult.OK)
					return;
				SetSelection(2, ofd.FileName);
			}
		}
		
		private void Delete3(object sender, EventArgs e) {
			_medias[2] = null;
			lV3.Text = I18n.Get("ConcatNoVideoStream");
			lA3.Text = I18n.Get("ConcatNoAudioStream");
			tbFile3.Text = string.Empty;
		}
		#endregion
		
		#region Validation
		private void Validate(object sender, EventArgs e) {
			if(_medias.Count(new Func<MediaInfo, bool>( (MediaInfo mi) => { return mi != null; })) < 2) {
				MessageBox.Show(I18n.Get("ConcatSelect2FilesMin"));
				return;
			}
			
			int cnt = 0;
			List<string> entries = new List<string>();
			
			string s = string.Empty;
			for(int i = 0; i < _medias.Length; i++) {
				if(_medias[i] != null) {
					if(Mode == ConcatMode.Both || Mode == ConcatMode.Video) {
						// Présence du flux vidéo
						if(_medias[i].VideoInfo == null) {
							MessageBox.Show(string.Format(I18n.Get("ConcatFileNoVideo"), i + 1));
							return;
						}
						// Vérification de la taille
						if(s.Length == 0)
							s = string.Format("{0}x{1}", _medias[i].VideoInfo.width, _medias[i].VideoInfo.height);
						else if(!s.Equals(string.Format("{0}x{1}", _medias[i].VideoInfo.width, _medias[i].VideoInfo.height))) {
							MessageBox.Show("ConcatVideoSameSize");
							return;
						}
					}
					if(Mode == ConcatMode.Both || Mode == ConcatMode.Audio) {
						// Présence du flux audio
						if(_medias[i].AudioInfo == null) {
							MessageBox.Show(string.Format(I18n.Get("ConcatFileNoAudio"), i + 1));
							return;
						}
					}
					// Uniformité des types de flux
					if(Mode == ConcatMode.Audio && _medias[i].VideoInfo != null) {
						MessageBox.Show(string.Format(I18n.Get("ConcatFileHasVideo"), i + 1));
						return;
					}
					if(Mode == ConcatMode.Video && _medias[i].AudioInfo != null) {
						MessageBox.Show(string.Format(I18n.Get("ConcatFileHasAudio"), i + 1));
						return;
					}
					
					// Arrivé ici le fichier est valide, on ajoute aux listes
					if(Mode == ConcatMode.Both) {
						entries.Add(string.Format("[{0}:0] [{0}:1] ", cnt++));
					} else {
						entries.Add(string.Format("[{0}:0] ", cnt++));
					}
				}
			}
			
			// Ajout des entrées
			if(tbFile1.Text.Length > 0)
				Builder.AddEntry(tbFile1.Text);
			if(tbFile2.Text.Length > 0)
				Builder.AddEntry(tbFile2.Text);
			if(tbFile3.Text.Length > 0)
				Builder.AddEntry(tbFile3.Text);
			
			// Parametrage du concat
			Builder.FilterComplex.Concat(entries, Mode == ConcatMode.Both || Mode == ConcatMode.Video, Mode == ConcatMode.Both || Mode == ConcatMode.Audio, string.Empty)
				.Param(Parameter.MISC_OVERWRITE_YES);
			
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
