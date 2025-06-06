namespace QLDonhang_Report
{
    partial class frmQLdonhang
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
            this.txtHoadon = new System.Windows.Forms.TextBox();
            this.dtpNgaydat = new System.Windows.Forms.DateTimePicker();
            this.dtpNgaygiao = new System.Windows.Forms.DateTimePicker();
            this.txtGhichu = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvDonhang = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Masanpham = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Tensanpham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Donvitinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dongia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thanhtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonhang)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ ĐƠN HÀNG";
            // 
            // txtHoadon
            // 
            this.txtHoadon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoadon.Location = new System.Drawing.Point(177, 91);
            this.txtHoadon.Name = "txtHoadon";
            this.txtHoadon.Size = new System.Drawing.Size(199, 22);
            this.txtHoadon.TabIndex = 1;
            // 
            // dtpNgaydat
            // 
            this.dtpNgaydat.Location = new System.Drawing.Point(177, 137);
            this.dtpNgaydat.Name = "dtpNgaydat";
            this.dtpNgaydat.Size = new System.Drawing.Size(199, 22);
            this.dtpNgaydat.TabIndex = 2;
            // 
            // dtpNgaygiao
            // 
            this.dtpNgaygiao.Location = new System.Drawing.Point(533, 137);
            this.dtpNgaygiao.Name = "dtpNgaygiao";
            this.dtpNgaygiao.Size = new System.Drawing.Size(199, 22);
            this.dtpNgaygiao.TabIndex = 3;
            // 
            // txtGhichu
            // 
            this.txtGhichu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGhichu.Location = new System.Drawing.Point(177, 194);
            this.txtGhichu.Name = "txtGhichu";
            this.txtGhichu.Size = new System.Drawing.Size(555, 118);
            this.txtGhichu.TabIndex = 4;
            this.txtGhichu.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Theo hoá đơn số";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ngày đặt hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ghi chú";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(424, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ngày giao hàng";
            // 
            // dgvDonhang
            // 
            this.dgvDonhang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDonhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonhang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Masanpham,
            this.Tensanpham,
            this.Donvitinh,
            this.Soluong,
            this.Dongia,
            this.Thanhtien});
            this.dgvDonhang.Location = new System.Drawing.Point(25, 329);
            this.dgvDonhang.Name = "dgvDonhang";
            this.dgvDonhang.RowHeadersVisible = false;
            this.dgvDonhang.RowHeadersWidth = 51;
            this.dgvDonhang.RowTemplate.Height = 24;
            this.dgvDonhang.Size = new System.Drawing.Size(802, 218);
            this.dgvDonhang.TabIndex = 9;
            this.dgvDonhang.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonhang_CellValueChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(25, 556);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(91, 31);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "In";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(159, 556);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(113, 31);
            this.btnOrder.TabIndex = 11;
            this.btnOrder.Text = "Đặt hàng";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(553, 563);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tổng cộng";
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Location = new System.Drawing.Point(640, 560);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(187, 22);
            this.txtTotal.TabIndex = 13;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // Masanpham
            // 
            this.Masanpham.HeaderText = "Mã sản phẩm";
            this.Masanpham.MinimumWidth = 6;
            this.Masanpham.Name = "Masanpham";
            // 
            // Tensanpham
            // 
            this.Tensanpham.HeaderText = "Tên sản phẩm";
            this.Tensanpham.MinimumWidth = 6;
            this.Tensanpham.Name = "Tensanpham";
            this.Tensanpham.ReadOnly = true;
            // 
            // Donvitinh
            // 
            this.Donvitinh.HeaderText = "Đơn vị tính";
            this.Donvitinh.MinimumWidth = 6;
            this.Donvitinh.Name = "Donvitinh";
            this.Donvitinh.ReadOnly = true;
            // 
            // Soluong
            // 
            this.Soluong.HeaderText = "Số lượng";
            this.Soluong.MinimumWidth = 6;
            this.Soluong.Name = "Soluong";
            // 
            // Dongia
            // 
            this.Dongia.HeaderText = "Đơn giá";
            this.Dongia.MinimumWidth = 6;
            this.Dongia.Name = "Dongia";
            this.Dongia.ReadOnly = true;
            // 
            // Thanhtien
            // 
            this.Thanhtien.HeaderText = "Thành tiền";
            this.Thanhtien.MinimumWidth = 6;
            this.Thanhtien.Name = "Thanhtien";
            this.Thanhtien.ReadOnly = true;
            // 
            // frmQLdonhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 599);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvDonhang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGhichu);
            this.Controls.Add(this.dtpNgaygiao);
            this.Controls.Add(this.dtpNgaydat);
            this.Controls.Add(this.txtHoadon);
            this.Controls.Add(this.label1);
            this.Name = "frmQLdonhang";
            this.Text = "Quản lý Đơn Hàng_Tôn Hoàng Cầm - 23110186";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonhang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHoadon;
        private System.Windows.Forms.DateTimePicker dtpNgaydat;
        private System.Windows.Forms.DateTimePicker dtpNgaygiao;
        private System.Windows.Forms.RichTextBox txtGhichu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDonhang;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewComboBoxColumn Masanpham;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tensanpham;
        private System.Windows.Forms.DataGridViewTextBoxColumn Donvitinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Soluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dongia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thanhtien;
    }
}

