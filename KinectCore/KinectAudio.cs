using Microsoft.Kinect;
#if KINECTSDK 
using Microsoft.Speech.AudioFormat;
using Microsoft.Speech.Recognition;
#else
using System.Speech.AudioFormat;
using System.Speech.Recognition;
#endif
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

        public delegate void RecognitionEventHandler(byte[] buf, bool issuccess);
        public event RecognitionEventHandler RecognitionEvent;

        ///// <summary>
        ///// 体感器
        ///// </summary>
        //private KinectSensor sensor = null;

        /// <summary>
        /// 语音识别信息
        /// </summary>
        RecognizerInfo RecognizerInfo { get; set; }

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



        /// <summary>
        /// 初始化 
        /// </summary>
        private void InitRecognizer(RecognizerInfo defaultRecognizerInfo,bool usingkinect)
        {

            //RecognizerInfo ri = defaultRecognizerInfo== null ? GetKinectRecognizer():defaultRecognizerInfo;

            if (null != defaultRecognizerInfo)
            {
                this.speechEngine = new SpeechRecognitionEngine(defaultRecognizerInfo.Id);
                // this.speechEngine.LoadGrammarCompleted += speechEngine_LoadGrammarCompleted;

#if(KINECTSDK)
                using (var memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(Properties.Resources.SpeechGrammar)))
                {
                    var g = new Grammar(memoryStream);
                    speechEngine.LoadGrammar(g);
                }
#else  
                speechEngine.LoadGrammar(new DictationGrammar());
#endif

                speechEngine.SpeechRecognized += SpeechRecognized;
                speechEngine.SpeechRecognitionRejected += SpeechRejected;
                if (usingkinect)
                {
                    KinectSensor sensor = GetKinectSensor();

                    speechEngine.SetInputToAudioStream(

                        sensor.AudioSource.Start(),

                        new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
                }
                else
                {
                    speechEngine.SetInputToDefaultAudioDevice();
                   // AudioFormat = new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null);
                }
                speechEngine.RecognizeAsync(RecognizeMode.Multiple );
            }
            else
            {
                throw new Exception(Properties.Resources.NoSpeechRecognizer);
            }

        }

        private bool IsKinect()
        {
            string value;
            this.RecognizerInfo.AdditionalInfo.TryGetValue("Kinect", out value);

            if ("True".Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;

        }

        private KinectSensor GetKinectSensor()
        {
            KinectSensor sensor = null;
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    sensor = potentialSensor;
                    break;
                }
            }

            if (null != sensor)
            {
                try
                {
                    // Start the sensor!
                    sensor.Start();
                }
                catch (IOException)
                {
                    // Some other application is streaming from the same Kinect sensor
                    sensor = null;
                }
            }

            if (null == sensor)
            {
                throw new Exception(Properties.Resources.NoKinectReady);
            }

            return sensor;

        }


        public KinectAudio(RecognizerInfo defaultRecognizerInfo, bool usingkinect)
        {
            this.RecognitionEvent += (a, b) => { };
            this.RecognizerInfo = defaultRecognizerInfo;
            InitRecognizer(this.RecognizerInfo, usingkinect);

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
        private void LoadGrammar(string filekey)
        {
            Log.log.WriteDebugLog("开始加载语法文件");
            string file = System.Configuration.ConfigurationManager.AppSettings[filekey];
            if (filekey != "DictationGrammar ")
            {               
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
            }
            try
            {
                this.speechEngine.UnloadAllGrammars();
#if ! KINECTSDK
                if (filekey == "DictationGrammar")
                {
                    System.Speech.Recognition.DictationGrammar customDictationGrammar = new System.Speech.Recognition.DictationGrammar();
                    customDictationGrammar.Name = "Dictation";
                    customDictationGrammar.Enabled = true;
                    //System.Speech.Recognition.DictationGrammar g = new System.Speech.Recognition.DictationGrammar();
                    //System.Speech.Recognition.DictationGrammar.LoadLocalizedGrammarFromType(
                   this.speechEngine.LoadGrammar(customDictationGrammar);
                }
                else
#endif
                {
                    Log.log.WriteDebugLog("加载语法文件——"+file);
                    Grammar g = new Grammar(file);
                    this.speechEngine.LoadGrammar(g);
                }
                Log.log.WriteDebugLog("完成语法文件加载....");
            }
            catch (Exception)
            {

                throw;
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

                this.CurrentItem.Confidence = (int)(e.Result.Confidence * 100);

                if (this.CurrentItem.SrcSocket != null && this.CurrentItem.SrcSocket.Connected)
                {
                    this.CurrentItem.SrcSocket.Send(this.CurrentItem.SerializResult());

                    this.RecognitionEvent(this.CurrentItem.SerializResult(), true);
                }
                else
                {
                    this.RecognitionEvent(this.CurrentItem.SerializResult(), false);
                }

                this.CurrentItem = FetchNext();

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
                    this.CurrentItem.SrcSocket.Send(this.CurrentItem.SerializResult());
                    this.RecognitionEvent(this.CurrentItem.SerializResult(), true);
                }
                else
                {
                    this.RecognitionEvent(this.CurrentItem.SerializResult(), false);
                }
                this.CurrentItem = FetchNext();

            }
        }     
    }
}
