using DoAn.BLL;
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


namespace DoAn.Admin.DuLieu
{
    public partial class AddTheLoai : Form
    {
        public delegate void Mydel();
        public Mydel d;
        public string IDTheLoai { get; set; }
        public AddTheLoai(string id)
        {
            IDTheLoai = id;
            InitializeComponent();
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
            TheLoai tl = QLBLL.Instance.GetTheLoaiByIDTheLoai(IDTheLoai);
            if(tl != null)
            {
                txtTheLoaiMa.Enabled = false;
                txtTheLoaiMa.Text = tl.IDTheLoai;
                txtTheLoaiTen.Text = tl.TenTheLoai;
            }
        }
        private void btnTheLoaiOK_Click(object sender, EventArgs e)
        {
            TheLoai theLoai = new TheLoai()
            {
                IDTheLoai = txtTheLoaiMa.Text,
                TenTheLoai = txtTheLoaiTen.Text,
            };
            QLBLL.Instance.ExecuteDBTheLoai(theLoai);
            d();
            Cursor = Cursors.Default;
            this.Alert("Thành công...", frmPopupNotification.enmType.Success);
            this.Close();
        }

        private void btnTheLoaiThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
