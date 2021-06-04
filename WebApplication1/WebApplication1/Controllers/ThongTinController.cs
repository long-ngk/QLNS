using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ThongTinController : Controller
    {
        QLNhanSuEntities db = new QLNhanSuEntities();
        // GET: ThongTin
        public ActionResult ThongTinTaiKhoan()
        {
          
            return View();
        }
        public ActionResult DoiMatKhau()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoiMatKhau(ChangePassword changePass)
        {
            string tenTK = Session["TenTK"].ToString();
            var taiKhoan = db.TaiKhoans.Where(x => x.TenTK == tenTK).SingleOrDefault();
            if (ModelState.IsValid)
            {
                if (taiKhoan != null)
                {
                    if (taiKhoan.MatKhau == changePass.MatKhauCu)
                    {
                        if (ModelState.IsValid)
                        {
                            taiKhoan.MatKhau = changePass.MatKhauMoi;
                            db.SaveChanges();
                            this.AddNotification("Đổi mật khẩu thành công", NotificationType.SUCCESS);
                            return View();
                        }
                        return View(changePass);
                    }
                    else
                    {
                        this.AddNotification("Mật khẩu cũ không đúng", NotificationType.ERROR);
                        return View(changePass);
                    }
                }
            }
            return View();
        }
        public ActionResult XemThongTinCaNhan()
        {
            string tenTK = Session["TenTK"].ToString();
            int maNV = Convert.ToInt32(Session["MaNhanVien"]);
            var taiKhoan = db.TaiKhoans.Where(x => x.TenTK == tenTK).SingleOrDefault();
            if (taiKhoan != null)
            {
                NhanVien nhanVien = db.NhanViens.Where(x => x.MaNhanVien == taiKhoan.MaNhanVien).SingleOrDefault();
                if (nhanVien != null)
                {
                    return View(nhanVien);
                }
            }
            return RedirectToAction("ThongTinTaiKhoan");
        }

    }
}