using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using PagedList;
using PagedList.Mvc;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers
{
    public class LuongCoBanController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: LuongCoBan
        public ActionResult Index(int? page, string trangThai, string MaPB, string loaiTimKiem, string tenTimKiem)
        {
            ViewBag.MaPB = new SelectList(db.PhongBans.OrderByDescending(x => x.TenPB), "MaPB", "TenPB", "12");
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            IQueryable<LuongCoBan> luongCoBans;
            try
            {
                if (trangThai == "TatCa")
                {
                    if (MaPB == "12")
                    {
                        if (loaiTimKiem == "MaNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
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
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString()) && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString()) && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            luongCoBans = db.LuongCoBans.Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString())).Include(l => l.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                }
                else if (trangThai == "HoatDong")
                {
                    if (MaPB == "12")
                    {
                        if (loaiTimKiem == "MaNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.TrangThai == true && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.TrangThai == true && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.TrangThai == true).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
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
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString()) && x.TrangThai == true && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString()) && x.TrangThai == true && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString()) && x.TrangThai == true).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                }
                else if (trangThai == "VoHieuHoa")
                {
                    if (MaPB == "12")
                    {
                        if (loaiTimKiem == "MaNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.TrangThai != true && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.TrangThai != true && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.TrangThai != true).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
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
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString()) && x.TrangThai != true && x.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else if (loaiTimKiem == "TenNhanVien")
                        {
                            if (tenTimKiem == null || tenTimKiem == "")
                            {
                                this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                            }
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString()) && x.TrangThai != true && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals(MaPB.ToString()) && x.TrangThai != true).OrderBy(x => x.NhanVien.HoTen);
                            return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                }

                luongCoBans = db.LuongCoBans.Include(l => l.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
            }
            catch
            {
                this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                luongCoBans = db.LuongCoBans.Where(x => x.NhanVien.PhongBan.MaPB.ToString().Equals("*/-+-*/-+*/")).Include(l => l.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                return View(luongCoBans.ToList().ToPagedList(pageNumber, pageSize));
            }
        }

        // GET: LuongCoBan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LuongCoBan luongCoBan = db.LuongCoBans.Find(id);
            if (luongCoBan == null)
            {
                return HttpNotFound();
            }
            return View(luongCoBan);
        }

        // GET: LuongCoBan/Create
        public ActionResult Create()
        {
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen");
            return View();
        }

        // POST: LuongCoBan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLuongCoBan,TienLuongCoBan,MaNhanVien,TrangThai,NguoiSua,NgaySua")] LuongCoBan luongCoBan)
        {
            if (ModelState.IsValid)
            {
                db.LuongCoBans.Add(luongCoBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", luongCoBan.MaNhanVien);
            return View(luongCoBan);
        }

        // GET: LuongCoBan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LuongCoBan luongCoBan = db.LuongCoBans.Find(id);
            if (luongCoBan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", luongCoBan.MaNhanVien);
            return View(luongCoBan);
        }

        // POST: LuongCoBan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLuongCoBan,TienLuongCoBan,MaNhanVien,TrangThai,NguoiSua,NgaySua")] LuongCoBan luongCoBan)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(luongCoBan).State = EntityState.Modified;
                var luongCoBanList = db.LuongCoBans.Where(x => x.MaNhanVien == luongCoBan.MaNhanVien);
                foreach(var item in luongCoBanList)
                {
                    item.TrangThai = false;
                }
                LuongCoBan newLuongCB = new LuongCoBan();
                newLuongCB.TienLuongCoBan = luongCoBan.TienLuongCoBan;
                newLuongCB.MaNhanVien = luongCoBan.MaNhanVien;
                newLuongCB.TrangThai = true;
                newLuongCB.NguoiSua = luongCoBan.NguoiSua;
                newLuongCB.NgaySua = DateTime.Now;
                db.LuongCoBans.Add(newLuongCB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", luongCoBan.MaNhanVien);
            return View(luongCoBan);
        }

        // GET: LuongCoBan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LuongCoBan luongCoBan = db.LuongCoBans.Find(id);
            if (luongCoBan == null)
            {
                return HttpNotFound();
            }
            return View(luongCoBan);
        }

        // POST: LuongCoBan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LuongCoBan luongCoBan = db.LuongCoBans.Find(id);
            db.LuongCoBans.Remove(luongCoBan);
            db.SaveChanges();
            return RedirectToAction("Index");
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
