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
    public partial class frmQuanLyGheNgoi : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CinemaConn"].ConnectionString;
        private string selectedPhongChieuID = null;
        private string selectedGheID = null;
        
        public frmQuanLyGheNgoi()
        {
            InitializeComponent();
            panelMaTranGhe.AutoScroll = true;
        }

        private void frmQuanLyGheNgoi_Load(object sender, EventArgs e)
        {
            LoadPhongChieu();
            LoadStatusGhe();
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
                    cboPhongChieu.DataSource = dt;
                    cboPhongChieu.DisplayMember = "TenPhong";
                    cboPhongChieu.ValueMember = "PhongChieuID";
                    LoadMaTranGhe();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải phòng chiếu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatusGhe()
        {
            cboStatusGhe.Items.AddRange(new string[] { "Good", "Broken", "Repairing" });
            cboStatusGhe.SelectedIndex = 0;
            cboStatusThem.Items.AddRange(new string[] { "Good", "Broken", "Repairing" });
            cboStatusThem.SelectedIndex = 0;
        }

        private void cboPhongChieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPhongChieuID = cboPhongChieu.SelectedValue.ToString();
            LoadMaTranGhe();
        }

        private void LoadMaTranGhe()
        {
            panelMaTranGhe.Controls.Clear(); // Xóa ma trận cũ

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_LayMaTranGheTheoPhong", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PhongChieuID", selectedPhongChieuID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    int buttonSize = 50; // Kích thước nút ghế
                    int padding = 5; // Khoảng cách giữa nút

                    foreach (DataRow row in dt.Rows)
                    {
                        Button btnGhe = new Button();
                        btnGhe.Text = row["Hang"].ToString() + row["Cot"].ToString();
                        btnGhe.Tag = row["GheID"].ToString(); // Lưu GheID
                        btnGhe.Size = new Size(buttonSize, buttonSize);
                        btnGhe.Location = new Point((Convert.ToInt32(row["Cot"]) - 1) * (buttonSize + padding), (row["Hang"].ToString()[0] - 'A') * (buttonSize + padding));
                        btnGhe.Click += BtnGhe_Click; // Sự kiện khi nhấn ghế

                        // Màu theo status
                        string status = row["Status"].ToString();
                        if (status == "Good") btnGhe.BackColor = Color.Green;
                        else if (status == "Broken") btnGhe.BackColor = Color.Red;
                        else if (status == "Repairing") btnGhe.BackColor = Color.Yellow;

                        panelMaTranGhe.Controls.Add(btnGhe);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải ma trận ghế: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGhe_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            selectedGheID = btn.Tag.ToString();
            MessageBox.Show("Đã chọn ghế: " + btn.Text + ". Bạn có thể sửa status."); // Có thể mở form chi tiết
            // Hiển thị cboStatusGhe để sửa
        }

        private void btnLuuStatus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedGheID))
            {
                MessageBox.Show("Vui lòng chọn ghế để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_SuaGhe", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GheID", selectedGheID);
                    cmd.Parameters.AddWithValue("@Status", cboStatusGhe.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@EmployeeID", Global.UserInfo.EmployeeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa status ghế thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMaTranGhe(); // Reload ma trận để cập nhật màu
                    selectedGheID = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi sửa ghế: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaGhe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedGheID))
            {
                MessageBox.Show("Vui lòng chọn ghế để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);  // ← Sửa: "xóa"
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa ghế này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_XoaGhe", conn);  // ← Sửa: Gọi sp_XoaGhe
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GheID", selectedGheID);
                    cmd.Parameters.AddWithValue("@EmployeeID", Global.UserInfo.EmployeeID);  // ← Loại bỏ @Status

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa ghế thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);  // ← Sửa thông báo
                    LoadMaTranGhe();  // Reload ma trận ghế
                    selectedGheID = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadMaTranGhe();
        }

        private void btnThemGhe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedPhongChieuID))
            {
                MessageBox.Show("Vui lòng chọn phòng chiếu trước khi thêm ghế!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHang.Text) || string.IsNullOrWhiteSpace(txtCot.Text) || cboStatusThem.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin ghế (Hàng, Cột, Trạng thái)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            char hang = txtHang.Text.Trim().ToUpper()[0];
            if (hang < 'A' || hang > 'Z')
            {
                MessageBox.Show("Hàng ghế phải từ A đến Z!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtCot.Text.Trim(), out int cot) || cot <= 0)
            {
                MessageBox.Show("Cột ghế phải là số nguyên lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string status = cboStatusThem.SelectedItem.ToString();
            if (status != "Good" && status != "Broken" && status != "Repairing")
            {
                MessageBox.Show("Trạng thái không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_ThemGhe", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PhongChieuID", selectedPhongChieuID);
                    cmd.Parameters.AddWithValue("@Hang", hang.ToString());
                    cmd.Parameters.AddWithValue("@Cot", cot);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@NgayLapDat", DateTime.Now);
                    cmd.Parameters.AddWithValue("@EmployeeID", Global.UserInfo.EmployeeID); // Giả định có class Global.UserInfo

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm ghế thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMaTranGhe(); // Cập nhật ma trận ghế
                    txtHang.Clear();
                    txtCot.Clear();
                    cboStatusThem.SelectedIndex = 0; // Reset về Good
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi thêm ghế: {ex.Message}. Kiểm tra dữ liệu hoặc quyền truy cập.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
