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
	
	public enum AudioEncoding {
		[Command("")]
		[LongName("Auto")]
		DEFAULT = -2,
		[Command("-an")]
		[LongName("No audio")]
		NOAUDIO = -1,
		[Command("-acodec copy")]
		[LongName("Copy")]
		COPY = 0,
		[Command("-c:a mp3")]
		[LongName("MPEG-3 Audio")]
		MP3 = 1,
		[Command("-c:a libvorbis")]
		[LongName("Vorbis")]
		VORBIS = 2,
		[Command("-c:a aac -strict -2")]
		[LongName("AAC")]
		AAC = 3,
		[Command("-c:a pcm_s16le")]
		[LongName("Wav - PCM 16bits little-endian")]
		WAV = 4
	}
	
	public static partial class Extensions {
		
		public static string Command(this AudioEncoding value) {
			FieldInfo field = value.GetType().GetField(value.ToString());
			CommandAttribute attribute
				= Attribute.GetCustomAttribute(field, typeof(CommandAttribute))
				as CommandAttribute;
			return attribute == null ? value.ToString() : attribute.Command;
		}
		
		public static string LongName(this AudioEncoding value) {
			FieldInfo field = value.GetType().GetField(value.ToString());
			LongNameAttribute attribute
				= Attribute.GetCustomAttribute(field, typeof(LongNameAttribute))
				as LongNameAttribute;
			return attribute == null ? value.ToString() : attribute.LongName;
		}
		
	}
	
}