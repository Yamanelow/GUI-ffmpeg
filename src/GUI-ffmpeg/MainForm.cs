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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ffmpeg {
	
	public partial class MainForm : Form {
		
		#region Ctor
		public MainForm() {
			InitializeComponent();
			UnlockUI();
		}
		
		public MainForm(IList<string> files) {
			InitializeComponent();
			UnlockUI();
			_autoLoadFiles = files;
		}
		#endregion
		
		#region Form loaded
		private void Loaded(object sender, EventArgs e) {
			if(_autoLoadFiles != null)
				AddItems(_autoLoadFiles);
			_autoLoadFiles = null;
		}
		#endregion
		
		#region Properties, variables, imports ...
		public int RuningTaskIndex { get; set; }
		
		private List<VideoTask> Tasks = new List<VideoTask>();
		
		private static readonly string[] _allowedExtensions = new string[] { ".avi", ".mp4", ".webm", ".3gp", ".mov" };
		private IList<string> _autoLoadFiles = null;
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
		
		private const int WM_VSCROLL = 277;
		private const int SB_PAGEBOTTOM = 7;
		#endregion
		
		#region UI (un)lock while processing
		private void LockUI() {
			RuningTaskIndex = -1;
			btnCancel.Enabled = false;
			btnLaunch.Enabled = false;
			btnCancel.Enabled = true;
		}
		
		private void UnlockUI() {
			RuningTaskIndex = -1;
			btnCancel.Enabled = true;
			btnLaunch.Enabled = true;
			btnCancel.Enabled = false;
		}
		#endregion
		
		#region Log function
		private void Log(string message) {
			this.Invoke(new Action<string>((string msg)=> {
			                               	if(RTB.Lines.Length > 2 && RTB.Lines[RTB.Lines.Length - 2].StartsWith("frame=") && msg.StartsWith("frame=")) {
			                               		ReplaceLastLines(RTB, msg);
			                               	} else if(RTB.Lines.Length > 2 && RTB.Lines[RTB.Lines.Length - 2].StartsWith("size=") && msg.StartsWith("size=")) {
			                               		ReplaceLastLines(RTB, msg);
			                               	} else {
			                               		RTB.AppendText(msg + "\r\n");
			                               	}
			                               	ScrollToBottom(RTB);
			                               	Application.DoEvents();
			                               }), message);
			Application.DoEvents();
		}
		#endregion
		
		#region Replace last lines of log for same messages
		public static void ReplaceLastLines(RichTextBox rtb, string text) {
			int firstCharOfLineIndex = rtb.GetFirstCharIndexFromLine(rtb.Lines.Length - 2);
			int lengthOfLine = rtb.Lines[rtb.Lines.Length - 2].Length;
			rtb.Select(firstCharOfLineIndex, lengthOfLine);
			rtb.SelectedText = text;
		}
		#endregion
		
		#region Force scroll down for log box
		public static void ScrollToBottom(RichTextBox MyRichTextBox) {
			SendMessage(MyRichTextBox.Handle, WM_VSCROLL, (IntPtr)SB_PAGEBOTTOM, IntPtr.Zero);
		}
		#endregion
		
		#region Launch tasks
		private void Launch(object sender, EventArgs e) {
			if(!File.Exists(Common.ffmpeg)) {
				MessageBox.Show("ffmpeg est introuvable, vérifiez qu'il se trouve bien dans le répertoire de l'application");
				return;
			}
			LockUI();
			RuningTaskIndex = 0;
			foreach(VideoTask task in Tasks) {
				LB.Refresh();
				task.Log += Log;
				task.Execute();
				task.Log -= Log;
				RuningTaskIndex++;
			}
			UnlockUI();
			
			Log("\r\n############################################################");
			Log("Opérations terminées");
			Log("############################################################\r\n");
			
			if(MessageBox.Show("Voulez vous supprimer les tâches effectuées ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				LB.Items.Clear();
				Tasks.Clear();
			}
			
			LB.Refresh();
			
			if(cbShutdown.Checked) {
				Process.Start("shutdown.exe", "-s -t 30 -c \"Fin de l'opération d'encodage.\"");
				Application.Exit();
			}
		}
		#endregion
		
		#region Add files via context menu
		private void AddFile(object sender, EventArgs e) {
			using(OpenFileDialog ofd = new OpenFileDialog()) {
				ofd.Filter = "Fichiers vidéo (" + string.Join(" ", _allowedExtensions) + ")|" + string.Join(";*", _allowedExtensions).TrimStart(';');
				ofd.Multiselect = true;
				ofd.CheckFileExists = true;
				ofd.CheckPathExists = true;
				if(ofd.ShowDialog() != DialogResult.OK)
					return;
				AddItems(ofd.FileNames);
			}
		}
		#endregion
		
		#region Delete file via context menu
		private void DeleteItem(object sender, EventArgs e) {
			if(LB.SelectedIndex < 0)
				return;
			try {
				Tasks.Remove(Tasks.Where(t => t.FileFullPath.Equals(LB.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault());
				LB.Items.RemoveAt(LB.SelectedIndex);
			} catch(Exception ex) {
				Log(ex.Message);
				Log(ex.StackTrace);
			}
		}
		#endregion
		
		#region Edit item via context menu
		private void EditItem(object sender, EventArgs e) {
			if(LB.SelectedIndex < 0)
				return;
			try {
				VideoTask ti = Tasks.Where(t => t.FileFullPath.Equals(LB.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
				TaskEditor.Edit(ti);
			} catch(Exception ex) {
				Log(ex.Message);
				Log(ex.StackTrace);
			}
		}
		#endregion
		
		#region Cancel demand
		private void Cancel(object sender, EventArgs e) {
			if(MessageBox.Show("Attention, l'interruption en cours d'encodage peut provoquer des fichiers de sortie incomplets et illisibles. Continuer ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
				foreach(VideoTask ti in Tasks)
					ti.Cancel();
			}
		}
		#endregion
		
		#region ListBox DrawItem override
		private void LBDrawItem(object sender, DrawItemEventArgs e) {
			if(LB.Items.Count == 0 || e.Index < 0 || e.Index >= LB.Items.Count)
				return;
			Color bg = (e.State & DrawItemState.Selected) == DrawItemState.Selected ? SystemColors.Highlight : (e.Index % 2 == 0 ? Color.Gainsboro : Color.White);
			e.Graphics.FillRectangle(new SolidBrush(bg), e.Bounds);
			e.DrawFocusRectangle();
			e.Graphics.DrawString(
				LB.Items[e.Index].ToString(),
				e.Index == RuningTaskIndex ? new Font(LB.Font, FontStyle.Bold) : LB.Font,
				new SolidBrush(e.Index == RuningTaskIndex ? Color.Red : LB.ForeColor),
				e.Bounds
			);
		}
		#endregion
		
		#region ListBox MouseUp for force select when right clicking
		private void LBMouseUp(object sender, MouseEventArgs e) {
			if(e.Button == MouseButtons.Right) {
				int i = LB.IndexFromPoint(e.X, e.Y);
				if(i == ListBox.NoMatches)
					return;
				LB.SelectedIndex = i;
			}
		}
		#endregion
		
		#region Add files to task list
		private void AddItems(IList<string> items) {
			VideoTask tskForCopy = null;
			foreach(string file in items) {
				bool equals = false;
				foreach(string itm in LB.Items) {
					if(file.Equals(itm, StringComparison.CurrentCultureIgnoreCase)) {
						equals = true;
						break;
					}
				}
				if(equals)
					continue;
				
				if(tskForCopy == null) {
					VideoTask tsk = new VideoTask() { FileFullPath = file, LengthOnTn = true };
					switch(TaskEditor.Edit(tsk)) {
						case EditorResult.OK:
							LB.Items.Add(file);
							Tasks.Add(tsk);
							break;
							
						case EditorResult.SameForAll:
							LB.Items.Add(file);
							Tasks.Add(tsk);
							tskForCopy = tsk.Clone();
							break;
					}
				} else {
					VideoTask tsk = tskForCopy.Clone();
					tsk.FileFullPath = file;
					LB.Items.Add(file);
					Tasks.Add(tsk);
				}
			}
		}
		#endregion
		
		#region Add files via ListBox drag'n'drop
		private void LBDragEnter(object sender, DragEventArgs e) {
			if(e.Data.GetDataPresent(DataFormats.FileDrop)) {
				e.Effect = DragDropEffects.Copy;
			}
		}
		
		private void LBDragDrop(object sender, DragEventArgs e) {
			if(e.Data.GetDataPresent(DataFormats.FileDrop)) {
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				if(files == null || files.Length == 0)
					return;
				List<string> rst = new List<string>();
				for(int i = 0; i < files.Length; i++) {
					if(File.Exists(files[i]) && _allowedExtensions.Contains(Path.GetExtension(files[i]))) {
						rst.Add(files[i]);
					}
				}
				AddItems(rst);
			}
		}
		#endregion
		
	}
	
}
