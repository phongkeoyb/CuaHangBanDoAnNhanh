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
    }
}
