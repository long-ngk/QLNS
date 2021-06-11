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
using Rotativa;
namespace WebApplication1.Controllers
{
    public class ThongKeLuongController : Controller
    {
        QLNhanSuEntities db = new QLNhanSuEntities();
        // GET: ThongKeLuong

        public void TruyenPara(int? month, int? year, string MaPB)
        {
            ViewBag.month = month;
            ViewBag.year = year;
            ViewBag.PB = MaPB;
        }
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
                        TruyenPara(month, year, MaPB);

                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.ThangNam.Month == month).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year != null && month == null)
                    {
                        TruyenPara(month, year, MaPB);

                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year == null && month != null)
                    {
                        TruyenPara(month, year, MaPB);

                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Month == month).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        TruyenPara(month, year, MaPB);

                        luongThangs = db.LuongThangs.OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                }
                else if (MaPB != null)
                {

                    if (year != null && month != null)
                    {
                        TruyenPara(month, year, MaPB);

                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.ThangNam.Month == month && x.LuongCoBan.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year != null && month == null)
                    {
                        TruyenPara(month, year, MaPB);

                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.LuongCoBan.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year == null && month != null)
                    {
                        TruyenPara(month, year, MaPB);

                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Month == month && x.LuongCoBan.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        TruyenPara(month, year, MaPB);

                        luongThangs = db.LuongThangs.Where(x => x.LuongCoBan.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                }
                TruyenPara(month, year, MaPB);

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


        public void TruyenPara2(int? month, int? year, string loaiTimKiem, string tenTimKiem)
        {
            ViewBag.month = month;
            ViewBag.year = year;
            ViewBag.loaiTimKiem = loaiTimKiem;
            ViewBag.tenTimKiem = tenTimKiem;
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
                        TruyenPara2(month, year, loaiTimKiem, tenTimKiem);

                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.ThangNam.Month == month && x.LuongCoBan.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year != null && month == null)
                    {
                        TruyenPara2(month, year, loaiTimKiem, tenTimKiem);

                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.LuongCoBan.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year == null && month != null)
                    {
                        TruyenPara2(month, year, loaiTimKiem, tenTimKiem);

                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Month == month && x.LuongCoBan.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        TruyenPara2(month, year, loaiTimKiem, tenTimKiem);

                        luongThangs = db.LuongThangs.Where(x => x.LuongCoBan.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }

                }
                else if (loaiTimKiem == "TenNhanVien")
                {
                    if (year != null && month != null)
                    {
                        TruyenPara2(month, year, loaiTimKiem, tenTimKiem);

                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.ThangNam.Month == month && x.LuongCoBan.NhanVien.HoTen.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year != null && month == null)
                    {
                        TruyenPara2(month, year, loaiTimKiem, tenTimKiem);

                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.LuongCoBan.NhanVien.HoTen.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year == null && month != null)
                    {
                        TruyenPara2(month, year, loaiTimKiem, tenTimKiem);

                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Month == month && x.LuongCoBan.NhanVien.HoTen.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        TruyenPara2(month, year, loaiTimKiem, tenTimKiem);

                        luongThangs = db.LuongThangs.Where(x => x.LuongCoBan.NhanVien.HoTen.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                }
                else
                {
                    if (year != null && month != null)
                    {
                        TruyenPara2(month, year, loaiTimKiem, tenTimKiem);

                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.ThangNam.Month == month).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year != null && month == null)
                    {
                        TruyenPara2(month, year, loaiTimKiem, tenTimKiem);

                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else if (year == null && month != null)
                    {
                        TruyenPara2(month, year, loaiTimKiem, tenTimKiem);

                        luongThangs = db.LuongThangs.Where(x => x.ThangNam.Month == month).OrderBy(x => x.LuongCoBan.NhanVien.HoTen);
                        return View(luongThangs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        TruyenPara2(month, year, loaiTimKiem, tenTimKiem);

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
            TempData["MaNV"] = luongThang.LuongCoBan.MaNhanVien;
            return View(luongThang);
        }

        //<<<<<<<<<<<<<<<<in ra chi tiết lương tháng của nhân viên
        public ActionResult Print(int? id, string maNV, int month, int year)
        {
            return new ActionAsPdf("InBangLuongThang", new { id = id }) { FileName = "Luong_MaNV_" + maNV + "_Thang_" + month + "_Nam_" + year + ".pdf" };
        }
        public ActionResult InBangLuongThang(int? id)
        {
            LuongThang luongThang = db.LuongThangs.Find(id);
            return View(luongThang);
        }
        //in ra chi tiết lương tháng của nhân viên>>>>>>>>>>>>>>>>>

        //<<<<<<<<<<<<<<<<in ra danh sách lương tháng của nhiều nhân viên
        public ActionResult PrintLuongTheoPhongBan(int? month, int? year, int? MaPB)
        {
            if (MaPB == 12)
            {
                return new ActionAsPdf("DSLuongTheoPhongBan", new { month, year, MaPB }) { FileName = "LuongTheoPhongBan_Thang_" + month + "_Nam_" + year + "_PhongBan_TatCa.pdf" };
            }
            else
            {
                LuongThang luong = new LuongThang();
                luong = db.LuongThangs.FirstOrDefault();
                string tenPB = luong.LuongCoBan.NhanVien.PhongBan.TenPB;
                return new ActionAsPdf("DSLuongTheoPhongBan", new { month, year, MaPB }) { FileName = "LuongTheoPhongBan_Thang_" + month + "_Nam_" + year + "_PhongBan_" + tenPB + ".pdf" };
            }
        }

        public void TruyenViewBagPhongBan(int? month, int? year, int? MaPB)
        {
            ViewBag.month = month;
            ViewBag.year1 = year;
            if (MaPB == 12)
            {
                ViewBag.TenPB = "Tất cả";
            }
            else
            {
                LuongThang luongThang = new LuongThang();
                if (year != null && month != null)
                {
                    luongThang = db.LuongThangs.Where(x => x.ThangNam.Month == month && x.ThangNam.Year == year).FirstOrDefault();
                    ViewBag.TenPB = luongThang.LuongCoBan.NhanVien.PhongBan.TenPB.ToString();
                }
                else if (year != null && month == null)
                {
                    luongThang = db.LuongThangs.Where(x => x.ThangNam.Year == year).FirstOrDefault();
                    ViewBag.TenPB = luongThang.LuongCoBan.NhanVien.PhongBan.TenPB.ToString();

                }
                else if (year == null && month != null)
                {
                    luongThang = db.LuongThangs.Where(x => x.ThangNam.Month == month).FirstOrDefault();
                    ViewBag.TenPB = luongThang.LuongCoBan.NhanVien.PhongBan.TenPB.ToString();
                }
                luongThang = db.LuongThangs.FirstOrDefault();
                ViewBag.TenPB = luongThang.LuongCoBan.NhanVien.PhongBan.TenPB.ToString();
            }
        }
        public ActionResult DSLuongTheoPhongBan(int? month, int? year, int? MaPB)
        {
            List<LuongThang> luongThangs;
            if (MaPB == 12)
            {
                if (year != null && month != null)
                {
                    TruyenViewBagPhongBan(month, year, MaPB);


                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Month == month && x.ThangNam.Year == year).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
                else if (year != null && month == null)
                {
                    TruyenViewBagPhongBan(month, year, MaPB);

                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
                else if (year == null && month != null)
                {
                    TruyenViewBagPhongBan(month, year, MaPB);

                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Month == month).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
                luongThangs = db.LuongThangs.OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                return View(luongThangs);

            }
            else if (MaPB != 12)
            {
                if (year != null && month != null)
                {
                    TruyenViewBagPhongBan(month, year, MaPB);

                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Month == month && x.ThangNam.Year == year && x.LuongCoBan.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
                else if (year != null && month == null)
                {
                    TruyenViewBagPhongBan(month, year, MaPB);

                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.LuongCoBan.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
                else if (year == null && month != null)
                {
                    TruyenViewBagPhongBan(month, year, MaPB);

                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Month == month && x.LuongCoBan.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
                luongThangs = db.LuongThangs.Where(x => x.LuongCoBan.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                return View(luongThangs);
            }
            luongThangs = db.LuongThangs.OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
            return View(luongThangs);
        }
        //in ra danh sách lương tháng của nhiều nhân viên>>>>>>>>>>>>

        public void TruyenViewBagNhanVien(int? month, int? year, string loaiTimKiem, string tenTimKiem)
        {
            ViewBag.month = month;
            ViewBag.year = year;
            ViewBag.loaiTimKiem = loaiTimKiem;
            ViewBag.tenTimKiem = tenTimKiem;

        }
        public ActionResult PrintLuongTheoNhanVien(int? month, int? year, string loaiTimKiem, string tenTimKiem)
        {
            //if (loaiTimKiem == "MaNhanVien")
            //{
            //    if (year != null && month != null)
            //    {
            //        return new ActionAsPdf("DSLuongTheoNhanVien", new { month, year, loaiTimKiem, tenTimKiem }) { FileName = "LuongTheoNhanVien_Thang_" + month + "_Nam_" + year + "_PhongBan_TatCa.pdf" };
            //    }
            //    else if (year != null && month == null)
            //    {

            //    }
            //    else if (year == null && month != null)
            //    {

            //    }
            //    else
            //    {

            //    }
            //        return new ActionAsPdf("DSLuongTheoNhanVien", new { month, year, MaPB }) { FileName = "LuongTheoPhongBan_Thang_" + month + "_Nam_" + year + "_PhongBan_TatCa.pdf" };
            //}
            //else if (loaiTimKiem == "TenNhanVien")
            //{
            //    LuongThang luong = new LuongThang();
            //    luong = db.LuongThangs.FirstOrDefault();
            //    string tenPB = luong.LuongCoBan.NhanVien.PhongBan.TenPB;
            //    return new ActionAsPdf("DSLuongTheoPhongBan", new { month, year, MaPB }) { FileName = "LuongTheoPhongBan_Thang_" + month + "_Nam_" + year + "_PhongBan_" + tenPB + ".pdf" };
            //}
            return new ActionAsPdf("DSLuongTheoNhanVien", new { month, year, loaiTimKiem, tenTimKiem }) { FileName = "LuongTheoNhanVien_Thang_" + month + "_Nam_" + year + "_LoaiTimKiem_" + loaiTimKiem + "_TenTimKiem_" + tenTimKiem + ".pdf" };
        }


        public ActionResult DSLuongTheoNhanVien(int? month, int? year, string loaiTimKiem, string tenTimKiem)
        {
            List<LuongThang> luongThangs;
            if (loaiTimKiem == "MaNhanVien")
            {
                if (year != null && month != null)
                {
                    TruyenViewBagNhanVien(month, year, loaiTimKiem, tenTimKiem);

                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.ThangNam.Month == month && x.LuongCoBan.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
                else if (year != null && month == null)
                {
                    TruyenViewBagNhanVien(month, year, loaiTimKiem, tenTimKiem);

                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.LuongCoBan.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
                else if (year == null && month != null)
                {
                    TruyenViewBagNhanVien(month, year, loaiTimKiem, tenTimKiem);

                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Month == month && x.LuongCoBan.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
                else
                {
                    TruyenViewBagNhanVien(month, year, loaiTimKiem, tenTimKiem);

                    luongThangs = db.LuongThangs.Where(x => x.LuongCoBan.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
            }
            else if (loaiTimKiem == "TenNhanVien")
            {
                if (year != null && month != null)
                {
                    TruyenViewBagNhanVien(month, year, loaiTimKiem, tenTimKiem);

                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.ThangNam.Month == month && x.LuongCoBan.NhanVien.HoTen.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
                else if (year != null && month == null)
                {
                    TruyenViewBagNhanVien(month, year, loaiTimKiem, tenTimKiem);

                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.LuongCoBan.NhanVien.HoTen.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
                else if (year == null && month != null)
                {
                    TruyenViewBagNhanVien(month, year, loaiTimKiem, tenTimKiem);

                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Month == month && x.LuongCoBan.NhanVien.HoTen.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
                else
                {
                    TruyenViewBagNhanVien(month, year, loaiTimKiem, tenTimKiem);

                    luongThangs = db.LuongThangs.Where(x => x.LuongCoBan.NhanVien.HoTen.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
            }
            else
            {
                if (year != null && month != null)
                {
                    TruyenViewBagNhanVien(month, year, loaiTimKiem, tenTimKiem);

                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year && x.ThangNam.Month == month).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
                else if (year != null && month == null)
                {
                    TruyenViewBagNhanVien(month, year, loaiTimKiem, tenTimKiem);

                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Year == year).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
                else if (year == null && month != null)
                {
                    TruyenViewBagNhanVien(month, year, loaiTimKiem, tenTimKiem);

                    luongThangs = db.LuongThangs.Where(x => x.ThangNam.Month == month).OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
                else
                {
                    TruyenViewBagNhanVien(month, year, loaiTimKiem, tenTimKiem);

                    luongThangs = db.LuongThangs.OrderBy(x => x.LuongCoBan.NhanVien.HoTen).ToList();
                    return View(luongThangs);
                }
            }
        }

    }
}