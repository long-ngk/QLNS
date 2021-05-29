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

namespace WebApplication1.Controllers
{
    public class TaiKhoanController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: TaiKhoan
        public ActionResult Index()
        {
            var taiKhoans = db.TaiKhoans.Include(t => t.NhanVien).Include(t => t.PhanQuyen).OrderByDescending(t => t.PhanQuyen.TenQuyen);
            return View(taiKhoans.ToList());
        }

        public ActionResult Search(string loaiTimKiem, string tenTimKiem)
        {
            QLNhanSuEntities db = new QLNhanSuEntities();
            List<TaiKhoan> taiKhoans = db.TaiKhoans.ToList();
            if (loaiTimKiem == "TenTK")
            {
                return View("Index", db.TaiKhoans.Where(x => x.TenTK.Contains(tenTimKiem) || tenTimKiem == null).OrderByDescending(x => x.PhanQuyen.TenQuyen).ToList());
            }
            else
            {
                return View("Index", db.TaiKhoans.Where(x => x.PhanQuyen.TenQuyen.Contains(tenTimKiem.ToString()) || tenTimKiem == null).OrderByDescending(x => x.PhanQuyen.TenQuyen).ToList());
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
        public ActionResult Edit([Bind(Include = "MaNhanVien,TenTK,MatKhau,MaQuyen")] TaiKhoan taiKhoan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(taiKhoan).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", taiKhoan.MaNhanVien);
                ViewBag.MaQuyen = new SelectList(db.PhanQuyens.Where(a => a.MaQuyen != 3), "MaQuyen", "TenQuyen", taiKhoan.MaQuyen);
                return View(taiKhoan);
            }catch
            {
                this.AddNotification("Vui lòng nhập đủ thông tin...", NotificationType.ERROR);
                ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", taiKhoan.MaNhanVien);
                ViewBag.MaQuyen = new SelectList(db.PhanQuyens.Where(a => a.MaQuyen != 3), "MaQuyen", "TenQuyen", taiKhoan.MaQuyen);
                return View(taiKhoan);
            }
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
