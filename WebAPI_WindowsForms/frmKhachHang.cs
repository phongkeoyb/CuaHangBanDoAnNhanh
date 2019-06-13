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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
            load();
        }

        public string baseAddress = "http://localhost:52381/api/";
        List<KhachHang> listKhachHang = null;

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

        public void load()
        {
            listKhachHang = loadKhachHang();
            dtgKhachHang.DataSource = listKhachHang;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int makh = int.Parse(txtMaKH.Text);
            string tenkhachhang = txtTenKH.Text;
            DateTime ngaysinh = DateTime.Parse(datetimeNS.Text);
            string gioitinh = rbtnNam.Text;
            if(rbtnNam.Checked == true)
            {
                gioitinh = rbtnNam.Text;
            }
            else
            {
                gioitinh = rbtnNu.Text;
            }
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;

            KhachHang khachhang = new KhachHang(makh,tenkhachhang,ngaysinh,diachi,gioitinh,sdt);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<KhachHang>("KhachHang", khachhang);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm khách hàng thành công","Thông báo",MessageBoxButtons.OK);
                }
            }

            load();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int makh = int.Parse(txtMaKH.Text);
            string tenkhachhang = txtTenKH.Text;
            DateTime ngaysinh = DateTime.Parse(datetimeNS.Text);
            string gioitinh = rbtnNam.Text;
            if (rbtnNam.Checked == true)
            {
                gioitinh = "1";
            }
            else
            {
                gioitinh = "0";
            }
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;

            KhachHang khachhang = new KhachHang(makh, tenkhachhang, ngaysinh, diachi, gioitinh, sdt);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<KhachHang>("KhachHang", khachhang);

                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sửa thành công","Thông báo",MessageBoxButtons.OK);
                }
                load();
            }
        }

        private void dtgKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaKH.Text = dtgKhachHang.Rows[index].Cells[0].Value.ToString();
                txtTenKH.Text = dtgKhachHang.Rows[index].Cells[1].Value.ToString();
                datetimeNS.Text = dtgKhachHang.Rows[index].Cells[2].Value.ToString();
                if (dtgKhachHang.Rows[index].Cells[5].Value.ToString() == "1")
                {
                    rbtnNam.Checked = true;
                    rbtnNu.Checked = false;
                }
                else
                {
                    rbtnNu.Checked = true;
                    rbtnNam.Checked = false;
                }
                txtDiaChi.Text = dtgKhachHang.Rows[index].Cells[3].Value.ToString();
                txtSDT.Text = dtgKhachHang.Rows[index].Cells[4].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //api/KhachHang?makhachhang={makhachhang}
            //KhachHang?makhachhang={makhachhang}
            int makh = int.Parse(txtMaKH.Text);
            using (var client = new HttpClient())
            {
                //HTTP DELETE
                client.BaseAddress = new Uri(baseAddress);
                var deleteTask = client.DeleteAsync($"KhachHang?makhachhang={makh}");
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Xóa thành công ");
                }
            }
            load();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            //KhachHang?hoten={hoten}&diachi={diachi}&sdt={sdt}
            List<KhachHang> listKhachHang = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"KhachHang?hoten={txtTimKiem.Text}&diachi={txtTimKiem.Text}&sdt={txtTimKiem.Text}");
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
            dtgKhachHang.DataSource = listKhachHang;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
