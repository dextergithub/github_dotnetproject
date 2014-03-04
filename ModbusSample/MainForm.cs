using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using ModbusSample.Properties;

namespace ModbusSample
{
    public partial class MainForm : Form
    {
        Vendor vendor = new Vendor();

        public MainForm()
        {
            InitializeComponent();
            InitComportSettingMenu();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            vendor.SetPortName(Settings.Default.ComName);
            motorsControl1.Vendor = vendor;
            vendor.ChangeRequest += VendorOnChangeRequest;
        }

        private void VendorOnChangeRequest(object sender, EventArgs eventArgs)
        {
            Action action = delegate
                                {
                                    MessageBox.Show("用户正在请求找零！");
                                    changeButton_LinkClicked(null, null);
                                };
            BeginInvoke(action);
        }

        /// <summary>
        /// 初始化串口设置菜单
        /// </summary>
        void InitComportSettingMenu()
        {
            comportButton.DropDownOpening += delegate(object sender, EventArgs args)
            {
                var portName = vendor.SerialPort.PortName;
                var menuItems = comportButton.DropDownItems.Cast<ToolStripMenuItem>().ToArray();
                Array.ForEach(menuItems, m => m.Checked = false);
                var menuItem = menuItems.FirstOrDefault(m => m.Text.ToLower() == portName.ToLower());
                if (menuItem != null)
                {
                    menuItem.Checked = true;
                }
            };

            for (int i = 0; i < 10; i++)
            {
                var portName = "COM" + (i + 1);
                var menuItem = new ToolStripMenuItem(portName);
                comportButton.DropDownItems.Add(menuItem);
                menuItem.Click += delegate
                {
                    if (!vendor.SetPortName(portName))
                    {
                        MessageBox.Show("打开串口错误!");
                    }
                    else
                    {
                        Settings.Default.ComName = vendor.SerialPort.PortName;
                        Settings.Default.Save();
                    }
                };
            }
        }


        /// <summary>
        /// 更新支付系统的可用性
        /// </summary>
        void UpdatePaymentEnable()
        {
            channelLabel.Text = string.Format("货道：{0} X {1}", vendor.ModbusData[1], vendor.ModbusData[2]);
            mdbChangerEnableLabel.Text = vendor.ModbusData[3] == 0 || vendor.ModbusData[Vendor.MdbChangerEanbleIndex] == 0 ? "×" : "√";
            mdbNoteEnableLabel.Text = vendor.ModbusData[6] == 0 || vendor.ModbusData[Vendor.MdbNoteEnableIndex] == 0 ? "×" : "√";
            hopper1EnableLabel.Text = vendor.ModbusData[9] == 0 ? "×" : "√";
            hopper2EnableLabel.Text = vendor.ModbusData[11] == 0 ? "×" : "√";
            pulse1EanbelLabel.Text = vendor.ModbusData[14] == 0 || vendor.ModbusData[Vendor.Pulse1EnableIndex] == 0 ? "×" : "√";
            pulse2EnableLabel.Text = vendor.ModbusData[15] == 0 || vendor.ModbusData[Vendor.Pulse2EanableIndex] == 0 ? "×" : "√";

            enableMdbNoteButton.Text = vendor.ModbusData[Vendor.MdbNoteEnableIndex] == 0 ? "启用" : "禁用";
            enableMdbChangerButton.Text = vendor.ModbusData[Vendor.MdbChangerEanbleIndex] == 0 ? "启用" : "禁用";
            enablePulse1Button.Text = vendor.ModbusData[Vendor.Pulse1EnableIndex] == 0 ? "启用" : "禁用";
            enablePulse2Button.Text = vendor.ModbusData[Vendor.Pulse2EanableIndex] == 0 ? "启用" : "禁用";
        }

        /// <summary>
        /// 更新收钱和找零的数量
        /// </summary>
        void UpdateMoney()
        {
            insertedMoneyLabel.Text = vendor.InsertedMoney.ToString("总收钱数：0.00（元）");
            restChangeLabel.Text = vendor.RestChange.ToString("剩余零钱：0.00（元）");
        }

        /// <summary>
        /// 更新用户界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiUpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdatePaymentEnable();
            UpdateMoney();
            commStatusLabel.Text = vendor.CommIsOk ? "通讯正常" : "通讯故障";
        }

        /// <summary>
        /// 清除收到的钱的数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearMoneyButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vendor.InsertedMoney = 0;
            uiUpdateTimer_Tick(null, null);
        }

        /// <summary>
        /// 禁用或启用Mdb纸币器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enableMdbNoteButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vendor.WriteModusData(Vendor.MdbNoteEnableIndex, vendor.ModbusData[Vendor.MdbNoteEnableIndex] == 0 ? 1 : 0);
        }

        /// <summary>
        /// 禁用或启用Mdb硬币器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enableMdbChangerButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vendor.WriteModusData(Vendor.MdbChangerEanbleIndex, vendor.ModbusData[Vendor.MdbChangerEanbleIndex] == 0 ? 1 : 0);
        }

        /// <summary>
        /// 禁用或启用1#脉冲收币器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enablePulse1Button_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vendor.WriteModusData(Vendor.Pulse1EnableIndex, vendor.ModbusData[Vendor.Pulse1EnableIndex] == 0 ? 1 : 0);

        }

        /// <summary>
        /// 禁用或启用2#脉冲收币器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enablePulse2Button_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vendor.WriteModusData(Vendor.Pulse2EanableIndex, vendor.ModbusData[Vendor.Pulse2EanableIndex] == 0 ? 1 : 0);
        }

        /// <summary>
        /// 进行找零工作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!vendor.CommIsOk)
            {
                MessageBox.Show("目前系统通讯故障，不能进行找零。");
                return;
            }

            if (vendor.ModbusData[Vendor.ChangeIsBusyIndex] != 0)
            {
                MessageBox.Show("上次找零还未完成，请稍候。");
                return;
            }

            if (vendor.RestChange < (decimal)30.0)
            {
                MessageBox.Show("找零器中剩余的零钱数过少，找零可能会失败！");
            }

            double change = 0;
            var changeText = InputBox.ShowInputBox("输入要找的零钱数", "", "10");
            if (!double.TryParse(changeText, out change)) return;
            if (change <= 0) return;

            vendor.Change(change, OnChangeFinish);
            changeProgressBar.Value = 0;
            changeProgressBar.Visible = true;
            changeProgressTimer.Enabled = true;
        }

        /// <summary>
        /// 在找零结束后的回调函数
        /// </summary>
        /// <param name="change"></param>
        private void OnChangeFinish(double change)
        {
            Invoke((Action)delegate
            {
                changeProgressBar.Visible = false;
                changeProgressTimer.Enabled = false;
                MessageBox.Show(string.Format("找零完成，共找零{0}元。", change / 100));
            });
        }

        /// <summary>
        /// 显示找零进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeProgressTimer_Tick(object sender, EventArgs e)
        {
            int value = changeProgressBar.Value + 10;
            if (value > changeProgressBar.Maximum)
            {
                value = changeProgressBar.Minimum;
            }
            changeProgressBar.Value = value;
        }

        /// <summary>
        /// 清除所有故障代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearAllAlarmButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vendor.WriteModusData(43, 1);
            vendor.RefreshModbusData(300, 100);
        }
    }
}
