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
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ffmpeg {
	
	public partial class LogWindow : Form {
		
		#region Ctor
		public LogWindow() {
			InitializeComponent();
		}
		public LogWindow(bool canBeClosed) {
			InitializeComponent();
			CanBeClosed = canBeClosed;
		}
		#endregion
		
		#region Vars / properties / imports
		public bool CanBeClosed { get; set; }
		
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
		
		private const int WM_VSCROLL = 277;
		private const int SB_PAGEBOTTOM = 7;
		#endregion
		
		#region Log function
		public void Log(string message) {
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
		
		#region Form closing check
		private void LogWindowFormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = !CanBeClosed;
		}
		#endregion
		
	}
	
}
