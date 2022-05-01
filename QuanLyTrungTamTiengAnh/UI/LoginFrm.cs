using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Logins;
namespace UI
{
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
            cbbChinhNhanh.DataSource = new string[] { "Chi nhanh 1", "Chi nhanh 2" };
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            bool isLogin = Login.LoginSystem(tbUserName.Text, tbPassword.Text,cbbChinhNhanh.Text.Trim());
            if (isLogin)
            {
                MessageBox.Show("Dang nhap thanh cong");
                frmHome frmhome = new frmHome();
                frmhome.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Dang nhap that bai");
            }
        }
    }
}
