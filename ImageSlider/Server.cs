using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace ImageSlider
{
    public partial class Server : Form
    {
        private int imagenumber = 0;
        private IPEndPoint IP;
        private Socket HostServer;
        private List<Socket> clientList;
        private List<string> clientNames;
        private List<Image> imageList;
        private List<string> imageName;

        public Server()
        {
            InitializeComponent();
            InitializeCustomComponents();
            Send();
        }

        private void InitializeCustomComponents()
        {
            clientList = new List<Socket>();
            clientNames = new List<string>();
            imageList = new List<Image>();
            imageName = new List<string>();
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
                        Thread clientThread = new Thread(() => HandleClient(client));
                        clientThread.IsBackground = true;
                        clientThread.Start();
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

        private void HandleClient(Socket client)
        {
            string clientName = "";
            try
            {
                byte[] nameBuffer = new byte[1024];
                int nameLength = client.Receive(nameBuffer);
                clientName = System.Text.Encoding.UTF8.GetString(nameBuffer, 0, nameLength);

                Invoke(new Action(() =>
                {
                    clientList.Add(client);
                    clientNames.Add(clientName);
                    lbClients.Items.Add(clientName); // Add client name to ListBox
                }));

                // Keep receiving data from the client
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int received = client.Receive(buffer);
                    if (received == 0)
                    {
                        throw new SocketException(); // Client disconnected
                    }
                }
            }
            catch
            {
                Invoke(new Action(() =>
                {
                    int index = clientList.IndexOf(client);
                    if (index >= 0)
                    {
                        clientList.RemoveAt(index);
                        clientNames.RemoveAt(index);
                        lbClients.Items.RemoveAt(index); // Remove client name from ListBox
                    }
                }));
                client.Close();
            }
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
            if (imageList != null && imageList.Count > 0)
            {
                Image tmpImage = imageList[imagenumber];
                string tmpName = imageName[imagenumber];
                byte[] imageData = ImageToByteArray(tmpImage);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(ms))
                    {
                        writer.Write(tmpName);
                        writer.Write(imageData.Length);
                        writer.Write(imageData);
                    }
                    byte[] dataToSend = ms.ToArray();
                    foreach (Socket client in clientList.ToList())
                    {
                        try
                        {
                            client.Send(dataToSend);
                        }
                        catch
                        {
                            clientList.Remove(client);
                        }
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

        private void LoadImages(string[] filePaths)
        {
            foreach (string file in filePaths)
            {
                try
                {
                    imageList.Add(Image.FromFile(file));
                    imageName.Add(Path.GetFileName(file));
                }
                catch (ArgumentException)
                {
                    continue;
                }
            }

            if (imageList.Count > 0)
            {
                pictureBox1.Image = imageList[imagenumber];
                tbNameImage.Text = imageName[imagenumber];
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
            Connect();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select Images";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] filePaths = openFileDialog.FileNames;
                    LoadImages(filePaths);
                }
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (imageList != null && imageList.Count > 0)
            {
                imagenumber = (imagenumber - 1 + imageList.Count) % imageList.Count;
                pictureBox1.Image = imageList[imagenumber];
                tbNameImage.Text = imageName[imagenumber];
                Send();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (imageList != null && imageList.Count > 0)
            {
                imagenumber = (imagenumber + 1) % imageList.Count;
                pictureBox1.Image = imageList[imagenumber];
                tbNameImage.Text = imageName[imagenumber];
                Send();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }
    }
}
