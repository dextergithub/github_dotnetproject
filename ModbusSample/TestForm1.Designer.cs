namespace ModbusSample
{
    partial class TestForm1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Achannelstart = new System.Windows.Forms.NumericUpDown();
            this.Achannelend = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Aperchannel = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.Acurrent = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Bchannelend = new System.Windows.Forms.NumericUpDown();
            this.Bcurrent = new System.Windows.Forms.NumericUpDown();
            this.Bperchannel = new System.Windows.Forms.NumericUpDown();
            this.Bchannelstart = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Achannelstart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Achannelend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Aperchannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Acurrent)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bchannelend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bcurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bperchannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bchannelstart)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "商品A";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(81, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 31);
            this.button2.TabIndex = 0;
            this.button2.Text = "商品B";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Achannelend);
            this.groupBox1.Controls.Add(this.Acurrent);
            this.groupBox1.Controls.Add(this.Aperchannel);
            this.groupBox1.Controls.Add(this.Achannelstart);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 85);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "商品A";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(372, 257);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "保存";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始货道";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "结束货道";
            // 
            // Achannelstart
            // 
            this.Achannelstart.Location = new System.Drawing.Point(68, 20);
            this.Achannelstart.Maximum = new decimal(new int[] {
            71,
            0,
            0,
            0});
            this.Achannelstart.Name = "Achannelstart";
            this.Achannelstart.Size = new System.Drawing.Size(120, 21);
            this.Achannelstart.TabIndex = 1;
            // 
            // Achannelend
            // 
            this.Achannelend.Location = new System.Drawing.Point(68, 47);
            this.Achannelend.Maximum = new decimal(new int[] {
            71,
            0,
            0,
            0});
            this.Achannelend.Name = "Achannelend";
            this.Achannelend.Size = new System.Drawing.Size(120, 21);
            this.Achannelend.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "单货道商品数量";
            // 
            // Aperchannel
            // 
            this.Aperchannel.Location = new System.Drawing.Point(289, 21);
            this.Aperchannel.Name = "Aperchannel";
            this.Aperchannel.Size = new System.Drawing.Size(120, 21);
            this.Aperchannel.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "已出货商品数量";
            // 
            // Acurrent
            // 
            this.Acurrent.Location = new System.Drawing.Point(289, 47);
            this.Acurrent.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Acurrent.Name = "Acurrent";
            this.Acurrent.Size = new System.Drawing.Size(120, 21);
            this.Acurrent.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Bchannelend);
            this.groupBox2.Controls.Add(this.Bcurrent);
            this.groupBox2.Controls.Add(this.Bperchannel);
            this.groupBox2.Controls.Add(this.Bchannelstart);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(13, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 85);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "商品B";
            // 
            // Bchannelend
            // 
            this.Bchannelend.Location = new System.Drawing.Point(68, 47);
            this.Bchannelend.Maximum = new decimal(new int[] {
            71,
            0,
            0,
            0});
            this.Bchannelend.Name = "Bchannelend";
            this.Bchannelend.Size = new System.Drawing.Size(120, 21);
            this.Bchannelend.TabIndex = 1;
            // 
            // Bcurrent
            // 
            this.Bcurrent.Location = new System.Drawing.Point(289, 47);
            this.Bcurrent.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Bcurrent.Name = "Bcurrent";
            this.Bcurrent.Size = new System.Drawing.Size(120, 21);
            this.Bcurrent.TabIndex = 1;
            // 
            // Bperchannel
            // 
            this.Bperchannel.Location = new System.Drawing.Point(289, 21);
            this.Bperchannel.Name = "Bperchannel";
            this.Bperchannel.Size = new System.Drawing.Size(120, 21);
            this.Bperchannel.TabIndex = 1;
            // 
            // Bchannelstart
            // 
            this.Bchannelstart.Location = new System.Drawing.Point(68, 20);
            this.Bchannelstart.Maximum = new decimal(new int[] {
            71,
            0,
            0,
            0});
            this.Bchannelstart.Name = "Bchannelstart";
            this.Bchannelstart.Size = new System.Drawing.Size(120, 21);
            this.Bchannelstart.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "已出货商品数量";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "单货道商品数量";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "结束货道";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "开始货道";
            // 
            // port
            // 
            this.port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.port.FormattingEnabled = true;
            this.port.Items.AddRange(new object[] {
            "Com1",
            "Com2",
            "Com3",
            "Com4",
            "Com5",
            "Com6",
            "Com7",
            "Com8",
            "Com9",
            "Com10",
            "Com11",
            "Com12"});
            this.port.Location = new System.Drawing.Point(81, 246);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(121, 20);
            this.port.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "串口";
            // 
            // TestForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 285);
            this.Controls.Add(this.port);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "TestForm1";
            this.Text = "设置";
            this.Load += new System.EventHandler(this.TestForm1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Achannelstart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Achannelend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Aperchannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Acurrent)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bchannelend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bcurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bperchannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bchannelstart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Achannelend;
        private System.Windows.Forms.NumericUpDown Acurrent;
        private System.Windows.Forms.NumericUpDown Aperchannel;
        private System.Windows.Forms.NumericUpDown Achannelstart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown Bchannelend;
        private System.Windows.Forms.NumericUpDown Bcurrent;
        private System.Windows.Forms.NumericUpDown Bperchannel;
        private System.Windows.Forms.NumericUpDown Bchannelstart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox port;
        private System.Windows.Forms.Label label9;
    }
}