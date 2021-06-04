using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xunit.Sdk;

namespace WebApplication1.Models
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "Nhập mật khẩu cũ", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string MatKhauCu { get; set; }
        [Required(ErrorMessage = "Nhập mật khẩu mới", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*\d).{5,25}$", ErrorMessage = "Mật khẩu bao gồm chữ và số, từ 5 đến 25 kí tự")]
        public string MatKhauMoi { get; set; }

        [Required(ErrorMessage = "Nhập xác nhận mật khẩu", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Compare("MatKhauMoi", ErrorMessage = "Xác nhận mật khẩu không khớp mật khẩu mới")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*\d).{5,25}$", ErrorMessage = "Mật khẩu bao gồm chữ và số, từ 5 đến 25 kí tự")]
        public string XacNhanMatKhau { get; set; }
    }
}