using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_DATA.DTO
{
    public class Mon
    {
        public int mamon { get; set; }
        public string tenhanghoa { get; set; }
        public int maloaimon { get; set; }
        public DateTime ngaysanxuat { get; set; }
        public int giahang { get; set; }

        public Mon(DataRow row)
        {
            this.mamon = int.Parse(row["mamon"].ToString());
            this.tenhanghoa = row["tenhanghoa"].ToString();
            this.maloaimon = int.Parse(row["maloaimon"].ToString());
            this.ngaysanxuat = DateTime.Parse(row["ngaysanxuat"].ToString());
            this.giahang = int.Parse(row["giahang"].ToString());
        }

        public Mon(int mamon, string tenhanghoa, int maloaimon, DateTime ngaysanxuat, int giahang)
        {
            this.mamon = mamon;
            this.tenhanghoa = tenhanghoa;
            this.maloaimon = maloaimon;
            this.ngaysanxuat = ngaysanxuat;
            this.giahang = giahang;
        }

        public Mon() { }
    }
}
