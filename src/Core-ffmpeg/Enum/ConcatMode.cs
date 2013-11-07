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
using System.Reflection;

namespace ffmpeg {
	
	public enum ConcatMode {
		[LongName("Non défini")]
		Undefined,
		[LongName("Vidéo et audio")]
		Both,
		[LongName("Vidéo uniquement")]
		Video,
		[LongName("Audio uniquement")]
		Audio
	}
	
	public static partial class Extensions {
		
		public static string LongName(this ConcatMode value) {
			return I18n.Get("ConcatMode." + Enum.GetName(typeof(ConcatMode), value) + ".LongName");
		}
		
	}
}
