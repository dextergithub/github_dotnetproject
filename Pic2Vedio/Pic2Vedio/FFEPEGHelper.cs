using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Pic2Vedio
{
    public class FFEPEGHelper
    {
        public Double Rate { get; set; }
        public string InputFile { get; set; }
        public string OutputFile { get; set; }
        public bool CreateAvi()
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("ffmpeg.exe", string.Format(" -threads 2 -y -r {2} -i \"{0}\"  \"{1}\"", this.InputFile, this.OutputFile, this.Rate));
            p.OutputDataReceived += p_OutputDataReceived;
            p.Start();
            p.WaitForExit();
            return true;
        }

        public FFEPEGHelper(double rate, string inputfile, string outputfile)
        {
            this.Rate = rate;
            this.InputFile = inputfile;
            this.OutputFile = outputfile;
        }

        void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            File.AppendAllText("./log.txt", e.Data);
        }
    }
}
