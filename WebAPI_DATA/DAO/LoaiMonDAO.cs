using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_DATA.DTO;

namespace WebAPI_DATA.DAO
{
    public class LoaiMonDAO
    {
        private LoaiMonDAO() { }

        private static volatile LoaiMonDAO instance;

        static object key = new object();

        public static LoaiMonDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new LoaiMonDAO();
                    }
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public List<LoaiMon> GetList()
        {
            List<LoaiMon> list = new List<LoaiMon>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM LoaiMon");
            foreach (DataRow item in data.Rows)
            {
                LoaiMon obj = new LoaiMon(item);
                list.Add(obj);
            }
            return list;
        }

        
        public int Create(int maloaimon, string tenloaimon)
        {
            string query = $"INSERT into LoaiMon VALUES  ( '{maloaimon}',N'{tenloaimon}' )";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

        public int Update(int maloaimon, string tenloaimon)
        {
            string query = $"UPDATE LoaiMon SET Tenloaimon = N'{tenloaimon}' where maloaimon='{maloaimon}'";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }

        public int Delete(int maloaimon)
        {
            string query = $"delete LoaiMon where maloaimon = '{maloaimon}'";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }
    }
}
