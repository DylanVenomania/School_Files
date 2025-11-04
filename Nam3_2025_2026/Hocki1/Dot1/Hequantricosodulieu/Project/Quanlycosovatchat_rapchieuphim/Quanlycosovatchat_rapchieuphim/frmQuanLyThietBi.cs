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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quanlycosovatchat_rapchieuphim
{
    public partial class frmQuanLyThietBi : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CinemaConn"].ConnectionString;
        private string selectedEquipmentID = null;
        public frmQuanLyThietBi()
        {
            InitializeComponent();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadThietBi();
        }

        private void frmQuanLyThietBi_Load(object sender, EventArgs e)
        {
            LoadThietBi();
            LoadDanhMuc();
            LoadPhongChieu();
            LoadTrangThai();
            LoadViTri();
            cbPhongChieuID.Enabled = false;
        }


        private void LoadThietBi(string searchKeyword = null, string status = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_TimKiemThietBi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TuKhoa", string.IsNullOrWhiteSpace(searchKeyword) ? (object)DBNull.Value : searchKeyword);
                    cmd.Parameters.AddWithValue("@TrangThai", string.IsNullOrWhiteSpace(status) ? (object)DBNull.Value : status);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvThietBi.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách thiết bị: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhMuc()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_LayDanhSachDanhMuc", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cbCategoryID.DataSource = dt;
                    cbCategoryID.DisplayMember = "TenDanhMuc";
                    cbCategoryID.ValueMember = "CategoryID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPhongChieu()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_LayDanhSachPhongChieu", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cbPhongChieuID.DataSource = dt;
                    cbPhongChieuID.DisplayMember = "TenPhong";
                    cbPhongChieuID.ValueMember = "PhongChieuID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải phòng chiếu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTrangThai()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_LayDanhSachTrangThai", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cbTrangThai.DataSource = dt;
                    cbTrangThai.DisplayMember = "DisplayValue";
                    cbTrangThai.ValueMember = "Value";
                    cbTrangThai.SelectedIndex = 0; // Mặc định chọn đầu tiên
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi tải trạng thái: {ex.Message}. Kiểm tra quyền truy cập.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadViTri()
        {
            cbViTri.Items.AddRange(new string[] { "Warehouse", "Screening Room" }); 
            cbViTri.SelectedIndex = 0;
        }

        private void cbViTri_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPhongChieuID.Enabled = (cbViTri.SelectedItem?.ToString() == "Screening Room");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenThietBi.Text) || cbCategoryID.SelectedValue == null || dtpNgayMua.Value == DateTime.MinValue)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string status = cbTrangThai.SelectedValue.ToString().Trim(); // Lấy từ SQL
            string location = cbViTri.SelectedItem.ToString().Trim();
            string phongChieuID = (location == "Screening Room") ? cbPhongChieuID.SelectedValue?.ToString() : null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_ThemThietBi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryID", cbCategoryID.SelectedValue);
                    cmd.Parameters.AddWithValue("@TenThietBi", txtTenThietBi.Text.Trim());
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@NgayMua", dtpNgayMua.Value);
                    cmd.Parameters.AddWithValue("@NhaCungCap", txtNhaCungCap.Text.Trim());
                    cmd.Parameters.AddWithValue("@Location", location);
                    cmd.Parameters.AddWithValue("@PhongChieuID", string.IsNullOrEmpty(phongChieuID) ? (object)DBNull.Value : phongChieuID);
                    cmd.Parameters.AddWithValue("@EmployeeID", Global.UserInfo.EmployeeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thiết bị thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadThietBi();
                    ClearInputs();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi thêm thiết bị: {ex.Message}. Có thể do ràng buộc hoặc quyền truy cập.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedEquipmentID))
            {
                MessageBox.Show("Vui lòng chọn thiết bị để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenThietBi.Text) || cbCategoryID.SelectedValue == null || dtpNgayMua.Value == DateTime.MinValue)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string status = cbTrangThai.SelectedValue.ToString().Trim(); // Lấy từ SQL
            string location = cbViTri.SelectedItem.ToString().Trim();
            string phongChieuID = (location == "Screening Room") ? cbPhongChieuID.SelectedValue?.ToString() : null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_SuaThietBi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EquipmentID", selectedEquipmentID);
                    cmd.Parameters.AddWithValue("@CategoryID", cbCategoryID.SelectedValue);
                    cmd.Parameters.AddWithValue("@TenThietBi", txtTenThietBi.Text.Trim());
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@NgayMua", dtpNgayMua.Value);
                    cmd.Parameters.AddWithValue("@NhaCungCap", txtNhaCungCap.Text.Trim());
                    cmd.Parameters.AddWithValue("@Location", location);
                    cmd.Parameters.AddWithValue("@PhongChieuID", string.IsNullOrEmpty(phongChieuID) ? (object)DBNull.Value : phongChieuID);
                    cmd.Parameters.AddWithValue("@EmployeeID", Global.UserInfo.EmployeeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thiết bị thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadThietBi();
                    ClearInputs();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi sửa thiết bị: {ex.Message}. Có thể do ràng buộc hoặc quyền truy cập.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedEquipmentID))
            {
                MessageBox.Show("Vui lòng chọn thiết bị để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa thiết bị này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_XoaThietBi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EquipmentID", selectedEquipmentID);
                    cmd.Parameters.AddWithValue("@EmployeeID", Global.UserInfo.EmployeeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thiết bị thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadThietBi();
                    ClearInputs();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi xóa thiết bị: {ex.Message}. Có thể thiết bị đang sử dụng hoặc quyền truy cập.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatKho_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedEquipmentID) || cbPhongChieuID.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị và phòng chiếu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_XuatKho", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EquipmentID", selectedEquipmentID);
                    cmd.Parameters.AddWithValue("@PhongChieuID", cbPhongChieuID.SelectedValue);
                    cmd.Parameters.AddWithValue("@EmployeeID", Global.UserInfo.EmployeeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xuất kho thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadThietBi();
                    ClearInputs();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi xuất kho: {ex.Message}. Có thể phòng chiếu không hợp lệ hoặc quyền truy cập.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNhapKho_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedEquipmentID))
            {
                MessageBox.Show("Vui lòng chọn thiết bị để nhập kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_NhapKho", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EquipmentID", selectedEquipmentID);
                    cmd.Parameters.AddWithValue("@EmployeeID", Global.UserInfo.EmployeeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Nhập kho thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadThietBi();
                    ClearInputs();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi nhập kho: {ex.Message}. Kiểm tra quyền truy cập.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvThietBi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvThietBi.SelectedRows.Count > 0)
            {
                selectedEquipmentID = dgvThietBi.SelectedRows[0].Cells["EquipmentID"].Value?.ToString();
                txtTenThietBi.Text = dgvThietBi.SelectedRows[0].Cells["TenThietBi"].Value?.ToString() ?? "";
                txtNhaCungCap.Text = dgvThietBi.SelectedRows[0].Cells["NhaCungCap"].Value?.ToString() ?? "";
                dtpNgayMua.Value = (dgvThietBi.SelectedRows[0].Cells["NgayMua"].Value is DBNull) ? DateTime.Now : Convert.ToDateTime(dgvThietBi.SelectedRows[0].Cells["NgayMua"].Value);
                cbCategoryID.SelectedValue = dgvThietBi.SelectedRows[0].Cells["CategoryID"].Value ?? null;
                cbTrangThai.SelectedValue = dgvThietBi.SelectedRows[0].Cells["Status"].Value?.ToString() ?? "Good";
                cbViTri.SelectedItem = dgvThietBi.SelectedRows[0].Cells["Location"].Value?.ToString() ?? "Warehouse";
                cbPhongChieuID.SelectedValue = dgvThietBi.SelectedRows[0].Cells["PhongChieuID"].Value ?? null;
            }
        }
        private void ClearInputs()
        {
            selectedEquipmentID = null;
            txtTenThietBi.Clear();
            txtNhaCungCap.Clear();
            dtpNgayMua.Value = DateTime.Now;
            cbCategoryID.SelectedIndex = -1;
            cbTrangThai.SelectedIndex = 0; // Mặc định chọn đầu tiên từ SQL
            cbViTri.SelectedIndex = 0;
            cbPhongChieuID.SelectedIndex = -1;
            cbPhongChieuID.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            string status = cbTrangThai.SelectedValue?.ToString(); // Giả sử cbTrangThai là ComboBox lọc trạng thái
            if (string.IsNullOrWhiteSpace(searchKeyword) && string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm hoặc chọn trạng thái!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadThietBi(searchKeyword, status);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }
    }

}
