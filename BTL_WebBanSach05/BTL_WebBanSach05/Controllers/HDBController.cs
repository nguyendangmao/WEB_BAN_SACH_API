using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Controllers
{
    public class HDBController : ApiController
    {
        WebBanSachEntities1 db = new WebBanSachEntities1();
        // GET: api/HDB
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/HDB/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HDB
        [HttpPost]
        public bool InsertHDB(int idKH)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                HOADONBAN hdb = new HOADONBAN();

                hdb.ID_KHACHHANG = idKH;
                hdb.NGAYLAPHDBAN = DateTime.Now;

                db.HOADONBANs.Add(hdb);
                db.SaveChanges();

                List<GIOHANG> gh = db.GIOHANGs.Where(n => n.ID_KHACHHANG == idKH).ToList();
                foreach (var item in gh)
                {
                    CT_HDBAN ctHDB = new CT_HDBAN();
                    ctHDB.MAHDBAN = hdb.MAHDBAN;
                    ctHDB.MASACH = item.MASACH;
                    ctHDB.SLBAN = item.SOLUONG;
                    ctHDB.KHUYENMAI = "";
                    db.CT_HDBAN.Add(ctHDB);
                    db.SaveChanges();

                    //update so luong sach
                    SACH sanpham = db.SACHes.FirstOrDefault(x => x.MASACH == item.MASACH);
                    if (sanpham == null)
                    {
                        return false;
                    }
                    sanpham.MASACH = sanpham.MASACH;
                    sanpham.TENSACH = sanpham.TENSACH;
                    sanpham.TENANH = sanpham.TENANH;
                    sanpham.NGUOIDICH = sanpham.NGUOIDICH;
                    sanpham.NGONNGU = sanpham.NGONNGU;
                    sanpham.SOTRANG = sanpham.SOTRANG;
                    sanpham.TRONGLUONG = sanpham.TRONGLUONG;
                    sanpham.NAMXUATBAN = sanpham.NAMXUATBAN;
                    sanpham.KICHTHUOC = sanpham.KICHTHUOC;
                    sanpham.MATHELOAI = sanpham.MATHELOAI;
                    sanpham.MATACGIA = sanpham.MATACGIA;
                    sanpham.MANXB = sanpham.MANXB;
                    sanpham.GIANHAP = sanpham.GIANHAP;
                    sanpham.GIABAN = sanpham.GIABAN;
                    sanpham.SOLUONG = sanpham.SOLUONG - item.SOLUONG;

                    db.SaveChanges();

                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        // PUT: api/HDB/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HDB/5
        public void Delete(int id)
        {
        }
    }
}
