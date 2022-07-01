//using pbl3.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.BLL;
using DoAn.View.MainView;
using pbl3.DTO;
using pbl3.View.Admin.DuLieu;

namespace pbl3.Admin.DuLieu
{
    public partial class DinhDang : UserControl
    {
        public DinhDang()
        {
            InitializeComponent();
            LoadLoaiManHinhANDPhim();
        }
        public void LoadLoaiManHinhANDPhim()
        {
            cbbDinhDangMaPhim.Items.AddRange(QLBLL.Instance.GetCBBPhim().ToArray());
            cbbDinhDangMaMH.Items.AddRange(QLBLL.Instance.GetCBBLoaiManHinh().ToArray());
        }
        public void Reload()
        {
            dgvDinhDangPhim.DataSource = QLBLL.Instance.ShowDinhDangPhim();
            dgvDinhDangPhim.Columns[0].Width = 250;
            dgvDinhDangPhim.Columns[1].Width = 250;
            dgvDinhDangPhim.Columns[2].Width = 250;

            dgvDinhDangPhim.Columns[0].HeaderText = "Mã Phân Loại";
            dgvDinhDangPhim.Columns[1].HeaderText = "Mã Phim";
            dgvDinhDangPhim.Columns[2].HeaderText = "Tên Phim";
            dgvDinhDangPhim.Columns[3].HeaderText = "Mã Màn Hình";
            dgvDinhDangPhim.Columns[4].HeaderText = "Tên Màn Hình";

        }
        private void btnDinhDangXem_Click(object sender, EventArgs e)
        {
            Reload();
        }
        
        private void btnDinhDangThem_Click(object sender, EventArgs e)
        {

            AddDinhDang addDinhDang = new AddDinhDang("");
            addDinhDang.d = new AddDinhDang.Mydel(Reload);
            addDinhDang.Show();
        }
        private void btnDinhDangSua_Click(object sender, EventArgs e)
        {
            if (dgvDinhDangPhim.SelectedRows.Count == 1)
            {
                string IDPhim = dgvDinhDangPhim.SelectedRows[0].Cells["ID_DinhDangPhim"].Value.ToString();
                AddDinhDang addDinhDang = new AddDinhDang(IDPhim);
                addDinhDang.Show();
                addDinhDang.d = new AddDinhDang.Mydel(Reload);
            }
        }
      

        private void dgvDinhDangPhim_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvDinhDangPhim.SelectedRows.Count == 1)
            {
                txtDinhDangMaDinhDang.Text = dgvDinhDangPhim.SelectedRows[0].Cells["ID_DinhDangPhim"].Value.ToString();
                string maManHinh = dgvDinhDangPhim.SelectedRows[0].Cells["ID_LoaiManHinh"].Value.ToString();
                foreach (CBBLoaiManHinh i in cbbDinhDangMaMH.Items)
                {
                    if (i.value == maManHinh)
                    {
                        cbbDinhDangMaMH.SelectedItem = i;
                        txtDinhDangTenMH.Text = i.text;
                    }
                }
                string maPhim = dgvDinhDangPhim.SelectedRows[0].Cells["ID_Phim"].Value.ToString();
                foreach (CBBPhim i in cbbDinhDangMaPhim.Items)
                {
                    if (i.value == maPhim)
                    {
                        cbbDinhDangMaPhim.SelectedItem = i;
                        txtDinhDangTenPhim.Text = i.text;
                    }
                }
            }

        }

        private void cbbDinhDangMaMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maManHinh = ((CBBLoaiManHinh)cbbDinhDangMaMH.SelectedItem).value.ToString();
            foreach (CBBLoaiManHinh i in cbbDinhDangMaMH.Items)
            {
                if (i.value == maManHinh)
                {
                    txtDinhDangTenMH.Text = i.text;
                }
            }
        }

        private void cbbDinhDangMaPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maPhim = ((CBBPhim)cbbDinhDangMaPhim.SelectedItem).value.ToString();
            foreach (CBBPhim i in cbbDinhDangMaPhim.Items)
            {
                if (i.value == maPhim)
                {
                    txtDinhDangTenPhim.Text = i.text;
                }
            }
        }

        private void btnDinhDangXoa_Click(object sender, EventArgs e)
        {
            if (dgvDinhDangPhim.SelectedRows.Count == 1)
            {
                try
                {

                DialogResult ret = MessageBox.Show("Bạn có muốn xóa định dạng này?", "Hỏi xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                {
                    string ID_DinhDangPhim = dgvDinhDangPhim.SelectedRows[0].Cells["ID_DinhDangPhim"].Value.ToString();
                    QLBLL.Instance.DelDinhDangPhim(ID_DinhDangPhim);
                    Cursor = Cursors.Default;
                    this.Alert("Xóa thành công...", frmPopupNotification.enmType.Success);
                    Reload();
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Phân loại phim và màn hình đã được tạo lịch chiếu không được xóa !!!");
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
    }


}
