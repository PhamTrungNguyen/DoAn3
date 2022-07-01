using DoAn.BLL;
using DoAn.DTO;
using DoAn.View.MainView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbl3
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Database database = new Database();
            //this.Hide();
            //database.ShowDialog();
            //this.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            btnLogin.Enabled = false;
            string userName = txtUserName.Text;
            string passWord = txtPasswork.Text;
            int result = QLBLL.Instance.Login(userName, passWord);
            if (result == 1)
            {
                //Cursor = Cursors.Default;
                //this.Alert("Đăng nhập thành công...", frmPopupNotification.enmType.Success);
                TaiKhoanDTO loginAccount = QLBLL.Instance.GetAccountByUserName(userName);
                BangDieuKhien frm = new BangDieuKhien(loginAccount);
                this.Hide();
                frm.ShowDialog();
                this.Show();
            }
            else if (result == 0)
            {
                Cursor = Cursors.Default; 
                this.Alert("Kết nối thất bại...", frmPopupNotification.enmType.Error);
                
            }
            else
            {
                Cursor = Cursors.Default;
                this.Alert("Đăng nhập thành công...", frmPopupNotification.enmType.Success);
            }
            btnLogin.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btnShowPass.ImageIndex == 0)
            {
                btnShowPass.ImageIndex = 1;
                txtPasswork.Focus();
            }
            else
            {
                btnShowPass.ImageIndex = 0;
                txtPasswork.Focus();
            }
            if (txtPasswork.PasswordChar == '*')
            {
                txtPasswork.PasswordChar = '\0';
            }
            else
            {
                txtPasswork.PasswordChar = '*';
            }
        }
        private void btnShowPass_MouseHover(object sender, EventArgs e)
        {
            if (btnShowPass.ImageIndex == 0)
                toolTip1.Show("Hiện mật khẩu", btnShowPass);
            else
                toolTip1.Show("Ẩn mật khẩu", btnShowPass);

        }
        public void Alert(string msg, frmPopupNotification.enmType type)
        {
            frmPopupNotification frm = new frmPopupNotification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }
    }
}
