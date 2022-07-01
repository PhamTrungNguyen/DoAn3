using DoAn;
using DoAn.BLL;
using DoAn.DTO;
using DoAn.View.Admin.Taikhoan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbl3.Admin.ThongTinTaiKhoan
{
    public partial class ThongTinTaiKhoan : UserControl
    {
        //testdoanEntities db = new testdoanEntities();
        public ThongTinTaiKhoan()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {
            cboThongTinTKMaNV.Items.AddRange(QLBLL.Instance.GetCBBNhanVien().ToArray());
        }
        public void Reload()
        {
            dgvListThongTinTK.DataSource = QLBLL.Instance.ShowTaiKhoan();
            dgvListThongTinTK.Columns[0].Width = 200;
            dgvListThongTinTK.Columns[1].Width = 200;
            dgvListThongTinTK.Columns[2].Width = 200;
            dgvListThongTinTK.Columns[3].Width = 200;

            dgvListThongTinTK.Columns[0].HeaderText = "Username";
            dgvListThongTinTK.Columns[1].HeaderText = "Mật Khẩu";
            dgvListThongTinTK.Columns[2].HeaderText = "Loại Tài Khoản";
            dgvListThongTinTK.Columns[3].HeaderText = "Mã Nhân Viên";
        }
        private void btnThongTinTKXem_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void btnThongTinTKThem_Click(object sender, EventArgs e)
        {
            AddTaiKhoan addtk = new AddTaiKhoan("");
            addtk.Show();
            addtk.d = new AddTaiKhoan.Mydel(Reload);
        }

        private void btnThongTinTKSua_Click(object sender, EventArgs e)
        {
            if (dgvListThongTinTK.SelectedRows.Count == 1)
            {
                string userName = dgvListThongTinTK.SelectedRows[0].Cells["userName"].Value.ToString();
                AddTaiKhoan addtk = new AddTaiKhoan(userName);
                addtk.Show();
                addtk.d = new AddTaiKhoan.Mydel(Reload);
            }
        }

        private void dgvListThongTinTK_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvListThongTinTK.SelectedRows.Count == 1)
            {
                txtThongTinTKUserName.Enabled = false;
                txtThongTinTKUserName.Text = dgvListThongTinTK.SelectedRows[0].Cells["userName"].Value.ToString();
                txtLoaiTK.Text = dgvListThongTinTK.SelectedRows[0].Cells["loaiTK"].Value.ToString();
                string id = dgvListThongTinTK.SelectedRows[0].Cells["IDNV"].Value.ToString();
                foreach (CBBNhanVien i in cboThongTinTKMaNV.Items)
                {
                    if (i.value == id)
                    {
                        cboThongTinTKMaNV.SelectedItem = i;
                        txtThongTinTKTenNV.Text = i.text;
                    }
                }

            }
        }

        private void cboThongTinTKMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cboThongTinTKMaNV.SelectedItem.ToString();
            foreach (CBBNhanVien i in cboThongTinTKMaNV.Items)
            {
                if (i.value == id)
                {
                    txtThongTinTKTenNV.Text = i.text;
                }
            }
        }

        private void btnThongTinTKXoa_Click(object sender, EventArgs e)
        {
            if (dgvListThongTinTK.SelectedRows.Count == 1)
            {
                DialogResult ret = MessageBox.Show("Bạn có muốn xóa tài khoản này?", "Hỏi xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                {
                    string username = dgvListThongTinTK.SelectedRows[0].Cells["userName"].Value.ToString();
                    QLBLL.Instance.DelTK(username);
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
            string txt = txtTimKiemTheoUserName.Text;
            List<TaiKhoanDTO> data = QLBLL.Instance.SearchTaiKhoan(txt);
            dgvListThongTinTK.DataSource = data;
        }
        
        private void btnResetMK_Click(object sender, EventArgs e)
        {
            if(dgvListThongTinTK.SelectedRows.Count == 1)
            {
                string username = dgvListThongTinTK.SelectedRows[0].Cells["userName"].Value.ToString();
                TaiKhoan tk = QLBLL.Instance.GetTKByUserName(username);
                QLBLL.Instance.ExecuteDBTaiKhoan(tk);
                Reload();
                MessageBox.Show("Done");
            }
        }
    }
}
