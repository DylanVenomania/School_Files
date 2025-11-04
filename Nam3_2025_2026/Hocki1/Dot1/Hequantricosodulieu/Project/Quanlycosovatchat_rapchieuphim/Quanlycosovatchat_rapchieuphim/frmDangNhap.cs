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

namespace Quanlycosovatchat_rapchieuphim
{
    public partial class frmDangNhap : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CinemaConn"].ConnectionString;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_DangNhap", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenDangNhap", txtTenDangNhap.Text);
                    cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        // Lưu thông tin người dùng
                        Global.UserInfo = new UserInfo
                        {
                            EmployeeID = reader["EmployeeID"].ToString(),
                            TenDangNhap = reader["TenDangNhap"].ToString(),
                            VaiTroID = reader["VaiTroID"].ToString(),
                            HoTen = reader["HoTen"].ToString()
                        };

                        // Mở form chính
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // Lớp lưu thông tin người dùng
        public static class Global
        {
            public static UserInfo UserInfo { get; set; }
        }

        public class UserInfo
        {
            public string EmployeeID { get; set; }
            public string TenDangNhap { get; set; }
            public string VaiTroID { get; set; }
            public string HoTen { get; set; }
        }

    }
}
