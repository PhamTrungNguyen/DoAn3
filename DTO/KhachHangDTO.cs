using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class KhachHangDTO
    {
        public string ID { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChiKH { get; set; }
        public string SDT { get; set; }
        public string CMND { get; set; }
        public int DiemTichLuy { get; set; }
        public KhachHangDTO()
        {

        }
        public KhachHangDTO(DataRow i)
        {
            this.ID = i["idKhachHang"].ToString();
            this.Ten = i["HoTenKH"].ToString();
            this.NgaySinh = Convert.ToDateTime(i["NgaySinhKH"].ToString());
            this.SDT = i["SDTKH"].ToString();
            this.DiaChiKH = i["DiaChiKH"].ToString();
            this.CMND = i["CMNDKH"].ToString();
            this.DiemTichLuy = Convert.ToInt32(i["DiemTichLuy"]);
         }
        
    }
}
