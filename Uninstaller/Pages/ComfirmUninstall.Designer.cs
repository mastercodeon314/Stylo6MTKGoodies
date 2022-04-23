namespace Stylo6MTKGoodiesInstaller.Pages
{
    partial class ComfirmUninstall
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
            this.infoLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uninstallLocationBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.Location = new System.Drawing.Point(3, 19);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(425, 13);
            this.infoLbl.TabIndex = 0;
            this.infoLbl.Text = "GitSE will be uninstalled from the following folder. Click Uninstall to start the" +
    " uninstallation.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Uninstalling from: ";
            // 
            // uninstallLocationBox
            // 
            this.uninstallLocationBox.Location = new System.Drawing.Point(99, 56);
            this.uninstallLocationBox.Name = "uninstallLocationBox";
            this.uninstallLocationBox.ReadOnly = true;
            this.uninstallLocationBox.Size = new System.Drawing.Size(397, 20);
            this.uninstallLocationBox.TabIndex = 2;
            // 
            // ComfirmUninstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uninstallLocationBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.infoLbl);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ComfirmUninstall";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label infoLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uninstallLocationBox;
    }
}
