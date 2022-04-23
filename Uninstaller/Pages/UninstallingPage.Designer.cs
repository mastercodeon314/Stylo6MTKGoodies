namespace Stylo6MTKGoodiesInstaller.Pages
{
    partial class UninstallingPage
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.statusLbl = new System.Windows.Forms.Label();
            this.showDetailsBtn = new System.Windows.Forms.Button();
            this.detailsBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(16, 17);
            this.progressBar1.Maximum = 446;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(506, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 0;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(13, 2);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(57, 13);
            this.statusLbl.TabIndex = 1;
            this.statusLbl.Text = "Installing...";
            // 
            // showDetailsBtn
            // 
            this.showDetailsBtn.Location = new System.Drawing.Point(16, 46);
            this.showDetailsBtn.Name = "showDetailsBtn";
            this.showDetailsBtn.Size = new System.Drawing.Size(88, 23);
            this.showDetailsBtn.TabIndex = 2;
            this.showDetailsBtn.Text = "Show details";
            this.showDetailsBtn.UseVisualStyleBackColor = true;
            this.showDetailsBtn.Click += new System.EventHandler(this.showDetailsBtn_Click);
            // 
            // detailsBox
            // 
            this.detailsBox.FormattingEnabled = true;
            this.detailsBox.Location = new System.Drawing.Point(16, 46);
            this.detailsBox.Name = "detailsBox";
            this.detailsBox.Size = new System.Drawing.Size(506, 186);
            this.detailsBox.TabIndex = 3;
            this.detailsBox.Visible = false;
            // 
            // UninstallingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.showDetailsBtn);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.detailsBox);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UninstallingPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button showDetailsBtn;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.ListBox detailsBox;
        public System.Windows.Forms.Label statusLbl;
    }
}
