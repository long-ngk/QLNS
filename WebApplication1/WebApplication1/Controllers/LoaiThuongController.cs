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
using PagedList;
using PagedList.Mvc;
namespace WebApplication1.Controllers
{
    public class LoaiThuongController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        public ActionResult Index(int? page, string trangThai, string loaiTimKiem, string tenTimKiem)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            try
            {
                IQueryable<LoaiThuong> loaiThuongs;
                QLNhanSuEntities db = new QLNhanSuEntities();
                if (trangThai == "TatCa")
                {
                    if (loaiTimKiem == "MaLoaiThuong")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã loại thưởng!", NotificationType.WARNING);
                            loaiThuongs = db.LoaiThuongs.Where(x => x.MaLoaiThuong.ToString().StartsWith("+-*/abcdefgh")).OrderBy(x => x.TenLoaiThuong);
                            return View("Index", loaiThuongs.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiThuongs = db.LoaiThuongs.Where(x => x.MaLoaiThuong.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiThuong);
                            return View("Index", loaiThuongs.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else if (loaiTimKiem == "TenLoaiThuong")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên loại thưởng!", NotificationType.WARNING);
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TenLoaiThuong.Contains("+-*/abcdefgh")).OrderBy(x => x.TenLoaiThuong);
                            return View("Index", loaiThuongs.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TenLoaiThuong.Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiThuong);
                            return View("Index", loaiThuongs.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else
                    {
                        loaiThuongs = db.LoaiThuongs.OrderBy(x => x.TenLoaiThuong);
                        return View("Index", loaiThuongs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                }
                else if (trangThai == "HoatDong")
                {
                    if (loaiTimKiem == "MaLoaiThuong")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã loại thưởng!", NotificationType.WARNING);
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai == true && x.MaLoaiThuong.ToString().StartsWith("+-*/abcdefgh")).OrderBy(x => x.TenLoaiThuong);
                            return View("Index", loaiThuongs.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai == true && x.MaLoaiThuong.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiThuong);
                            return View("Index", loaiThuongs.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else if (loaiTimKiem == "TenLoaiThuong")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên loại thưởng!", NotificationType.WARNING);
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai == true && x.TenLoaiThuong.Contains("+-*/abcdefgh")).OrderBy(x => x.TenLoaiThuong);
                            return View("Index", loaiThuongs.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai == true && x.TenLoaiThuong.Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiThuong);
                            return View("Index", loaiThuongs.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else
                    {
                        loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai == true).OrderBy(x => x.TenLoaiThuong);
                        return View("Index", loaiThuongs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                }
                else if (trangThai == "VoHieuHoa")
                {
                    if (loaiTimKiem == "MaLoaiThuong")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã loại thưởng!", NotificationType.WARNING);
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai != true && x.MaLoaiThuong.ToString().StartsWith("+-*/abcdefgh")).OrderBy(x => x.TenLoaiThuong);
                            return View("Index", loaiThuongs.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai != true && x.MaLoaiThuong.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiThuong);
                            return View("Index", loaiThuongs.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else if (loaiTimKiem == "TenLoaiThuong")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên loại thưởng!", NotificationType.WARNING);
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai != true && x.TenLoaiThuong.Contains("+-*/abcdefgh")).OrderBy(x => x.TenLoaiThuong);
                            return View("Index", loaiThuongs.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai != true && x.TenLoaiThuong.Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiThuong);
                            return View("Index", loaiThuongs.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else
                    {
                        loaiThuongs = db.LoaiThuongs.Where(x => x.TrangThai != true).OrderBy(x => x.TenLoaiThuong);
                        return View("Index", loaiThuongs.ToList().ToPagedList(pageNumber, pageSize));
                    }
                }
                else
                {
                    loaiThuongs = db.LoaiThuongs.OrderBy(x => x.TenLoaiThuong);
                    return View("Index", loaiThuongs.ToList().ToPagedList(pageNumber, pageSize));
                }
            }
            catch
            {
                this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                return View("Index", db.LoaiThuongs.OrderBy(x => x.TenLoaiThuong).ToList().ToPagedList(pageNumber, pageSize));
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
                //kiểm tra tên loại thưởng được nhập từ ô textbox có trùng với bất kỳ tên loại thưởng nào trong database bảng LoaiThuong không 
                var tenLoaiThuongList = db.LoaiThuongs.Where(x => x.TenLoaiThuong.Equals(loaiThuong.TenLoaiThuong.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
                string oldTenLoaiThuong = "";
                if (tenLoaiThuongList.Count > 0)
                {
                    foreach (var item in tenLoaiThuongList)
                    {
                        if (item.TrangThai == true)
                        {
                            item.TrangThai = false;
                            item.NguoiSua = "Hệ thống - " + loaiThuong.NguoiSua;
                            item.NgaySua = DateTime.Now;
                            
                        }
                        oldTenLoaiThuong = item.TenLoaiThuong;
                    }
                    loaiThuong.TenLoaiThuong = oldTenLoaiThuong;
                    loaiThuong.TrangThai = true;
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
                var tenLoaiThuongList = db.LoaiThuongs.Where(x => x.TenLoaiThuong.Equals(loaiThuong.TenLoaiThuong.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
                string oldTenLoaiThuong = "";
                if (tenLoaiThuongList.Count > 0)
                {
                    foreach (var item in tenLoaiThuongList)
                    {
                        if (item.TrangThai == true)
                        {
                            item.TrangThai = false;
                            item.NguoiSua = "Hệ thống - " + loaiThuong.NguoiSua;
                            item.NgaySua = DateTime.Now;
                           
                        }
                        oldTenLoaiThuong = item.TenLoaiThuong;
                    }
                    loaiThuong.TenLoaiThuong = oldTenLoaiThuong;
                    loaiThuong.TrangThai = true;
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
                var checkIsChecked = loaiThuongs.Where(x => x.IsChecked == true).FirstOrDefault();
                if (checkIsChecked == null)
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
