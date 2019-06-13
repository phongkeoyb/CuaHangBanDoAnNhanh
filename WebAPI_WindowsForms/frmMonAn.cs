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
using WebAPI_DATA.DTO;

namespace WebAPI_WindowsForms
{
    public partial class frmMonAn : Form
    {
        public frmMonAn()
        {
            InitializeComponent();
            load();
        }

        public string baseAddress = "http://localhost:52381/api/";
        List<Mon> listMon = null;
        List<LoaiMon> listLoaiMon = null;

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

        void load()
        {
            listLoaiMon = LoadLoaiMon();
            listMon = loadMon();
            dtgLoaiHangHoa.DataSource = listLoaiMon;
            dtgMon.DataSource = listMon;
            cbLoaiHangHoa.DataSource = listLoaiMon;
            cbLoaiHangHoa.DisplayMember = "maloaimon";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void dtgLoaiHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaLoaiMon.Text = dtgLoaiHangHoa.Rows[index].Cells[0].Value.ToString();
                txtTenHH.Text = dtgLoaiHangHoa.Rows[index].Cells[1].Value.ToString();
            }
        }

        private void dtgMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaHangHoa.Text = dtgMon.Rows[index].Cells[0].Value.ToString();
                txtTenHangHoa.Text = dtgMon.Rows[index].Cells[1].Value.ToString();
                cbLoaiHangHoa.Text = dtgMon.Rows[index].Cells[2].Value.ToString();
                dateTimeNSX.Text = dtgMon.Rows[index].Cells[3].Value.ToString();
                txtDonGia.Text = dtgMon.Rows[index].Cells[4].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int mamon = int.Parse(txtMaHangHoa.Text);
            string tenhanghoa = txtTenHangHoa.Text;
            int loaihanghoa = int.Parse(cbLoaiHangHoa.Text);
            DateTime nsx = DateTime.Parse(dateTimeNSX.Text);
            int dongia = int.Parse(txtDonGia.Text);
            Mon mon = new Mon(mamon, tenhanghoa, loaihanghoa, nsx, dongia);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Mon>("Mon", mon);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm món thành công", "Thông báo", MessageBoxButtons.OK);
                }
            }
            load();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int mamon = int.Parse(txtMaHangHoa.Text);
            string tenhanghoa = txtTenHangHoa.Text;
            int loaihanghoa = int.Parse(cbLoaiHangHoa.Text);
            DateTime nsx = DateTime.Parse(dateTimeNSX.Text);
            int dongia = int.Parse(txtDonGia.Text);
            Mon mon = new Mon(mamon, tenhanghoa, loaihanghoa, nsx, dongia);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<Mon>("Mon", mon);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sửa món thành công", "Thông báo", MessageBoxButtons.OK);
                }
            }
            load();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int mamon = int.Parse(txtMaHangHoa.Text);
            using (var client = new HttpClient())
            {
                //HTTP DELETE
                client.BaseAddress = new Uri(baseAddress);
                var deleteTask = client.DeleteAsync($"Mon?mamon={mamon}");
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Xóa thành công ");
                }

            }
            load();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int LoaiMon = int.Parse(txtMaLoaiMon.Text);
            string tenloaihang = txtTenHH.Text;
            LoaiMon loaiMon = new LoaiMon(LoaiMon,tenloaihang);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<LoaiMon>("LoaiMon", loaiMon);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm loại hàng thành công", "Thông báo", MessageBoxButtons.OK);
                }
            }
            load();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int LoaiMon = int.Parse(txtMaLoaiMon.Text);
            string tenloaihang = txtTenHH.Text;
            LoaiMon loaiMon = new LoaiMon(LoaiMon, tenloaihang);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<LoaiMon>("LoaiMon", loaiMon);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                }
            }
            load();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //LoaiMon?maloaimon={maloaimon}
            int maloaimon = int.Parse(txtMaLoaiMon.Text);
            using (var client = new HttpClient())
            {
                //HTTP DELETE
                client.BaseAddress = new Uri(baseAddress);
                var deleteTask = client.DeleteAsync($"LoaiMon?maloaimon={maloaimon}");
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Xóa thành công ");
                }

            }
            load();
        }
    }
}
