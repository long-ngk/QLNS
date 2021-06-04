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
    public class PhongBanController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: PhongBan
        public ActionResult Index()
        {
            return View(db.PhongBans.Where(x=>x.MaPB != 12).OrderBy(x => x.TenPB).ToList());
        }

        public ActionResult Search(string loaiTimKiem, string tenTimKiem)
        {
            QLNhanSuEntities db = new QLNhanSuEntities();
            List<PhongBan> phongBans = db.PhongBans.ToList();
            if (loaiTimKiem == "MaPhongBan")
            {
                if (tenTimKiem == null || tenTimKiem == "")
                {
                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã phòng ban!", NotificationType.WARNING);
                }
               
                return View("Index", db.PhongBans.Where(x => x.MaPB.ToString().Contains(tenTimKiem.ToString()) && x.MaPB != 12 || tenTimKiem == null).OrderBy(x=>x.TenPB).ToList());
            }
            else
            {
                if (tenTimKiem == null || tenTimKiem == "")
                {
                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên phòng ban!", NotificationType.WARNING);
                }
                return View("Index", db.PhongBans.Where(x => x.TenPB.Contains(tenTimKiem.ToString()) && x.MaPB != 12 || tenTimKiem == null).OrderBy(x => x.TenPB).ToList());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(List<PhongBan> phongBans)
        {
            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                var checkIsChecked = phongBans.Where(x => x.IsChecked == true).SingleOrDefault();
                if (checkIsChecked == null)
                {
                    this.AddNotification("Vui lòng chọn phòng ban để xóa!", NotificationType.ERROR);
                    return RedirectToAction("Index");
                }
                foreach (var item in phongBans)
                {
                    if (item.IsChecked == true)
                    {
                        int maPhongBan = item.MaPB;
                        PhongBan phongBan = db.PhongBans.Where(x => x.MaPB == maPhongBan).SingleOrDefault();
                        if (phongBan != null)
                        {
                            db.PhongBans.Remove(phongBan);
                            db.SaveChanges();
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                this.AddNotification("Không thể xóa vì phòng ban này đã và đang được sử dụng!", NotificationType.ERROR);
                return RedirectToAction("Index");
            }
        }
        // GET: PhongBan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongBan phongBan = db.PhongBans.Find(id);
            if (phongBan == null)
            {
                return HttpNotFound();
            }
            return View(phongBan);
        }

        // GET: PhongBan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhongBan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPB,TenPB,SoDT,NguoiSua,NgaySua")] PhongBan phongBan)
        {
            if (ModelState.IsValid)
            {
                db.PhongBans.Add(phongBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phongBan);
        }

        // GET: PhongBan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongBan phongBan = db.PhongBans.Find(id);
            if (phongBan == null)
            {
                return HttpNotFound();
            }
            return View(phongBan);
        }

        // POST: PhongBan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPB,TenPB,SoDT,NguoiSua,NgaySua")] PhongBan phongBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phongBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phongBan);
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
