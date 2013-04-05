using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeechRecognition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SpeechRecognitionEngine speechEngine;
        private void Form1_Load(object sender, EventArgs e)
        {
            RecognizerInfo recognizer = GetKinectRecognizer();

            if (recognizer == null) return;
            this.speechEngine = new SpeechRecognitionEngine(recognizer.Id);

            Grammar dictation = new DictationGrammar();
            dictation.Name = "Dictation Grammar";

            speechEngine.LoadGrammar(dictation);

            speechEngine.SpeechRecognized += SpeechRecognized;
            speechEngine.SpeechRecognitionRejected += SpeechRejected;
            //RecognizedAudio audio = new System.Speech.Recognition.RecognizedAudio();

          //  speechEngine.SetInputToAudioStream( 
            //       new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
            speechEngine.SetInputToDefaultAudioDevice();

            speechEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void SpeechRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            this.textBox1.AppendText(e.Result.Text+"\n");
        }

        private void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            this.textBox1.AppendText(e.Result.Text + "\n");
        }

       

        // <summary>
        /// Gets the metadata for the speech recognizer (acoustic model) most suitable to
        /// process audio from Kinect device.
        /// </summary>
        /// <returns>
        /// RecognizerInfo if found, <code>null</code> otherwise.
        /// </returns>
        private static RecognizerInfo GetKinectRecognizer()
        {
            foreach (RecognizerInfo recognizer in SpeechRecognitionEngine.InstalledRecognizers())
            {
                //string value;
               // recognizer.AdditionalInfo.TryGetValue("Kinect", out value);
                //"True".Equals(value, StringComparison.OrdinalIgnoreCase) &&
                if ( "zh-cn".Equals(recognizer.Culture.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return recognizer;
                }
            }

            return null;
        }

    }
}
