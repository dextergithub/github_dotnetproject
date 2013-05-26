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



        }

        Task TB = null;

        private void RunBuilder(Image[] files, string outputFile)
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

                foreach (Image f in files)
                {
                    //listBox1.Items.Add(f.FullName);
                    IClip k = videoTrack.AddImage(f, 0, fps);

                }

                // add some audio

                ITrack audioTrack = timeline.AddAudioGroup().AddTrack();
                try
                {
                    using (WindowsMediaRenderer renderer = new WindowsMediaRenderer(timeline, outputFile, WindowsMediaProfiles.HighQualityVideo))
                    {
                        renderer.Render();

                    }
                }
                catch (Exception ex)
                {

                    File.AppendAllText("./" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", ex.Message + ex.StackTrace);
                }
            }
            #endregion

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
            string mfile = Properties.Settings.Default.MonitorFile;
            if (e.ChangeType == WatcherChangeTypes.Changed && string.Compare(e.FullPath, mfile, true) == 0)
            {
                HandlerFile();
            }
            FileSystemWatcher t = sender as FileSystemWatcher;
            if (t != null)
            {
                // Task.Factory.StartNew(() => {
                t.WaitForChanged(WatcherChangeTypes.Changed);
                //});

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
                    File.AppendAllText("./" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", ex.Message + ex.StackTrace);
                }

            }

        }

        void HandleNode(XmlNode e)
        {
            string root = "";
            string outfile = "";

            XmlNodeList allpath = e.SelectNodes("./bigImage/@path");

            int leng = allpath.Count.ToString().Length;
            int idx = 0;
            string temp = "";

            foreach (XmlNode item in allpath)
            {

                FileInfo f = new FileInfo(item.Value);
                if (f.Exists)
                {
                    if (string.IsNullOrEmpty(root))
                    {
                        root = f.Directory.Name;
                        outfile = f.DirectoryName + "\\" + root + ".avi";
                        temp = f.DirectoryName + "\\temp\\";
                        if (!Directory.Exists(temp))
                        {
                            Directory.CreateDirectory(temp);
                        }

                        if (File.Exists(outfile))
                        {
                            break;
                        }
                    }

                    ConvertImag(item.Value, temp + idx.ToString().PadLeft(leng, '0') + ".jpg");
                    idx++;
                }
            }
            if (idx > 0)
            {
                FFEPEGHelper f = new FFEPEGHelper(Properties.Settings.Default.DefaultRate, temp + "%" + (leng > 1 ? leng.ToString() : "") + "d.jpg", outfile);
                f.CreateAvi();
                Directory.Delete(temp,true);
            }
        }

        private void ConvertImag(string file, string savefile)
        {
            //using (Bitmap bm = new Bitmap(file))
            //{
            //    MemoryStream s = new MemoryStream();
            //    bm.Save(s, System.Drawing.Imaging.ImageFormat.Jpeg);
            //    s.Flush();
            Bitmap b = (Bitmap)Bitmap.FromFile(file);

            b.Save(savefile, System.Drawing.Imaging.ImageFormat.Jpeg);

            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HandlerFile();
            // Task.Factory.StartNew(() => {
            MonitorFile();
            //});
        }
    }
}

