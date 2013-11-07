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
	public partial class chapterType {
		
		private tagType[] tagField;
		
		private int idField;
		
		private string time_baseField;
		
		private int startField;
		
		private float start_timeField;
		
		private bool start_timeFieldSpecified;
		
		private int endField;
		
		private float end_timeField;
		
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
		public int id {
			get {
				return this.idField;
			}
			set {
				this.idField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string time_base {
			get {
				return this.time_baseField;
			}
			set {
				this.time_baseField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int start {
			get {
				return this.startField;
			}
			set {
				this.startField = value;
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
		public int end {
			get {
				return this.endField;
			}
			set {
				this.endField = value;
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
		
	}
	
}
