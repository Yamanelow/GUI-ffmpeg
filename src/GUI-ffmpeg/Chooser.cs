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
using System.Threading;
using System.Windows.Forms;

namespace ffmpeg {
	
	public partial class Chooser : Form {
		
		#region Ctor
		public Chooser() {
			InitializeComponent();
		}
		#endregion
		
		#region Click functions
		private void RunNoSound(object sender, EventArgs e) {
			Execution.NoSound();
		}
		
		private void RunGetMp3(object sender, EventArgs e) {
			Execution.GetMp3();
		}
		
		private void RunConcat(object sender, EventArgs e) {
			Execution.Concat();
		}
		
		private void RunGui(object sender, EventArgs e) {
			this.Hide();
			Execution.Gui();
			this.Show();
		}
		
		private void RunFileEncoder(object sender, EventArgs e) {
			this.Hide();
			Execution.FileEncode();
			this.Show();
		}
		#endregion
		
		#region Drag and drop stuff
		private void OnDragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				e.Effect = DragDropEffects.Copy;
			}
		}
		
		// Must create new thread to avoid Exlorer freeze while processing
		// and Invoke back on the form to keep ShowDialog working as espected
		private void OnDragDrop(object sender, DragEventArgs e) {
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			ThreadPool.QueueUserWorkItem(new WaitCallback(HandleDrop), new Tuple<string, IList<string>>(((Control)sender).Name, files));
		}
		
		private void HandleDrop(object obj) {
			this.Invoke(new Action<object>((o) => { HandleDropInvoke(o); }), obj);
		}
		private void HandleDropInvoke(object obj) {
			this.Show();
			Tuple<string, IList<string>> itm = obj as Tuple<string, IList<string>>;
			if(itm == null)
				throw new ArgumentException("Argument incorrect", "tmp");
			switch(itm.Item1) {
				case "btnNoSound":
					Execution.NoSound(itm.Item2);
					break;
					
				case "btnGetMp3":
					Execution.GetMp3(itm.Item2);
					break;
					
				case "btnConcat":
					Execution.Concat(itm.Item2);
					break;
					
				case "btnGui":
					this.Hide();
					Execution.Gui(itm.Item2);
					this.Show();
					break;
			}
		}
		#endregion
		
	}
	
}
