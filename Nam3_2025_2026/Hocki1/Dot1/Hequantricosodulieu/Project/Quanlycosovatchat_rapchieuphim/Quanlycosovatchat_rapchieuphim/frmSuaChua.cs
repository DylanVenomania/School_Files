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
    public partial class frmSuaChua : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CinemaConn"].ConnectionString;
        private string selectedEquipmentID = null; 
        private string selectedGheID = null;
        private string selectedSuaChuaID = null;
        public frmSuaChua()
        {
            InitializeComponent();

            LoadThietBi();
            LoadGhe();
            LoadTrangThai();
            LoadDanhSachSuaChua();
        }

        private void LoadThietBi()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_LayDanhSachThietBiCombo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cboThietBi.DataSource = dt;
                    cboThietBi.DisplayMember = "TenThietBi";
                    cboThietBi.ValueMember = "EquipmentID";
                    cboThietBi.SelectedIndex = -1; // Đảm bảo không chọn mặc định
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi tải danh sách thiết bị (Mã lỗi: {ex.Number}): {ex.Message}", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGhe()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_LayDanhSachGheCombo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cboGhe.DataSource = dt;
                    cboGhe.DisplayMember = "TenGhe";
                    cboGhe.ValueMember = "GheID";
                    cboGhe.SelectedIndex = -1; // Đảm bảo không chọn mặc định
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi tải danh sách ghế (Mã lỗi: {ex.Number}): {ex.Message}", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new string[] { "In Progress", "Completed" });
            cboTrangThai.SelectedIndex = 0;
        }

        private void cboThietBi_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedEquipmentID = cboThietBi.SelectedValue?.ToString(); // Sử dụng EquipmentID
            selectedGheID = null;
            cboGhe.SelectedIndex = -1; // Reset ghế
            LoadDanhSachSuaChua();
        }

        private void cboGhe_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedGheID = cboGhe.SelectedValue?.ToString();
            selectedEquipmentID = null;
            cboThietBi.SelectedIndex = -1; // Reset thiết bị
            LoadDanhSachSuaChua();
        }


        private void LoadDanhSachSuaChua()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_LayDanhSachSuaChua", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EquipmentID", selectedEquipmentID ?? (object)DBNull.Value); // Sử dụng EquipmentID
                    cmd.Parameters.AddWithValue("@GheID", selectedGheID ?? (object)DBNull.Value);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvDanhSachSuaChua.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách sửa chữa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemSuaChua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedEquipmentID) && string.IsNullOrWhiteSpace(selectedGheID))
            {
                MessageBox.Show("Vui lòng chọn thiết bị hoặc ghế để sửa chữa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpNgaySuaChua.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sửa chữa không được sau ngày hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMoTa.Text) || !decimal.TryParse(txtChiPhi.Text, out decimal chiPhi) || chiPhi < 0)
            {
                MessageBox.Show("Vui lòng nhập mô tả và chi phí hợp lệ (≥ 0)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_ThemSuaChua", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EquipmentID", selectedEquipmentID ?? (object)DBNull.Value); // Sử dụng EquipmentID
                    cmd.Parameters.AddWithValue("@GheID", selectedGheID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgaySuaChua", dtpNgaySuaChua.Value);
                    cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                    cmd.Parameters.AddWithValue("@ChiPhi", chiPhi);
                    cmd.Parameters.AddWithValue("@EmployeeID", Global.UserInfo.EmployeeID); // Giả định có class Global
                    cmd.Parameters.AddWithValue("@TrangThai", cboTrangThai.SelectedItem.ToString());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm sửa chữa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachSuaChua();
                    txtMoTa.Clear();
                    txtChiPhi.Clear();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi thêm sửa chữa: {ex.Message}", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSachSuaChua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedSuaChuaID = dgvDanhSachSuaChua.Rows[e.RowIndex].Cells["SuaChuaID"].Value?.ToString();
                cboTrangThai.SelectedItem = dgvDanhSachSuaChua.Rows[e.RowIndex].Cells["TrangThai"].Value?.ToString();
            }
        }

        private void btnCapNhatTrangThai_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedSuaChuaID))
            {
                MessageBox.Show("Vui lòng chọn bản ghi sửa chữa để cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_CapNhatTrangThaiSuaChua", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SuaChuaID", selectedSuaChuaID);
                    cmd.Parameters.AddWithValue("@TrangThai", cboTrangThai.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@EmployeeID", Global.UserInfo.EmployeeID); // Giả định có class Global

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật trạng thái thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachSuaChua();
                    selectedSuaChuaID = null;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi cập nhật: {ex.Message}", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaSuaChua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedSuaChuaID))
            {
                MessageBox.Show("Vui lòng chọn bản ghi sửa chữa để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa bản ghi sửa chữa này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_XoaSuaChua", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SuaChuaID", selectedSuaChuaID);
                    cmd.Parameters.AddWithValue("@EmployeeID", Global.UserInfo.EmployeeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa bản ghi sửa chữa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachSuaChua();
                    selectedSuaChuaID = null;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi xóa bản ghi sửa chữa (Mã lỗi: {ex.Number}): {ex.Message}", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
