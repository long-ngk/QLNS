using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    public class TaiKhoanViewModel
    {
        [DisplayName("Mã nhân viên")]
        public int MaNhanVien { get; set; }

        [DisplayName("Tên tài khoản")]
        public string TenTK { get; set; }

        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }

        [DisplayName("Mã quyền")]
        public int MaQuyen { get; set; }

        public virtual NhanVien NhanVien { get; set; }
        public virtual PhanQuyen PhanQuyen { get; set; }
    }
}