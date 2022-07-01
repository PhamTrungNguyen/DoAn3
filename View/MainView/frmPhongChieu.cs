using DoAn;
using DoAn.BLL;
using DoAn.DTO;
using DoAn.View.MainView;
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
namespace pbl3
{
    public partial class frmPhongChieu : Form
    {
        int SIZE = 40;
        int GAP = 20;


        List<TicketDTO> listSeat = new List<TicketDTO>();
        List<Button> listSeatSelected = new List<Button>();


        float displayPrice = 0;//Hiện thị giá vé
        float ticketPrice = 0;//Lưu giá vé gốc
        float total = 0;//Tổng giá tiền
        float discount = 0;//Tiền được giảm
        float payment = 0;//Tiền phải trả
        int plusPoint = 0;//Số điểm tích lũy khi mua vé


        KhachHangDTO customer;
        PhimDTO phim;
        LichChieu lc;

        public frmPhongChieu(LichChieu lc, PhimDTO phim)
        {
            InitializeComponent();
            this.lc = lc;
            this.phim = phim;
        }

        private void frmPhongChieu_Load(object sender, EventArgs e)
        {
            ticketPrice = float.Parse(lc.GiaVe);

            radNguoiLon.Checked = true;
            radSV.Checked = false;
            radTreEm.Checked = false;

            LoadDataPC(lc.PhongChieu.TenPhong);


            ShowOrHideTichThuong();

            listSeat = QLBLL.Instance.GetListTicketsByShowTimes(lc.IDLichChieu);

            LoadSeats(listSeat);
        }
        private void ShowOrHideTichThuong()
        {
            if(chkKhachHangThanhVien.Checked)
            {
                pnCustomer.Visible = true; 
            }
            else
            {
                pnCustomer.Visible = false;
            }
        }
        private void LoadSeats(List<TicketDTO> list)
        {
            flowLayoutPanel1.Controls.Clear();         
            for (int i = 0; i < list.Count; i++)
            {
                Button btnSeat = new Button() { Width = SIZE + 25, Height = SIZE };
                btnSeat.Text = list[i].SeatName;
                if (list[i].Status == 1)
                    btnSeat.BackColor = Color.Gray;
                else
                    btnSeat.BackColor = Color.White;
                btnSeat.Click += BtnSeat_Click; ;
                flowLayoutPanel1.Controls.Add(btnSeat);

                btnSeat.Tag = list[i];
            }
        }

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btnSeat = sender as Button;
            if (btnSeat.BackColor == Color.White)
            {
                groupLoaiVe.Enabled = true;
                radNguoiLon.Checked = true;


                btnSeat.BackColor = Color.Red;
                TicketDTO ticket = btnSeat.Tag as TicketDTO;

                ticket.Price = ticketPrice;
                displayPrice = ticket.Price;
                total += ticketPrice;
                payment = total - discount;
                ticket.Type = 1;

                listSeatSelected.Add(btnSeat);
                plusPoint++;
                lblPlusPoint.Text = plusPoint + "";
            }
            else if (btnSeat.BackColor == Color.Red)
            {
                btnSeat.BackColor = Color.White;
                TicketDTO ticket = btnSeat.Tag as TicketDTO;

                total -= ticket.Price;
                payment = total - discount;
                ticket.Price = 0;
                displayPrice = ticket.Price;
                ticket.Type = 0;

                listSeatSelected.Remove(btnSeat);
                plusPoint--;
                lblPlusPoint.Text = plusPoint + "";
                groupLoaiVe.Enabled = false;
            }
            else if (btnSeat.BackColor == Color.Gray)
            {
                MessageBox.Show("Ghế số [" + btnSeat.Text + "] đã có người mua");
            }
            LoadBill();
            if (listSeatSelected.Count > 0)
            {
                chkKhachHangThanhVien.Enabled = true;

            }
            else
            {
                chkKhachHangThanhVien.Enabled = false;
            }
        }

