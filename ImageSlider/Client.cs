using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ImageSlider
{
    public partial class Client : Form
    {
        private IPEndPoint IP;
        private Socket client;
        private bool isConnected = false;

        public Client()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIP.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ IP và Name");
                return;
            }
            if (isConnected)
            {
                return;
            }
            IP = new IPEndPoint(IPAddress.Parse(txtIP.Text), 8080);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                client.Connect(IP);
                isConnected = true;
                MessageBox.Show("Kết nối thành công");
                SendClientName(txtName.Text);
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

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                client.Close();
                isConnected = false;
                MessageBox.Show("Đã ngắt kết nối");
                pictureBox1.Image = null;
                tbNameImage.Text = string.Empty;
            }
        }

        private void SendClientName(string clientName)
        {
            byte[] nameData = System.Text.Encoding.UTF8.GetBytes(clientName);
            client.Send(nameData);
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
                        using (MemoryStream ms = new MemoryStream(data, 0, receivedBytes))
                        {
                            using (BinaryReader reader = new BinaryReader(ms))
                            {
                                string filename = reader.ReadString();
                                int imageLength = reader.ReadInt32();
                                byte[] imageData = reader.ReadBytes(imageLength);

                                Image image = ByteArrayToImage(imageData);
                                DisplayImage(image);
                                DisplayFilename(filename);
                            }
                        }
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

        private void DisplayFilename(string filename)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    tbNameImage.Text = filename; 
                }));
            }
        }
    }
}
