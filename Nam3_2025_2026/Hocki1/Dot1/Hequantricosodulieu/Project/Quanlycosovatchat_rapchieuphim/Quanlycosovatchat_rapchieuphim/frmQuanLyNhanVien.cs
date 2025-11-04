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
 
    public partial class frmQuanLyNhanVien : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CinemaConn"].ConnectionString;
        private string selectedEmployeeID = null;
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadVaiTro();
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void LoadNhanVien()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_LayDanhSachNhanVien", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvNhanVien.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi tải danh sách nhân viên: {ex.Message}. Kiểm tra quyền truy cập hoặc kết nối.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadVaiTro()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_LayDanhSachVaiTro", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cboVaiTro.DataSource = dt;
                    cboVaiTro.DisplayMember = "TenVaiTro";
                    cboVaiTro.ValueMember = "VaiTroID";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi tải vai trò: {ex.Message}. Kiểm tra quyền truy cập.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text) || cboVaiTro.SelectedValue == null || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_ThemNhanVien", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenDangNhap", txtTenDangNhap.Text.Trim());
                    cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text.Trim());
                    cmd.Parameters.AddWithValue("@VaiTroID", cboVaiTro.SelectedValue);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNhanVien();
                    ClearInputs();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi thêm nhân viên: {ex.Message}. Tên đăng nhập có thể đã tồn tại hoặc quyền truy cập.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedEmployeeID))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_XoaNhanVien", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeID", selectedEmployeeID);
                    cmd.Parameters.AddWithValue("@EmployeeIDCurrent", Global.UserInfo.EmployeeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNhanVien();
                    ClearInputs();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi xóa nhân viên: {ex.Message}. Có thể nhân viên có lịch sử hoặc quyền truy cập.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedEmployeeID))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text) || cboVaiTro.SelectedValue == null || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_SuaNhanVien", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeID", selectedEmployeeID);
                    cmd.Parameters.AddWithValue("@TenDangNhap", txtTenDangNhap.Text.Trim());
                    cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text.Trim());
                    cmd.Parameters.AddWithValue("@VaiTroID", cboVaiTro.SelectedValue);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                    cmd.Parameters.AddWithValue("@EmployeeIDCurrent", Global.UserInfo.EmployeeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNhanVien();
                    ClearInputs();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi sửa nhân viên: {ex.Message}. Tên đăng nhập có thể đã tồn tại hoặc quyền truy cập.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadNhanVien();
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                selectedEmployeeID = dgvNhanVien.SelectedRows[0].Cells["EmployeeID"].Value?.ToString();
                txtTenDangNhap.Text = dgvNhanVien.SelectedRows[0].Cells["TenDangNhap"].Value?.ToString() ?? "";
                txtHoTen.Text = dgvNhanVien.SelectedRows[0].Cells["HoTen"].Value?.ToString() ?? "";
                cboVaiTro.SelectedValue = dgvNhanVien.SelectedRows[0].Cells["TenVaiTro"].Value?.ToString() ?? "VT001"; // Mặc định Admin
                txtMatKhau.Text = ""; // Không hiển thị mật khẩu cũ
            }
        }

        private void ClearInputs()
        {
            selectedEmployeeID = null;
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtHoTen.Clear();
            cboVaiTro.SelectedIndex = 0;
        }
    }
}
