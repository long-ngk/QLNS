using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using PagedList;
using PagedList.Mvc;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers
{
    public class CCRaVaoController : Controller
    {
        QLNhanSuEntities db = new QLNhanSuEntities();
        // GET: CCRaVao
        public ActionResult ChamCongNgay(int? page, int? month, int? year)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            var maNhanVien = Session["MaNhanVien"].ToString();

            IQueryable<ChamCong> chamCongs;
            if (month != null && year != null)
            {
                chamCongs = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Equals(maNhanVien) && x.Ngay.Month == month && x.Ngay.Year == year);
                return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
            }
            else if(month == null && year != null)
            {
                chamCongs = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Equals(maNhanVien) &&  x.Ngay.Year == year);
                return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
            }
            else if (month != null && year == null)
            {
                chamCongs = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Equals(maNhanVien) && x.Ngay.Month == month);
                return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
            }
            chamCongs = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Equals(maNhanVien) && x.Ngay.Month == DateTime.Now.Month && x.Ngay.Year == DateTime.Now.Year);
            return View(chamCongs.ToList().ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult CheckIn()
        {
            var maNhanVien = Session["MaNhanVien"].ToString();
            var ngayHomNay = DateTime.Today;
            var nhanVien = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Equals(maNhanVien) && x.Ngay == ngayHomNay).SingleOrDefault();
            if (nhanVien != null)
            {

                nhanVien.ThoiGianVao = DateTime.Now.TimeOfDay;
                TimeSpan thoiGianVaoQuyDinh = DateTime.Parse("8:00 AM").TimeOfDay;
                TimeSpan thoiGianKhongChoVao = DateTime.Parse("10:00 AM").TimeOfDay;
                if (nhanVien.ThoiGianVao < thoiGianVaoQuyDinh)
                {
                    nhanVien.TrangThai = "Đúng giờ";
                }
                else if(nhanVien.ThoiGianVao < thoiGianKhongChoVao && nhanVien.ThoiGianVao > thoiGianVaoQuyDinh)
                {
                    nhanVien.TrangThai = "Đi trễ";
                    var tenphat = db.LoaiPhats.Where(s => s.TenLoaiPhat == "Đi trễ" && s.TrangThai == true).SingleOrDefault();
                    if (tenphat != null)
                    {
                        Ct_Phat phat = new Ct_Phat();
                        phat.MaNhanVien = nhanVien.MaNhanVien;
                        phat.MaLoaiPhat = tenphat.MaLoaiPhat;
                        phat.NgayPhat = DateTime.Now;
                        phat.NguoiPhat = "Hệ thống";
                        phat.NguoiSua = "Hệ thống";
                        phat.NgaySua = DateTime.Now;
                        phat.TrangThai = true;
                        db.Ct_Phat.Add(phat);
                        db.SaveChanges();
                    }
                }
                else
                {
                    this.AddNotification("Không được check in vì đã quá giờ quy định.", NotificationType.WARNING);
                    return RedirectToAction("ChamCongNgay");
                }
                db.SaveChanges();
            }
            return RedirectToAction("ChamCongNgay");
        }

        [HttpPost]
        public ActionResult CheckOut()
        {
            TimeSpan thoiGianVaoQuyDinh = DateTime.Parse("8:00 AM").TimeOfDay;
            TimeSpan thoiGianDuocPhepRa = DateTime.Parse("5:00 PM").TimeOfDay;
            var maNhanVien = Session["MaNhanVien"].ToString();
            var ngayHomNay = DateTime.Today;
            var nhanVien = db.ChamCongs.Where(x => x.MaNhanVien.ToString().Equals(maNhanVien) && x.Ngay == ngayHomNay).SingleOrDefault();
            if (nhanVien != null)
            {
                if(DateTime.Now.TimeOfDay > thoiGianDuocPhepRa)
                {
                    nhanVien.ThoiGianRa = DateTime.Now.TimeOfDay;
                    //nếu nhân viên chấm công vào trước 8h sáng sẽ được tính full 8h làm việc
                    if (nhanVien.ThoiGianVao < thoiGianVaoQuyDinh)
                    {
                        nhanVien.ThoiGianLamViec = 8;
                    }
                    else //ngược lại, sẽ lấy mốc 17h trừ đi thời gian nhân viên vô và trừ thêm 1 tiếng nghỉ trưa để ra số giờ làm việc
                    {
                        
                        var soGioLamViec = thoiGianDuocPhepRa - nhanVien.ThoiGianVao;
                        nhanVien.ThoiGianLamViec = soGioLamViec.Value.Hours - 1;

                    }
                    var thoiGianTangCa = nhanVien.ThoiGianRa - thoiGianDuocPhepRa;
                    nhanVien.ThoiGianTangCa = thoiGianTangCa.Value.Hours;
                    db.SaveChanges();
                }
                else
                {
                    this.AddNotification("Không được check out trước 17h...", NotificationType.WARNING);
                    return RedirectToAction("ChamCongNgay");
                }
            }
            return RedirectToAction("ChamCongNgay");
        }
    }
}