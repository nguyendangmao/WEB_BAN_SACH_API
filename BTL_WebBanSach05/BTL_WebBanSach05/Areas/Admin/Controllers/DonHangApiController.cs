using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class DonHangApiController : ApiController
    {
        WebBanSachEntities1 db = new WebBanSachEntities1();
        // GET: api/DonHangApi
        public Array Get()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<HOADONBAN> hdb = db.HOADONBANs.ToList();

            var list = (from hd in hdb

                        select new
                        {
                            MaDonHang = hd.MAHDBAN,
                            NgayLapHD = hd.NGAYLAPHDBAN,
                            MaKH = hd.ID_KHACHHANG,
                        });

            return list.ToArray();
        }

        // GET: api/DonHangApi/5
        /// Tìm kiếm theo id đơn hàng và id khachsh hàng
        public Array GetChiTietHoaDonKLists(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<HOADONBAN> hdb = db.HOADONBANs.ToList();

            var list = (from hd in hdb
                        where (Convert.ToString(hd.MAHDBAN).Contains(Convert.ToString(id)) ||
                        Convert.ToString(hd.ID_KHACHHANG).Contains(Convert.ToString(id)))
                        
                        select new
                        {
                            MaDonHang = hd.MAHDBAN,
                            NgayLapHD = hd.NGAYLAPHDBAN,
                            MaKH = hd.ID_KHACHHANG,
                        });

            return list.ToArray();
        }

        public Array GetCT_DH(int idDonHang)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<CT_HDBAN> ct_hdb = db.CT_HDBAN.ToList();
            List<SACH> sach = db.SACHes.ToList();

            var list = (from ct_hd in ct_hdb
                        join s in sach on ct_hd.MASACH equals s.MASACH
                        where ct_hd.MAHDBAN == idDonHang

                        select new
                        {
                            MaHD = ct_hd.MAHDBAN,
                            TenSP = s.TENSACH,
                            SL = ct_hd.SLBAN,
                            giaban = s.GIABAN
                        });

            return list.ToArray();
        }
        // POST: api/DonHangApi
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/DonHangApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DonHangApi/5
        public void Delete(int id)
        {
        }
    }
}
