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
    public class MonController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<Mon> item = MonDAO.Instance.GetList();
            if (item.Count == 0)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet]
        public IHttpActionResult TimKiemMonAn([FromUri] string TenHangHoa)
        {
            List<Mon> item = MonDAO.Instance.TimKiemMonAN(TenHangHoa);
            if (item.Count == 0)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet]
        public IHttpActionResult TimKiemMonAN([FromUri] int maloaimon)
        {
            List<Mon> item = MonDAO.Instance.LoaiMonAn(maloaimon);
            if (item.Count == 0)
            {
                return NotFound();
            }
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] Mon x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            MonDAO.Instance.Create(x.mamon,x.tenhanghoa,x.maloaimon,x.ngaysanxuat,x.giahang);
            return Ok();
        }

        public IHttpActionResult Put([FromBody] Mon x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            MonDAO.Instance.Update(x.mamon,x.tenhanghoa,x.maloaimon,x.ngaysanxuat,x.giahang);
            return Ok();
        }

        public IHttpActionResult Delete([FromUri] int mamon)
        {
            if (mamon <= 0)
                return BadRequest("Not a valid mamon");
            MonDAO.Instance.Delete(mamon);
            return Ok();
        }
    }
}
