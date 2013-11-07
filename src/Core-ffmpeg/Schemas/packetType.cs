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
	public partial class packetType {
		
		private string codec_typeField;
		
		private int stream_indexField;
		
		private long ptsField;
		
		private bool ptsFieldSpecified;
		
		private float pts_timeField;
		
		private bool pts_timeFieldSpecified;
		
		private long dtsField;
		
		private bool dtsFieldSpecified;
		
		private float dts_timeField;
		
		private bool dts_timeFieldSpecified;
		
		private long durationField;
		
		private bool durationFieldSpecified;
		
		private float duration_timeField;
		
		private bool duration_timeFieldSpecified;
		
		private long convergence_durationField;
		
		private bool convergence_durationFieldSpecified;
		
		private float convergence_duration_timeField;
		
		private bool convergence_duration_timeFieldSpecified;
		
		private long sizeField;
		
		private long posField;
		
		private bool posFieldSpecified;
		
		private string flagsField;
		
		private string dataField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string codec_type {
			get {
				return this.codec_typeField;
			}
			set {
				this.codec_typeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int stream_index {
			get {
				return this.stream_indexField;
			}
			set {
				this.stream_indexField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public long pts {
			get {
				return this.ptsField;
			}
			set {
				this.ptsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ptsSpecified {
			get {
				return this.ptsFieldSpecified;
			}
			set {
				this.ptsFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public float pts_time {
			get {
				return this.pts_timeField;
			}
			set {
				this.pts_timeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool pts_timeSpecified {
			get {
				return this.pts_timeFieldSpecified;
			}
			set {
				this.pts_timeFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public long dts {
			get {
				return this.dtsField;
			}
			set {
				this.dtsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool dtsSpecified {
			get {
				return this.dtsFieldSpecified;
			}
			set {
				this.dtsFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public float dts_time {
			get {
				return this.dts_timeField;
			}
			set {
				this.dts_timeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool dts_timeSpecified {
			get {
				return this.dts_timeFieldSpecified;
			}
			set {
				this.dts_timeFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public long duration {
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
		public float duration_time {
			get {
				return this.duration_timeField;
			}
			set {
				this.duration_timeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool duration_timeSpecified {
			get {
				return this.duration_timeFieldSpecified;
			}
			set {
				this.duration_timeFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public long convergence_duration {
			get {
				return this.convergence_durationField;
			}
			set {
				this.convergence_durationField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool convergence_durationSpecified {
			get {
				return this.convergence_durationFieldSpecified;
			}
			set {
				this.convergence_durationFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public float convergence_duration_time {
			get {
				return this.convergence_duration_timeField;
			}
			set {
				this.convergence_duration_timeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool convergence_duration_timeSpecified {
			get {
				return this.convergence_duration_timeFieldSpecified;
			}
			set {
				this.convergence_duration_timeFieldSpecified = value;
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
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public long pos {
			get {
				return this.posField;
			}
			set {
				this.posField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool posSpecified {
			get {
				return this.posFieldSpecified;
			}
			set {
				this.posFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string flags {
			get {
				return this.flagsField;
			}
			set {
				this.flagsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string data {
			get {
				return this.dataField;
			}
			set {
				this.dataField = value;
			}
		}
		
	}
	
}
