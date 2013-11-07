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
	[System.Xml.Serialization.XmlRootAttribute("ffprobe", IsNullable=false)]
	public partial class ffprobeType {
		
		private packetType[] packetsField;
		
		private frameType[] framesField;
		
		private streamType[] streamsField;
		
		private programType[] programsField;
		
		private chapterType[] chaptersField;
		
		private formatType formatField;
		
		private errorType errorField;
		
		private programVersionType program_versionField;
		
		private libraryVersionType[] library_versionsField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.Xml.Serialization.XmlArrayItemAttribute("packet", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
		public packetType[] packets {
			get {
				return this.packetsField;
			}
			set {
				this.packetsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.Xml.Serialization.XmlArrayItemAttribute("frame", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
		public frameType[] frames {
			get {
				return this.framesField;
			}
			set {
				this.framesField = value;
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
		[System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.Xml.Serialization.XmlArrayItemAttribute("program", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
		public programType[] programs {
			get {
				return this.programsField;
			}
			set {
				this.programsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.Xml.Serialization.XmlArrayItemAttribute("chapter", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
		public chapterType[] chapters {
			get {
				return this.chaptersField;
			}
			set {
				this.chaptersField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public formatType format {
			get {
				return this.formatField;
			}
			set {
				this.formatField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public errorType error {
			get {
				return this.errorField;
			}
			set {
				this.errorField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public programVersionType program_version {
			get {
				return this.program_versionField;
			}
			set {
				this.program_versionField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.Xml.Serialization.XmlArrayItemAttribute("library_version", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
		public libraryVersionType[] library_versions {
			get {
				return this.library_versionsField;
			}
			set {
				this.library_versionsField = value;
			}
		}
		
	}
	
}
