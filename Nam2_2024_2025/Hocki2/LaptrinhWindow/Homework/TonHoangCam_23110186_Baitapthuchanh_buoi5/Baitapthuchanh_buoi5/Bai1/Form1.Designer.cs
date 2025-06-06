namespace Bai1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dt_NgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txt_MaKhoa = new System.Windows.Forms.TextBox();
            this.txt_TenSV = new System.Windows.Forms.TextBox();
            this.txt_GioiTinh = new System.Windows.Forms.TextBox();
            this.txt_HoSV = new System.Windows.Forms.TextBox();
            this.txt_MaSV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewSV = new System.Windows.Forms.DataGridView();
            this.maSVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoSVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaySinhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioiTinhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maKhoaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sinhVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sINHVIENDataSet = new Bai1.SINHVIENDataSet();
            this.cmd_Them = new System.Windows.Forms.Button();
            this.cmd_Sua = new System.Windows.Forms.Button();
            this.cmd_Luu = new System.Windows.Forms.Button();
            this.cmd_Xoa = new System.Windows.Forms.Button();
            this.cmd_Thoat = new System.Windows.Forms.Button();
            this.cmd_Huy = new System.Windows.Forms.Button();
            this.sinhVienTableAdapter = new Bai1.SINHVIENDataSetTableAdapters.SinhVienTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sinhVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sINHVIENDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dt_NgaySinh);
            this.panel1.Controls.Add(this.txt_MaKhoa);
            this.panel1.Controls.Add(this.txt_TenSV);
            this.panel1.Controls.Add(this.txt_GioiTinh);
            this.panel1.Controls.Add(this.txt_HoSV);
            this.panel1.Controls.Add(this.txt_MaSV);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(33, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 183);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dt_NgaySinh
            // 
            this.dt_NgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_NgaySinh.Location = new System.Drawing.Point(130, 120);
            this.dt_NgaySinh.Name = "dt_NgaySinh";
            this.dt_NgaySinh.Size = new System.Drawing.Size(133, 27);
            this.dt_NgaySinh.TabIndex = 12;
            // 
            // txt_MaKhoa
            // 
            this.txt_MaKhoa.Location = new System.Drawing.Point(634, 118);
            this.txt_MaKhoa.Name = "txt_MaKhoa";
            this.txt_MaKhoa.Size = new System.Drawing.Size(132, 27);
            this.txt_MaKhoa.TabIndex = 11;
            // 
            // txt_TenSV
            // 
            this.txt_TenSV.Location = new System.Drawing.Point(634, 73);
            this.txt_TenSV.Name = "txt_TenSV";
            this.txt_TenSV.Size = new System.Drawing.Size(132, 27);
            this.txt_TenSV.TabIndex = 10;
            // 
            // txt_GioiTinh
            // 
            this.txt_GioiTinh.Location = new System.Drawing.Point(364, 121);
            this.txt_GioiTinh.Name = "txt_GioiTinh";
            this.txt_GioiTinh.Size = new System.Drawing.Size(141, 27);
            this.txt_GioiTinh.TabIndex = 9;
            // 
            // txt_HoSV
            // 
            this.txt_HoSV.Location = new System.Drawing.Point(364, 69);
            this.txt_HoSV.Name = "txt_HoSV";
            this.txt_HoSV.Size = new System.Drawing.Size(141, 27);
            this.txt_HoSV.TabIndex = 8;
            // 
            // txt_MaSV
            // 
            this.txt_MaSV.Location = new System.Drawing.Point(130, 69);
            this.txt_MaSV.Name = "txt_MaSV";
            this.txt_MaSV.Size = new System.Drawing.Size(133, 27);
            this.txt_MaSV.TabIndex = 7;
            this.txt_MaSV.TextChanged += new System.EventHandler(this.txt_MaSV_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(543, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Mã khoa: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(543, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Tên SV: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(298, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Giới tính: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(298, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Họ SV: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày sinh: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã SV:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(318, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Sinh Viên";
            // 
            // dataGridViewSV
            // 
            this.dataGridViewSV.AutoGenerateColumns = false;
            this.dataGridViewSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maSVDataGridViewTextBoxColumn,
            this.hoSVDataGridViewTextBoxColumn,
            this.tenSVDataGridViewTextBoxColumn,
            this.ngaySinhDataGridViewTextBoxColumn,
            this.gioiTinhDataGridViewTextBoxColumn,
            this.maKhoaDataGridViewTextBoxColumn});
            this.dataGridViewSV.DataSource = this.sinhVienBindingSource;
            this.dataGridViewSV.Location = new System.Drawing.Point(33, 250);
            this.dataGridViewSV.Name = "dataGridViewSV";
            this.dataGridViewSV.RowHeadersWidth = 51;
            this.dataGridViewSV.RowTemplate.Height = 24;
            this.dataGridViewSV.Size = new System.Drawing.Size(833, 226);
            this.dataGridViewSV.TabIndex = 1;
            this.dataGridViewSV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSV_CellContentClick);
            // 
            // maSVDataGridViewTextBoxColumn
            // 
            this.maSVDataGridViewTextBoxColumn.DataPropertyName = "MaSV";
            this.maSVDataGridViewTextBoxColumn.HeaderText = "MaSV";
            this.maSVDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.maSVDataGridViewTextBoxColumn.Name = "maSVDataGridViewTextBoxColumn";
            this.maSVDataGridViewTextBoxColumn.Width = 150;
            // 
            // hoSVDataGridViewTextBoxColumn
            // 
            this.hoSVDataGridViewTextBoxColumn.DataPropertyName = "HoSV";
            this.hoSVDataGridViewTextBoxColumn.HeaderText = "HoSV";
            this.hoSVDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hoSVDataGridViewTextBoxColumn.Name = "hoSVDataGridViewTextBoxColumn";
            this.hoSVDataGridViewTextBoxColumn.Width = 150;
            // 
            // tenSVDataGridViewTextBoxColumn
            // 
            this.tenSVDataGridViewTextBoxColumn.DataPropertyName = "TenSV";
            this.tenSVDataGridViewTextBoxColumn.HeaderText = "TenSV";
            this.tenSVDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tenSVDataGridViewTextBoxColumn.Name = "tenSVDataGridViewTextBoxColumn";
            this.tenSVDataGridViewTextBoxColumn.Width = 149;
            // 
            // ngaySinhDataGridViewTextBoxColumn
            // 
            this.ngaySinhDataGridViewTextBoxColumn.DataPropertyName = "NgaySinh";
            this.ngaySinhDataGridViewTextBoxColumn.HeaderText = "NgaySinh";
            this.ngaySinhDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ngaySinhDataGridViewTextBoxColumn.Name = "ngaySinhDataGridViewTextBoxColumn";
            this.ngaySinhDataGridViewTextBoxColumn.Width = 150;
            // 
            // gioiTinhDataGridViewTextBoxColumn
            // 
            this.gioiTinhDataGridViewTextBoxColumn.DataPropertyName = "GioiTinh";
            this.gioiTinhDataGridViewTextBoxColumn.HeaderText = "GioiTinh";
            this.gioiTinhDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.gioiTinhDataGridViewTextBoxColumn.Name = "gioiTinhDataGridViewTextBoxColumn";
            this.gioiTinhDataGridViewTextBoxColumn.Width = 150;
            // 
            // maKhoaDataGridViewTextBoxColumn
            // 
            this.maKhoaDataGridViewTextBoxColumn.DataPropertyName = "MaKhoa";
            this.maKhoaDataGridViewTextBoxColumn.HeaderText = "MaKhoa";
            this.maKhoaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.maKhoaDataGridViewTextBoxColumn.Name = "maKhoaDataGridViewTextBoxColumn";
            this.maKhoaDataGridViewTextBoxColumn.Width = 150;
            // 
            // sinhVienBindingSource
            // 
            this.sinhVienBindingSource.DataMember = "SinhVien";
            this.sinhVienBindingSource.DataSource = this.sINHVIENDataSet;
            // 
            // sINHVIENDataSet
            // 
            this.sINHVIENDataSet.DataSetName = "SINHVIENDataSet";
            this.sINHVIENDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmd_Them
            // 
            this.cmd_Them.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_Them.Location = new System.Drawing.Point(63, 494);
            this.cmd_Them.Name = "cmd_Them";
            this.cmd_Them.Size = new System.Drawing.Size(90, 43);
            this.cmd_Them.TabIndex = 2;
            this.cmd_Them.Text = "Thêm";
            this.cmd_Them.UseVisualStyleBackColor = true;
            this.cmd_Them.Click += new System.EventHandler(this.cmd_Them_Click);
            // 
            // cmd_Sua
            // 
            this.cmd_Sua.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_Sua.Location = new System.Drawing.Point(198, 494);
            this.cmd_Sua.Name = "cmd_Sua";
            this.cmd_Sua.Size = new System.Drawing.Size(83, 43);
            this.cmd_Sua.TabIndex = 3;
            this.cmd_Sua.Text = "Sửa";
            this.cmd_Sua.UseVisualStyleBackColor = true;
            this.cmd_Sua.Click += new System.EventHandler(this.cmd_Sua_Click);
            // 
            // cmd_Luu
            // 
            this.cmd_Luu.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_Luu.Location = new System.Drawing.Point(472, 494);
            this.cmd_Luu.Name = "cmd_Luu";
            this.cmd_Luu.Size = new System.Drawing.Size(80, 43);
            this.cmd_Luu.TabIndex = 5;
            this.cmd_Luu.Text = "Lưu";
            this.cmd_Luu.UseVisualStyleBackColor = true;
            this.cmd_Luu.Click += new System.EventHandler(this.cmd_Luu_Click);
            // 
            // cmd_Xoa
            // 
            this.cmd_Xoa.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_Xoa.Location = new System.Drawing.Point(334, 494);
            this.cmd_Xoa.Name = "cmd_Xoa";
            this.cmd_Xoa.Size = new System.Drawing.Size(81, 43);
            this.cmd_Xoa.TabIndex = 4;
            this.cmd_Xoa.Text = "Xóa";
            this.cmd_Xoa.UseVisualStyleBackColor = true;
            this.cmd_Xoa.Click += new System.EventHandler(this.cmd_Xoa_Click);
            // 
            // cmd_Thoat
            // 
            this.cmd_Thoat.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_Thoat.Location = new System.Drawing.Point(749, 494);
            this.cmd_Thoat.Name = "cmd_Thoat";
            this.cmd_Thoat.Size = new System.Drawing.Size(84, 43);
            this.cmd_Thoat.TabIndex = 7;
            this.cmd_Thoat.Text = "Thoát";
            this.cmd_Thoat.UseVisualStyleBackColor = true;
            this.cmd_Thoat.Click += new System.EventHandler(this.cmd_Thoat_Click);
            // 
            // cmd_Huy
            // 
            this.cmd_Huy.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_Huy.Location = new System.Drawing.Point(608, 494);
            this.cmd_Huy.Name = "cmd_Huy";
            this.cmd_Huy.Size = new System.Drawing.Size(81, 43);
            this.cmd_Huy.TabIndex = 6;
            this.cmd_Huy.Text = "Hủy";
            this.cmd_Huy.UseVisualStyleBackColor = true;
            this.cmd_Huy.Click += new System.EventHandler(this.cmd_Huy_Click);
            // 
            // sinhVienTableAdapter
            // 
            this.sinhVienTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 569);
            this.Controls.Add(this.cmd_Thoat);
            this.Controls.Add(this.cmd_Huy);
            this.Controls.Add(this.cmd_Luu);
            this.Controls.Add(this.cmd_Xoa);
            this.Controls.Add(this.cmd_Sua);
            this.Controls.Add(this.cmd_Them);
            this.Controls.Add(this.dataGridViewSV);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Quản lý sinh viên_Bài1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sinhVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sINHVIENDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_MaKhoa;
        private System.Windows.Forms.TextBox txt_TenSV;
        private System.Windows.Forms.TextBox txt_GioiTinh;
        private System.Windows.Forms.TextBox txt_HoSV;
        private System.Windows.Forms.TextBox txt_MaSV;
        private System.Windows.Forms.DateTimePicker dt_NgaySinh;
        private System.Windows.Forms.DataGridView dataGridViewSV;
        private System.Windows.Forms.Button cmd_Them;
        private System.Windows.Forms.Button cmd_Sua;
        private System.Windows.Forms.Button cmd_Luu;
        private System.Windows.Forms.Button cmd_Xoa;
        private System.Windows.Forms.Button cmd_Thoat;
        private System.Windows.Forms.Button cmd_Huy;
        private SINHVIENDataSet sINHVIENDataSet;
        private System.Windows.Forms.BindingSource sinhVienBindingSource;
        private SINHVIENDataSetTableAdapters.SinhVienTableAdapter sinhVienTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoSVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaySinhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioiTinhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maKhoaDataGridViewTextBoxColumn;
    }
}

