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

        public void load()
        {
            listMon = loadMon();
            listKhachHang = loadKhachHang();
            listHoaDon = loadHoaDon();
            dtgMon.DataSource = listMon;
            dtgHoaDon.DataSource = listHoaDon;
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
                cbLoaiHangHoa.Text = dtgMon.Rows[index].Cells[0].Value.ToString();
            }
        }
    }
}
