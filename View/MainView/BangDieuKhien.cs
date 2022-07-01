using DoAn.DTO;
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
    public partial class BangDieuKhien : Form
    {
        private TaiKhoanDTO loginAccount;
        public BangDieuKhien(TaiKhoanDTO acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
            ChangeAccount(Convert.ToInt32(acc.loaiTK));
        }
        public TaiKhoanDTO LoginAccount
        {

            get { return loginAccount; }
            set
            {
                loginAccount = value;
                ChangeAccount(Convert.ToInt32(loginAccount.loaiTK));
            }
        }
        public void ChangeAccount(int type)
        {
            if (Convert.ToInt32(loginAccount.loaiTK) == 2) btnAdmin.Enabled = false;
            lblAcc.Text += LoginAccount.userName;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Admin1 admin1 = new Admin1();
            admin1.ShowDialog();
        }

        private void btnBanVe_Click(object sender, EventArgs e)
        {
            frmBang frmBang = new frmBang();
            frmBang.ShowDialog();
            this.Show();
        }

        private void btnResetMK_Click(object sender, EventArgs e)
        {
            btnDoiMK.Enabled = false;
            string user = LoginAccount.userName;
            DoiMatKhau doiMatKhau = new DoiMatKhau(user);
           // this.Hide();
            doiMatKhau.ShowDialog();
            this.Show();
            btnDoiMK.Enabled = true;
        }
    }
}
