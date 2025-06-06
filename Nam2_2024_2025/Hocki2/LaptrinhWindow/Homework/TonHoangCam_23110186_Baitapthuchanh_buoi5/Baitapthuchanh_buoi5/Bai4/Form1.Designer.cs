namespace Bai4
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
            this.txbTongKhoa = new System.Windows.Forms.TextBox();
            this.txbMaKhoa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbTenKhoa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewKhoa = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhoa)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbTongKhoa);
            this.panel1.Controls.Add(this.txbMaKhoa);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txbTenKhoa);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(69, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 206);
            this.panel1.TabIndex = 0;
            // 
            // txbTongKhoa
            // 
            this.txbTongKhoa.Enabled = false;
            this.txbTongKhoa.Location = new System.Drawing.Point(190, 130);
            this.txbTongKhoa.Name = "txbTongKhoa";
            this.txbTongKhoa.Size = new System.Drawing.Size(177, 32);
            this.txbTongKhoa.TabIndex = 6;
            // 
            // txbMaKhoa
            // 
            this.txbMaKhoa.Location = new System.Drawing.Point(190, 72);
            this.txbMaKhoa.Name = "txbMaKhoa";
            this.txbMaKhoa.Size = new System.Drawing.Size(177, 32);
            this.txbMaKhoa.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(573, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tên Khoa: ";
            // 
            // txbTenKhoa
            // 
            this.txbTenKhoa.Location = new System.Drawing.Point(662, 69);
            this.txbTenKhoa.Name = "txbTenKhoa";
            this.txbTenKhoa.Size = new System.Drawing.Size(177, 32);
            this.txbTenKhoa.TabIndex = 4;
            this.txbTenKhoa.TextChanged += new System.EventHandler(this.txbTenKhoa_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(93, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tổng khoa: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Khoa: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(344, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ KHOA";
            // 
            // dataGridViewKhoa
            // 
            this.dataGridViewKhoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKhoa.Location = new System.Drawing.Point(69, 267);
            this.dataGridViewKhoa.Name = "dataGridViewKhoa";
            this.dataGridViewKhoa.RowHeadersWidth = 51;
            this.dataGridViewKhoa.RowTemplate.Height = 24;
            this.dataGridViewKhoa.Size = new System.Drawing.Size(876, 175);
            this.dataGridViewKhoa.TabIndex = 1;
            this.dataGridViewKhoa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKhoa_CellContentClick);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(84, 466);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(103, 57);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(224, 466);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 51);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Enabled = false;
            this.btnLuu.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(534, 469);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(111, 51);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(380, 466);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(101, 57);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(841, 469);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 51);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Enabled = false;
            this.btnHuy.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(687, 469);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(112, 52);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 559);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dataGridViewKhoa);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Quản Lý Khoa";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewKhoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.TextBox txbTenKhoa;
        private System.Windows.Forms.TextBox txbTongKhoa;
        private System.Windows.Forms.TextBox txbMaKhoa;
        private System.Windows.Forms.Label label5;
    }
}

