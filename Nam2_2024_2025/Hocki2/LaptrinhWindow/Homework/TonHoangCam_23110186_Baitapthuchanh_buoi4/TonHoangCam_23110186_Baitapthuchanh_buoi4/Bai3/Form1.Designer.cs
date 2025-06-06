namespace Bai3
{
    partial class frm_nhanvien
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
            this.grid_thongtinnhanvien = new System.Windows.Forms.DataGridView();
            this.col_manhanvien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ngaysinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gioitinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cmnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_diachi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_quequan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_honnhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_blank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbox_thongtinnhanvien = new System.Windows.Forms.GroupBox();
            this.date_ngaysinh = new System.Windows.Forms.DateTimePicker();
            this.lbl_tinhtranghonnhan = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_khong = new System.Windows.Forms.RadioButton();
            this.btn_co = new System.Windows.Forms.RadioButton();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.lbl_email = new System.Windows.Forms.Label();
            this.txt_quequan = new System.Windows.Forms.TextBox();
            this.lbl_quequan = new System.Windows.Forms.Label();
            this.txt_diachi = new System.Windows.Forms.TextBox();
            this.txt_sdt = new System.Windows.Forms.TextBox();
            this.txt_cmnd = new System.Windows.Forms.TextBox();
            this.lbl_diachi = new System.Windows.Forms.Label();
            this.lbl_sdt = new System.Windows.Forms.Label();
            this.lbl_cmnd = new System.Windows.Forms.Label();
            this.grbox_gioitinh = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_nu = new System.Windows.Forms.RadioButton();
            this.btn_nam = new System.Windows.Forms.RadioButton();
            this.txt_hoten = new System.Windows.Forms.TextBox();
            this.txt_manhanvien = new System.Windows.Forms.TextBox();
            this.lbl_ngaysinh = new System.Windows.Forms.Label();
            this.lbl_hoten = new System.Windows.Forms.Label();
            this.lbl_manhanvien = new System.Windows.Forms.Label();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_xem = new System.Windows.Forms.Button();
            this.btn_luu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_thongtinnhanvien)).BeginInit();
            this.grbox_thongtinnhanvien.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grbox_gioitinh.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_thongtinnhanvien
            // 
            this.grid_thongtinnhanvien.BackgroundColor = System.Drawing.Color.White;
            this.grid_thongtinnhanvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_thongtinnhanvien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_manhanvien,
            this.col_hoten,
            this.col_ngaysinh,
            this.col_gioitinh,
            this.col_cmnd,
            this.col_sdt,
            this.col_diachi,
            this.col_quequan,
            this.col_honnhan,
            this.col_email,
            this.col_blank});
            this.grid_thongtinnhanvien.Location = new System.Drawing.Point(284, 21);
            this.grid_thongtinnhanvien.Name = "grid_thongtinnhanvien";
            this.grid_thongtinnhanvien.RowHeadersWidth = 51;
            this.grid_thongtinnhanvien.RowTemplate.Height = 24;
            this.grid_thongtinnhanvien.Size = new System.Drawing.Size(1017, 445);
            this.grid_thongtinnhanvien.TabIndex = 0;
            // 
            // col_manhanvien
            // 
            this.col_manhanvien.FillWeight = 91.28631F;
            this.col_manhanvien.HeaderText = "Mã nhân viên";
            this.col_manhanvien.MinimumWidth = 6;
            this.col_manhanvien.Name = "col_manhanvien";
            this.col_manhanvien.Width = 80;
            // 
            // col_hoten
            // 
            this.col_hoten.FillWeight = 91.7077F;
            this.col_hoten.HeaderText = "Họ tên";
            this.col_hoten.MinimumWidth = 6;
            this.col_hoten.Name = "col_hoten";
            this.col_hoten.Width = 80;
            // 
            // col_ngaysinh
            // 
            this.col_ngaysinh.FillWeight = 143.8971F;
            this.col_ngaysinh.HeaderText = "Ngày sinh";
            this.col_ngaysinh.MinimumWidth = 6;
            this.col_ngaysinh.Name = "col_ngaysinh";
            this.col_ngaysinh.Width = 126;
            // 
            // col_gioitinh
            // 
            this.col_gioitinh.FillWeight = 88.1495F;
            this.col_gioitinh.HeaderText = "Giới tính";
            this.col_gioitinh.MinimumWidth = 6;
            this.col_gioitinh.Name = "col_gioitinh";
            this.col_gioitinh.Width = 78;
            // 
            // col_cmnd
            // 
            this.col_cmnd.FillWeight = 88.83121F;
            this.col_cmnd.HeaderText = "Số CMND";
            this.col_cmnd.MinimumWidth = 6;
            this.col_cmnd.Name = "col_cmnd";
            this.col_cmnd.Width = 78;
            // 
            // col_sdt
            // 
            this.col_sdt.FillWeight = 89.45634F;
            this.col_sdt.HeaderText = "Số điện thoại";
            this.col_sdt.MinimumWidth = 6;
            this.col_sdt.Name = "col_sdt";
            this.col_sdt.Width = 78;
            // 
            // col_diachi
            // 
            this.col_diachi.FillWeight = 90.02962F;
            this.col_diachi.HeaderText = "Địa chỉ";
            this.col_diachi.MinimumWidth = 6;
            this.col_diachi.Name = "col_diachi";
            this.col_diachi.Width = 79;
            // 
            // col_quequan
            // 
            this.col_quequan.FillWeight = 90.55531F;
            this.col_quequan.HeaderText = "Quê quán";
            this.col_quequan.MinimumWidth = 6;
            this.col_quequan.Name = "col_quequan";
            this.col_quequan.Width = 79;
            // 
            // col_honnhan
            // 
            this.col_honnhan.FillWeight = 91.03738F;
            this.col_honnhan.HeaderText = "Hôn nhân";
            this.col_honnhan.MinimumWidth = 6;
            this.col_honnhan.Name = "col_honnhan";
            this.col_honnhan.Width = 80;
            // 
            // col_email
            // 
            this.col_email.FillWeight = 91.47943F;
            this.col_email.HeaderText = "Email";
            this.col_email.MinimumWidth = 6;
            this.col_email.Name = "col_email";
            this.col_email.Width = 80;
            // 
            // col_blank
            // 
            this.col_blank.FillWeight = 143.57F;
            this.col_blank.HeaderText = "";
            this.col_blank.MinimumWidth = 6;
            this.col_blank.Name = "col_blank";
            this.col_blank.Width = 126;
            // 
            // grbox_thongtinnhanvien
            // 
            this.grbox_thongtinnhanvien.Controls.Add(this.date_ngaysinh);
            this.grbox_thongtinnhanvien.Controls.Add(this.lbl_tinhtranghonnhan);
            this.grbox_thongtinnhanvien.Controls.Add(this.panel2);
            this.grbox_thongtinnhanvien.Controls.Add(this.txt_email);
            this.grbox_thongtinnhanvien.Controls.Add(this.lbl_email);
            this.grbox_thongtinnhanvien.Controls.Add(this.txt_quequan);
            this.grbox_thongtinnhanvien.Controls.Add(this.lbl_quequan);
            this.grbox_thongtinnhanvien.Controls.Add(this.txt_diachi);
            this.grbox_thongtinnhanvien.Controls.Add(this.txt_sdt);
            this.grbox_thongtinnhanvien.Controls.Add(this.txt_cmnd);
            this.grbox_thongtinnhanvien.Controls.Add(this.lbl_diachi);
            this.grbox_thongtinnhanvien.Controls.Add(this.lbl_sdt);
            this.grbox_thongtinnhanvien.Controls.Add(this.lbl_cmnd);
            this.grbox_thongtinnhanvien.Controls.Add(this.grbox_gioitinh);
            this.grbox_thongtinnhanvien.Controls.Add(this.txt_hoten);
            this.grbox_thongtinnhanvien.Controls.Add(this.txt_manhanvien);
            this.grbox_thongtinnhanvien.Controls.Add(this.lbl_ngaysinh);
            this.grbox_thongtinnhanvien.Controls.Add(this.lbl_hoten);
            this.grbox_thongtinnhanvien.Controls.Add(this.lbl_manhanvien);
            this.grbox_thongtinnhanvien.Controls.Add(this.grid_thongtinnhanvien);
            this.grbox_thongtinnhanvien.Location = new System.Drawing.Point(12, 12);
            this.grbox_thongtinnhanvien.Name = "grbox_thongtinnhanvien";
            this.grbox_thongtinnhanvien.Size = new System.Drawing.Size(1326, 486);
            this.grbox_thongtinnhanvien.TabIndex = 1;
            this.grbox_thongtinnhanvien.TabStop = false;
            this.grbox_thongtinnhanvien.Text = "Thông tin nhân viên";
            // 
            // date_ngaysinh
            // 
            this.date_ngaysinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_ngaysinh.Location = new System.Drawing.Point(124, 106);
            this.date_ngaysinh.Name = "date_ngaysinh";
            this.date_ngaysinh.Size = new System.Drawing.Size(138, 22);
            this.date_ngaysinh.TabIndex = 20;
            this.date_ngaysinh.UseWaitCursor = true;
            this.date_ngaysinh.Value = new System.DateTime(2025, 2, 21, 21, 9, 17, 0);
            // 
            // lbl_tinhtranghonnhan
            // 
            this.lbl_tinhtranghonnhan.Location = new System.Drawing.Point(24, 402);
            this.lbl_tinhtranghonnhan.Name = "lbl_tinhtranghonnhan";
            this.lbl_tinhtranghonnhan.Size = new System.Drawing.Size(77, 36);
            this.lbl_tinhtranghonnhan.TabIndex = 19;
            this.lbl_tinhtranghonnhan.Text = "Tình trạng hôn nhân";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_khong);
            this.panel2.Controls.Add(this.btn_co);
            this.panel2.Location = new System.Drawing.Point(112, 388);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 50);
            this.panel2.TabIndex = 18;
            // 
            // btn_khong
            // 
            this.btn_khong.AutoSize = true;
            this.btn_khong.Location = new System.Drawing.Point(76, 15);
            this.btn_khong.Name = "btn_khong";
            this.btn_khong.Size = new System.Drawing.Size(66, 20);
            this.btn_khong.TabIndex = 1;
            this.btn_khong.TabStop = true;
            this.btn_khong.Text = "Không";
            this.btn_khong.UseVisualStyleBackColor = true;
            // 
            // btn_co
            // 
            this.btn_co.AutoSize = true;
            this.btn_co.Location = new System.Drawing.Point(12, 15);
            this.btn_co.Name = "btn_co";
            this.btn_co.Size = new System.Drawing.Size(45, 20);
            this.btn_co.TabIndex = 0;
            this.btn_co.TabStop = true;
            this.btn_co.Text = "Có";
            this.btn_co.UseVisualStyleBackColor = true;
            // 
            // txt_email
            // 
            this.txt_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_email.Location = new System.Drawing.Point(124, 444);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(138, 22);
            this.txt_email.TabIndex = 17;
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(24, 447);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(41, 16);
            this.lbl_email.TabIndex = 16;
            this.lbl_email.Text = "Email";
            // 
            // txt_quequan
            // 
            this.txt_quequan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_quequan.Location = new System.Drawing.Point(124, 357);
            this.txt_quequan.Name = "txt_quequan";
            this.txt_quequan.Size = new System.Drawing.Size(138, 22);
            this.txt_quequan.TabIndex = 15;
            // 
            // lbl_quequan
            // 
            this.lbl_quequan.AutoSize = true;
            this.lbl_quequan.Location = new System.Drawing.Point(24, 363);
            this.lbl_quequan.Name = "lbl_quequan";
            this.lbl_quequan.Size = new System.Drawing.Size(65, 16);
            this.lbl_quequan.TabIndex = 14;
            this.lbl_quequan.Text = "Quê quán";
            // 
            // txt_diachi
            // 
            this.txt_diachi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_diachi.Location = new System.Drawing.Point(124, 317);
            this.txt_diachi.Name = "txt_diachi";
            this.txt_diachi.Size = new System.Drawing.Size(138, 22);
            this.txt_diachi.TabIndex = 13;
            // 
            // txt_sdt
            // 
            this.txt_sdt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_sdt.Location = new System.Drawing.Point(124, 275);
            this.txt_sdt.Name = "txt_sdt";
            this.txt_sdt.Size = new System.Drawing.Size(138, 22);
            this.txt_sdt.TabIndex = 12;
            // 
            // txt_cmnd
            // 
            this.txt_cmnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_cmnd.Location = new System.Drawing.Point(124, 238);
            this.txt_cmnd.Name = "txt_cmnd";
            this.txt_cmnd.Size = new System.Drawing.Size(138, 22);
            this.txt_cmnd.TabIndex = 11;
            // 
            // lbl_diachi
            // 
            this.lbl_diachi.AutoSize = true;
            this.lbl_diachi.Location = new System.Drawing.Point(24, 323);
            this.lbl_diachi.Name = "lbl_diachi";
            this.lbl_diachi.Size = new System.Drawing.Size(55, 16);
            this.lbl_diachi.TabIndex = 10;
            this.lbl_diachi.Text = "Địa chỉ *";
            // 
            // lbl_sdt
            // 
            this.lbl_sdt.AutoSize = true;
            this.lbl_sdt.Location = new System.Drawing.Point(24, 281);
            this.lbl_sdt.Name = "lbl_sdt";
            this.lbl_sdt.Size = new System.Drawing.Size(93, 16);
            this.lbl_sdt.TabIndex = 9;
            this.lbl_sdt.Text = "Số điện thoại *";
            // 
            // lbl_cmnd
            // 
            this.lbl_cmnd.AutoSize = true;
            this.lbl_cmnd.Location = new System.Drawing.Point(24, 241);
            this.lbl_cmnd.Name = "lbl_cmnd";
            this.lbl_cmnd.Size = new System.Drawing.Size(75, 16);
            this.lbl_cmnd.TabIndex = 8;
            this.lbl_cmnd.Text = "Số CMND *";
            // 
            // grbox_gioitinh
            // 
            this.grbox_gioitinh.Controls.Add(this.panel1);
            this.grbox_gioitinh.Controls.Add(this.btn_nu);
            this.grbox_gioitinh.Controls.Add(this.btn_nam);
            this.grbox_gioitinh.Location = new System.Drawing.Point(27, 142);
            this.grbox_gioitinh.Name = "grbox_gioitinh";
            this.grbox_gioitinh.Size = new System.Drawing.Size(235, 79);
            this.grbox_gioitinh.TabIndex = 7;
            this.grbox_gioitinh.TabStop = false;
            this.grbox_gioitinh.Text = "Giới tính";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(74, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 77);
            this.panel1.TabIndex = 19;
            // 
            // btn_nu
            // 
            this.btn_nu.AutoSize = true;
            this.btn_nu.Location = new System.Drawing.Point(106, 34);
            this.btn_nu.Name = "btn_nu";
            this.btn_nu.Size = new System.Drawing.Size(45, 20);
            this.btn_nu.TabIndex = 1;
            this.btn_nu.TabStop = true;
            this.btn_nu.Text = "Nữ";
            this.btn_nu.UseVisualStyleBackColor = true;
            // 
            // btn_nam
            // 
            this.btn_nam.AutoSize = true;
            this.btn_nam.Location = new System.Drawing.Point(17, 34);
            this.btn_nam.Name = "btn_nam";
            this.btn_nam.Size = new System.Drawing.Size(57, 20);
            this.btn_nam.TabIndex = 0;
            this.btn_nam.TabStop = true;
            this.btn_nam.Text = "Nam";
            this.btn_nam.UseVisualStyleBackColor = true;
            // 
            // txt_hoten
            // 
            this.txt_hoten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_hoten.Location = new System.Drawing.Point(124, 58);
            this.txt_hoten.Name = "txt_hoten";
            this.txt_hoten.Size = new System.Drawing.Size(138, 22);
            this.txt_hoten.TabIndex = 5;
            // 
            // txt_manhanvien
            // 
            this.txt_manhanvien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_manhanvien.Location = new System.Drawing.Point(124, 21);
            this.txt_manhanvien.Name = "txt_manhanvien";
            this.txt_manhanvien.Size = new System.Drawing.Size(138, 22);
            this.txt_manhanvien.TabIndex = 4;
            // 
            // lbl_ngaysinh
            // 
            this.lbl_ngaysinh.AutoSize = true;
            this.lbl_ngaysinh.Location = new System.Drawing.Point(24, 106);
            this.lbl_ngaysinh.Name = "lbl_ngaysinh";
            this.lbl_ngaysinh.Size = new System.Drawing.Size(67, 16);
            this.lbl_ngaysinh.TabIndex = 3;
            this.lbl_ngaysinh.Text = "Ngày sinh";
            // 
            // lbl_hoten
            // 
            this.lbl_hoten.AutoSize = true;
            this.lbl_hoten.Location = new System.Drawing.Point(24, 64);
            this.lbl_hoten.Name = "lbl_hoten";
            this.lbl_hoten.Size = new System.Drawing.Size(54, 16);
            this.lbl_hoten.TabIndex = 2;
            this.lbl_hoten.Text = "Họ tên *";
            // 
            // lbl_manhanvien
            // 
            this.lbl_manhanvien.AutoSize = true;
            this.lbl_manhanvien.Location = new System.Drawing.Point(24, 24);
            this.lbl_manhanvien.Name = "lbl_manhanvien";
            this.lbl_manhanvien.Size = new System.Drawing.Size(94, 16);
            this.lbl_manhanvien.TabIndex = 1;
            this.lbl_manhanvien.Text = "Mã nhân viên *";
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(423, 511);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(116, 51);
            this.btn_them.TabIndex = 2;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(554, 511);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(117, 51);
            this.btn_xoa.TabIndex = 3;
            this.btn_xoa.Text = "Xoá";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_xem
            // 
            this.btn_xem.Location = new System.Drawing.Point(687, 511);
            this.btn_xem.Name = "btn_xem";
            this.btn_xem.Size = new System.Drawing.Size(119, 51);
            this.btn_xem.TabIndex = 4;
            this.btn_xem.Text = "Xem";
            this.btn_xem.UseVisualStyleBackColor = true;
            this.btn_xem.Click += new System.EventHandler(this.btn_xem_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.Location = new System.Drawing.Point(1075, 511);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(120, 49);
            this.btn_luu.TabIndex = 5;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // frm_nhanvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1350, 586);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.btn_xem);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.grbox_thongtinnhanvien);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "frm_nhanvien";
            this.Text = "FrmNhanVien";
            ((System.ComponentModel.ISupportInitialize)(this.grid_thongtinnhanvien)).EndInit();
            this.grbox_thongtinnhanvien.ResumeLayout(false);
            this.grbox_thongtinnhanvien.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grbox_gioitinh.ResumeLayout(false);
            this.grbox_gioitinh.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid_thongtinnhanvien;
        private System.Windows.Forms.GroupBox grbox_thongtinnhanvien;
        private System.Windows.Forms.Label lbl_hoten;
        private System.Windows.Forms.Label lbl_manhanvien;
        private System.Windows.Forms.TextBox txt_hoten;
        private System.Windows.Forms.TextBox txt_manhanvien;
        private System.Windows.Forms.Label lbl_ngaysinh;
        private System.Windows.Forms.GroupBox grbox_gioitinh;
        private System.Windows.Forms.RadioButton btn_nu;
        private System.Windows.Forms.RadioButton btn_nam;
        private System.Windows.Forms.TextBox txt_diachi;
        private System.Windows.Forms.TextBox txt_sdt;
        private System.Windows.Forms.TextBox txt_cmnd;
        private System.Windows.Forms.Label lbl_diachi;
        private System.Windows.Forms.Label lbl_sdt;
        private System.Windows.Forms.Label lbl_cmnd;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.TextBox txt_quequan;
        private System.Windows.Forms.Label lbl_quequan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton btn_khong;
        private System.Windows.Forms.RadioButton btn_co;
        private System.Windows.Forms.Label lbl_tinhtranghonnhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_manhanvien;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ngaysinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gioitinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cmnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_diachi;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_quequan;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_honnhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_email;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_blank;
        private System.Windows.Forms.DateTimePicker date_ngaysinh;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_xem;
        private System.Windows.Forms.Button btn_luu;
    }
}

