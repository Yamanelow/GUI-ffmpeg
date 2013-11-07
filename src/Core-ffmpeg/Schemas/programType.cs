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
	public partial class programType {
		
		private tagType[] tagField;
		
		private streamType[] streamsField;
		
		private int program_idField;
		
		private int program_numField;
		
		private int nb_streamsField;
		
		private float start_timeField;
		
		private bool start_timeFieldSpecified;
		
		private long start_ptsField;
		
		private bool start_ptsFieldSpecified;
		
		private float end_timeField;
		
		private bool end_timeFieldSpecified;
		
		private long end_ptsField;
		
		private bool end_ptsFieldSpecified;
		
		private int pmt_pidField;
		
		private int pcr_pidField;
		
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
		[System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.Xml.Serialization.XmlArrayItemAttribute("stream", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
		public streamType[] streams {
			get {
				return this.streamsField;
			}
			set {
				this.streamsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int program_id {
			get {
				return this.program_idField;
			}
			set {
				this.program_idField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int program_num {
			get {
				return this.program_numField;
			}
			set {
				this.program_numField = value;
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
		public long start_pts {
			get {
				return this.start_ptsField;
			}
			set {
				this.start_ptsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool start_ptsSpecified {
			get {
				return this.start_ptsFieldSpecified;
			}
			set {
				this.start_ptsFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public float end_time {
			get {
				return this.end_timeField;
			}
			set {
				this.end_timeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool end_timeSpecified {
			get {
				return this.end_timeFieldSpecified;
			}
			set {
				this.end_timeFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public long end_pts {
			get {
				return this.end_ptsField;
			}
			set {
				this.end_ptsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool end_ptsSpecified {
			get {
				return this.end_ptsFieldSpecified;
			}
			set {
				this.end_ptsFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int pmt_pid {
			get {
				return this.pmt_pidField;
			}
			set {
				this.pmt_pidField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int pcr_pid {
			get {
				return this.pcr_pidField;
			}
			set {
				this.pcr_pidField = value;
			}
		}
		
	}
	
}
