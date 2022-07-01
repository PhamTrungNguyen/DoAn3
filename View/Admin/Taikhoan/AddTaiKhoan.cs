using DoAn.BLL;
using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn.View.Admin.Taikhoan
{
    public partial class AddTaiKhoan : Form
    {
        public delegate void Mydel();
        public Mydel d { get; set; }
        public string username { get; set; }
        public AddTaiKhoan(string name)
        {
            InitializeComponent();
            username = name;
            cbbMaNV.Items.AddRange(QLBLL.Instance.GetCBBNhanVien().ToArray());
            GUI();
        }
        public void GUI()
        {
            TaiKhoan a = QLBLL.Instance.GetTKByUserName(username);
            if (a != null)
            {
                txtUserName.Enabled = false;
                txtUserName.Text = a.UserName;
                txtLoaiTK.Text = a.LoaiTK;
                foreach (CBBNhanVien r in cbbMaNV.Items)
                {
                    if (r.value == a.idNhanVien)
                    {
                        cbbMaNV.SelectedItem = r;
                    }
                }
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan
            {
                UserName = txtUserName.Text,
                LoaiTK = txtLoaiTK.Text,
                Pass = "123456789",
                idNhanVien = cbbMaNV.SelectedItem.ToString(),
            };
            QLBLL.Instance.ExecuteDBTaiKhoan(tk);
            d();
            this.Close();
        }

        private void cbbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cbbMaNV.SelectedItem.ToString();
            foreach (CBBNhanVien i in cbbMaNV.Items)
            {
                if (i.value == id)
                {

                    txtTenNV.Text = i.text;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
