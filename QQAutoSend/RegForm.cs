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
            //this.richTextBox1.Text = "1��ע�Ḷ��10Ԫ��Դ���븶��30Ԫ����ϵQQ:470130547";
            //this.richTextBox2.Text = "2��ע�Ḷ��10Ԫ��Դ���븶��30Ԫ����ϵQQ:470130547";
        }

        private void btReg_Click(object sender, EventArgs e)
        {
            string lickey = this.txtRegKey.Text;
            if (lickey.Equals(String.Empty))
            {
                MessageBox.Show("���������к�"); return;
            }

            if (QQREG.AnalysisLicense(lickey).Equals(this.txtMachineKey.Text))
            {
                Regedit.LicenseKey = lickey; 
                MessageBox.Show("ע��ɹ�");
                this.Close();
            }
            else
            {
                MessageBox.Show("ע��ʧ��");
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

       
    }
}