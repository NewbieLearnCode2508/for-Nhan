namespace GiaoDien.MenuTab
{
    partial class frmPhieuNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.cboLoaiSanPham = new System.Windows.Forms.ComboBox();
            this.lblaaa = new System.Windows.Forms.Label();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMaPhieuNhap = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSanPham
            // 
            this.cboSanPham.FormattingEnabled = true;
            this.cboSanPham.Location = new System.Drawing.Point(23, 48);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(163, 21);
            this.cboSanPham.TabIndex = 0;
            this.cboSanPham.SelectedIndexChanged += new System.EventHandler(this.cboSanPham_SelectedIndexChanged);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(23, 163);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(163, 20);
            this.txtSoLuong.TabIndex = 1;
            this.txtSoLuong.TextChanged += new System.EventHandler(this.txtSoLuong_TextChanged);
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(105, 198);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(53, 13);
            this.lblDonGia.TabIndex = 2;
            this.lblDonGia.Text = "lblDonGia";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(20, 341);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Số lượng";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(105, 256);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(64, 13);
            this.lblNhanVien.TabIndex = 7;
            this.lblNhanVien.Text = "lblNhanVien";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(105, 227);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(63, 13);
            this.lblTongTien.TabIndex = 8;
            this.lblTongTien.Text = "lblTongTien";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(108, 341);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(196, 341);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(284, 341);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(75, 23);
            this.btnXacNhan.TabIndex = 11;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(378, 20);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(410, 344);
            this.dataGridView1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tổng tiền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Nhân viên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Đơn giá";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(23, 75);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(76, 13);
            this.label.TabIndex = 17;
            this.label.Text = "Loại sản phẩm";
            // 
            // cboLoaiSanPham
            // 
            this.cboLoaiSanPham.FormattingEnabled = true;
            this.cboLoaiSanPham.Location = new System.Drawing.Point(23, 103);
            this.cboLoaiSanPham.Name = "cboLoaiSanPham";
            this.cboLoaiSanPham.Size = new System.Drawing.Size(163, 21);
            this.cboLoaiSanPham.TabIndex = 16;
            this.cboLoaiSanPham.SelectedIndexChanged += new System.EventHandler(this.cboLoaiSanPham_SelectedIndexChanged);
            // 
            // lblaaa
            // 
            this.lblaaa.AutoSize = true;
            this.lblaaa.Location = new System.Drawing.Point(23, 285);
            this.lblaaa.Name = "lblaaa";
            this.lblaaa.Size = new System.Drawing.Size(59, 13);
            this.lblaaa.TabIndex = 19;
            this.lblaaa.Text = "Ngày nhập";
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Location = new System.Drawing.Point(105, 285);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(68, 13);
            this.lblNgayNhap.TabIndex = 18;
            this.lblNgayNhap.Text = "lblNgayNhap";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Mã phiếu nhập";
            // 
            // lblMaPhieuNhap
            // 
            this.lblMaPhieuNhap.AutoSize = true;
            this.lblMaPhieuNhap.Location = new System.Drawing.Point(105, 314);
            this.lblMaPhieuNhap.Name = "lblMaPhieuNhap";
            this.lblMaPhieuNhap.Size = new System.Drawing.Size(85, 13);
            this.lblMaPhieuNhap.TabIndex = 20;
            this.lblMaPhieuNhap.Text = "lblMaPhieuNhap";
            // 
            // frmPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblMaPhieuNhap);
            this.Controls.Add(this.lblaaa);
            this.Controls.Add(this.lblNgayNhap);
            this.Controls.Add(this.label);
            this.Controls.Add(this.cboLoaiSanPham);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblNhanVien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lblDonGia);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.cboSanPham);
            this.Name = "frmPhieuNhap";
            this.Text = "frmPhieuNhap";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ComboBox cboLoaiSanPham;
        private System.Windows.Forms.Label lblaaa;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMaPhieuNhap;
    }
}