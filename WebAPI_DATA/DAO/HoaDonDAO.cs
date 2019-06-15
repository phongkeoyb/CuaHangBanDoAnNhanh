using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_DATA.DTO;

namespace WebAPI_DATA.DAO
{
    public class HoaDonDAO
    {
        private HoaDonDAO() { }

        private static volatile HoaDonDAO instance;

        static object key = new object();

        public static HoaDonDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new HoaDonDAO();
                    }
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public List<HoaDon> GetList()
        {
            List<HoaDon> list = new List<HoaDon>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM HoaDonBan");
            foreach (DataRow item in data.Rows)
            {
                HoaDon obj = new HoaDon(item);
                list.Add(obj);
            }
            return list;
        }

        public int Create(int mahd, DateTime ngayhoadon, int manv, int makh)
        {
            string query = $"INSERT into HoaDonBan VALUES  ( {mahd},  N'{ngayhoadon}', '0',  '{makh}' , N'{manv}' )";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public DataTable ThanhToan(string dieukien)
        {
            DataTable dth = DataProvider.Instance.ExecuteQuery("select maMon , tenHangHoa , giaHang from Mon " + dieukien);
            return dth;
        }

        public int Update(int mahd, int tongtien)
        {
            string query = $"UPDATE hoadonban SET tongtien = '{tongtien}'  where mahoadon ='{mahd}'";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }
    }
}
