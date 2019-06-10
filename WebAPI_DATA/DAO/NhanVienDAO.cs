using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_DATA.DTO;

namespace WebAPI_DATA.DAO
{
    public class NhanVienDAO
    {
        private NhanVienDAO() { }

        private static volatile NhanVienDAO instance;

        static object key = new object();

        public static NhanVienDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new NhanVienDAO();
                    }
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }


        public List<NhanVien> GetList()
        {
            List<NhanVien> list = new List<NhanVien>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM NhanVien");
            foreach (DataRow item in data.Rows)
            {
                NhanVien obj = new NhanVien(item);
                list.Add(obj);
            }
            return list;
        }

        public List<NhanVien> NhanVienID(int manhanvien)
        {
            List<NhanVien> list = new List<NhanVien>();
            string query = $"SELECT * FROM NhanVien where manv = '{manhanvien}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                NhanVien obj = new NhanVien(item);
                list.Add(obj);
            }
            return list;
        }
    }
}
