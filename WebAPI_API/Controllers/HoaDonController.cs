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
    public class HoaDonController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<HoaDon> item = HoaDonDAO.Instance.GetList();
            if (item.Count == 0)
            {
                return NotFound();
            }
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] HoaDon x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            HoaDonDAO.Instance.Create(x.mahoadon,x.ngaythang,x.manv,x.makh,x.tongtien);
            return Ok();
        }
    }
}
