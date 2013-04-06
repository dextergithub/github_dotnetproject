using KinectCore;
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
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinectAudioRecognition
{
    public partial class Form1 : Form
    {


        KinectAudio audio;

        int count = 1;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.RecognizerID) || GetRecognizer(Properties.Settings.Default.RecognizerID)==null)
            {
                new SettingBox().ShowDialog();
            }

            string RecognizerID = Properties.Settings.Default.RecognizerID;

            RecognizerInfo info = GetRecognizer(RecognizerID);

            if (info == null)
            {
                Log.log.WriteDebugLog("找不到对应的识别引擎id[{0}]".ExtFormat(Properties.Settings.Default.RecognizerID));
                MessageBox.Show("找不到对应的识别引擎id[{0}]".ExtFormat(Properties.Settings.Default.RecognizerID));
                return;
            }

            try
            {
                audio = new KinectAudio(info, Properties.Settings.Default.UsingKinect);
                audio.RecognitionEvent += audio_RecognitionEvent;

                this.com_Socket.DisplayMember = "key";
                this.com_Socket.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                Log.log.WriteErrLog("Form1_Load", ex,"");
                MessageBox.Show(ex.Message +"\n" +ex.StackTrace);
            }    
        }

        void audio_RecognitionEvent(byte[] buf, bool issuccess)
        {
            string txt = System.Text.Encoding.Default.GetString(buf);
            if (issuccess)
            {
                txt += " 已经成功向client 发送！\n";
            }
            else
            {
                txt += " 向client 发送 消息失败！\n";
            }           

            this.Invoke(new EventHandler(delegate {
                this.txt_log.AppendText(txt);
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KinectSocketClient sock = new KinectSocketClient();
            sock.GetMessage += sock_GetMessage;
            this.com_Socket.Items.Add(
                new SocketItem() { key = "Client" + this.com_Socket.Items.Count, Value = sock }
              );

        }

        void sock_GetMessage(Socket socket, byte[] msg)
        {
            Log.log.WriteDebugLog("Client _sock_GetMessage" + System.Text.Encoding.Default.GetString(msg));
            RequestItem item = RequestItem.Deserialize(msg);
            
            if (item != null)
                SetInfo(item, false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KinectSocketClient soc = ((this.com_Socket.SelectedItem) as SocketItem).Value;
            if (soc == null) return;

            if (string.IsNullOrEmpty(this.txt_command.Text)) return;

            RequestItem item = new RequestItem()
            {
                SrcSocket = soc.client,
                NO = count++,
                GrammarFile = this.com_grammar.Text,
                Commond = this.txt_command.Text
            };

            soc.SendMessage(item.Serializ());
            SetInfo(item, true);

        }

        delegate void delegate_setInfo(RequestItem item, bool issend);

        private void SetInfo(RequestItem item, bool issend)
        {
            if (this.txt_log.InvokeRequired)
            {
                var d = new delegate_setInfo(SetInfo);
                this.Invoke(d, item, issend);
            }
            else
            {
                String address = "";
                String port = "";
                if (item.SrcSocket != null)
                {
                    IPEndPoint ipEndPoint = (IPEndPoint)item.SrcSocket.RemoteEndPoint;
                    if (ipEndPoint != null)
                    {
                        address = ipEndPoint.Address.ToString();
                        port = ipEndPoint.Port.ToString();
                    }

                }

                this.txt_log.AppendText(
                    "{0},socket:{1},grammar:{2},command:{3},Confidence:{4},NO:{5},Recognized:{6}\n".ExtFormat(issend ? "发送请求" : "接收结果",
                    address + ":" + port,
                    item.GrammarFile,
                    item.Commond,
                    item.Confidence,
                    item.NO, item.Recognized)
                    );
            }
        }

        /// <summary>
        /// Gets the metadata for the speech recognizer (acoustic model) most suitable to
        /// process audio from Kinect device.
        /// </summary>
        /// <returns>
        /// RecognizerInfo if found, <code>null</code> otherwise.
        /// </returns>
        private static RecognizerInfo GetRecognizer(string RecognizerID)
        {
            Log.log.WriteDebugLog("GetKinectRecognizer——获取识别设备");
            foreach (RecognizerInfo recognizer in SpeechRecognitionEngine.InstalledRecognizers())
            {
                if (string.Compare(recognizer.Id, RecognizerID, true)==0)
                {
                    return recognizer;
                }
            }

            return null;
        }


    }

    public class SocketItem
    {
        public string key { get; set; }
        public KinectSocketClient Value { get; set; }
    }
}

