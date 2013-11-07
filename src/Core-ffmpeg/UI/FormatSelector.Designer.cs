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

namespace ffmpeg
{
	partial class FormatSelector
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormatSelector));
			this.cbFormat = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cbCV = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.gbVideo = new System.Windows.Forms.GroupBox();
			this.tbQmax = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tbQmin = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbQscale = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tbCRF = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tbBV = new System.Windows.Forms.TextBox();
			this.gbAudio = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbCA = new System.Windows.Forms.ComboBox();
			this.cbBA = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbSR = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.gbVideo.SuspendLayout();
			this.gbAudio.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbFormat
			// 
			this.cbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFormat.FormattingEnabled = true;
			resources.ApplyResources(this.cbFormat, "cbFormat");
			this.cbFormat.Name = "cbFormat";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// cbCV
			// 
			this.cbCV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCV.FormattingEnabled = true;
			resources.ApplyResources(this.cbCV, "cbCV");
			this.cbCV.Name = "cbCV";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// gbVideo
			// 
			this.gbVideo.Controls.Add(this.tbQmax);
			this.gbVideo.Controls.Add(this.label10);
			this.gbVideo.Controls.Add(this.tbQmin);
			this.gbVideo.Controls.Add(this.label4);
			this.gbVideo.Controls.Add(this.tbQscale);
			this.gbVideo.Controls.Add(this.label9);
			this.gbVideo.Controls.Add(this.tbCRF);
			this.gbVideo.Controls.Add(this.label8);
			this.gbVideo.Controls.Add(this.tbBV);
			this.gbVideo.Controls.Add(this.label2);
			this.gbVideo.Controls.Add(this.cbCV);
			this.gbVideo.Controls.Add(this.label3);
			resources.ApplyResources(this.gbVideo, "gbVideo");
			this.gbVideo.Name = "gbVideo";
			this.gbVideo.TabStop = false;
			// 
			// tbQmax
			// 
			resources.ApplyResources(this.tbQmax, "tbQmax");
			this.tbQmax.Name = "tbQmax";
			// 
			// label10
			// 
			resources.ApplyResources(this.label10, "label10");
			this.label10.Name = "label10";
			// 
			// tbQmin
			// 
			resources.ApplyResources(this.tbQmin, "tbQmin");
			this.tbQmin.Name = "tbQmin";
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// tbQscale
			// 
			resources.ApplyResources(this.tbQscale, "tbQscale");
			this.tbQscale.Name = "tbQscale";
			// 
			// label9
			// 
			resources.ApplyResources(this.label9, "label9");
			this.label9.Name = "label9";
			// 
			// tbCRF
			// 
			resources.ApplyResources(this.tbCRF, "tbCRF");
			this.tbCRF.Name = "tbCRF";
			// 
			// label8
			// 
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			// 
			// tbBV
			// 
			resources.ApplyResources(this.tbBV, "tbBV");
			this.tbBV.Name = "tbBV";
			// 
			// gbAudio
			// 
			this.gbAudio.Controls.Add(this.label5);
			this.gbAudio.Controls.Add(this.cbCA);
			this.gbAudio.Controls.Add(this.cbBA);
			this.gbAudio.Controls.Add(this.label6);
			this.gbAudio.Controls.Add(this.cbSR);
			this.gbAudio.Controls.Add(this.label7);
			resources.ApplyResources(this.gbAudio, "gbAudio");
			this.gbAudio.Name = "gbAudio";
			this.gbAudio.TabStop = false;
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// cbCA
			// 
			this.cbCA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCA.FormattingEnabled = true;
			resources.ApplyResources(this.cbCA, "cbCA");
			this.cbCA.Name = "cbCA";
			// 
			// cbBA
			// 
			this.cbBA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBA.FormattingEnabled = true;
			this.cbBA.Items.AddRange(new object[] {
									resources.GetString("cbBA.Items"),
									resources.GetString("cbBA.Items1"),
									resources.GetString("cbBA.Items2")});
			resources.ApplyResources(this.cbBA, "cbBA");
			this.cbBA.Name = "cbBA";
			// 
			// label6
			// 
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			// 
			// cbSR
			// 
			this.cbSR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSR.FormattingEnabled = true;
			this.cbSR.Items.AddRange(new object[] {
									resources.GetString("cbSR.Items"),
									resources.GetString("cbSR.Items1"),
									resources.GetString("cbSR.Items2"),
									resources.GetString("cbSR.Items3"),
									resources.GetString("cbSR.Items4"),
									resources.GetString("cbSR.Items5"),
									resources.GetString("cbSR.Items6"),
									resources.GetString("cbSR.Items7"),
									resources.GetString("cbSR.Items8"),
									resources.GetString("cbSR.Items9"),
									resources.GetString("cbSR.Items10"),
									resources.GetString("cbSR.Items11")});
			resources.ApplyResources(this.cbSR, "cbSR");
			this.cbSR.Name = "cbSR";
			// 
			// label7
			// 
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Cancel);
			// 
			// button2
			// 
			resources.ApplyResources(this.button2, "button2");
			this.button2.Name = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Validate);
			// 
			// FormatSelector
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.gbAudio);
			this.Controls.Add(this.gbVideo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbFormat);
			this.Name = "FormatSelector";
			this.gbVideo.ResumeLayout(false);
			this.gbVideo.PerformLayout();
			this.gbAudio.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbQmax;
		private System.Windows.Forms.TextBox tbBV;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbCRF;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbQscale;
		private System.Windows.Forms.TextBox tbQmin;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbSR;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbBA;
		private System.Windows.Forms.ComboBox cbCA;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox gbAudio;
		private System.Windows.Forms.GroupBox gbVideo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbCV;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbFormat;
	}
}
