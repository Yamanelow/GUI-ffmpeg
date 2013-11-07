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

using System.Xml.Serialization;

namespace ffmpeg.Schemas {
	
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute()]
	public partial class streamDispositionType {
		
		private int defaultField;
		
		private int dubField;
		
		private int originalField;
		
		private int commentField;
		
		private int lyricsField;
		
		private int karaokeField;
		
		private int forcedField;
		
		private int hearing_impairedField;
		
		private int visual_impairedField;
		
		private int clean_effectsField;
		
		private int attached_picField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int @default {
			get {
				return this.defaultField;
			}
			set {
				this.defaultField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int dub {
			get {
				return this.dubField;
			}
			set {
				this.dubField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int original {
			get {
				return this.originalField;
			}
			set {
				this.originalField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int comment {
			get {
				return this.commentField;
			}
			set {
				this.commentField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int lyrics {
			get {
				return this.lyricsField;
			}
			set {
				this.lyricsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int karaoke {
			get {
				return this.karaokeField;
			}
			set {
				this.karaokeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int forced {
			get {
				return this.forcedField;
			}
			set {
				this.forcedField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int hearing_impaired {
			get {
				return this.hearing_impairedField;
			}
			set {
				this.hearing_impairedField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int visual_impaired {
			get {
				return this.visual_impairedField;
			}
			set {
				this.visual_impairedField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int clean_effects {
			get {
				return this.clean_effectsField;
			}
			set {
				this.clean_effectsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int attached_pic {
			get {
				return this.attached_picField;
			}
			set {
				this.attached_picField = value;
			}
		}
		
	}
	
}
