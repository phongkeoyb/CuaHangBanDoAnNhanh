using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_DATA.DTO;

namespace WebAPI_DATA.DAO
{
    public class ChiTietHoaDonDAO
    {
        private ChiTietHoaDonDAO() { }

        private static volatile ChiTietHoaDonDAO instance;

        static object key = new object();

        public static ChiTietHoaDonDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new ChiTietHoaDonDAO();
                    }
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public List<ChiTietHoaDon> GetList(int mahoadon)
        {
            List<ChiTietHoaDon> list = new List<ChiTietHoaDon>();
            DataTable data = DataProvider.Instance.ExecuteQuery($"XemCT {mahoadon}");
            foreach (DataRow item in data.Rows)
            {
                ChiTietHoaDon obj = new ChiTietHoaDon(item);
                list.Add(obj);
            }
            return list;
        }

        public int Create(int mamon, int mahoadon, int soluong, int thanhtien)
        {
            string query = $"INSERT into ChiTietHoaDonBan VALUES  ( '{mamon}', '{mahoadon}', '{soluong}', '{thanhtien}' )";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

    }
}
