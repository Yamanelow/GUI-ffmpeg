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
	partial class Chooser
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chooser));
			this.btnNoSound = new System.Windows.Forms.Button();
			this.btnGetMp3 = new System.Windows.Forms.Button();
			this.btnConcat = new System.Windows.Forms.Button();
			this.btnGui = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnNoSound
			// 
			resources.ApplyResources(this.btnNoSound, "btnNoSound");
			this.btnNoSound.AllowDrop = true;
			this.btnNoSound.BackgroundImage = global::ffmpeg.Images.nosound;
			this.btnNoSound.Name = "btnNoSound";
			this.btnNoSound.UseVisualStyleBackColor = true;
			this.btnNoSound.Click += new System.EventHandler(this.RunNoSound);
			this.btnNoSound.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
			this.btnNoSound.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
			// 
			// btnGetMp3
			// 
			resources.ApplyResources(this.btnGetMp3, "btnGetMp3");
			this.btnGetMp3.AllowDrop = true;
			this.btnGetMp3.BackgroundImage = global::ffmpeg.Images.getmp3;
			this.btnGetMp3.Name = "btnGetMp3";
			this.btnGetMp3.UseVisualStyleBackColor = true;
			this.btnGetMp3.Click += new System.EventHandler(this.RunGetMp3);
			this.btnGetMp3.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
			this.btnGetMp3.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
			// 
			// btnConcat
			// 
			resources.ApplyResources(this.btnConcat, "btnConcat");
			this.btnConcat.AllowDrop = true;
			this.btnConcat.BackgroundImage = global::ffmpeg.Images.concat;
			this.btnConcat.Name = "btnConcat";
			this.btnConcat.UseVisualStyleBackColor = true;
			this.btnConcat.Click += new System.EventHandler(this.RunConcat);
			this.btnConcat.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
			this.btnConcat.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
			// 
			// btnGui
			// 
			resources.ApplyResources(this.btnGui, "btnGui");
			this.btnGui.AllowDrop = true;
			this.btnGui.BackgroundImage = global::ffmpeg.Images.gui;
			this.btnGui.Name = "btnGui";
			this.btnGui.UseVisualStyleBackColor = true;
			this.btnGui.Click += new System.EventHandler(this.RunGui);
			this.btnGui.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
			this.btnGui.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.AllowDrop = true;
			this.button1.BackgroundImage = global::ffmpeg.Images.format;
			this.button1.Name = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.RunFileEncoder);
			// 
			// Chooser
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnGui);
			this.Controls.Add(this.btnConcat);
			this.Controls.Add(this.btnGetMp3);
			this.Controls.Add(this.btnNoSound);
			this.Name = "Chooser";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnGui;
		private System.Windows.Forms.Button btnConcat;
		private System.Windows.Forms.Button btnGetMp3;
		private System.Windows.Forms.Button btnNoSound;
	}
}
