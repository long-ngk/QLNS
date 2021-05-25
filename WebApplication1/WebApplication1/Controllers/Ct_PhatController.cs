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
    public class Ct_PhatController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: Ct_Phat
        public ActionResult Index(string loaiTimKiem, string tenTimKiem, int? page, string trangThai)
        {
            try
            {
                IQueryable<Ct_Phat> ct_P;
                QLNhanSuEntities db = new QLNhanSuEntities();
                if (trangThai == "TatCa")
                {
                    if (loaiTimKiem == "MaNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            ct_P = db.Ct_Phat.Where(x => x.NhanVien.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }
                        else
                        {
                            ct_P = db.Ct_Phat.Where(x => x.NhanVien.MaNhanVien.ToString().StartsWith(tenTimKiem)).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else if (loaiTimKiem == "TenNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            ct_P = db.Ct_Phat.Where(x => x.NhanVien.HoTen.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }
                        else
                        {
                            ct_P = db.Ct_Phat.Where(x => x.NhanVien.HoTen.Contains(tenTimKiem)).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else if (loaiTimKiem == "PhongBan")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            ct_P = db.Ct_Phat.Where(x => x.NhanVien.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }
                        else
                        {
                            ct_P = db.Ct_Phat.Where(x => x.NhanVien.PhongBan.TenPB.Contains(tenTimKiem)).Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else
                    {
                        ct_P = db.Ct_Phat.Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                        return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                    }
                }
                else if (trangThai == "HoatDong")
                {
                    if (loaiTimKiem == "MaNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }

                        else
                        {
                            ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.MaNhanVien.ToString().StartsWith(tenTimKiem)).Include(c => c.NhanVien).Include(c => c.LoaiPhat);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else if (loaiTimKiem == "TenNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.HoTen.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }
                        else
                        {
                            ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.HoTen.Contains(tenTimKiem)).Include(c => c.NhanVien).Include(c => c.LoaiPhat);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else if (loaiTimKiem == "PhongBan")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }
                        else
                        {
                            ct_P = db.Ct_Phat.Where(x => x.TrangThai == true && x.NhanVien.PhongBan.TenPB.Contains(tenTimKiem)).Include(c => c.NhanVien).Include(c => c.LoaiPhat);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else
                    {

                        ct_P = db.Ct_Phat.Where(x => x.TrangThai == true).Include(c => c.NhanVien).Include(c => c.LoaiPhat);
                        return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));

                    }
                }
                else if (trangThai == "VoHieuHoa")
                {
                    if (loaiTimKiem == "MaNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }
                        else
                        {
                            ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.MaNhanVien.ToString().StartsWith(tenTimKiem)).Include(c => c.NhanVien).Include(c => c.LoaiPhat);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else if (loaiTimKiem == "TenNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.HoTen.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }
                        else
                        {
                            ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.HoTen.Contains(tenTimKiem)).Include(c => c.NhanVien).Include(c => c.LoaiPhat);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else if (loaiTimKiem == "PhongBan")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiPhat);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }
                        else
                        {
                            ct_P = db.Ct_Phat.Where(x => x.TrangThai != true && x.NhanVien.PhongBan.TenPB.Contains(tenTimKiem)).Include(c => c.NhanVien).Include(c => c.LoaiPhat);
                            return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else
                    {
                        ct_P = db.Ct_Phat.Where(x => x.TrangThai != true).Include(c => c.NhanVien).Include(c => c.LoaiPhat);
                        return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                    }
                }
                else
                {
                    ct_P = db.Ct_Phat.Include(c => c.NhanVien).Include(c => c.LoaiPhat).OrderBy(x => x.NhanVien.HoTen);
                    return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                }
            }
            catch
            {
                this.AddNotification("Không tìm thấy từ khóa yêu cầu. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                return View("Index", db.Ct_Phat.OrderBy(x => x.NhanVien.HoTen).ToList());
            }
        }

        public ActionResult Search(string loaiTimKiem, string tenTimKiem, int? page)
        {
            try
            {
                IQueryable<Ct_Phat> ct_P;
                QLNhanSuEntities db = new QLNhanSuEntities();
                if (loaiTimKiem == "MaNhanVien")
                {

                    int tenTimKiem_int;
                    int.TryParse(tenTimKiem, out tenTimKiem_int);
                    ct_P = db.Ct_Phat.Where(x => x.NhanVien.MaNhanVien.ToString().StartsWith(tenTimKiem) || tenTimKiem == null).Include(c => c.NhanVien).Include(c => c.LoaiPhat);
                    return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                }
                else if (loaiTimKiem == "TenNhanVien")
                {

                    ct_P = db.Ct_Phat.Where(x => x.NhanVien.HoTen.Contains(tenTimKiem) || tenTimKiem == null).Include(c => c.NhanVien).Include(c => c.LoaiPhat);
                    return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                }
                else
                {
                    ct_P = db.Ct_Phat.Where(x => x.NhanVien.PhongBan.TenPB.Contains(tenTimKiem) || tenTimKiem == null).Include(c => c.NhanVien).Include(c => c.LoaiPhat);
                    return View("Index", ct_P.ToList().ToPagedList(page ?? 1, 10));
                }
            }
            catch
            {
                this.AddNotification("Không tìm thấy từ khóa yêu cầu. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                return View("Index", db.Ct_Phat.OrderBy(x => x.NhanVien.HoTen).ToList());
            }
        }

        // GET: Ct_Phat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ct_Phat ct_Phat = db.Ct_Phat.Find(id);
            if (ct_Phat == null)
            {
                return HttpNotFound();
            }
            return View(ct_Phat);
        }

        // GET: Ct_Phat/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiPhat = new SelectList(db.LoaiPhats, "MaLoaiPhat", "TenLoaiPhat");
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen");
            return View();
        }

        // POST: Ct_Phat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTPhat,MaNhanVien,MaLoaiPhat,TrangThai,NguoiSua,NgaySua")] Ct_Phat ct_Phat)
        {
            if (ModelState.IsValid)
            {
                db.Ct_Phat.Add(ct_Phat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiPhat = new SelectList(db.LoaiPhats, "MaLoaiPhat", "TenLoaiPhat", ct_Phat.MaLoaiPhat);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", ct_Phat.MaNhanVien);
            return View(ct_Phat);
        }

        // GET: Ct_Phat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ct_Phat ct_Phat = db.Ct_Phat.Find(id);
            if (ct_Phat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiPhat = new SelectList(db.LoaiPhats.Where(x => x.TrangThai == true), "MaLoaiPhat", "TenLoaiPhat", ct_Phat.MaLoaiPhat);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", ct_Phat.MaNhanVien);
            return View(ct_Phat);
        }

        // POST: Ct_Phat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTPhat,MaNhanVien,MaLoaiPhat,TrangThai,NguoiSua,NgaySua")] Ct_Phat ct_Phat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ct_Phat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiPhat = new SelectList(db.LoaiPhats.Where(x => x.TrangThai == true), "MaLoaiPhat", "TenLoaiPhat", ct_Phat.MaLoaiPhat);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", ct_Phat.MaNhanVien);
            return View(ct_Phat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(List<Ct_Phat> ct_Phats)
        {
            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                if (ct_Phats == null)
                {
                    this.AddNotification("Vui lòng chọn chi tiết phạt để xóa!", NotificationType.ERROR);
                    return RedirectToAction("Index");
                }
                foreach (var item in ct_Phats)
                {
                    if (item.IsChecked == true)
                    {
                        int maCTPhat = item.MaCTPhat;
                        Ct_Phat ct_Phat = db.Ct_Phat.Where(x => x.MaCTPhat == maCTPhat).SingleOrDefault();
                        if (ct_Phat != null)
                        {
                            ct_Phat.TrangThai = false;
                            db.SaveChanges();
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                this.AddNotification("Không thể xóa vì chi tiết thưởng này đã và đang được sử dụng!", NotificationType.ERROR);
                return RedirectToAction("Index");
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
