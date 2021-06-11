using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Extensions;
using PagedList;
namespace WebApplication1.Controllers
{
    public class ChamCongController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: ChamCong
        public ActionResult Index(int? page, DateTime? fromDate, DateTime? toDate, string MaPB, string loaiTimKiem, string tenTimKiem)
        {
            ViewBag.MaPB = new SelectList(db.PhongBans.OrderByDescending(x => x.TenPB), "MaPB", "TenPB", "12");
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            IQueryable<ChamCong> chamCongs;
            try
            {
                if (MaPB == "12")
                {
                    if (fromDate > toDate)
                    {
                        this.AddNotification("Ngày bắt đầu không lớn hơn ngày kết thúc!", NotificationType.ERROR);
                        chamCongs = db.ChamCongs.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/")).OrderBy(x => x.NhanVien.HoTen);
                        return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        if (fromDate == null && toDate == null)
                        {
                            if (loaiTimKiem == "MaNhanVien")
                            {
                                if(tenTimKiem == null || tenTimKiem == "")
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                                }
                                chamCongs = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(n => n.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                                return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
                            }
                            else if (loaiTimKiem == "TenNhanVien")
                            {
                                if (tenTimKiem == null || tenTimKiem == "")
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                                }
                                chamCongs = db.ChamCongs.Where(x => x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(n => n.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                                return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
                            }
                            else
                            {
                                chamCongs = db.ChamCongs.Include(n => n.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                                return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
                            }
                        }
                        else
                        {
                            if (loaiTimKiem == "MaNhanVien")
                            {
                                if (tenTimKiem == null || tenTimKiem == "")
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                                }
                                chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate && x.Ngay <= toDate && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(n => n.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                                return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
                            }
                            else if (loaiTimKiem == "TenNhanVien")
                            {
                                if (tenTimKiem == null || tenTimKiem == "")
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                                }
                                chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate && x.Ngay <= toDate && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(n => n.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                                return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
                            }
                            else 
                            {
                                chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate && x.Ngay <= toDate).Include(n => n.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                                return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
                            }
                        }
                    }
                }
                else if(MaPB != null)
                {
                    if (fromDate > toDate)
                    {
                        this.AddNotification("Ngày bắt đầu không lớn hơn ngày kết thúc!", NotificationType.ERROR);
                        chamCongs = db.ChamCongs.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/")).OrderBy(x => x.NhanVien.HoTen);
                        return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        if (fromDate == null && toDate == null)
                        {
                            if (loaiTimKiem == "MaNhanVien")
                            {
                                if (tenTimKiem == null || tenTimKiem == "")
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                                }
                                chamCongs = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Contains(tenTimKiem.ToString()) && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                                return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
                            }
                            else if (loaiTimKiem == "TenNhanVien")
                            {
                                if (tenTimKiem == null || tenTimKiem == "")
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                                }
                                chamCongs = db.ChamCongs.Where(x => x.NhanVien.HoTen.Contains(tenTimKiem.ToString()) && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                                return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
                            }
                            else
                            {
                                chamCongs = db.ChamCongs.Where(x=> x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                                return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
                            }
                        }
                        else
                        {
                            if (loaiTimKiem == "MaNhanVien")
                            {
                                if (tenTimKiem == null || tenTimKiem == "")
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                                }
                                chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate && x.Ngay <= toDate && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString()) && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                                return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
                            }
                            else if (loaiTimKiem == "TenNhanVien")
                            {
                                if (tenTimKiem == null || tenTimKiem == "")
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                                }
                                chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate && x.Ngay <= toDate && x.NhanVien.HoTen.Contains(tenTimKiem.ToString()) && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                                return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
                            }
                            else
                            {
                                chamCongs = db.ChamCongs.Where(x => x.Ngay >= fromDate && x.Ngay <= toDate && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).Include(n => n.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                                return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
                            }
                        }

                    }
                }
                chamCongs = db.ChamCongs.Include(n => n.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
            }
            catch
            {
                this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                chamCongs = db.ChamCongs.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/")).OrderBy(x => x.NhanVien.HoTen);
                return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
            }
        }

        // GET: ChamCong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamCong chamCong = db.ChamCongs.Find(id);
            if (chamCong == null)
            {
                return HttpNotFound();
            }
            return View(chamCong);
        }

        // GET: ChamCong/Create
        //public ActionResult Create()
        //{
        //    ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen");
        //    return View();
        //}

        //// POST: ChamCong/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MaNhanVien,Ngay,ThoiGianVao,ThoiGianRa,ThoiGianLamViec,ThoiGianTangCa,TrangThai")] ChamCong chamCong)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ChamCongs.Add(chamCong);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", chamCong.MaNhanVien);
        //    return View(chamCong);
        //}

        //// GET: ChamCong/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ChamCong chamCong = db.ChamCongs.Find(id);
        //    if (chamCong == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", chamCong.MaNhanVien);
        //    return View(chamCong);
        //}

        //// POST: ChamCong/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "MaNhanVien,Ngay,ThoiGianVao,ThoiGianRa,ThoiGianLamViec,ThoiGianTangCa,TrangThai")] ChamCong chamCong)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(chamCong).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", chamCong.MaNhanVien);
        //    return View(chamCong);
        //}

        //// GET: ChamCong/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ChamCong chamCong = db.ChamCongs.Find(id);
        //    if (chamCong == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(chamCong);
        //}

        //// POST: ChamCong/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ChamCong chamCong = db.ChamCongs.Find(id);
        //    db.ChamCongs.Remove(chamCong);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
