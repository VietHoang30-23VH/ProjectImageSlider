using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace ImageSlider
{
    public partial class Server : Form
    {
        private int imagenumber = 0;
        private IPEndPoint IP;
        private Socket HostServer;
        private List<Socket> clientList;
        

        public Server()
        {
            InitializeComponent();
            InitializeCustomComponents();
            Send();
        }

        private void InitializeCustomComponents()
        {
            imageList1 = new ImageList();
            clientList = new List<Socket>();
        }

        private void Connect()
        {
            IP = new IPEndPoint(IPAddress.Any, 8080);
            HostServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            HostServer.Bind(IP);
            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        HostServer.Listen(100);
                        Socket client = HostServer.Accept();
                        clientList.Add(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 8080);
                    HostServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            Listen.IsBackground = true;
            Listen.Start();
        }

        private byte[] Serialize(object obj)
        {
            using (MemoryStream streamable = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(streamable, obj);
                return streamable.ToArray();
            }
        }

        private void Send()
        {
            if (imageList1.Images.Count > 0)
            {
                Image tmpImage = imageList1.Images[imagenumber];
                byte[] imageData = ImageToByteArray(tmpImage);
                foreach (Socket client in clientList.ToList())
                {
                    try
                    {
                        client.Send(imageData);
                    }
                    catch
                    {
                        clientList.Remove(client);
                    }
                }
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void LoadImage(string directoryPath)
        {
            if (imageList1 == null)
            {
                imageList1 = new ImageList();
            }

            string[] files = Directory.GetFiles(directoryPath, "*.*")
                                      .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                                               || f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                                               || f.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                                               || f.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase)
                                               || f.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                                      .ToArray();
            foreach (string file in files)
            {
                try
                {
                    using (Bitmap bmp = new Bitmap(file))
                    {
                        imageList1.Images.Add(new Bitmap(bmp));
                    }
                }
                catch (ArgumentException)
                {
                    continue;
                }
            }

            if (imageList1.Images.Count > 0)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = imageList1.Images[imagenumber];
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
            Connect();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string directoryPath = folderBrowserDialog.SelectedPath;
                    Pathfile.Text = directoryPath;
                    LoadImage(directoryPath);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (imageList1 != null && imageList1.Images.Count > 0)
            {
                imagenumber = (imagenumber - 1 + imageList1.Images.Count) % imageList1.Images.Count;
                pictureBox1.Image = imageList1.Images[imagenumber];
                Send();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (imageList1 != null && imageList1.Images.Count > 0)
            {
                imagenumber = (imagenumber + 1) % imageList1.Images.Count;
                pictureBox1.Image = imageList1.Images[imagenumber];
                Send();
            }
        }
    }
}
