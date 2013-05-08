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
                FontFamily f = new FontFamily("宋体");

                for (int i = 0; i < 200; i++)
                {
                    Bitmap tmp = new Bitmap(bp);
                    Image img = wm.Mark(tmp, MarkType.Text, string.Format("{0},{1}", i, (int)(i / 24)), tmp, 150, 150, true, Color.Red, 0F, f);
                    img.Save("./demo/" + i + ".jpg");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {



                OpenFileDialog dig = new OpenFileDialog();
                dig.Multiselect = true;
                dig.Filter = "图片|*.jpg;*.png;*.gif";
                // generates a little slide-show, with audio track and fades between images.
                if (dig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    string[] files = dig.FileNames;
                    double fr = this.fps.Value;
                    RunBuilder(dig.FileNames, this.fps.Value);
                    MessageBox.Show("Completed");


                }



            }
            catch (Exception ex)
            {
                throw ex;

            }

        }



        private void RunBuilder(string[] files, double fr)
        {


            #region v1
            // generates a little slide-show, with audio track and fades between images.
            string path = Properties.Settings.Default.OutPut;
            if (string.IsNullOrEmpty(path))
            {
                path = AppDomain.CurrentDomain.BaseDirectory;
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string outputFile = path + "\\demo" + DateTime.Now.ToString("yyyyMMdd") + ".wmv";

            double fps = ((double)1) / Convert.ToDouble(fr);

            using (ITimeline timeline = new DefaultTimeline())
            {
                Bitmap top = new Bitmap(files[0]);

                IGroup group = timeline.AddVideoGroup(32, top.Width, top.Height);

                ITrack videoTrack = group.AddTrack();


                // IOrderedEnumerable<FileInfo> enumerable = JPGfilesCopy.OrderBy(f => f.CreationTime);

                foreach (string f in files)
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
            // });

            //t.Start();
            // return t;
        }

    }
}

