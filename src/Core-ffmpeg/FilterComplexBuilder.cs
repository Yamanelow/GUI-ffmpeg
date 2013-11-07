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
	
	public class FilterComplexBuilder {
		
		public FilterComplexBuilder(CommandLineBuilder owner) {
			_owner = owner;
			PreviousOutput = "[0:v]";
			CurrentOperation = 0;
		}
		
		public int CurrentOperation { get; private set; }
		public string PreviousOutput { get; private set; }
		private StringBuilder _ol = new StringBuilder();
		private CommandLineBuilder _owner;
		
		
		public CommandLineBuilder Transpose(Transpose mode) {
			return Transpose(mode, null, null);
		}
		public CommandLineBuilder Transpose(Transpose mode, string input, string output) {
			_owner.MarkFilterPosition();
			
			if(input == null) {
				input = PreviousOutput;
			}
			if(output == null) {
				PreviousOutput = string.Format("[tmp{0}]", ++CurrentOperation);
				output = PreviousOutput + ";";
			} else if(output.Length > 0 && !output.EndsWith(";")) {
				output += ";";
			}
			
			_ol.AppendFormat(" {0} transpose={1} {2}", input, (int)mode, output);
			return _owner;
		}
		
		public CommandLineBuilder Resize(string width, string height) {
			return Resize(width, height, null, null);
		}
		public CommandLineBuilder Resize(string width, string height, string input, string output) {
			_owner.MarkFilterPosition();
			
			if(input == null) {
				input = PreviousOutput;
			}
			if(output == null) {
				PreviousOutput = string.Format("[tmp{0}]", ++CurrentOperation);
				output = PreviousOutput + ";";
			} else if(output.Length > 0 && !output.EndsWith(";")) {
				output += ";";
			}
			
			_ol.AppendFormat(" {0} scale=w={1}:h={2} {3}", input, string.IsNullOrWhiteSpace(width) ? "-1" : width, string.IsNullOrWhiteSpace(height) ? "-1" : height, output);
			return _owner;
		}
		
		public CommandLineBuilder Overlay(Overlay position, string over, bool shortest = false) {
			return Overlay(position, over, null, null, shortest);
		}
		public CommandLineBuilder Overlay(Overlay position, string over, string under, string output, bool shortest = false) {
			if(string.IsNullOrWhiteSpace(over))
				throw new ArgumentNullException("over");
			
			_owner.MarkFilterPosition();
			
			if(under == null) {
				under = PreviousOutput;
			}
			if(output == null) {
				PreviousOutput = string.Format("[tmp{0}]", ++CurrentOperation);
				output = PreviousOutput + ";";
			} else if(output.Length > 0 && !output.EndsWith(";")) {
				output += ";";
			}
			
			_ol.AppendFormat(" {0} {1} overlay={2} {3}", under, over, position.Value(), output);
			return _owner;
		}
		
		public CommandLineBuilder ColorSrc(string output, int width, int height, byte R, byte G, byte B) {
			return ColorSrc(output, width, height, R, G, B, 255);
		}
		public CommandLineBuilder ColorSrc(string output, int width, int height, byte R, byte G, byte B, byte A) {
			return ColorSrc(output, width, height, string.Format("0x{0:X2}{1:X2}{2:X2}{3:X2}", R, G, B, A));
		}
		public CommandLineBuilder ColorSrc(string output, int width, int height) {
			return ColorSrc(output, width, height, "black");
		}
		public CommandLineBuilder ColorSrc(string output, int width, int height, string color) {
			if(string.IsNullOrWhiteSpace(output))
				throw new ArgumentNullException("output");
			if(width <= 0)
				throw new ArgumentOutOfRangeException("width", width, "Value must be > 0");
			if(height <= 0)
				throw new ArgumentOutOfRangeException("height", height, "Value must be > 0");
			if(string.IsNullOrWhiteSpace(color))
				throw new ArgumentNullException("colorName");
			
			_owner.MarkFilterPosition();
			
			if(!output.EndsWith(";")) {
				output += ";";
			}
			
			_ol.AppendFormat("color={0}:size={1}x{2} {3}", color, width, height, output);
			return _owner;
		}
		
		public CommandLineBuilder Concat(List<string> entries, bool useVideo, bool useAudio, string output) {
			if(output == null)
				throw new ArgumentNullException("output");
			if(entries == null || entries.Count == 0)
				throw new ArgumentNullException("entries");
			
			_owner.MarkFilterPosition();
			
			if(!output.EndsWith(";")) {
				output += ";";
			}
			
			string arg = ":v=" + (useVideo ? "1" : "0") + ":a=" + (useAudio ? "1" : "0");
			_ol.AppendFormat("{0} concat=n={1}{2} {3}", string.Join(" ", entries), entries.Count, arg, output);
			
			return _owner;
		}
		
		public override string ToString() {
			StringBuilder ol = new StringBuilder(_ol.ToString());
			if(ol.ToString().EndsWith("];")) {
				int lp = ol.ToString().LastIndexOf('[');
				ol.Remove(lp, ol.Length - lp);
			} else if(ol.ToString().EndsWith(";")) {
				int lp = ol.ToString().LastIndexOf(';');
				ol.Remove(lp, ol.Length - lp);
			}
			return ol.ToString();
		}
		
	}
	
}