        private void LoadDataPC(string cinemaName)
        {
            PhongChieuDTO cinema = QLBLL.Instance.GetPCBYID(cinemaName);
            int Row = cinema.SoHangGhe;
            int Column = cinema.SoGhe1Hang;
            flowLayoutPanel1.Size = new Size((SIZE + 25 + GAP) * Column, (SIZE + GAP) * Row);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn hủy tất cả những vé đã chọn ko?",
                "Hủy Mua Vé", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            foreach (Button btn in listSeatSelected)
            {
                btn.BackColor = Color.White;
            }
            CreateGiaTri();
            this.OnLoad(new EventArgs());
        }
        private void CreateGiaTri()
        {
            listSeatSelected.Clear();

            radNguoiLon.Checked = true;
            groupLoaiVe.Enabled = false;
            chkKhachHangThanhVien.Checked = false;
            chkKhachHangThanhVien.Enabled = false;

            ShowOrHideTichThuong();

            total = 0;
            displayPrice = 0;
            discount = 0;
            payment = 0;
            plusPoint = 0;

            LoadBill();
        }
        private void LoadBill()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            txtGiaVe.Text = displayPrice.ToString("c", culture);
            txtTongTien.Text = total.ToString("c", culture);
            txtTienGiam.Text = discount.ToString("c", culture);
            txtSoTienPhaiTra.Text = payment.ToString("c", culture);
        }
        private void radSV_Click(object sender, EventArgs e)
        {
            if(radSV.Checked)
            {
                if (listSeatSelected.Count == 0) return;
                TicketDTO ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as TicketDTO;
                ticket.Type = 2;

                float oldPrice = ticket.Price;
                ticket.Price = 0.8f * ticketPrice;
                displayPrice = ticket.Price;
                total += ticket.Price - oldPrice;
                payment = total - discount;

                LoadBill();
            }    
        }

      

        private void chkKhachHangThanhVien_Click(object sender, EventArgs e)
        {
            if(chkKhachHangThanhVien.Checked)
            {
                frmKhachHang frm = new frmKhachHang();
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    customer = frm.customer;
                    lblCustomerName.Text = customer.Ten;
                    lblPoint.Text = customer.DiemTichLuy + "";
                    ShowOrHideTichThuong();
                }
                else
                {
                    chkKhachHangThanhVien.Checked = false;
                }
            }
            else
            {
                ShowOrHideTichThuong();
                customer = null;
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(listSeatSelected.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vé trước khi thanh toán ! \n");
                return;
            }
            string message = "Bạn có chắc chắn mua những vé : \n";
            foreach(Button btn in listSeatSelected)
            {
                message += "[" +btn.Text + "] ";
            }
            message += "\nKhông?";
            DialogResult result = MessageBox.Show(message, "Hỏi Mua",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                int ret = 0;
                if (chkKhachHangThanhVien.Checked == true)
                {
                    foreach(Button btn in listSeatSelected)
                    {
                        btn.Enabled = true;
                        TicketDTO ticket = btn.Tag as TicketDTO;
                        ret += QLBLL.Instance.BuyTicket(ticket.ID, ticket.Type, customer.ID, ticket.Price);
                    }
                    customer.DiemTichLuy += plusPoint;
                    QLBLL.Instance.UpdatePointCustomer(customer.ID, customer.DiemTichLuy);
                }
                else
                {
                    foreach(Button btn in listSeatSelected)
                    {
                        btn.Enabled = true;
                        TicketDTO ticket = btn.Tag as TicketDTO;

                        ret+= QLBLL.Instance.BuyTicket(ticket.ID,ticket.Type,ticket.Price);

                    }
                }
                if(ret == listSeatSelected.Count)
                {
                    MessageBox.Show("Bạn đã mua vé thành công!");
                }
                CreateGiaTri();
                this.OnLoad(new EventArgs());
            }
        }

        private void radNguoiLon_Click(object sender, EventArgs e)
        {
            if (radNguoiLon.Checked)
            {
                if (listSeatSelected.Count == 0) return;
                TicketDTO ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as TicketDTO;
                ticket.Type = 1;

                float oldPrice = ticket.Price;
                ticket.Price = ticketPrice;
                displayPrice = ticket.Price;
                total += ticket.Price - oldPrice;
                payment = total - discount;

                LoadBill();
            }

        }

        private void radTreEm_Click(object sender, EventArgs e)
        {
            if (radTreEm.Checked)
            {
                if (listSeatSelected.Count == 0) return;
                TicketDTO ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as TicketDTO;
                ticket.Type = 3;

                float oldPrice = ticket.Price;
                ticket.Price = 0.6f * ticketPrice;
                displayPrice = ticket.Price;
                total += ticket.Price - oldPrice;
                payment = total - discount;

                LoadBill();
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void groupLoaiVe_Enter(object sender, EventArgs e)
        {

        }

        private void txtGiaVe_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radSV_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radTreEm_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radNguoiLon_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void pnCustomer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericFreeTickets_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnFreeTicket_Click(object sender, EventArgs e)
        {
            int freeTickets = (int)numericFreeTickets.Value;
            if (freeTickets <= 0) return;

            if (freeTickets > listSeat.Count)
            {
                MessageBox.Show("BẠN CHỈ ĐỔI ĐƯỢC TỐT ĐA [" + listSeatSelected.Count + "] VÉ", "THÔNG BÁO");
                return;
            }
            int pointFreeTicket = freeTickets * 20;
            if ((customer.DiemTichLuy) < pointFreeTicket)
            {
                MessageBox.Show("BẠN KHÔNG ĐỦ ĐIỂM TÍCH LŨY ĐỂ ĐỔI [" + freeTickets + "] VÉ", "THÔNG BÁO");
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("BẠN CÓ MUỐN DÙNG ĐIỂM TÍCH LŨY ĐỂ ĐỔI [" + freeTickets + "] VÉ MIỄN PHÍ KHÔNG?",
                                        "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    (customer.DiemTichLuy) -= pointFreeTicket;
                    plusPoint -= freeTickets;

                    if (QLBLL.Instance.UpdatePointCustomer(customer.ID, customer.DiemTichLuy))
                    {
                        MessageBox.Show("BẠN ĐÃ DỔI ĐƯỢC [" + freeTickets + "] VÉ MIỄN PHÍ THÀNH CÔNG", "THÔNG BÁO");
                    }
                    lblPoint.Text = "" + customer.DiemTichLuy;
                    lblPlusPoint.Text = "" + plusPoint;

                    for (int i = 0; i < listSeatSelected.Count && freeTickets > 0; i++)
                    {
                        TicketDTO ticket = listSeatSelected[i].Tag as TicketDTO;
                        if (ticket.Price != 0)
                        {
                            discount += ticket.Price;
                            ticket.Price = 0;
                            freeTickets--;
                        }
                    }

                    payment = total - discount;
                    LoadBill();
                }
            }
        }

        private void lblPlusPoint_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblCustomerName_Click(object sender, EventArgs e)
        {

        }

        private void lblPoint_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void chkKhachHangThanhVien_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtSoTienPhaiTra_Click(object sender, EventArgs e)
        {

        }

        private void txtTienGiam_Click(object sender, EventArgs e)
        {

        }

        private void txtTongTien_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer4_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}