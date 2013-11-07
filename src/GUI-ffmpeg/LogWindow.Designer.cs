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
	partial class LogWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogWindow));
			this.RTB = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// RTB
			// 
			this.RTB.DetectUrls = false;
			this.RTB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RTB.Location = new System.Drawing.Point(0, 0);
			this.RTB.Name = "RTB";
			this.RTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.RTB.Size = new System.Drawing.Size(548, 260);
			this.RTB.TabIndex = 0;
			this.RTB.Text = "";
			this.RTB.WordWrap = false;
			// 
			// LogWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(548, 260);
			this.Controls.Add(this.RTB);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "LogWindow";
			this.Text = "Log Window";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogWindowFormClosing);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.RichTextBox RTB;
	}
}
