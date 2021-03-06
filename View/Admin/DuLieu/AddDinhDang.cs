//using pbl3.DAL;
//using pbl3.DAO;
using DoAn;
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

namespace pbl3.View.Admin.DuLieu
{
    public partial class AddDinhDang : Form
    {
        public delegate void Mydel();
        public Mydel d { get; set; }
        public string ID_DinhDangPhim { get; set; }
        public AddDinhDang(string id)
        {
            ID_DinhDangPhim = id;
            InitializeComponent();
            Load();
            GUI();
        }
        public void Alert(string msg, frmPopupNotification.enmType type)
        {
            frmPopupNotification frm = new frmPopupNotification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }
        public void Load()
        {
            cbbDinhDangMaPhim.Items.AddRange(QLBLL.Instance.GetCBBPhim().ToArray());
            cbbDinhDangMaMH.Items.AddRange(QLBLL.Instance.GetCBBLoaiManHinh().ToArray());
        }
        public void GUI()
        {
            DinhDangPhim a = QLBLL.Instance.GetDinhDangPhimByMaDinhDang(ID_DinhDangPhim);
            if (a != null)
            {
                txtDinhDangMaDinhDang.Enabled = false;
                txtDinhDangMaDinhDang.Text = a.IDDinhDangPhim;

                foreach (CBBLoaiManHinh r in cbbDinhDangMaMH.Items)
                {
                    if (r.value == a.IDLoaiManHinh)
                    {
                        cbbDinhDangMaMH.SelectedItem = r;
                        txtDinhDangTenMH.Text = r.text;
                    }
                }
                foreach (CBBPhim r in cbbDinhDangMaPhim.Items)
                {
                    if (r.value == a.IDPhim)
                    {
                        cbbDinhDangMaPhim.SelectedItem = r;
                        txtDinhDangTenPhim.Text = r.text;
                    }
                }

            }
        }
        private void btnDinhDangOk_Click(object sender, EventArgs e)
        {
            DinhDangPhim dinhDangPhim = new DinhDangPhim
            {
                IDDinhDangPhim = txtDinhDangMaDinhDang.Text,
                IDPhim = ((CBBPhim)cbbDinhDangMaPhim.SelectedItem).value,
                IDLoaiManHinh = ((CBBLoaiManHinh)cbbDinhDangMaMH.SelectedItem).value,
            };
            QLBLL.Instance.ExecuteDBDinhDangPhim(dinhDangPhim);
            d();
            Cursor = Cursors.Default;
            this.Alert("Thành công...", frmPopupNotification.enmType.Success);
            this.Close();
        }
        private void cbbDinhDangMaMH_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void btnDinhDangCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

