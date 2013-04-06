using Microsoft.Kinect;
using Microsoft.Speech.AudioFormat;
using Microsoft.Speech.Recognition;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectCore
{
    public class KinectAudio
    {
        /// <summary>
        /// 体感器
        /// </summary>
        private KinectSensor sensor = null;
        /// <summary>
        /// 语音识别引擎
        /// </summary>
        private SpeechRecognitionEngine speechEngine = null;
        /// <summary>
        /// 识别队列
        /// </summary>
        private Queue<RequestItem> queue = new Queue<RequestItem>();
        /// <summary>
        /// Socket
        /// </summary>
        KinectSocketServer SocketServer;
        /// <summary>
        /// 当前要处理的请求
        /// </summary>
        private RequestItem CurrentItem;
        /// <summary>
        /// 添加队列
        /// </summary>
        /// <param name="item"></param>
        public void AddRequest(RequestItem item)
        {
            Log.log.WriteDebugLog("开始 添加请求，加入队列");
            this.queue.Enqueue(item);
            if (this.CurrentItem == null)
                this.CurrentItem = FetchNext();
            Log.log.WriteDebugLog("完成 添加请求，加入队列");
        }

        private void InitDefaultRecognizer()
        {

        }
        /// <summary>
        /// 初始化 
        /// </summary>
        private void InitKinect()
        {
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.sensor = potentialSensor;
                    break;
                }
            }

            if (null != this.sensor)
            {
                try
                {
                    // Start the sensor!
                    this.sensor.Start();
                }
                catch (IOException)
                {
                    // Some other application is streaming from the same Kinect sensor
                    this.sensor = null;
                }
            }

            if (null == this.sensor)
            {
                throw new Exception(Properties.Resources.NoKinectReady);
            }

            RecognizerInfo ri = GetKinectRecognizer();

            if (null != ri)
            {
                this.speechEngine = new SpeechRecognitionEngine(ri.Id);
                // this.speechEngine.LoadGrammarCompleted += speechEngine_LoadGrammarCompleted;

                using (var memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(Properties.Resources.SpeechGrammar)))
                {
                    var g = new Grammar(memoryStream);
                    speechEngine.LoadGrammar(g);
                }

                speechEngine.SpeechRecognized += SpeechRecognized;
                speechEngine.SpeechRecognitionRejected += SpeechRejected;

                speechEngine.SetInputToAudioStream(
                    sensor.AudioSource.Start(), new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
                speechEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
            else
            {
                throw new Exception(Properties.Resources.NoSpeechRecognizer);
            }

        }


        public KinectAudio()
        {
            InitKinect();

            this.SocketServer = new KinectSocketServer();
            this.SocketServer.GetMessage += SocketServer_GetMessage;
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="msg"></param>
        void SocketServer_GetMessage(System.Net.Sockets.Socket socket, byte[] msg)
        {
            try
            {
                Log.log.WriteDebugLog("SocketServer_GetMessage_接收消息");
                RequestItem item = RequestItem.Deserialize(msg);
                if (item == null) return;
                item.SrcSocket = socket;
                this.AddRequest(item);
                Log.log.WriteDebugLog("SocketServer_GetMessage_添加队列");
            }
            catch (Exception ex)
            {
                Log.log.Error("SocketServer_GetMessage," + ex.Message, ex);
            }
        }
        /// <summary>
        /// 加载语法
        /// </summary>
        /// <param name="filekey"></param>
        private  void LoadGrammar(string filekey)
        {
            Log.log.WriteDebugLog("开始加载语法文件");
            string file = System.Configuration.ConfigurationManager.AppSettings[filekey];
            if (string.IsNullOrEmpty(file))
            {
                throw new Exception("没有找到[{0}]配置或者配置为空".ExtFormat(filekey));
            }

            if (!Path.IsPathRooted(file))
            {
                file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
            }

            if (!File.Exists(file))
            {
                throw new Exception("文件[{0}]不存在".ExtFormat(file));
            }

            if (this.speechEngine == null)
            {
                throw new Exception("语音识别引擎没有被初始化");
            }

            try
            {
                this.speechEngine.UnloadAllGrammars();
                Grammar g = new Grammar(file);
                this.speechEngine.LoadGrammar(g);
                Log.log.WriteDebugLog("完成语法文件加载....");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SpeechRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            if (CurrentItem == null) return;

            this.CurrentItem.Recognized = e.Result.Text;
            if (!string.IsNullOrEmpty(e.Result.Text))
            {
                Log.log.WriteDebugLog("SpeechRejected——识别到一个");
                if (string.Compare(this.CurrentItem.Commond, e.Result.Text, true) == 0)
                {
                    this.CurrentItem.Confidence = (int)e.Result.Confidence * 100;
                }
                else
                {
                    this.CurrentItem.Confidence = 0;
                }

                if (this.CurrentItem.SrcSocket != null && this.CurrentItem.SrcSocket.Connected)
                {
                    this.CurrentItem.SrcSocket.Send(this.CurrentItem.Serializ());
                }

                this.CurrentItem = FetchNext();

            }
        }
        /// <summary>
        /// 进入下一条
        /// </summary>
        /// <returns></returns>
        private RequestItem FetchNext()
        {
            if (this.queue.Count == 0) return null;
            RequestItem item = null;

            try
            {
                Log.log.WriteDebugLog("开始读取下一条");
                item = this.queue.Dequeue();
                LoadGrammar(item.GrammarFile);
                Log.log.WriteDebugLog("成功读取下一条");
            }
            catch (Exception ex)
            {
                Log.log.Error("FetchNext" + ex.Message, ex);
            }

            return item;
        }

        private void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (CurrentItem == null) return;

            if (!string.IsNullOrEmpty(e.Result.Text))
            {
                Log.log.WriteDebugLog("SpeechRecognized——识别到一个");

                this.CurrentItem.Recognized = e.Result.Text;

                if (string.Compare(this.CurrentItem.Commond, e.Result.Text, true) == 0)
                {
                    this.CurrentItem.Confidence = (int)(e.Result.Confidence * 100);
                }
                else
                {
                    this.CurrentItem.Confidence = 0;
                }

                if (this.CurrentItem.SrcSocket != null && this.CurrentItem.SrcSocket.Connected)
                {
                    this.CurrentItem.SrcSocket.Send(this.CurrentItem.Serializ());
                }

                this.CurrentItem = FetchNext();

            }
        }


        /// <summary>
        /// Gets the metadata for the speech recognizer (acoustic model) most suitable to
        /// process audio from Kinect device.
        /// </summary>
        /// <returns>
        /// RecognizerInfo if found, <code>null</code> otherwise.
        /// </returns>
        private static RecognizerInfo GetKinectRecognizer()
        {
            Log.log.WriteDebugLog("GetKinectRecognizer——获取识别设备");
            foreach (RecognizerInfo recognizer in SpeechRecognitionEngine.InstalledRecognizers())
            {
                string value;
                recognizer.AdditionalInfo.TryGetValue("Kinect", out value);

                if ("True".Equals(value, StringComparison.OrdinalIgnoreCase) && "en-US".Equals(recognizer.Culture.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return recognizer;
                }
            }

            return null;
        }


    }
}
