namespace FaceTrackingBasics_WinFrom
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
            this.faceTrackingViewer = new FaceTrackingBasics_WinFrom.FaceTrackingViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // faceTrackingViewer
            // 
            this.faceTrackingViewer.BackColor = System.Drawing.Color.White;
            this.faceTrackingViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.faceTrackingViewer.Kinect = null;
            this.faceTrackingViewer.Location = new System.Drawing.Point(12, 12);
            this.faceTrackingViewer.Name = "faceTrackingViewer";
            this.faceTrackingViewer.Size = new System.Drawing.Size(686, 531);
            this.faceTrackingViewer.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(13, 550);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "离Kinect 稍微远一点。晃动一下脸";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 594);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.faceTrackingViewer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FaceTrackingViewer faceTrackingViewer;
        private System.Windows.Forms.Label label1;
    }
}

