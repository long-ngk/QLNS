using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Extensions;
using System.Net.Mail;
using System.Net;
using System.Web.Helpers;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        QLNhanSuEntities database = new QLNhanSuEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckLogin(TaiKhoan taiKhoan)
        {
            var check = database.TaiKhoans.Where(s => s.TenTK == taiKhoan.TenTK && s.MatKhau == taiKhoan.MatKhau).SingleOrDefault();
            var trangThaiLamViec = database.TaiKhoans.Where(s => s.TenTK == taiKhoan.TenTK && s.MatKhau == taiKhoan.MatKhau && s.NhanVien.TrangThai == true).SingleOrDefault();
            if (ModelState.IsValid)
            {
                if (check == null)
                {
                    this.AddNotification("Sai tên tài khoản hoặc mật khẩu!", NotificationType.ERROR);

                    return View("Login");
                }
                else
                {
                    if (trangThaiLamViec != null)
                    {
                        database.Configuration.ValidateOnSaveEnabled = false;
                        var tenNhanVien = (from a in database.TaiKhoans
                                           where a.TenTK == taiKhoan.TenTK
                                           select a.NhanVien.HoTen).SingleOrDefault();
                        if (tenNhanVien != null)
                        {
                            Session["TenNhanVien"] = tenNhanVien.ToString();
                            
                        }
                        Session["MaNhanVien"] = trangThaiLamViec.MaNhanVien;
                        Session["TenPB"] = trangThaiLamViec.NhanVien.PhongBan.TenPB;
                        Session["TenChucVu"] = trangThaiLamViec.NhanVien.ChucVu.TenChucVu;
                        Session["TenQuyen"] = trangThaiLamViec.PhanQuyen.TenQuyen;
                        Session["TenTK"] = taiKhoan.TenTK;
                        Session["MatKhau"] = taiKhoan.MatKhau;
                        switch (check.MaQuyen)
                        {
                            case 4:
                                Session["MaQuyen"] = 4;
                                return RedirectToAction("Index", "NhanVien");
                            case 3:
                                Session["MaQuyen"] = 3;
                                return RedirectToAction("Index", "TaiKhoan");
                            case 2:
                                Session["MaQuyen"] = 2;
                                return RedirectToAction("Index", "LuongCoBan");
                            case 1:
                                Session["MaQuyen"] = 1;
                                return RedirectToAction("ThongTinTaiKhoan", "ThongTin");
                            default:
                                Session["MaQuyen"] = check.MaQuyen;
                                return RedirectToAction("ThongTinTaiKhoan", "ThongTin");
                        }
                    }
                    else
                    {
                        this.AddNotification("Tài khoản đã bị vô hiệu hóa.", NotificationType.ERROR);
                        return View("Login");
                    }
                }
            }
            else
            {
                
                return View("Login");
            }
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult CheckForgotPassword(CheckTenTK_Email check, string command)
        {
            var checkTenTK = database.TaiKhoans.Where(s => s.TenTK == check.TenTK).SingleOrDefault();
            var checkEmail = database.NhanViens.Where(s => s.Email == check.Email && s.TaiKhoan.TenTK == check.TenTK).SingleOrDefault();
            if (command.Equals("Gửi mail"))
            {
                if (check.TenTK == null || check.Email == null || check.TenTK == "" || check.Email == "")
                {
                    return View("ForgotPassword");
                }
                else
                {

                    if (checkTenTK == null || checkEmail == null)
                    {
                        this.AddNotification("Sai tên tài khoản hoặc email!", NotificationType.ERROR);
                        return View("ForgotPassword");
                    }
                    else
                    {
                        string resetCode = Guid.NewGuid().ToString();
                        SendResetPasswordLinkEmail(checkEmail.Email, resetCode);
                        checkTenTK.ResetPasswordCode = resetCode;
                        this.AddNotification("Đã gửi mail. Vui lòng kiểm tra email!", NotificationType.SUCCESS);
                        
                        database.Configuration.ValidateOnSaveEnabled = false;
                        database.SaveChanges();
                        return View("ForgotPassword");
                    }
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        [NonAction]
        public void SendResetPasswordLinkEmail(string email, string resetCode)
        {
            var verifyUrl = "/Login/ResetPassword/" + resetCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("democnpmnc@gmail.com", "Long Nguyen");
            var toEmail = new MailAddress(email);
            var fromEmailPassword = "democnpmnc123";
            string subject = "Reset password";
            string body = "Chào. Nhấp vào link kế bên để cài lại mật khẩu. <a href=" + link + ">Link đây</a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            }) smtp.Send(message);
        }

        public ActionResult ResetPassword(string id)
        {
            QLNhanSuEntities database = new QLNhanSuEntities();
            var taiKhoan = database.TaiKhoans.Where(s => s.ResetPasswordCode == id).FirstOrDefault();
            if(taiKhoan != null)
            {
                ResetPasswordModel model = new ResetPasswordModel();
                model.ResetCode = id;
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = "";

            if (ModelState.IsValid)
            {
                QLNhanSuEntities database = new QLNhanSuEntities();
                var taiKhoan = database.TaiKhoans.Where(s => s.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                if(taiKhoan != null)
                {
                    taiKhoan.MatKhau = model.MatKhauMoi;
                    taiKhoan.ResetPasswordCode = "";
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.SaveChanges();
                    this.AddNotification("Mật khẩu được thay đổi thành công.", NotificationType.SUCCESS);
                }
                else
                {
                    this.AddNotification("Phiên đặt lại mật khẩu đã hết hạn. Vui lòng thử lại!", NotificationType.ERROR);
                }
            }
            else
            {
                this.AddNotification("Có gì đó sai sai...", NotificationType.ERROR);
            }
            ViewBag.Message = message;
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}