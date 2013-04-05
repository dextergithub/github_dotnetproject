using Common;
using Splicer.Renderer;
using Splicer.Timeline;
using Splicer.WindowsMedia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pic2Vedio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WaterMark wm = new WaterMark();
            FileInfo basfile = new FileInfo("./demo/1 (1).jpg");


            if (basfile != null)
            {
                Bitmap bp = new Bitmap(basfile.FullName);
                FontFamily f=new FontFamily("宋体");
                
                for (int i = 0; i <200; i++)
                {
                    Bitmap tmp = new Bitmap(bp);                  
                   Image img = wm.Mark(tmp, MarkType.Text, string.Format( "{0},{1}",i,(int) (i/24)), tmp, 150, 150, true, Color.Red, 0F, f);
                   img.Save("./demo/" + i + ".jpg");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Multiselect = true;
            dig.Filter = "图片|*.jpg;*.png;*.gif";
            // generates a little slide-show, with audio track and fades between images.
            if(dig.ShowDialog()== System.Windows.Forms.DialogResult.OK )
            {

                RunBuilder(dig.FileNames, this.fps.Value).ContinueWith((r) =>
                {
                MessageBox.Show("Test");
            });

            }
            #region old version
            /*
            string outputFile = "FadeBetweenImages.wmv";



            using (ITimeline timeline = new DefaultTimeline())
            {

                IGroup group = timeline.AddVideoGroup(32, 2560, 1920);

                //timeline
                double halfDuration = 0.5;

                ITrack videoTrack = group.AddTrack();

                // IClip clip1 = videoTrack.AddImage("image1.jpg", 0, 2); // play first image for a little while
                System.IO.DirectoryInfo dirinfo = new System.IO.DirectoryInfo("./demo/");
                int idx = 0;
                if (dirinfo != null)
                {
                    FileInfo[] files = dirinfo.GetFiles("*.jpg");
                    foreach (var item in files)
                    {
                        //System.Drawing.Bitmap b = new Bitmap(item.FullName);
                        IClip clip1 = videoTrack.AddImage(item.FullName, idx++ * 1, idx * 1);
                        group.AddTransition(clip1.Offset - halfDuration, halfDuration, StandardTransitions.CreateFade(), true);

                        group.AddTransition(clip1.Offset, halfDuration, StandardTransitions.CreateFade(), false);
                    }
                }

                //IClip clip2 = videoTrack.AddImage("image2.jpg", 0, 2); // and the next

                //IClip clip3 = videoTrack.AddImage("image3.jpg", 0, 2); // and finally the last

                //IClip clip4 = videoTrack.AddImage("image4.jpg", 0, 2); // and finally the last



                //double halfDuration = 0.5;



                //// fade out and back in

                //group.AddTransition(clip2.Offset - halfDuration, halfDuration, StandardTransitions.CreateFade(), true);

                //group.AddTransition(clip2.Offset, halfDuration, StandardTransitions.CreateFade(), false);



                //// again

                //group.AddTransition(clip3.Offset - halfDuration, halfDuration, StandardTransitions.CreateFade(), true);

                //group.AddTransition(clip3.Offset, halfDuration, StandardTransitions.CreateFade(), false);



                //// and again

                //group.AddTransition(clip4.Offset - halfDuration, halfDuration, StandardTransitions.CreateFade(), true);

                //group.AddTransition(clip4.Offset, halfDuration, StandardTransitions.CreateFade(), false);



                // add some audio

                ITrack audioTrack = timeline.AddAudioGroup().AddTrack();



                // IClip audio = audioTrack.AddAudio("testinput.wav", 0, videoTrack.Duration);



                //// create an audio envelope effect, this will:

                //// fade the audio from 0% to 100% in 1 second.

                //// play at full volume until 1 second before the end of the track

                //// fade back out to 0% volume

                //audioTrack.AddEffect(0, audio.Duration,

                //               StandardEffects.CreateAudioEnvelope(1.0, 1.0, 1.0, audio.Duration));



                // render our slideshow out to a windows media file

                //using (

                IRenderer renderer =

                   new WindowsMediaRenderer(timeline, outputFile, WindowsMediaProfiles.HighQualityVideo);
                {

                    renderer.Render();

                }
              }
            */
            #endregion

           
            

        }

        private Task RunBuilder(string[] files,double fr )
        {
            return Task.Run(() => {

                #region v1
                // generates a little slide-show, with audio track and fades between images.

                string outputFile = "demo"+ DateTime.Now.ToString("yyyyMMdd")+".wmv";

                double fps =  ((double)1) / Convert.ToDouble(fr);

                using (ITimeline timeline = new DefaultTimeline())
                {
                    Bitmap top = new Bitmap(files[0]);

                    IGroup group = timeline.AddVideoGroup(32, top.Width, top.Height);

                    ITrack videoTrack = group.AddTrack();


                   // IOrderedEnumerable<FileInfo> enumerable = JPGfilesCopy.OrderBy(f => f.CreationTime);

                    foreach (string  f in files)
                    {
                        //listBox1.Items.Add(f.FullName);
                        IClip k = videoTrack.AddImage(f, 0, fps);

                    }

                    // add some audio

                    ITrack audioTrack = timeline.AddAudioGroup().AddTrack();
                    //ITrack audioTrack = timeline.AddAudioGroup().AddTrack();

                    //IClip audio = audioTrack.AddAudio(@textBox1.Text, 0, videoTrack.Duration);

                    // render our slideshow out to a windows media file
                    //string path = Environment.GetFolderPath(Environment.SpecialFolder.Programs);

                    using (WindowsMediaRenderer renderer = new WindowsMediaRenderer(timeline, outputFile, WindowsMediaProfiles.HighQualityVideo))
                    {
                        renderer.Render();

                    }
                   
                    //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    // axWindowsMediaPlayer1.URL = @"C:\Users\dell\Documents\My Dropbox\Deema\Deema\bin\Release\" + outputFile;

                }
                #endregion
            });
        }

    }
}

