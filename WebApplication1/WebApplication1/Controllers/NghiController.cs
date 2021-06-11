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

namespace WebApplication1.Controllers
{
    public class NghiController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: Nghi
        public ActionResult Index(int? page, DateTime? fromDate, DateTime? toDate,string MaPB, string trangThai)
        {
            ViewBag.MaPB = new SelectList(db.PhongBans.OrderByDescending(x=>x.TenPB), "MaPB", "TenPB", "12");
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            IQueryable<Nghi> nghis;
            if (MaPB == "12")
            {
                if (trangThai == "TatCa")
                {
                    if (fromDate > toDate)
                    {
                        this.AddNotification("Ngày bắt đầu không lớn hơn ngày kết thúc!", NotificationType.ERROR);
                        nghis = db.Nghis.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/")).OrderBy(x => x.NhanVien.HoTen);
                        return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        if (fromDate == null && toDate == null)
                        {
                            nghis = db.Nghis.Include(n => n.NhanVien).OrderBy(x => x.NhanVien.HoTen);
                            return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    nghis = db.Nghis.Include(n => n.NhanVien).Where(x => x.NgayNghi >= fromDate && x.NgayNghi <= toDate).OrderBy(x => x.NhanVien.HoTen);
                    return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                }
                if (trangThai == "HoatDong")
                {
                    if (fromDate > toDate)
                    {
                        this.AddNotification("Ngày bắt đầu không lớn hơn ngày kết thúc!", NotificationType.ERROR);
                        nghis = db.Nghis.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/")).OrderBy(x => x.NhanVien.HoTen);
                        return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        if (fromDate == null && toDate == null)
                        {
                            nghis = db.Nghis.Include(n => n.NhanVien).Where(x => x.Phep == true).OrderBy(x => x.NhanVien.HoTen);
                            return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    nghis = db.Nghis.Include(n => n.NhanVien).Where(x => x.NgayNghi >= fromDate && x.NgayNghi <= toDate && x.Phep == true).OrderBy(x => x.NhanVien.HoTen);
                    return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                }
                if (trangThai == "VoHieuHoa")
                {
                    if (fromDate > toDate)
                    {
                        this.AddNotification("Ngày bắt đầu không lớn hơn ngày kết thúc!", NotificationType.ERROR);
                        nghis = db.Nghis.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/")).OrderBy(x => x.NhanVien.HoTen);
                        return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        if (fromDate == null && toDate == null)
                        {
                            nghis = db.Nghis.Include(n => n.NhanVien).Where(x => x.Phep != true).OrderBy(x => x.NhanVien.HoTen);
                            return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    nghis = db.Nghis.Include(n => n.NhanVien).Where(x => x.NgayNghi >= fromDate && x.NgayNghi <= toDate && x.Phep != true).OrderBy(x => x.NhanVien.HoTen);
                    return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                }
            }
            else
            {
                if (trangThai == "TatCa")
                {
                    if (fromDate > toDate)
                    {
                        this.AddNotification("Ngày bắt đầu không lớn hơn ngày kết thúc!", NotificationType.ERROR);
                        nghis = db.Nghis.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/")).OrderBy(x => x.NhanVien.HoTen);
                        return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        if (fromDate == null && toDate == null)
                        {
                            nghis = db.Nghis.Include(n => n.NhanVien).OrderBy(x => x.NhanVien.HoTen).Where(x=>x.NhanVien.PhongBan.MaPB.ToString() == MaPB);
                            return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    nghis = db.Nghis.Include(n => n.NhanVien).Where(x => x.NgayNghi >= fromDate && x.NgayNghi <= toDate && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).OrderBy(x => x.NhanVien.HoTen);
                    return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                }
                if (trangThai == "HoatDong")
                {
                    if (fromDate > toDate)
                    {
                        this.AddNotification("Ngày bắt đầu không lớn hơn ngày kết thúc!", NotificationType.ERROR);
                        nghis = db.Nghis.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/")).OrderBy(x => x.NhanVien.HoTen);
                        return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        if (fromDate == null && toDate == null)
                        {
                            nghis = db.Nghis.Include(n => n.NhanVien).Where(x => x.Phep == true && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).OrderBy(x => x.NhanVien.HoTen);
                            return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    nghis = db.Nghis.Include(n => n.NhanVien).Where(x => x.NgayNghi >= fromDate && x.NgayNghi <= toDate && x.Phep == true && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).OrderBy(x => x.NhanVien.HoTen);
                    return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                }
                if (trangThai == "VoHieuHoa")
                {
                    if (fromDate > toDate)
                    {
                        this.AddNotification("Ngày bắt đầu không lớn hơn ngày kết thúc!", NotificationType.ERROR);
                        nghis = db.Nghis.Include(n => n.NhanVien).Where(x => x.NhanVien.HoTen.Contains("/*-+-*/-+-*/")).OrderBy(x => x.NhanVien.HoTen);
                        return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        if (fromDate == null && toDate == null)
                        {
                            nghis = db.Nghis.Include(n => n.NhanVien).Where(x => x.Phep != true && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).OrderBy(x => x.NhanVien.HoTen);
                            return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    nghis = db.Nghis.Include(n => n.NhanVien).Where(x => x.NgayNghi >= fromDate && x.NgayNghi <= toDate && x.Phep != true && x.NhanVien.PhongBan.MaPB.ToString() == MaPB).OrderBy(x => x.NhanVien.HoTen);
                    return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
                }
            }
            nghis = db.Nghis.Include(n => n.NhanVien).OrderBy(x => x.NhanVien.HoTen);
            return View(nghis.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Nghi/Details/5
        public ActionResult Details(int? id, DateTime? ngayNghi)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nghi nghi = db.Nghis.Where(x => x.MaNhanVien == id && x.NgayNghi == ngayNghi).SingleOrDefault();
            if (nghi == null)
            {
                return HttpNotFound();
            }
            return View(nghi);
        }


        // GET: Nghi/Create
        public ActionResult Create()
        {
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen");
            return View();
        }

        // POST: Nghi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhanVien,NgayNghi,Phep,NguoiDuyet,NgaySua,GhiChu")] Nghi nghi)
        {
            if (ModelState.IsValid)
            {
                db.Nghis.Add(nghi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", nghi.MaNhanVien);
            return View(nghi);
        }

        // GET: Nghi/Edit/5
        public ActionResult Edit(int? id, DateTime? ngayNghi)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nghi nghi = db.Nghis.Where(x => x.MaNhanVien == id && x.NgayNghi == ngayNghi).SingleOrDefault();
            if (nghi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", nghi.MaNhanVien);
            return View(nghi);
        }

        // POST: Nghi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhanVien,NgayNghi,Phep,NguoiDuyet,NgaySua,GhiChu")] Nghi nghi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nghi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", nghi.MaNhanVien);
            return View(nghi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult DuyetPhep(List<Nghi> nghis, FormCollection form)
        {
            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                var checkIsChecked = nghis.Where(x => x.IsChecked == true).FirstOrDefault();
                if (checkIsChecked == null)
                {
                    this.AddNotification("Vui lòng chọn nhân viên để duyệt!", NotificationType.ERROR);
                    return RedirectToAction("Index");
                }

                foreach (var item in nghis)
                {
                    if (item.IsChecked == true)
                    {
                        Nghi nghi = db.Nghis.Where(x => x.MaNhanVien == item.MaNhanVien && x.NgayNghi == item.NgayNghi).SingleOrDefault();
                        if (nghi != null)
                        {
                            if (nghi.Phep)
                            {
                                nghi.Phep = false;
                                nghi.NguoiDuyet = form["NguoiDuyet"].ToString();
                                nghi.NgaySua = DateTime.Now;
                                db.SaveChanges();
                            }
                            else
                            {
                                nghi.Phep = true;
                                nghi.NguoiDuyet = form["NguoiDuyet"].ToString();
                                nghi.NgaySua = DateTime.Now;
                                db.SaveChanges();
                            }
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {

                this.AddNotification("Có lỗi xảy ra. Vui lòng thử lại!", NotificationType.ERROR);
                return RedirectToAction("Index");
            }
        }
    }
}
