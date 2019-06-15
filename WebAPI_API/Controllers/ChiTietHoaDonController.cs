using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_DATA.DAO;
using WebAPI_DATA.DTO;

namespace WebAPI_API.Controllers
{
    public class ChiTietHoaDonController : ApiController
    {
        public IHttpActionResult Get(int mahd)
        {
            List<ChiTietHoaDon> item = ChiTietHoaDonDAO.Instance.GetList(mahd);
            if (item.Count == 0)
            {
                return NotFound();
            }
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] ChiTietHoaDon x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            ChiTietHoaDonDAO.Instance.Create(x.mamon, x.mahd, x.soluong, x.thanhtien);
            return Ok();
        }
    }
}
