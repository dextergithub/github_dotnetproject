using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectCore
{
    public class MatchingResult
    {
     
        private string _kinectrecognition;

        public string KinectRecognition
        {
            get { return _kinectrecognition; }
            set {
                _kinectrecognition = value;
                            
        } }

        public float MatchingRate { get; set; }

        public long SequenceNumber { get; set; }

        public Action<MatchingResult> CallBack { get; set; }
    }
}
