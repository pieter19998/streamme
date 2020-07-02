using System;
using System.IO;
using System.Net.Sockets;

namespace streamClient
{
    internal class Udp
    {
        private MemoryStream _stream;
        private readonly UdpClient _udpClient;

        public Udp()
        {
            _udpClient = new UdpClient();
        }

        public void send(byte[] sendBytes)
        {
            try
            {
                _udpClient.Send(sendBytes, sendBytes.Length, "127.0.0.1", 3000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}