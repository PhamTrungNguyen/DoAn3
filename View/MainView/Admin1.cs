using DoAn;
using DoAn.View.Admin.Ve;
using pbl3.Admin.DoanhThu;
using pbl3.Admin.KhachHang;
using pbl3.Admin.NhanVien;
using pbl3.Admin.ThongTinTaiKhoan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhachHang = pbl3.Admin.KhachHang.KhachHang;
using NhanVien = pbl3.Admin.NhanVien.NhanVien;

namespace pbl3
{
    public partial class Admin1 : Form
    {
        public Admin1()
        {
            InitializeComponent();
        }

        private void btnDuLieu_Click(object sender, EventArgs e)
        {
            this.Text = "Dữ Liệu";
            pnAdmin.Controls.Clear();
            DuLieu duLieu = new DuLieu();
            duLieu.Dock = DockStyle.Fill;
            pnAdmin.Controls.Add(duLieu);
        }

        private void btnDuLieu_MouseClick(object sender, MouseEventArgs e)
        {
            btnNhanVien.BackColor = Color.FromArgb(253, 227, 250);
            btnKhachHang.BackColor = Color.FromArgb(253, 227, 250);
            btnDanhThu.BackColor = Color.FromArgb(253, 227, 250);
            btnTaiKhoan.BackColor = Color.FromArgb(253, 227, 250);
            btnVe.BackColor = Color.FromArgb(253, 227, 250);

            btnDuLieu.BackColor = Color.Pink;
        }

        private void btnDanhThu_MouseClick(object sender, MouseEventArgs e)
        {
            btnNhanVien.BackColor = Color.FromArgb(253, 227, 250);
            btnKhachHang.BackColor = Color.FromArgb(253, 227, 250);
            btnDuLieu.BackColor = Color.FromArgb(253, 227, 250);
            btnTaiKhoan.BackColor = Color.FromArgb(253, 227, 250);
            btnVe.BackColor = Color.FromArgb(253, 227, 250);

            btnDanhThu.BackColor = Color.Pink;
        }

        private void btnNhanVien_MouseClick(object sender, MouseEventArgs e)
        {
            btnDuLieu.BackColor = Color.FromArgb(253, 227, 250);
            btnKhachHang.BackColor = Color.FromArgb(253, 227, 250);
            btnDanhThu.BackColor = Color.FromArgb(253, 227, 250);
            btnTaiKhoan.BackColor = Color.FromArgb(253, 227, 250);
            btnVe.BackColor = Color.FromArgb(253, 227, 250);

            btnNhanVien.BackColor = Color.Pink;
        }

        private void btnKhachHang_MouseClick(object sender, MouseEventArgs e)
        {
            btnDuLieu.BackColor = Color.FromArgb(253, 227, 250);
            btnNhanVien.BackColor = Color.FromArgb(253, 227, 250);
            btnDanhThu.BackColor = Color.FromArgb(253, 227, 250);
            btnTaiKhoan.BackColor = Color.FromArgb(253, 227, 250);
            btnVe.BackColor = Color.FromArgb(253, 227, 250);

            btnKhachHang.BackColor = Color.Pink;
        }

        private void btnTaiKhoan_MouseClick(object sender, MouseEventArgs e)
        {
            btnDuLieu.BackColor = Color.FromArgb(253, 227, 250);
            btnKhachHang.BackColor = Color.FromArgb(253, 227, 250);
            btnDanhThu.BackColor = Color.FromArgb(253, 227, 250);
            btnKhachHang.BackColor = Color.FromArgb(253, 227, 250);
            btnVe.BackColor = Color.FromArgb(253, 227, 250);

            btnTaiKhoan.BackColor = Color.Pink;
        }

        private void btnDanhThu_Click(object sender, EventArgs e)
        {
            this.Text = "Doanh Thu";
            pnAdmin.Controls.Clear();
            DoanhThu duLieu = new DoanhThu();
            duLieu.Dock = DockStyle.Fill;
            pnAdmin.Controls.Add(duLieu);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            this.Text = "Thông tin khách hàng";
            pnAdmin.Controls.Clear();
            KhachHang duLieu = new KhachHang();
            duLieu.Dock = DockStyle.Fill;
            pnAdmin.Controls.Add(duLieu);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            this.Text = "Thông tin nhân viên";
            pnAdmin.Controls.Clear();
            NhanVien duLieu = new NhanVien();
            duLieu.Dock = DockStyle.Fill;
            pnAdmin.Controls.Add(duLieu);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            this.Text = "Thông tin tài khoản";
            pnAdmin.Controls.Clear();
            ThongTinTaiKhoan duLieu = new ThongTinTaiKhoan();
            duLieu.Dock = DockStyle.Fill;
            pnAdmin.Controls.Add(duLieu);
        }

        

       

        private void btnVe_Click(object sender, EventArgs e)
        {
            this.Text = "Bán vé";
            pnAdmin.Controls.Clear();
            BanVe duLieu = new BanVe();
            duLieu.Dock = DockStyle.Fill;
            pnAdmin.Controls.Add(duLieu);

           
        }

        private void btnVe_MouseClick(object sender, MouseEventArgs e)
        {
            btnDuLieu.BackColor = Color.FromArgb(253, 227, 250);
            btnKhachHang.BackColor = Color.FromArgb(253, 227, 250);
            btnDanhThu.BackColor = Color.FromArgb(253, 227, 250);
            btnKhachHang.BackColor = Color.FromArgb(253, 227, 250);
            btnTaiKhoan.BackColor = Color.FromArgb(253, 227, 250);

            btnVe.BackColor = Color.Pink;
        }
    }
}
