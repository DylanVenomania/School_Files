namespace Bai3
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.dtbNgSinh = new System.Windows.Forms.DateTimePicker();
            this.txbMaKhoa = new System.Windows.Forms.TextBox();
            this.txbHoTenSV = new System.Windows.Forms.TextBox();
            this.txbGioiTinh = new System.Windows.Forms.TextBox();
            this.txbMaSV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridDiemThi = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDiemThi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnTim);
            this.panel1.Controls.Add(this.dtbNgSinh);
            this.panel1.Controls.Add(this.txbMaKhoa);
            this.panel1.Controls.Add(this.txbHoTenSV);
            this.panel1.Controls.Add(this.txbGioiTinh);
            this.panel1.Controls.Add(this.txbMaSV);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(74, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 282);
            this.panel1.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(756, 220);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(98, 40);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(608, 220);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(98, 40);
            this.btnTim.TabIndex = 12;
            this.btnTim.Text = "Tìm ";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // dtbNgSinh
            // 
            this.dtbNgSinh.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtbNgSinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtbNgSinh.Location = new System.Drawing.Point(200, 150);
            this.dtbNgSinh.Name = "dtbNgSinh";
            this.dtbNgSinh.Size = new System.Drawing.Size(173, 26);
            this.dtbNgSinh.TabIndex = 11;
            // 
            // txbMaKhoa
            // 
            this.txbMaKhoa.Enabled = false;
            this.txbMaKhoa.Location = new System.Drawing.Point(608, 153);
            this.txbMaKhoa.Name = "txbMaKhoa";
            this.txbMaKhoa.Size = new System.Drawing.Size(246, 32);
            this.txbMaKhoa.TabIndex = 10;
            // 
            // txbHoTenSV
            // 
            this.txbHoTenSV.Enabled = false;
            this.txbHoTenSV.Location = new System.Drawing.Point(608, 86);
            this.txbHoTenSV.Name = "txbHoTenSV";
            this.txbHoTenSV.Size = new System.Drawing.Size(246, 32);
            this.txbHoTenSV.TabIndex = 9;
            // 
            // txbGioiTinh
            // 
            this.txbGioiTinh.Enabled = false;
            this.txbGioiTinh.Location = new System.Drawing.Point(200, 207);
            this.txbGioiTinh.Name = "txbGioiTinh";
            this.txbGioiTinh.Size = new System.Drawing.Size(173, 32);
            this.txbGioiTinh.TabIndex = 8;
            // 
            // txbMaSV
            // 
            this.txbMaSV.Location = new System.Drawing.Point(200, 86);
            this.txbMaSV.Name = "txbMaSV";
            this.txbMaSV.Size = new System.Drawing.Size(173, 32);
            this.txbMaSV.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(46, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Giới tính";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(496, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mã Khoa: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(496, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Họ Tên SV: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày Sinh: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhập Mã SV: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.RosyBrown;
            this.label1.Location = new System.Drawing.Point(258, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm Kiếm Thông Tin Sinh Viên";
            // 
            // dataGridDiemThi
            // 
            this.dataGridDiemThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDiemThi.Location = new System.Drawing.Point(74, 339);
            this.dataGridDiemThi.Name = "dataGridDiemThi";
            this.dataGridDiemThi.RowHeadersWidth = 51;
            this.dataGridDiemThi.RowTemplate.Height = 24;
            this.dataGridDiemThi.Size = new System.Drawing.Size(900, 192);
            this.dataGridDiemThi.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 626);
            this.Controls.Add(this.dataGridDiemThi);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Tìm Kiếm Thông Tin Sinh Viên";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDiemThi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtbNgSinh;
        private System.Windows.Forms.TextBox txbMaKhoa;
        private System.Windows.Forms.TextBox txbHoTenSV;
        private System.Windows.Forms.TextBox txbGioiTinh;
        private System.Windows.Forms.TextBox txbMaSV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dataGridDiemThi;
    }
}

