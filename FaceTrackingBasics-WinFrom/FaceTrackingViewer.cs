using System;
using System.Collections.Generic;
using System.ComponentModel;
using Drawing = System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit.FaceTracking;
using System.Diagnostics;
using BaseCommon;

namespace FaceTrackingBasics_WinFrom
{
    public partial class FaceTrackingViewer : UserControl
    {
        public delegate void GPathChangeHandler(FaceTrackingViewer sender, Drawing.Drawing2D.GraphicsPath path);
        public event GPathChangeHandler GPathChange;

        public FaceTrackingViewer()
        {
            InitializeComponent();

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.OnRender(e);
        }

        private KinectSensor _Kinect;

        // = DependencyProperty.Register(
        //"Kinect",
        //typeof(KinectSensor),
        //typeof(FaceTrackingViewer),
        //new PropertyMetadata(
        //    null, (o, args) => ((FaceTrackingViewer)o).OnSensorChanged((KinectSensor)args.OldValue, (KinectSensor)args.NewValue)));

        private const uint MaxMissedFrames = 100;

        private readonly Dictionary<int, SkeletonFaceTracker> trackedSkeletons = new Dictionary<int, SkeletonFaceTracker>();

        private byte[] colorImage;

        private ColorImageFormat colorImageFormat = ColorImageFormat.Undefined;

        private short[] depthImage;

        private DepthImageFormat depthImageFormat = DepthImageFormat.Undefined;

        private bool disposed;

        private Skeleton[] skeletonData;

        public KinectSensor Kinect
        {
            get
            {
                return _Kinect;
            }

            set
            {
                OnSensorChanged(_Kinect, value);
                _Kinect = value;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                this.ResetFaceTracking();

                this.disposed = true;
            }
        }

        protected void OnRender(PaintEventArgs e)
        {
            foreach (SkeletonFaceTracker faceInformation in this.trackedSkeletons.Values)
            {
               Drawing.Drawing2D.GraphicsPath path= faceInformation.DrawFaceModel(e);
               if (path != null)
               {
                  if(GPathChange != null ) GPathChange(this, path);
                   LogHelper.MyTrace.WriteLine(path.ExtToString());
               }
            }
        }



        private void OnAllFramesReady(object sender, AllFramesReadyEventArgs allFramesReadyEventArgs)
        {
            ColorImageFrame colorImageFrame = null;
            DepthImageFrame depthImageFrame = null;
            SkeletonFrame skeletonFrame = null;

            try
            {
                colorImageFrame = allFramesReadyEventArgs.OpenColorImageFrame();
                depthImageFrame = allFramesReadyEventArgs.OpenDepthImageFrame();
                skeletonFrame = allFramesReadyEventArgs.OpenSkeletonFrame();

                if (colorImageFrame == null || depthImageFrame == null || skeletonFrame == null)
                {
                    return;

                }


                // Check for image format changes.  The FaceTracker doesn't
                // deal with that so we need to reset.
                if (this.depthImageFormat != depthImageFrame.Format)
                {
                    this.ResetFaceTracking();
                    this.depthImage = null;
                    this.depthImageFormat = depthImageFrame.Format;
                }

                if (this.colorImageFormat != colorImageFrame.Format)
                {
                    this.ResetFaceTracking();
                    this.colorImage = null;
                    this.colorImageFormat = colorImageFrame.Format;
                }

                // Create any buffers to store copies of the data we work with
                if (this.depthImage == null)
                {
                    this.depthImage = new short[depthImageFrame.PixelDataLength];
                }

                if (this.colorImage == null)
                {
                    this.colorImage = new byte[colorImageFrame.PixelDataLength];
                }

                // Get the skeleton information
                if (this.skeletonData == null || this.skeletonData.Length != skeletonFrame.SkeletonArrayLength)
                {
                    this.skeletonData = new Skeleton[skeletonFrame.SkeletonArrayLength];
                }


                colorImageFrame.CopyPixelDataTo(this.colorImage);
                depthImageFrame.CopyPixelDataTo(this.depthImage);
                skeletonFrame.CopySkeletonDataTo(this.skeletonData);

                // Update the list of trackers and the trackers with the current frame information
                foreach (Skeleton skeleton in this.skeletonData)
                {
                    if (skeleton.TrackingState == SkeletonTrackingState.Tracked
                        || skeleton.TrackingState == SkeletonTrackingState.PositionOnly)
                    {
                        // We want keep a record of any skeleton, tracked or untracked.
                        if (!this.trackedSkeletons.ContainsKey(skeleton.TrackingId))
                        {
                            this.trackedSkeletons.Add(skeleton.TrackingId, new SkeletonFaceTracker());
                        }

                        // Give each tracker the upated frame.
                        SkeletonFaceTracker skeletonFaceTracker;
                        if (this.trackedSkeletons.TryGetValue(skeleton.TrackingId, out skeletonFaceTracker))
                        {
                            skeletonFaceTracker.OnFrameReady(this.Kinect, colorImageFormat, colorImage, depthImageFormat, depthImage, skeleton);
                            skeletonFaceTracker.LastTrackedFrame = skeletonFrame.FrameNumber;
                        }
                    }
                }

                this.RemoveOldTrackers(skeletonFrame.FrameNumber);

                //this.InvalidateVisual();
                this.Invalidate();
            }
            finally
            {
                if (colorImageFrame != null)
                {
                    colorImageFrame.Dispose();
                }

                if (depthImageFrame != null)
                {
                    depthImageFrame.Dispose();
                }

                if (skeletonFrame != null)
                {
                    skeletonFrame.Dispose();
                }
            }
        }

