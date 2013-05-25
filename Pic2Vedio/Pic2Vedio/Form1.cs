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
using System.Xml;
using System.Xml.Linq;

namespace Pic2Vedio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MonitorFile();
        }


        private void RunBuilder(string[] files, string outputFile)
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

            //string outputFile = path + "\\demo" + DateTime.Now.ToString("yyyyMMdd") + ".wmv";

            double fps = ((double)1) / Convert.ToDouble(Pic2Vedio.Properties.Settings.Default.DefaultRate);

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


        private void MonitorFile()
        {
            if (string.IsNullOrEmpty(Pic2Vedio.Properties.Settings.Default.MonitorFile))
            {
                return;
            }

            FileInfo file = new FileInfo(Properties.Settings.Default.MonitorFile);
            if (file != null)
            {
                FileSystemWatcher watcher = new FileSystemWatcher(file.DirectoryName, "*.xml");
                watcher.Changed += watcher_Changed;
                watcher.WaitForChanged(WatcherChangeTypes.Changed);
            }

        }

        void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.ChangeType == WatcherChangeTypes.Changed && string.Compare(e.FullPath, Properties.Settings.Default.MonitorFile, true) == 0)
            {
                HandlerFile();
            }
            FileSystemWatcher t = sender as FileSystemWatcher;
            if (t != null)
            {
                Task.Factory.StartNew(() => { t.WaitForChanged(WatcherChangeTypes.Changed); });

            }
        }

        void HandlerFile()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Properties.Settings.Default.MonitorFile);
            foreach (XmlNode item in doc.SelectNodes("//root/data/AllImage"))
            {
                try
                {
                    HandleNode(item);
                }
                catch (Exception ex)
                {
                    File.AppendAllText("./" + DateTime.Now.ToString("yyyy-mm-dd") + ".txt", ex.Message + ex.StackTrace);
                }

            }

        }

        void HandleNode(XmlNode e)
        {
            string root = "";
            string outfile = "";

            List<string> image = new List<string>();
            foreach (XmlNode item in e.SelectNodes("./bigImage/@path"))
            {

                FileInfo f = new FileInfo(item.Value);
                if (f.Exists)
                {
                    if (string.IsNullOrEmpty(root))
                    {
                        root = f.Directory.Name;
                        outfile = f.DirectoryName + "\\" + root + ".wmv";
                        if (File.Exists(outfile))
                        {
                            break;
                        }
                    }
                    image.Add(item.Value);
                }
            }
            if (image.Count > 0)
            {
                RunBuilder(image.ToArray(), outfile);
            }
        }


    }
}

