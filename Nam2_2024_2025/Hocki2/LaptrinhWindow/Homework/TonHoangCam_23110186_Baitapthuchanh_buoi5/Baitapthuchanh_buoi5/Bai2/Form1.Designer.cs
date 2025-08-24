namespace bai2
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
            this.cbMaKhoa = new System.Windows.Forms.ComboBox();
            this.txt_TenKhoa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewSV = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_TongSV = new System.Windows.Forms.TextBox();
            this.cmd_Thoat = new System.Windows.Forms.Button();
            this.sINHVIENDataSet = new bai2.SINHVIENDataSet();
            this.khoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.khoaTableAdapter = new bai2.SINHVIENDataSetTableAdapters.KhoaTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sINHVIENDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbMaKhoa);
            this.panel1.Controls.Add(this.txt_TenKhoa);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(130, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(742, 228);
            this.panel1.TabIndex = 0;
            // 
            // cbMaKhoa
            // 
            this.cbMaKhoa.FormattingEnabled = true;
            this.cbMaKhoa.Location = new System.Drawing.Point(151, 125);
            this.cbMaKhoa.Name = "cbMaKhoa";
            this.cbMaKhoa.Size = new System.Drawing.Size(106, 24);
            this.cbMaKhoa.TabIndex = 10;
            this.cbMaKhoa.SelectedIndexChanged += new System.EventHandler(this.cbMaKhoa_SelectedIndexChanged);
            // 
            // txt_TenKhoa
            // 
            this.txt_TenKhoa.Location = new System.Drawing.Point(448, 121);
            this.txt_TenKhoa.Name = "txt_TenKhoa";
            this.txt_TenKhoa.Size = new System.Drawing.Size(238, 23);
            this.txt_TenKhoa.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(61, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 18);
            this.label8.TabIndex = 8;
            this.label8.Text = "Mã khoa :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(349, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tên khoa :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(138, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thống kê sinh viên theo khoa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 1;
            // 
            // dataGridViewSV
            // 
            this.dataGridViewSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSV.Location = new System.Drawing.Point(130, 284);
            this.dataGridViewSV.Name = "dataGridViewSV";
            this.dataGridViewSV.RowHeadersWidth = 51;
            this.dataGridViewSV.RowTemplate.Height = 24;
            this.dataGridViewSV.Size = new System.Drawing.Size(742, 187);
            this.dataGridViewSV.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(218, 519);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tổng";
            // 
            // txt_TongSV
            // 
            this.txt_TongSV.Enabled = false;
            this.txt_TongSV.Location = new System.Drawing.Point(266, 514);
            this.txt_TongSV.Name = "txt_TongSV";
            this.txt_TongSV.Size = new System.Drawing.Size(151, 23);
            this.txt_TongSV.TabIndex = 10;
            // 
            // cmd_Thoat
            // 
            this.cmd_Thoat.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_Thoat.Location = new System.Drawing.Point(627, 506);
            this.cmd_Thoat.Name = "cmd_Thoat";
            this.cmd_Thoat.Size = new System.Drawing.Size(98, 37);
            this.cmd_Thoat.TabIndex = 11;
            this.cmd_Thoat.Text = "Thoát";
            this.cmd_Thoat.UseVisualStyleBackColor = true;
            this.cmd_Thoat.Click += new System.EventHandler(this.cmd_Thoat_Click);
            // 
            // sINHVIENDataSet
            // 
            this.sINHVIENDataSet.DataSetName = "SINHVIENDataSet";
            this.sINHVIENDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // khoaBindingSource
            // 
            this.khoaBindingSource.DataMember = "Khoa";
            this.khoaBindingSource.DataSource = this.sINHVIENDataSet;
            // 
            // khoaTableAdapter
            // 
            this.khoaTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 587);
            this.Controls.Add(this.cmd_Thoat);
            this.Controls.Add(this.txt_TongSV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewSV);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Thống Kê Sinh Viên Theo Khoa";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sINHVIENDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridViewSV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_TenKhoa;
        private System.Windows.Forms.TextBox txt_TongSV;
        private System.Windows.Forms.ComboBox cbMaKhoa;
        private System.Windows.Forms.Button cmd_Thoat;
        private SINHVIENDataSet sINHVIENDataSet;
        private System.Windows.Forms.BindingSource khoaBindingSource;
        private SINHVIENDataSetTableAdapters.KhoaTableAdapter khoaTableAdapter;
    }
}

