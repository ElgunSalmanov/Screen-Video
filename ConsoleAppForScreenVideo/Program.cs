using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace ConsoleAppForScreenVideo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ipAddress = IPAddress.Loopback;

            var listener = new TcpListener(ipAddress, 27001);

            listener.Start();

            var endPoint = "";

            while (true)
            {
                var client = listener.AcceptTcpClient();
                var stream = client.GetStream();
                var br = new BinaryReader(stream);

                Bitmap bitmap;

                while (true)
                {
                    var message = br.ReadString();

                    if (message == "Screen")
                    {
                        endPoint = (client.Client.RemoteEndPoint as IPEndPoint).Address.ToString();
                        bitmap = new Bitmap(1366, 768);

                        Size size = new Size(bitmap.Width, bitmap.Height);

                        Graphics memoryGraphics = Graphics.FromImage(bitmap);
                        memoryGraphics.CopyFromScreen(0, 0, 0, 0, size);

                        UdpClient udpClient = new UdpClient();

                        ImageConverter imageConverter = new ImageConverter();

                        var bytes = (byte[])imageConverter.ConvertTo(bitmap, typeof(byte[]));

                        int bytesLength = (bytes.Length / 10000) + 1;
                        int count = 0;

                        while (bytesLength >= 0)
                        {
                            if (bytesLength == 0)
                            {
                                udpClient.Send(new byte[2] { 2, 3 }, new byte[2] { 2, 3 }.Length, IPAddress.Loopback.ToString(), 27001);
                                break;
                            }

                            udpClient.Send(bytes.Skip(count).Take(20000).ToArray(), bytes.Skip(count).Take(10000).ToArray().Length, endPoint.ToString(), 27001);

                            bytesLength--;
                            count += 10000;
                        }
                    }
                    break;
                }
            }
        }
    }
}
