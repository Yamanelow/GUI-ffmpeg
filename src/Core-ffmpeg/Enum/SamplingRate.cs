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
	
	public enum SamplingRate : int {
		Defaut = 0,
		Telephone = 8000,
		VoIP = 16000,
		MiniDV = 32000,
		AudioCD = 44100,
		DVD = 48000,
		Pro = 88200,
		BluRay = 96000,
		HDCD = 176400,
		BluRayPlus = 192000,
		DxD = 352800,
		DSD = 2822400,
		DoubleDsD = 5644800
	}
	
	public static partial class Extensions {
		
		public static string Value(this SamplingRate value) {
			return ((int)value).ToString();
		}
		
	}
	
}
