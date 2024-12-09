
namespace gprs
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new System.Windows.Forms.TextBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            textBox2 = new System.Windows.Forms.TextBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            radioButton1 = new System.Windows.Forms.RadioButton();
            groupBox1 = new System.Windows.Forms.GroupBox();
            radioButton10 = new System.Windows.Forms.RadioButton();
            radioButton4 = new System.Windows.Forms.RadioButton();
            radioButton3 = new System.Windows.Forms.RadioButton();
            radioButton2 = new System.Windows.Forms.RadioButton();
            numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            groupBox2 = new System.Windows.Forms.GroupBox();
            numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            groupBox3 = new System.Windows.Forms.GroupBox();
            radioButton11 = new System.Windows.Forms.RadioButton();
            radioButton9 = new System.Windows.Forms.RadioButton();
            radioButton8 = new System.Windows.Forms.RadioButton();
            radioButton7 = new System.Windows.Forms.RadioButton();
            radioButton6 = new System.Windows.Forms.RadioButton();
            radioButton5 = new System.Windows.Forms.RadioButton();
            radioButton12 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F);
            textBox1.Location = new System.Drawing.Point(11, 398);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(517, 35);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(200, 200);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F);
            textBox2.Location = new System.Drawing.Point(11, 460);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(517, 35);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new System.Drawing.Point(218, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(200, 200);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new System.Drawing.Point(424, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(200, 200);
            pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new System.Drawing.Point(6, 22);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new System.Drawing.Size(74, 21);
            radioButton1.TabIndex = 6;
            radioButton1.TabStop = true;
            radioButton1.Text = "图像锁头";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton10);
            groupBox1.Controls.Add(radioButton4);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new System.Drawing.Point(11, 229);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(122, 163);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "功能选择";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // radioButton10
            // 
            radioButton10.AutoSize = true;
            radioButton10.Location = new System.Drawing.Point(6, 127);
            radioButton10.Name = "radioButton10";
            radioButton10.Size = new System.Drawing.Size(86, 21);
            radioButton10.TabIndex = 10;
            radioButton10.TabStop = true;
            radioButton10.Text = "灵敏度调试";
            radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new System.Drawing.Point(6, 100);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new System.Drawing.Size(74, 21);
            radioButton4.TabIndex = 9;
            radioButton4.TabStop = true;
            radioButton4.Text = "红名开枪";
            radioButton4.UseVisualStyleBackColor = true;
            radioButton4.CheckedChanged += radioButton4_CheckedChanged;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new System.Drawing.Point(6, 73);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new System.Drawing.Size(74, 21);
            radioButton3.TabIndex = 8;
            radioButton3.TabStop = true;
            radioButton3.Text = "单次架点";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new System.Drawing.Point(6, 46);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new System.Drawing.Size(74, 21);
            radioButton2.TabIndex = 7;
            radioButton2.TabStop = true;
            radioButton2.Text = "自动架点";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new System.Drawing.Point(6, 22);
            numericUpDown1.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(120, 23);
            numericUpDown1.TabIndex = 8;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(numericUpDown3);
            groupBox2.Controls.Add(numericUpDown2);
            groupBox2.Controls.Add(numericUpDown1);
            groupBox2.Location = new System.Drawing.Point(414, 229);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(169, 163);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "识别到人物后多久开枪(ms)";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new System.Drawing.Point(6, 80);
            numericUpDown3.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new System.Drawing.Size(120, 23);
            numericUpDown3.TabIndex = 10;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new System.Drawing.Point(6, 51);
            numericUpDown2.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new System.Drawing.Size(120, 23);
            numericUpDown2.TabIndex = 9;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(radioButton12);
            groupBox3.Controls.Add(radioButton11);
            groupBox3.Controls.Add(radioButton9);
            groupBox3.Controls.Add(radioButton8);
            groupBox3.Controls.Add(radioButton7);
            groupBox3.Controls.Add(radioButton6);
            groupBox3.Controls.Add(radioButton5);
            groupBox3.Location = new System.Drawing.Point(157, 229);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(238, 163);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "枪械参数选择";
            // 
            // radioButton11
            // 
            radioButton11.AutoSize = true;
            radioButton11.Location = new System.Drawing.Point(107, 22);
            radioButton11.Name = "radioButton11";
            radioButton11.Size = new System.Drawing.Size(58, 21);
            radioButton11.TabIndex = 12;
            radioButton11.TabStop = true;
            radioButton11.Text = "m700";
            radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            radioButton9.AutoSize = true;
            radioButton9.Location = new System.Drawing.Point(6, 127);
            radioButton9.Name = "radioButton9";
            radioButton9.Size = new System.Drawing.Size(50, 21);
            radioButton9.TabIndex = 11;
            radioButton9.TabStop = true;
            radioButton9.Text = "手枪";
            radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            radioButton8.AutoSize = true;
            radioButton8.Location = new System.Drawing.Point(6, 100);
            radioButton8.Name = "radioButton8";
            radioButton8.Size = new System.Drawing.Size(67, 21);
            radioButton8.TabIndex = 3;
            radioButton8.TabStop = true;
            radioButton8.Text = "步枪-头";
            radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            radioButton7.AutoSize = true;
            radioButton7.Location = new System.Drawing.Point(6, 73);
            radioButton7.Name = "radioButton7";
            radioButton7.Size = new System.Drawing.Size(58, 21);
            radioButton7.TabIndex = 2;
            radioButton7.TabStop = true;
            radioButton7.Text = "m200";
            radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Location = new System.Drawing.Point(6, 46);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new System.Drawing.Size(62, 21);
            radioButton6.TabIndex = 1;
            radioButton6.TabStop = true;
            radioButton6.Text = "巴雷特";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new System.Drawing.Point(6, 22);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new System.Drawing.Size(47, 21);
            radioButton5.TabIndex = 0;
            radioButton5.TabStop = true;
            radioButton5.Text = "98k";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            radioButton12.AutoSize = true;
            radioButton12.Location = new System.Drawing.Point(107, 46);
            radioButton12.Name = "radioButton12";
            radioButton12.Size = new System.Drawing.Size(79, 21);
            radioButton12.TabIndex = 13;
            radioButton12.TabStop = true;
            radioButton12.Text = "步枪-身子";
            radioButton12.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(633, 508);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(textBox2);
            Controls.Add(pictureBox1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton12;
    }
}

