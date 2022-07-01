using DoAn.BLL;
using DoAn.DTO;
using DoAn.View.Admin.Khachhang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbl3.Admin.KhachHang
{
    public partial class KhachHang : UserControl
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        public void Reload()
        {
            dgvListKhachHang.DataSource = QLBLL.Instance.ShowKhachHang();
            dgvListKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
            dgvListKhachHang.Columns[1].HeaderText = "Họ Tên";
            dgvListKhachHang.Columns[2].HeaderText = "Ngày Sinh";
            dgvListKhachHang.Columns[3].HeaderText = "Địa Chỉ";
            dgvListKhachHang.Columns[4].HeaderText = "Số Điện Thoại";
            dgvListKhachHang.Columns[5].HeaderText = "CMND";
            dgvListKhachHang.Columns[6].HeaderText = "Điểm Tích Lũy";
            dgvListKhachHang.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
        private void btnKhachHangXem_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void btnKhachHangThem_Click(object sender, EventArgs e)
        {
            AddKhachHang addkh = new AddKhachHang("");
            addkh.Show();
            addkh.d = new AddKhachHang.Mydel(Reload);
        }

        private void btnKhachHangSua_Click(object sender, EventArgs e)
        {
            if (dgvListKhachHang.SelectedRows.Count == 1)
            {
                string IDKH = dgvListKhachHang.SelectedRows[0].Cells["ID"].Value.ToString();
                AddKhachHang addkh = new AddKhachHang(IDKH);
                addkh.Show();
                addkh.d = new AddKhachHang.Mydel(Reload);
            }
        }

        private void btnKhachHangXoa_Click(object sender, EventArgs e)
        {
            if (dgvListKhachHang.SelectedRows.Count == 1)
            {
                DialogResult ret = MessageBox.Show("Bạn có muốn xóa khách hàng này?", "Hỏi xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                {
                    string maKH = dgvListKhachHang.SelectedRows[0].Cells["ID"].Value.ToString();
                    QLBLL.Instance.DelKH(maKH);
                    Reload();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn để xóa");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string txt = txtSearch.Text;
            List<KhachHangDTO> data = QLBLL.Instance.SearchKhachHang(txt);
            dgvListKhachHang.DataSource = data;
        }

        private void dgvListKhachHang_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvListKhachHang.SelectedRows.Count == 1)
            {
                txtKhachHangMaKH.Enabled = false;
                txtKhachHangMaKH.Text = dgvListKhachHang.SelectedRows[0].Cells["ID"].Value.ToString();
                txtKhachHangHoten.Text = dgvListKhachHang.SelectedRows[0].Cells["Ten"].Value.ToString();
                dtpKhachHangNgaySinh.Value = Convert.ToDateTime(dgvListKhachHang.SelectedRows[0].Cells["NgaySinh"].Value.ToString());
                txtKhachHangDiaChi.Text = dgvListKhachHang.SelectedRows[0].Cells["DiaChiKH"].Value.ToString();
                txtKhachHangSoDT.Text = dgvListKhachHang.SelectedRows[0].Cells["SDT"].Value.ToString();
                txtKhachHangCMND.Text = dgvListKhachHang.SelectedRows[0].Cells["CMND"].Value.ToString();
                txtDiemTichLuy.Text = dgvListKhachHang.SelectedRows[0].Cells["DiemTichLuy"].Value.ToString();
            }
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {

        }

        private void dgvListKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
