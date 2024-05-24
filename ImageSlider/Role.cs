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
    public partial class Role : Form
    {
        public Role()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
             Server slider = new Server();
            slider.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
        }
    }
}
