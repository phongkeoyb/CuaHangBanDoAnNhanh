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
    public class LoaiMonController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<LoaiMon> item = LoaiMonDAO.Instance.GetList();
            if (item.Count == 0)
            {
                return NotFound();
            }
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] LoaiMon x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            LoaiMonDAO.Instance.Create(x.maloaimon, x.tenloaimon);
            return Ok();
        }
        
        public IHttpActionResult Put([FromBody] LoaiMon x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            LoaiMonDAO.Instance.Update(x.maloaimon, x.tenloaimon);
            return Ok();
        }

        public IHttpActionResult Delete([FromUri] int maloaimon)
        {
            if (maloaimon <= 0)
                return BadRequest("Not a valid ma loai mon id");
            LoaiMonDAO.Instance.Delete(maloaimon);
            return Ok();
        }
    }
}
