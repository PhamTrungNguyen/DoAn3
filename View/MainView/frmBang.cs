using DoAn;
using DoAn.BLL;
using DoAn.DTO;
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

namespace pbl3
{
    public partial class frmBang : Form
    {
        public frmBang()
        {
            InitializeComponent();
        }
      //  testdoanEntities db = new testdoanEntities();
        private void listView_Click(object sender, EventArgs e)
        {
            if (lsvLichChieu.SelectedItems.Count > 0)
            {
                //LichChieuDTO lc = lsvLichChieu.SelectedItems[0].Tag as LichChieuDTO;
                string idLichChieu = lsvLichChieu.SelectedItems[0].SubItems[0].Text;
                // MessageBox.Show(idLichChieu);
                //LichChieu lc = db.LichChieux.Find(idLichChieu);
                //List<LichChieu> lc = new List<LichChieu>();
                LichChieu lc = QLBLL.Instance.GetLCbByIDLC(idLichChieu);

                //  MessageBox.Show(lc.IDLichChieu);
                PhimDTO p = cbbPhim.SelectedItem as PhimDTO;
                frmPhongChieu frm = new frmPhongChieu(lc, p);
                this.Hide();
                frm.ShowDialog();
                this.OnLoad(null);
                this.Show();
            }
        }
        public void LoadPhimByNgayKC_KT(DateTime date)
        {
            //cbbPhim.Items.AddRange((QLBLL.Instance.GetPhimByNgayKC_KT(date)).ToArray());
            cbbPhim.Items.Clear();
            cbbPhim.Items.AddRange((QLBLL.Instance.GetPhimByNgayKC_KT(date)).ToArray());

        }
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpThoiGian_ValueChanged(object sender, EventArgs e)
        {
            LoadPhimByNgayKC_KT(dtpThoiGian.Value);

        }

        private void cbbPhim_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbbPhim.SelectedIndex != -1)
            {
                string tenPhim = cbbPhim.SelectedItem.ToString();
                lsvLichChieu.Items.Clear();
               
                //DinhDangPhim ddp = db.DinhDangPhims.Where(s => s.IDPhim == idPhim && s.LichChieux.OrderBy(p => p.ThoiGianChieu).FirstOrDefault().ThoiGianChieu > dtpThoiGian.Value).FirstOrDefault();
                    //FormatMovie format = cboFormatFilm.SelectedItem as FormatMovie;
                  
                    foreach (LichChieu i in QLBLL.Instance.GetLCByTenPhimVaTrangThai(tenPhim))
                    {
                        ListViewItem lvi = new ListViewItem(i.IDLichChieu);

                        lvi.SubItems.Add(i.PhongChieu.TenPhong.ToString());
                        lvi.SubItems.Add(i.DinhDangPhim.Phim.TenPhim.ToString());
                        lvi.SubItems.Add(i.ThoiGianChieu.ToString());
                        lvi.SubItems.Add(i.TrangThai.ToString());
                        lvi.Tag = lvi;
                        lsvLichChieu.Items.Add(lvi);
                    }
                
                //cbbPhim.DataSource = null;
                //lsvLichChieu.Items.Clear();
                //PhimDTO movie = cbbPhim.SelectedItem as PhimDTO;
                //cbbPhim.DataSource = QLBLL.Instance.GetListFormatMovieByMovie(movie.idPhim);
                //cbbPhim.DisplayMember = "ScreenTypeName";
            }
        }

        private void frmBang_Load(object sender, EventArgs e)
        {

        }
    }
}
