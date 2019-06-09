using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_DATA.DTO
{
    public class ChiTietHoaDon
    {
        public string mahd { get; set; }
        public string mathucdon { get; set; }
        public int soluong { get; set; }
        public float dongia { get; set; }

        public ChiTietHoaDon(DataRow row)
        {
            this.mahd = row["mahd"].ToString();
            this.mathucdon = row["mathucdon"].ToString();
            this.soluong = int.Parse(row["soluong"].ToString());
            this.dongia = float.Parse(row["dongia"].ToString());
        }

        public ChiTietHoaDon(string mahd, string mathucdon, int soluong, float dongia)
        {
            this.mahd = mahd;
            this.mathucdon = mathucdon;
            this.soluong = soluong;
            this.dongia = dongia;
        }

        public ChiTietHoaDon() { }
    }
}
