namespace ModbusSample
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.channelLabel = new System.Windows.Forms.Label();
            this.changeProgressBar = new System.Windows.Forms.ProgressBar();
            this.restChangeLabel = new System.Windows.Forms.Label();
            this.changeButton = new System.Windows.Forms.LinkLabel();
            this.clearMoneyButton = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.hopper2EnableLabel = new System.Windows.Forms.Label();
            this.hopper1EnableLabel = new System.Windows.Forms.Label();
            this.pulse2EnableLabel = new System.Windows.Forms.Label();
            this.pulse1EanbelLabel = new System.Windows.Forms.Label();
            this.mdbChangerEnableLabel = new System.Windows.Forms.Label();
            this.mdbNoteEnableLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.enablePulse2Button = new System.Windows.Forms.LinkLabel();
            this.label14 = new System.Windows.Forms.Label();
            this.enablePulse1Button = new System.Windows.Forms.LinkLabel();
            this.pulseMachine1Label = new System.Windows.Forms.Label();
            this.enableMdbChangerButton = new System.Windows.Forms.LinkLabel();
            this.mdbChangerLabel = new System.Windows.Forms.Label();
            this.mdbNoteLabel = new System.Windows.Forms.Label();
            this.enableMdbNoteButton = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.insertedMoneyLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.clearAllAlarmButton = new System.Windows.Forms.LinkLabel();
            this.motorsControl1 = new ModbusSample.MotorsControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.comportButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.uiUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.changeProgressTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.commStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1264, 643);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1256, 617);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.channelLabel);
            this.panel1.Controls.Add(this.changeProgressBar);
            this.panel1.Controls.Add(this.restChangeLabel);
            this.panel1.Controls.Add(this.changeButton);
            this.panel1.Controls.Add(this.clearMoneyButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.insertedMoneyLabel);
            this.panel1.Location = new System.Drawing.Point(8, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 558);
            this.panel1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DimGray;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(24, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(350, 1);
            this.label4.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(17, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "1. 货道数量";
            // 
            // channelLabel
            // 
            this.channelLabel.AutoSize = true;
            this.channelLabel.Font = new System.Drawing.Font("宋体", 12F);
            this.channelLabel.ForeColor = System.Drawing.Color.Black;
            this.channelLabel.Location = new System.Drawing.Point(34, 67);
            this.channelLabel.Name = "channelLabel";
            this.channelLabel.Size = new System.Drawing.Size(104, 16);
            this.channelLabel.TabIndex = 10;
            this.channelLabel.Text = "500.00（元）";
            // 
            // changeProgressBar
            // 
            this.changeProgressBar.Location = new System.Drawing.Point(274, 213);
            this.changeProgressBar.Name = "changeProgressBar";
            this.changeProgressBar.Size = new System.Drawing.Size(100, 23);
            this.changeProgressBar.TabIndex = 8;
            this.changeProgressBar.Value = 30;
            this.changeProgressBar.Visible = false;
            // 
            // restChangeLabel
            // 
            this.restChangeLabel.AutoSize = true;
            this.restChangeLabel.Font = new System.Drawing.Font("宋体", 12F);
            this.restChangeLabel.ForeColor = System.Drawing.Color.Red;
            this.restChangeLabel.Location = new System.Drawing.Point(34, 220);
            this.restChangeLabel.Name = "restChangeLabel";
            this.restChangeLabel.Size = new System.Drawing.Size(184, 16);
            this.restChangeLabel.TabIndex = 7;
            this.restChangeLabel.Text = "剩余零钱：500.00（元）";
            // 
            // changeButton
            // 
            this.changeButton.AutoSize = true;
            this.changeButton.Location = new System.Drawing.Point(302, 220);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(29, 12);
            this.changeButton.TabIndex = 6;
            this.changeButton.TabStop = true;
            this.changeButton.Text = "找零";
            this.changeButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.changeButton_LinkClicked);
            // 
            // clearMoneyButton
            // 
            this.clearMoneyButton.AutoSize = true;
            this.clearMoneyButton.Location = new System.Drawing.Point(302, 150);
            this.clearMoneyButton.Name = "clearMoneyButton";
            this.clearMoneyButton.Size = new System.Drawing.Size(29, 12);
            this.clearMoneyButton.TabIndex = 6;
            this.clearMoneyButton.TabStop = true;
            this.clearMoneyButton.Text = "清除";
            this.clearMoneyButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.clearMoneyButton_LinkClicked);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(17, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(350, 1);
            this.label3.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(17, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 1);
            this.label2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 1);
            this.label1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.Controls.Add(this.hopper2EnableLabel, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.hopper1EnableLabel, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.pulse2EnableLabel, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.pulse1EanbelLabel, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.mdbChangerEnableLabel, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.mdbNoteEnableLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.enablePulse2Button, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.enablePulse1Button, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.pulseMachine1Label, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.enableMdbChangerButton, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.mdbChangerLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.mdbNoteLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.enableMdbNoteButton, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(38, 285);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(319, 153);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // hopper2EnableLabel
            // 
            this.hopper2EnableLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hopper2EnableLabel.Location = new System.Drawing.Point(204, 130);
            this.hopper2EnableLabel.Margin = new System.Windows.Forms.Padding(5);
            this.hopper2EnableLabel.Name = "hopper2EnableLabel";
            this.hopper2EnableLabel.Size = new System.Drawing.Size(50, 18);
            this.hopper2EnableLabel.TabIndex = 17;
            this.hopper2EnableLabel.Text = "√";
            this.hopper2EnableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hopper1EnableLabel
            // 
            this.hopper1EnableLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hopper1EnableLabel.Location = new System.Drawing.Point(204, 105);
            this.hopper1EnableLabel.Margin = new System.Windows.Forms.Padding(5);
            this.hopper1EnableLabel.Name = "hopper1EnableLabel";
            this.hopper1EnableLabel.Size = new System.Drawing.Size(50, 15);
            this.hopper1EnableLabel.TabIndex = 15;
            this.hopper1EnableLabel.Text = "√";
            this.hopper1EnableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pulse2EnableLabel
            // 
            this.pulse2EnableLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pulse2EnableLabel.Location = new System.Drawing.Point(204, 80);
            this.pulse2EnableLabel.Margin = new System.Windows.Forms.Padding(5);
            this.pulse2EnableLabel.Name = "pulse2EnableLabel";
            this.pulse2EnableLabel.Size = new System.Drawing.Size(50, 15);
            this.pulse2EnableLabel.TabIndex = 14;
            this.pulse2EnableLabel.Text = "√";
            this.pulse2EnableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pulse1EanbelLabel
            // 
            this.pulse1EanbelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pulse1EanbelLabel.Location = new System.Drawing.Point(204, 55);
            this.pulse1EanbelLabel.Margin = new System.Windows.Forms.Padding(5);
            this.pulse1EanbelLabel.Name = "pulse1EanbelLabel";
            this.pulse1EanbelLabel.Size = new System.Drawing.Size(50, 15);
            this.pulse1EanbelLabel.TabIndex = 13;
            this.pulse1EanbelLabel.Text = "√";
            this.pulse1EanbelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mdbChangerEnableLabel
            // 
            this.mdbChangerEnableLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdbChangerEnableLabel.Location = new System.Drawing.Point(204, 30);
            this.mdbChangerEnableLabel.Margin = new System.Windows.Forms.Padding(5);
            this.mdbChangerEnableLabel.Name = "mdbChangerEnableLabel";
            this.mdbChangerEnableLabel.Size = new System.Drawing.Size(50, 15);
            this.mdbChangerEnableLabel.TabIndex = 12;
            this.mdbChangerEnableLabel.Text = "√";
            this.mdbChangerEnableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mdbNoteEnableLabel
            // 
            this.mdbNoteEnableLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdbNoteEnableLabel.Location = new System.Drawing.Point(204, 5);
            this.mdbNoteEnableLabel.Margin = new System.Windows.Forms.Padding(5);
            this.mdbNoteEnableLabel.Name = "mdbNoteEnableLabel";
            this.mdbNoteEnableLabel.Size = new System.Drawing.Size(50, 15);
            this.mdbNoteEnableLabel.TabIndex = 11;
            this.mdbNoteEnableLabel.Text = "√";
            this.mdbNoteEnableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(5, 130);
            this.label12.Margin = new System.Windows.Forms.Padding(5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(189, 18);
            this.label12.TabIndex = 10;
            this.label12.Text = "6) 2#Hopper找零机";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(5, 105);
            this.label13.Margin = new System.Windows.Forms.Padding(5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(189, 15);
            this.label13.TabIndex = 8;
            this.label13.Text = "5) 1#Hopper找零机";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // enablePulse2Button
            // 
            this.enablePulse2Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enablePulse2Button.Location = new System.Drawing.Point(264, 80);
            this.enablePulse2Button.Margin = new System.Windows.Forms.Padding(5);
            this.enablePulse2Button.Name = "enablePulse2Button";
            this.enablePulse2Button.Size = new System.Drawing.Size(50, 15);
            this.enablePulse2Button.TabIndex = 7;
            this.enablePulse2Button.TabStop = true;
            this.enablePulse2Button.Text = "禁用";
            this.enablePulse2Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.enablePulse2Button.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.enablePulse2Button_LinkClicked);
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(5, 80);
            this.label14.Margin = new System.Windows.Forms.Padding(5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(189, 15);
            this.label14.TabIndex = 6;
            this.label14.Text = "4) 2#脉冲式收币器";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // enablePulse1Button
            // 
            this.enablePulse1Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enablePulse1Button.Location = new System.Drawing.Point(264, 55);
            this.enablePulse1Button.Margin = new System.Windows.Forms.Padding(5);
            this.enablePulse1Button.Name = "enablePulse1Button";
            this.enablePulse1Button.Size = new System.Drawing.Size(50, 15);
            this.enablePulse1Button.TabIndex = 5;
            this.enablePulse1Button.TabStop = true;
            this.enablePulse1Button.Text = "禁用";
            this.enablePulse1Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.enablePulse1Button.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.enablePulse1Button_LinkClicked);
            // 
            // pulseMachine1Label
            // 
            this.pulseMachine1Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pulseMachine1Label.Location = new System.Drawing.Point(5, 55);
            this.pulseMachine1Label.Margin = new System.Windows.Forms.Padding(5);
            this.pulseMachine1Label.Name = "pulseMachine1Label";
            this.pulseMachine1Label.Size = new System.Drawing.Size(189, 15);
            this.pulseMachine1Label.TabIndex = 4;
            this.pulseMachine1Label.Text = "3) 1#脉冲式收币器";
            this.pulseMachine1Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // enableMdbChangerButton
            // 
            this.enableMdbChangerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enableMdbChangerButton.Location = new System.Drawing.Point(264, 30);
            this.enableMdbChangerButton.Margin = new System.Windows.Forms.Padding(5);
            this.enableMdbChangerButton.Name = "enableMdbChangerButton";
            this.enableMdbChangerButton.Size = new System.Drawing.Size(50, 15);
            this.enableMdbChangerButton.TabIndex = 3;
            this.enableMdbChangerButton.TabStop = true;
            this.enableMdbChangerButton.Text = "禁用";
            this.enableMdbChangerButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.enableMdbChangerButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.enableMdbChangerButton_LinkClicked);
            // 
            // mdbChangerLabel
            // 
            this.mdbChangerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdbChangerLabel.Location = new System.Drawing.Point(5, 30);
            this.mdbChangerLabel.Margin = new System.Windows.Forms.Padding(5);
            this.mdbChangerLabel.Name = "mdbChangerLabel";
            this.mdbChangerLabel.Size = new System.Drawing.Size(189, 15);
            this.mdbChangerLabel.TabIndex = 2;
            this.mdbChangerLabel.Text = "2) Mdb硬币器";
            this.mdbChangerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mdbNoteLabel
            // 
            this.mdbNoteLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdbNoteLabel.Location = new System.Drawing.Point(5, 5);
            this.mdbNoteLabel.Margin = new System.Windows.Forms.Padding(5);
            this.mdbNoteLabel.Name = "mdbNoteLabel";
            this.mdbNoteLabel.Size = new System.Drawing.Size(189, 15);
            this.mdbNoteLabel.TabIndex = 0;
            this.mdbNoteLabel.Text = "1) Mdb纸币器";
            this.mdbNoteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // enableMdbNoteButton
            // 
            this.enableMdbNoteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enableMdbNoteButton.Location = new System.Drawing.Point(264, 5);
            this.enableMdbNoteButton.Margin = new System.Windows.Forms.Padding(5);
            this.enableMdbNoteButton.Name = "enableMdbNoteButton";
            this.enableMdbNoteButton.Size = new System.Drawing.Size(50, 15);
            this.enableMdbNoteButton.TabIndex = 1;
            this.enableMdbNoteButton.TabStop = true;
            this.enableMdbNoteButton.Text = "禁用";
            this.enableMdbNoteButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.enableMdbNoteButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.enableMdbNoteButton_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(17, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "2. 收钱";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(17, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "3. 找钱";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(17, 256);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "4. 支付系统";
            // 
            // insertedMoneyLabel
            // 
            this.insertedMoneyLabel.AutoSize = true;
            this.insertedMoneyLabel.Font = new System.Drawing.Font("宋体", 12F);
            this.insertedMoneyLabel.ForeColor = System.Drawing.Color.Red;
            this.insertedMoneyLabel.Location = new System.Drawing.Point(34, 146);
            this.insertedMoneyLabel.Name = "insertedMoneyLabel";
            this.insertedMoneyLabel.Size = new System.Drawing.Size(104, 16);
            this.insertedMoneyLabel.TabIndex = 4;
            this.insertedMoneyLabel.Text = "500.00（元）";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.clearAllAlarmButton);
            this.tabPage2.Controls.Add(this.motorsControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1256, 617);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "销售";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // clearAllAlarmButton
            // 
            this.clearAllAlarmButton.AutoSize = true;
            this.clearAllAlarmButton.Location = new System.Drawing.Point(32, 407);
            this.clearAllAlarmButton.Name = "clearAllAlarmButton";
            this.clearAllAlarmButton.Size = new System.Drawing.Size(77, 12);
            this.clearAllAlarmButton.TabIndex = 1;
            this.clearAllAlarmButton.TabStop = true;
            this.clearAllAlarmButton.Text = "清除所有故障";
            this.clearAllAlarmButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.clearAllAlarmButton_LinkClicked);
            // 
            // motorsControl1
            // 
            this.motorsControl1.Location = new System.Drawing.Point(21, 26);
            this.motorsControl1.Name = "motorsControl1";
            this.motorsControl1.Size = new System.Drawing.Size(1000, 369);
            this.motorsControl1.TabIndex = 0;
            this.motorsControl1.Vendor = null;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comportButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1264, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // comportButton
            // 
            this.comportButton.Image = ((System.Drawing.Image)(resources.GetObject("comportButton.Image")));
            this.comportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.comportButton.Name = "comportButton";
            this.comportButton.Size = new System.Drawing.Size(85, 22);
            this.comportButton.Text = "设置串口";
            // 
            // uiUpdateTimer
            // 
            this.uiUpdateTimer.Enabled = true;
            this.uiUpdateTimer.Interval = 500;
            this.uiUpdateTimer.Tick += new System.EventHandler(this.uiUpdateTimer_Tick);
            // 
            // changeProgressTimer
            // 
            this.changeProgressTimer.Tick += new System.EventHandler(this.changeProgressTimer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 646);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // commStatusLabel
            // 
            this.commStatusLabel.Name = "commStatusLabel";
            this.commStatusLabel.Size = new System.Drawing.Size(56, 17);
            this.commStatusLabel.Text = "通讯正常";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 668);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Modbus协议功能演示";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label insertedMoneyLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.LinkLabel enablePulse2Button;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.LinkLabel enablePulse1Button;
        private System.Windows.Forms.Label pulseMachine1Label;
        private System.Windows.Forms.LinkLabel enableMdbChangerButton;
        private System.Windows.Forms.Label mdbChangerLabel;
        private System.Windows.Forms.Label mdbNoteLabel;
        private System.Windows.Forms.LinkLabel enableMdbNoteButton;
        private System.Windows.Forms.LinkLabel changeButton;
        private System.Windows.Forms.LinkLabel clearMoneyButton;
        private System.Windows.Forms.Label hopper2EnableLabel;
        private System.Windows.Forms.Label hopper1EnableLabel;
        private System.Windows.Forms.Label pulse2EnableLabel;
        private System.Windows.Forms.Label pulse1EanbelLabel;
        private System.Windows.Forms.Label mdbChangerEnableLabel;
        private System.Windows.Forms.Label mdbNoteEnableLabel;
        private System.Windows.Forms.Timer uiUpdateTimer;
        private System.Windows.Forms.Label restChangeLabel;
        private System.Windows.Forms.ProgressBar changeProgressBar;
        private System.Windows.Forms.Timer changeProgressTimer;
        private MotorsControl motorsControl1;
        private System.Windows.Forms.ToolStripDropDownButton comportButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel commStatusLabel;
        private System.Windows.Forms.LinkLabel clearAllAlarmButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label channelLabel;
    }
}

