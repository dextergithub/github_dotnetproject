using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Download by http://www.codefans.net
namespace QQAutoSend
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }

        private void RegForm_Load(object sender, EventArgs e)
        {
            this.txtMachineKey.Text = QQREG.MachineKey;
            //this.richTextBox1.Text = "1、注册付费10元，源代码付费30元，联系QQ:470130547";
            //this.richTextBox2.Text = "2、注册付费10元，源代码付费30元，联系QQ:470130547";
        }

        private void btReg_Click(object sender, EventArgs e)
        {
            string lickey = this.txtRegKey.Text;
            if (lickey.Equals(String.Empty))
            {
                MessageBox.Show("请输入序列号"); return;
            }

            if (QQREG.AnalysisLicense(lickey).Equals(this.txtMachineKey.Text))
            {
                Regedit.LicenseKey = lickey; 
                MessageBox.Show("注册成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("注册失败");
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

       
    }
}