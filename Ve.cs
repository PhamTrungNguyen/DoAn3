//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAn
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ve
    {
        public int IDVe { get; set; }
        public Nullable<int> LoaiVe { get; set; }
        public string IDLichChieu { get; set; }
        public string MaGheNgoi { get; set; }
        public string IDKhachHang { get; set; }
        public int TrangThai { get; set; }
        public Nullable<decimal> TienBanVe { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
        public virtual LichChieu LichChieu { get; set; }
    }
}