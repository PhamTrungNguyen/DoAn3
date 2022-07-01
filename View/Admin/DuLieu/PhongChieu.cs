using DoAn.BLL;
using DoAn.View.MainView;
using pbl3.DTO;
using pbl3.View.Admin.DuLieu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn.View.Admin.DuLieu
{
    public partial class PhongChieu : UserControl
    {
        public PhongChieu()
        {
            InitializeComponent();
            LoadLMH();
        }
        public void LoadLMH()
        {
            cbbManHinh.Items.AddRange(QLBLL.Instance.GetCBBLoaiMH().ToArray());
        }
        public void Reload()
        {
            dgvPhongChieu.DataSource = QLBLL.Instance.ShowPhongChieu();
            dgvPhongChieu.Columns[0].Width = 200;
            dgvPhongChieu.Columns[1].Width = 180;
            dgvPhongChieu.Columns[2].Width = 150;
            dgvPhongChieu.Columns[3].Width = 150;
            // dgvPhongChieu.Columns[4].Width = 150;
            dgvPhongChieu.Columns[4].Width = 150;
            dgvPhongChieu.Columns[0].Width = 290;

            dgvPhongChieu.Columns[0].HeaderText = "Mã Phòng Chiếu";
            dgvPhongChieu.Columns[1].HeaderText = "Tên Phòng Chiếu";
            dgvPhongChieu.Columns[2].HeaderText = "Mã Màn Hình";
            dgvPhongChieu.Columns[3].HeaderText = "Số Chỗ Ngồi";
            // dgvPhongChieu.Columns[4].HeaderText = "Tình Trạng";
            dgvPhongChieu.Columns[4].HeaderText = "Số Hàng Ghế";
            dgvPhongChieu.Columns[5].HeaderText = "Số Ghế 1 Hàng";
        }
        private void btnPhongChieuThemXem_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void btnPhongChieuThem_Click(object sender, EventArgs e)
        {
            AddPhongChieu addpc = new AddPhongChieu("");
            addpc.Show();
            addpc.d = new AddPhongChieu.Mydel(Reload);
        }

        private void dgvPhongChieu_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvPhongChieu.SelectedRows.Count == 1)
            {
                txtPhongChieuMaPhong.Enabled = false;
                txtPhongChieuMaPhong.Text = dgvPhongChieu.SelectedRows[0].Cells["IDPhongChieu"].Value.ToString();
                txtPhongChieuTenPhong.Text = dgvPhongChieu.SelectedRows[0].Cells["TenPhong"].Value.ToString();
                txtPhongChieuChoNgoi.Text = dgvPhongChieu.SelectedRows[0].Cells["SoChoNgoi"].Value.ToString();
                // txtPhongChieuTinhTrang.Text = dgvPhongChieu.SelectedRows[0].Cells["TinhTrang"].Value.ToString();
                txtPhongChieuSoHangGhe.Text = dgvPhongChieu.SelectedRows[0].Cells["SoHangGhe"].Value.ToString();
                txtPhongChieuGheMoiHang.Text = dgvPhongChieu.SelectedRows[0].Cells["SoGhe1Hang"].Value.ToString();
                string id = dgvPhongChieu.SelectedRows[0].Cells["IDManHinh"].Value.ToString();
                foreach (CBBLoaiManHinh r in cbbManHinh.Items)
                {
                    if (r.value == id)
                    {
                        cbbManHinh.SelectedItem = r;
                    }
                }

            }
        }
        private void btnPhongChieuThemXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhongChieu.SelectedRows.Count == 1)
            {
                try
                {

               
                DialogResult ret = MessageBox.Show("Bạn có muốn xóa phòng chiếu này?", "Hỏi xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                {
                    bool kt = true;
                    string mapc = dgvPhongChieu.SelectedRows[0].Cells["IDPhongChieu"].Value.ToString();
                    List<LichChieu> lc = QLBLL.Instance.GetPhongChieuByLichChieu(mapc);
                    foreach (LichChieu l in lc)
                    {
                        if(l.TrangThai == "1")
                        {
                            kt = false;
                        }    
                    }    
                    if(kt != false)
                    {
                    QLBLL.Instance.DelPhongChieu(mapc);
                    Cursor = Cursors.Default;
                    this.Alert("Xóa thành công...", frmPopupNotification.enmType.Success);
                    Reload();
                    }
                    else
                    {
                        MessageBox.Show("Phòng chiếu đã được tạo lịch chiếu không được xóa !!!");
                    }
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thao tác nhanh vui lòng thử lại");
                }
            }
        }
        public void Alert(string msg, frmPopupNotification.enmType type)
        {
            frmPopupNotification frm = new frmPopupNotification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }

        private void btnPhongChieuThemSua_Click(object sender, EventArgs e)
        {
            if (dgvPhongChieu.SelectedRows.Count == 1)
            {

                string maPhong = txtPhongChieuMaPhong.Text;
                LichChieu lc = QLBLL.Instance.getLichChieuByIDPhong(maPhong);
                if (lc.TrangThai == "0")
                {
                    string IDPC = dgvPhongChieu.SelectedRows[0].Cells["IDPhongChieu"].Value.ToString();
                    AddPhongChieu addpc = new AddPhongChieu(IDPC);
                    addpc.Show();
                    addpc.d = new AddPhongChieu.Mydel(Reload);

                }
                else
                {
                    MessageBox.Show("Phòng chiếu đã được tạo vé không được sửa !!!");

                }
            }
        }
    }
}
