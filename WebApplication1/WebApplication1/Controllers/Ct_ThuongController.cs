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
    public class Ct_ThuongController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: Ct_Thuong
        public ActionResult Index()
        {
            this.AddNotification("Bạn đang xem toàn bộ danh sách!", NotificationType.INFO);
            var ct_Thuong = db.Ct_Thuong.Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(c => c.NhanVien.HoTen);
            return View(ct_Thuong.ToList());
        }

        public ActionResult DanhSachHoatDong()
        {
            this.AddNotification("Bạn đang xem danh sách có trạng thái: Hoạt động!", NotificationType.INFO);
            List<Ct_Thuong> ct_Thuongs = db.Ct_Thuong.Where(x => x.TrangThai == true).OrderBy(x => x.NhanVien.HoTen).ToList();
            return View("Index", ct_Thuongs);
        }

        public ActionResult DanhSachVoHieuHoa()
        {
            this.AddNotification("Bạn đang xem danh sách có trạng thái: Vô hiệu hóa!", NotificationType.INFO);
            List<Ct_Thuong> ct_Thuongs = db.Ct_Thuong.Where(x => x.TrangThai != true).OrderBy(x => x.NhanVien.HoTen).ToList();
            return View("Index", ct_Thuongs);
        }

        public ActionResult Search(string loaiTimKiem, string tenTimKiem, List<Ct_Thuong> ct_Thuongs)
        {
            try
            {
                IQueryable<Ct_Thuong> ct_s;
                QLNhanSuEntities db = new QLNhanSuEntities();
                if (loaiTimKiem == "MaNhanVien")
                {

                    int tenTimKiem_int;
                    int.TryParse(tenTimKiem, out tenTimKiem_int);
                    ct_s = db.Ct_Thuong.Where(x => x.NhanVien.MaNhanVien == tenTimKiem_int || tenTimKiem == null).Include(c => c.NhanVien).Include(c => c.LoaiThuong);
                    return View("Index", ct_s.ToList());
                }
                else if (loaiTimKiem == "TenNhanVien")
                {

                    List<Ct_Thuong> list1, list2;
                    ct_s = db.Ct_Thuong.Where(x => x.NhanVien.HoTen.Contains(tenTimKiem) || tenTimKiem == null).Include(c => c.NhanVien).Include(c => c.LoaiThuong);
                    list1 = ct_s.ToList();
                    list2 = list1.Where(x => ct_Thuongs.Contains(x)).ToList();
                    foreach (var item in ct_Thuongs)
                    {
                        var cts = list1.Where(x => x.MaNhanVien == item.MaNhanVien).FirstOrDefault();
                        if (cts != null)
                        {

                            list2.Add(cts);

                        }
                    }
                    return View("Index", list2);
                }
                else
                {
                    List<Ct_Thuong> list1, list2;
                    ct_s = db.Ct_Thuong.Where(x => x.NhanVien.PhongBan.TenPB.Contains(tenTimKiem) || tenTimKiem == null).Include(c => c.NhanVien).Include(c => c.LoaiThuong);
                    list1 = ct_s.ToList();
                    list2 = list1.Where(x => ct_Thuongs.Contains(x)).ToList();
                    foreach (var item in ct_Thuongs)
                    {
                        var cts = list1.Where(x => x.MaNhanVien == item.MaNhanVien).FirstOrDefault();
                        if (cts != null)
                        {

                            list2.Add(cts);

                        }
                    }
                    return View("Index", list2);
                }
            }
            catch
            {
                this.AddNotification("Không tìm thấy từ khóa yêu cầu. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                return View("Index", db.Ct_Thuong.OrderBy(x => x.NhanVien.HoTen).ToList());
            }
        }
        // GET: Ct_Thuong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ct_Thuong ct_Thuong = db.Ct_Thuong.Find(id);
            if (ct_Thuong == null)
            {
                return HttpNotFound();
            }
            return View(ct_Thuong);
        }

        // GET: Ct_Thuong/Create
        public ActionResult Create()
        {
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen");
            ViewBag.MaLoaiThuong = new SelectList(db.LoaiThuongs, "MaLoaiThuong", "TenLoaiThuong");
            return View();
        }

        // POST: Ct_Thuong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTThuong,MaNhanVien,MaLoaiThuong,NguoiSua,NgaySua")] Ct_Thuong ct_Thuong)
        {
            if (ModelState.IsValid)
            {
                db.Ct_Thuong.Add(ct_Thuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", ct_Thuong.MaNhanVien);
            ViewBag.MaLoaiThuong = new SelectList(db.LoaiThuongs, "MaLoaiThuong", "TenLoaiThuong", ct_Thuong.MaLoaiThuong);
            return View(ct_Thuong);
        }

        // GET: Ct_Thuong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ct_Thuong ct_Thuong = db.Ct_Thuong.Find(id);
            if (ct_Thuong == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "MaNhanVien", ct_Thuong.MaNhanVien);
            ViewBag.MaLoaiThuong = new SelectList(db.LoaiThuongs.Where(x => x.TrangThai == true), "MaLoaiThuong", "TenLoaiThuong", ct_Thuong.MaLoaiThuong);
            return View(ct_Thuong);
        }

        // POST: Ct_Thuong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTThuong,MaNhanVien,HoTen,TenPB,MaLoaiThuong,NguoiSua,NgaySua")] Ct_Thuong ct_Thuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ct_Thuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", ct_Thuong.MaNhanVien);
            ViewBag.MaLoaiThuong = new SelectList(db.LoaiThuongs, "MaLoaiThuong", "TenLoaiThuong", ct_Thuong.MaLoaiThuong);
            return View(ct_Thuong);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(List<Ct_Thuong> ct_Thuongs)
        {
            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                if (ct_Thuongs == null)
                {
                    this.AddNotification("Vui lòng chọn chi tiết thưởng để xóa!", NotificationType.ERROR);
                    return RedirectToAction("Index");
                }
                foreach (var item in ct_Thuongs)
                {
                    if (item.IsChecked == true)
                    {
                        int maCTThuong = item.MaCTThuong;
                        Ct_Thuong ct_Thuong = db.Ct_Thuong.Where(x => x.MaCTThuong == maCTThuong).SingleOrDefault();
                        if (ct_Thuong != null)
                        {
                            ct_Thuong.TrangThai = false;
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
