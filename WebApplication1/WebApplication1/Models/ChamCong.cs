//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChamCong
    {
        public int MaNhanVien { get; set; }
        public System.DateTime Ngay { get; set; }
        public Nullable<System.TimeSpan> ThoiGianVao { get; set; }
        public Nullable<System.TimeSpan> ThoiGianRa { get; set; }
        public Nullable<int> ThoiGianLamViec { get; set; }
        public Nullable<int> ThoiGianTangCa { get; set; }
        public string TrangThai { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}