        private void OnSensorChanged(KinectSensor oldSensor, KinectSensor newSensor)
        {
            if (oldSensor != null)
            {
                oldSensor.AllFramesReady -= this.OnAllFramesReady;
                this.ResetFaceTracking();
            }

            if (newSensor != null)
            {
                newSensor.AllFramesReady += this.OnAllFramesReady;
            }
        }

        /// <summary>
        /// Clear out any trackers for skeletons we haven't heard from for a while
        /// </summary>
        private void RemoveOldTrackers(int currentFrameNumber)
        {
            var trackersToRemove = new List<int>();

            foreach (var tracker in this.trackedSkeletons)
            {
                uint missedFrames = (uint)currentFrameNumber - (uint)tracker.Value.LastTrackedFrame;
                if (missedFrames > MaxMissedFrames)
                {
                    // There have been too many frames since we last saw this skeleton
                    trackersToRemove.Add(tracker.Key);
                }
            }

            foreach (int trackingId in trackersToRemove)
            {
                this.RemoveTracker(trackingId);
            }
        }

        private void RemoveTracker(int trackingId)
        {
            this.trackedSkeletons[trackingId].Dispose();
            this.trackedSkeletons.Remove(trackingId);
        }

        private void ResetFaceTracking()
        {
            foreach (int trackingId in new List<int>(this.trackedSkeletons.Keys))
            {
                this.RemoveTracker(trackingId);
            }
        }

        private class SkeletonFaceTracker : IDisposable
        {
            private static FaceTriangle[] faceTriangles;

            private EnumIndexableCollection<FeaturePoint, PointF> facePoints;

            private FaceTracker faceTracker;

            private bool lastFaceTrackSucceeded;

            private SkeletonTrackingState skeletonTrackingState;

            public int LastTrackedFrame { get; set; }

            public void Dispose()
            {
                if (this.faceTracker != null)
                {
                    this.faceTracker.Dispose();
                    this.faceTracker = null;
                }
            }

