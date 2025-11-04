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
using OfficeOpenXml;
using System.IO;


namespace Quanlycosovatchat_rapchieuphim
{

    public partial class frmBaoCao : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CinemaConn"].ConnectionString;
        public frmBaoCao()
        {
            InitializeComponent();
            
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            LoadBaoCaoThietBi();
            LoadBaoCaoPhongChieu();
            LoadBaoCaoNhanVien();

            dtpTuNgayChiPhi.Value = DateTime.Now.AddDays(-7);
            dtpDenNgayChiPhi.Value = DateTime.Now;
        }



        private void LoadBaoCaoThietBi()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_BaoCaoThietBiTheoTrangThai", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvBaoCaoThietBi.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi tải báo cáo thiết bị: {ex.Message}. Kiểm tra quyền truy cập hoặc kết nối.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBaoCaoPhongChieu()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_BaoCaoPhongChieuTheoSucChua", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvBaoCaoPhongChieu.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi tải báo cáo phòng chiếu: {ex.Message}. Kiểm tra quyền truy cập.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBaoCaoNhanVien()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_BaoCaoNhanVienTheoVaiTro", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvBaoCaoNhanVien.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi tải báo cáo nhân viên: {ex.Message}. Kiểm tra quyền truy cập.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnTaiLaiThietBi_Click(object sender, EventArgs e)
        {
            LoadBaoCaoThietBi();
        }

        private void btnTaiLaiPhongChieu_Click(object sender, EventArgs e)
        {
            LoadBaoCaoPhongChieu();
        }

        private void btnTaiLaiNhanVien_Click(object sender, EventArgs e)
        {
            LoadBaoCaoNhanVien();
        }

        private void btnTaiVeThietBi_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvBaoCaoThietBi, "BaoCaoThietBi_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx");
        }

        private void btnTaiVePhongChieu_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvBaoCaoThietBi, "BaoCaoThietBi_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx");
        }

        private void btnTaiVeNhanVien_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvBaoCaoNhanVien, "BaoCaoNhanVien_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx");
        }

        private void ExportToExcel(DataGridView dgv, string fileName)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files|*.xlsx";
                    sfd.FileName = fileName;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        DataTable dt = new DataTable();
                        foreach (DataGridViewColumn column in dgv.Columns)
                        {
                            dt.Columns.Add(column.HeaderText);
                        }
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                DataRow dr = dt.NewRow();
                                for (int i = 0; i < dgv.Columns.Count; i++)
                                {
                                    dr[i] = row.Cells[i].Value?.ToString() ?? "";
                                }
                                dt.Rows.Add(dr);
                            }
                        }

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có dữ liệu để xuất!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        using (var package = new ExcelPackage())
                        {
                            var worksheet = package.Workbook.Worksheets.Add("BaoCao");
                            worksheet.Cells["A1"].LoadFromDataTable(dt, true);
                            worksheet.Cells.AutoFitColumns();

                            using (var memoryStream = new MemoryStream())
                            {
                                package.SaveAs(memoryStream);
                                var byteArray = memoryStream.ToArray();
                                File.WriteAllBytes(sfd.FileName, byteArray);
                            }

                            MessageBox.Show("Xuất file Excel thành công!\nĐường dẫn: " + sfd.FileName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Lỗi khi ghi file: {ex.Message}. Kiểm tra quyền truy cập, file đang mở, hoặc chạy chương trình với quyền Admin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MissingMethodException ex)
            {
                MessageBox.Show($"Lỗi phương thức không tìm thấy: {ex.Message}. Hãy kiểm tra phiên bản .NET Framework (cần 4.7.2+) hoặc dùng EPPlus 4.5.3.3.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung khi xuất file: {ex.Message}. Vui lòng cung cấp thông báo này để được hỗ trợ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void btnTinhTongChiPhi_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_TinhTongChiPhi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgayChiPhi.Value);
                    cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgayChiPhi.Value);
                    cmd.Parameters.Add("@TongChiPhi", SqlDbType.Decimal).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    decimal tongChiPhi = (decimal)cmd.Parameters["@TongChiPhi"].Value;
                    lblTongChiPhi.Text = $"Tổng chi phí sửa chữa: {tongChiPhi:C}";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL khi tính tổng chi phí: {ex.Message}. Kiểm tra quyền truy cập hoặc tham số.", "Lỗi DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
