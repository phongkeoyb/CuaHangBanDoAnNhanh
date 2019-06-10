using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebAPI_DATA.DAO;
using WebAPI_DATA.DTO;

namespace WebAPI_WindowsForms
{
    public partial class frmHoaDon : Form
    {
        
        public frmHoaDon()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gio.Text = DateTime.Now.ToLongTimeString();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            load();
        }

        public string baseAddress = "http://localhost:52381/api/";
        List<KhachHang> listKhachHang = null;
        List<Mon> listMon = null;
        List<HoaDon> listHoaDon = null;
        List<LoaiMon> listLoaiMon = null;
        List<NhanVien> listNhanVien = null;

        private List<LoaiMon> LoadLoaiMon()
        {
            List<LoaiMon> listLoaiMon = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("LoaiMon");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<LoaiMon>>();
                    readTask.Wait();
                    listLoaiMon = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..    
                }
            }
            return listLoaiMon;
        }

        private List<Mon> loadMon()
        {
            List<Mon> listMon = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("Mon");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Mon>>();
                    readTask.Wait();
                    listMon = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..    
                }
            }
            return listMon;
        }

        private List<KhachHang> loadKhachHang()
        {
            List<KhachHang> listKhachHang = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("KhachHang");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<KhachHang>>();
                    readTask.Wait();
                    listKhachHang = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..    
                }
            }
            return listKhachHang;
        }

        private List<HoaDon> loadHoaDon()
        {
            List<HoaDon> listHoaDon = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("HoaDon");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<HoaDon>>();
                    readTask.Wait();
                    listHoaDon = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..    
                }
            }
            return listHoaDon;
        }

        private List<NhanVien> loadNhanVien()
        {
            List<NhanVien> listNhanVien = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("NhanVien");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<NhanVien>>();
                    readTask.Wait();
                    listNhanVien = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..    
                }
            }
            return listNhanVien;
        }

        public void load()
        {
            listMon = loadMon();
            listKhachHang = loadKhachHang();
            listHoaDon = loadHoaDon();
            listNhanVien = loadNhanVien();
            dtgMon.DataSource = listMon;
            dtgHoaDon.DataSource = listHoaDon;
            danhsachmon();
            cbMaKhachHang.DataSource = listKhachHang;
            cbMaKhachHang.DisplayMember = "MaKhachHang";

            cbMaNhanVien.DataSource = listNhanVien;
            cbMaNhanVien.DisplayMember = "maNV";
        }

        void danhsachmon()
        {
            listLoaiMon = LoadLoaiMon();
            cbLoaiHangHoa.DataSource = listLoaiMon;
            cbLoaiHangHoa.DisplayMember = "TenLoaiMon";
        }

        void danhsachloaimontheoid(int id)
        {
            List<Mon> listMon = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"Mon?maloaimon={id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Mon>>();
                    readTask.Wait();
                    listMon = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..    
                }
            }

            cbTenHangHoa.DataSource = listMon;
            cbTenHangHoa.DisplayMember = "TenHangHoa";
        }

        private void txtTimMon_TextChanged(object sender, EventArgs e)
        {
            // Mon?TenHangHoa={TenHangHoa}
            List<Mon> listMon = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"Mon?TenHangHoa={txtTimMon.Text}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Mon>>();
                    readTask.Wait();
                    listMon = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..    
                }
            }
            dtgMon.DataSource = listMon;
        }

        private void dtgMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                cbTenHangHoa.Text = dtgMon.Rows[index].Cells[1].Value.ToString();
            }
        }

        private void cbLoaiHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if(cb.SelectedItem == null) { return; }

            LoaiMon selected = cb.SelectedItem as LoaiMon;
            id = selected.maloaimon;

            danhsachloaimontheoid(id);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang khachHang = new frmKhachHang();
            khachHang.ShowDialog();
        }

        public void loadKhachHang(int id)
        {
            //KhachHang?makhachhang={makhachhang}
            List<KhachHang> listKhachHang = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"KhachHang?makhachhang={id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<KhachHang>>();
                    readTask.Wait();
                    listKhachHang = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..    
                }
            }
            //listKhachHang = KhachHangDAO.Instance.KhachHangID(id);
            foreach (var item in listKhachHang)
            {
                txtDiaChi.Text = item.diachi;
                txtTenKhachHang.Text = item.hoten;
                txtSDT.Text = item.sdt;
            }
        }

        public void loadNhanvien(int manhanvien)
        {
            //NhanVien?manhanvien={manhanvien}
            List<NhanVien> listNhanVien = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"NhanVien?manhanvien={manhanvien}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<NhanVien>>();
                    readTask.Wait();
                    listNhanVien = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..    
                }
            }
            //listKhachHang = KhachHangDAO.Instance.KhachHangID(id);
            foreach (var item in listNhanVien)
            {
                txtTenNhanVien.Text = item.tennv;
            }
        }

        private void cbMaKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            int makh = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) { return; }
            KhachHang selected = cb.SelectedItem as KhachHang;
            makh = selected.makhachhang;
            loadKhachHang(makh);

        }

        private void cbMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int manv = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) { return; }
            NhanVien selected = cb.SelectedItem as NhanVien;
            manv = selected.manv;
            loadNhanvien(manv);
        }
        

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien nhanVien = new frmNhanVien();
            nhanVien.ShowDialog();
        }
    }
}
