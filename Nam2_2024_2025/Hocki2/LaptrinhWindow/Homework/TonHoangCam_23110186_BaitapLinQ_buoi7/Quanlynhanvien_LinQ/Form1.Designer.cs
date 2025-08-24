namespace Quanlynhanvien_LinQ
{
    partial class frm_quanlynhanvien
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
            this.txt_hoten = new System.Windows.Forms.TextBox();
            this.lbl_danhmucnhanvien = new System.Windows.Forms.Label();
            this.grbox_thongtin = new System.Windows.Forms.GroupBox();
            this.lbl_bangcap = new System.Windows.Forms.Label();
            this.lbl_dienthoai = new System.Windows.Forms.Label();
            this.lbl_ngaysinh = new System.Windows.Forms.Label();
            this.lbl_diachi = new System.Windows.Forms.Label();
            this.lbl_hoten = new System.Windows.Forms.Label();
            this.combobox_bangcap = new System.Windows.Forms.ComboBox();
            this.txt_dienthoai = new System.Windows.Forms.TextBox();
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.txt_diachi = new System.Windows.Forms.TextBox();
            this.dg_thongtinchung = new System.Windows.Forms.DataGridView();
            this.grbox_btn = new System.Windows.Forms.GroupBox();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_huy = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.grbox_thongtinchung = new System.Windows.Forms.GroupBox();
            this.grbox_thongtin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_thongtinchung)).BeginInit();
            this.grbox_btn.SuspendLayout();
            this.grbox_thongtinchung.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_hoten
            // 
            this.txt_hoten.Location = new System.Drawing.Point(115, 21);
            this.txt_hoten.Name = "txt_hoten";
            this.txt_hoten.Size = new System.Drawing.Size(220, 22);
            this.txt_hoten.TabIndex = 0;
            // 
            // lbl_danhmucnhanvien
            // 
            this.lbl_danhmucnhanvien.AutoSize = true;
            this.lbl_danhmucnhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_danhmucnhanvien.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_danhmucnhanvien.Location = new System.Drawing.Point(294, 21);
            this.lbl_danhmucnhanvien.Name = "lbl_danhmucnhanvien";
            this.lbl_danhmucnhanvien.Size = new System.Drawing.Size(309, 29);
            this.lbl_danhmucnhanvien.TabIndex = 1;
            this.lbl_danhmucnhanvien.Text = "DANH MỤC NHÂN VIÊN";
            // 
            // grbox_thongtin
            // 
            this.grbox_thongtin.Controls.Add(this.lbl_bangcap);
            this.grbox_thongtin.Controls.Add(this.lbl_dienthoai);
            this.grbox_thongtin.Controls.Add(this.lbl_ngaysinh);
            this.grbox_thongtin.Controls.Add(this.lbl_diachi);
            this.grbox_thongtin.Controls.Add(this.lbl_hoten);
            this.grbox_thongtin.Controls.Add(this.combobox_bangcap);
            this.grbox_thongtin.Controls.Add(this.txt_dienthoai);
            this.grbox_thongtin.Controls.Add(this.dtp_date);
            this.grbox_thongtin.Controls.Add(this.txt_diachi);
            this.grbox_thongtin.Controls.Add(this.txt_hoten);
            this.grbox_thongtin.Location = new System.Drawing.Point(39, 53);
            this.grbox_thongtin.Name = "grbox_thongtin";
            this.grbox_thongtin.Size = new System.Drawing.Size(806, 135);
            this.grbox_thongtin.TabIndex = 2;
            this.grbox_thongtin.TabStop = false;
            this.grbox_thongtin.Text = "Thông tin chi tiết";
            // 
            // lbl_bangcap
            // 
            this.lbl_bangcap.AutoSize = true;
            this.lbl_bangcap.Location = new System.Drawing.Point(422, 73);
            this.lbl_bangcap.Name = "lbl_bangcap";
            this.lbl_bangcap.Size = new System.Drawing.Size(65, 16);
            this.lbl_bangcap.TabIndex = 8;
            this.lbl_bangcap.Text = "Bằng cấp";
            // 
            // lbl_dienthoai
            // 
            this.lbl_dienthoai.AutoSize = true;
            this.lbl_dienthoai.Location = new System.Drawing.Point(422, 24);
            this.lbl_dienthoai.Name = "lbl_dienthoai";
            this.lbl_dienthoai.Size = new System.Drawing.Size(66, 16);
            this.lbl_dienthoai.TabIndex = 7;
            this.lbl_dienthoai.Text = "Điện thoại";
            // 
            // lbl_ngaysinh
            // 
            this.lbl_ngaysinh.AutoSize = true;
            this.lbl_ngaysinh.Location = new System.Drawing.Point(30, 64);
            this.lbl_ngaysinh.Name = "lbl_ngaysinh";
            this.lbl_ngaysinh.Size = new System.Drawing.Size(67, 16);
            this.lbl_ngaysinh.TabIndex = 6;
            this.lbl_ngaysinh.Text = "Ngày sinh";
            // 
            // lbl_diachi
            // 
            this.lbl_diachi.AutoSize = true;
            this.lbl_diachi.Location = new System.Drawing.Point(30, 100);
            this.lbl_diachi.Name = "lbl_diachi";
            this.lbl_diachi.Size = new System.Drawing.Size(47, 16);
            this.lbl_diachi.TabIndex = 6;
            this.lbl_diachi.Text = "Địa chỉ";
            // 
            // lbl_hoten
            // 
            this.lbl_hoten.AutoSize = true;
            this.lbl_hoten.Location = new System.Drawing.Point(30, 27);
            this.lbl_hoten.Name = "lbl_hoten";
            this.lbl_hoten.Size = new System.Drawing.Size(46, 16);
            this.lbl_hoten.TabIndex = 5;
            this.lbl_hoten.Text = "Họ tên";
            // 
            // combobox_bangcap
            // 
            this.combobox_bangcap.FormattingEnabled = true;
            this.combobox_bangcap.Items.AddRange(new object[] {
            "Đại học",
            "Tiến sĩ",
            "Thạc sĩ"});
            this.combobox_bangcap.Location = new System.Drawing.Point(494, 70);
            this.combobox_bangcap.Name = "combobox_bangcap";
            this.combobox_bangcap.Size = new System.Drawing.Size(211, 24);
            this.combobox_bangcap.TabIndex = 4;
            // 
            // txt_dienthoai
            // 
            this.txt_dienthoai.Location = new System.Drawing.Point(494, 21);
            this.txt_dienthoai.Name = "txt_dienthoai";
            this.txt_dienthoai.Size = new System.Drawing.Size(211, 22);
            this.txt_dienthoai.TabIndex = 3;
            // 
            // dtp_date
            // 
            this.dtp_date.Location = new System.Drawing.Point(115, 59);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(219, 22);
            this.dtp_date.TabIndex = 2;
            // 
            // txt_diachi
            // 
            this.txt_diachi.Location = new System.Drawing.Point(115, 97);
            this.txt_diachi.Name = "txt_diachi";
            this.txt_diachi.Size = new System.Drawing.Size(219, 22);
            this.txt_diachi.TabIndex = 1;
            // 
            // dg_thongtinchung
            // 
            this.dg_thongtinchung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_thongtinchung.Location = new System.Drawing.Point(23, 27);
            this.dg_thongtinchung.Name = "dg_thongtinchung";
            this.dg_thongtinchung.RowHeadersWidth = 51;
            this.dg_thongtinchung.RowTemplate.Height = 24;
            this.dg_thongtinchung.Size = new System.Drawing.Size(757, 210);
            this.dg_thongtinchung.TabIndex = 9;
            // 
            // grbox_btn
            // 
            this.grbox_btn.Controls.Add(this.btn_thoat);
            this.grbox_btn.Controls.Add(this.btn_them);
            this.grbox_btn.Controls.Add(this.btn_huy);
            this.grbox_btn.Controls.Add(this.btn_sua);
            this.grbox_btn.Controls.Add(this.btn_luu);
            this.grbox_btn.Controls.Add(this.btn_xoa);
            this.grbox_btn.Location = new System.Drawing.Point(299, 194);
            this.grbox_btn.Name = "grbox_btn";
            this.grbox_btn.Size = new System.Drawing.Size(546, 72);
            this.grbox_btn.TabIndex = 10;
            this.grbox_btn.TabStop = false;
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(451, 21);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(81, 43);
            this.btn_thoat.TabIndex = 17;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(25, 21);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(75, 43);
            this.btn_them.TabIndex = 12;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.Location = new System.Drawing.Point(364, 21);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(81, 43);
            this.btn_huy.TabIndex = 16;
            this.btn_huy.Text = "Huỷ";
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(190, 21);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(81, 43);
            this.btn_sua.TabIndex = 13;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.Location = new System.Drawing.Point(277, 21);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(81, 43);
            this.btn_luu.TabIndex = 15;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(106, 21);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(78, 43);
            this.btn_xoa.TabIndex = 14;
            this.btn_xoa.Text = "Xoá";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // grbox_thongtinchung
            // 
            this.grbox_thongtinchung.Controls.Add(this.dg_thongtinchung);
            this.grbox_thongtinchung.Location = new System.Drawing.Point(39, 287);
            this.grbox_thongtinchung.Name = "grbox_thongtinchung";
            this.grbox_thongtinchung.Size = new System.Drawing.Size(806, 254);
            this.grbox_thongtinchung.TabIndex = 11;
            this.grbox_thongtinchung.TabStop = false;
            this.grbox_thongtinchung.Text = "Thông tin chung";
            // 
            // frm_quanlynhanvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.grbox_thongtinchung);
            this.Controls.Add(this.grbox_btn);
            this.Controls.Add(this.grbox_thongtin);
            this.Controls.Add(this.lbl_danhmucnhanvien);
            this.Name = "frm_quanlynhanvien";
            this.Text = "Quản Lý Nhân Viên - Tôn Hoàng Cầm_23110186";
            this.grbox_thongtin.ResumeLayout(false);
            this.grbox_thongtin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_thongtinchung)).EndInit();
            this.grbox_btn.ResumeLayout(false);
            this.grbox_thongtinchung.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_hoten;
        private System.Windows.Forms.Label lbl_danhmucnhanvien;
        private System.Windows.Forms.GroupBox grbox_thongtin;
        private System.Windows.Forms.DataGridView dg_thongtinchung;
        private System.Windows.Forms.GroupBox grbox_btn;
        private System.Windows.Forms.GroupBox grbox_thongtinchung;
        private System.Windows.Forms.ComboBox combobox_bangcap;
        private System.Windows.Forms.TextBox txt_dienthoai;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.TextBox txt_diachi;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Label lbl_bangcap;
        private System.Windows.Forms.Label lbl_dienthoai;
        private System.Windows.Forms.Label lbl_ngaysinh;
        private System.Windows.Forms.Label lbl_diachi;
        private System.Windows.Forms.Label lbl_hoten;
    }
}

