using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Controllers
{
    public class NguoiDungController : Controller
    {
        WebBanSachEntities1 db = new WebBanSachEntities1();
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection f)
        {
            String sHoten = f.Get("name").ToString();
            String sDiaChi = f.Get("add").ToString();
            String sPhone = f.Get("phone").ToString();
            String sMatKhau = f.Get("password").ToString();

            TK_KHACHHANG kh = db.TK_KHACHHANG.SingleOrDefault(n => n.SDT_KH == sPhone);

            if(kh != null)
            {
                ViewBag.ThongBao = "Đã tồn tại tài khoản! Vui lòng nhập số điện thoại khác!";
                return View();
            }
            else if(sMatKhau.Length < 8 && (sPhone.Length < 10 || sPhone.Length > 10))
            {
                ViewBag.ThongBao = "Số điện thoại và mật khẩu không đúng định dạng!";
                return View();
            }
            else if (sPhone.Length < 10 || sPhone.Length > 10)
            {
                ViewBag.ThongBao = "Số điện thoại cần có 10 số!";
                return View();
            }
            else if (sMatKhau.Length < 8)
            {
                ViewBag.ThongBao = "Mật khẩu cần có 8 ký tự trở lên!";
                return View();
            }
            else if (sPhone != "" && sMatKhau != "" && sHoten != "" && sDiaChi != "")
            {
                TK_KHACHHANG tk = new TK_KHACHHANG();
                tk.HOTENKH = sHoten;
                tk.DIACHI = sDiaChi;
                tk.SDT_KH = sPhone;
                tk.MATKHAU_KH = sMatKhau;

                db.TK_KHACHHANG.Add(tk);
                db.SaveChanges();
                ViewBag.ThongBao = "Đăng ký thành công !!!";
                return RedirectToAction("DangNhap");
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            String sTaiKhoan = f.Get("name").ToString();
            String sMatKhau = f.Get("password").ToString();
            TK_KHACHHANG kh = db.TK_KHACHHANG.SingleOrDefault(n => n.SDT_KH == sTaiKhoan && n.MATKHAU_KH == sMatKhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "đăng nhập thành công";
                Session["TaiKhoan"] = kh;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ThongBao = "Tài khoản hoặc mật khẩu ko đúng";
            return View();
        }

    }
}