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
	public partial class formatType {
		
		private tagType[] tagField;
		
		private string filenameField;
		
		private int nb_streamsField;
		
		private string format_nameField;
		
		private string format_long_nameField;
		
		private float start_timeField;
		
		private bool start_timeFieldSpecified;
		
		private float durationField;
		
		private bool durationFieldSpecified;
		
		private long sizeField;
		
		private bool sizeFieldSpecified;
		
		private long bit_rateField;
		
		private bool bit_rateFieldSpecified;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("tag", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public tagType[] tag {
			get {
				return this.tagField;
			}
			set {
				this.tagField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string filename {
			get {
				return this.filenameField;
			}
			set {
				this.filenameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int nb_streams {
			get {
				return this.nb_streamsField;
			}
			set {
				this.nb_streamsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string format_name {
			get {
				return this.format_nameField;
			}
			set {
				this.format_nameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string format_long_name {
			get {
				return this.format_long_nameField;
			}
			set {
				this.format_long_nameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public float start_time {
			get {
				return this.start_timeField;
			}
			set {
				this.start_timeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool start_timeSpecified {
			get {
				return this.start_timeFieldSpecified;
			}
			set {
				this.start_timeFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public float duration {
			get {
				return this.durationField;
			}
			set {
				this.durationField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool durationSpecified {
			get {
				return this.durationFieldSpecified;
			}
			set {
				this.durationFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public long size {
			get {
				return this.sizeField;
			}
			set {
				this.sizeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool sizeSpecified {
			get {
				return this.sizeFieldSpecified;
			}
			set {
				this.sizeFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public long bit_rate {
			get {
				return this.bit_rateField;
			}
			set {
				this.bit_rateField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool bit_rateSpecified {
			get {
				return this.bit_rateFieldSpecified;
			}
			set {
				this.bit_rateFieldSpecified = value;
			}
		}
		
	}
	
}
