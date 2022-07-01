using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class TaiKhoanDTO
    {
        public string userName { get; set; }
        public string passWord { get; set; }
        public string loaiTK { get; set; }
        public string IDNV { get; set; }

        public TaiKhoanDTO()
        {

        }
        public TaiKhoanDTO(DataRow row)
        {
            this.userName = row["userName"].ToString();
            this.passWord = row["Pass"].ToString();
            this.loaiTK = row["loaiTK"].ToString();
            this.IDNV = row["IDNhanVien"].ToString();
        }
    }
}
