using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_DATA.DTO
{
    public class KhachHang
    {
        public int makhachhang { get; set; }
        public string hoten { get; set; }
        public DateTime ngaysinh { get; set; }
        public string diachi { get; set; }
        public string sdt { get; set; }
        public string gioitinh { get; set; }

        public KhachHang(DataRow row)
        {
            this.makhachhang = Int32.Parse(row["makhachhang"].ToString());
            this.hoten = row["hoten"].ToString();
            this.diachi = row["diachi"].ToString();
            this.gioitinh = row["gioitinh"].ToString();
            this.sdt = row["sdt"].ToString();
            this.ngaysinh = DateTime.Parse(row["ngaysinh"].ToString());
        }
        public KhachHang(int makhachhang, string hoten, DateTime ngaysinh, string diachi, string gioitinh, string sdt)
        {
            this.makhachhang = makhachhang;
            this.hoten = hoten;
            this.diachi = diachi;
            this.gioitinh = gioitinh;
            this.sdt = sdt;
            this.ngaysinh = ngaysinh;
        }

        public KhachHang() { }
    }
}
