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
    public class LoaiThuongController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: LoaiThuong
        public ActionResult Index()
        {
            this.AddNotification("Bạn đang xem toàn bộ danh sách!", NotificationType.INFO);
            return View(db.LoaiThuongs.OrderBy(x => x.TenLoaiThuong).ToList());
        }

        public ActionResult DanhSachHoatDong()
        {
            this.AddNotification("Bạn đang xem danh sách có trạng thái: Hoạt động!", NotificationType.INFO);
            List<LoaiThuong> loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai == true).OrderBy(x => x.TenLoaiThuong).ToList();
            return View("Index", loaiThuongs);
        }

        public ActionResult DanhSachVoHieuHoa()
        {
            this.AddNotification("Bạn đang xem danh sách có trạng thái: Vô hiệu hóa!", NotificationType.INFO);
            List<LoaiThuong> loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai != true).OrderBy(x => x.TenLoaiThuong).ToList();
            return View("Index", loaiThuongs);
        }
        public ActionResult Search(string loaiTimKiem, string tenTimKiem, List<LoaiThuong> loaiThuongs)
        {
           
            try
            {
                QLNhanSuEntities db = new QLNhanSuEntities();

                if (loaiTimKiem == "MaLoaiThuong")
                {
                    int tenTimKiem_int;
                    int.TryParse(tenTimKiem, out tenTimKiem_int);
                    return View("Index", loaiThuongs.Where(x => x.MaLoaiThuong == tenTimKiem_int || tenTimKiem == null).ToList());
                }
                else
                {

                    return View("Index", loaiThuongs.Where(x => x.TenLoaiThuong.Contains(tenTimKiem.ToString()) || tenTimKiem == null).ToList());
                }
            }
            catch
            {
                this.AddNotification("Không tìm thấy từ khóa yêu cầu. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                return View("Index", db.LoaiThuongs.OrderBy(x => x.TenLoaiThuong).ToList());
            }
        }

        // GET: LoaiThuong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiThuong loaiThuong = db.LoaiThuongs.Find(id);
            if (loaiThuong == null)
            {
                return HttpNotFound();
            }
            return View(loaiThuong);
        }

        // GET: LoaiThuong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiThuong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiThuong,TenLoaiThuong,GiaTri,TrangThai,NguoiSua,NgaySua")] LoaiThuong loaiThuong)
        {
            if (ModelState.IsValid)
            {
                //kiểm tra tên loại thưởng được nhập từ ô t có trùng với bất kỳ tên loại thưởng nào trong database bảng LoaiThuong không 
                var tenLoaiThuongList = db.LoaiThuongs.Where(x => x.TenLoaiThuong.Equals(loaiThuong.TenLoaiThuong, StringComparison.OrdinalIgnoreCase)).ToList();

                if (tenLoaiThuongList.Count != 0)
                {
                    foreach (var item in tenLoaiThuongList)
                    {
                        if (item.TrangThai == true)
                        {
                            item.TrangThai = false;
                            item.NguoiSua = "Hệ thống - " + loaiThuong.NguoiSua;
                            item.NgaySua = DateTime.Now;
                          
                        }
                    }
                    db.LoaiThuongs.Add(loaiThuong);
                }
                else
                {
                    db.LoaiThuongs.Add(loaiThuong);
                }
                //if (tenLoaiThuong != null)
                //{

                //    tenLoaiThuong.TrangThai = false;
                //    tenLoaiThuong.NguoiSua = "Hệ thống - " + loaiThuong.NguoiSua;
                //    tenLoaiThuong.NgaySua = DateTime.Now;
                //    db.LoaiThuongs.Add(loaiThuong);

                //}
                //else
                //{
                //    db.LoaiThuongs.Add(loaiThuong);
                //}

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiThuong);
        }

        // GET: LoaiThuong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiThuong loaiThuong = db.LoaiThuongs.Find(id);
            if (loaiThuong == null)
            {
                return HttpNotFound();
            }
            return View(loaiThuong);
        }

        // POST: LoaiThuong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiThuong,TenLoaiThuong,GiaTri,TrangThai,NguoiSua,NgaySua")] LoaiThuong loaiThuong)
        {
            if (ModelState.IsValid)
            {
                var tenLoaiThuongList = db.LoaiThuongs.Where(x => x.TenLoaiThuong.Equals(loaiThuong.TenLoaiThuong, StringComparison.OrdinalIgnoreCase)).ToList();

                if (tenLoaiThuongList.Count != 0)
                {
                    foreach (var item in tenLoaiThuongList)
                    {
                        if (item.TrangThai == true)
                        {
                            item.TrangThai = false;
                            item.NguoiSua = "Hệ thống - " + loaiThuong.NguoiSua;
                            item.NgaySua = DateTime.Now;
                           
                        }
                    }
                    db.LoaiThuongs.Add(loaiThuong);
                }
                else
                {
                    db.LoaiThuongs.Add(loaiThuong);
                }
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiThuong);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(List<LoaiThuong> loaiThuongs)
        {
            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                if (loaiThuongs == null)
                {
                    this.AddNotification("Vui lòng chọn loại thưởng để xóa!", NotificationType.ERROR);
                    return RedirectToAction("Index");
                }
                foreach (var item in loaiThuongs)
                {
                    if (item.IsChecked == true)
                    {
                        int maLoaiThuong = item.MaLoaiThuong;
                        LoaiThuong loaiThuong = db.LoaiThuongs.Where(x => x.MaLoaiThuong == maLoaiThuong).SingleOrDefault();
                        if (loaiThuong != null)
                        {
                            loaiThuong.TrangThai = false;
                            db.SaveChanges();
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                this.AddNotification("Không thể xóa vì loại thưởng này đã và đang được sử dụng!", NotificationType.ERROR);
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
