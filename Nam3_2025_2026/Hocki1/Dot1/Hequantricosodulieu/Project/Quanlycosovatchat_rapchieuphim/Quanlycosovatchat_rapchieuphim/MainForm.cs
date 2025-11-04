using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Quanlycosovatchat_rapchieuphim.frmDangNhap;

namespace Quanlycosovatchat_rapchieuphim
{

    public partial class MainForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CinemaConn"].ConnectionString;
        
        public MainForm()
        {

            InitializeComponent();
           
        }

        public static void OpenConnection(SqlConnection conn)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public static void CloseConnection(SqlConnection conn)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin người dùng
            lblTenNguoiDung.Text = $"Chào: {Global.UserInfo.HoTen}";
            lblVaiTro.Text = $"Vai trò: {GetRoleName(Global.UserInfo.VaiTroID)}";

            // Hiển thị nút theo vai trò
            ConfigureButtonsByRole(Global.UserInfo.VaiTroID);
        }

        private string GetRoleName(string vaiTroID)
        {
            switch (vaiTroID)
            {
                case "VT001": return "Admin";
                case "VT002": return "Nhân viên kho";
                case "VT003": return "Nhân viên kỹ thuật";
                case "VT004": return "Nhân viên bảo trì";
                default: return "Không xác định";
            }
        }
        
        private void ConfigureButtonsByRole(string vaiTroID)
        {
            // Mặc định ẩn tất cả nút
            btnQuanLyDanhMuc.Visible = false;
            btnQuanLyThietBi.Visible = false;
            btnQuanLyPhongChieu.Visible = false;
            btnQuanLyGhe.Visible = false;
            btnQuanLySuaChua.Visible = false;
            btnQuanLyNhanVien.Visible = false;
            btnXemLichSu.Visible = false;

            // Hiển thị nút theo vai trò
            switch (vaiTroID)
            {
                case "VT001": // Admin
                    btnQuanLyDanhMuc.Visible = true;
                    btnQuanLyThietBi.Visible = true;
                    btnQuanLyPhongChieu.Visible = true;
                    btnQuanLyGhe.Visible = true;
                    btnQuanLySuaChua.Visible = true;
                    btnQuanLyNhanVien.Visible = true;
                    btnXemLichSu.Visible = true;
                    break;
                case "VT002": // Nhân viên kho
                    btnQuanLyThietBi.Visible = true;
                    break;
                case "VT003": // Nhân viên kỹ thuật
                    btnQuanLyPhongChieu.Visible = true;
                    btnQuanLyGhe.Visible = true;
                    break;
                case "VT004": // Nhân viên bảo trì
                    btnQuanLySuaChua.Visible = true;
                    break;
            }
        }

        private void btnQuanLyPhongChieu_Click(object sender, EventArgs e)
        {
            frmQuanLyPhongChieu form = new frmQuanLyPhongChieu();
            form.ShowDialog();
        }

        private void btnQuanLyThietBi_Click(object sender, EventArgs e)
        {
            frmQuanLyThietBi form = new frmQuanLyThietBi();
            form.ShowDialog();
        }

        private void btnQuanLyDanhMuc_Click(object sender, EventArgs e)
        {
            frmQuanLyDanhMuc form = new frmQuanLyDanhMuc();
            form.ShowDialog();
        }

        private void btnQuanLyGhe_Click(object sender, EventArgs e)
        {
            frmQuanLyGheNgoi frm = new frmQuanLyGheNgoi();  
            frm.ShowDialog();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien frm = new frmQuanLyNhanVien();
            frm.ShowDialog();
        }

        private void btnXemLichSu_Click(object sender, EventArgs e)
        {
            frmQuanLyLichSuHoatDong  frm = new frmQuanLyLichSuHoatDong();
            frm.ShowDialog();
        }

        private void btnQuanLySuaChua_Click(object sender, EventArgs e)
        {
            frmSuaChua frm = new frmSuaChua();
            frm.ShowDialog();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Global.UserInfo = null;
            frmDangNhap loginForm = new frmDangNhap();
            loginForm.Show();
            this.Close();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            frmBaoCao frm = new frmBaoCao();
            frm.ShowDialog();
        }

        
    }
}
