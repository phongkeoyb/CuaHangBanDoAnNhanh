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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        public string baseAddress = "http://localhost:52381/api/";
        List<NhanVien> listNhanVien = null;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            listNhanVien = loadNhanVien();
            dtgNhanVien.DataSource = listNhanVien;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
