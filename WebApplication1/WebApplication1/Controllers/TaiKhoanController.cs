using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Extensions;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Controllers
{
    public class TaiKhoanController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: TaiKhoan
        public ActionResult Index(string loaiTimKiem, string tenTimKiem, int? page)
        {
            IQueryable<TaiKhoan> taiKhoans;
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            try
            {
                if (loaiTimKiem == "TenTK")
                {
                    if (tenTimKiem == "" || tenTimKiem == null)
                    {
                        this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên tài khoản!", NotificationType.WARNING);
                    }
                    taiKhoans = db.TaiKhoans.Where(x => x.TenTK.Contains(tenTimKiem.ToString())).Include(t => t.NhanVien).Include(t => t.PhanQuyen).OrderBy(t => t.NhanVien.HoTen);
                    return View("Index", taiKhoans.ToList().ToPagedList(pageNumber, pageSize));

                }
                else if (loaiTimKiem == "MaNhanVien")
                {
                    if (tenTimKiem == "" || tenTimKiem == null)
                    {
                        this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                    }
                    taiKhoans = db.TaiKhoans.Where(x => x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(t => t.NhanVien).Include(t => t.PhanQuyen).OrderBy(t => t.NhanVien.HoTen);
                    return View("Index", taiKhoans.ToList().ToPagedList(pageNumber, pageSize));

                }
                else if (loaiTimKiem == "TenQuyen")
                {
                    if (tenTimKiem == "" || tenTimKiem == null)
                    {
                        this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên quyền!", NotificationType.WARNING);
                    }
                    taiKhoans = db.TaiKhoans.Where(x => x.PhanQuyen.TenQuyen.Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                    return View("Index", taiKhoans.ToList().ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    taiKhoans = db.TaiKhoans.Include(t => t.NhanVien).Include(t => t.PhanQuyen).OrderBy(t => t.NhanVien.HoTen);
                    return View("Index", taiKhoans.ToList().ToPagedList(pageNumber, pageSize));
                }
            }
            catch
            {
                taiKhoans = db.TaiKhoans.Where(x => x.PhanQuyen.TenQuyen.Contains("-*/+-*/*-++//*")).Include(t => t.NhanVien).Include(t => t.PhanQuyen).OrderBy(t => t.PhanQuyen.TenQuyen);
                this.AddNotification("Không tìm thấy từ khóa yêu cầu. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                return View("Index", taiKhoans.ToList().ToPagedList(pageNumber, pageSize));
            }
        }

        // GET: TaiKhoan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // GET: TaiKhoan/Create
        public ActionResult Create()
        {

            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen");
            ViewBag.MaQuyen = new SelectList(db.PhanQuyens.Where(a => a.MaQuyen != 3), "MaQuyen", "TenQuyen");
            return View();
        }

        // POST: TaiKhoan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhanVien,TenTK,MatKhau,MaQuyen")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.TaiKhoans.Add(taiKhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", taiKhoan.MaNhanVien);
            ViewBag.MaQuyen = new SelectList(db.PhanQuyens, "MaQuyen", "TenQuyen", taiKhoan.MaQuyen);
            return View(taiKhoan);
        }

        // GET: TaiKhoan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", taiKhoan.MaNhanVien);
            ViewBag.MaQuyen = new SelectList(db.PhanQuyens.Where(a => a.MaQuyen != 3), "MaQuyen", "TenQuyen", taiKhoan.MaQuyen);
            return View(taiKhoan);
        }

        // POST: TaiKhoan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhanVien,TenTK,MatKhau,MaQuyen,ResetPasswordCode")] TaiKhoan taiKhoan)
        {
            //try
            //{
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", taiKhoan.MaNhanVien);
            ViewBag.MaQuyen = new SelectList(db.PhanQuyens.Where(a => a.MaQuyen != 3), "MaQuyen", "TenQuyen", taiKhoan.MaQuyen);
            return View(taiKhoan);
            //}catch
            //{
            //    this.AddNotification("Vui lòng nhập đủ thông tin...", NotificationType.ERROR);
            //    ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", taiKhoan.MaNhanVien);
            //    ViewBag.MaQuyen = new SelectList(db.PhanQuyens.Where(a => a.MaQuyen != 3), "MaQuyen", "TenQuyen", taiKhoan.MaQuyen);
            //    return View(taiKhoan);
            //}
        }

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
