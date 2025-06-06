namespace Bai2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.dtNgayDatHang = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtNgayGiaoHang = new System.Windows.Forms.DateTimePicker();
            this.dtgvThongTinDonHang = new System.Windows.Forms.DataGridView();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnDatHang = new System.Windows.Forms.Button();
            this.lbTongCong = new System.Windows.Forms.Label();
            this.txtTongCong = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongTinDonHang)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(384, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN ĐƠN HÀNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Theo hóa đơn số:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày đặt hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(308, 212);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(327, 48);
            this.txtGhiChu.TabIndex = 4;
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoHoaDon.Location = new System.Drawing.Point(308, 112);
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.Size = new System.Drawing.Size(211, 25);
            this.txtSoHoaDon.TabIndex = 5;
            // 
            // dtNgayDatHang
            // 
            this.dtNgayDatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayDatHang.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayDatHang.Location = new System.Drawing.Point(308, 159);
            this.dtNgayDatHang.Name = "dtNgayDatHang";
            this.dtNgayDatHang.Size = new System.Drawing.Size(135, 24);
            this.dtNgayDatHang.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(481, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ngày đặt hàng";
            // 
            // dtNgayGiaoHang
            // 
            this.dtNgayGiaoHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayGiaoHang.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayGiaoHang.Location = new System.Drawing.Point(565, 161);
            this.dtNgayGiaoHang.Name = "dtNgayGiaoHang";
            this.dtNgayGiaoHang.Size = new System.Drawing.Size(135, 24);
            this.dtNgayGiaoHang.TabIndex = 8;
            // 
            // dtgvThongTinDonHang
            // 
            this.dtgvThongTinDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThongTinDonHang.Location = new System.Drawing.Point(92, 287);
            this.dtgvThongTinDonHang.Name = "dtgvThongTinDonHang";
            this.dtgvThongTinDonHang.Size = new System.Drawing.Size(864, 301);
            this.dtgvThongTinDonHang.TabIndex = 9;
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Location = new System.Drawing.Point(91, 594);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 39);
            this.btnIn.TabIndex = 10;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnDatHang
            // 
            this.btnDatHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatHang.Location = new System.Drawing.Point(200, 594);
            this.btnDatHang.Name = "btnDatHang";
            this.btnDatHang.Size = new System.Drawing.Size(96, 39);
            this.btnDatHang.TabIndex = 11;
            this.btnDatHang.Text = "Đặt Hàng";
            this.btnDatHang.UseVisualStyleBackColor = true;
            this.btnDatHang.Click += new System.EventHandler(this.btnDatHang_Click);
            // 
            // lbTongCong
            // 
            this.lbTongCong.AutoSize = true;
            this.lbTongCong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongCong.Location = new System.Drawing.Point(739, 604);
            this.lbTongCong.Name = "lbTongCong";
            this.lbTongCong.Size = new System.Drawing.Size(73, 19);
            this.lbTongCong.TabIndex = 12;
            this.lbTongCong.Text = "Tổng cộng";
            // 
            // txtTongCong
            // 
            this.txtTongCong.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTongCong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTongCong.Enabled = false;
            this.txtTongCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong.Location = new System.Drawing.Point(824, 603);
            this.txtTongCong.Name = "txtTongCong";
            this.txtTongCong.Size = new System.Drawing.Size(132, 19);
            this.txtTongCong.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 645);
            this.Controls.Add(this.txtTongCong);
            this.Controls.Add(this.lbTongCong);
            this.Controls.Add(this.btnDatHang);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dtgvThongTinDonHang);
            this.Controls.Add(this.dtNgayGiaoHang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtNgayDatHang);
            this.Controls.Add(this.txtSoHoaDon);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongTinDonHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtSoHoaDon;
        private System.Windows.Forms.DateTimePicker dtNgayDatHang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtNgayGiaoHang;
        private System.Windows.Forms.DataGridView dtgvThongTinDonHang;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnDatHang;
        private System.Windows.Forms.Label lbTongCong;
        private System.Windows.Forms.TextBox txtTongCong;
    }
}

