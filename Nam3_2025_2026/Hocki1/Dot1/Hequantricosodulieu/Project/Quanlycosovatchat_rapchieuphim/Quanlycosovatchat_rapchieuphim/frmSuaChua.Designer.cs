namespace Quanlycosovatchat_rapchieuphim
{
    partial class frmSuaChua
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboThietBi = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboGhe = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboTrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpNgaySuaChua = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtChiPhi = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMoTa = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvDanhSachSuaChua = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnCapNhatTrangThai = new Guna.UI2.WinForms.Guna2Button();
            this.btnThemSuaChua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoaSuaChua = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSuaChua)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thiết bị";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ghế";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Trạng thái";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày sửa chữa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mô tả";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Chi phí";
            // 
            // cboThietBi
            // 
            this.cboThietBi.BackColor = System.Drawing.Color.Transparent;
            this.cboThietBi.BorderRadius = 15;
            this.cboThietBi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboThietBi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThietBi.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboThietBi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboThietBi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboThietBi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboThietBi.ItemHeight = 30;
            this.cboThietBi.Location = new System.Drawing.Point(139, 49);
            this.cboThietBi.Name = "cboThietBi";
            this.cboThietBi.Size = new System.Drawing.Size(202, 36);
            this.cboThietBi.TabIndex = 6;
            this.cboThietBi.SelectedIndexChanged += new System.EventHandler(this.cboThietBi_SelectedIndexChanged);
            // 
            // cboGhe
            // 
            this.cboGhe.BackColor = System.Drawing.Color.Transparent;
            this.cboGhe.BorderRadius = 15;
            this.cboGhe.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboGhe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGhe.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboGhe.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboGhe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGhe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboGhe.ItemHeight = 30;
            this.cboGhe.Location = new System.Drawing.Point(139, 110);
            this.cboGhe.Name = "cboGhe";
            this.cboGhe.Size = new System.Drawing.Size(202, 36);
            this.cboGhe.TabIndex = 7;
            this.cboGhe.SelectedIndexChanged += new System.EventHandler(this.cboGhe_SelectedIndexChanged);
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.cboTrangThai.BorderRadius = 15;
            this.cboTrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTrangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTrangThai.ItemHeight = 30;
            this.cboTrangThai.Location = new System.Drawing.Point(139, 297);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(202, 36);
            this.cboTrangThai.TabIndex = 8;
            // 
            // dtpNgaySuaChua
            // 
            this.dtpNgaySuaChua.Checked = true;
            this.dtpNgaySuaChua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgaySuaChua.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgaySuaChua.Location = new System.Drawing.Point(139, 358);
            this.dtpNgaySuaChua.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgaySuaChua.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgaySuaChua.Name = "dtpNgaySuaChua";
            this.dtpNgaySuaChua.Size = new System.Drawing.Size(202, 36);
            this.dtpNgaySuaChua.TabIndex = 9;
            this.dtpNgaySuaChua.Value = new System.DateTime(2025, 9, 30, 21, 29, 15, 572);
            // 
            // txtChiPhi
            // 
            this.txtChiPhi.BorderRadius = 15;
            this.txtChiPhi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtChiPhi.DefaultText = "";
            this.txtChiPhi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtChiPhi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtChiPhi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtChiPhi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtChiPhi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtChiPhi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtChiPhi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtChiPhi.Location = new System.Drawing.Point(139, 181);
            this.txtChiPhi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtChiPhi.Name = "txtChiPhi";
            this.txtChiPhi.PlaceholderText = "";
            this.txtChiPhi.SelectedText = "";
            this.txtChiPhi.Size = new System.Drawing.Size(202, 34);
            this.txtChiPhi.TabIndex = 10;
            // 
            // txtMoTa
            // 
            this.txtMoTa.BorderRadius = 15;
            this.txtMoTa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMoTa.DefaultText = "";
            this.txtMoTa.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMoTa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMoTa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMoTa.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMoTa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMoTa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMoTa.Location = new System.Drawing.Point(139, 239);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.PlaceholderText = "";
            this.txtMoTa.SelectedText = "";
            this.txtMoTa.Size = new System.Drawing.Size(202, 32);
            this.txtMoTa.TabIndex = 11;
            // 
            // dgvDanhSachSuaChua
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDanhSachSuaChua.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachSuaChua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSachSuaChua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSachSuaChua.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDanhSachSuaChua.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDanhSachSuaChua.Location = new System.Drawing.Point(407, 31);
            this.dgvDanhSachSuaChua.Name = "dgvDanhSachSuaChua";
            this.dgvDanhSachSuaChua.RowHeadersVisible = false;
            this.dgvDanhSachSuaChua.RowHeadersWidth = 51;
            this.dgvDanhSachSuaChua.RowTemplate.Height = 24;
            this.dgvDanhSachSuaChua.Size = new System.Drawing.Size(1124, 363);
            this.dgvDanhSachSuaChua.TabIndex = 12;
            this.dgvDanhSachSuaChua.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDanhSachSuaChua.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDanhSachSuaChua.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDanhSachSuaChua.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDanhSachSuaChua.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDanhSachSuaChua.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDanhSachSuaChua.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDanhSachSuaChua.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDanhSachSuaChua.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDanhSachSuaChua.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDanhSachSuaChua.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDanhSachSuaChua.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachSuaChua.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvDanhSachSuaChua.ThemeStyle.ReadOnly = false;
            this.dgvDanhSachSuaChua.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDanhSachSuaChua.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDanhSachSuaChua.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDanhSachSuaChua.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDanhSachSuaChua.ThemeStyle.RowsStyle.Height = 24;
            this.dgvDanhSachSuaChua.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDanhSachSuaChua.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDanhSachSuaChua.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachSuaChua_CellClick);
            // 
            // btnCapNhatTrangThai
            // 
            this.btnCapNhatTrangThai.BorderRadius = 15;
            this.btnCapNhatTrangThai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCapNhatTrangThai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCapNhatTrangThai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCapNhatTrangThai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCapNhatTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCapNhatTrangThai.ForeColor = System.Drawing.Color.White;
            this.btnCapNhatTrangThai.Location = new System.Drawing.Point(58, 427);
            this.btnCapNhatTrangThai.Name = "btnCapNhatTrangThai";
            this.btnCapNhatTrangThai.Size = new System.Drawing.Size(180, 45);
            this.btnCapNhatTrangThai.TabIndex = 13;
            this.btnCapNhatTrangThai.Text = "Cập nhật trạng thái";
            this.btnCapNhatTrangThai.Click += new System.EventHandler(this.btnCapNhatTrangThai_Click);
            // 
            // btnThemSuaChua
            // 
            this.btnThemSuaChua.BorderRadius = 15;
            this.btnThemSuaChua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemSuaChua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemSuaChua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemSuaChua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemSuaChua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThemSuaChua.ForeColor = System.Drawing.Color.White;
            this.btnThemSuaChua.Location = new System.Drawing.Point(288, 427);
            this.btnThemSuaChua.Name = "btnThemSuaChua";
            this.btnThemSuaChua.Size = new System.Drawing.Size(180, 45);
            this.btnThemSuaChua.TabIndex = 14;
            this.btnThemSuaChua.Text = "Thêm sửa chữa";
            this.btnThemSuaChua.Click += new System.EventHandler(this.btnThemSuaChua_Click);
            // 
            // btnXoaSuaChua
            // 
            this.btnXoaSuaChua.BorderRadius = 15;
            this.btnXoaSuaChua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaSuaChua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaSuaChua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoaSuaChua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoaSuaChua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoaSuaChua.ForeColor = System.Drawing.Color.White;
            this.btnXoaSuaChua.Location = new System.Drawing.Point(520, 427);
            this.btnXoaSuaChua.Name = "btnXoaSuaChua";
            this.btnXoaSuaChua.Size = new System.Drawing.Size(180, 45);
            this.btnXoaSuaChua.TabIndex = 15;
            this.btnXoaSuaChua.Text = "Xoá";
            this.btnXoaSuaChua.Click += new System.EventHandler(this.btnXoaSuaChua_Click);
            // 
            // frmSuaChua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1553, 495);
            this.Controls.Add(this.btnXoaSuaChua);
            this.Controls.Add(this.btnThemSuaChua);
            this.Controls.Add(this.btnCapNhatTrangThai);
            this.Controls.Add(this.dgvDanhSachSuaChua);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.txtChiPhi);
            this.Controls.Add(this.dtpNgaySuaChua);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.cboGhe);
            this.Controls.Add(this.cboThietBi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSuaChua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSuaChua";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSuaChua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cboThietBi;
        private Guna.UI2.WinForms.Guna2ComboBox cboGhe;
        private Guna.UI2.WinForms.Guna2ComboBox cboTrangThai;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgaySuaChua;
        private Guna.UI2.WinForms.Guna2TextBox txtChiPhi;
        private Guna.UI2.WinForms.Guna2TextBox txtMoTa;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDanhSachSuaChua;
        private Guna.UI2.WinForms.Guna2Button btnCapNhatTrangThai;
        private Guna.UI2.WinForms.Guna2Button btnThemSuaChua;
        private Guna.UI2.WinForms.Guna2Button btnXoaSuaChua;
    }
}