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
	
	public static class Extensions {
		
		public static double ToUnixTimestamp(this DateTime value) {
			TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
			return (long)Math.Floor(span.TotalSeconds);
		}
		
		#region Preserve Stack Trace
		internal static void PreserveStackTrace(this Exception exception) {
			MethodInfo preserveStackTrace = typeof(Exception).GetMethod("InternalPreserveStackTrace", BindingFlags.Instance | BindingFlags.NonPublic);
			preserveStackTrace.Invoke(exception, null);
		}
		#endregion
		
	}
	
}
