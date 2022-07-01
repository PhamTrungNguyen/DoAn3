using DoAn.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn.View.Admin.Khachhang
{
    public partial class AddKhachHang : Form
    {
        public delegate void Mydel();
        public Mydel d { get; set; }
        public string IDKH { get; set; }
        public AddKhachHang(string id)
        {
            InitializeComponent();
            IDKH = id;
            GUI();
        }
        public void GUI()
        {
            KhachHang a = QLBLL.Instance.GetKHByIDKH(IDKH);
            if (a != null)
            {
                txtKhachHangMaKH.Enabled = false;
                txtKhachHangMaKH.Text = a.idKhachHang;
                txtKhachHangHoten.Text = a.HoTenKH;
                dtpKhachHangNgaySinh.Value = Convert.ToDateTime(a.NgaySinhKH);
                txtKhachHangDiaChi.Text = a.DiaChiKH;
                txtKhachHangSoDT.Text = a.SDTKH;
                txtKhachHangCMND.Text = a.CMNDKH;
                txtDiemTichLuy.Text =(a.DiemTichLuy).ToString();

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang
            {
                idKhachHang = txtKhachHangMaKH.Text,
                HoTenKH = txtKhachHangHoten.Text,
                NgaySinhKH = dtpKhachHangNgaySinh.Value,
                DiaChiKH = txtKhachHangDiaChi.Text,
                SDTKH = txtKhachHangSoDT.Text,
                CMNDKH = txtKhachHangCMND.Text,
                DiemTichLuy = Convert.ToInt32(txtDiemTichLuy.Text),
            };
            QLBLL.Instance.ExecuteDBKH(kh);
            d();
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
