namespace Stylo6MTKGoodies
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.infoBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dragBar2 = new Stylo6MTKGoodies.TitleBar.DragBar();
            this.windowsDefaultTitleBarButton1 = new Stylo6MTKGoodies.TitleBar.WindowsDefaultTitleBarButton();
            this.appIcon1 = new Stylo6MTKGoodies.TitleBar.AppIcon();
            this.dragBar1 = new Stylo6MTKGoodies.TitleBar.DragBar();
            this.TitleLbl = new Stylo6MTKGoodies.TitleBar.TransparentLabel();
            ((System.ComponentModel.ISupportInitialize)(this.appIcon1)).BeginInit();
            this.dragBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoBox
            // 
            this.infoBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.infoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoBox.ForeColor = System.Drawing.Color.Silver;
            this.infoBox.Location = new System.Drawing.Point(1, 81);
            this.infoBox.Multiline = true;
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(358, 285);
            this.infoBox.TabIndex = 10;
            this.infoBox.Text = resources.GetString("infoBox.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(129, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Application Information";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.Color.Silver;
            this.textBox1.Location = new System.Drawing.Point(366, 81);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(382, 285);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(501, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Application Usage";
            // 
            // dragBar2
            // 
            this.dragBar2.Location = new System.Drawing.Point(1, 33);
            this.dragBar2.Name = "dragBar2";
            this.dragBar2.Size = new System.Drawing.Size(28, 7);
            this.dragBar2.TabIndex = 9;
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
            this.windowsDefaultTitleBarButton1.Location = new System.Drawing.Point(710, 0);
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
            this.dragBar1.Size = new System.Drawing.Size(679, 40);
            this.dragBar1.TabIndex = 3;
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.ForeColor = System.Drawing.Color.Silver;
            this.TitleLbl.Location = new System.Drawing.Point(4, 8);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(147, 20);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "Stylo MTK 6 Goodies";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(749, 370);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.dragBar2);
            this.Controls.Add(this.windowsDefaultTitleBarButton1);
            this.Controls.Add(this.appIcon1);
            this.Controls.Add(this.dragBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAbout";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.appIcon1)).EndInit();
            this.dragBar1.ResumeLayout(false);
            this.dragBar1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TitleBar.DragBar dragBar1;
        private TitleBar.AppIcon appIcon1;
        private TitleBar.WindowsDefaultTitleBarButton windowsDefaultTitleBarButton1;
        private TitleBar.TransparentLabel TitleLbl;
        private TitleBar.DragBar dragBar2;
        private System.Windows.Forms.TextBox infoBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}

