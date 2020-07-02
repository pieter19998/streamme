using System;
using System.IO;
using System.Windows.Forms;

namespace streamClient
{
    public partial class Form1 : Form
    {
        private MemoryStream _stream;
        private Udp _udp;
        private Webcam _webcam;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            _webcam = new Webcam(pictureBox1);
            _udp = new Udp();
            _stream = new MemoryStream();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stream_button.Text.Equals("Start stream"))
            {
                _webcam.CaptureCamera();
                stream_button.Text = "Stop stream";
                _webcam.isCameraRunning = true;
            }
            else
            {
                _webcam.capture.Release();
                stream_button.Text = "Start stream";
                _webcam.isCameraRunning = false;
                pictureBox1.Image = null;
                pictureBox1.Update();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}