using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        QLNS_1Entities database = new QLNS_1Entities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CheckLogin(TaiKhoan taiKhoan)
        {
            var check = database.TaiKhoans.Where(s => s.TenTK == taiKhoan.TenTK && s.MatKhau == taiKhoan.MatKhau).SingleOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfo = "Sai thông tin";
                return View("Login");
            }
            else
            {
                database.Configuration.ValidateOnSaveEnabled = false;
                Session["TenTK"] = taiKhoan.TenTK;
                Session["MatKhau"] = taiKhoan.MatKhau;
                return RedirectToAction("ListEmployee", "Home");
            }
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}