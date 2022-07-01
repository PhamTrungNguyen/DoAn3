using DoAn.BLL;
using DoAn.DTO;
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

namespace DoAn.View.Admin.DuLieu
{
    public partial class AddLichChieu : Form
    {
        public delegate void Mydel();
        public Mydel d;
        public string id { get; set; }
        public string trangthai { get; set; }
        public AddLichChieu(string idlc)
        {
            InitializeComponent();
            id = idlc;
            cboLichChieuMa.Items.AddRange(QLBLL.Instance.GetCBBDinhDang().ToArray());
            cboLichChieuPhong.Items.AddRange(QLBLL.Instance.GetCBBPhongChieu().ToArray());
            GUI();
        }
        public void Alert(string msg, frmPopupNotification.enmType type)
        {
            frmPopupNotification frm = new frmPopupNotification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }
        public void GUI()
        {
            LichChieu a = QLBLL.Instance.GetLichChieuByID(id);
            if (a != null)
            {
                trangthai = a.TrangThai;
                txtLichChieuMALC.Enabled = false;
                txtLichChieuMALC.Text = a.IDLichChieu;
                string f = a.ThoiGianChieu.ToString();
                string[] split = f.Split(' ');
                dtmShowtimeDate.Value = Convert.ToDateTime(split[0].ToString());
                dtmShowtimeTime.Value = Convert.ToDateTime(split[1].ToString());
                foreach (CBBPhongChieu i in cboLichChieuPhong.Items)
                {
                    if (i.value == a.IDPhong)
                    {
                        cboLichChieuPhong.SelectedItem = i;
                    }
                }
                foreach(CBBDinhDang i in cboLichChieuMa.Items)
                {
                    if(i.value == a.IDDinhDang)
                    {
                        cboLichChieuMa.SelectedItem = i;
                    }
                }    

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DateTime time = new DateTime(dtmShowtimeDate.Value.Year, dtmShowtimeDate.Value.Month, dtmShowtimeDate.Value.Day, dtmShowtimeTime.Value.Hour, dtmShowtimeTime.Value.Minute, dtmShowtimeTime.Value.Second);
            LichChieu lc = new LichChieu
            {
                IDLichChieu = txtLichChieuMALC.Text,
                IDDinhDang = ((CBBDinhDang)cboLichChieuMa.SelectedItem).value,
                IDPhong = ((CBBPhongChieu)cboLichChieuPhong.SelectedItem).value,
                ThoiGianChieu = Convert.ToDateTime(time),
                GiaVe = "85000",
                TrangThai = trangthai,
            };
            QLBLL.Instance.ExecuteLichChieu(lc);
            d();
            
            ///Cursor = Cursors.Default;
            //this.Alert("Thành công...", frmPopupNotification.enmType.Success);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}

