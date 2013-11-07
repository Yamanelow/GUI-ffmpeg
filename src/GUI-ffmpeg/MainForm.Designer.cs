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
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnLaunch = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbShutdown = new System.Windows.Forms.CheckBox();
			this.LB = new System.Windows.Forms.ListBox();
			this.cmLB = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RTB = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.cmLB.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.Cancel);
			// 
			// btnLaunch
			// 
			resources.ApplyResources(this.btnLaunch, "btnLaunch");
			this.btnLaunch.Name = "btnLaunch";
			this.btnLaunch.UseVisualStyleBackColor = true;
			this.btnLaunch.Click += new System.EventHandler(this.Launch);
			// 
			// panel1
			// 
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.Controls.Add(this.cbShutdown);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnLaunch);
			this.panel1.Name = "panel1";
			// 
			// cbShutdown
			// 
			resources.ApplyResources(this.cbShutdown, "cbShutdown");
			this.cbShutdown.Name = "cbShutdown";
			this.cbShutdown.UseVisualStyleBackColor = true;
			// 
			// LB
			// 
			resources.ApplyResources(this.LB, "LB");
			this.LB.AllowDrop = true;
			this.LB.ContextMenuStrip = this.cmLB;
			this.LB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.LB.FormattingEnabled = true;
			this.LB.Name = "LB";
			this.LB.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LBDrawItem);
			this.LB.DragDrop += new System.Windows.Forms.DragEventHandler(this.LBDragDrop);
			this.LB.DragEnter += new System.Windows.Forms.DragEventHandler(this.LBDragEnter);
			this.LB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LBMouseUp);
			// 
			// cmLB
			// 
			resources.ApplyResources(this.cmLB, "cmLB");
			this.cmLB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.ajouterToolStripMenuItem,
									this.supprimerToolStripMenuItem,
									this.editerToolStripMenuItem});
			this.cmLB.Name = "cmLB";
			// 
			// ajouterToolStripMenuItem
			// 
			resources.ApplyResources(this.ajouterToolStripMenuItem, "ajouterToolStripMenuItem");
			this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
			this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.AddFile);
			// 
			// supprimerToolStripMenuItem
			// 
			resources.ApplyResources(this.supprimerToolStripMenuItem, "supprimerToolStripMenuItem");
			this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
			this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.DeleteItem);
			// 
			// editerToolStripMenuItem
			// 
			resources.ApplyResources(this.editerToolStripMenuItem, "editerToolStripMenuItem");
			this.editerToolStripMenuItem.Name = "editerToolStripMenuItem";
			this.editerToolStripMenuItem.Click += new System.EventHandler(this.EditItem);
			// 
			// RTB
			// 
			resources.ApplyResources(this.RTB, "RTB");
			this.RTB.DetectUrls = false;
			this.RTB.Name = "RTB";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Name = "label1";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label2.Name = "label2";
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.RTB);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.LB);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Load += new System.EventHandler(this.Loaded);
			this.panel1.ResumeLayout(false);
			this.cmLB.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripMenuItem editerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip cmLB;
		private System.Windows.Forms.CheckBox cbShutdown;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RichTextBox RTB;
		private System.Windows.Forms.Button btnLaunch;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ListBox LB;
	}
}
