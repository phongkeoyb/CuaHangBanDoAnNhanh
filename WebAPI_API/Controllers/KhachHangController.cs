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
    public class KhachHangController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<KhachHang> item = KhachHangDAO.Instance.GetList();
            if (item.Count == 0)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] KhachHang x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            KhachHangDAO.Instance.Create(x.makhachhang,x.hoten,x.ngaysinh,x.gioitinh,x.diachi,x.sdt);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] KhachHang x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            KhachHangDAO.Instance.Update(x.makhachhang, x.hoten, x.ngaysinh, x.gioitinh, x.diachi, x.sdt);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Delete([FromUri] int makhachhang)
        {
            if (makhachhang <= 0)
                return BadRequest("Not a valid Khach hang id");
            KhachHangDAO.Instance.Delete(makhachhang);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult TimKiemKhachHang([FromUri] string hoten, string diachi, string sdt)
        {
            List<KhachHang> item = KhachHangDAO.Instance.TimKiemKhachHang(hoten, diachi,sdt);
            if (item.Count == 0)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
