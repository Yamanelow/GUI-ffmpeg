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
	public partial class frameType {
		
		private string media_typeField;
		
		private int key_frameField;
		
		private long ptsField;
		
		private bool ptsFieldSpecified;
		
		private float pts_timeField;
		
		private bool pts_timeFieldSpecified;
		
		private long pkt_ptsField;
		
		private bool pkt_ptsFieldSpecified;
		
		private float pkt_pts_timeField;
		
		private bool pkt_pts_timeFieldSpecified;
		
		private long pkt_dtsField;
		
		private bool pkt_dtsFieldSpecified;
		
		private float pkt_dts_timeField;
		
		private bool pkt_dts_timeFieldSpecified;
		
		private long pkt_durationField;
		
		private bool pkt_durationFieldSpecified;
		
		private float pkt_duration_timeField;
		
		private bool pkt_duration_timeFieldSpecified;
		
		private long pkt_posField;
		
		private bool pkt_posFieldSpecified;
		
		private int pkt_sizeField;
		
		private bool pkt_sizeFieldSpecified;
		
		private string sample_fmtField;
		
		private long nb_samplesField;
		
		private bool nb_samplesFieldSpecified;
		
		private int channelsField;
		
		private bool channelsFieldSpecified;
		
		private string channel_layoutField;
		
		private long widthField;
		
		private bool widthFieldSpecified;
		
		private long heightField;
		
		private bool heightFieldSpecified;
		
		private string pix_fmtField;
		
		private string sample_aspect_ratioField;
		
		private string pict_typeField;
		
		private long coded_picture_numberField;
		
		private bool coded_picture_numberFieldSpecified;
		
		private long display_picture_numberField;
		
		private bool display_picture_numberFieldSpecified;
		
		private int interlaced_frameField;
		
		private bool interlaced_frameFieldSpecified;
		
		private int top_field_firstField;
		
		private bool top_field_firstFieldSpecified;
		
		private int repeat_pictField;
		
		private bool repeat_pictFieldSpecified;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string media_type {
			get {
				return this.media_typeField;
			}
			set {
				this.media_typeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int key_frame {
			get {
				return this.key_frameField;
			}
			set {
				this.key_frameField = value;
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
		public long pkt_pts {
			get {
				return this.pkt_ptsField;
			}
			set {
				this.pkt_ptsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool pkt_ptsSpecified {
			get {
				return this.pkt_ptsFieldSpecified;
			}
			set {
				this.pkt_ptsFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public float pkt_pts_time {
			get {
				return this.pkt_pts_timeField;
			}
			set {
				this.pkt_pts_timeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool pkt_pts_timeSpecified {
			get {
				return this.pkt_pts_timeFieldSpecified;
			}
			set {
				this.pkt_pts_timeFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public long pkt_dts {
			get {
				return this.pkt_dtsField;
			}
			set {
				this.pkt_dtsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool pkt_dtsSpecified {
			get {
				return this.pkt_dtsFieldSpecified;
			}
			set {
				this.pkt_dtsFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public float pkt_dts_time {
			get {
				return this.pkt_dts_timeField;
			}
			set {
				this.pkt_dts_timeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool pkt_dts_timeSpecified {
			get {
				return this.pkt_dts_timeFieldSpecified;
			}
			set {
				this.pkt_dts_timeFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public long pkt_duration {
			get {
				return this.pkt_durationField;
			}
			set {
				this.pkt_durationField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool pkt_durationSpecified {
			get {
				return this.pkt_durationFieldSpecified;
			}
			set {
				this.pkt_durationFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public float pkt_duration_time {
			get {
				return this.pkt_duration_timeField;
			}
			set {
				this.pkt_duration_timeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool pkt_duration_timeSpecified {
			get {
				return this.pkt_duration_timeFieldSpecified;
			}
			set {
				this.pkt_duration_timeFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public long pkt_pos {
			get {
				return this.pkt_posField;
			}
			set {
				this.pkt_posField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool pkt_posSpecified {
			get {
				return this.pkt_posFieldSpecified;
			}
			set {
				this.pkt_posFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int pkt_size {
			get {
				return this.pkt_sizeField;
			}
			set {
				this.pkt_sizeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool pkt_sizeSpecified {
			get {
				return this.pkt_sizeFieldSpecified;
			}
			set {
				this.pkt_sizeFieldSpecified = value;
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
		public long nb_samples {
			get {
				return this.nb_samplesField;
			}
			set {
				this.nb_samplesField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool nb_samplesSpecified {
			get {
				return this.nb_samplesFieldSpecified;
			}
			set {
				this.nb_samplesFieldSpecified = value;
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
		public string channel_layout {
			get {
				return this.channel_layoutField;
			}
			set {
				this.channel_layoutField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public long width {
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
		public long height {
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
		public string pict_type {
			get {
				return this.pict_typeField;
			}
			set {
				this.pict_typeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public long coded_picture_number {
			get {
				return this.coded_picture_numberField;
			}
			set {
				this.coded_picture_numberField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool coded_picture_numberSpecified {
			get {
				return this.coded_picture_numberFieldSpecified;
			}
			set {
				this.coded_picture_numberFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public long display_picture_number {
			get {
				return this.display_picture_numberField;
			}
			set {
				this.display_picture_numberField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool display_picture_numberSpecified {
			get {
				return this.display_picture_numberFieldSpecified;
			}
			set {
				this.display_picture_numberFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int interlaced_frame {
			get {
				return this.interlaced_frameField;
			}
			set {
				this.interlaced_frameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool interlaced_frameSpecified {
			get {
				return this.interlaced_frameFieldSpecified;
			}
			set {
				this.interlaced_frameFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int top_field_first {
			get {
				return this.top_field_firstField;
			}
			set {
				this.top_field_firstField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool top_field_firstSpecified {
			get {
				return this.top_field_firstFieldSpecified;
			}
			set {
				this.top_field_firstFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int repeat_pict {
			get {
				return this.repeat_pictField;
			}
			set {
				this.repeat_pictField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool repeat_pictSpecified {
			get {
				return this.repeat_pictFieldSpecified;
			}
			set {
				this.repeat_pictFieldSpecified = value;
			}
		}
		
	}
	
}
