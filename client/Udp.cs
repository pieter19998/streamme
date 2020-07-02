using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    class Udp
    {
        private Bitmap image;

        public Udp()
        {
            UdpClient udp= new UdpClient();

        }

        public void listen(PictureBox pictureBox)
        {
            UdpClient receivingUdpClient = new UdpClient();
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            try
            {
                while (true)
                {
                    Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there?");

                    receivingUdpClient.Send(sendBytes, sendBytes.Length, "127.0.0.1", 3001);

                    Byte[] receiveBytes = receivingUdpClient.Receive(ref RemoteIpEndPoint);

                    MemoryStream s = new MemoryStream();

                    ImageConverter ic = new ImageConverter();

                    Image img = (Image)ic.ConvertFrom(receiveBytes);

                    Bitmap image = new Bitmap(img);

                    image.Save(s, ImageFormat.Jpeg);

                    pictureBox.Image = image;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
