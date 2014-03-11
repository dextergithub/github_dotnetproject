using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseCommon;

namespace ModbusSample
{
    public partial class TestForm1 : Form
    {

        public Vendor V = null;
        public TestForm1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (V == null) return;
            int index = -1;
            if (!Program.GetIndex("A", ref index))
            {

                return;
            }
            V.OutputGoods(index, (flag) =>
            {
                MessageBox.Show("出货A：{0},货道：{1}".ExtFormat(flag ? "成功" : "失败", ""));

            });

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (V == null) return;
            int index = -1;
            if (!Program.GetIndex("B", ref index))
            {
                return;
            }

            V.OutputGoods(index, (flag) =>
            {
                MessageBox.Show("出货B：{0},货道：{1}".ExtFormat(flag ? "成功" : "失败", ""));

            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VEMConfigHelper config = VEMConfigHelper.Create();
            config.AChannelEnd = (int)this.Achannelend.Value;
            config.AChannelStart = (int)this.Achannelstart.Value;
            config.ACurrent = (int)this.Acurrent.Value;
            config.APerChannel = (int)this.Aperchannel.Value;

            config.BChannelEnd = (int)this.Bchannelend.Value;
            config.BChannelStart = (int)this.Bchannelstart.Value;
            config.BCurrent = (int)this.Bcurrent.Value;
            config.BPerChannel = (int)this.Bperchannel.Value;
            config.Port = port.Text;
            config.Save();
            MessageBox.Show("保存成功！");

        }

        private void TestForm1_Load(object sender, EventArgs e)
        {
            VEMConfigHelper config = VEMConfigHelper.Create();
            this.Achannelend.Value = config.AChannelEnd;
            this.Achannelstart.Value = config.AChannelStart;
            this.Acurrent.Value = config.ACurrent;
            this.Aperchannel.Value = config.APerChannel;

            this.Bchannelend.Value = config.BChannelEnd;
            this.Bchannelstart.Value = config.BChannelStart;
            this.Bcurrent.Value = config.BCurrent;
            this.Bperchannel.Value = config.BPerChannel;
            this.port.Text = config.Port;
        }
    }
}
