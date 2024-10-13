using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GiaoDien.MenuTab
{
    public partial class frmPhieuNhap : Form
    {
        private MongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> sanphamCollection;
        private string selectedProductID;
        private int selectedProductPrice;

        // Lớp ViewModel để hiển thị phiếu nhập
        public class PhieuNhapViewModel
        {
            public string MaPhieuNhap { get; set; }
            public string NgayNhap { get; set; }
            public string TenSanPham { get; set; }
            public int SoLuong { get; set; }
            public int TongTien { get; set; }
            public string TenNhanVien { get; set; }
        }

        public frmPhieuNhap()
        {
            InitializeComponent();


            // Kết nối MongoDB
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("VLXD");
            sanphamCollection = database.GetCollection<BsonDocument>("SanPham");

            // Gọi hàm hiển thị dữ liệu phiếu nhập lên DataGridView khi form load
            LoadPhieuNhapData();

            // Load danh sách loại sản phẩm vào ComboBox khi form load
            LoadLoaiSanPhamData();
        }

        // Hàm để load loại sản phẩm vào ComboBox
        private void LoadLoaiSanPhamData()
        {
            var loaiSanPhams = sanphamCollection.Find(new BsonDocument()).ToList();
            foreach (var loaiSanPham in loaiSanPhams)
            {
                cboLoaiSanPham.Items.Add(new
                {
                    Text = loaiSanPham["TenLoaiSanPham"].AsString,
                    Value = loaiSanPham["MaLoaiSanPham"].AsString
                });
            }
            cboLoaiSanPham.DisplayMember = "Text";
            cboLoaiSanPham.ValueMember = "Value";
        }

        //Load phiếu nhập
        private void LoadPhieuNhapData()
        {
            // Lấy tất cả dữ liệu sản phẩm và phiếu nhập
            var sanphams = sanphamCollection.Find(new BsonDocument()).ToList();

            // Tạo danh sách để chứa dữ liệu phiếu nhập
            List<PhieuNhapViewModel> phieuNhapList = new List<PhieuNhapViewModel>();

            // Duyệt qua từng sản phẩm và lấy ra danh sách phiếu nhập
            foreach (var sanpham in sanphams)
            {
                var sanPhamName = sanpham["TenLoaiSanPham"].AsString;
                var products = sanpham["SanPham"].AsBsonArray;

                foreach (var product in products)
                {
                    var productName = product["TenSanPham"].AsString;
                    var phieuNhaps = product["PhieuNhap"].AsBsonArray;

                    foreach (var phieuNhap in phieuNhaps)
                    {
                        // Thêm phiếu nhập vào danh sách
                        phieuNhapList.Add(new PhieuNhapViewModel
                        {
                            MaPhieuNhap = phieuNhap["PhieuNhap"].AsString,
                            NgayNhap = phieuNhap["NgayNhap"].AsString,
                            TenSanPham = productName,
                            SoLuong = phieuNhap["SoLuong"].AsInt32,
                            TongTien = phieuNhap["TongTien"].AsInt32,
                            TenNhanVien = phieuNhap["NhanVien"]["TenNhanVien"].AsString
                        });
                    }
                }
            }

            // Hiển thị dữ liệu lên DataGridView
            dataGridView1.DataSource = phieuNhapList;
        }

        private void CalculateTotalPrice()
        {
            if (int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                int tongTien = soLuong * selectedProductPrice;
                lblTongTien.Text = tongTien.ToString();
            }
        }

        // Tự động tạo mã phiếu nhập
        private string GenerateNewPhieuNhapID()
        {
            return "PN" + DateTime.Now.ToString("yyyyMMddHHmmss"); // Ví dụ: PN20241012153000
        }

        // Hàm để tự động hiển thị ngày lập phiếu, mã phiếu nhập và nhân viên
        private void AutoRenderPhieuNhapInfo()
        {
            lblMaPhieuNhap.Text = GenerateNewPhieuNhapID();
            lblNgayNhap.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblNhanVien.Text = "Huỳnh Minh Khang";  // Thông tin nhân viên, ví dụ này có thể lấy từ hệ thống đăng nhập
        }

        private void cboLoaiSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboSanPham.Items.Clear(); // Xóa sản phẩm cũ trước
            var selectedLoaiSanPham = (dynamic)cboLoaiSanPham.SelectedItem;
            string maLoaiSanPham = selectedLoaiSanPham.Value;

            // Lấy danh sách sản phẩm theo loại sản phẩm đã chọn
            var filter = Builders<BsonDocument>.Filter.Eq("MaLoaiSanPham", maLoaiSanPham);
            var loaiSanPham = sanphamCollection.Find(filter).FirstOrDefault();
            var products = loaiSanPham["SanPham"].AsBsonArray;

            // Load sản phẩm vào ComboBox
            foreach (var product in products)
            {
                cboSanPham.Items.Add(new
                {
                    Text = product["TenSanPham"].AsString,
                    Value = product["MaSanPham"].AsString,
                    DonGia = product["DonGia"].AsInt32
                });
            }

            cboSanPham.DisplayMember = "Text";
            cboSanPham.ValueMember = "Value";
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedProductID) && int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                var filter = Builders<BsonDocument>.Filter.Eq("SanPham.MaSanPham", selectedProductID);
                var update = Builders<BsonDocument>.Update.Push("SanPham.$.PhieuNhap", new BsonDocument {
                { "PhieuNhap", lblMaPhieuNhap.Text },
                { "NgayNhap", lblNgayNhap.Text },
                { "SoLuong", soLuong },
                { "TongTien", int.Parse(lblTongTien.Text) },
                { "NhanVien", new BsonDocument {
                    { "MaNhanVien", "NV001" },  // Thông tin nhân viên lấy từ hệ thống đăng nhập
                    { "TenNhanVien", "Huỳnh Minh Khang" }
                }}
            });

                // Thực hiện cập nhật trong MongoDB
                sanphamCollection.UpdateOne(filter, update);

                MessageBox.Show("Phiếu nhập đã được thêm thành công.");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm và nhập số lượng hợp lệ.");
            }
            LoadPhieuNhapData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            AutoRenderPhieuNhapInfo();
        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProduct = (dynamic)cboSanPham.SelectedItem;
            selectedProductID = selectedProduct.Value;
            MessageBox.Show($"{selectedProductID} log 1");
            selectedProductPrice = selectedProduct.DonGia;

            lblDonGia.Text = selectedProductPrice.ToString();
            CalculateTotalPrice(); // Tính tổng tiền dựa trên số lượng
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }
    }
}
