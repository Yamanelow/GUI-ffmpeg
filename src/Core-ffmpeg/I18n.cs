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
using System.Resources;

namespace ffmpeg {
	
	public static class I18n {
		
		private static readonly ResourceManager _rms  = new ResourceManager("ffmpeg.I18n", typeof(I18n).Assembly);
		
		public static string Get(this string name) {
			return _rms.GetString(name);
		}
		
	}
	
}
