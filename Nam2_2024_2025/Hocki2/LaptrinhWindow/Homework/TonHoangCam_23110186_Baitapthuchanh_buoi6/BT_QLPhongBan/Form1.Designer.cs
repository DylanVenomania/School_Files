namespace BT_QLPhongBan
{
    partial class frm_qlphongban
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
            this.lbl_maphongban = new System.Windows.Forms.Label();
            this.lbl_tenphongban = new System.Windows.Forms.Label();
            this.lbl_mota = new System.Windows.Forms.Label();
            this.txt_maphongban = new System.Windows.Forms.TextBox();
            this.txt_tenphongban = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txt_timkiem = new System.Windows.Forms.TextBox();
            this.btn_timkiem = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.txt_mota = new System.Windows.Forms.TextBox();
            this.grid_phongban = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grid_phongban)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_maphongban
            // 
            this.lbl_maphongban.AutoSize = true;
            this.lbl_maphongban.Location = new System.Drawing.Point(62, 82);
            this.lbl_maphongban.Name = "lbl_maphongban";
            this.lbl_maphongban.Size = new System.Drawing.Size(93, 16);
            this.lbl_maphongban.TabIndex = 0;
            this.lbl_maphongban.Text = "Mã phòng ban";
            // 
            // lbl_tenphongban
            // 
            this.lbl_tenphongban.AutoSize = true;
            this.lbl_tenphongban.Location = new System.Drawing.Point(62, 132);
            this.lbl_tenphongban.Name = "lbl_tenphongban";
            this.lbl_tenphongban.Size = new System.Drawing.Size(98, 16);
            this.lbl_tenphongban.TabIndex = 1;
            this.lbl_tenphongban.Text = "Tên phòng ban";
            // 
            // lbl_mota
            // 
            this.lbl_mota.AutoSize = true;
            this.lbl_mota.Location = new System.Drawing.Point(62, 183);
            this.lbl_mota.Name = "lbl_mota";
            this.lbl_mota.Size = new System.Drawing.Size(40, 16);
            this.lbl_mota.TabIndex = 2;
            this.lbl_mota.Text = "Mô tả";
            // 
            // txt_maphongban
            // 
            this.txt_maphongban.Location = new System.Drawing.Point(182, 79);
            this.txt_maphongban.Name = "txt_maphongban";
            this.txt_maphongban.Size = new System.Drawing.Size(188, 22);
            this.txt_maphongban.TabIndex = 3;
            // 
            // txt_tenphongban
            // 
            this.txt_tenphongban.Location = new System.Drawing.Point(182, 129);
            this.txt_tenphongban.Name = "txt_tenphongban";
            this.txt_tenphongban.Size = new System.Drawing.Size(188, 22);
            this.txt_tenphongban.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txt_timkiem
            // 
            this.txt_timkiem.Location = new System.Drawing.Point(182, 27);
            this.txt_timkiem.Name = "txt_timkiem";
            this.txt_timkiem.Size = new System.Drawing.Size(418, 22);
            this.txt_timkiem.TabIndex = 7;
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Location = new System.Drawing.Point(631, 21);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(80, 35);
            this.btn_timkiem.TabIndex = 8;
            this.btn_timkiem.Text = "Tìm kiếm";
            this.btn_timkiem.UseVisualStyleBackColor = true;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(631, 72);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(80, 37);
            this.btn_them.TabIndex = 9;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(631, 122);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(80, 36);
            this.btn_sua.TabIndex = 10;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(631, 176);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(80, 39);
            this.btn_xoa.TabIndex = 11;
            this.btn_xoa.Text = "Xoá";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(631, 232);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(80, 40);
            this.btn_thoat.TabIndex = 12;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // txt_mota
            // 
            this.txt_mota.Location = new System.Drawing.Point(182, 184);
            this.txt_mota.Multiline = true;
            this.txt_mota.Name = "txt_mota";
            this.txt_mota.Size = new System.Drawing.Size(418, 88);
            this.txt_mota.TabIndex = 13;
            // 
            // grid_phongban
            // 
            this.grid_phongban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_phongban.Location = new System.Drawing.Point(65, 297);
            this.grid_phongban.Name = "grid_phongban";
            this.grid_phongban.RowHeadersWidth = 51;
            this.grid_phongban.RowTemplate.Height = 24;
            this.grid_phongban.Size = new System.Drawing.Size(638, 130);
            this.grid_phongban.TabIndex = 14;
            this.grid_phongban.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_phongban_CellClick);
            // 
            // frm_qlphongban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grid_phongban);
            this.Controls.Add(this.txt_mota);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.btn_timkiem);
            this.Controls.Add(this.txt_timkiem);
            this.Controls.Add(this.txt_tenphongban);
            this.Controls.Add(this.txt_maphongban);
            this.Controls.Add(this.lbl_mota);
            this.Controls.Add(this.lbl_tenphongban);
            this.Controls.Add(this.lbl_maphongban);
            this.Name = "frm_qlphongban";
            this.Text = "Quản lý phòng ban";
            this.Load += new System.EventHandler(this.frm_qlphongban_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_phongban)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_maphongban;
        private System.Windows.Forms.Label lbl_tenphongban;
        private System.Windows.Forms.Label lbl_mota;
        private System.Windows.Forms.TextBox txt_maphongban;
        private System.Windows.Forms.TextBox txt_tenphongban;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txt_timkiem;
        private System.Windows.Forms.Button btn_timkiem;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.TextBox txt_mota;
        private System.Windows.Forms.DataGridView grid_phongban;
    }
}

