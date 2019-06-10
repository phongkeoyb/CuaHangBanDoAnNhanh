using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_DATA.DTO;

namespace WebAPI_DATA.DAO
{
    public class KhachHangDAO
    {
        private KhachHangDAO() { }

        private static volatile KhachHangDAO instance;

        static object key = new object();

        public static KhachHangDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new KhachHangDAO();
                    }
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }


        public List<KhachHang> GetList()
        {
            List<KhachHang> list = new List<KhachHang>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM KhachHang");
            foreach (DataRow item in data.Rows)
            {
                KhachHang obj = new KhachHang(item);
                list.Add(obj);
            }
            return list;
        }

        public int Create(int makhachhang, string hoten, DateTime ngaysinh, string gioitinh, string diachi, string sdt)
        {
            string query = $"INSERT into KhachHang VALUES  ( {makhachhang},  N'{hoten}', N'{ngaysinh}',  '{gioitinh}' , N'{diachi}', '{sdt}' )";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

        public int Update(int makhachhang, string hoten, DateTime ngaysinh, string gioitinh, string diachi, string sdt)
        {
            string query = $"UPDATE KhachHang SET hoten=N'{hoten}',diachi=N'{diachi}',gioitinh='{gioitinh}', SDT ='{sdt}', ngaysinh =N'{ngaysinh}' where makhachhang={makhachhang}";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }
        public int Delete(int makhachhang)
        {
            string query = $"DELETE KhachHang WHERE makhachhang={makhachhang}";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }

        public List<KhachHang> TimKiemKhachHang(string hoten, string diachi, string sdt)
        {
            List<KhachHang> list = new List<KhachHang>();
            string query = $"SELECT * FROM KhachHang where hoten like '%{hoten}%' or diachi like '%{diachi}%' or sdt like '%{sdt}%' ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                KhachHang obj = new KhachHang(item);
                list.Add(obj);
            }
            return list;
        }

        public List<KhachHang> KhachHangID(int makhachang)
        {
            List<KhachHang> list = new List<KhachHang>();
            string query = $"SELECT * FROM KhachHang where makhachhang = '{makhachang}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                KhachHang obj = new KhachHang(item);
                list.Add(obj);
            }
            return list;
        }
    }
}
