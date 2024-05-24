using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace ImageSlider
{
    public partial class Client : Form
    {
        private IPEndPoint IP;
        private Socket client;

        public Client()
        {
            InitializeComponent();
           
        }

        private void Connect()
        {
            IP = new IPEndPoint(IPAddress.Parse(tbIP.Text), 8080);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                client.Connect(IP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }

        private void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    int receivedBytes = client.Receive(data);
                    if (receivedBytes > 0)
                    {
                        byte[] actualData = new byte[receivedBytes];
                        Array.Copy(data, actualData, receivedBytes);
                        Image image = ByteArrayToImage(actualData);
                        DisplayImage(image);
                    }
                }
            }
            catch
            {
                client.Close();
            }
        }

        private Image ByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void DisplayImage(Image image)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = image;
                }));
            }
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect();
        }
    }
}