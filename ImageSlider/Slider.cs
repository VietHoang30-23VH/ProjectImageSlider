using ImageSlider.Usercontrol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSlider
{
    public partial class Slider : Form
    {
        public Slider()
        {
            InitializeComponent();
        }
        private void addUserControl(UserControl user)
        {
            user.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(user);
            user.BringToFront();
        }
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Preview preview = new Preview();
            addUserControl(preview);
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            Sourcecs sourcecs = new Sourcecs();
            addUserControl(sourcecs);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
