using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_DATA.DTO;

namespace WebAPI_DATA.DAO
{
    public class MonDAO
    {
        private MonDAO() { }

        private static volatile MonDAO instance;

        static object key = new object();

        public static MonDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new MonDAO();
                    }
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public List<Mon> GetList()
        {
            List<Mon> list = new List<Mon>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Mon");
            foreach (DataRow item in data.Rows)
            {
                Mon obj = new Mon(item);
                list.Add(obj);
            }
            return list;
        }
        
        public List<Mon> TimKiemMonAN(string tenhanghoa)
        {
            List<Mon> list = new List<Mon>();
            string query = $"SELECT * FROM mon where  tenhanghoa like N'%{tenhanghoa}%' ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Mon obj = new Mon(item);
                list.Add(obj);
            }
            return list;
        }
    }
}
