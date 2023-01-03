using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        WebBanSachEntities1 db = new WebBanSachEntities1();
        public ActionResult DangKyAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKyAdmin(FormCollection f)
        {
            String sTaiKhoan = f.Get("phone").ToString();
            String sMatKhau = f.Get("password").ToString();
            TAIKHOANADMIN ad = db.TAIKHOANADMINs.SingleOrDefault(n => n.SDT_ADMIN == sTaiKhoan && n.MATKHAU == sMatKhau);

            if (ad != null)
            {
                ViewBag.ThongBao = "Đã tồn tại tài khoản! Vui lòng nhập số điện thoại khác!";
                return View();
            }
            else if (sMatKhau.Length < 8 && (sTaiKhoan.Length < 10 || sTaiKhoan.Length > 10))
            {
                ViewBag.ThongBao = "Số điện thoại và mật khẩu không đúng định dạng!";
                return View();
            }
            else if (sTaiKhoan.Length < 10 || sTaiKhoan.Length > 10)
            {
                ViewBag.ThongBao = "Số điện thoại cần có 10 số!";
                return View();
            }
            else if (sMatKhau.Length < 8)
            {
                ViewBag.ThongBao = "Mật khẩu cần có 8 ký tự trở lên!";
                return View();
            }
            else if (sTaiKhoan != "" && sMatKhau != "")
            {
                TAIKHOANADMIN tk = new TAIKHOANADMIN();
                tk.SDT_ADMIN = sTaiKhoan;
                tk.MATKHAU = sMatKhau;

                db.TAIKHOANADMINs.Add(tk);
                db.SaveChanges();
                ViewBag.ThongBao = "Đăng ký thành công !!!";
                return RedirectToAction("DangNhapAdmin");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DangNhapAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhapAdmin(FormCollection f)
        {
            String sTaiKhoan = f.Get("phone").ToString();
            String sMatKhau = f.Get("password").ToString();
            TAIKHOANADMIN kh = db.TAIKHOANADMINs.SingleOrDefault(n => n.SDT_ADMIN == sTaiKhoan);
            if (kh != null)
            {
                ViewBag.ThongBao = "đăng nhập thành công";
                return RedirectToAction("Index", "SanPham");
            }
            ViewBag.ThongBao = "Tài khoản hoặc mật khẩu ko đúng";
            return View();

        }

    }
}