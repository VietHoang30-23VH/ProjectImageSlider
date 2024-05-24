using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSlider
{
    public partial class ForgotPassword : Form
    {
        Modify modify = new Modify();
        public ForgotPassword()
        {
            InitializeComponent();
            rtbPassword.AppendText("Mật khẩu của bạn là:");
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtEmail2.Text)) 
            {
                MessageBox.Show("Nhập ẹmail đã đăng kí!");
            }
            else
            {
                string query = "Select * from [dbo].[User] where Email ='" + txtEmail2.Text + "'";
                if(modify.accounts(query).Count!=0)
                {
                    rtbPassword.Clear();
                    rtbPassword.AppendText($"Mật khẩu của bạn là: {modify.accounts(query)[0].Password}");
                }
                else
                {
                    rtbPassword.Clear();
                    if (MessageBox.Show("Email này chưa được đăng kí! Hãy đăng kí!","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) ==DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
            }
        }
    }
}
