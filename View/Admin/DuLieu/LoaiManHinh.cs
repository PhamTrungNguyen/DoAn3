using DoAn;
using DoAn.BLL;
using DoAn.View.MainView;
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

namespace pbl3.Admin.DuLieu
{
    public partial class LoaiManHinh : UserControl
    {
        public LoaiManHinh()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        void Reload()
        {
            dgvManHinh.DataSource = QLBLL.Instance.ShowLMH();
            dgvManHinh.Columns[0].Width = 280;// The id column 
            dgvManHinh.Columns[1].Width = 280;// The abbrevation columln

            dgvManHinh.Columns[0].HeaderText = "Mã Màn Hình";
            dgvManHinh.Columns[1].HeaderText = "Tên Màn Hình";
        }
        private void BtnManHinhXem_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void BtnManHinhThem_Click(object sender, EventArgs e)
        {
            AddLoaiMH addLoaiMH = new AddLoaiMH("");
            addLoaiMH.d = new AddLoaiMH.Mydel(Reload);
            addLoaiMH.Show();
        }

        private void BtnManHinhSua_Click(object sender, EventArgs e)
        {
            if (dgvManHinh.SelectedRows.Count == 1)
            {
                string IDLoaiMH = dgvManHinh.SelectedRows[0].Cells["ID_LoaiManHinh"].Value.ToString();
                AddLoaiMH addlmh = new AddLoaiMH(IDLoaiMH);
                addlmh.Show();
                addlmh.d = new AddLoaiMH.Mydel(Reload);
            }
        }
        private void BtnManHinhXoa_Click(object sender, EventArgs e)
        {
            if (dgvManHinh.SelectedRows.Count == 1)
            {
                string maLMH1 = txtManHinhMa.Text;
                DinhDangPhim dinhDang = QLBLL.Instance.GetLMHByDinhDang(maLMH1);
                if (dinhDang == null)
                {
                    DialogResult ret = MessageBox.Show("Bạn có muốn xóa loại màn hình này?", "Hỏi xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ret == DialogResult.Yes)
                    {
                        string maLMH = dgvManHinh.SelectedRows[0].Cells["ID_LoaiManHinh"].Value.ToString();
                        QLBLL.Instance.DelLoaiMH(maLMH);
                        Cursor = Cursors.Default;
                        this.Alert("Xóa thành công...", frmPopupNotification.enmType.Success);
                        Reload();
                    }
                }
                else
                {
                    MessageBox.Show("Màn hình đã được tạo phân loại không được xóa !!!");
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

        private void dgvManHinh_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvManHinh.SelectedRows.Count == 1)
            {
                txtManHinhMa.Enabled = false;
                txtManHinhMa.Text = dgvManHinh.SelectedRows[0].Cells["ID_LoaiManHinh"].Value.ToString();
                txttxtManHinhTen.Text = dgvManHinh.SelectedRows[0].Cells["TenManHinh"].Value.ToString();
            }
        }
    }
}
