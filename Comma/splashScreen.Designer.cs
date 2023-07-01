namespace Comma
{
    partial class splashScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(splashScreen));
            this.mainPhoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPhoto
            // 
            this.mainPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPhoto.Image = ((System.Drawing.Image)(resources.GetObject("mainPhoto.Image")));
            this.mainPhoto.Location = new System.Drawing.Point(0, 0);
            this.mainPhoto.Name = "mainPhoto";
            this.mainPhoto.Size = new System.Drawing.Size(600, 350);
            this.mainPhoto.TabIndex = 0;
            this.mainPhoto.TabStop = false;
            // 
            // splashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.mainPhoto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "splashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comma";
            ((System.ComponentModel.ISupportInitialize)(this.mainPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPhoto;
    }
}