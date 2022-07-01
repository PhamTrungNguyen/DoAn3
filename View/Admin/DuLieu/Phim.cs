using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.Admin.DuLieu;
using DoAn.BLL;
using DoAn.View.MainView;
using pbl3.DTO;

namespace pbl3.Admin.DuLieu
{
    public partial class Phim : UserControl
    {
        public Phim()
        {
            InitializeComponent();
            Loadtheloai();
        }
        public void Loadtheloai()
        {
            cboTheLoai.Items.AddRange(QLBLL.Instance.GetCBBTheLoai().ToArray());
        }
        public void Reload()
        {
            dgvMovie.DataSource = QLBLL.Instance.ShowPhim();
            dgvMovie.Columns[0].HeaderText = "Mã Phim";
            dgvMovie.Columns[1].HeaderText = "Tên Phim";
            dgvMovie.Columns[2].HeaderText = "Thời Lượng";
            dgvMovie.Columns[3].HeaderText = "Ngày Khởi Chiếu";
            dgvMovie.Columns[4].HeaderText = "Ngày Kết Thúc";
            dgvMovie.Columns[5].HeaderText = "Sản Xuất";
            dgvMovie.Columns[6].HeaderText = "Đạo Diễn";
            dgvMovie.Columns[7].HeaderText = "Năm Sản Xuất";
            dgvMovie.Columns[8].HeaderText = "Mã Thể Loại";
            dgvMovie.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvMovie.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";

        }
        private void btnPhimXem_Click(object sender, EventArgs e)
        {
            Reload();
        }
        private void btnPhimThem_Click(object sender, EventArgs e)
        {

            AddPhim addphim = new AddPhim("");
            addphim.Show();
            addphim.d = new AddPhim.Mydel(Reload);
        }
        private void btnPhimUpdate_Click(object sender, EventArgs e)
        {
            if(dgvMovie.SelectedRows.Count == 1)
            {
                string IDPhim = dgvMovie.SelectedRows[0].Cells["idPhim"].Value.ToString();
                AddPhim addphim = new AddPhim(IDPhim);
                addphim.Show();
                addphim.d = new AddPhim.Mydel(Reload);
            }
                
        }
        private void btnPhimXoa_Click(object sender, EventArgs e)
        {
            if (dgvMovie.SelectedRows.Count == 1)
            {
                try
                {

                DialogResult ret = MessageBox.Show("Bạn có muốn xóa phim này?", "Hỏi xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                {
                    string maPhim = dgvMovie.SelectedRows[0].Cells["IDPhim"].Value.ToString();
                    QLBLL.Instance.DelPhim(maPhim);
                    Cursor = Cursors.Default;
                    this.Alert("Xóa thành công...", frmPopupNotification.enmType.Success);
                    Reload();
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Phim đã được tạo lịch chiếu không được xóa !!!");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn để xóa");
            }
        }
        public void Alert(string msg, frmPopupNotification.enmType type)
        {
            frmPopupNotification frm = new frmPopupNotification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }

        private void dgvMovie_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvMovie.SelectedRows.Count == 1)
            {
                txtPhimMa.Enabled = false;
                txtPhimMa.Text = dgvMovie.SelectedRows[0].Cells["IDPhim"].Value.ToString();
                txtPhimTen.Text = dgvMovie.SelectedRows[0].Cells["TenPhim"].Value.ToString();
                txtPhimThoiLuong.Text = dgvMovie.SelectedRows[0].Cells["ThoiLuong"].Value.ToString();
                txtPhimNamSX.Text = dgvMovie.SelectedRows[0].Cells["NamSanXuat"].Value.ToString();
                dtpPhimNgayKC.Value = Convert.ToDateTime(dgvMovie.SelectedRows[0].Cells["ngayKC"].Value.ToString());
                dtpPhimNgayKT.Value = Convert.ToDateTime(dgvMovie.SelectedRows[0].Cells["ngayKT"].Value.ToString());
                txtPhimSanXuat.Text = dgvMovie.SelectedRows[0].Cells["SanXuat"].Value.ToString();
                txtPhimDaoDien.Text = dgvMovie.SelectedRows[0].Cells["DaoDien"].Value.ToString();
                string id = dgvMovie.SelectedRows[0].Cells["IDTheLoai"].Value.ToString();
                foreach (CBBTheLoai r in cboTheLoai.Items)
                {
                    if (r.value == id)
                    {
                        cboTheLoai.SelectedItem = r;
                    }
                }
            }
        }

    }


}
