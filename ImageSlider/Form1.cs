using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ImageSlider
{
    public partial class Form1 : Form
    {
        string FolderPath;
        int indexImage;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i<10;i++)
            {
                comboBox1.Items.Add(i);
                comboBox1.SelectedIndex = 0;
            }
        }
        private void DisplayFileContent(string filePath)
        {
            // Lấy đuôi của file vd như .txt 
            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            if (extension == ".png" || extension == ".jpg" || extension == ".jpeg")
            {
                Image image = Image.FromFile(filePath);
                // Điều chỉnh độ rộng của ảnh để phù hợp với pictrueBox
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Image = image;
            }
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    listBox1.Items.Clear();
                    FolderPath = Path.GetDirectoryName(openFileDialog.FileNames[0]); // Lấy đường dẫn thư mục chứa tệp được chọn

                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        listBox1.Items.Add(Path.GetFileName(fileName)); // Thêm tên tệp vào danh sách
                    }

                    listBox1.SelectedIndex = indexImage = 0;
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = btnShow.Enabled = true;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                if (listBox1.SelectedItem != null)
                {
                    string selectedFilePath = Path.Combine(FolderPath, listBox1.SelectedItem.ToString());
                    DisplayFileContent(selectedFilePath);
                }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (indexImage > 0)
            {
                indexImage -= 1;
                if (indexImage == 0)
                {
                    btnPrevious.Enabled = false;
                }
                if (indexImage < listBox1.Items.Count - 1)
                {
                    btnNext.Enabled = true;
                    listBox1.SelectedIndex = indexImage;
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (indexImage < listBox1.Items.Count - 1)
            {
                indexImage++;
                if (indexImage == listBox1.Items.Count - 1)
                {
                    btnNext.Enabled = false;
                }
                if (indexImage > 0)
                {
                    btnPrevious.Enabled=true;
                    listBox1.SelectedIndex = indexImage;
                }
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (btnShow.Text == "Presentation")
            {
                btnShow.Text = "Stop";
                timer1.Interval = int.Parse(comboBox1.Text) * 1000;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                btnShow.Text = "Presentation";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnNext.PerformClick();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
