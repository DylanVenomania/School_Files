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
    public partial class frmQuanLyPhongChieu : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CinemaConn"].ConnectionString;
        private string selectedPhongChieuID = null;
        public frmQuanLyPhongChieu()
        {
            InitializeComponent();
        }
        private void LoadPhongChieu(string searchKeyword = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd;
                    if (string.IsNullOrWhiteSpace(searchKeyword))
                    {
                        cmd = new SqlCommand("sp_LayDanhSachPhongChieu", conn);
                    }
                    else
                    {
                        cmd = new SqlCommand("sp_TimKiemPhongChieu", conn);
                        cmd.Parameters.AddWithValue("@TenPhong", searchKeyword);
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvPhongChieu.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi tải danh sách phòng chiếu: {ex.Message}. Kiểm tra quyền truy cập hoặc kết nối.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchKeyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadPhongChieu(searchKeyword);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void frmQuanLyPhongChieu_Load(object sender, EventArgs e)
        {
            LoadPhongChieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenPhong.Text) || string.IsNullOrWhiteSpace(txtSucChua.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên phòng và sức chứa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSucChua.Text, out int sucChua) || sucChua <= 0)
            {
                MessageBox.Show("Sức chứa phải là số nguyên dương!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_ThemPhongChieu", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenPhong", txtTenPhong.Text);
                    cmd.Parameters.AddWithValue("@SucChua", sucChua);
                    cmd.Parameters.AddWithValue("@EmployeeID", Global.UserInfo.EmployeeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm phòng chiếu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhongChieu();
                    ClearInputs();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi thêm phòng chiếu: {ex.Message}. Có thể tên phòng đã tồn tại hoặc quyền truy cập.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedPhongChieuID))
            {
                MessageBox.Show("Vui lòng chọn phòng chiếu để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenPhong.Text) || string.IsNullOrWhiteSpace(txtSucChua.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên phòng và sức chứa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSucChua.Text, out int sucChua) || sucChua <= 0)
            {
                MessageBox.Show("Sức chứa phải là số nguyên dương!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_SuaPhongChieu", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PhongChieuID", selectedPhongChieuID);
                    cmd.Parameters.AddWithValue("@TenPhong", txtTenPhong.Text);
                    cmd.Parameters.AddWithValue("@SucChua", sucChua);
                    cmd.Parameters.AddWithValue("@EmployeeID", Global.UserInfo.EmployeeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa phòng chiếu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhongChieu();
                    ClearInputs();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi sửa phòng chiếu: {ex.Message}. Có thể tên phòng đã tồn tại hoặc quyền truy cập.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedPhongChieuID))
            {
                MessageBox.Show("Vui lòng chọn phòng chiếu để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa phòng chiếu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_XoaPhongChieu", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PhongChieuID", selectedPhongChieuID);
                    cmd.Parameters.AddWithValue("@EmployeeID", Global.UserInfo.EmployeeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa phòng chiếu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhongChieu();
                    ClearInputs();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi xóa phòng chiếu: {ex.Message}. Có thể phòng đang được sử dụng hoặc quyền truy cập.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadPhongChieu();
        }

        private void dgvPhongChieu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhongChieu.SelectedRows.Count > 0)
            {
                selectedPhongChieuID = dgvPhongChieu.SelectedRows[0].Cells["PhongChieuID"].Value?.ToString();
                txtTenPhong.Text = dgvPhongChieu.SelectedRows[0].Cells["TenPhong"].Value?.ToString() ?? "";
                txtSucChua.Text = dgvPhongChieu.SelectedRows[0].Cells["SucChua"].Value?.ToString() ?? "";
            }
        }
        private void ClearInputs()
        {
            selectedPhongChieuID = null;
            txtTenPhong.Clear();
            txtSucChua.Clear();
        }

        
    }
}
