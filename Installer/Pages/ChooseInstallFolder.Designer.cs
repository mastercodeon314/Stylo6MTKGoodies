namespace Stylo6MTKGoodiesInstaller.Pages
{
    partial class ChooseInstallFolder
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
            this.label5 = new System.Windows.Forms.Label();
            this.SpaceAvaLbl = new System.Windows.Forms.Label();
            this.spaceReqLbl = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.destinationBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.progLbl = new System.Windows.Forms.Label();
            this.uninstallerTesterBox = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 8);
            this.label5.MaximumSize = new System.Drawing.Size(526, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(514, 26);
            this.label5.TabIndex = 18;
            this.label5.Text = "Setup will install Stylo 6 MTK Goodies in the following folder. To install in a d" +
    "ifferent folder, click Browse and select another folder. Click Install to start " +
    "the installation";
            // 
            // SpaceAvaLbl
            // 
            this.SpaceAvaLbl.AutoSize = true;
            this.SpaceAvaLbl.Location = new System.Drawing.Point(10, 218);
            this.SpaceAvaLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SpaceAvaLbl.Name = "SpaceAvaLbl";
            this.SpaceAvaLbl.Size = new System.Drawing.Size(89, 13);
            this.SpaceAvaLbl.TabIndex = 17;
            this.SpaceAvaLbl.Text = "Space available: ";
            // 
            // spaceReqLbl
            // 
            this.spaceReqLbl.AutoSize = true;
            this.spaceReqLbl.Location = new System.Drawing.Point(10, 192);
            this.spaceReqLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.spaceReqLbl.Name = "spaceReqLbl";
            this.spaceReqLbl.Size = new System.Drawing.Size(85, 13);
            this.spaceReqLbl.TabIndex = 16;
            this.spaceReqLbl.Text = "Space required: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.browseBtn);
            this.groupBox2.Controls.Add(this.destinationBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 104);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(369, 47);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destination Folder";
            // 
            // browseBtn
            // 
            this.browseBtn.BackColor = System.Drawing.SystemColors.Control;
            this.browseBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.browseBtn.Location = new System.Drawing.Point(274, 17);
            this.browseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(88, 23);
            this.browseBtn.TabIndex = 1;
            this.browseBtn.Text = "Browse...";
            this.browseBtn.UseVisualStyleBackColor = false;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // destinationBox
            // 
            this.destinationBox.Location = new System.Drawing.Point(14, 17);
            this.destinationBox.Margin = new System.Windows.Forms.Padding(2);
            this.destinationBox.Name = "destinationBox";
            this.destinationBox.Size = new System.Drawing.Size(256, 20);
            this.destinationBox.TabIndex = 0;
            this.destinationBox.TextChanged += new System.EventHandler(this.destinationBox_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(287, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Test Btn";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progLbl
            // 
            this.progLbl.AutoSize = true;
            this.progLbl.Location = new System.Drawing.Point(284, 176);
            this.progLbl.Name = "progLbl";
            this.progLbl.Size = new System.Drawing.Size(82, 13);
            this.progLbl.TabIndex = 20;
            this.progLbl.Text = "7z Progress: 0%";
            this.progLbl.Visible = false;
            // 
            // uninstallerTesterBox
            // 
            this.uninstallerTesterBox.AutoSize = true;
            this.uninstallerTesterBox.Location = new System.Drawing.Point(13, 156);
            this.uninstallerTesterBox.Name = "uninstallerTesterBox";
            this.uninstallerTesterBox.Size = new System.Drawing.Size(255, 17);
            this.uninstallerTesterBox.TabIndex = 21;
            this.uninstallerTesterBox.Text = "Check to proceed to the uninstaller testing page.";
            this.uninstallerTesterBox.UseVisualStyleBackColor = true;
            this.uninstallerTesterBox.Visible = false;
            this.uninstallerTesterBox.CheckedChanged += new System.EventHandler(this.uninstallerTesterBox_CheckedChanged);
            // 
            // ChooseInstallFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uninstallerTesterBox);
            this.Controls.Add(this.progLbl);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SpaceAvaLbl);
            this.Controls.Add(this.spaceReqLbl);
            this.Controls.Add(this.groupBox2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ChooseInstallFolder";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label SpaceAvaLbl;
        private System.Windows.Forms.Label spaceReqLbl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.TextBox destinationBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label progLbl;
        private System.Windows.Forms.CheckBox uninstallerTesterBox;
    }
}
