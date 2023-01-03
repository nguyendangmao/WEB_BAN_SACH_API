using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class KhachHangApiController : ApiController
    {
        WebBanSachEntities1 db = new WebBanSachEntities1();
        // GET: api/Sach
        public IEnumerable<TK_KHACHHANG> GetAllKH()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.TK_KHACHHANG;
        }

        // GET: api/KhachHangApi/5
        public Array Get(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<TK_KHACHHANG> KH = db.TK_KHACHHANG.ToList();

            var list = (from sp in KH
                        where (Convert.ToString(sp.ID_KHACHHANG).Contains(Convert.ToString(id)) || sp.SDT_KH.Contains(Convert.ToString(id)))

                        select new
                        {
                           ID_KHACHHANG = sp.ID_KHACHHANG,
                           HOTENKH = sp.HOTENKH,
                           SDT_KH = sp.SDT_KH,
                           DIACHI = sp.DIACHI
                        });

            return list.ToArray();
        }
        public Array GetListDH(int idKH)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<HOADONBAN> hdb = db.HOADONBANs.ToList();

            var list = (from hd in hdb
                        where (hd.ID_KHACHHANG == idKH)

                        select new
                        {
                            MaDonHang = hd.MAHDBAN,
                            NgayLapHD = hd.NGAYLAPHDBAN,
                        });

            return list.ToArray();
        }
        public Array GetCT_DH_KH(int idDH)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<CT_HDBAN> ct_hdb = db.CT_HDBAN.ToList();
            List<SACH> sach = db.SACHes.ToList();

            var list = (from ct_hd in ct_hdb
                        join s in sach on ct_hd.MASACH equals s.MASACH
                        where ct_hd.MAHDBAN == idDH

                        select new
                        {
                            MaHD = ct_hd.MAHDBAN,
                            MaSP = s.MASACH,
                            TenSP = s.TENSACH,
                            SL = ct_hd.SLBAN,
                            giaban = s.GIABAN
                        });

            return list.ToArray();
        }

        // POST: api/KhachHangApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/KhachHangApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/KhachHangApi/5
        public void Delete(int id)
        {
        }
    }
}
