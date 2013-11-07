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
	partial class ConcatSelector
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConcatSelector));
			this.btnSelect1 = new System.Windows.Forms.Button();
			this.btnDelete1 = new System.Windows.Forms.Button();
			this.tbFile1 = new System.Windows.Forms.TextBox();
			this.lV1 = new System.Windows.Forms.Label();
			this.lA1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tbFile2 = new System.Windows.Forms.TextBox();
			this.lA2 = new System.Windows.Forms.Label();
			this.btnSelect2 = new System.Windows.Forms.Button();
			this.lV2 = new System.Windows.Forms.Label();
			this.btnDelete2 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.tbFile3 = new System.Windows.Forms.TextBox();
			this.lA3 = new System.Windows.Forms.Label();
			this.btnSelect3 = new System.Windows.Forms.Button();
			this.lV3 = new System.Windows.Forms.Label();
			this.btnDelete3 = new System.Windows.Forms.Button();
			this.btnValidation = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblMode = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnSelect1
			// 
			resources.ApplyResources(this.btnSelect1, "btnSelect1");
			this.btnSelect1.Name = "btnSelect1";
			this.btnSelect1.UseVisualStyleBackColor = true;
			this.btnSelect1.Click += new System.EventHandler(this.Select1);
			// 
			// btnDelete1
			// 
			resources.ApplyResources(this.btnDelete1, "btnDelete1");
			this.btnDelete1.Name = "btnDelete1";
			this.btnDelete1.UseVisualStyleBackColor = true;
			this.btnDelete1.Click += new System.EventHandler(this.Delete1);
			// 
			// tbFile1
			// 
			resources.ApplyResources(this.tbFile1, "tbFile1");
			this.tbFile1.Name = "tbFile1";
			// 
			// lV1
			// 
			resources.ApplyResources(this.lV1, "lV1");
			this.lV1.Name = "lV1";
			// 
			// lA1
			// 
			resources.ApplyResources(this.lA1, "lA1");
			this.lA1.Name = "lA1";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbFile1);
			this.groupBox1.Controls.Add(this.lA1);
			this.groupBox1.Controls.Add(this.btnSelect1);
			this.groupBox1.Controls.Add(this.lV1);
			this.groupBox1.Controls.Add(this.btnDelete1);
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tbFile2);
			this.groupBox2.Controls.Add(this.lA2);
			this.groupBox2.Controls.Add(this.btnSelect2);
			this.groupBox2.Controls.Add(this.lV2);
			this.groupBox2.Controls.Add(this.btnDelete2);
			resources.ApplyResources(this.groupBox2, "groupBox2");
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.TabStop = false;
			// 
			// tbFile2
			// 
			resources.ApplyResources(this.tbFile2, "tbFile2");
			this.tbFile2.Name = "tbFile2";
			// 
			// lA2
			// 
			resources.ApplyResources(this.lA2, "lA2");
			this.lA2.Name = "lA2";
			// 
			// btnSelect2
			// 
			resources.ApplyResources(this.btnSelect2, "btnSelect2");
			this.btnSelect2.Name = "btnSelect2";
			this.btnSelect2.UseVisualStyleBackColor = true;
			this.btnSelect2.Click += new System.EventHandler(this.Select2);
			// 
			// lV2
			// 
			resources.ApplyResources(this.lV2, "lV2");
			this.lV2.Name = "lV2";
			// 
			// btnDelete2
			// 
			resources.ApplyResources(this.btnDelete2, "btnDelete2");
			this.btnDelete2.Name = "btnDelete2";
			this.btnDelete2.UseVisualStyleBackColor = true;
			this.btnDelete2.Click += new System.EventHandler(this.Delete2);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.tbFile3);
			this.groupBox3.Controls.Add(this.lA3);
			this.groupBox3.Controls.Add(this.btnSelect3);
			this.groupBox3.Controls.Add(this.lV3);
			this.groupBox3.Controls.Add(this.btnDelete3);
			resources.ApplyResources(this.groupBox3, "groupBox3");
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.TabStop = false;
			// 
			// tbFile3
			// 
			resources.ApplyResources(this.tbFile3, "tbFile3");
			this.tbFile3.Name = "tbFile3";
			// 
			// lA3
			// 
			resources.ApplyResources(this.lA3, "lA3");
			this.lA3.Name = "lA3";
			// 
			// btnSelect3
			// 
			resources.ApplyResources(this.btnSelect3, "btnSelect3");
			this.btnSelect3.Name = "btnSelect3";
			this.btnSelect3.UseVisualStyleBackColor = true;
			this.btnSelect3.Click += new System.EventHandler(this.Select3);
			// 
			// lV3
			// 
			resources.ApplyResources(this.lV3, "lV3");
			this.lV3.Name = "lV3";
			// 
			// btnDelete3
			// 
			resources.ApplyResources(this.btnDelete3, "btnDelete3");
			this.btnDelete3.Name = "btnDelete3";
			this.btnDelete3.UseVisualStyleBackColor = true;
			this.btnDelete3.Click += new System.EventHandler(this.Delete3);
			// 
			// btnValidation
			// 
			resources.ApplyResources(this.btnValidation, "btnValidation");
			this.btnValidation.Name = "btnValidation";
			this.btnValidation.UseVisualStyleBackColor = true;
			this.btnValidation.Click += new System.EventHandler(this.Validate);
			// 
			// btnCancel
			// 
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.Cancel);
			// 
			// lblMode
			// 
			resources.ApplyResources(this.lblMode, "lblMode");
			this.lblMode.ForeColor = System.Drawing.Color.DarkRed;
			this.lblMode.Name = "lblMode";
			// 
			// ConcatSelector
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblMode);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnValidation);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "ConcatSelector";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblMode;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnValidation;
		private System.Windows.Forms.Button btnDelete3;
		private System.Windows.Forms.Label lV3;
		private System.Windows.Forms.Button btnSelect3;
		private System.Windows.Forms.Label lA3;
		private System.Windows.Forms.TextBox tbFile3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnDelete2;
		private System.Windows.Forms.Label lV2;
		private System.Windows.Forms.Button btnSelect2;
		private System.Windows.Forms.Label lA2;
		private System.Windows.Forms.TextBox tbFile2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lA1;
		private System.Windows.Forms.Label lV1;
		private System.Windows.Forms.TextBox tbFile1;
		private System.Windows.Forms.Button btnDelete1;
		private System.Windows.Forms.Button btnSelect1;
	}
}
