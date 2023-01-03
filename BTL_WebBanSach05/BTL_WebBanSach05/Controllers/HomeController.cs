using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Controllers
{
    public class HomeController : Controller
    {
        WebBanSachEntities1 db = new WebBanSachEntities1();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["TaiKhoan"] != null)
            {
                TK_KHACHHANG kh = (TK_KHACHHANG)Session["TaiKhoan"];
                ViewBag.IdKH = kh.ID_KHACHHANG;
                ViewBag.Hoten = "Xin chào " + kh.HOTENKH;
            }
            else
            {
                ViewBag.IdKH = "";
                ViewBag.Hoten = "";
            }
            return View();
        }

        public ActionResult Log()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            if (Session["TaiKhoan"] != null)
            {
                TK_KHACHHANG kh = (TK_KHACHHANG)Session["TaiKhoan"];
                ViewBag.IdKH = kh.ID_KHACHHANG;
                ViewBag.Hoten = "Xin chào " + kh.HOTENKH;
            }
            else
            {
                ViewBag.IdKH = "";
                ViewBag.Hoten = "";
            }
            return View();
        }
        public ActionResult CTSanPham(int? idSP)
        {
            if (Session["TaiKhoan"] != null)
            {
                TK_KHACHHANG kh = (TK_KHACHHANG)Session["TaiKhoan"];
                ViewBag.IdKH = kh.ID_KHACHHANG;
                ViewBag.Hoten = "Xin chào " + kh.HOTENKH;
            }
            else
            {
                ViewBag.IdKH = "";
                ViewBag.Hoten = "";
            }
            ViewBag.IdSP = idSP;
            return View();
        }
        public ActionResult Filter()
        {
            if (Session["TaiKhoan"] != null)
            {
                TK_KHACHHANG kh = (TK_KHACHHANG)Session["TaiKhoan"];
                ViewBag.IdKH = kh.ID_KHACHHANG;
                ViewBag.Hoten = "Xin chào " + kh.HOTENKH;
            }
            else
            {
                ViewBag.IdKH = "";
                ViewBag.Hoten = "";
            }
            return View();
        }

        public ActionResult GioHang(string idKH)
        {
            if (Session["TaiKhoan"] != null)
            {
                TK_KHACHHANG kh = (TK_KHACHHANG)Session["TaiKhoan"];
                ViewBag.IdKH = kh.ID_KHACHHANG;
                ViewBag.hoTen = kh.HOTENKH;
                ViewBag.SDT = kh.SDT_KH;
                ViewBag.DiaChi = kh.DIACHI;
                ViewBag.HT = "Xin chào " + ViewBag.hoTen;
            }
            else
            {
                ViewBag.IdKH = "";
                ViewBag.hoTen = "";
                ViewBag.HT = "";
            }

            if (idKH == "")
            {
                ViewBag.idKhach = -1;
                ViewBag.ThongBao = "Vui lòng đăng nhập để xem giỏ hàng!";
            }
            else
            {
                ViewBag.idKhach = idKH;
                ViewBag.ThongBao = "";
            }
            return View();
        }

        public ActionResult TTKhach(string idKH)
        {
            if (Session["TaiKhoan"] != null)
            {
                TK_KHACHHANG kh = (TK_KHACHHANG)Session["TaiKhoan"];
                ViewBag.IdKH = kh.ID_KHACHHANG;
                ViewBag.hoTen = kh.HOTENKH;
                ViewBag.SDT = kh.SDT_KH;
                ViewBag.DiaChi = kh.DIACHI;
                ViewBag.HT = "Xin chào " + ViewBag.hoTen;
            }
            else
            {
                ViewBag.IdKH = "";
                ViewBag.hoTen = "";
                ViewBag.HT = "";
            }

            if (idKH == "")
            {
                ViewBag.idKhach = -1;
                ViewBag.ThongBao = "Vui lòng đăng nhập để xem thông tin của bạn!";
            }
            else
            {
                ViewBag.idKhach = idKH;
                ViewBag.ThongBao = "";
            }
            return View();
        }

    }
}
