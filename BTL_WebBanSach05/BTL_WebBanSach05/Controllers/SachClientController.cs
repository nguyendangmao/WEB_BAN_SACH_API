using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Controllers
{
    public class SachClientController : ApiController
    {
        WebBanSachEntities1 db = new WebBanSachEntities1();
        // GET: api/SachClient
        public Array Get()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<SACH> sach = db.SACHes.ToList();
            List<TACGIA> tacgia = db.TACGIAs.ToList();
            List<THELOAI> theloai = db.THELOAIs.ToList();
            List<NXB> nxb = db.NXBs.ToList();

            var list = (from sp in sach
                        join tg in tacgia on sp.MATACGIA equals tg.MATACGIA
                        join tl in theloai on sp.MATHELOAI equals tl.MATHELOAI
                        join n in nxb on sp.MANXB equals n.MANXB
                        select new
                        {
                            MaSanPham = sp.MASACH,
                            TenSanPham = sp.TENSACH,
                            TenAnh = sp.TENANH,
                            NGUOIDICH = sp.NGUOIDICH,
                            NGONNGU = sp.NGONNGU,
                            SOTRANG = sp.SOTRANG,
                            TRONGLUONG = sp.TRONGLUONG,
                            NAMXUATBAN = sp.NAMXUATBAN,
                            KICHTHUOC = sp.KICHTHUOC,
                            GIANHAP = sp.GIANHAP,
                            GIABAN = sp.GIABAN,
                            SoLuong = sp.SOLUONG,
                            TenTacGia = tg.TENTACGIA,
                            TheLoai = tl.TENTHELOAI,
                            NXB = n.TENNXB
                        });

            return list.ToArray();
        }

        // GET: api/SachClient/5
        public Array Get(int idSP)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<SACH> sach = db.SACHes.ToList();
            List<TACGIA> tacgia = db.TACGIAs.ToList();
            List<THELOAI> theloai = db.THELOAIs.ToList();
            List<NXB> nxb = db.NXBs.ToList();

            var list = (from sp in sach
                        join tg in tacgia on sp.MATACGIA equals tg.MATACGIA
                        join tl in theloai on sp.MATHELOAI equals tl.MATHELOAI
                        join n in nxb on sp.MANXB equals n.MANXB
                        where sp.MASACH == idSP

                        select new
                        {
                            MaSanPham = sp.MASACH,
                            TenSanPham = sp.TENSACH,
                            TenAnh = sp.TENANH,
                            NGUOIDICH = sp.NGUOIDICH,
                            NGONNGU = sp.NGONNGU,
                            SOTRANG = sp.SOTRANG,
                            TRONGLUONG = sp.TRONGLUONG,
                            NAMXUATBAN = sp.NAMXUATBAN,
                            KICHTHUOC = sp.KICHTHUOC,
                            GIANHAP = sp.GIANHAP,
                            GIABAN = sp.GIABAN,
                            SoLuong = sp.SOLUONG,
                            TenTacGia = tg.TENTACGIA,
                            TheLoai = tl.TENTHELOAI,
                            NXB = n.TENNXB
                        });

            return list.ToArray();
        }

        // GET: api/SachClient/5
        public Array GetSachTL(int idTheLoai)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<SACH> sach = db.SACHes.ToList();
            List<TACGIA> tacgia = db.TACGIAs.ToList();
            List<THELOAI> theloai = db.THELOAIs.ToList();
            List<NXB> nxb = db.NXBs.ToList();

            var list = (from sp in sach
                        join tg in tacgia on sp.MATACGIA equals tg.MATACGIA
                        join tl in theloai on sp.MATHELOAI equals tl.MATHELOAI
                        join n in nxb on sp.MANXB equals n.MANXB
                        where sp.MATHELOAI == idTheLoai

                        select new
                        {
                            MaSanPham = sp.MASACH,
                            TenSanPham = sp.TENSACH,
                            TenAnh = sp.TENANH,
                            NGUOIDICH = sp.NGUOIDICH,
                            NGONNGU = sp.NGONNGU,
                            SOTRANG = sp.SOTRANG,
                            TRONGLUONG = sp.TRONGLUONG,
                            NAMXUATBAN = sp.NAMXUATBAN,
                            KICHTHUOC = sp.KICHTHUOC,
                            GIANHAP = sp.GIANHAP,
                            GIABAN = sp.GIABAN,
                            SoLuong = sp.SOLUONG,
                            TenTacGia = tg.TENTACGIA,
                            TheLoai = tl.TENTHELOAI,
                            NXB = n.TENNXB
                        });

            return list.ToArray();
        }

        public Array GetGioHang(string idKH)
        {
            db.Configuration.ProxyCreationEnabled = false;
            int id = int.Parse(idKH.ToString().Trim());

            List<SACH> sach = db.SACHes.ToList();
            List<TK_KHACHHANG> kh = db.TK_KHACHHANG.ToList();
            List<GIOHANG> cart = db.GIOHANGs.ToList();

            var list = (from sp in sach
                        join gh in cart on sp.MASACH equals gh.MASACH
                        join k in kh on gh.ID_KHACHHANG equals k.ID_KHACHHANG
                        where k.ID_KHACHHANG == id

                        select new
                        {
                            Id_GH = gh.ID_GIOHANG,
                            MaSanPham = sp.MASACH,
                            TenSanPham = sp.TENSACH,
                            TenAnh = sp.TENANH,
                            SL = gh.SOLUONG,
                            giaban = sp.GIABAN,
                        });

            return list.ToArray();
        }


        // POST: api/SachClient
        [HttpPost]
        public bool InsertGH(int idKH, int MaSach, int Soluong)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;

                SACH sach = db.SACHes.Where(n => n.MASACH == MaSach).FirstOrDefault();
                GIOHANG gh = db.GIOHANGs.Where(n => n.MASACH == MaSach && n.ID_KHACHHANG == idKH).FirstOrDefault();
                if (sach.SOLUONG <= 0)
                {
                    return false;
                }
                else if(gh != null)
                {
                    gh.ID_GIOHANG = gh.ID_GIOHANG;
                    gh.ID_KHACHHANG = gh.ID_KHACHHANG;
                    gh.MASACH = gh.MASACH;
                    gh.SOLUONG = gh.SOLUONG + Soluong;

                    db.SaveChanges();
                    return true;
                }
                else
                {
                    GIOHANG giohang = new GIOHANG();

                    giohang.ID_KHACHHANG = idKH;
                    giohang.MASACH = MaSach;
                    giohang.SOLUONG = Soluong;

                    db.GIOHANGs.Add(giohang);
                    db.SaveChanges();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // PUT: api/SachClient/5
        //4. sua thong tin san pham
        [HttpPut]
        public bool UpdateSP(int idGH, int idKH, int MaSach, int Soluong)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                GIOHANG giohang = db.GIOHANGs.FirstOrDefault(x => x.ID_GIOHANG == idGH);
                if (giohang == null)
                {
                    return false;
                }
                if (Soluong > 0)
                {
                    giohang.ID_KHACHHANG = idKH;
                    giohang.MASACH = MaSach;
                    giohang.SOLUONG = Soluong;
                }
                db.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
        // DELETE: api/SachClient/5

        [HttpDelete]
        public bool DeleteSPGH(int idGH)
        {
            try
            {
                GIOHANG gh = db.GIOHANGs.FirstOrDefault(x => x.ID_GIOHANG == idGH);
                if (gh == null)
                {
                    return false;
                }

                db.GIOHANGs.Remove(gh);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
