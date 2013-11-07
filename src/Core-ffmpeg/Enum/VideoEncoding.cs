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
	
	public enum VideoEncoding : int {
		[Command("")]
		[LongName("Auto")]
		DEFAULT = -2,
		[Command("-vn")]
		[LongName("No video")]
		NOVIDEO = -1,
		[Command("-vcodec copy")]
		[LongName("Copy")]
		COPY = 0,
		[Command("-c:v libx264")]
		[LongName("H264")]
		X264 = 1,
		[Command("-c:v libvpx")]
		[LongName("On2 VP8")]
		VPX = 2,
		[Command("-c:v flv")]
		[LongName("Flash flv")]
		FLV = 3
	}
	
	public static partial class Extensions {
		
		public static string Command(this VideoEncoding value) {
			FieldInfo field = value.GetType().GetField(value.ToString());
			CommandAttribute attribute
				= Attribute.GetCustomAttribute(field, typeof(CommandAttribute))
				as CommandAttribute;
			return attribute == null ? value.ToString() : attribute.Command;
		}
		
		public static string LongName(this VideoEncoding value) {
			FieldInfo field = value.GetType().GetField(value.ToString());
			LongNameAttribute attribute
				= Attribute.GetCustomAttribute(field, typeof(LongNameAttribute))
				as LongNameAttribute;
			return attribute == null ? value.ToString() : attribute.LongName;
		}
		
	}
	
}
