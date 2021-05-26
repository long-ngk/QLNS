﻿using System;
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
    public class NhanVienController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();

        // GET: NhanVien
        public ActionResult Index(string loaiTimKiem, string tenTimKiem, int? page, string trangThai)
        {
            try
            {
                IQueryable<NhanVien> nhanViens;
                QLNhanSuEntities db = new QLNhanSuEntities();
                if (trangThai == "TatCa")
                {
                    if (loaiTimKiem == "MaNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            nhanViens = db.NhanViens.Where(x => x.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }
                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.MaNhanVien.ToString().StartsWith(tenTimKiem)).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else if (loaiTimKiem == "TenNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            nhanViens = db.NhanViens.Where(x => x.HoTen.Contains("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }
                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.HoTen.Contains(tenTimKiem)).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else if (loaiTimKiem == "PhongBan")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            nhanViens = db.NhanViens.Where(x => x.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }
                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.PhongBan.TenPB.Contains(tenTimKiem)).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else
                    {
                        nhanViens = db.NhanViens.Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                        return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                    }
                }
                else if (trangThai == "HoatDong")
                {
                    if (loaiTimKiem == "MaNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai == true && x.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }

                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai == true && x.MaNhanVien.ToString().StartsWith(tenTimKiem)).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else if (loaiTimKiem == "TenNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai == true && x.HoTen.Contains("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }
                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai == true && x.HoTen.Contains(tenTimKiem)).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else if (loaiTimKiem == "PhongBan")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai == true && x.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }
                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai == true && x.PhongBan.TenPB.Contains(tenTimKiem)).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else
                    {

                        nhanViens = db.NhanViens.Where(x => x.TrangThai == true).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                        return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));

                    }
                }
                else if (trangThai == "VoHieuHoa")
                {
                    if (loaiTimKiem == "MaNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai != true && x.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }
                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai != true && x.MaNhanVien.ToString().StartsWith(tenTimKiem)).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else if (loaiTimKiem == "TenNhanVien")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai != true && x.HoTen.Contains("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }
                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai != true && x.HoTen.Contains(tenTimKiem)).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else if (loaiTimKiem == "PhongBan")
                    {
                        if (tenTimKiem == "" || tenTimKiem == null)
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai != true && x.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }
                        else
                        {
                            nhanViens = db.NhanViens.Where(x => x.TrangThai != true && x.PhongBan.TenPB.Contains(tenTimKiem)).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                            return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    else
                    {
                        nhanViens = db.NhanViens.Where(x => x.TrangThai != true).Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen);
                        return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                    }
                }
                else
                {
                    nhanViens = db.NhanViens.Include(c => c.PhongBan).Include(c => c.ChucVu).OrderBy(x => x.HoTen).OrderBy(x => x.HoTen);
                    return View("Index", nhanViens.ToList().ToPagedList(page ?? 1, 10));
                }
            }
            catch
            {
                this.AddNotification("Không tìm thấy từ khóa yêu cầu. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                return View("Index", db.NhanViens.OrderBy(x => x.HoTen).ToList());
            }
        }


        // GET: NhanVien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NhanVien/Create
        public ActionResult Create()
        {
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu");
            ViewBag.MaPB = new SelectList(db.PhongBans, "MaPB", "TenPB");
            ViewBag.MaNhanVien = new SelectList(db.TaiKhoans, "MaNhanVien", "TenTK");

            ViewBag.MaQuyen = new SelectList(db.PhanQuyens.Where(x => !x.MaQuyen.Equals(3)), "MaQuyen", "TenQuyen");
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhanVien,HoTen,NgaySinh,GioiTinh,QueQuan,DiaChi,CMND,Email,SDT,HinhAnh,MaChucVu,MaPB,TrangThai,NguoiSua,NgaySua")] NhanVien nhanVien, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                if (form["LuongCoBan"] == "" || form["LuongCoBan"] == null)
                {
                    ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
                    ViewBag.MaPB = new SelectList(db.PhongBans, "MaPB", "TenPB", nhanVien.MaPB);
                    ViewBag.MaNhanVien = new SelectList(db.TaiKhoans, "MaNhanVien", "TenTK", nhanVien.MaNhanVien);

                    ViewBag.MaQuyen = new SelectList(db.PhanQuyens.Where(x => !x.MaQuyen.Equals(3)), "MaQuyen", "TenQuyen");
                    this.AddNotification("Lương cơ bản không được trống!", NotificationType.ERROR);
                    return View(nhanVien);
                }
                else
                {
                    db.NhanViens.Add(nhanVien);
                    db.SaveChanges();
                    var generator = new RandomGenerator();
                    int tenTaiKhoan = generator.RandomNumber(100000, 999999);

                    var luongCB = db.LuongCoBans.Where(x => x.MaNhanVien == nhanVien.MaNhanVien).SingleOrDefault();
                    if (luongCB == null)
                    {
                        var lCB = new LuongCoBan();
                        lCB.MaNhanVien = nhanVien.MaNhanVien;
                        lCB.TienLuongCoBan = Convert.ToInt32(form["LuongCoBan"]);
                        lCB.NguoiSua = nhanVien.NguoiSua;
                        lCB.NgaySua = nhanVien.NgaySua;
                        db.LuongCoBans.Add(lCB);
                        db.SaveChanges();
                    }
                    var taiKhoan = db.TaiKhoans.Where(x => x.MaNhanVien == nhanVien.MaNhanVien).SingleOrDefault();
                    if (taiKhoan == null)
                    {
                        var newTaiKhoan = new TaiKhoan();
                        newTaiKhoan.TenTK = nhanVien.MaNhanVien + tenTaiKhoan.ToString();
                        newTaiKhoan.MaNhanVien = nhanVien.MaNhanVien;
                        newTaiKhoan.MatKhau = "a123456";
                        newTaiKhoan.MaQuyen = Convert.ToInt32(form["MaQuyen"]);
                        db.TaiKhoans.Add(newTaiKhoan);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }

            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
            ViewBag.MaPB = new SelectList(db.PhongBans, "MaPB", "TenPB", nhanVien.MaPB);
            ViewBag.MaNhanVien = new SelectList(db.TaiKhoans, "MaNhanVien", "TenTK", nhanVien.MaNhanVien);

            ViewBag.MaQuyen = new SelectList(db.PhanQuyens.Where(x => !x.MaQuyen.Equals(3)), "MaQuyen", "TenQuyen");
            return View(nhanVien);
        }

        // GET: NhanVien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
            ViewBag.MaPB = new SelectList(db.PhongBans, "MaPB", "TenPB", nhanVien.MaPB);
            ViewBag.MaNhanVien = new SelectList(db.TaiKhoans, "MaNhanVien", "TenTK", nhanVien.MaNhanVien);
            return View(nhanVien);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhanVien,HoTen,NgaySinh,GioiTinh,QueQuan,DiaChi,CMND,Email,SDT,HinhAnh,MaChucVu,MaPB,TrangThai,NguoiSua,NgaySua")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
            ViewBag.MaPB = new SelectList(db.PhongBans, "MaPB", "TenPB", nhanVien.MaPB);
            ViewBag.MaNhanVien = new SelectList(db.TaiKhoans, "MaNhanVien", "TenTK", nhanVien.MaNhanVien);
            return View(nhanVien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(List<NhanVien> nhanViens, string submit)
        {
            try
            {
                if (submit == "xoaNV")
                {
                    try
                    {
                        db.Configuration.ValidateOnSaveEnabled = false;
                        var checkIsChecked = nhanViens.Where(x => x.IsChecked == true).SingleOrDefault();
                        if (checkIsChecked == null)
                        {
                            this.AddNotification("Vui lòng chọn nhân viên để xóa!", NotificationType.ERROR);
                            return RedirectToAction("Index");
                        }
                        foreach (var item in nhanViens)
                        {
                            if (item.IsChecked == true)
                            {
                                int maNhanVien = item.MaNhanVien;
                                NhanVien nhanVien = db.NhanViens.Where(x => x.MaNhanVien == maNhanVien).SingleOrDefault();
                                if (nhanVien != null)
                                {
                                    nhanVien.TrangThai = false;
                                    db.SaveChanges();
                                }
                            }
                        }

                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        this.AddNotification("Không thể xóa vì thông tin nhân viên đang được sử dụng!", NotificationType.ERROR);
                        return RedirectToAction("Index");
                    }
                }
                else if (submit == "themThuong")
                {
                    try
                    {
                        db.Configuration.ValidateOnSaveEnabled = false;
                        var checkIsChecked = nhanViens.Where(x => x.IsChecked == true).FirstOrDefault();
                        if (checkIsChecked == null)
                        {
                            this.AddNotification("Vui lòng chọn nhân viên để thêm thưởng!", NotificationType.ERROR);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["listNhanVien"] = nhanViens.ToList();
                            return RedirectToAction("ThemThuongNhanVien");
                        }
                    }
                    catch
                    {
                        this.AddNotification("Không thể thêm thưởng cho nhân viên... Vui lòng thử lại!", NotificationType.ERROR);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    try
                    {
                        db.Configuration.ValidateOnSaveEnabled = false;
                        var checkIsChecked = nhanViens.Where(x => x.IsChecked == true).FirstOrDefault();
                        if (checkIsChecked == null)
                        {
                            this.AddNotification("Vui lòng chọn nhân viên để thêm phạt!", NotificationType.ERROR);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["listNhanVien"] = nhanViens.ToList();
                            return RedirectToAction("ThemPhatNhanVien");
                        }
                    }
                    catch
                    {
                        this.AddNotification("Không thể thêm phạt cho nhân viên... Vui lòng thử lại!", NotificationType.ERROR);
                        return RedirectToAction("Index");
                    }
                }
            }
            catch
            {
                this.AddNotification("Xảy ra lỗi. Vui lòng thực hiện lại thao tác!", NotificationType.ERROR);
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

        public ActionResult ThemThuongNhanVien()
        {
            ViewBag.MaLoaiThuong = new SelectList(db.LoaiThuongs.Where(x => x.TrangThai == true), "MaLoaiThuong", "TenLoaiThuong");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemThuongNhanVien(FormCollection form)
        {
            var listNhanVien = TempData["listNhanVien"] as List<NhanVien>;
            foreach (var item in listNhanVien)
            {
                if (item.IsChecked == true)
                {
                    var chitietThuong = new Ct_Thuong();
                    chitietThuong.MaNhanVien = item.MaNhanVien;
                    chitietThuong.MaLoaiThuong = Convert.ToInt32(form["MaLoaiThuong"]);
                    chitietThuong.TrangThai = true;
                    chitietThuong.NguoiSua = form["NguoiSua"].ToString();
                    chitietThuong.NgaySua = DateTime.Now;
                    db.Ct_Thuong.Add(chitietThuong);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult ThemPhatNhanVien()
        {
            ViewBag.MaLoaiPhat = new SelectList(db.LoaiPhats.Where(x => x.TrangThai == true && !x.TenLoaiPhat.Equals("Nghỉ", StringComparison.OrdinalIgnoreCase) && !x.TenLoaiPhat.Equals("Đi trễ", StringComparison.OrdinalIgnoreCase)), "MaLoaiPhat", "TenLoaiPhat");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemPhatNhanVien(FormCollection form)
        {
            var listNhanVien = TempData["listNhanVien"] as List<NhanVien>;
            foreach (var item in listNhanVien)
            {
                if (item.IsChecked == true)
                {
                    var chitietPhat = new Ct_Phat();
                    chitietPhat.MaNhanVien = item.MaNhanVien;
                    chitietPhat.MaLoaiPhat = Convert.ToInt32(form["MaLoaiPhat"]);
                    chitietPhat.TrangThai = true;
                    chitietPhat.NguoiSua = form["NguoiSua"].ToString();
                    chitietPhat.NgaySua = DateTime.Now;
                    db.Ct_Phat.Add(chitietPhat);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
    public class RandomGenerator
    {
        // Instantiate random number generator.  
        // It is better to keep a single Random instance 
        // and keep using Next on the same instance.  
        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
