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

namespace DoAn.View.MainView
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        public KhachHangDTO customer;

        private void btnCofirm_Click(object sender, EventArgs e)
        {
            DataTable data = QLBLL.Instance.GetCustomer(txtCustomerID.Text, txtCustomerName.Text);
            if (data.Rows.Count == 0)
            {
                MessageBox.Show("ID hoặc Họ tên của Khách Hàng không chính xác!\nVui lòng nhập lại thông tin.");
                return;
            }
            customer = new KhachHangDTO(data.Rows[0]);

            DialogResult = DialogResult.OK;
        }
    }
}
