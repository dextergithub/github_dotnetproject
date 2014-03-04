namespace ModbusSample
{
    partial class MotorControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.outputButton = new System.Windows.Forms.LinkLabel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.warnLabel = new System.Windows.Forms.Label();
            this.outputProgressBar = new System.Windows.Forms.ProgressBar();
            this.progressTimer = new System.Windows.Forms.Timer(this.components);
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // outputButton
            // 
            this.outputButton.AutoSize = true;
            this.outputButton.Location = new System.Drawing.Point(118, 8);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(29, 12);
            this.outputButton.TabIndex = 10;
            this.outputButton.TabStop = true;
            this.outputButton.Text = "出货";
            this.outputButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.outputButton_LinkClicked);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(5, 8);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(5);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(23, 12);
            this.nameLabel.TabIndex = 9;
            this.nameLabel.Text = "72#";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // warnLabel
            // 
            this.warnLabel.Image = global::ModbusSample.Properties.Resources.WarningHS;
            this.warnLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.warnLabel.Location = new System.Drawing.Point(30, 3);
            this.warnLabel.Margin = new System.Windows.Forms.Padding(5);
            this.warnLabel.Name = "warnLabel";
            this.warnLabel.Size = new System.Drawing.Size(20, 18);
            this.warnLabel.TabIndex = 8;
            this.warnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // outputProgressBar
            // 
            this.outputProgressBar.Location = new System.Drawing.Point(32, 2);
            this.outputProgressBar.Name = "outputProgressBar";
            this.outputProgressBar.Size = new System.Drawing.Size(115, 23);
            this.outputProgressBar.TabIndex = 11;
            this.outputProgressBar.Visible = false;
            // 
            // progressTimer
            // 
            this.progressTimer.Tick += new System.EventHandler(this.progressTimer_Tick);
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 500;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // MotorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.warnLabel);
            this.Controls.Add(this.outputProgressBar);
            this.Name = "MotorControl";
            this.Size = new System.Drawing.Size(150, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel outputButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label warnLabel;
        private System.Windows.Forms.ProgressBar outputProgressBar;
        private System.Windows.Forms.Timer progressTimer;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
