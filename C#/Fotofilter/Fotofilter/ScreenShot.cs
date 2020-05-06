using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace Fotofilter
{
    public partial class ScreenShot : Form
    {
        VideoCapture capture;
        Mat frame;
        Bitmap image;
        public Bitmap snapshot;
        private Thread camera;
        bool isCameraRunning = false;

        public ScreenShot()
        {
            InitializeComponent();
        }

        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }
        private void CaptureCameraCallback()
        {

            frame = new Mat();
            capture = new VideoCapture(0);
            capture.Open(0);
            

            if (capture.IsOpened())
            {
                while (isCameraRunning)
                {
                    
                    capture.Read(frame);
                    image = BitmapConverter.ToBitmap(frame);
                    if (pbxCameraFeed.Image != null)
                    {
                        pbxCameraFeed.Image.Dispose();
                    }
                    
                    pbxCameraFeed.Image = image.GetThumbnailImage(pbxCameraFeed.Width, pbxCameraFeed.Height, null, IntPtr.Zero);
                    
                }
            }
        }

        private void SnapImage(object sender, EventArgs e)
        {
            if(pbxCameraFeed.Image != null)
            {
                snapshot = new Bitmap(pbxCameraFeed.Image);
                capture.Release();
                pbxCameraFeed.Image = null;
                isCameraRunning = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            isCameraRunning = false;
            Close();
        }

        private void StartCamera(object sender, EventArgs e)
        {
            CaptureCamera();
            isCameraRunning = true;
        }
    }
}
