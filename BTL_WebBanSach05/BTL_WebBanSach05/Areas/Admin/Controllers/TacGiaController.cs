using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class TacGiaController : ApiController
    {
        WebBanSachEntities1 db = new WebBanSachEntities1();
        // GET: api/TacGia
        public List<TACGIA> Get()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.TACGIAs.ToList();
        }

        // GET: api/TacGia/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TacGia
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TacGia/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TacGia/5
        public void Delete(int id)
        {
        }
    }
}
