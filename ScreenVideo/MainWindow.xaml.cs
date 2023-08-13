using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace ScreenVideo
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            timer.Tick += Screen;
            timer.Interval = new TimeSpan(0, 0, 1);
        }

        private void screenbtn_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();

            tbox.IsReadOnly = true;
            screenbtn.IsEnabled = false;
        }

        public void Screen(object? sender, EventArgs e)
        {
            var tcpClient = new TcpClient();

            tcpClient.Connect(tbox.Text, 27001);

            var stream = tcpClient.GetStream();
            var bw = new BinaryWriter(stream);

            bw.Write("Screen");

            tcpClient.GetStream().Close();
            tcpClient.Close();

            List<byte> listbyte = new List<byte>();

            UdpClient udpClient = new UdpClient(27001);

            var endPoint = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                byte[] buffer = udpClient.Receive(ref endPoint);

                if (buffer.Length == 2) break;

                foreach (var item in buffer)
                {
                    listbyte.Add(item);
                }
            }

            byte[] count = new byte[listbyte.Count];

            listbyte.CopyTo(count);

            image.Source = byteImage(count);

            udpClient.Close();
        }

        public static ImageSource byteImage(byte[] image)
        {
            BitmapImage bitmapImage = new BitmapImage();

            MemoryStream memoryStream = new MemoryStream(image);

            bitmapImage.BeginInit();
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.EndInit();

            ImageSource imageSource = bitmapImage as ImageSource;

            return imageSource;
        }
    }
}
