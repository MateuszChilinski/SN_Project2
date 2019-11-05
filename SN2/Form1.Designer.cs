namespace SN2
{
    partial class Form1
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
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.FileComboBox = new System.Windows.Forms.ComboBox();
            this.NoiseValue = new System.Windows.Forms.NumericUpDown();
            this.StartButton = new System.Windows.Forms.Button();
            this.MethodComboBox = new System.Windows.Forms.ComboBox();
            this.MethodLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AsyncCheckBox = new System.Windows.Forms.CheckBox();
            this.OriginalPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoiseValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.Location = new System.Drawing.Point(12, 12);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(484, 299);
            this.MainPictureBox.TabIndex = 0;
            this.MainPictureBox.TabStop = false;
            // 
            // FileComboBox
            // 
            this.FileComboBox.FormattingEnabled = true;
            this.FileComboBox.Location = new System.Drawing.Point(1186, 127);
            this.FileComboBox.Name = "FileComboBox";
            this.FileComboBox.Size = new System.Drawing.Size(169, 28);
            this.FileComboBox.TabIndex = 1;
            // 
            // NoiseValue
            // 
            this.NoiseValue.Location = new System.Drawing.Point(1186, 80);
            this.NoiseValue.Name = "NoiseValue";
            this.NoiseValue.Size = new System.Drawing.Size(169, 26);
            this.NoiseValue.TabIndex = 2;
            this.NoiseValue.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(1070, 269);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(285, 42);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // MethodComboBox
            // 
            this.MethodComboBox.FormattingEnabled = true;
            this.MethodComboBox.Items.AddRange(new object[] {
            "Hebb\'s rule",
            "Oja\'s rule"});
            this.MethodComboBox.Location = new System.Drawing.Point(1186, 23);
            this.MethodComboBox.Name = "MethodComboBox";
            this.MethodComboBox.Size = new System.Drawing.Size(169, 28);
            this.MethodComboBox.TabIndex = 4;
            // 
            // MethodLabel
            // 
            this.MethodLabel.AutoSize = true;
            this.MethodLabel.Location = new System.Drawing.Point(1069, 26);
            this.MethodLabel.Name = "MethodLabel";
            this.MethodLabel.Size = new System.Drawing.Size(63, 20);
            this.MethodLabel.TabIndex = 5;
            this.MethodLabel.Text = "Method";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1069, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Noise (%)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1069, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "File";
            // 
            // AsyncCheckBox
            // 
            this.AsyncCheckBox.AutoSize = true;
            this.AsyncCheckBox.Location = new System.Drawing.Point(1073, 161);
            this.AsyncCheckBox.Name = "AsyncCheckBox";
            this.AsyncCheckBox.Size = new System.Drawing.Size(78, 24);
            this.AsyncCheckBox.TabIndex = 8;
            this.AsyncCheckBox.Text = "Async";
            this.AsyncCheckBox.UseVisualStyleBackColor = true;
            // 
            // OriginalPictureBox
            // 
            this.OriginalPictureBox.Location = new System.Drawing.Point(521, 12);
            this.OriginalPictureBox.Name = "OriginalPictureBox";
            this.OriginalPictureBox.Size = new System.Drawing.Size(484, 299);
            this.OriginalPictureBox.TabIndex = 9;
            this.OriginalPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1830, 346);
            this.Controls.Add(this.OriginalPictureBox);
            this.Controls.Add(this.AsyncCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MethodLabel);
            this.Controls.Add(this.MethodComboBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.NoiseValue);
            this.Controls.Add(this.FileComboBox);
            this.Controls.Add(this.MainPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoiseValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPictureBox;
        private System.Windows.Forms.ComboBox FileComboBox;
        private System.Windows.Forms.NumericUpDown NoiseValue;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ComboBox MethodComboBox;
        private System.Windows.Forms.Label MethodLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox AsyncCheckBox;
        private System.Windows.Forms.PictureBox OriginalPictureBox;
    }
}

