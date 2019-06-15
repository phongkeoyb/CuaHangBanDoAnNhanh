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
        public string tenhanghoa { get; set; }
        public int giahang { get; set; }
        public int soluong { get; set; }
        public int thanhtien { get; set; }
        public int mamon { set; get; }

        public int mahd { get; set; }
        //mamon, mahd, soluong, thanhtien
        public ChiTietHoaDon(DataRow row)
        {
            this.tenhanghoa = row["tenhanghoa"].ToString();
            this.giahang = int.Parse(row["giahang"].ToString());
            this.soluong = int.Parse(row["soluong"].ToString());
            this.thanhtien = int.Parse(row["thanhtien"].ToString());
        }

        public ChiTietHoaDon(string tenhanghoa, int giahang, int soluong, int thanhtien)
        {
            this.tenhanghoa = tenhanghoa;
            this.giahang = giahang;
            this.soluong = soluong;
            this.thanhtien = thanhtien;
        }

        public ChiTietHoaDon(int mamon, int mahd, int soluong, int thanhtien)
        {
            this.mamon = mamon;
            this.mahd = mahd;
            this.soluong = soluong;
            this.thanhtien = thanhtien;
        }
        public ChiTietHoaDon() { }
    }
}
