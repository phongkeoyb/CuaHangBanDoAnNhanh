using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_DATA.DTO
{
    public class HoaDon
    {
        public int mahoadon { get; set; }
        public DateTime ngaythang { get; set; }
        public int manv { get; set; }
        public int makh { get; set; }
        public int tongtien { get; set; }

        public HoaDon(DataRow row)
        {
            this.mahoadon = int.Parse(row["mahoadon"].ToString());
            this.ngaythang = DateTime.Parse(row["ngaythang"].ToString());
            this.manv = int.Parse(row["manv"].ToString());
            this.makh = int.Parse(row["makhachhang"].ToString());
            this.tongtien = int.Parse(row["tongtien"].ToString());
        }
        public HoaDon(int mahd, DateTime ngayhoadon, int manv, int makh, int tongtien)
        {
            this.mahoadon = mahd;
            this.ngaythang = ngayhoadon;
            this.manv = manv;
            this.makh = makh;
            this.tongtien = tongtien;
        }

        public HoaDon(int mahd, int tongtien)
        {
            this.mahoadon = mahd;
            this.tongtien = tongtien;
        }

        public HoaDon() { }
    }
}
