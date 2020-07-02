using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {
        private Thread t;
        private Udp _udp;
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (pauze.Text.Equals("Start"))
            {
                Udp _udp = new Udp();
                pauze.Text = "Pauze";
                t = new Thread(() => _udp.listen(pictureBox1));
                t.Start();
            }
            else
            { 
                pauze.Text = "Start";
                t.Abort();
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
