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
            load();
        }

        public void load()
        {
            listNhanVien = loadNhanVien();
            dtgNhanVien.DataSource = listNhanVien;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int maNV = int.Parse(txtMaNhanVien.Text);
            string tenNV = txtTenNhanVien.Text;
            DateTime ngaysinh = DateTime.Parse(dateTimeNS.Text);
            string quequan = txtQueQuan.Text;
            string sdt = txtSDT.Text;
            string tendangnhap = txtTenDangNhap.Text;
            string matkhau = txtMatKhau.Text;

            NhanVien nhanVien = new NhanVien(maNV, tenNV, ngaysinh, quequan, tendangnhap, sdt, matkhau);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<NhanVien>("NhanVien", nhanVien);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK);
                }
            }

            load();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int maNV = int.Parse(txtMaNhanVien.Text);
            string tenNV = txtTenNhanVien.Text;
            DateTime ngaysinh = DateTime.Parse(dateTimeNS.Text);
            string quequan = txtQueQuan.Text;
            string sdt = txtSDT.Text;
            string tendangnhap = txtTenDangNhap.Text;
            string matkhau = txtMatKhau.Text;
            NhanVien nhanVien = new NhanVien(maNV, tenNV, ngaysinh, quequan, tendangnhap, sdt, matkhau);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<NhanVien>("NhanVien", nhanVien);

                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                }
                load();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNhanVien.Text;
            using (var client = new HttpClient())
            {
                //HTTP DELETE
                client.BaseAddress = new Uri(baseAddress);
                var deleteTask = client.DeleteAsync($"NhanVien?manv={maNV}");
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Xóa thành công ");
                }
            }

            load();
        }

        private void dtgNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaNhanVien.Text = dtgNhanVien.Rows[index].Cells[0].Value.ToString();
                txtTenNhanVien.Text = dtgNhanVien.Rows[index].Cells[1].Value.ToString();
                dateTimeNS.Text = dtgNhanVien.Rows[index].Cells[2].Value.ToString();
                txtQueQuan.Text = dtgNhanVien.Rows[index].Cells[3].Value.ToString();
                txtSDT.Text = dtgNhanVien.Rows[index].Cells[4].Value.ToString();
                txtTenDangNhap.Text = dtgNhanVien.Rows[index].Cells[5].Value.ToString();
                txtMatKhau.Text = dtgNhanVien.Rows[index].Cells[6].Value.ToString();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string timkiem = txtTimKiem.Text;
            List<NhanVien> listNhanVien = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"NhanVien?tenNV={timkiem}&quenquan={timkiem}&sdt={timkiem}");
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
            dtgNhanVien.DataSource = listNhanVien;
        }
    }
}
