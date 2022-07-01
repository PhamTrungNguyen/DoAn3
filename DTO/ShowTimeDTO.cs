using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public  class ShowTimeDTO
    {
        //public string ID { get; set; }

        //public string IDLichChieu { get; set; }

        //public string LoaiVe { get; set; }

        //public string MaGheNgoi { get; set; }

        //public string IDKhachHang { get; set; }

        //public double TienBanVe { get; set; }

        //public string TrangThai { get; set; }
        public string ID { get; set; }

        public DateTime Time { get; set; }

        public string CinemaName { get; set; }

        public string FormatMovieID { get; set; }

        public string MovieName { get; set; }

        public double TicketPrice { get; set; }

        public string Status { get; set; }
    }
}
