using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public partial class TaiKhoanViewModel
    {
        [DisplayName("Mã nhân viên")]
        public int MaNhanVien { get; set; }

        [DisplayName("Tên tài khoản")]
        [Required(ErrorMessage= "Tên tài khoản không được để trống...")]
        public string TenTK { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống...")]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }

        [DisplayName("Mã quyền")]
        public int MaQuyen { get; set; }

        public virtual NhanVien NhanVien { get; set; }
        public virtual PhanQuyen PhanQuyen { get; set; }
    }
}