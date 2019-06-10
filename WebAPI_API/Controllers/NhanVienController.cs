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
    public class NhanVienController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<NhanVien> item = NhanVienDAO.Instance.GetList();
            if (item.Count == 0)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet]
        public IHttpActionResult NhanVienID([FromUri] int manhanvien)
        {
            List<NhanVien> item = NhanVienDAO.Instance.NhanVienID(manhanvien);
            if (item.Count == 0)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
