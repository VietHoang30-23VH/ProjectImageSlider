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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Modify modify= new Modify();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text) || !string.IsNullOrEmpty(txtPassword.Text)) 
            {
                string tk = txtUsername.Text;
                string mk = txtPassword.Text;
                string query = "Select * from [dbo].[User] where Username='" + tk + "' and Password='" + mk + "'";
                if (modify.accounts(query).Count > 0)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Role role = new Role();
                    role.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                if (string.IsNullOrEmpty(txtUsername.Text))
                {
                    MessageBox.Show("Vui lòng nhập tài khoản", "Thông báo");
                    return;
                }
                else if (string.IsNullOrEmpty(txtPassword.Text)) MessageBox.Show("Vui lòng nhập mật khẩu","Thông báo");
            }                
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signup = new Signup();
            signup.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword forgot = new ForgotPassword();
            forgot.ShowDialog();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                btnShow.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                btnHide.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }
    }
  
}
