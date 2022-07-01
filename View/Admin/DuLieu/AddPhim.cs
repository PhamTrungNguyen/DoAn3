//using pbl3.DAO;
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

namespace DoAn.Admin.DuLieu
{
    public partial class AddPhim : Form
    {
        public delegate void Mydel();
        public Mydel d { get; set; }
        string IDPhim { get; set; }
        public AddPhim(string id)
        {
            IDPhim = id;
            InitializeComponent();
            cboTheLoai.Items.AddRange(QLBLL.Instance.GetCBBTheLoai().ToArray());
            GUI();
        }
     //   testdoanEntities db = new testdoanEntities();
        public void Alert(string msg, frmPopupNotification.enmType type)
        {
            frmPopupNotification frm = new frmPopupNotification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }
        public void GUI()
        {
            Phim a = QLBLL.Instance.GetPhimByIDPhim(IDPhim);
            if (a != null)
            {
                txtPhimMa.Enabled = false;
                txtPhimTen.Text = a.TenPhim;
                txtPhimMa.Text = a.IDPhim;
                txtPhimThoiLuong.Text = Convert.ToString(a.ThoiLuong);
                txtPhimNamSX.Text = Convert.ToString(a.NamSX);
                dtpPhimNgayKC.Value = Convert.ToDateTime(a.NgayKhoiChieu);
                dtpPhimNgayKT.Value = Convert.ToDateTime(a.NgayKetThuc);
                txtPhimSanXuat.Text = a.SanXuat;
                txtPhimDaoDien.Text = a.DaoDien;
                foreach (CBBTheLoai r in cboTheLoai.Items)
                {
                    if (r.value == a.IDTheLoai)
                    {
                        cboTheLoai.SelectedItem = r;
                    }
                }

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string maPhim = txtPhimMa.Text;
            DateTime ngaykc = dtpPhimNgayKC.Value;
            DateTime ngaykt = dtpPhimNgayKT.Value;
            DinhDangPhim ddp = QLBLL.Instance.SSThoiGian(maPhim, ngaykc);
            DinhDangPhim ddp1 = QLBLL.Instance.SSThoiGian1(maPhim, ngaykt);
            //DinhDangPhim ddp = db.DinhDangPhims.Where(s =>s.IDPhim == maPhim && s.LichChieux.OrderBy(p => p.ThoiGianChieu).FirstOrDefault().ThoiGianChieu < dtpPhimNgayKC.Value).FirstOrDefault();
            //DinhDangPhim ddp1 = db.DinhDangPhims.Where(s => s.IDPhim == maPhim && s.LichChieux.OrderByDescending(p => p.ThoiGianChieu).FirstOrDefault().ThoiGianChieu > dtpPhimNgayKT.Value).FirstOrDefault();
            if (ddp == null && ddp1 == null )
            {

                Phim phim = new Phim
                {
                    IDPhim = txtPhimMa.Text,
                    TenPhim = txtPhimTen.Text,
                    ThoiLuong = Convert.ToDouble(txtPhimThoiLuong.Text),
                    NgayKhoiChieu = (dtpPhimNgayKC.Value),
                    NgayKetThuc = (dtpPhimNgayKT.Value),
                    SanXuat = txtPhimSanXuat.Text,
                    NamSX = Convert.ToInt32(txtPhimNamSX.Text),
                    DaoDien = txtPhimDaoDien.Text,
                    IDTheLoai = ((CBBTheLoai)cboTheLoai.SelectedItem).value,


                };


                QLBLL.Instance.ExecuteDBPhim(phim);
                d();
                Cursor = Cursors.Default;
                this.Alert("Thành công...", frmPopupNotification.enmType.Success);
                this.Close();
            }
            else
            {
                MessageBox.Show("Thời gian sửa không hợp lệ !!!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
