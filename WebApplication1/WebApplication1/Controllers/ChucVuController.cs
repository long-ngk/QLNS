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
    public class ChucVuController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: ChucVu
        public ActionResult Index()
        {
            return View(db.ChucVus.ToList());
        }
        public ActionResult Search(string loaiTimKiem, string tenTimKiem)
        {
            QLNhanSuEntities db = new QLNhanSuEntities();
            List<ChucVu> chucVus = db.ChucVus.ToList();
            if (loaiTimKiem == "MaChucVu")
            {
                int tenTimKiem_int;
                int.TryParse(tenTimKiem, out tenTimKiem_int);
                return View("Index", db.ChucVus.Where(x => x.MaChucVu == tenTimKiem_int || tenTimKiem == null).ToList());
            }
            else
            {

                return View("Index", db.ChucVus.Where(x => x.TenChucVu.Contains(tenTimKiem.ToString()) || tenTimKiem == null).ToList());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(List<ChucVu> chucVus )
        {
            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                var checkIsChecked = chucVus.Where(x => x.IsChecked == true).SingleOrDefault();
                if (checkIsChecked == null)
                {
                    this.AddNotification("Vui lòng chọn chức vụ để xóa!", NotificationType.ERROR);
                    return RedirectToAction("Index");
                }

                foreach (var item in chucVus)
                {
                    if (item.IsChecked == true)
                    {
                        int maChucVu = item.MaChucVu;
                        ChucVu chucVu = db.ChucVus.Where(x => x.MaChucVu == maChucVu).SingleOrDefault();
                        if (chucVu != null)
                        {
                            db.ChucVus.Remove(chucVu);
                            db.SaveChanges();
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                this.AddNotification("Không thể xóa vì chức vụ này đã và đang được sử dụng!", NotificationType.ERROR);
                return RedirectToAction("Index");
            }
        }

        // GET: ChucVu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucVu chucVu = db.ChucVus.Find(id);
            if (chucVu == null)
            {
                return HttpNotFound();
            }
            return View(chucVu);
        }

        // GET: ChucVu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChucVu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChucVu,TenChucVu,HeSoChucVu,PhuCap,NguoiSua,NgaySua")] ChucVu chucVu)
        {
            if (ModelState.IsValid)
            {
                db.ChucVus.Add(chucVu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chucVu);
        }

        // GET: ChucVu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucVu chucVu = db.ChucVus.Find(id);
            if (chucVu == null)
            {
                return HttpNotFound();
            }
            return View(chucVu);
        }

        // POST: ChucVu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChucVu,TenChucVu,HeSoChucVu,PhuCap,NguoiSua,NgaySua")] ChucVu chucVu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chucVu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chucVu);
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
