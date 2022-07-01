using DoAn;
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
    public partial class DoiMatKhau : Form
    {
        
        public string user { get; set; }
        public DoiMatKhau(string User)
        {
            InitializeComponent();
            user = User;
            GUI();
        }
        public void Alert(string msg, frmPopupNotification.enmType type)
        {
            frmPopupNotification frm = new frmPopupNotification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }
        public void GUI()
        {
            TaiKhoan a = db.TaiKhoans.Find(user);
            if (a != null)
            {
                txtMaNV.Text = a.idNhanVien;
                txtTenTK.Text = a.UserName;
            }
        }
        PBL3QLRPEntities4 db = new PBL3QLRPEntities4();
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = db.TaiKhoans.Find(user);
            if (tk.Pass != txtPassOld.Text)
            {
                Cursor = Cursors.Default;
                this.Alert("Mật khẩu cũ không đúng...", frmPopupNotification.enmType.Warning);
            }
            else
            {
                if (txtPassNew.Text != txtXacNhan.Text)
                {
                    Cursor = Cursors.Default;
                    this.Alert("Nhập mật khẩu không đúng...", frmPopupNotification.enmType.Warning);

                }
                else
                {
                    tk.Pass = txtPassNew.Text;
                    Cursor = Cursors.Default;
                    this.Alert("Đổi mật khẩu thành công...", frmPopupNotification.enmType.Success);
                    this.Close();
                }
            }
            db.SaveChanges();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
