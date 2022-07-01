using DoAn;
using DoAn.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbl3.Admin.DoanhThu
{
    public partial class DoanhThu : UserControl
    {
        public DoanhThu()
        {
            InitializeComponent();
            LoadPhimCBB(cbbPhim);
            LoadDateTimePickerRevenue();
        }
        void LoadPhimCBB(ComboBox comboBox)
        {
            comboBox.DataSource = QLBLL.Instance.ShowPhim();
            comboBox.DisplayMember = "TenPhim";
            comboBox.ValueMember = "IDPhim";
        }
        void LoadDateTimePickerRevenue()
        {
            dtpKC.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpKT.Value = dtpKC.Value.AddMonths(1).AddDays(-1);
        }

        void LoadRevenue(string idMovie, DateTime fromDate, DateTime toDate)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            dtgvRevenue.DataSource = QLBLL.Instance.GetRevenue(idMovie, fromDate, toDate);
            txtDoanhThu.Text = GetSumRevenue().ToString("c", culture);

        }
        decimal GetSumRevenue()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in dtgvRevenue.Rows)
            {
                sum += Convert.ToDecimal(row.Cells["Tiền vé"].Value);
            }
            return sum;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadRevenue(cbbPhim.SelectedValue.ToString(), dtpKC.Value, dtpKT.Value);
        }

    }
}
