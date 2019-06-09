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
        [HttpGet]
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
        public IHttpActionResult TimKiemMonAn(string TenHangHoa)
        {
            List<Mon> item = MonDAO.Instance.TimKiemMonAN(TenHangHoa);
            if (item.Count == 0)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
