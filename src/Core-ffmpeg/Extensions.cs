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
using System.Resources;

namespace ffmpeg {
	
	public static partial class Extensions {
		
		#region Preserve Stack Trace
		internal static void PreserveStackTrace(this Exception exception) {
			MethodInfo preserveStackTrace = typeof(Exception).GetMethod("InternalPreserveStackTrace", BindingFlags.Instance | BindingFlags.NonPublic);
			preserveStackTrace.Invoke(exception, null);
		}
		#endregion
		
		#region Readable numers
		public static string ToReadableString(this long number) {
			string[] suf = { "", "K", "M", "G", "T", "P", "E" };
			if (number == 0)
				return "0" + suf[0];
			long tmp = Math.Abs(number);
			int place = Convert.ToInt32(Math.Floor(Math.Log(tmp, 1000)));
			double num = Math.Round(tmp / Math.Pow(1000, place), 1);
			return (Math.Sign(number) * num).ToString() + suf[place];
		}
		public static string ToReadableString(this int number) {
			string[] suf = { "", "K", "M", "G", "T", "P", "E" };
			if (number == 0)
				return "0" + suf[0];
			int tmp = Math.Abs(number);
			int place = Convert.ToInt32(Math.Floor(Math.Log(tmp, 1000)));
			double num = Math.Round(tmp / Math.Pow(1000, place), 1);
			return (Math.Sign(number) * num).ToString() + suf[place];
		}
		#endregion
		
		#region Ensure closing quatation marks
		public static string EncloseQMarks(this string data) {
			return (data.StartsWith("\"") ? data : "\"" + data) + (data.EndsWith("\"") ? string.Empty : "\"");
		}
		#endregion
		
	}
	
}
