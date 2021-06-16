﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class LoaiPhat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiPhat()
        {
            this.Ct_Phat = new HashSet<Ct_Phat>();
        }

        [DisplayName("Mã loại phạt")]
        public int MaLoaiPhat { get; set; }
        [DisplayName("Tên loại phạt")]
        [Required(ErrorMessage = "Tên loại phạt không được trống...")]
        public string TenLoaiPhat { get; set; }
        [DisplayName("Giá trị")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Vui lòng nhập số nguyên...")]
        [Required(ErrorMessage = "Giá trị không được trống...")]
        public int GiaTri { get; set; }
        [DisplayName("Trạng thái")]
        public bool TrangThai { get; set; }
        [DisplayName("Người sửa")]
        public string NguoiSua { get; set; }
        [DisplayName("Ngày sửa")]
        public System.DateTime NgaySua { get; set; }
        public bool IsChecked { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ct_Phat> Ct_Phat { get; set; }
    }
}
