using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace ImageSlider
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();
        public bool checkedAccount(string str)
        {
            return Regex.IsMatch(str, "^[a-zA-Z0-9]{5,30}$");
        }
        public bool checkedEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9_.]{5,50}@(gmail\.com|gm\.uit\.edu\.vn)$");
        }
        private void Show_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar=='\0')
            {
                pictureHide.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }

        private void pictureHide_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                pictureShow.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }

        private void pictureShow2_Click(object sender, EventArgs e)
        {
            if (txtConfirm.PasswordChar == '\0')
            {
                pictureHide2.BringToFront();
                txtConfirm.PasswordChar = '*';
            }
        }

        private void pictureHide2_Click(object sender, EventArgs e)
        {
            if (txtConfirm.PasswordChar == '*')
            {
                pictureShow2.BringToFront();
                txtConfirm.PasswordChar = '\0';
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            string tentk = txtUser.Text;
            string matkhau = txtPassword.Text;
            string xnmatkhau = txtConfirm.Text;
            string emai = txtEmail.Text;
            if (!checkedAccount(tentk))
            {
                MessageBox.Show("Nhập tài khoản thỏa: độ dài từ 5 -> 30, có số, có chữ hoa, chữ thường!");
                return;
            }
            if (!checkedAccount(matkhau))
            {
                MessageBox.Show("Nhập mật khẩu thỏa: độ dài từ 5 -> 30, có số, có chữ hoa, chữ thường!");
                return;
            }
            if (matkhau!=xnmatkhau)
            {
                MessageBox.Show("Mật khẩu xác nhận không giống nhau. Vui lòng nhập lại.");
                return;
            }
            if (!checkedEmail(emai))
            {
                MessageBox.Show("Nhập email thỏa: độ dài từ 5->50, có dạng @gmail.com (có thể là @gm.uit.edu.vn)!");
                return;
            }
            if (modify.accounts("Select * from [dbo].[User] where Email = '" + emai+"'").Count > 0)
            {
                MessageBox.Show("Email đã tồn tại! Vui lòng chọn mail khác!");
            }
            try
            {
                string query = "Insert into [dbo].[User] values ('" + tentk + "','" + matkhau + "','" + emai + "')";
                modify.Commnad(query);
                if (MessageBox.Show("Đăng kí thành công! Quay trở về đăng nhập?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch { }
        }
    }
}
