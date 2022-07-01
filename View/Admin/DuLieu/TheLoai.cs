using DoAn;
using DoAn.Admin.DuLieu;
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

namespace pbl3.Admin.DuLieu
{
    public partial class TheLoai : UserControl
    {
        public TheLoai()
        {
            InitializeComponent();

        }
        void Reload()
        {
            dgvTheLoai.DataSource = QLBLL.Instance.ShowTheLoai();
            dgvTheLoai.Columns[0].HeaderText = "Mã Thể Loại";
            dgvTheLoai.Columns[1].HeaderText = "Tên Thể Loại";
        }
        private void btnTheLoaiThem_Click(object sender, EventArgs e)
        {
            AddTheLoai addTheLoai = new AddTheLoai("");
            addTheLoai.Show();
            addTheLoai.d = new AddTheLoai.Mydel(Reload);
        }

        private void btnTheLoaiThemXem_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void dgvTheLoai_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvTheLoai.SelectedRows.Count == 1)
            {
                txtTheLoaiMa.Enabled = false;
                txtTheLoaiMa.Text = dgvTheLoai.SelectedRows[0].Cells["ID_TheLoai"].Value.ToString();
                txtTheLoaiTen.Text = dgvTheLoai.SelectedRows[0].Cells["TenTheLoai"].Value.ToString();
            }
        }
        private void btnTheLoaiSua_Click(object sender, EventArgs e)
        {
            if (dgvTheLoai.SelectedRows.Count == 1)
            {
                string IDTheLoai = dgvTheLoai.SelectedRows[0].Cells["ID_TheLoai"].Value.ToString();
                AddTheLoai addTheLoai = new AddTheLoai(IDTheLoai);
                addTheLoai.Show();
                addTheLoai.d = new AddTheLoai.Mydel(Reload);
            }
        }
        PBL3QLRPEntities4 db = new PBL3QLRPEntities4();
        private void btnTheLoaiXoa_Click(object sender, EventArgs e)
        {
            if (dgvTheLoai.SelectedRows.Count == 1)
            {
                try
                {

                DialogResult ret = MessageBox.Show("Bạn có muốn xóa thể loại này?", "Hỏi xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                {
                    {
                        string maTheLoai = dgvTheLoai.SelectedRows[0].Cells["ID_TheLoai"].Value.ToString();
                        QLBLL.Instance.DelTheLoai(maTheLoai);
                        Cursor = Cursors.Default;
                        this.Alert("Xóa thành công...", frmPopupNotification.enmType.Success);
                        Reload();
                          
                    }
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thể loại đã được tạo phân loại không được xóa !!!");
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
