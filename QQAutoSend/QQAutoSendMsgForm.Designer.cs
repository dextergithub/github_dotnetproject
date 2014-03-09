namespace QQAutoSend
{
    partial class QQAutoSendMsgForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QQAutoSendMsgForm));
            this.btUpdate = new System.Windows.Forms.Button();
            this.listQQWindows = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TestSendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSendText = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listSendRecord = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btRegister = new System.Windows.Forms.Button();
            this.btTestSend = new System.Windows.Forms.Button();
            this.btLoopSend = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIntervalTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btExit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btStopLoop = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.btTestSingle = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btUpdate
            // 
            this.btUpdate.Location = new System.Drawing.Point(3, 151);
            this.btUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(80, 31);
            this.btUpdate.TabIndex = 0;
            this.btUpdate.Text = "更新";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // listQQWindows
            // 
            this.listQQWindows.ContextMenuStrip = this.contextMenuStrip1;
            this.listQQWindows.FormattingEnabled = true;
            this.listQQWindows.ItemHeight = 16;
            this.listQQWindows.Location = new System.Drawing.Point(1, 209);
            this.listQQWindows.Margin = new System.Windows.Forms.Padding(4);
            this.listQQWindows.Name = "listQQWindows";
            this.listQQWindows.Size = new System.Drawing.Size(262, 276);
            this.listQQWindows.TabIndex = 1;
            this.toolTip1.SetToolTip(this.listQQWindows, "单击右键，显示菜单");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TestSendToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 28);
            // 
            // TestSendToolStripMenuItem
            // 
            this.TestSendToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 12F);
            this.TestSendToolStripMenuItem.Name = "TestSendToolStripMenuItem";
            this.TestSendToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.TestSendToolStripMenuItem.Text = "测试发送信息";
            this.TestSendToolStripMenuItem.Click += new System.EventHandler(this.TestSendToolStripMenuItem_Click);
            // 
            // txtSendText
            // 
            this.txtSendText.Location = new System.Drawing.Point(0, 0);
            this.txtSendText.Name = "txtSendText";
            this.txtSendText.Size = new System.Drawing.Size(494, 121);
            this.txtSendText.TabIndex = 2;
            this.txtSendText.Text = "<输入要发送的内容>";
            this.txtSendText.Enter += new System.EventHandler(this.txtSendText_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "要发送信息的QQ对话框：";
            // 
            // listSendRecord
            // 
            this.listSendRecord.FormattingEnabled = true;
            this.listSendRecord.ItemHeight = 16;
            this.listSendRecord.Location = new System.Drawing.Point(263, 208);
            this.listSendRecord.Name = "listSendRecord";
            this.listSendRecord.Size = new System.Drawing.Size(230, 276);
            this.listSendRecord.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "QQ信息发送记录：";
            // 
            // btRegister
            // 
            this.btRegister.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btRegister.Location = new System.Drawing.Point(303, 498);
            this.btRegister.Name = "btRegister";
            this.btRegister.Size = new System.Drawing.Size(190, 61);
            this.btRegister.TabIndex = 11;
            this.btRegister.Text = "软件注册";
            this.btRegister.UseVisualStyleBackColor = true;
            this.btRegister.Click += new System.EventHandler(this.btRegister_Click);
            // 
            // btTestSend
            // 
            this.btTestSend.Location = new System.Drawing.Point(167, 151);
            this.btTestSend.Margin = new System.Windows.Forms.Padding(4);
            this.btTestSend.Name = "btTestSend";
            this.btTestSend.Size = new System.Drawing.Size(80, 31);
            this.btTestSend.TabIndex = 12;
            this.btTestSend.Text = "循环测试";
            this.btTestSend.UseVisualStyleBackColor = true;
            this.btTestSend.Click += new System.EventHandler(this.btTestSend_Click);
            // 
            // btLoopSend
            // 
            this.btLoopSend.Location = new System.Drawing.Point(249, 151);
            this.btLoopSend.Margin = new System.Windows.Forms.Padding(4);
            this.btLoopSend.Name = "btLoopSend";
            this.btLoopSend.Size = new System.Drawing.Size(80, 31);
            this.btLoopSend.TabIndex = 13;
            this.btLoopSend.Text = "循环发送";
            this.btLoopSend.UseVisualStyleBackColor = true;
            this.btLoopSend.Click += new System.EventHandler(this.btLoopSend_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "循环发送间隔时间";
            // 
            // txtIntervalTime
            // 
            this.txtIntervalTime.Location = new System.Drawing.Point(144, 122);
            this.txtIntervalTime.Name = "txtIntervalTime";
            this.txtIntervalTime.Size = new System.Drawing.Size(65, 26);
            this.txtIntervalTime.TabIndex = 15;
            this.txtIntervalTime.Text = "0";
            this.txtIntervalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIntervalTime.Leave += new System.EventHandler(this.txtIntervalTime_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "分钟";
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(413, 151);
            this.btExit.Margin = new System.Windows.Forms.Padding(4);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(80, 31);
            this.btExit.TabIndex = 17;
            this.btExit.Text = "退出";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btStopLoop
            // 
            this.btStopLoop.Location = new System.Drawing.Point(331, 151);
            this.btStopLoop.Margin = new System.Windows.Forms.Padding(4);
            this.btStopLoop.Name = "btStopLoop";
            this.btStopLoop.Size = new System.Drawing.Size(80, 31);
            this.btStopLoop.TabIndex = 18;
            this.btStopLoop.Text = "停止循环";
            this.btStopLoop.UseVisualStyleBackColor = true;
            this.btStopLoop.Click += new System.EventHandler(this.btStopLoop_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(249, 122);
            this.btClear.Margin = new System.Windows.Forms.Padding(4);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(244, 26);
            this.btClear.TabIndex = 19;
            this.btClear.Text = "清空输入框内容";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btTestSingle
            // 
            this.btTestSingle.Location = new System.Drawing.Point(85, 151);
            this.btTestSingle.Margin = new System.Windows.Forms.Padding(4);
            this.btTestSingle.Name = "btTestSingle";
            this.btTestSingle.Size = new System.Drawing.Size(80, 31);
            this.btTestSingle.TabIndex = 20;
            this.btTestSingle.Text = "单条测试";
            this.btTestSingle.UseVisualStyleBackColor = true;
            this.btTestSingle.Click += new System.EventHandler(this.btTestSingle_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 498);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "显示查找";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(125, 498);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // QQAutoSendMsgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 564);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btTestSingle);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btStopLoop);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIntervalTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btLoopSend);
            this.Controls.Add(this.btTestSend);
            this.Controls.Add(this.btRegister);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listSendRecord);
            this.Controls.Add(this.txtSendText);
            this.Controls.Add(this.listQQWindows);
            this.Controls.Add(this.btUpdate);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QQAutoSendMsgForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QQ信息自动发送器 V1.0   【百木破解】http://www.bmpj.net";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.ListBox listQQWindows;
        private System.Windows.Forms.RichTextBox txtSendText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listSendRecord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btRegister;
        private System.Windows.Forms.Button btTestSend;
        private System.Windows.Forms.Button btLoopSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIntervalTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btStopLoop;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TestSendToolStripMenuItem;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btTestSingle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

