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
    public class LoaiPhatController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: LoaiPhat
        public ActionResult Index(int? page, string trangThai, string loaiTimKiem, string tenTimKiem)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;

            try
            {
                IQueryable<LoaiPhat> loaiPhats;
                QLNhanSuEntities db = new QLNhanSuEntities();
                
                if (trangThai == "TatCa")
                {
                    if (loaiTimKiem == "MaLoaiPhat")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã loại phạt!", NotificationType.WARNING);
                            loaiPhats = db.LoaiPhats.Where(x => x.MaLoaiPhat.ToString().StartsWith("+-*/abcdefgh")).OrderBy(x => x.TenLoaiPhat);
                            return View("Index", loaiPhats.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiPhats = db.LoaiPhats.Where(x => x.MaLoaiPhat.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiPhat);
                            return View("Index", loaiPhats.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else if (loaiTimKiem == "TenLoaiPhat")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên loại phạt!", NotificationType.WARNING);
                            loaiPhats = db.LoaiPhats.Where(x => x.TenLoaiPhat.Contains("+-*/abcdefgh")).OrderBy(x => x.TenLoaiPhat);
                            return View("Index", loaiPhats.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiPhats = db.LoaiPhats.Where(x => x.TenLoaiPhat.Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiPhat);
                            return View("Index", loaiPhats.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else
                    {
                        loaiPhats = db.LoaiPhats.OrderBy(x => x.TenLoaiPhat);
                        return View("Index", loaiPhats.ToList().ToPagedList(pageNumber, pageSize));
                    }
                }
                else if (trangThai == "HoatDong")
                {
                    if (loaiTimKiem == "MaLoaiPhat")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã loại phạt!", NotificationType.WARNING);
                            loaiPhats = db.LoaiPhats.Where(x => x.TrangThai == true && x.MaLoaiPhat.ToString().StartsWith("+-*/abcdefgh")).OrderBy(x => x.TenLoaiPhat);
                            return View("Index", loaiPhats.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiPhats = db.LoaiPhats.Where(x => x.TrangThai == true && x.MaLoaiPhat.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiPhat);
                            return View("Index", loaiPhats.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else if (loaiTimKiem == "TenLoaiPhat")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên loại phạt!", NotificationType.WARNING);
                            loaiPhats = db.LoaiPhats.Where(x => x.TrangThai == true && x.TenLoaiPhat.Contains("+-*/abcdefgh")).OrderBy(x => x.TenLoaiPhat);
                            return View("Index", loaiPhats.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiPhats = db.LoaiPhats.Where(x => x.TrangThai == true && x.TenLoaiPhat.Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiPhat);
                            return View("Index", loaiPhats.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else
                    {
                        loaiPhats = db.LoaiPhats.Where(x => x.TrangThai == true).OrderBy(x => x.TenLoaiPhat);
                        return View("Index", loaiPhats.ToList().ToPagedList(pageNumber, pageSize));
                    }
                }
                else if (trangThai == "VoHieuHoa")
                {
                    if (loaiTimKiem == "MaLoaiPhat")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã loại phạt!", NotificationType.WARNING);
                            loaiPhats = db.LoaiPhats.Where(x => x.TrangThai != true && x.MaLoaiPhat.ToString().StartsWith("+-*/abcdefgh")).OrderBy(x => x.TenLoaiPhat);
                            return View("Index", loaiPhats.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiPhats = db.LoaiPhats.Where(x => x.TrangThai != true && x.MaLoaiPhat.ToString().Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiPhat);
                            return View("Index", loaiPhats.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else if (loaiTimKiem == "TenLoaiPhat")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên loại phạt!", NotificationType.WARNING);
                            loaiPhats = db.LoaiPhats.Where(x => x.TrangThai != true && x.TenLoaiPhat.Contains("+-*/abcdefgh")).OrderBy(x => x.TenLoaiPhat);
                            return View("Index", loaiPhats.ToList().ToPagedList(pageNumber, pageSize));
                        }
                        else
                        {
                            loaiPhats = db.LoaiPhats.Where(x => x.TrangThai != true && x.TenLoaiPhat.Contains(tenTimKiem.ToString())).OrderBy(x => x.TenLoaiPhat);
                            return View("Index", loaiPhats.ToList().ToPagedList(pageNumber, pageSize));
                        }
                    }
                    else
                    {
                        loaiPhats = db.LoaiPhats.Where(x => x.TrangThai != true).OrderBy(x => x.TenLoaiPhat);
                        return View("Index", loaiPhats.ToList().ToPagedList(pageNumber, pageSize));
                    }
                }
                else
                {
                    loaiPhats = db.LoaiPhats.OrderBy(x => x.TenLoaiPhat);
                    return View("Index", loaiPhats.ToList().ToPagedList(pageNumber, pageSize));
                }
            }
            catch
            {
                this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                return View("Index", db.LoaiPhats.OrderBy(x => x.TenLoaiPhat).ToList().ToPagedList(pageNumber, pageSize));
            }
        }

        // GET: LoaiPhat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhat loaiPhat = db.LoaiPhats.Find(id);
            if (loaiPhat == null)
            {
                return HttpNotFound();
            }
            return View(loaiPhat);
        }

        // GET: LoaiPhat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiPhat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiPhat,TenLoaiPhat,GiaTri,TrangThai,NguoiSua,NgaySua")] LoaiPhat loaiPhat)
        {
            if (ModelState.IsValid)
            {
                //kiểm tra tên loại phạt được nhập từ ô textbox có trùng với bất kỳ tên loại thưởng nào trong database bảng LoaiPhat không 
                var tenLoaiPhatList = db.LoaiPhats.Where(x => x.TenLoaiPhat.Equals(loaiPhat.TenLoaiPhat.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
                string oldTenLoaiPhat = "";
                if (tenLoaiPhatList.Count > 0)
                {
                    foreach (var item in tenLoaiPhatList)
                    {
                        if (item.TrangThai == true)
                        {
                            item.TrangThai = false;
                            item.NguoiSua = "Hệ thống - " + loaiPhat.NguoiSua;
                            item.NgaySua = DateTime.Now;
                           
                        }
                        oldTenLoaiPhat = item.TenLoaiPhat;
                    }
                    loaiPhat.TenLoaiPhat = oldTenLoaiPhat;
                    loaiPhat.TrangThai = true;
                    db.LoaiPhats.Add(loaiPhat);
                }
                else
                {
                    db.LoaiPhats.Add(loaiPhat);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiPhat);
        }

        // GET: LoaiPhat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhat loaiPhat = db.LoaiPhats.Find(id);
            if (loaiPhat == null)
            {
                return HttpNotFound();
            }
            return View(loaiPhat);
        }

        // POST: LoaiPhat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiPhat,TenLoaiPhat,GiaTri,TrangThai,NguoiSua,NgaySua")] LoaiPhat loaiPhat)
        {
            if (ModelState.IsValid)
            {
                var tenLoaiPhatList = db.LoaiPhats.Where(x => x.TenLoaiPhat.Equals(loaiPhat.TenLoaiPhat.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
                string oldTenLoaiPhat = "";
                if (tenLoaiPhatList.Count != 0)
                {
                    foreach (var item in tenLoaiPhatList)
                    {
                        if (item.TrangThai == true)
                        {
                            item.TrangThai = false;
                            item.NguoiSua = "Hệ thống - " + loaiPhat.NguoiSua;
                            item.NgaySua = DateTime.Now;
                       
                        }
                        oldTenLoaiPhat = item.TenLoaiPhat;
                    }
                    loaiPhat.TenLoaiPhat = oldTenLoaiPhat;
                    loaiPhat.TrangThai = true;
                    db.LoaiPhats.Add(loaiPhat);
                }
                else
                {
                    db.LoaiPhats.Add(loaiPhat);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiPhat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(List<LoaiPhat> loaiPhats)
        {
            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                var checkIsChecked = loaiPhats.Where(x => x.IsChecked == true).FirstOrDefault();
                if (checkIsChecked == null)
                {
                    this.AddNotification("Vui lòng chọn loại phạt để xóa!", NotificationType.ERROR);
                    return RedirectToAction("Index");
                }
                foreach (var item in loaiPhats)
                {
                    if (item.IsChecked == true)
                    {
                        if(item.TenLoaiPhat == "Nghỉ" || item.TenLoaiPhat == "Đi trễ")
                        {
                            this.AddNotification("Không thể xóa vì loại phạt Đi trễ hoặc Nghỉ là loại phạt mặc định!", NotificationType.WARNING);
                            return RedirectToAction("Index");
                        }
                        int maLoaiPhat = item.MaLoaiPhat;
                        LoaiPhat loaiPhat = db.LoaiPhats.Where(x => x.MaLoaiPhat == maLoaiPhat).SingleOrDefault();
                        if (loaiPhat != null)
                        {
                            loaiPhat.TrangThai = false;
                            db.SaveChanges();
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                this.AddNotification("Không thể xóa vì loại phạt này đã và đang được sử dụng!", NotificationType.ERROR);
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
