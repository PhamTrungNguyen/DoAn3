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
    
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            this.Ves = new HashSet<Ve>();
        }
    
        public string idKhachHang { get; set; }
        public string HoTenKH { get; set; }
        public System.DateTime NgaySinhKH { get; set; }
        public string DiaChiKH { get; set; }
        public string SDTKH { get; set; }
        public string CMNDKH { get; set; }
        public int DiemTichLuy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ve> Ves { get; set; }
    }
}