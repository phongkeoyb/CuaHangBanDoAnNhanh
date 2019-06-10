using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_DATA.DTO
{
    public class NhanVien
    {
        public int manv { get; set; }
        public string tennv { get; set; }
        public DateTime ngaysinh { get; set; }
        public string quequan { get; set; }
        public string sdt { get; set; }
        public string tendangnhap { get; set; }
        public string matkhau { get; set; }

        public NhanVien(DataRow row)
        {
            this.manv = Int32.Parse(row["manv"].ToString());
            this.tennv = row["tennv"].ToString();
            this.quequan = row["quequan"].ToString();
            this.tendangnhap = row["tendangnhap"].ToString();
            this.matkhau = row["matkhau"].ToString();
            this.sdt = row["sdt"].ToString();
            this.ngaysinh = DateTime.Parse(row["ngaysinh"].ToString());
        }
        public NhanVien(int manv, string tennv, DateTime ngaysinh, string quequan, string tendangnhap, string sdt, string matkhau)
        {
            this.manv = manv;
            this.tennv = tennv;
            this.quequan = quequan;
            this.tendangnhap = tendangnhap;
            this.matkhau = matkhau;
            this.sdt = sdt;
            this.ngaysinh = ngaysinh;
        }

        public NhanVien() { }
    }
}
