using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Bai3
{
    public partial class Form1: Form
    {
        KetNoiDuLieu ketnoi = new KetNoiDuLieu();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {


            if (txbMaSV.Text == "")
                MessageBox.Show("Không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                    string maSV = txbMaSV.Text.Trim();
                    string sql = "SELECT MaMH AS [Mã môn học], TenMH AS [Tên môn học], DiemThi AS [Điểm thi]FROM MonHoc WHERE MaSV='" + maSV + "'";
                    dataGridDiemThi.DataSource = ketnoi.taobang(sql);

                    string sqlThongTinSV = "SELECT (HoSV + ' ' + TenSV) AS HoTen, NgaySinh, GioiTinh, MaKhoa FROM SinhVien WHERE MaSV='" + maSV + "'";
                    DataTable dt = new DataTable();
                    dt = ketnoi.taobang(sqlThongTinSV);

                    DataRow row = dt.Rows[0];
                    txbHoTenSV.Text = row["HoTen"].ToString();
                    txbMaKhoa.Text = row["MaKhoa"].ToString();
                    txbGioiTinh.Text = row["GioiTinh"].ToString();
                    dtbNgSinh.Text = row["NgaySinh"].ToString();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ketnoi.myconnect();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
            ketnoi.myClose();
        }
    }
}
