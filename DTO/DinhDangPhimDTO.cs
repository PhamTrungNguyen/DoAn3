using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public  class DinhDangPhimDTO
    {
        public DinhDangPhimDTO(DataRow row)
        {
            this.ID_DinhDangPhim = row["ID_DinhDangPhim"].ToString();
            this.ID_LoaiManHinh = row["ID_LoaiManHinh"].ToString();
            this.MovieName = row["MovieName"].ToString();
            this.LMH = row["LMH"].ToString();
            this.ID_Phim = row["ID_Phim"].ToString();
        }
        public DinhDangPhimDTO()
        { }
        public string ID_DinhDangPhim { get; set; }
        public string ID_Phim { get; set; }
        public string MovieName { get; set; }
        public string ID_LoaiManHinh { get; set; }
        public string LMH { get; set; }
    }
}
