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
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace ffmpeg {
	
	internal sealed class Program {
		
		[STAThread]
		private static void Main(string[] args) {
//			Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en");
//			Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			if(args == null || args.Length == 0) {
				Application.Run(new Chooser());
			} else if(args.Length == 1) {
				switch(args[0]) {
					case "-concat":
						Execution.Concat();
						return;
					case "-getmp3":
						Execution.GetMp3();
						return;
					case "-process":
						Execution.Gui();
						return;
					default:
						Application.Run(new Chooser());
						return;
				}
			} else {
				string[] files = new string[args.Length - 1];
				Array.Copy(args, 1, files, 0, args.Length - 1);
				switch(args[0]) {
					case "-concat":
						Execution.Concat(files);
						return;
					case "-getmp3":
						Execution.GetMp3(files);
						return;
					case "-process":
						Execution.Gui(files);
						return;
					default:
						Execution.Gui(args, true);
						return;
				}
			}
		}
		
	}
	
}
