using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace streamClient
{
    internal class Webcam
    {
        private readonly Udp _udp;
        private readonly PictureBox _webcam;
        private Thread camera;

        private Mat frame;
        private Bitmap image;

        public Webcam(PictureBox webcam)
        {
            isCameraRunning = false;
            _webcam = webcam;
            _udp = new Udp();
        }

        public VideoCapture capture { get; set; }
        public bool isCameraRunning { get; set; }

        public void CaptureCamera()
        {
            camera = new Thread(CaptureCameraCallback);
            camera.Start();
        }

        private void CaptureCameraCallback()
        {
            frame = new Mat();
            capture = new VideoCapture(0);
            capture.Open(0);

            capture.FrameHeight = 1;
            capture.FrameWidth = 1;

            if (capture.IsOpened())
                while (isCameraRunning)
                    try
                    {
                        var s = new MemoryStream();
                        capture.Read(frame);

                        image = frame.ToBitmap();

                        image.Save(s, ImageFormat.Jpeg);

                        if (_webcam.Image != null) _webcam.Image.Dispose();

                        _udp.send(s.ToArray());

                        _webcam.Image = image;
                    }
                    catch (Exception e)
                    {
                        //catch error in frame and ignore
                        Console.WriteLine(e);
                    }
        }
    }
}