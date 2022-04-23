namespace COMPortScanner
{
    partial class AdbTesting
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
            this.deviceBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bootedBox = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.attachedBox = new System.Windows.Forms.CheckBox();
            this.commandBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sendBtn = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // deviceBox
            // 
            this.deviceBox.FormattingEnabled = true;
            this.deviceBox.Location = new System.Drawing.Point(411, 25);
            this.deviceBox.Name = "deviceBox";
            this.deviceBox.Size = new System.Drawing.Size(181, 199);
            this.deviceBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Attached adb devices";
            // 
            // bootedBox
            // 
            this.bootedBox.AutoSize = true;
            this.bootedBox.Location = new System.Drawing.Point(290, 52);
            this.bootedBox.Name = "bootedBox";
            this.bootedBox.Size = new System.Drawing.Size(106, 17);
            this.bootedBox.TabIndex = 2;
            this.bootedBox.Text = "Device is booted";
            this.bootedBox.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(272, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // attachedBox
            // 
            this.attachedBox.AutoSize = true;
            this.attachedBox.Location = new System.Drawing.Point(290, 29);
            this.attachedBox.Name = "attachedBox";
            this.attachedBox.Size = new System.Drawing.Size(115, 17);
            this.attachedBox.TabIndex = 4;
            this.attachedBox.Text = "Device is attached";
            this.attachedBox.UseVisualStyleBackColor = true;
            // 
            // commandBox
            // 
            this.commandBox.Location = new System.Drawing.Point(15, 108);
            this.commandBox.Name = "commandBox";
            this.commandBox.Size = new System.Drawing.Size(160, 20);
            this.commandBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Adb Command";
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(15, 134);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(108, 23);
            this.sendBtn.TabIndex = 7;
            this.sendBtn.Text = "Send To Device";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(12, 189);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(321, 176);
            this.outputBox.TabIndex = 8;
            // 
            // AdbTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 414);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commandBox);
            this.Controls.Add(this.attachedBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.bootedBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deviceBox);
            this.Name = "AdbTesting";
            this.Text = "AdbTesting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox deviceBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox bootedBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox attachedBox;
        private System.Windows.Forms.TextBox commandBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.TextBox outputBox;
    }
}