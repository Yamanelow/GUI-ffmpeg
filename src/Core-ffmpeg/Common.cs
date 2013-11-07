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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ffmpeg {
	
	public static class Common {
		
		public const int CRF_MIN = 4;
		public const int CRF_MAX = 63;
		
		public const int QSCALE_MIN = 1;
		public const int QSCALE_MAX = 31;
		
		public const int QMIN_MIN = 0;
		public const int QMIN_MAX = 63;
		public const int QMAX_MAX = 63;
		
		public static readonly string ffmpeg = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ffmpeg.exe");
		public static readonly string ffprobe = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ffprobe.exe");
		
		public static IList<MediaFormat> GetAudioFormats() {
			return GetAudioFormats(new List<MediaFormat>());
		}
		public static IList<MediaFormat> GetAudioFormats(IList<MediaFormat> baseList) {
			return Enum.GetValues(typeof(MediaFormat))
				.Cast<MediaFormat>()
				.Where(p => { return p.IsAudioFormat(); })
				.Union(baseList)
				.ToList();
		}
		
		public static IList<MediaFormat> GetVideoFormats() {
			return GetVideoFormats(new List<MediaFormat>());
		}
		public static IList<MediaFormat> GetVideoFormats(IList<MediaFormat> baseList) {
			return Enum.GetValues(typeof(MediaFormat))
				.Cast<MediaFormat>()
				.Where(p => { return !p.IsAudioFormat(); })
				.Union(baseList)
				.ToList();
		}
	}
	
}
