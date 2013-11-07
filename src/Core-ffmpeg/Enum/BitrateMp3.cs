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
	
	public enum BitrateMp3 : int {
		Defaut = 0,
		Low = 96000,
		Standard = 128000,
		High = 192000
	}
	
	public static partial class Extensions {
		
		public static string Value(this BitrateMp3 value) {
			return ((int)value).ToString();
		}
		
	}
	
}
