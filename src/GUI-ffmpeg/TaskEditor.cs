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
using System.Windows.Forms;

namespace ffmpeg {
	
	public partial class TaskEditor : Form {
		
		#region Vars
		private VideoTask _task;
		#endregion
		
		#region Ctor
		private TaskEditor() {
			InitializeComponent();
		}
		
		public TaskEditor(VideoTask task) {
			InitializeComponent();
			_task = task;
			this.Text = task.FileFullPath;
			tbFile.Text = task.FileFullPath;
			cbMP4.Checked = task.MP4;
			cbFLV.Checked = task.FLV;
			cbWEBM.Checked = task.WEBM;
			cbMP3.Checked = task.MP3;
			tbvbmp4.Text = task.MP4_bv;
			tbvbwebm.Text = task.WEBM_bv;
			tbvbflv.Text = task.FLV_bv;
			tbabmp4.Text = task.MP4_ba;
			tbabwebm.Text = task.WEBM_ba;
			tbabflv.Text = task.FLV_ba;
			tbabmp3.Text = task.MP3_ba;
			tbsrflv.Text = task.FLV_sr;
			tbsrmp3.Text = task.MP3_sr;
			cbNoSound.Checked = task.NoSound;
			cbReplace.Checked = task.WebChar;
			cbPoster.Checked = task.Poster;
			cbJSON.Checked = task.Json;
			cbTN.Checked = task.Thumbnail;
			cbIncTime.Checked = task.LengthOnTn;
			cbOW.Checked = task.Overwrite;
			cbRotate.SelectedIndex = task.Rotate;
			tbWidth.Text = task.ResizeWidth;
			tbHeight.Text = task.ResizeHeight;
			nudStartOffset.Value = task.StartOffset;
			nudEndOffset.Value = task.EndOffset;
			nudMinWidth.Value = task.TnWidth;
			nudMinHeight.Value = task.TnHeight;
			cbOL1.SelectedIndex = task.Overlays[0].Item1;
			cbOL2.SelectedIndex = task.Overlays[1].Item1;
			cbOL3.SelectedIndex = task.Overlays[2].Item1;
			cbOL4.SelectedIndex = task.Overlays[3].Item1;
			tbOL1.Text = task.Overlays[0].Item2;
			tbOL2.Text = task.Overlays[1].Item2;
			tbOL3.Text = task.Overlays[2].Item2;
			tbOL4.Text = task.Overlays[3].Item2;
		}
		#endregion
		
		#region Task edit function
		public static EditorResult Edit(VideoTask task) {
			using(TaskEditor te = new TaskEditor(task)) {
				if(te.ShowDialog() != DialogResult.OK)
					return EditorResult.Cancel;
				return te.cbSameForAll.Checked ? EditorResult.SameForAll : EditorResult.OK;
			}
		}
		#endregion
		
		#region Cancel edit
		private void Annuler(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}
		#endregion
		
		#region Validate edit
		private void Valider(object sender, EventArgs e) {
			_task.MP4 = cbMP4.Checked;
			_task.FLV = cbFLV.Checked;
			_task.WEBM = cbWEBM.Checked;
			_task.MP3 = cbMP3.Checked;
			_task.MP4_bv = tbvbmp4.Text;
			_task.WEBM_bv = tbvbwebm.Text;
			_task.FLV_bv = tbvbflv.Text;
			_task.MP4_ba = tbabmp4.Text;
			_task.WEBM_ba = tbabwebm.Text;
			_task.FLV_ba = tbabflv.Text;
			_task.MP3_ba = tbabmp3.Text;
			_task.FLV_sr = tbsrflv.Text;
			_task.MP3_sr = tbsrmp3.Text;
			_task.NoSound = cbNoSound.Checked;
			_task.WebChar = cbReplace.Checked;
			_task.Poster = cbPoster.Checked;
			_task.Json = cbJSON.Checked;
			_task.Thumbnail = cbTN.Checked;
			_task.LengthOnTn = cbIncTime.Checked;
			_task.Overwrite = cbOW.Checked;
			_task.Rotate = cbRotate.SelectedIndex;
			_task.ResizeWidth = tbWidth.Text;
			_task.ResizeHeight = tbHeight.Text;
			_task.StartOffset = nudStartOffset.Value;
			_task.EndOffset = nudEndOffset.Value;
			_task.TnWidth = (int)nudMinWidth.Value;
			_task.TnHeight = (int)nudMinHeight.Value;
			_task.Overlays = new Tuple<int, string>[] {
				new Tuple<int, string>(cbOL1.SelectedIndex, tbOL1.Text),
				new Tuple<int, string>(cbOL2.SelectedIndex, tbOL2.Text),
				new Tuple<int, string>(cbOL3.SelectedIndex, tbOL3.Text),
				new Tuple<int, string>(cbOL4.SelectedIndex, tbOL4.Text)
			};
			this.DialogResult = DialogResult.OK;
		}
		#endregion
		
		#region Overlay picture selection
		private void SelectOverlayImage(object sender, EventArgs e) {
			using(OpenFileDialog ofd = new OpenFileDialog()) {
				ofd.Filter = "Fichiers image (.*bmp *.jpg *.png)|.*bmp;*.jpg;*.png|Fichiers vidéo (.*avi *.mp4 *.webm)|.*avi;*.mp4;*.webm";
				if(ofd.ShowDialog() == DialogResult.OK) {
					switch((sender as Button).Name) {
						case "btnOL1":
							tbOL1.Text = ofd.FileName;
							break;
						case "btnOL2":
							tbOL2.Text = ofd.FileName;
							break;
						case "btnOL3":
							tbOL3.Text = ofd.FileName;
							break;
						case "btnOL4":
							tbOL4.Text = ofd.FileName;
							break;
					}
				}
			}
		}
		#endregion
		
	}
	
}
