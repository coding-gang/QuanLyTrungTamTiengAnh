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
using Core.Permission;
using Dtos;
namespace UI
{
    public partial class LoginFrm : Form
    {
        private Role role = null;
        public LoginFrm()
        {
            InitializeComponent();
            role = new Role();
            cbbChinhNhanh.DataSource = new string[] { "Chi nhánh 1", "Chi nhánh 2" };
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            var branch = cbbChinhNhanh.Text.Trim();
            bool isLogin = Login.LoginSystem(tbUserName.Text, tbPassword.Text,branch);
            if (isLogin)
            {
                MessageBox.Show("Dang nhap thanh cong");
                var userRole = GetPermissionRole();
                frmHome frmhome = new frmHome(userRole,branch);
                this.Hide();
                frmhome.Show();
               
            }
            else
            {
                MessageBox.Show("Dang nhap that bai");
            }
        }

        private UserRole GetPermissionRole()
        {
             return role.GetRoleCurrentUser();
        }
    }
}
