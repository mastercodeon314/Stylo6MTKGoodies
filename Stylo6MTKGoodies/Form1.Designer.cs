namespace Stylo6MTKGoodies
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.forceBromBtn = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new Darkness.MenuStrip();
            this.fileToolStripMenuItem = new Darkness.ToolStripMenuItem();
            this.exitToolStripMenuItem = new Darkness.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new Darkness.ToolStripMenuItem();
            this.dragBar2 = new Stylo6MTKGoodies.TitleBar.DragBar();
            this.windowsDefaultTitleBarButton3 = new Stylo6MTKGoodies.TitleBar.WindowsDefaultTitleBarButton();
            this.windowsDefaultTitleBarButton2 = new Stylo6MTKGoodies.TitleBar.WindowsDefaultTitleBarButton();
            this.windowsDefaultTitleBarButton1 = new Stylo6MTKGoodies.TitleBar.WindowsDefaultTitleBarButton();
            this.appIcon1 = new Stylo6MTKGoodies.TitleBar.AppIcon();
            this.dragBar1 = new Stylo6MTKGoodies.TitleBar.DragBar();
            this.TitleLbl = new Stylo6MTKGoodies.TitleBar.TransparentLabel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.rebootBtn = new System.Windows.Forms.Button();
            this.blUnlockBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appIcon1)).BeginInit();
            this.dragBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // forceBromBtn
            // 
            this.forceBromBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forceBromBtn.ForeColor = System.Drawing.Color.Silver;
            this.forceBromBtn.Location = new System.Drawing.Point(1, 67);
            this.forceBromBtn.Name = "forceBromBtn";
            this.forceBromBtn.Size = new System.Drawing.Size(173, 44);
            this.forceBromBtn.TabIndex = 0;
            this.forceBromBtn.Text = "Force Brom";
            this.forceBromBtn.UseVisualStyleBackColor = false;
            this.forceBromBtn.Click += new System.EventHandler(this.forceBromBtn_Click);
            // 
            // outputBox
            // 
            this.outputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.outputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputBox.ForeColor = System.Drawing.Color.Silver;
            this.outputBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.outputBox.Location = new System.Drawing.Point(0, 117);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputBox.Size = new System.Drawing.Size(940, 480);
            this.outputBox.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 40);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(940, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Silver;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.Silver;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.Silver;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // dragBar2
            // 
            this.dragBar2.Location = new System.Drawing.Point(1, 33);
            this.dragBar2.Name = "dragBar2";
            this.dragBar2.Size = new System.Drawing.Size(28, 7);
            this.dragBar2.TabIndex = 9;
            // 
            // windowsDefaultTitleBarButton3
            // 
            this.windowsDefaultTitleBarButton3.ButtonType = Stylo6MTKGoodies.TitleBar.WindowsDefaultTitleBarButton.Type.Minimize;
            this.windowsDefaultTitleBarButton3.ClickColor = System.Drawing.Color.DodgerBlue;
            this.windowsDefaultTitleBarButton3.ClickIconColor = System.Drawing.Color.Black;
            this.windowsDefaultTitleBarButton3.HoverColor = System.Drawing.Color.SkyBlue;
            this.windowsDefaultTitleBarButton3.HoverIconColor = System.Drawing.Color.Black;
            this.windowsDefaultTitleBarButton3.IconColor = System.Drawing.Color.Black;
            this.windowsDefaultTitleBarButton3.IconLineThickness = 2;
            this.windowsDefaultTitleBarButton3.Location = new System.Drawing.Point(820, 0);
            this.windowsDefaultTitleBarButton3.Name = "windowsDefaultTitleBarButton3";
            this.windowsDefaultTitleBarButton3.Size = new System.Drawing.Size(40, 40);
            this.windowsDefaultTitleBarButton3.TabIndex = 7;
            this.windowsDefaultTitleBarButton3.Text = "windowsDefaultTitleBarButton3";
            this.windowsDefaultTitleBarButton3.UseVisualStyleBackColor = true;
            // 
            // windowsDefaultTitleBarButton2
            // 
            this.windowsDefaultTitleBarButton2.ButtonType = Stylo6MTKGoodies.TitleBar.WindowsDefaultTitleBarButton.Type.Maximize;
            this.windowsDefaultTitleBarButton2.ClickColor = System.Drawing.Color.Red;
            this.windowsDefaultTitleBarButton2.ClickIconColor = System.Drawing.Color.Black;
            this.windowsDefaultTitleBarButton2.HoverColor = System.Drawing.Color.OrangeRed;
            this.windowsDefaultTitleBarButton2.HoverIconColor = System.Drawing.Color.Black;
            this.windowsDefaultTitleBarButton2.IconColor = System.Drawing.Color.Black;
            this.windowsDefaultTitleBarButton2.IconLineThickness = 2;
            this.windowsDefaultTitleBarButton2.Location = new System.Drawing.Point(860, 0);
            this.windowsDefaultTitleBarButton2.Name = "windowsDefaultTitleBarButton2";
            this.windowsDefaultTitleBarButton2.Size = new System.Drawing.Size(40, 40);
            this.windowsDefaultTitleBarButton2.TabIndex = 6;
            this.windowsDefaultTitleBarButton2.Text = "windowsDefaultTitleBarButton2";
            this.windowsDefaultTitleBarButton2.UseVisualStyleBackColor = true;
            // 
            // windowsDefaultTitleBarButton1
            // 
            this.windowsDefaultTitleBarButton1.ButtonType = Stylo6MTKGoodies.TitleBar.WindowsDefaultTitleBarButton.Type.Close;
            this.windowsDefaultTitleBarButton1.ClickColor = System.Drawing.Color.Empty;
            this.windowsDefaultTitleBarButton1.ClickIconColor = System.Drawing.Color.Empty;
            this.windowsDefaultTitleBarButton1.HoverColor = System.Drawing.Color.OrangeRed;
            this.windowsDefaultTitleBarButton1.HoverIconColor = System.Drawing.Color.Black;
            this.windowsDefaultTitleBarButton1.IconColor = System.Drawing.Color.Black;
            this.windowsDefaultTitleBarButton1.IconLineThickness = 2;
            this.windowsDefaultTitleBarButton1.Location = new System.Drawing.Point(900, 0);
            this.windowsDefaultTitleBarButton1.Name = "windowsDefaultTitleBarButton1";
            this.windowsDefaultTitleBarButton1.Size = new System.Drawing.Size(40, 40);
            this.windowsDefaultTitleBarButton1.TabIndex = 5;
            this.windowsDefaultTitleBarButton1.Text = "windowsDefaultTitleBarButton1";
            this.windowsDefaultTitleBarButton1.UseVisualStyleBackColor = true;
            // 
            // appIcon1
            // 
            this.appIcon1.Image = ((System.Drawing.Image)(resources.GetObject("appIcon1.Image")));
            this.appIcon1.Location = new System.Drawing.Point(1, 5);
            this.appIcon1.Name = "appIcon1";
            this.appIcon1.Scale = 3.5F;
            this.appIcon1.Size = new System.Drawing.Size(28, 28);
            this.appIcon1.TabIndex = 4;
            this.appIcon1.TabStop = false;
            // 
            // dragBar1
            // 
            this.dragBar1.Controls.Add(this.TitleLbl);
            this.dragBar1.Location = new System.Drawing.Point(31, 0);
            this.dragBar1.Name = "dragBar1";
            this.dragBar1.Size = new System.Drawing.Size(788, 40);
            this.dragBar1.TabIndex = 3;
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.ForeColor = System.Drawing.Color.Silver;
            this.TitleLbl.Location = new System.Drawing.Point(4, 8);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(134, 20);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "LG Stylo 6 Goodies";
            // 
            // cancelBtn
            // 
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.ForeColor = System.Drawing.Color.Silver;
            this.cancelBtn.Location = new System.Drawing.Point(767, 67);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(173, 44);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // rebootBtn
            // 
            this.rebootBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rebootBtn.ForeColor = System.Drawing.Color.Silver;
            this.rebootBtn.Location = new System.Drawing.Point(588, 67);
            this.rebootBtn.Name = "rebootBtn";
            this.rebootBtn.Size = new System.Drawing.Size(173, 44);
            this.rebootBtn.TabIndex = 12;
            this.rebootBtn.Text = "Power Device Off";
            this.rebootBtn.UseVisualStyleBackColor = false;
            this.rebootBtn.Click += new System.EventHandler(this.rebootBtn_Click);
            // 
            // blUnlockBtn
            // 
            this.blUnlockBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blUnlockBtn.ForeColor = System.Drawing.Color.Silver;
            this.blUnlockBtn.Location = new System.Drawing.Point(179, 67);
            this.blUnlockBtn.Name = "blUnlockBtn";
            this.blUnlockBtn.Size = new System.Drawing.Size(173, 44);
            this.blUnlockBtn.TabIndex = 2;
            this.blUnlockBtn.Text = "Bootloader Unlock";
            this.blUnlockBtn.UseVisualStyleBackColor = false;
            this.blUnlockBtn.Click += new System.EventHandler(this.blUnlockBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(941, 600);
            this.Controls.Add(this.rebootBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.dragBar2);
            this.Controls.Add(this.windowsDefaultTitleBarButton3);
            this.Controls.Add(this.windowsDefaultTitleBarButton2);
            this.Controls.Add(this.windowsDefaultTitleBarButton1);
            this.Controls.Add(this.appIcon1);
            this.Controls.Add(this.dragBar1);
            this.Controls.Add(this.blUnlockBtn);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.forceBromBtn);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appIcon1)).EndInit();
            this.dragBar1.ResumeLayout(false);
            this.dragBar1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button forceBromBtn;
        private System.Windows.Forms.TextBox outputBox;
        private TitleBar.DragBar dragBar1;
        private TitleBar.AppIcon appIcon1;
        private TitleBar.WindowsDefaultTitleBarButton windowsDefaultTitleBarButton1;
        private TitleBar.WindowsDefaultTitleBarButton windowsDefaultTitleBarButton2;
        private TitleBar.WindowsDefaultTitleBarButton windowsDefaultTitleBarButton3;
        private TitleBar.TransparentLabel TitleLbl;
        private Darkness.MenuStrip menuStrip1;
        private Darkness.ToolStripMenuItem fileToolStripMenuItem;
        private Darkness.ToolStripMenuItem exitToolStripMenuItem;
        private TitleBar.DragBar dragBar2;
        private Darkness.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button rebootBtn;
        private System.Windows.Forms.Button blUnlockBtn;
    }
}

