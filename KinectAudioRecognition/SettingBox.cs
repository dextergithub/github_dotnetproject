#if KINECTSDK 
using Microsoft.Speech.AudioFormat;
using Microsoft.Speech.Recognition;
#else
using System.Speech.AudioFormat;
using System.Speech.Recognition;
#endif
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KinectAudioRecognition
{
   
    public partial class SettingBox : Form
    {
        public SettingBox()
        {
            InitializeComponent();
        }

        

        private void SettingBox_Load(object sender, EventArgs e)
        {
           
            this.comboBox1.DataSource = SpeechRecognitionEngine.InstalledRecognizers();
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Id";

            if (!string.IsNullOrEmpty(Properties.Settings.Default.RecognizerID))
            {
                this.comboBox1.SelectedValue = Properties.Settings.Default.RecognizerID;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( this.comboBox1.SelectedItem== null )
            {
                MessageBox.Show("请选择识别引擎名称！");
                return;
            }
            Properties.Settings.Default.RecognizerID = this.comboBox1.SelectedValue.ToString();
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
