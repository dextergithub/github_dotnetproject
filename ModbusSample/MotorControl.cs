using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModbusSample
{
    public partial class MotorControl : UserControl
    {
        public MotorControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            updateTimer_Tick(null,null);
        }

        /// <summary>
        /// 读取或设置电机索引号
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 读取或设置Vendor对象
        /// </summary>
        public Vendor Vendor { get; set; }

        /// <summary>
        /// 定时更新界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (Index < 0 || Index >= 72) return;
            if (Vendor == null) return;

            UpdateUi();
        }

        /// <summary>
        /// 更新界面
        /// </summary>
        private void UpdateUi()
        {
            nameLabel.Text = string.Format("{0}#", Index + 1);
            warnLabel.Visible = Vendor.ModbusData[300 + Index] != 0;
            toolTip1.SetToolTip(warnLabel, FormatWarnMessage((int)Vendor.ModbusData[300 + Index]));
            progressTimer.Enabled = Vendor.ModbusData[Vendor.CurrRunningMotorIndex] == Index;
            outputProgressBar.Visible = Vendor.ModbusData[Vendor.CurrRunningMotorIndex] == Index;
            outputButton.Visible = !outputProgressBar.Visible;
        }

        //0表示正常，1-电机反馈线异常 2-电机欠流 3-电机过流
        private string FormatWarnMessage(int alarmCode)
        {
            var alarmMessage = new string[] { "正常", "电机反馈线异常", "电机欠流", "电机过流" };
            if (alarmCode >= 0 && alarmCode < alarmMessage.Length)
                return alarmMessage[alarmCode];
            return "未知的故障";
        }

        /// <summary>
        /// 更新出货进度条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void progressTimer_Tick(object sender, EventArgs e)
        {
            int value = outputProgressBar.Value + 10;
            if (value > outputProgressBar.Maximum)
            {
                value = outputProgressBar.Minimum;
            }
            outputProgressBar.Value = value;
        }

        /// <summary>
        /// 执行出任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void outputButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Vendor.CommIsOk)
            {
                MessageBox.Show("目前系统通讯故障，不能进行找零。");
                return;
            }
            if (Vendor.ModbusData[Vendor.CurrRunningMotorIndex] != 255)
            {
                MessageBox.Show("上一次出货任务还未完成，请稍候。");
                return;
            }
            Vendor.OutputGoods(Index, OnOutputFinnish);
        }

        /// <summary>
        /// 出货完成后的回调函数
        /// </summary>
        /// <param name="isSuccess"></param>
        private void OnOutputFinnish(bool isSuccess)
        {
            Invoke((Action)delegate
            {
                var message = string.Format("出货{0}", isSuccess ? "成功" : "失败");
                MessageBox.Show(message);
            });
        }
    }
}
