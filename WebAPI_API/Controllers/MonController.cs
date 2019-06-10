﻿using System;
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
    }
}