            public Drawing.Drawing2D.GraphicsPath DrawFaceModel(PaintEventArgs drawingContext)
            {
                if (!this.lastFaceTrackSucceeded || this.skeletonTrackingState != SkeletonTrackingState.Tracked)
                {

                    return null;
                }

                var faceModelPts = new List<PointF>();
                var faceModel = new List<FaceModelTriangle>();

                for (int i = 0; i < this.facePoints.Count; i++)
                {
                    faceModelPts.Add(new PointF(this.facePoints[i].X + 0.5f, this.facePoints[i].Y + 0.5f));
                }

                foreach (var t in faceTriangles)
                {
                    var triangle = new FaceModelTriangle();
                    triangle.P1 = faceModelPts[t.First];
                    triangle.P2 = faceModelPts[t.Second];
                    triangle.P3 = faceModelPts[t.Third];
                    faceModel.Add(triangle);
                }

                //var faceModelGroup = new GeometryGroup();
                //for (int i = 0; i < faceModel.Count; i++)
                //{
                //    var faceTriangle = new GeometryGroup();
                //    faceTriangle.Children.Add(new LineGeometry(faceModel[i].P1, faceModel[i].P2));
                //    faceTriangle.Children.Add(new LineGeometry(faceModel[i].P2, faceModel[i].P3));
                //    faceTriangle.Children.Add(new LineGeometry(faceModel[i].P3, faceModel[i].P1));
                //    faceModelGroup.Children.Add(faceTriangle);
                //}

                var faceModelGroup = new Drawing.Drawing2D.GraphicsPath();
                for (int i = 0; i < faceModel.Count; i++)
                {
                    var faceTriangle = new Drawing.Drawing2D.GraphicsPath();
                    faceTriangle.AddLine(faceModel[i].P1.ToDPoint(), faceModel[i].P2.ToDPoint());
                    faceTriangle.AddLine(faceModel[i].P2.ToDPoint(), faceModel[i].P3.ToDPoint());
                    faceTriangle.AddLine(faceModel[i].P3.ToDPoint(), faceModel[i].P1.ToDPoint());
                    faceModelGroup.AddPath(faceTriangle, true);
                }
                
                drawingContext.Graphics.DrawPath(
                   new Drawing.Pen(Drawing.Brushes.Red, 1),
                    faceModelGroup);
                return faceModelGroup;
                //System.Diagnostics.Debug.WriteLine("faceModelGroup_" + Newtonsoft.Json.JsonConvert.SerializeObject(faceModelGroup));
            }

            /// <summary>
            /// Updates the face tracking information for this skeleton
            /// </summary>
            internal void OnFrameReady(KinectSensor kinectSensor, ColorImageFormat colorImageFormat, byte[] colorImage, DepthImageFormat depthImageFormat, short[] depthImage, Skeleton skeletonOfInterest)
            {
                this.skeletonTrackingState = skeletonOfInterest.TrackingState;

                if (this.skeletonTrackingState != SkeletonTrackingState.Tracked)
                {
                    // nothing to do with an untracked skeleton.
                    return;
                }

                if (this.faceTracker == null)
                {
                    try
                    {
                        this.faceTracker = new FaceTracker(kinectSensor);
                    }
                    catch (InvalidOperationException)
                    {
                        // During some shutdown scenarios the FaceTracker
                        // is unable to be instantiated.  Catch that exception
                        // and don't track a face.
                        Debug.WriteLine("AllFramesReady - creating a new FaceTracker threw an InvalidOperationException");
                        this.faceTracker = null;
                    }
                }

                if (this.faceTracker != null)
                {
                    FaceTrackFrame frame = this.faceTracker.Track(
                        colorImageFormat, colorImage, depthImageFormat, depthImage, skeletonOfInterest);

                    this.lastFaceTrackSucceeded = frame.TrackSuccessful;
                    if (this.lastFaceTrackSucceeded)
                    {
                        if (faceTriangles == null)
                        {
                            // only need to get this once.  It doesn't change.
                            faceTriangles = frame.GetTriangles();
                        }

                        this.facePoints = frame.GetProjected3DShape();
                    }
                }
            }

            private struct FaceModelTriangle
            {
                public PointF P1;
                public PointF P2;
                public PointF P3;
            }
        }

    }
    public static class ExtPointF
    {
        public static Drawing.PointF ToDPoint(this PointF p)
        {
            return new Drawing.PointF(p.X, p.Y);
        }

        public static string ExtToString(this Drawing.Drawing2D.GraphicsPath path)
        {
            if (path == null || path.PathPoints.Length  == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--Path Start-------------------------------------------");
            foreach (Drawing.PointF  item in path.PathPoints)
            {
                sb.AppendLine("Point:{{x:{0},y:{1}}}".ExtFormat(item.X ,item.Y));
            }
            sb.AppendLine("--Path End-------------------------------------------");
            return sb.ToString();
        }
    }
}
