using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
namespace ImageSlider.Usercontrol
{
    public partial class Sourcecs : UserControl
    {
        public Sourcecs()
        {
            InitializeComponent();
        }
        string FolderPath;
        int index;
        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    listBox1.Items.Clear();
                    FolderPath = Path.GetDirectoryName(openFileDialog.FileName);
                    foreach (var image in openFileDialog.FileNames )
                    {
                        listBox1.Items.Add(Path.GetFileName(image));
                    }
                    listBox1.SelectedIndex = index = 0;
                }
            }
        }
        private void DisplayFileContent(string filePath)
        {
            // Lấy đuôi của file vd như .txt 
            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            if (extension == ".png" || extension == ".jpg" || extension == ".jpeg")
            {
                Image Image image = Image.FromFile(filePath);
                // Điều chỉnh độ rộng của ảnh để phù hợp với pictrueBox
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Image = image;
            }
        }
    }
}
