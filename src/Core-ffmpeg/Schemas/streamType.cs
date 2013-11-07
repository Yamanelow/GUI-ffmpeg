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
	public partial class streamType {
		
		private streamDispositionType dispositionField;
		
		private tagType[] tagField;
		
		private int indexField;
		
		private string codec_nameField;
		
		private string codec_long_nameField;
		
		private string profileField;
		
		private string codec_typeField;
		
		private string codec_time_baseField;
		
		private string codec_tagField;
		
		private string codec_tag_stringField;
		
		private string extradataField;
		
		private int widthField;
		
		private bool widthFieldSpecified;
		
		private int heightField;
		
		private bool heightFieldSpecified;
		
		private int has_b_framesField;
		
		private bool has_b_framesFieldSpecified;
		
		private string sample_aspect_ratioField;
		
		private string display_aspect_ratioField;
		
		private string pix_fmtField;
		
		private int levelField;
		
		private bool levelFieldSpecified;
		
		private string timecodeField;
		
		private string sample_fmtField;
		
		private int sample_rateField;
		
		private bool sample_rateFieldSpecified;
		
		private int channelsField;
		
		private bool channelsFieldSpecified;
		
		private int bits_per_sampleField;
		
		private bool bits_per_sampleFieldSpecified;
		
		private string idField;
		
		private string r_frame_rateField;
		
		private string avg_frame_rateField;
		
		private string time_baseField;
		
		private long start_ptsField;
		
		private bool start_ptsFieldSpecified;
		
		private float start_timeField;
		
		private bool start_timeFieldSpecified;
		
		private long duration_tsField;
		
		private bool duration_tsFieldSpecified;
		
		private float durationField;
		
		private bool durationFieldSpecified;
		
		private int bit_rateField;
		
		private bool bit_rateFieldSpecified;
		
		private int nb_framesField;
		
		private bool nb_framesFieldSpecified;
		
		private int nb_read_framesField;
		
		private bool nb_read_framesFieldSpecified;
		
		private int nb_read_packetsField;
		
		private bool nb_read_packetsFieldSpecified;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public streamDispositionType disposition {
			get {
				return this.dispositionField;
			}
			set {
				this.dispositionField = value;
			}
		}
		
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
		public int index {
			get {
				return this.indexField;
			}
			set {
				this.indexField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string codec_name {
			get {
				return this.codec_nameField;
			}
			set {
				this.codec_nameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string codec_long_name {
			get {
				return this.codec_long_nameField;
			}
			set {
				this.codec_long_nameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string profile {
			get {
				return this.profileField;
			}
			set {
				this.profileField = value;
			}
		}
		
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
		public string codec_time_base {
			get {
				return this.codec_time_baseField;
			}
			set {
				this.codec_time_baseField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string codec_tag {
			get {
				return this.codec_tagField;
			}
			set {
				this.codec_tagField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string codec_tag_string {
			get {
				return this.codec_tag_stringField;
			}
			set {
				this.codec_tag_stringField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string extradata {
			get {
				return this.extradataField;
			}
			set {
				this.extradataField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int width {
			get {
				return this.widthField;
			}
			set {
				this.widthField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool widthSpecified {
			get {
				return this.widthFieldSpecified;
			}
			set {
				this.widthFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int height {
			get {
				return this.heightField;
			}
			set {
				this.heightField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool heightSpecified {
			get {
				return this.heightFieldSpecified;
			}
			set {
				this.heightFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int has_b_frames {
			get {
				return this.has_b_framesField;
			}
			set {
				this.has_b_framesField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool has_b_framesSpecified {
			get {
				return this.has_b_framesFieldSpecified;
			}
			set {
				this.has_b_framesFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string sample_aspect_ratio {
			get {
				return this.sample_aspect_ratioField;
			}
			set {
				this.sample_aspect_ratioField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string display_aspect_ratio {
			get {
				return this.display_aspect_ratioField;
			}
			set {
				this.display_aspect_ratioField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string pix_fmt {
			get {
				return this.pix_fmtField;
			}
			set {
				this.pix_fmtField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int level {
			get {
				return this.levelField;
			}
			set {
				this.levelField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool levelSpecified {
			get {
				return this.levelFieldSpecified;
			}
			set {
				this.levelFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string timecode {
			get {
				return this.timecodeField;
			}
			set {
				this.timecodeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string sample_fmt {
			get {
				return this.sample_fmtField;
			}
			set {
				this.sample_fmtField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int sample_rate {
			get {
				return this.sample_rateField;
			}
			set {
				this.sample_rateField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool sample_rateSpecified {
			get {
				return this.sample_rateFieldSpecified;
			}
			set {
				this.sample_rateFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int channels {
			get {
				return this.channelsField;
			}
			set {
				this.channelsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool channelsSpecified {
			get {
				return this.channelsFieldSpecified;
			}
			set {
				this.channelsFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int bits_per_sample {
			get {
				return this.bits_per_sampleField;
			}
			set {
				this.bits_per_sampleField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool bits_per_sampleSpecified {
			get {
				return this.bits_per_sampleFieldSpecified;
			}
			set {
				this.bits_per_sampleFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string id {
			get {
				return this.idField;
			}
			set {
				this.idField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string r_frame_rate {
			get {
				return this.r_frame_rateField;
			}
			set {
				this.r_frame_rateField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string avg_frame_rate {
			get {
				return this.avg_frame_rateField;
			}
			set {
				this.avg_frame_rateField = value;
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
		public long duration_ts {
			get {
				return this.duration_tsField;
			}
			set {
				this.duration_tsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool duration_tsSpecified {
			get {
				return this.duration_tsFieldSpecified;
			}
			set {
				this.duration_tsFieldSpecified = value;
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
		public int bit_rate {
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
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int nb_frames {
			get {
				return this.nb_framesField;
			}
			set {
				this.nb_framesField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool nb_framesSpecified {
			get {
				return this.nb_framesFieldSpecified;
			}
			set {
				this.nb_framesFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int nb_read_frames {
			get {
				return this.nb_read_framesField;
			}
			set {
				this.nb_read_framesField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool nb_read_framesSpecified {
			get {
				return this.nb_read_framesFieldSpecified;
			}
			set {
				this.nb_read_framesFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int nb_read_packets {
			get {
				return this.nb_read_packetsField;
			}
			set {
				this.nb_read_packetsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool nb_read_packetsSpecified {
			get {
				return this.nb_read_packetsFieldSpecified;
			}
			set {
				this.nb_read_packetsFieldSpecified = value;
			}
		}
		
	}
	
}
