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
	public partial class programVersionType {
		
		private string versionField;
		
		private string copyrightField;
		
		private string build_dateField;
		
		private string build_timeField;
		
		private string compiler_typeField;
		
		private string compiler_versionField;
		
		private string configurationField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string version {
			get {
				return this.versionField;
			}
			set {
				this.versionField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string copyright {
			get {
				return this.copyrightField;
			}
			set {
				this.copyrightField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string build_date {
			get {
				return this.build_dateField;
			}
			set {
				this.build_dateField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string build_time {
			get {
				return this.build_timeField;
			}
			set {
				this.build_timeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string compiler_type {
			get {
				return this.compiler_typeField;
			}
			set {
				this.compiler_typeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string compiler_version {
			get {
				return this.compiler_versionField;
			}
			set {
				this.compiler_versionField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string configuration {
			get {
				return this.configurationField;
			}
			set {
				this.configurationField = value;
			}
		}
		
	}
	
}
