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

        [HttpGet]
        public IHttpActionResult TimKiemNhanVien([FromUri] string tenNV, string quenquan, string sdt)
        {
            List<NhanVien> item = NhanVienDAO.Instance.TimKiemNhanVien(tenNV, quenquan, sdt);
            if (item.Count == 0)
            {
                return NotFound();
            }
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] NhanVien x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            NhanVienDAO.Instance.Create(x.manv,x.tennv,x.ngaysinh,x.quequan,x.sdt,x.tendangnhap,x.matkhau);
            return Ok();
        }

        public IHttpActionResult Put([FromBody] NhanVien x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            NhanVienDAO.Instance.Update(x.manv,x.tennv,x.ngaysinh,x.quequan,x.sdt,x.tendangnhap,x.matkhau);
            return Ok();
        }

        public IHttpActionResult Delete([FromUri] int manv)
        {
            if (manv <= 0)
                return BadRequest("Not a valid ma nhan vien id");
            NhanVienDAO.Instance.Delete(manv);
            return Ok();
        }
    }
}
