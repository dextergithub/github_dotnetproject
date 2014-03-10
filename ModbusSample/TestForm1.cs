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
            int index=-1;
            Program.GetIndex("A",ref index);
            V.OutputGoods(index, (flag) =>
            {
                MessageBox.Show("出货A：{0},货道：{1}".ExtFormat(flag ? "成功" : "失败", ModbusSample.Properties.Settings.Default.AChannels));

            });

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (V == null) return;
            int index = -1;
            Program.GetIndex("B", ref index);
            V.OutputGoods(index, (flag) =>
            {
                MessageBox.Show("出货B：{0},货道：{1}".ExtFormat(flag ? "成功" : "失败", ModbusSample.Properties.Settings.Default.BChannels));
               
            });
        }
    }
}
