namespace ExampleCall
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Choose1 = new System.Windows.Forms.Button();
            this.Choose2 = new System.Windows.Forms.Button();
            this.Choose3 = new System.Windows.Forms.Button();
            this.Choose4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.StartCompute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ChuangchangDian = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HuadongDian = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.queshu = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Choose1
            // 
            this.Choose1.Location = new System.Drawing.Point(24, 22);
            this.Choose1.Name = "Choose1";
            this.Choose1.Size = new System.Drawing.Size(121, 19);
            this.Choose1.TabIndex = 1;
            this.Choose1.Tag = "";
            this.Choose1.Text = "选择第1路数据文件";
            this.Choose1.UseVisualStyleBackColor = true;
            this.Choose1.Click += new System.EventHandler(this.Choose1_Click);
            // 
            // Choose2
            // 
            this.Choose2.Location = new System.Drawing.Point(24, 61);
            this.Choose2.Name = "Choose2";
            this.Choose2.Size = new System.Drawing.Size(121, 19);
            this.Choose2.TabIndex = 2;
            this.Choose2.Tag = "";
            this.Choose2.Text = "选择第2路数据文件";
            this.Choose2.UseVisualStyleBackColor = true;
            this.Choose2.Click += new System.EventHandler(this.Choose2_Click);
            // 
            // Choose3
            // 
            this.Choose3.Location = new System.Drawing.Point(24, 100);
            this.Choose3.Name = "Choose3";
            this.Choose3.Size = new System.Drawing.Size(121, 19);
            this.Choose3.TabIndex = 3;
            this.Choose3.Tag = "";
            this.Choose3.Text = "选择第3路数据文件";
            this.Choose3.UseVisualStyleBackColor = true;
            this.Choose3.Click += new System.EventHandler(this.Choose3_Click);
            // 
            // Choose4
            // 
            this.Choose4.Location = new System.Drawing.Point(24, 140);
            this.Choose4.Name = "Choose4";
            this.Choose4.Size = new System.Drawing.Size(121, 19);
            this.Choose4.TabIndex = 4;
            this.Choose4.Tag = "";
            this.Choose4.Text = "选择第4路数据文件";
            this.Choose4.UseVisualStyleBackColor = true;
            this.Choose4.Click += new System.EventHandler(this.Choose4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(152, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(301, 21);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(152, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(301, 21);
            this.textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(152, 98);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(301, 21);
            this.textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(152, 138);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(301, 21);
            this.textBox4.TabIndex = 8;
            // 
            // StartCompute
            // 
            this.StartCompute.Location = new System.Drawing.Point(451, 308);
            this.StartCompute.Name = "StartCompute";
            this.StartCompute.Size = new System.Drawing.Size(92, 22);
            this.StartCompute.TabIndex = 9;
            this.StartCompute.Text = "计算";
            this.StartCompute.UseVisualStyleBackColor = true;
            this.StartCompute.Click += new System.EventHandler(this.StartCompute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "计算窗长(数据点数)";
            // 
            // ChuangchangDian
            // 
            this.ChuangchangDian.Location = new System.Drawing.Point(27, 201);
            this.ChuangchangDian.Name = "ChuangchangDian";
            this.ChuangchangDian.Size = new System.Drawing.Size(63, 21);
            this.ChuangchangDian.TabIndex = 13;
            this.ChuangchangDian.Text = "7200";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "个点";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "滑动步长(数据点数，大于0且小于等于窗长)";
            // 
            // HuadongDian
            // 
            this.HuadongDian.Location = new System.Drawing.Point(152, 201);
            this.HuadongDian.Name = "HuadongDian";
            this.HuadongDian.Size = new System.Drawing.Size(57, 21);
            this.HuadongDian.TabIndex = 16;
            this.HuadongDian.Text = "24";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "个点";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(286, 230);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(204, 16);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "输出相对标定系数及自检内精度值";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(286, 253);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(144, 16);
            this.checkBox3.TabIndex = 20;
            this.checkBox3.Text = "输出相对标定后的数据";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "相对标定系数或自检内精度存放位置";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Items.AddRange(new object[] {
            "计算窗长的开头",
            "计算窗长的末尾",
            "计算窗长的中间"});
            this.listBox1.Location = new System.Drawing.Point(28, 322);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(97, 52);
            this.listBox1.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "缺数标记";
            // 
            // queshu
            // 
            this.queshu.Location = new System.Drawing.Point(27, 249);
            this.queshu.Name = "queshu";
            this.queshu.Size = new System.Drawing.Size(63, 21);
            this.queshu.TabIndex = 24;
            this.queshu.Text = "999999";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(286, 276);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(150, 16);
            this.checkBox2.TabIndex = 25;
            this.checkBox2.Text = "输出自检结果(1+3,2+4)";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(286, 299);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(138, 16);
            this.checkBox4.TabIndex = 26;
            this.checkBox4.Text = "输出差应变(1-3,2-4)";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 410);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.queshu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.HuadongDian);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChuangchangDian);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartCompute);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Choose4);
            this.Controls.Add(this.Choose3);
            this.Controls.Add(this.Choose2);
            this.Controls.Add(this.Choose1);
            this.Name = "Form1";
            this.Text = "相对标定计算";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Choose1;
        private System.Windows.Forms.Button Choose2;
        private System.Windows.Forms.Button Choose3;
        private System.Windows.Forms.Button Choose4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button StartCompute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ChuangchangDian;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox HuadongDian;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox queshu;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox4;
    }
}

