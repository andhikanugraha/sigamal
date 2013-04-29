namespace SiGamalOutlookAddin
{
    partial class SiGamal
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SaveKeySignButton = new System.Windows.Forms.Button();
            this.SignButton = new System.Windows.Forms.Button();
            this.RandomKeySignButton = new System.Windows.Forms.Button();
            this.LoadKeySignButton = new System.Windows.Forms.Button();
            this.xSignTextBox = new System.Windows.Forms.TextBox();
            this.gSignTextBox = new System.Windows.Forms.TextBox();
            this.pSignTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.p = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.VerifyButton = new System.Windows.Forms.Button();
            this.LoadKeyVerifyButton = new System.Windows.Forms.Button();
            this.yVerifyTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gVerifyTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pVerifyTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(503, 105);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SaveKeySignButton);
            this.tabPage1.Controls.Add(this.SignButton);
            this.tabPage1.Controls.Add(this.RandomKeySignButton);
            this.tabPage1.Controls.Add(this.LoadKeySignButton);
            this.tabPage1.Controls.Add(this.xSignTextBox);
            this.tabPage1.Controls.Add(this.gSignTextBox);
            this.tabPage1.Controls.Add(this.pSignTextBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.p);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(495, 79);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sign";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // SaveKeySignButton
            // 
            this.SaveKeySignButton.Location = new System.Drawing.Point(316, 34);
            this.SaveKeySignButton.Name = "SaveKeySignButton";
            this.SaveKeySignButton.Size = new System.Drawing.Size(75, 23);
            this.SaveKeySignButton.TabIndex = 9;
            this.SaveKeySignButton.Text = "Save Button";
            this.SaveKeySignButton.UseVisualStyleBackColor = true;
            this.SaveKeySignButton.Click += new System.EventHandler(this.SaveKeySignButton_Click);
            // 
            // SignButton
            // 
            this.SignButton.Location = new System.Drawing.Point(397, 34);
            this.SignButton.Name = "SignButton";
            this.SignButton.Size = new System.Drawing.Size(75, 23);
            this.SignButton.TabIndex = 8;
            this.SignButton.Text = "Sign";
            this.SignButton.UseVisualStyleBackColor = true;
            this.SignButton.Click += new System.EventHandler(this.SignButton_Click);
            // 
            // RandomKeySignButton
            // 
            this.RandomKeySignButton.Location = new System.Drawing.Point(154, 34);
            this.RandomKeySignButton.Name = "RandomKeySignButton";
            this.RandomKeySignButton.Size = new System.Drawing.Size(75, 23);
            this.RandomKeySignButton.TabIndex = 7;
            this.RandomKeySignButton.Text = "Random";
            this.RandomKeySignButton.UseVisualStyleBackColor = true;
            this.RandomKeySignButton.Click += new System.EventHandler(this.RandomKeySignButton_Click);
            // 
            // LoadKeySignButton
            // 
            this.LoadKeySignButton.Location = new System.Drawing.Point(235, 34);
            this.LoadKeySignButton.Name = "LoadKeySignButton";
            this.LoadKeySignButton.Size = new System.Drawing.Size(75, 23);
            this.LoadKeySignButton.TabIndex = 6;
            this.LoadKeySignButton.Text = "Load";
            this.LoadKeySignButton.UseVisualStyleBackColor = true;
            this.LoadKeySignButton.Click += new System.EventHandler(this.LoadKeySignButton_Click);
            // 
            // xSignTextBox
            // 
            this.xSignTextBox.Location = new System.Drawing.Point(291, 7);
            this.xSignTextBox.Name = "xSignTextBox";
            this.xSignTextBox.Size = new System.Drawing.Size(100, 20);
            this.xSignTextBox.TabIndex = 5;
            this.xSignTextBox.Text = "0";
            // 
            // gSignTextBox
            // 
            this.gSignTextBox.Location = new System.Drawing.Point(160, 7);
            this.gSignTextBox.Name = "gSignTextBox";
            this.gSignTextBox.Size = new System.Drawing.Size(100, 20);
            this.gSignTextBox.TabIndex = 4;
            this.gSignTextBox.Text = "0";
            // 
            // pSignTextBox
            // 
            this.pSignTextBox.Location = new System.Drawing.Point(27, 7);
            this.pSignTextBox.Name = "pSignTextBox";
            this.pSignTextBox.Size = new System.Drawing.Size(100, 20);
            this.pSignTextBox.TabIndex = 3;
            this.pSignTextBox.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "x";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "g";
            // 
            // p
            // 
            this.p.AutoSize = true;
            this.p.Location = new System.Drawing.Point(7, 7);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(13, 13);
            this.p.TabIndex = 0;
            this.p.Text = "p";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.VerifyButton);
            this.tabPage2.Controls.Add(this.LoadKeyVerifyButton);
            this.tabPage2.Controls.Add(this.yVerifyTextBox);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.gVerifyTextBox);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.pVerifyTextBox);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(495, 79);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Verify";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // VerifyButton
            // 
            this.VerifyButton.Location = new System.Drawing.Point(345, 33);
            this.VerifyButton.Name = "VerifyButton";
            this.VerifyButton.Size = new System.Drawing.Size(75, 23);
            this.VerifyButton.TabIndex = 7;
            this.VerifyButton.Text = "Verify";
            this.VerifyButton.UseVisualStyleBackColor = true;
            this.VerifyButton.Click += new System.EventHandler(this.VerifyButton_Click);
            // 
            // LoadKeyVerifyButton
            // 
            this.LoadKeyVerifyButton.Location = new System.Drawing.Point(264, 33);
            this.LoadKeyVerifyButton.Name = "LoadKeyVerifyButton";
            this.LoadKeyVerifyButton.Size = new System.Drawing.Size(75, 23);
            this.LoadKeyVerifyButton.TabIndex = 6;
            this.LoadKeyVerifyButton.Text = "Load";
            this.LoadKeyVerifyButton.UseVisualStyleBackColor = true;
            this.LoadKeyVerifyButton.Click += new System.EventHandler(this.LoadKeyVerifyButton_Click);
            // 
            // yVerifyTextBox
            // 
            this.yVerifyTextBox.Location = new System.Drawing.Point(300, 7);
            this.yVerifyTextBox.Name = "yVerifyTextBox";
            this.yVerifyTextBox.Size = new System.Drawing.Size(100, 20);
            this.yVerifyTextBox.TabIndex = 5;
            this.yVerifyTextBox.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "y";
            // 
            // gVerifyTextBox
            // 
            this.gVerifyTextBox.Location = new System.Drawing.Point(163, 7);
            this.gVerifyTextBox.Name = "gVerifyTextBox";
            this.gVerifyTextBox.Size = new System.Drawing.Size(100, 20);
            this.gVerifyTextBox.TabIndex = 3;
            this.gVerifyTextBox.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "g";
            // 
            // pVerifyTextBox
            // 
            this.pVerifyTextBox.Location = new System.Drawing.Point(27, 7);
            this.pVerifyTextBox.Name = "pVerifyTextBox";
            this.pVerifyTextBox.Size = new System.Drawing.Size(100, 20);
            this.pVerifyTextBox.TabIndex = 1;
            this.pVerifyTextBox.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "p";
            // 
            // SiGamal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 133);
            this.Controls.Add(this.tabControl1);
            this.Name = "SiGamal";
            this.Text = "SiGamal";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button SignButton;
        private System.Windows.Forms.Button RandomKeySignButton;
        private System.Windows.Forms.Button LoadKeySignButton;
        private System.Windows.Forms.TextBox xSignTextBox;
        private System.Windows.Forms.TextBox gSignTextBox;
        private System.Windows.Forms.TextBox pSignTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label p;
        private System.Windows.Forms.Button VerifyButton;
        private System.Windows.Forms.Button LoadKeyVerifyButton;
        private System.Windows.Forms.TextBox yVerifyTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox gVerifyTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pVerifyTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveKeySignButton;
    }
}