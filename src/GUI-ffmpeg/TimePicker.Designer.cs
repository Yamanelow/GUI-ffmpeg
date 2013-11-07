namespace ffmpeg
{
    partial class TimePicker
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TheTimeBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TheTimeBox
            // 
            this.TheTimeBox.Location = new System.Drawing.Point(0, 0);
            this.TheTimeBox.Name = "TheTimeBox";
            this.TheTimeBox.Size = new System.Drawing.Size(75, 20);
            this.TheTimeBox.TabIndex = 0;
            this.TheTimeBox.Text = "00:00:00.000";
            this.TheTimeBox.Click += new System.EventHandler(this.TheTimeBox_Click);
            this.TheTimeBox.TextChanged += new System.EventHandler(this.TheTimeBox_TextChanged);
            this.TheTimeBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TheTimeBox_KeyDown);
            // 
            // TimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TheTimeBox);
            this.Name = "TimePicker";
            this.Size = new System.Drawing.Size(75, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TheTimeBox;

    }
}
