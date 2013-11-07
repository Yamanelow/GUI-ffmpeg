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
using System.Text;

namespace ffmpeg {
	
	public class CommandLineBuilder {
		
		#region Ctor
		public CommandLineBuilder() {
			VideoEncoding = VideoEncoding.DEFAULT;
			AudioEncoding = AudioEncoding.DEFAULT;
			FilterComplex = new FilterComplexBuilder(this);
		}
		#endregion
		
		#region Var & Properties
		private List<Tuple<Parameter, string>> _actions = new List<Tuple<Parameter, string>>();
		
		public VideoEncoding VideoEncoding { get; private set; }
		public AudioEncoding AudioEncoding { get; private set; }
		public FilterComplexBuilder FilterComplex { get; private set; }
		#endregion
		
		#region Mark Filter complex position at 1st use
		internal void MarkFilterPosition() {
			_actions.Add(Tuple.Create(Parameter.MISC_FILTER_COMPLEX, string.Empty));
		}
		#endregion
		
		#region Pre-made command lines
		public static string ExtractMp3(string input, string output, BitrateMp3 br = BitrateMp3.Standard, SamplingRate sr = SamplingRate.AudioCD) {
			if(string.IsNullOrWhiteSpace(input))
				throw new ArgumentNullException("input");
			if(string.IsNullOrWhiteSpace(output))
				throw new ArgumentNullException("output");
			
			return new CommandLineBuilder()
				.AddEntry(input)
				.VideoCodec(VideoEncoding.NOVIDEO)
				.AudioCodec(AudioEncoding.MP3)
				.Param(Parameter.A_BITRATE, ((int)br).ToString())
				.Param(Parameter.A_SAMPLE, ((int)sr).ToString())
				.Param(Parameter.MISC_OVERWRITE_YES)
				.Output(output);
		}
		
		public static string ExtractWav(string input, string output) {
			if(string.IsNullOrWhiteSpace(input))
				throw new ArgumentNullException("input");
			if(string.IsNullOrWhiteSpace(output))
				throw new ArgumentNullException("output");
			
			return new CommandLineBuilder()
				.AddEntry(input)
				.VideoCodec(VideoEncoding.NOVIDEO)
				.AudioCodec(AudioEncoding.WAV)
				.Param(Parameter.MISC_OVERWRITE_YES)
				.Output(output);
		}
		
		public static string RemoveSound(string input, string output) {
			if(string.IsNullOrWhiteSpace(input))
				throw new ArgumentNullException("input");
			if(string.IsNullOrWhiteSpace(output))
				throw new ArgumentNullException("output");
			
			return new CommandLineBuilder()
				.AddEntry(input)
				.VideoCodec(VideoEncoding.COPY)
				.AudioCodec(AudioEncoding.NOAUDIO)
				.Param(Parameter.MISC_OVERWRITE_YES)
				.Output(output);
		}
		#endregion
		
		#region Command line construction
		public CommandLineBuilder AddRaw(string raw) {
			if(string.IsNullOrWhiteSpace(raw))
				throw new ArgumentNullException("raw");
			
			_actions.Add(Tuple.Create(Parameter.NONE, raw));
			return this;
		}
		
		public CommandLineBuilder AddEntry(string data) {
			if(string.IsNullOrWhiteSpace(data))
				throw new ArgumentNullException("data");
			
			_actions.Add(Tuple.Create(Parameter.MISC_INPUT, data.EncloseQMarks()));
			return this;
		}
		
		public CommandLineBuilder Seek(string position) {
			if(string.IsNullOrWhiteSpace(position))
				throw new ArgumentNullException("position");
			
			_actions.Add(Tuple.Create(Parameter.MISC_SEEK, position));
			return this;
		}
		
		public CommandLineBuilder To(string position) {
			if(string.IsNullOrWhiteSpace(position))
				throw new ArgumentNullException("position");
			
			_actions.Add(Tuple.Create(Parameter.MISC_TO, position));
			return this;
		}
		
		public CommandLineBuilder Duration(string duration) {
			if(string.IsNullOrWhiteSpace(duration))
				throw new ArgumentNullException("duration");
			
			_actions.Add(Tuple.Create(Parameter.MISC_DURATION, duration));
			return this;
		}
		
		public CommandLineBuilder Resize(string width, string height) {
			if(string.IsNullOrWhiteSpace(width) && string.IsNullOrWhiteSpace(height))
				throw new ArgumentNullException("width/height");
			
			return Resize((string.IsNullOrWhiteSpace(width) ? "-1" : width) + "x" + (string.IsNullOrWhiteSpace(height) ? "-1" : height));
		}
		public CommandLineBuilder Resize(string sizes) {
			if(string.IsNullOrWhiteSpace(sizes))
				throw new ArgumentNullException("sizes");
			
			_actions.Add(Tuple.Create(Parameter.MISC_RESIZE, sizes));
			return this;
		}
		
		public CommandLineBuilder VideoCodec(VideoEncoding codec) {
			VideoEncoding = codec;
			return this;
		}
		
		public CommandLineBuilder AudioCodec(AudioEncoding codec) {
			AudioEncoding = codec;
			return this;
		}
		
		public CommandLineBuilder Param(Parameter param) {
			return Param(param, null);
		}
		public CommandLineBuilder Param(Parameter param, string data) {
			_actions.Add(Tuple.Create(param, data == null ? string.Empty : data));
			return this;
		}
		
		public string Output(string output) {
			return Output(output, MediaFormat.DEFAULT);
		}
		public string Output(string output, MediaFormat outputFormat) {
			if(string.IsNullOrWhiteSpace(output))
				throw new ArgumentNullException("output");
			
			return string.Format("{0} {1} {2}", this.ToString(), outputFormat.Command(), output.EncloseQMarks());
		}
		#endregion
		
		#region ToString() override
		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			for(int i = 0; i < _actions.Count; i++) {
				sb.AppendFormat(
					"{0} {1} ",
					_actions[i].Item1.Command(),
					_actions[i].Item1 == Parameter.MISC_FILTER_COMPLEX ? FilterComplex.ToString().EncloseQMarks() : _actions[i].Item2
				);
			}
			sb.Append(VideoEncoding.Command()).Append(" ");
			sb.Append(AudioEncoding.Command()).Append(" ");
			return sb.ToString();
		}
		#endregion
		
	}
	
}
