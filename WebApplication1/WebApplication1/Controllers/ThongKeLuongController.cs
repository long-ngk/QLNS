using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using PagedList;
using PagedList.Mvc;
using WebApplication1.Extensions;
using System.Net;

namespace WebApplication1.Controllers
{
    public class ThongKeLuongController : Controller
    {
        QLNhanSuEntities db = new QLNhanSuEntities();
        // GET: ThongKeLuong

        public ActionResult TheoPhongBan(int? page, int? month, int? year, string MaPB)
        {
            ViewBag.MaPB = new SelectList(db.PhongBans.OrderByDescending(x => x.TenPB), "MaPB", "TenPB", "12");
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            IQueryable<LuongThang> luongThangs;
            try
            {
                if (MaPB == "12")
                {

                    if (year != null && month != null)
                    {
                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.ThangNam.Month == month).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year != null && month == null)
                    {
                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.ThangNam.Month == month).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                }
                else if (MaPB != null)
                {

                    if (year != null && month != null)
                    {
                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.ThangNam.Month == month && x.LuongCoBan.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year != null && month == null)
                    {
                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.LuongCoBan.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.ThangNam.Month == month && x.LuongCoBan.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                }
                luongThangs = db.LuongThangs.OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
            }
            catch
            {
                this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện lại!", NotificationType.ERROR);
                luongThangs = db.LuongThangs.OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
            }
        }

        [HttpGet]
        public ActionResult TheoNhanVien(int? page, int? month, int? year, string loaiTimKiem, string tenTimKiem)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            IQueryable<LuongThang> luongThangs;
            try
            {
                if (loaiTimKiem == "MaNhanVien")
                {
                    if (year != null && month != null)
                    {
                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.ThangNam.Month == month && x.LuongCoBan.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year != null && month == null)
                    {
                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.LuongCoBan.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year == null && month != null)
                    {
                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Month == month && x.LuongCoBan.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        luongThangs = db.LuongThangs.Where(x => x.LuongCoBan.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }

                }
                else if (loaiTimKiem == "TenNhanVien")
                {
                    if (year != null && month != null)
                    {
                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.ThangNam.Month == month && x.LuongCoBan.NhanVien.HoTen.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year != null && month == null)
                    {
                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.LuongCoBan.NhanVien.HoTen.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year == null && month != null)
                    {

                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Month == month && x.LuongCoBan.NhanVien.HoTen.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        luongThangs = db.LuongThangs.Where(x => x.LuongCoBan.NhanVien.HoTen.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                }
                else
                {
                    if (year != null && month != null)
                    {
                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.ThangNam.Month == month).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year != null && month == null)
                    {
                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year == null && month != null)
                    {

                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Month == month).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        luongThangs = db.LuongThangs.OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                }
            }
            catch
            {
                this.AddNotification("Không tìm thấy từ khóa yêu cầu. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                luongThangs = db.LuongThangs;
                return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
            }

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LuongThang luongThang = db.LuongThangs.Find(id);
            if (luongThang == null)
            {
                return HttpNotFound();
            }
            return View(luongThang);
        }
    }
}