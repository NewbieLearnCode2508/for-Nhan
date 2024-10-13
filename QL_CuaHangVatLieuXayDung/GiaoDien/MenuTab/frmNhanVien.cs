using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Windows.Forms;

namespace GiaoDien.MenuTab
{
    public partial class frmNhanVien : Form
    {
        private IMongoDatabase db;

        public frmNhanVien()
        {
            InitializeComponent();
            var client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("QL_VLXD");  // Thay bằng tên database của bạn
            LoadData();
        }


        private IMongoCollection<NhanVien> GetNhanVienCollection()
        {
            return db.GetCollection<NhanVien>("NhanVien"); // Thay bằng tên collection của bạn
        }

        // Lấy toàn bộ danh sách nhân viên
        private List<NhanVien> GetAllNhanVien()
        {
            var collection = GetNhanVienCollection();
            return collection.Find(new BsonDocument()).ToList();
        }

        // Thêm nhân viên
        private void AddNhanVien(NhanVien nv)
        {
            var collection = GetNhanVienCollection();
            collection.InsertOne(nv);
        }

        // Cập nhật thông tin nhân viên
        private void UpdateNhanVien(NhanVien nv)
        {
            var collection = GetNhanVienCollection();
            var filter = Builders<NhanVien>.Filter.Eq("MaNhanVien", nv.MaNhanVien);
            collection.ReplaceOne(filter, nv);
        }

        // Xóa nhân viên theo mã
        private void DeleteNhanVien(string maNhanVien)
        {
            var collection = GetNhanVienCollection();
            var filter = Builders<NhanVien>.Filter.Eq("MaNhanVien", maNhanVien);
            collection.DeleteOne(filter);
        }

        // Tìm kiếm nhân viên theo mã hoặc tên
        private List<NhanVien> SearchNhanVien(string keyword)
        {
            var collection = GetNhanVienCollection();
            var filter = Builders<NhanVien>.Filter.Or(
                Builders<NhanVien>.Filter.Eq("MaNhanVien", keyword),
                Builders<NhanVien>.Filter.Regex("TenNhanVien", new BsonRegularExpression(keyword, "i"))
            );
            return collection.Find(filter).ToList();
        }

        // Tải dữ liệu lên DataGridView
        private void LoadData()
        {
            var data = GetAllNhanVien();
            dgvNhanVien.DataSource = data;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void GenerateNewMaNhanVien()
        {
            var collection = GetNhanVienCollection();
            var lastEmployee = collection.Find(new BsonDocument())
                                         .SortByDescending(nv => nv.MaNhanVien)
                                         .FirstOrDefault();

            string newMaNhanVien;

            if (lastEmployee != null)
            {
                string lastMaNhanVien = lastEmployee.MaNhanVien;
                int number = int.Parse(lastMaNhanVien.Substring(2));
                newMaNhanVien = "NV" + (number + 1).ToString("D3");
            }
            else
            {
                newMaNhanVien = "NV001"; // Nếu không có nhân viên nào thì mã đầu tiên là NV001
            }

            // Hiển thị mã nhân viên vào txtMaNhanVien và vô hiệu hóa TextBox này
            txtMaNhanVien.Text = newMaNhanVien; // Đặt giá trị vào TextBox
            txtMaNhanVien.Enabled = false; // Vô hiệu hóa TextBox
        }

        private bool ValidateNhanVien(NhanVien nv)
        {
            if (string.IsNullOrEmpty(nv.TenNhanVien))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên.");
                return false;
            }

            // Kiểm tra định dạng email
            if (string.IsNullOrEmpty(nv.Email) ||
                !System.Text.RegularExpressions.Regex.IsMatch(nv.Email, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
            {
                MessageBox.Show("Vui lòng nhập email đúng định dạng @gmail.com.");
                return false;
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrEmpty(nv.SoDienThoai) ||
                !System.Text.RegularExpressions.Regex.IsMatch(nv.SoDienThoai, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số.");
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            GenerateNewMaNhanVien(); // Gọi hàm để tạo mã nhân viên mới

            var nv = new NhanVien
            {
                MaNhanVien = txtMaNhanVien.Text, // Lấy mã từ TextBox
                TenNhanVien = txtTenNhanVien.Text,
                DiaChi = txtDiaChi.Text,
                Email = txtEmail.Text,
                SoDienThoai = txtSoDienThoai.Text,
                ChucVu = txtChucVu.Text,
                TaiKhoan = txtTaiKhoan.Text,
                MatKhau = txtMatKhau.Text
            };

            if (ValidateNhanVien(nv)) // Kiểm tra tính hợp lệ trước khi thêm
            {
                AddNhanVien(nv);
                MessageBox.Show("Thêm nhân viên thành công!");
                LoadData();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var nv = new NhanVien
            {
                MaNhanVien = txtMaNhanVien.Text,
                TenNhanVien = txtTenNhanVien.Text,
                DiaChi = txtDiaChi.Text,
                Email = txtEmail.Text,
                SoDienThoai = txtSoDienThoai.Text,
                ChucVu = txtChucVu.Text,
                TaiKhoan = txtTaiKhoan.Text,
                MatKhau = txtMatKhau.Text
            };

            if (ValidateNhanVien(nv))
            {
                UpdateNhanVien(nv);
                MessageBox.Show("Sửa thông tin nhân viên thành công!");
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtMaNhanVien.Text;
            DeleteNhanVien(maNhanVien);
            MessageBox.Show("Xóa nhân viên thành công!");
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtMaNhanVien.Text;
            var result = SearchNhanVien(keyword);
            dgvNhanVien.DataSource = result;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNhanVien.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtTenNhanVien.Text = row.Cells["TenNhanVien"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtChucVu.Text = row.Cells["ChucVu"].Value.ToString();
                txtTaiKhoan.Text = row.Cells["TaiKhoan"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
            }
        }
    }
    public class NhanVien
    {
        public ObjectId _id { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string ChucVu { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
    }
}
