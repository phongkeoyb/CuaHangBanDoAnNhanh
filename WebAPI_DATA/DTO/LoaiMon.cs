using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_DATA.DTO
{
    public class LoaiMon
    {
        public int maloaimon { get; set; }
        public string tenloaimon { get; set; }

        public LoaiMon(DataRow row)
        {
            this.maloaimon = int.Parse(row["maloaimon"].ToString());
            this.tenloaimon = row["tenloaimon"].ToString();
        }

        public LoaiMon(int maloaimon, string tenloaimon)
        {
            this.maloaimon = maloaimon;
            this.tenloaimon = tenloaimon;
        }

        public LoaiMon() { }
    }
}
