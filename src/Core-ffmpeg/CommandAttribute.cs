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
using System.ComponentModel;
using System.Reflection;

namespace ffmpeg {
	
	[AttributeUsage(AttributeTargets.Field)]
	public class CommandAttribute : Attribute {
		
		public CommandAttribute(string command) {
			this.Command = command;
		}
		
		public string Command { get; set; }
		
	}
	
}
