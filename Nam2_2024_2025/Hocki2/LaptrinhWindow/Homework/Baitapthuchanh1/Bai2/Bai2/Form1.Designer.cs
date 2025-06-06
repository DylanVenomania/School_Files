namespace Bai2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_thontin = new Label();
            lbl_hoten = new Label();
            txt_hoten = new TextBox();
            lbl_namsinh = new Label();
            lbl_sothich = new Label();
            comboBox_ngay = new ComboBox();
            comboBox_thang = new ComboBox();
            comboBox_nam = new ComboBox();
            txt_sothich = new TextBox();
            btn_xem = new Button();
            txt_khungketqua = new TextBox();
            btn_thoat = new Button();
            SuspendLayout();
            // 
            // lbl_thontin
            // 
            lbl_thontin.AutoSize = true;
            lbl_thontin.BackColor = SystemColors.ButtonFace;
            lbl_thontin.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_thontin.ForeColor = Color.Red;
            lbl_thontin.Location = new Point(233, 37);
            lbl_thontin.Name = "lbl_thontin";
            lbl_thontin.Size = new Size(96, 23);
            lbl_thontin.TabIndex = 0;
            lbl_thontin.Text = "Thông Tin";
            // 
            // lbl_hoten
            // 
            lbl_hoten.AutoSize = true;
            lbl_hoten.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_hoten.Location = new Point(67, 89);
            lbl_hoten.Name = "lbl_hoten";
            lbl_hoten.Size = new Size(73, 19);
            lbl_hoten.TabIndex = 1;
            lbl_hoten.Text = "Họ và tên";
            // 
            // txt_hoten
            // 
            txt_hoten.BorderStyle = BorderStyle.FixedSingle;
            txt_hoten.Location = new Point(171, 85);
            txt_hoten.Name = "txt_hoten";
            txt_hoten.Size = new Size(257, 27);
            txt_hoten.TabIndex = 4;
            // 
            // lbl_namsinh
            // 
            lbl_namsinh.AutoSize = true;
            lbl_namsinh.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_namsinh.Location = new Point(67, 135);
            lbl_namsinh.Name = "lbl_namsinh";
            lbl_namsinh.Size = new Size(73, 19);
            lbl_namsinh.TabIndex = 5;
            lbl_namsinh.Text = "Năm sinh";
            // 
            // lbl_sothich
            // 
            lbl_sothich.AutoSize = true;
            lbl_sothich.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_sothich.Location = new Point(67, 182);
            lbl_sothich.Name = "lbl_sothich";
            lbl_sothich.Size = new Size(65, 19);
            lbl_sothich.TabIndex = 6;
            lbl_sothich.Text = "Sở thích";
            // 
            // comboBox_ngay
            // 
            comboBox_ngay.FormattingEnabled = true;
            comboBox_ngay.ImeMode = ImeMode.NoControl;
            comboBox_ngay.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" });
            comboBox_ngay.Location = new Point(171, 131);
            comboBox_ngay.Name = "comboBox_ngay";
            comboBox_ngay.Size = new Size(53, 28);
            comboBox_ngay.TabIndex = 7;
           
            // 
            // comboBox_thang
            // 
            comboBox_thang.FormattingEnabled = true;
            comboBox_thang.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            comboBox_thang.Location = new Point(257, 131);
            comboBox_thang.Name = "comboBox_thang";
            comboBox_thang.Size = new Size(53, 28);
            comboBox_thang.TabIndex = 8;
            // 
            // comboBox_nam
            // 
            comboBox_nam.FormattingEnabled = true;
            comboBox_nam.Items.AddRange(new object[] { "Dưới đây là danh sách các năm từ 1900 đến 2025, mỗi năm trên một dòng:", "", "1900  ", "1901  ", "1902  ", "1903  ", "1904  ", "1905  ", "1906  ", "1907  ", "1908  ", "1909  ", "1910  ", "1911  ", "1912  ", "1913  ", "1914  ", "1915  ", "1916  ", "1917  ", "1918  ", "1919  ", "1920  ", "1921  ", "1922  ", "1923  ", "1924  ", "1925  ", "1926  ", "1927  ", "1928  ", "1929  ", "1930  ", "1931  ", "1932  ", "1933  ", "1934  ", "1935  ", "1936  ", "1937  ", "1938  ", "1939  ", "1940  ", "1941  ", "1942  ", "1943  ", "1944  ", "1945  ", "1946  ", "1947  ", "1948  ", "1949  ", "1950  ", "1951  ", "1952  ", "1953  ", "1954  ", "1955  ", "1956  ", "1957  ", "1958  ", "1959  ", "1960  ", "1961  ", "1962  ", "1963  ", "1964  ", "1965  ", "1966  ", "1967  ", "1968  ", "1969  ", "1970  ", "1971  ", "1972  ", "1973  ", "1974  ", "1975  ", "1976  ", "1977  ", "1978  ", "1979  ", "1980  ", "1981  ", "1982  ", "1983  ", "1984  ", "1985  ", "1986  ", "1987  ", "1988  ", "1989  ", "1990  ", "1991  ", "1992  ", "1993  ", "1994  ", "1995  ", "1996  ", "1997  ", "1998  ", "1999  ", "2000  ", "2001  ", "2002  ", "2003  ", "2004  ", "2005  ", "2006  ", "2007  ", "2008  ", "2009  ", "2010  ", "2011  ", "2012  ", "2013  ", "2014  ", "2015  ", "2016  ", "2017  ", "2018  ", "2019  ", "2020  ", "2021  ", "2022  ", "2023  ", "2024  ", "2025  " });
            comboBox_nam.Location = new Point(348, 131);
            comboBox_nam.Name = "comboBox_nam";
            comboBox_nam.Size = new Size(80, 28);
            comboBox_nam.TabIndex = 9;
            // 
            // txt_sothich
            // 
            txt_sothich.BorderStyle = BorderStyle.FixedSingle;
            txt_sothich.Location = new Point(171, 178);
            txt_sothich.Name = "txt_sothich";
            txt_sothich.Size = new Size(257, 27);
            txt_sothich.TabIndex = 10;
            // 
            // btn_xem
            // 
            btn_xem.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_xem.Location = new Point(171, 247);
            btn_xem.Name = "btn_xem";
            btn_xem.Size = new Size(98, 26);
            btn_xem.TabIndex = 11;
            btn_xem.Text = "Xem";
            btn_xem.UseVisualStyleBackColor = true;
            btn_xem.Click += btn_xem_Click;
            // 
            // txt_khungketqua
            // 
            txt_khungketqua.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_khungketqua.Location = new Point(25, 293);
            txt_khungketqua.Multiline = true;
            txt_khungketqua.Name = "txt_khungketqua";
            txt_khungketqua.ReadOnly = true;
            txt_khungketqua.Size = new Size(534, 148);
            txt_khungketqua.TabIndex = 13;
            // 
            // btn_thoat
            // 
            btn_thoat.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_thoat.Location = new Point(303, 247);
            btn_thoat.Name = "btn_thoat";
            btn_thoat.Size = new Size(98, 26);
            btn_thoat.TabIndex = 14;
            btn_thoat.Text = "Thoát";
            btn_thoat.UseVisualStyleBackColor = true;
            btn_thoat.Click += btn_thoat_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 453);
            Controls.Add(btn_thoat);
            Controls.Add(txt_khungketqua);
            Controls.Add(btn_xem);
            Controls.Add(txt_sothich);
            Controls.Add(comboBox_nam);
            Controls.Add(comboBox_thang);
            Controls.Add(comboBox_ngay);
            Controls.Add(lbl_sothich);
            Controls.Add(lbl_namsinh);
            Controls.Add(txt_hoten);
            Controls.Add(lbl_hoten);
            Controls.Add(lbl_thontin);
            Name = "Form1";
            Text = "Thông tin cá nhân";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_thontin;
        private Label lbl_hoten;
        private TextBox txt_hoten;
        private Label lbl_namsinh;
        private Label lbl_sothich;
        private ComboBox comboBox_ngay;
        private ComboBox comboBox_thang;
        private ComboBox comboBox_nam;
        private TextBox txt_sothich;
        private Button btn_xem;
        private TextBox txt_khungketqua;
        private Button btn_thoat;
    }
}
