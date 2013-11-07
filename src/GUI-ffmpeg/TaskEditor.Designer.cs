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
	partial class TaskEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskEditor));
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.nudMinHeight = new System.Windows.Forms.NumericUpDown();
			this.cbIncTime = new System.Windows.Forms.CheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cbPoster = new System.Windows.Forms.CheckBox();
			this.nudMinWidth = new System.Windows.Forms.NumericUpDown();
			this.cbJSON = new System.Windows.Forms.CheckBox();
			this.cbTN = new System.Windows.Forms.CheckBox();
			this.cbReplace = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbNoSound = new System.Windows.Forms.CheckBox();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.tbabmp4 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.tbabwebm = new System.Windows.Forms.TextBox();
			this.tbsrflv = new System.Windows.Forms.TextBox();
			this.tbabflv = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tbsrmp3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbabmp3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.tbvbflv = new System.Windows.Forms.TextBox();
			this.tbvbwebm = new System.Windows.Forms.TextBox();
			this.tbvbmp4 = new System.Windows.Forms.TextBox();
			this.cbMP3 = new System.Windows.Forms.CheckBox();
			this.cbFLV = new System.Windows.Forms.CheckBox();
			this.cbWEBM = new System.Windows.Forms.CheckBox();
			this.cbMP4 = new System.Windows.Forms.CheckBox();
			this.cbRotate = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbFile = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.cbSameForAll = new System.Windows.Forms.CheckBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.tbHeight = new System.Windows.Forms.TextBox();
			this.tbWidth = new System.Windows.Forms.TextBox();
			this.nudEndOffset = new ffmpeg.TimePicker();
			this.nudStartOffset = new ffmpeg.TimePicker();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.btnOL4 = new System.Windows.Forms.Button();
			this.tbOL4 = new System.Windows.Forms.TextBox();
			this.cbOL4 = new System.Windows.Forms.ComboBox();
			this.btnOL3 = new System.Windows.Forms.Button();
			this.tbOL3 = new System.Windows.Forms.TextBox();
			this.cbOL3 = new System.Windows.Forms.ComboBox();
			this.btnOL2 = new System.Windows.Forms.Button();
			this.tbOL2 = new System.Windows.Forms.TextBox();
			this.cbOL2 = new System.Windows.Forms.ComboBox();
			this.btnOL1 = new System.Windows.Forms.Button();
			this.tbOL1 = new System.Windows.Forms.TextBox();
			this.cbOL1 = new System.Windows.Forms.ComboBox();
			this.cbOW = new System.Windows.Forms.CheckBox();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudMinHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMinWidth)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			resources.ApplyResources(this.groupBox2, "groupBox2");
			this.groupBox2.Controls.Add(this.nudMinHeight);
			this.groupBox2.Controls.Add(this.cbIncTime);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.cbPoster);
			this.groupBox2.Controls.Add(this.nudMinWidth);
			this.groupBox2.Controls.Add(this.cbJSON);
			this.groupBox2.Controls.Add(this.cbTN);
			this.groupBox2.Controls.Add(this.cbReplace);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.TabStop = false;
			// 
			// nudMinHeight
			// 
			resources.ApplyResources(this.nudMinHeight, "nudMinHeight");
			this.nudMinHeight.Maximum = new decimal(new int[] {
									500,
									0,
									0,
									0});
			this.nudMinHeight.Minimum = new decimal(new int[] {
									40,
									0,
									0,
									0});
			this.nudMinHeight.Name = "nudMinHeight";
			this.nudMinHeight.Value = new decimal(new int[] {
									72,
									0,
									0,
									0});
			// 
			// cbIncTime
			// 
			resources.ApplyResources(this.cbIncTime, "cbIncTime");
			this.cbIncTime.Checked = true;
			this.cbIncTime.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbIncTime.Name = "cbIncTime";
			this.cbIncTime.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			// 
			// cbPoster
			// 
			resources.ApplyResources(this.cbPoster, "cbPoster");
			this.cbPoster.Name = "cbPoster";
			this.cbPoster.UseVisualStyleBackColor = true;
			// 
			// nudMinWidth
			// 
			resources.ApplyResources(this.nudMinWidth, "nudMinWidth");
			this.nudMinWidth.Maximum = new decimal(new int[] {
									500,
									0,
									0,
									0});
			this.nudMinWidth.Minimum = new decimal(new int[] {
									60,
									0,
									0,
									0});
			this.nudMinWidth.Name = "nudMinWidth";
			this.nudMinWidth.Value = new decimal(new int[] {
									128,
									0,
									0,
									0});
			// 
			// cbJSON
			// 
			resources.ApplyResources(this.cbJSON, "cbJSON");
			this.cbJSON.Name = "cbJSON";
			this.cbJSON.UseVisualStyleBackColor = true;
			// 
			// cbTN
			// 
			resources.ApplyResources(this.cbTN, "cbTN");
			this.cbTN.Name = "cbTN";
			this.cbTN.UseVisualStyleBackColor = true;
			// 
			// cbReplace
			// 
			resources.ApplyResources(this.cbReplace, "cbReplace");
			this.cbReplace.Name = "cbReplace";
			this.cbReplace.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Controls.Add(this.cbNoSound);
			this.groupBox1.Controls.Add(this.textBox11);
			this.groupBox1.Controls.Add(this.tbabmp4);
			this.groupBox1.Controls.Add(this.textBox9);
			this.groupBox1.Controls.Add(this.tbabwebm);
			this.groupBox1.Controls.Add(this.tbsrflv);
			this.groupBox1.Controls.Add(this.tbabflv);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.tbsrmp3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.tbabmp3);
			this.groupBox1.Controls.Add(this.textBox4);
			this.groupBox1.Controls.Add(this.tbvbflv);
			this.groupBox1.Controls.Add(this.tbvbwebm);
			this.groupBox1.Controls.Add(this.tbvbmp4);
			this.groupBox1.Controls.Add(this.cbMP3);
			this.groupBox1.Controls.Add(this.cbFLV);
			this.groupBox1.Controls.Add(this.cbWEBM);
			this.groupBox1.Controls.Add(this.cbMP4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// cbNoSound
			// 
			resources.ApplyResources(this.cbNoSound, "cbNoSound");
			this.cbNoSound.Name = "cbNoSound";
			this.cbNoSound.UseVisualStyleBackColor = true;
			// 
			// textBox11
			// 
			resources.ApplyResources(this.textBox11, "textBox11");
			this.textBox11.Name = "textBox11";
			// 
			// tbabmp4
			// 
			resources.ApplyResources(this.tbabmp4, "tbabmp4");
			this.tbabmp4.Name = "tbabmp4";
			// 
			// textBox9
			// 
			resources.ApplyResources(this.textBox9, "textBox9");
			this.textBox9.Name = "textBox9";
			// 
			// tbabwebm
			// 
			resources.ApplyResources(this.tbabwebm, "tbabwebm");
			this.tbabwebm.Name = "tbabwebm";
			// 
			// tbsrflv
			// 
			resources.ApplyResources(this.tbsrflv, "tbsrflv");
			this.tbsrflv.Name = "tbsrflv";
			// 
			// tbabflv
			// 
			resources.ApplyResources(this.tbabflv, "tbabflv");
			this.tbabflv.Name = "tbabflv";
			// 
			// label6
			// 
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// tbsrmp3
			// 
			resources.ApplyResources(this.tbsrmp3, "tbsrmp3");
			this.tbsrmp3.Name = "tbsrmp3";
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// tbabmp3
			// 
			resources.ApplyResources(this.tbabmp3, "tbabmp3");
			this.tbabmp3.Name = "tbabmp3";
			// 
			// textBox4
			// 
			resources.ApplyResources(this.textBox4, "textBox4");
			this.textBox4.Name = "textBox4";
			// 
			// tbvbflv
			// 
			resources.ApplyResources(this.tbvbflv, "tbvbflv");
			this.tbvbflv.Name = "tbvbflv";
			// 
			// tbvbwebm
			// 
			resources.ApplyResources(this.tbvbwebm, "tbvbwebm");
			this.tbvbwebm.Name = "tbvbwebm";
			// 
			// tbvbmp4
			// 
			resources.ApplyResources(this.tbvbmp4, "tbvbmp4");
			this.tbvbmp4.Name = "tbvbmp4";
			// 
			// cbMP3
			// 
			resources.ApplyResources(this.cbMP3, "cbMP3");
			this.cbMP3.Name = "cbMP3";
			this.cbMP3.UseVisualStyleBackColor = true;
			// 
			// cbFLV
			// 
			resources.ApplyResources(this.cbFLV, "cbFLV");
			this.cbFLV.Name = "cbFLV";
			this.cbFLV.UseVisualStyleBackColor = true;
			// 
			// cbWEBM
			// 
			resources.ApplyResources(this.cbWEBM, "cbWEBM");
			this.cbWEBM.Name = "cbWEBM";
			this.cbWEBM.UseVisualStyleBackColor = true;
			// 
			// cbMP4
			// 
			resources.ApplyResources(this.cbMP4, "cbMP4");
			this.cbMP4.Name = "cbMP4";
			this.cbMP4.UseVisualStyleBackColor = true;
			// 
			// cbRotate
			// 
			resources.ApplyResources(this.cbRotate, "cbRotate");
			this.cbRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRotate.FormattingEnabled = true;
			this.cbRotate.Items.AddRange(new object[] {
									resources.GetString("cbRotate.Items"),
									resources.GetString("cbRotate.Items1"),
									resources.GetString("cbRotate.Items2"),
									resources.GetString("cbRotate.Items3"),
									resources.GetString("cbRotate.Items4")});
			this.cbRotate.Name = "cbRotate";
			// 
			// label7
			// 
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// tbFile
			// 
			resources.ApplyResources(this.tbFile, "tbFile");
			this.tbFile.Name = "tbFile";
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Valider);
			// 
			// button2
			// 
			resources.ApplyResources(this.button2, "button2");
			this.button2.Name = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Annuler);
			// 
			// cbSameForAll
			// 
			resources.ApplyResources(this.cbSameForAll, "cbSameForAll");
			this.cbSameForAll.Name = "cbSameForAll";
			this.cbSameForAll.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			resources.ApplyResources(this.groupBox4, "groupBox4");
			this.groupBox4.Controls.Add(this.tbHeight);
			this.groupBox4.Controls.Add(this.tbWidth);
			this.groupBox4.Controls.Add(this.nudEndOffset);
			this.groupBox4.Controls.Add(this.nudStartOffset);
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Controls.Add(this.cbRotate);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.TabStop = false;
			// 
			// tbHeight
			// 
			resources.ApplyResources(this.tbHeight, "tbHeight");
			this.tbHeight.Name = "tbHeight";
			// 
			// tbWidth
			// 
			resources.ApplyResources(this.tbWidth, "tbWidth");
			this.tbWidth.Name = "tbWidth";
			// 
			// nudEndOffset
			// 
			resources.ApplyResources(this.nudEndOffset, "nudEndOffset");
			this.nudEndOffset.Hours = 0;
			this.nudEndOffset.Milliseconds = 0;
			this.nudEndOffset.Minutes = 0;
			this.nudEndOffset.Name = "nudEndOffset";
			this.nudEndOffset.Seconds = 0;
			this.nudEndOffset.Value = System.TimeSpan.Parse("00:00:00");
			// 
			// nudStartOffset
			// 
			resources.ApplyResources(this.nudStartOffset, "nudStartOffset");
			this.nudStartOffset.Hours = 0;
			this.nudStartOffset.Milliseconds = 0;
			this.nudStartOffset.Minutes = 0;
			this.nudStartOffset.Name = "nudStartOffset";
			this.nudStartOffset.Seconds = 0;
			this.nudStartOffset.Value = System.TimeSpan.Parse("00:00:00");
			// 
			// label10
			// 
			resources.ApplyResources(this.label10, "label10");
			this.label10.Name = "label10";
			// 
			// label9
			// 
			resources.ApplyResources(this.label9, "label9");
			this.label9.Name = "label9";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// groupBox5
			// 
			resources.ApplyResources(this.groupBox5, "groupBox5");
			this.groupBox5.Controls.Add(this.btnOL4);
			this.groupBox5.Controls.Add(this.tbOL4);
			this.groupBox5.Controls.Add(this.cbOL4);
			this.groupBox5.Controls.Add(this.btnOL3);
			this.groupBox5.Controls.Add(this.tbOL3);
			this.groupBox5.Controls.Add(this.cbOL3);
			this.groupBox5.Controls.Add(this.btnOL2);
			this.groupBox5.Controls.Add(this.tbOL2);
			this.groupBox5.Controls.Add(this.cbOL2);
			this.groupBox5.Controls.Add(this.btnOL1);
			this.groupBox5.Controls.Add(this.tbOL1);
			this.groupBox5.Controls.Add(this.cbOL1);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.TabStop = false;
			// 
			// btnOL4
			// 
			resources.ApplyResources(this.btnOL4, "btnOL4");
			this.btnOL4.Name = "btnOL4";
			this.btnOL4.UseVisualStyleBackColor = true;
			this.btnOL4.Click += new System.EventHandler(this.SelectOverlayImage);
			// 
			// tbOL4
			// 
			resources.ApplyResources(this.tbOL4, "tbOL4");
			this.tbOL4.Name = "tbOL4";
			// 
			// cbOL4
			// 
			resources.ApplyResources(this.cbOL4, "cbOL4");
			this.cbOL4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOL4.FormattingEnabled = true;
			this.cbOL4.Items.AddRange(new object[] {
									resources.GetString("cbOL4.Items"),
									resources.GetString("cbOL4.Items1"),
									resources.GetString("cbOL4.Items2"),
									resources.GetString("cbOL4.Items3"),
									resources.GetString("cbOL4.Items4")});
			this.cbOL4.Name = "cbOL4";
			// 
			// btnOL3
			// 
			resources.ApplyResources(this.btnOL3, "btnOL3");
			this.btnOL3.Name = "btnOL3";
			this.btnOL3.UseVisualStyleBackColor = true;
			this.btnOL3.Click += new System.EventHandler(this.SelectOverlayImage);
			// 
			// tbOL3
			// 
			resources.ApplyResources(this.tbOL3, "tbOL3");
			this.tbOL3.Name = "tbOL3";
			// 
			// cbOL3
			// 
			resources.ApplyResources(this.cbOL3, "cbOL3");
			this.cbOL3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOL3.FormattingEnabled = true;
			this.cbOL3.Items.AddRange(new object[] {
									resources.GetString("cbOL3.Items"),
									resources.GetString("cbOL3.Items1"),
									resources.GetString("cbOL3.Items2"),
									resources.GetString("cbOL3.Items3"),
									resources.GetString("cbOL3.Items4")});
			this.cbOL3.Name = "cbOL3";
			// 
			// btnOL2
			// 
			resources.ApplyResources(this.btnOL2, "btnOL2");
			this.btnOL2.Name = "btnOL2";
			this.btnOL2.UseVisualStyleBackColor = true;
			this.btnOL2.Click += new System.EventHandler(this.SelectOverlayImage);
			// 
			// tbOL2
			// 
			resources.ApplyResources(this.tbOL2, "tbOL2");
			this.tbOL2.Name = "tbOL2";
			// 
			// cbOL2
			// 
			resources.ApplyResources(this.cbOL2, "cbOL2");
			this.cbOL2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOL2.FormattingEnabled = true;
			this.cbOL2.Items.AddRange(new object[] {
									resources.GetString("cbOL2.Items"),
									resources.GetString("cbOL2.Items1"),
									resources.GetString("cbOL2.Items2"),
									resources.GetString("cbOL2.Items3"),
									resources.GetString("cbOL2.Items4")});
			this.cbOL2.Name = "cbOL2";
			// 
			// btnOL1
			// 
			resources.ApplyResources(this.btnOL1, "btnOL1");
			this.btnOL1.Name = "btnOL1";
			this.btnOL1.UseVisualStyleBackColor = true;
			this.btnOL1.Click += new System.EventHandler(this.SelectOverlayImage);
			// 
			// tbOL1
			// 
			resources.ApplyResources(this.tbOL1, "tbOL1");
			this.tbOL1.Name = "tbOL1";
			// 
			// cbOL1
			// 
			resources.ApplyResources(this.cbOL1, "cbOL1");
			this.cbOL1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOL1.FormattingEnabled = true;
			this.cbOL1.Items.AddRange(new object[] {
									resources.GetString("cbOL1.Items"),
									resources.GetString("cbOL1.Items1"),
									resources.GetString("cbOL1.Items2"),
									resources.GetString("cbOL1.Items3"),
									resources.GetString("cbOL1.Items4")});
			this.cbOL1.Name = "cbOL1";
			// 
			// cbOW
			// 
			resources.ApplyResources(this.cbOW, "cbOW");
			this.cbOW.Checked = true;
			this.cbOW.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbOW.Name = "cbOW";
			this.cbOW.UseVisualStyleBackColor = true;
			// 
			// TaskEditor
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.cbOW);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.cbSameForAll);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tbFile);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TaskEditor";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudMinHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMinWidth)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.CheckBox cbOW;
		private System.Windows.Forms.TextBox tbWidth;
		private System.Windows.Forms.TextBox tbHeight;
		private System.Windows.Forms.ComboBox cbOL1;
		private System.Windows.Forms.TextBox tbOL1;
		private System.Windows.Forms.Button btnOL1;
		private System.Windows.Forms.ComboBox cbOL2;
		private System.Windows.Forms.TextBox tbOL2;
		private System.Windows.Forms.Button btnOL2;
		private System.Windows.Forms.ComboBox cbOL3;
		private System.Windows.Forms.TextBox tbOL3;
		private System.Windows.Forms.Button btnOL3;
		private System.Windows.Forms.ComboBox cbOL4;
		private System.Windows.Forms.TextBox tbOL4;
		private System.Windows.Forms.Button btnOL4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.CheckBox cbNoSound;
		private ffmpeg.TimePicker nudStartOffset;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private ffmpeg.TimePicker nudEndOffset;
		private System.Windows.Forms.NumericUpDown nudMinWidth;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown nudMinHeight;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox cbSameForAll;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbRotate;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox tbFile;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox cbMP4;
		private System.Windows.Forms.CheckBox cbWEBM;
		private System.Windows.Forms.CheckBox cbFLV;
		private System.Windows.Forms.CheckBox cbMP3;
		private System.Windows.Forms.TextBox tbvbmp4;
		private System.Windows.Forms.TextBox tbvbwebm;
		private System.Windows.Forms.TextBox tbvbflv;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox tbabmp3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbsrmp3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbabflv;
		private System.Windows.Forms.TextBox tbsrflv;
		private System.Windows.Forms.TextBox tbabwebm;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.TextBox tbabmp4;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox cbReplace;
		private System.Windows.Forms.CheckBox cbTN;
		private System.Windows.Forms.CheckBox cbJSON;
		private System.Windows.Forms.CheckBox cbPoster;
		private System.Windows.Forms.CheckBox cbIncTime;
		private System.Windows.Forms.GroupBox groupBox2;
	}
}
