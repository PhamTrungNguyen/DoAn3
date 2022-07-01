using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class CBBNhanVien
    {
        public string value { get; set; }
        public string text { get; set; }
        public override string ToString()
        {
            return value;
        }
    }
}
