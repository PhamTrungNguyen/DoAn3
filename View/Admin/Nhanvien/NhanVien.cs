using DoAn.BLL;
using DoAn.DTO;
using DoAn.View.Admin.Nhanvien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbl3.Admin.NhanVien
{
    public partial class NhanVien : UserControl
    {
        public NhanVien()
        {
            InitializeComponent();
        }
        public void Reload()
        {
            dgvListNhanVien.DataSource = QLBLL.Instance.ShowNhanVien();
            dgvListNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvListNhanVien.Columns[1].HeaderText = "Họ Tên";
            dgvListNhanVien.Columns[2].HeaderText = "Ngày Sinh";
            dgvListNhanVien.Columns[3].HeaderText = "Địa Chỉ";
            dgvListNhanVien.Columns[4].HeaderText = "Số Điện Thoại";
            dgvListNhanVien.Columns[5].HeaderText = "CMND";
            dgvListNhanVien.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
          
        }
        private void btnNhanVienXem_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void btnNhanVienSua_Click(object sender, EventArgs e)
        {
            if (dgvListNhanVien.SelectedRows.Count == 1)
            {
                string IDNV = dgvListNhanVien.SelectedRows[0].Cells["IDNhanVien"].Value.ToString();
                AddNhanVien addnv = new AddNhanVien(IDNV);
                addnv.Show();
                addnv.d = new AddNhanVien.Mydel(Reload);
            }
        }

        private void btnNhanVienThem_Click(object sender, EventArgs e)
        {
            AddNhanVien addnv = new AddNhanVien("");
            addnv.Show();
            addnv.d = new AddNhanVien.Mydel(Reload);
        }

        private void btnNhanVienXoa_Click(object sender, EventArgs e)
        {
            if (dgvListNhanVien.SelectedRows.Count == 1)
            {
                DialogResult ret = MessageBox.Show("Bạn có muốn xóa nhân viên này?", "Hỏi xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                {
                    string maNV = dgvListNhanVien.SelectedRows[0].Cells["IDNhanVien"].Value.ToString();
                    QLBLL.Instance.DelNV(maNV);
                    Reload();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn để xóa");
            }
        }

        private void dgvListNhanVien_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvListNhanVien.SelectedRows.Count == 1)
            {
                txtNhanVienMaNV.Enabled = false;
                txtNhanVienMaNV.Text = dgvListNhanVien.SelectedRows[0].Cells["IDNhanVien"].Value.ToString();
                txtNhanVienHoTen.Text = dgvListNhanVien.SelectedRows[0].Cells["NameNV"].Value.ToString();
                dtpNhanVienNgaySinh.Value = Convert.ToDateTime(dgvListNhanVien.SelectedRows[0].Cells["NS"].Value.ToString());
                txtNhanVienDiaChi.Text = dgvListNhanVien.SelectedRows[0].Cells["DiaChi"].Value.ToString();
                txtNhanVienSoDT.Text = dgvListNhanVien.SelectedRows[0].Cells["SDT"].Value.ToString();
                txtNhanVienCMND.Text = Convert.ToString(dgvListNhanVien.SelectedRows[0].Cells["CMND"].Value.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string txt = txtSearch.Text;
            List<NhanVienDTO> data = QLBLL.Instance.SearchNhanVien(txt);
            dgvListNhanVien.DataSource = data;
        }

        
    }
}
