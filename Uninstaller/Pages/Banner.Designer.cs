namespace Stylo6MTKGoodiesInstaller.Pages
{
    partial class Banner
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
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.subTextLbl = new System.Windows.Forms.Label();
            this.headerLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPicture
            // 
            this.logoPicture.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.logoPicture.Location = new System.Drawing.Point(0, 7);
            this.logoPicture.Name = "logoPicture";
            this.logoPicture.Size = new System.Drawing.Size(162, 72);
            this.logoPicture.TabIndex = 13;
            this.logoPicture.TabStop = false;
            // 
            // subTextLbl
            // 
            this.subTextLbl.AutoSize = true;
            this.subTextLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subTextLbl.Location = new System.Drawing.Point(185, 42);
            this.subTextLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.subTextLbl.Name = "subTextLbl";
            this.subTextLbl.Size = new System.Drawing.Size(233, 15);
            this.subTextLbl.TabIndex = 12;
            this.subTextLbl.Text = "Choose the folder in which to install GitSE";
            // 
            // headerLbl
            // 
            this.headerLbl.AutoSize = true;
            this.headerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLbl.Location = new System.Drawing.Point(167, 20);
            this.headerLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(157, 15);
            this.headerLbl.TabIndex = 11;
            this.headerLbl.Text = "Choose Install Location";
            // 
            // Banner
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.logoPicture);
            this.Controls.Add(this.subTextLbl);
            this.Controls.Add(this.headerLbl);
            this.Size = new System.Drawing.Size(575, 81);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox logoPicture;
        public System.Windows.Forms.Label subTextLbl;
        public System.Windows.Forms.Label headerLbl;
    }
}
