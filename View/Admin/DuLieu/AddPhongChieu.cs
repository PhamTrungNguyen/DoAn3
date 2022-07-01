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
    public partial class AddPhongChieu : Form
    {
        public delegate void Mydel();
        public Mydel d;
        public string IDPhongChieu { get; set; }

        public AddPhongChieu(string id)
        {
            InitializeComponent();
            IDPhongChieu = id;
            cbbManHinh.Items.AddRange(QLBLL.Instance.GetCBBLoaiMH().ToArray());
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
            PhongChieu a = QLBLL.Instance.GetPCByIDPC(IDPhongChieu);
            if (a != null)
            {
                txtIDPhongChieu.Enabled = false;
                txtIDPhongChieu.Text = a.IDPhongChieu;
                txtTenPhong.Text = a.TenPhong;
                txtSoChoNgoi.Text = Convert.ToString(a.SoChoNgoi);
                txtSoHangGhe.Text = Convert.ToString(a.SoHangGhe);
                txtSoGhe1Hang.Text = Convert.ToString(a.SoGheMotHang);
                foreach (CBBLoaiManHinh r in cbbManHinh.Items)
                {
                    if (r.value == a.IDManHinh)
                    {
                        cbbManHinh.SelectedItem = r;
                    }
                }

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int soghe = Convert.ToInt32(txtSoChoNgoi.Text);
            int soghe1 = Convert.ToInt32(txtSoHangGhe.Text) * Convert.ToInt32(txtSoGhe1Hang.Text);
            if(soghe == soghe1)
            {     
            if (soghe <= 140)
            {
                PhongChieu pc = new PhongChieu
                {
                    IDPhongChieu = txtIDPhongChieu.Text,
                    TenPhong = txtTenPhong.Text,
                    IDManHinh = ((CBBLoaiManHinh)cbbManHinh.SelectedItem).value,
                    SoHangGhe = Convert.ToInt32(txtSoHangGhe.Text),
                    SoGheMotHang = Convert.ToInt32(txtSoGhe1Hang.Text),
                    SoChoNgoi = Convert.ToInt32(txtSoChoNgoi.Text),
                };
                QLBLL.Instance.ExecuteDBPhongChieu(pc);
                d();
                Cursor = Cursors.Default;
                this.Alert("Thành công...", frmPopupNotification.enmType.Success);
                this.Close();
            }
            }
            else
            {
                MessageBox.Show("Số chỗ ngồi không đúng");
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
