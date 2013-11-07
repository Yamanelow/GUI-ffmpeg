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

namespace ffmpeg {
	
	public enum Overlay {
		TopLeft = 0,
		TopRight = 1,
		BottomLeft = 2,
		BottomRight = 3,
		Center = 4
	}
	
	public static partial class Extensions {
		
		public static string Value(this Overlay overlay) {
			switch(overlay) {
				case Overlay.TopLeft:
					return "0:0";
				case Overlay.TopRight:
					return "main_w-overlay_w:0";
				case Overlay.BottomLeft:
					return "0:main_h-overlay_h";
				case Overlay.BottomRight:
					return "main_w-overlay_w:main_h-overlay_h";
				case Overlay.Center:
					return "main_w/2-overlay_w/2:main_h/2-overlay_h/2";
			}
			return string.Empty;
		}
		
	}
	
}
