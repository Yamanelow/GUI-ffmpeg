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
	
	public enum Parameter {
		[Command("")]
		NONE,
		
		[Command("-vn")]
		A_NOAUDIO,
		[Command("-c:a mp3")]
		A_C_MP3,
		[Command("-c:a libvorbis")]
		A_C_VORBIS,
		[Command("-c:a aac -strict -2")]
		A_C_AAC,
		[Command("-c:a pcm_s16le")]
		A_C_WAVE,
		[Command("-acodec copy")]
		A_COPY,
		[Command("-b:a")]
		A_BITRATE,
		[Command("-ar")]
		A_SAMPLE,
		
		
		[Command("-vn")]
		V_NOVIDEO,
		[Command("-c:v libx264")]
		V_C_X264,
		[Command("-c:v libvpx")]
		V_C_VPX,
		[Command("-f flv -g 300")]
		V_C_FLV,
		[Command("-b:v")]
		V_BITRATE,
		[Command("-qscale")]
		V_QSCALE,
		[Command("-crf")]
		V_CRF,
		[Command("-qmin")]
		V_QMIN,
		[Command("-qmax")]
		V_QMAX,
		
		[Command("transpose")]
		FX_TRANSPOSE,
		[Command("scale")]
		FX_RESIZE,
		[Command("overlay")]
		FX_OVERLAY,
		[Command("color")]
		FX_BGCOLOR,
		
		
		[Command("-i")]
		MISC_INPUT,
		[Command("-s")]
		MISC_RESIZE,
		[Command("-f")]
		MISC_FORMAT,
		[Command("-ss")]
		MISC_SEEK_ACC,
		[Command("-ss")]
		MISC_SEEK_FAST,
		[Command("-ss")]
		MISC_SEEK,
		[Command("-t")]
		MISC_DURATION,
		[Command("-to")]
		MISC_TO,
		[Command("-y")]
		MISC_OVERWRITE_YES,
		[Command("-n")]
		MISC_OVERWRITE_NO,
		[Command("-filter_complex")]
		MISC_FILTER_COMPLEX
			
	}
	
	public static partial class Extensions {
		
		public static string Command(this Parameter value) {
			FieldInfo field = value.GetType().GetField(value.ToString());
			CommandAttribute attribute
				= Attribute.GetCustomAttribute(field, typeof(CommandAttribute))
				as CommandAttribute;
			return attribute == null ? value.ToString() : attribute.Command;
		}
		
	}
	
}
