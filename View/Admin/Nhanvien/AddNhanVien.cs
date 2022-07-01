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

namespace DoAn.View.Admin.Nhanvien
{
    public partial class AddNhanVien : Form
    {
        public delegate void Mydel();
        public Mydel d { get; set; }
        public string IDNV { get; set; }
        public AddNhanVien(string id)
        {
            InitializeComponent();
            IDNV = id;
            GUI();
        }
        public void GUI()
        {
            NhanVien a = QLBLL.Instance.GetNVByIDNV(IDNV);
            if (a != null)
            {
                txtMaNV.Enabled = false;
                txtMaNV.Text = a.idNhanVien;
                txtHoTen.Text = a.TenNV;
                dtpNS.Value = Convert.ToDateTime(a.NgaySinhNV);
                txtDiaChi.Text = a.DiaChiNV;
                txtSDT.Text = a.SDTNV;
                txtCMND.Text = Convert.ToString(a.SDTNV);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien
            {
                idNhanVien = txtMaNV.Text,
                TenNV = txtHoTen.Text,
                NgaySinhNV = Convert.ToDateTime(dtpNS.Value),
                DiaChiNV = txtDiaChi.Text,
                SDTNV = txtSDT.Text,
                CMNDNV = Convert.ToInt32(txtSDT.Text),
            };
            QLBLL.Instance.ExecuteDBNV(nv);
            d();
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
