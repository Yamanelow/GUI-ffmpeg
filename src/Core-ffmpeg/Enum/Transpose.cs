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
	
	public enum Transpose : int {
		R90CounterClockwiseVerticalFlip = 0,
		R90Clockwise = 1,
		R90CounterClockwise = 2,
		R90ClockwiseVerticalFlip = 3
	}
	
}
