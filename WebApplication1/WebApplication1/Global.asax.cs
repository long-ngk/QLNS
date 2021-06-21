using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentScheduler;
using WebApplication1.Models;
using System.Data.Entity.Validation;
using System.Dynamic;
namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DateTime B = DateTime.Now;
            DateTime dayOfW = DateTime.Today;
            JobManager.Initialize(new MyRegistry());
            QLNhanSuEntities ql = new QLNhanSuEntities();
            if (dayOfW.DayOfWeek != DayOfWeek.Saturday && dayOfW.DayOfWeek != DayOfWeek.Sunday)
            {
                var chamcong = ql.ChamCongs.Where(s => s.Ngay == B.Date).FirstOrDefault();
                if (chamcong == null)
                {
                    var nhanvien = ql.NhanViens.Where(s => s.TrangThai == true && s.MaNhanVien != 1001);
                    foreach (var nv in nhanvien)
                    {
                        //ChamCong cham = new ChamCong();
                        //cham.MaNhanVien = nv.MaNhanVien;
                        //cham.Ngay = B;
                        //ql.ChamCongs.Add(cham);
                        ChamCong cham = new ChamCong();
                        cham.MaNhanVien = nv.MaNhanVien;
                        cham.Ngay = B;
                        ql.ChamCongs.Add(cham);
                    }
                    ql.SaveChanges();
                }
            }


            int month, year;
            if (B.Month == 1)
            {
                month = 12;
                year = B.Year - 1;
            }
            else
            {
                month = B.Month - 1;
                year = B.Year;
            }
            var day = DateTime.DaysInMonth(year, month);
            DateTime ngayCuoiThang = new DateTime(year, month, day);
            var luong = ql.LuongThangs.Where(s => s.ThangNam.Month.ToString() == month.ToString() && s.ThangNam.Year.ToString() == year.ToString()).FirstOrDefault();
            if (luong == null)
            {

                var nhanvien = ql.NhanViens.Where(s => s.TrangThai == true && s.MaNhanVien != 1001);
                foreach (var nv in nhanvien)
                {
                    int gtthuong = 0;
                    int gtphat = 0;
                    int giolam = 0;
                    int giotangca = 0;
                    var thuong = ql.Ct_Thuong.Where(s => s.NgaySua.Month == month && s.NgaySua.Year == year && s.MaNhanVien == nv.MaNhanVien);
                    foreach (var t in thuong)
                    {
                        var giatrithuong = ql.LoaiThuongs.Where(s => s.MaLoaiThuong == t.MaLoaiThuong).SingleOrDefault();
                        gtthuong = gtthuong + giatrithuong.GiaTri;
                    }
                    var phat = ql.Ct_Phat.Where(s => s.NgaySua.Month == month && s.NgaySua.Year == year && s.MaNhanVien == nv.MaNhanVien);
                    foreach (var t in phat)
                    {
                        var giatriphat = ql.LoaiPhats.Where(s => s.MaLoaiPhat == t.MaLoaiPhat).SingleOrDefault();
                        gtphat = gtphat + giatriphat.GiaTri;
                    }
                    var cc = ql.ChamCongs.Where(s => s.MaNhanVien == nv.MaNhanVien && s.Ngay.Month.ToString() == month.ToString() && s.Ngay.Year.ToString() == year.ToString() && s.TrangThai != null);
                    if (cc.Count() == 0)
                    {

                    }
                    else
                    {
                        foreach (var c in cc)
                        {
                            if (c.ThoiGianLamViec != null && c.ThoiGianTangCa != null)
                            {
                                giolam = (int)(giolam + c.ThoiGianLamViec);
                                giotangca = (int)(giotangca + c.ThoiGianTangCa);
                            }
                        }
                    }
                    var luongcoban = ql.LuongCoBans.Where(s => s.MaNhanVien == nv.MaNhanVien && s.TrangThai == true).SingleOrDefault();
                    if (luongcoban != null)
                    {
                        LuongThang l = new LuongThang();
                        l.MaLuongCoBan = luongcoban.MaLuongCoBan;
                        l.ThangNam = ngayCuoiThang;
                        l.TongGioLamViec = giolam;
                        l.TongGioTangCa = giotangca;
                        l.TongThuong = gtthuong;
                        l.TongPhat = gtphat;
                        l.HeSoLuong = luongcoban.NhanVien.ChucVu.HeSoChucVu;
                        l.PhuCap = luongcoban.NhanVien.ChucVu.PhuCap;
                        ql.LuongThangs.Add(l);
                    }
                }
                ql.SaveChanges();
            }

            //sau 10h nếu app đc khởi động mà chấm công hôm nay, những ai chưa chấm công nếu trạng thái là null, thì thay thành "Nghỉ"
            //đồng thời thêm nhân viên đó vào bảng nghỉ
            TimeSpan thoiGianKhongChoVao = DateTime.Parse("10:00 AM").TimeOfDay;
            if (DateTime.Now.TimeOfDay > thoiGianKhongChoVao)
            {
                var nvList = ql.ChamCongs.Where(s => s.TrangThai == null && s.Ngay == DateTime.Today).ToList();
                if (nvList.Count > 0)
                {
                    var nvNghiList = ql.Nghis.Where(x => x.NgayNghi == DateTime.Today).ToList();
                    if (nvNghiList.Count == 0)
                    {
                        foreach (var b in nvList)
                        {
                            b.TrangThai = "Nghỉ";

                            //thêm dữ liệu nhân viên nghỉ vào bảng Nghỉ
                            Nghi nhanVienNghi = new Nghi();
                            nhanVienNghi.MaNhanVien = b.MaNhanVien;
                            nhanVienNghi.NgayNghi = DateTime.Today;
                            nhanVienNghi.Phep = false;
                            nhanVienNghi.NgaySua = DateTime.Now;
                            nhanVienNghi.GhiChu = "Hôm nay nghỉ";
                            ql.Nghis.Add(nhanVienNghi);
                        }
                        ql.SaveChanges();
                    }
                }
            }

            //kiểm tra sau 16h nếu nhân viên nghỉ thì thêm phạt nhân viên đó, mà nếu đã có phạt rồi thì ko phạt nữa
            TimeSpan thoiGianThemPhatNhanVienNghi = DateTime.Parse("04:00 PM").TimeOfDay;
            var mocThoiGian16h = DateTime.Today.AddHours(16);
            if (DateTime.Now.TimeOfDay > thoiGianThemPhatNhanVienNghi)
            {
                //list chấm công nhân viên có trạng thái nghỉ không phép trong ngày hôm nay
                var nvChamCongList = ql.Nghis.Where(x => x.Phep == false && x.NgayNghi == DateTime.Today.Date).ToList();
                foreach (var b in nvChamCongList)
                {
                    var ct_PhatNhanVienNghi = ql.Ct_Phat.Where(x => x.LoaiPhat.TenLoaiPhat == "Nghỉ" && x.MaNhanVien == b.MaNhanVien && x.NgayPhat == mocThoiGian16h).SingleOrDefault();
                    if (ct_PhatNhanVienNghi == null)
                    {
                        var tenphat = ql.LoaiPhats.Where(s => s.TenLoaiPhat == "Nghỉ" && s.TrangThai == true).SingleOrDefault();
                        if (tenphat != null)
                        {
                            Ct_Phat phat = new Ct_Phat();
                            phat.MaNhanVien = b.MaNhanVien;
                            phat.MaLoaiPhat = tenphat.MaLoaiPhat;
                            phat.NgayPhat = DateTime.Today.AddHours(16);
                            phat.NguoiPhat = "Hệ thống";
                            phat.NguoiSua = "Hệ thống";
                            phat.NgaySua = DateTime.Today.AddHours(16);
                            phat.TrangThai = true;
                            ql.Ct_Phat.Add(phat);

                        }
                    }
                    else
                    {
                        break;
                    }
                }
                ql.SaveChanges();
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }

    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            Action someMethod = new Action(() =>
            {
                QLNhanSuEntities ql = new QLNhanSuEntities();
                var nv = ql.ChamCongs.Where(s => s.TrangThai == null && s.Ngay == DateTime.Today);
                foreach (var b in nv)
                {
                    b.TrangThai = "Nghỉ";

                    Nghi nhanVienNghi = new Nghi();
                    nhanVienNghi.MaNhanVien = b.MaNhanVien;
                    nhanVienNghi.NgayNghi = DateTime.Today;
                    nhanVienNghi.Phep = false;
                    nhanVienNghi.NgaySua = DateTime.Now;
                    nhanVienNghi.GhiChu = "Hôm nay nghỉ";
                    ql.Nghis.Add(nhanVienNghi);
                }
                ql.SaveChanges();

            });
            this.Schedule(someMethod).ToRunEvery(0).Days().At(10, 00);


            Action taophat = new Action(() =>
            {
                DateTime B = DateTime.Now;
                QLNhanSuEntities ql = new QLNhanSuEntities();
                var mocThoiGian16h = DateTime.Today.AddHours(16);
                var listNhanVienNghiKhongPhep = ql.Nghis.Where(x => x.Phep == false && x.NgayNghi == DateTime.Today.Date);
                //var nv = ql.ChamCongs.Where(s => s.TrangThai == "Nghỉ" && s.Ngay == DateTime.Today);
                foreach (var b in listNhanVienNghiKhongPhep)
                {
                    var ct_PhatNhanVienNghi = ql.Ct_Phat.Where(x => x.LoaiPhat.TenLoaiPhat == "Nghỉ" && x.MaNhanVien == b.MaNhanVien && x.NgayPhat == mocThoiGian16h).SingleOrDefault();
                    if (ct_PhatNhanVienNghi == null)
                    {
                        var tenphat = ql.LoaiPhats.Where(s => s.TenLoaiPhat == "Nghỉ" && s.TrangThai == true).SingleOrDefault();
                        if (tenphat != null)
                        {
                            Ct_Phat phat = new Ct_Phat();
                            phat.MaNhanVien = b.MaNhanVien;
                            phat.MaLoaiPhat = tenphat.MaLoaiPhat;
                            phat.NgayPhat = DateTime.Today.AddHours(16);
                            phat.NguoiPhat = "Hệ thống";
                            phat.NguoiSua = "Hệ thống";
                            phat.NgaySua = DateTime.Today.AddHours(16);
                            phat.TrangThai = true;
                            ql.Ct_Phat.Add(phat);

                        }
                    }
                }
                ql.SaveChanges();
            });
            this.Schedule(taophat).ToRunEvery(0).Days().At(16, 00);
            //DateTime B = DateTime.Now;


        }
    }
}
