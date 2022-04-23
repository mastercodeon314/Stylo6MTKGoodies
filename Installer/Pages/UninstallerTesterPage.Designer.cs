namespace Stylo6MTKGoodiesInstaller.Pages
{
    partial class UninstallerTesterPage
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
            this.regBtn = new System.Windows.Forms.Button();
            this.unregBtn = new System.Windows.Forms.Button();
            this.isRegBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // regBtn
            // 
            this.regBtn.Location = new System.Drawing.Point(179, 108);
            this.regBtn.Name = "regBtn";
            this.regBtn.Size = new System.Drawing.Size(123, 23);
            this.regBtn.TabIndex = 0;
            this.regBtn.Text = "Register Uninstaller";
            this.regBtn.UseVisualStyleBackColor = true;
            this.regBtn.Click += new System.EventHandler(this.regBtn_Click);
            // 
            // unregBtn
            // 
            this.unregBtn.Location = new System.Drawing.Point(179, 137);
            this.unregBtn.Name = "unregBtn";
            this.unregBtn.Size = new System.Drawing.Size(123, 23);
            this.unregBtn.TabIndex = 1;
            this.unregBtn.Text = "Unregister Uninstaller";
            this.unregBtn.UseVisualStyleBackColor = true;
            this.unregBtn.Click += new System.EventHandler(this.unregBtn_Click);
            // 
            // isRegBox
            // 
            this.isRegBox.AutoSize = true;
            this.isRegBox.Location = new System.Drawing.Point(44, 112);
            this.isRegBox.Name = "isRegBox";
            this.isRegBox.Size = new System.Drawing.Size(129, 17);
            this.isRegBox.TabIndex = 2;
            this.isRegBox.Text = "Uninstaller Registered";
            this.isRegBox.UseVisualStyleBackColor = true;
            // 
            // UninstallerTesterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.isRegBox);
            this.Controls.Add(this.unregBtn);
            this.Controls.Add(this.regBtn);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UninstallerTesterPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button regBtn;
        private System.Windows.Forms.Button unregBtn;
        private System.Windows.Forms.CheckBox isRegBox;
    }
}
