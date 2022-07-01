using DoAn;
using DoAn.BLL;
using DoAn.View.MainView;
using pbl3.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbl3.View.Admin.DuLieu
{
    public partial class AddLoaiMH : Form
    {
        public delegate void Mydel();
        public Mydel d;
        string IDLoaiMH { get; set; }
        public AddLoaiMH(string id)
        {
            InitializeComponent();
            IDLoaiMH = id;
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
            LoaiManHinh a = QLBLL.Instance.GetLMHByIDLMH(IDLoaiMH);
            if (a != null)
            {
                txtMaLoaiMH.Enabled = false;
                txtMaLoaiMH.Text = a.IDLoaiManHinh;
                txtTenLoaiMH.Text = a.TenManHinh;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            LoaiManHinh lmh = new LoaiManHinh
            {
                IDLoaiManHinh = txtMaLoaiMH.Text,
                TenManHinh = txtTenLoaiMH.Text,
            };
            QLBLL.Instance.ExecuteDBLoaiMH(lmh);
            d();
            Cursor = Cursors.Default;
            this.Alert("Thành công...", frmPopupNotification.enmType.Success);
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
