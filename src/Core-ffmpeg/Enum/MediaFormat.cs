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
	
	public enum MediaFormat : int {
		[Command("")]
		[LongName("Auto")]
		DEFAULT = 0,
		[Command("-f matroska")]
		[LongName("Matrooska (.mkv)")]
		MKV = 1,
		[Command("-f mp4")]
		[LongName("MPEG-4 (.mp4)")]
		MP4 = 2,
		[Command("-f avi")]
		[LongName("AVI (.avi)")]
		AVI = 3,
		[Command("-f flv")]
		[LongName("FLV (.flv)")]
		FLV = 4,
		[Command("-f 3gp")]
		[LongName("QuickTime 3GP (.3gp)")]
		QT_3GP = 5,
		[Command("-f mov")]
		[LongName("QuickTime MOV (.mov)")]
		QT_MOV = 6,
		[Command("-f webm")]
		[LongName("WebM (.webm)")]
		WEBM = 7,
		[Command("-f mp3")]
		[LongName("MPEG-3 Audio (.mp3)")]
		[AudioFormat()]
		MP3 = 8,
		[Command("-f aiff")]
		[LongName("Audio IFF (.aiff)")]
		[AudioFormat()]
		AIFF = 9,
		[Command("-f flac")]
		[LongName("Flac (.flac)")]
		[AudioFormat()]
		FLAC = 10,
		[Command("-f wav")]
		[LongName("Waveform Audio (.wav)")]
		[AudioFormat()]
		WAV = 11,
		[Command("-f ogg")]
		[LongName("Ogg (.ogg)")]
		[AudioFormat()]
		OGG = 12,
		[Command("-f mp2")]
		[LongName("MPEG-2 Audio (.mp2)")]
		[AudioFormat()]
		MP2 = 13
	}
	
	public static partial class Extensions {
		
		public static bool IsAudioFormat(this MediaFormat value) {
			FieldInfo field = value.GetType().GetField(value.ToString());
			return Attribute.GetCustomAttribute(field, typeof(AudioFormatAttribute)) != null;
		}
		
		public static string Command(this MediaFormat value) {
			FieldInfo field = value.GetType().GetField(value.ToString());
			CommandAttribute attribute
				= Attribute.GetCustomAttribute(field, typeof(CommandAttribute))
				as CommandAttribute;
			return attribute == null ? value.ToString() : attribute.Command;
		}
		
		public static string LongName(this MediaFormat value) {
			FieldInfo field = value.GetType().GetField(value.ToString());
			LongNameAttribute attribute
				= Attribute.GetCustomAttribute(field, typeof(LongNameAttribute))
				as LongNameAttribute;
			return attribute == null ? value.ToString() : attribute.LongName;
		}
		
	}
	
}
