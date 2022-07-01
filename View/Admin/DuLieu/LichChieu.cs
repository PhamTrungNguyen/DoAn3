using DoAn.BLL;
using DoAn.DTO;
using DoAn.View.Admin.DuLieu;
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
    public partial class LichChieu : UserControl
    {
        public LichChieu()
        {
            InitializeComponent();
            LoadPhongChieuAndDinhDang();
        }
        public void LoadPhongChieuAndDinhDang()
        {
            cboLichChieuMa.Items.AddRange(QLBLL.Instance.GetCBBDinhDang().ToArray());
            cboLichChieuPhong.Items.AddRange(QLBLL.Instance.GetCBBPhongChieu().ToArray());
        }
        public void Reload()
        {
            dgvLichChieu.DataSource = QLBLL.Instance.ShowLichChieu();

            dgvLichChieu.Columns[0].HeaderText = "Mã Lịch Chiếu";
            dgvLichChieu.Columns[1].HeaderText = "Thời Gian Chiếu";
            dgvLichChieu.Columns[2].Visible = false;
            dgvLichChieu.Columns[3].Visible = false;
            dgvLichChieu.Columns[4].Visible = false;
            dgvLichChieu.Columns[5].HeaderText = "Trạng Thái";
            dgvLichChieu.Columns[6].HeaderText = "Tên Phim";
            dgvLichChieu.Columns[7].HeaderText = "Tên Phòng Chiếu";
            dgvLichChieu.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

        }
        private void btnLichChieuXem_Click(object sender, EventArgs e)
        {
            Reload();
        }
        private void dgvLichChieu_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvLichChieu.SelectedRows.Count == 1)
            {
                txtLichChieuMALC.Text = dgvLichChieu.SelectedRows[0].Cells["IDLichChieu"].Value.ToString();
                string maIDLichChieuPhong = dgvLichChieu.SelectedRows[0].Cells["IDPhong"].Value.ToString();
                foreach (CBBPhongChieu i in cboLichChieuPhong.Items)
                {
                    if (i.value == maIDLichChieuPhong)
                    {
                        cboLichChieuPhong.SelectedItem = i;
                    }
                }
                string maIDDinhDang = dgvLichChieu.SelectedRows[0].Cells["IDDinhDang"].Value.ToString();
                string maPhim = "";
                string maLoaiMH = "";
                foreach (CBBDinhDang i in cboLichChieuMa.Items)
                {
                    if (i.value == maIDDinhDang)
                    {
                        cboLichChieuMa.SelectedItem = i;
                        maPhim = i.text;
                        maLoaiMH = i.text1;
                        foreach (PhimDTO p in QLBLL.Instance.ShowPhim())
                        {
                            if (p.idPhim == maPhim)
                            {
                                txtLichChieuPhim.Text = p.tenPhim.ToString();
                            }
                        }
                        foreach (LoaiManHinhDTO p in QLBLL.Instance.ShowLMH())
                        {
                            if (p.ID_LoaiManHinh.ToString() == maLoaiMH)
                            {
                                txtLichChieuManHinh.Text = p.TenManHinh.ToString();
                            }
                        }

                    }
                }
                string slip = (dgvLichChieu.SelectedRows[0].Cells["ThoiGianChieu"].Value.ToString());
                string[] split = slip.Split(' ');
                dtmShowtimeDate.Value = Convert.ToDateTime(split[0].ToString());
                dtmShowtimeTime.Value = Convert.ToDateTime(split[1].ToString());
            }
        }

        private void cboLichChieuMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maDinhDang = ((CBBDinhDang)cboLichChieuMa.SelectedItem).value.ToString();
            string maPhim = "";
            string maLoaiMH = "";
            foreach (CBBDinhDang i in cboLichChieuMa.Items)
            {
                if (i.value == maDinhDang)
                {
                    cboLichChieuMa.SelectedItem = i;
                    maPhim = i.text;
                    maLoaiMH = i.text1;
                    foreach (PhimDTO p in QLBLL.Instance.ShowPhim())
                    {
                        if (p.idPhim.ToString() == maPhim)
                        {
                            txtLichChieuPhim.Text = p.tenPhim.ToString();
                        }
                    }
                    foreach (LoaiManHinhDTO p in QLBLL.Instance.ShowLMH())
                    {
                        if (p.ID_LoaiManHinh.ToString() == maLoaiMH)
                        {
                            txtLichChieuManHinh.Text = p.TenManHinh.ToString();
                        }
                    }

                }
            }
        }

        private void btnLichChieuThem_Click(object sender, EventArgs e)
        {
            AddLichChieu frm = new AddLichChieu("");
            frm.Show();
            frm.d = new AddLichChieu.Mydel(Reload);
        }

        private void btnLichChieuSua_Click(object sender, EventArgs e)
        {
            if (dgvLichChieu.SelectedRows.Count == 1)
            {
                string IDlc = dgvLichChieu.SelectedRows[0].Cells["IDLichChieu"].Value.ToString();
                AddLichChieu frm = new AddLichChieu(IDlc);
                frm.Show();
                frm.d = new AddLichChieu.Mydel(Reload);
            }
        }

        private void btnLichChieuXoa_Click(object sender, EventArgs e)
        {
            if (dgvLichChieu.SelectedRows.Count == 1)
            {
                string tinhtrang = dgvLichChieu.SelectedRows[0].Cells["TrangThai"].Value.ToString();
                if (tinhtrang == "1")
                {
                    MessageBox.Show("Lịch chiếu đã được tạo vé không được xóa !!!");
                }
                else
                {

                    DialogResult ret = MessageBox.Show("Bạn có muốn xóa lịch chiếu này?", "Hỏi xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ret == DialogResult.Yes)
                    {
                        string maLC = dgvLichChieu.SelectedRows[0].Cells["IDLichChieu"].Value.ToString();
                        QLBLL.Instance.DelLichChieu(maLC);
                        Cursor = Cursors.Default;
                        this.Alert("Xóa thành công...", frmPopupNotification.enmType.Success);
                        Reload();
                    }
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