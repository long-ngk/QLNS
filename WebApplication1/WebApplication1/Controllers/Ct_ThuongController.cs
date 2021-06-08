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
    public class Ct_ThuongController : Controller
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();
        public ActionResult Index(string loaiTimKiem, string tenTimKiem, int? page, string trangThai,string submit)
        {
            IQueryable<Ct_Thuong> ct_T;
            QLNhanSuEntities db = new QLNhanSuEntities();
            if(submit != null)
            {
                if (submit == "timKiem")
                {
                    try
                    {
                        if (trangThai == "TatCa")
                        {
                            if (loaiTimKiem == "MaNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.NhanVien.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.NhanVien.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "TenNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.NhanVien.HoTen.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "PhongBan")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo phòng ban!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.NhanVien.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.NhanVien.PhongBan.TenPB.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else
                            {
                                ct_T = db.Ct_Thuong.Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                            }
                        }
                        else if (trangThai == "HoatDong")
                        {
                            if (loaiTimKiem == "MaNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai == true && x.NhanVien.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }

                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai == true && x.NhanVien.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "TenNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai == true && x.NhanVien.HoTen.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai == true && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "PhongBan")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo phòng ban!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai == true && x.NhanVien.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai == true && x.NhanVien.PhongBan.TenPB.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else
                            {

                                ct_T = db.Ct_Thuong.Where(x => x.TrangThai == true).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));

                            }
                        }
                        else if (trangThai == "VoHieuHoa")
                        {
                            if (loaiTimKiem == "MaNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai != true && x.NhanVien.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai != true && x.NhanVien.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "TenNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai != true && x.NhanVien.HoTen.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai != true && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "PhongBan")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo phòng ban!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai != true && x.NhanVien.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai != true && x.NhanVien.PhongBan.TenPB.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else
                            {
                                ct_T = db.Ct_Thuong.Where(x => x.TrangThai != true).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                                return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                            }
                        }
                        else
                        {
                            ct_T = db.Ct_Thuong.Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen).OrderBy(x => x.NhanVien.HoTen);
                            return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    catch
                    {
                        this.AddNotification("Không tìm thấy từ khóa yêu cầu. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                        return View("Index", db.Ct_Thuong.OrderBy(x => x.NhanVien.HoTen).ToList().ToPagedList(page ?? 1, 10));
                    }
                }
                else
                {
                    try
                    {

                        if (trangThai == "TatCa")
                        {
                            if (loaiTimKiem == "MaNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.NhanVien.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgayThuong);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.NhanVien.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgayThuong);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "TenNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.NhanVien.HoTen.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgayThuong);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgayThuong);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "PhongBan")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo phòng ban!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.NhanVien.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgayThuong);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.NhanVien.PhongBan.TenPB.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgayThuong);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else
                            {
                                ct_T = db.Ct_Thuong.Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgayThuong);
                                return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                            }
                        }
                        else if (trangThai == "HoatDong")
                        {
                            if (loaiTimKiem == "MaNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai == true && x.NhanVien.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgayThuong);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }

                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai == true && x.NhanVien.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgayThuong);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "TenNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai == true && x.NhanVien.HoTen.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgayThuong);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai == true && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgayThuong);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "PhongBan")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo phòng ban!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai == true && x.NhanVien.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgayThuong);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai == true && x.NhanVien.PhongBan.TenPB.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgayThuong);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else
                            {

                                ct_T = db.Ct_Thuong.Where(x => x.TrangThai == true).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgayThuong);
                                return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));

                            }
                        }
                        else if (trangThai == "VoHieuHoa")
                        {
                            if (loaiTimKiem == "MaNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo mã nhân viên!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai != true && x.NhanVien.MaNhanVien.ToString().StartsWith("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgaySua);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai != true && x.NhanVien.MaNhanVien.ToString().Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgaySua);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "TenNhanVien")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo tên nhân viên!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai != true && x.NhanVien.HoTen.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgaySua);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai != true && x.NhanVien.HoTen.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgaySua);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else if (loaiTimKiem == "PhongBan")
                            {
                                if (tenTimKiem == "" || tenTimKiem == null)
                                {
                                    this.AddNotification("Vui lòng nhập từ khóa để tìm kiếm theo phòng ban!", NotificationType.WARNING);
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai != true && x.NhanVien.PhongBan.TenPB.Contains("+-*/abcdefgh")).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgaySua);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                                else
                                {
                                    ct_T = db.Ct_Thuong.Where(x => x.TrangThai != true && x.NhanVien.PhongBan.TenPB.Contains(tenTimKiem.ToString())).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgaySua);
                                    return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                                }
                            }
                            else
                            {
                                ct_T = db.Ct_Thuong.Where(x => x.TrangThai != true).Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgaySua);
                                return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                            }
                        }
                        else
                        {
                            ct_T = db.Ct_Thuong.Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgayThuong);
                            return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
                        }
                    }
                    catch
                    {
                        this.AddNotification("Có lỗi xảy ra. Vui lòng thực hiện tìm kiếm lại!", NotificationType.ERROR);
                        return View("Index", db.Ct_Thuong.Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen).ToList().ToPagedList(page ?? 1, 10));
                    }
                }
            }
            else
            {
                ct_T = db.Ct_Thuong.Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderBy(x => x.NhanVien.HoTen);
                return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
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
        public ActionResult Edit([Bind(Include = "MaCTThuong,MaNhanVien,HoTen,TenPB,MaLoaiThuong,TrangThai,NguoiSua,NgaySua,NguoiThuong,NgayThuong")] Ct_Thuong ct_Thuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ct_Thuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", ct_Thuong.MaNhanVien);
            ViewBag.MaLoaiThuong = new SelectList(db.LoaiThuongs.Where(x => x.TrangThai == true), "MaLoaiThuong", "TenLoaiThuong", ct_Thuong.MaLoaiThuong);
            return View(ct_Thuong);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(List<Ct_Thuong> ct_Thuongs)
        {
            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                var checkIsChecked = ct_Thuongs.Where(x => x.IsChecked == true).FirstOrDefault();
                if (checkIsChecked == null)
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
                            if (Session["TenNhanVien"] == null)
                            {
                                ct_Thuong.NguoiSua = "Ẩn danh";
                                ct_Thuong.NgaySua = DateTime.Now;
                            }
                            else
                            {
                                ct_Thuong.NguoiSua = Session["TenNhanVien"].ToString();
                                ct_Thuong.NgaySua = DateTime.Now;
                            }
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

        public ActionResult ThemGanDay(int? page)
        {
            IQueryable<Ct_Thuong> ct_T = db.Ct_Thuong.Include(c => c.NhanVien).Include(c => c.LoaiThuong).OrderByDescending(x => x.NgaySua);
            return View("Index", ct_T.ToList().ToPagedList(page ?? 1, 10));
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
