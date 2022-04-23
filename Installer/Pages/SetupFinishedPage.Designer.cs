namespace Stylo6MTKGoodiesInstaller.Pages
{
    partial class SetupFinishedPage
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
            this.showReleaseNotesBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lineLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // showReleaseNotesBox
            // 
            this.showReleaseNotesBox.AutoSize = true;
            this.showReleaseNotesBox.Location = new System.Drawing.Point(210, 166);
            this.showReleaseNotesBox.Name = "showReleaseNotesBox";
            this.showReleaseNotesBox.Size = new System.Drawing.Size(119, 17);
            this.showReleaseNotesBox.TabIndex = 12;
            this.showReleaseNotesBox.Text = "Show release notes";
            this.showReleaseNotesBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(206, 20);
            this.label5.MaximumSize = new System.Drawing.Size(300, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 48);
            this.label5.TabIndex = 11;
            this.label5.Text = "Completing Stylo 6 MTK Goodies Setup";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 111);
            this.label4.MaximumSize = new System.Drawing.Size(300, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Click Finish to close Setup";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 79);
            this.label1.MaximumSize = new System.Drawing.Size(300, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Stylo 6 MTK Goodies has been installed on your computer.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 324);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // lineLbl
            // 
            this.lineLbl.Enabled = false;
            this.lineLbl.Location = new System.Drawing.Point(0, 327);
            this.lineLbl.Margin = new System.Windows.Forms.Padding(0);
            this.lineLbl.Name = "lineLbl";
            this.lineLbl.Size = new System.Drawing.Size(535, 14);
            this.lineLbl.TabIndex = 13;
            this.lineLbl.Text = "────────────────────────────────────────────────────────────────────";
            // 
            // SetupFinishedPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lineLbl);
            this.Controls.Add(this.showReleaseNotesBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "SetupFinishedPage";
            this.Size = new System.Drawing.Size(541, 340);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox showReleaseNotesBox;
        private System.Windows.Forms.Label lineLbl;
    }
}
