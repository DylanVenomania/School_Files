using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace QLDonhang_Report
{
    public partial class frmQLdonhang : Form
    {
        private SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Winform_report_donhang;Integrated Security=True");
        private DataTable dt = new DataTable();

        public frmQLdonhang()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadProduct();
        }

        private void SetupDataGridView()
        {
            // Định nghĩa cấu trúc DataTable
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Masanpham", typeof(string));
            dt.Columns.Add("Tensanpham", typeof(string));
            dt.Columns.Add("Donvitinh", typeof(string));
            dt.Columns.Add("Soluong", typeof(int));
            dt.Columns.Add("Dongia", typeof(int));
            dt.Columns.Add("Thanhtien", typeof(int));

            dgvDonhang.AutoGenerateColumns = false;

            // Bind DataTable vào DataGridView
            dgvDonhang.DataSource = dt;
        }

        private void LoadProduct()
        {
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select Masanpham, Tensanpham from Product", conn);
                DataTable dtProducts = new DataTable();
                da.Fill(dtProducts);

                // Thiết lập nguồn dữ liệu cho cột ComboBox Masanpham
                DataGridViewComboBoxColumn productColumn = (DataGridViewComboBoxColumn)dgvDonhang.Columns["Masanpham"];
                productColumn.DataSource = dtProducts;
                productColumn.DisplayMember = "Masanpham";
                productColumn.ValueMember = "Masanpham";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách sản phẩm: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void dgvDonhang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDonhang.Rows[e.RowIndex];

                // Cập nhật STT
                row.Cells["STT"].Value = e.RowIndex + 1;

                // Khi Masanpham thay đổi, lấy thông tin sản phẩm
                if (e.ColumnIndex == dgvDonhang.Columns["Masanpham"].Index)
                {
                    string masanpham = row.Cells["Masanpham"].Value?.ToString();
                    if (!string.IsNullOrEmpty(masanpham))
                    {
                        try
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("select Tensanpham, Donvitinh, Giaban from Product where Masanpham = @Masanpham", conn);
                            cmd.Parameters.AddWithValue("@Masanpham", masanpham);
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                row.Cells["Tensanpham"].Value = reader["Tensanpham"].ToString();
                                row.Cells["Donvitinh"].Value = reader["Donvitinh"].ToString();
                                row.Cells["Dongia"].Value = Convert.ToInt32(reader["Giaban"]);
                            }
                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi lấy thông tin sản phẩm: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }

                // Tính thành tiền khi số lượng thay đổi
                if (e.ColumnIndex == dgvDonhang.Columns["Soluong"].Index || e.ColumnIndex == dgvDonhang.Columns["Dongia"].Index)
                {
                    int soluong = 0;
                    int dongia = 0;

                    if (row.Cells["Soluong"].Value != null && int.TryParse(row.Cells["Soluong"].Value.ToString(), out int sl))
                    {
                        soluong = sl;
                    }
                    if (row.Cells["Dongia"].Value != null && int.TryParse(row.Cells["Dongia"].Value.ToString(), out int dg))
                    {
                        dongia = dg;
                    }

                    row.Cells["Thanhtien"].Value = soluong * dongia;

                    // Cập nhật tổng cộng
                    Tinhtong();
                }
            }
        }

        private void Tinhtong()
        {
            int total = 0;
            foreach (DataGridViewRow row in dgvDonhang.Rows)
            {
                if (row.Cells["Thanhtien"].Value != null)
                {
                    total += Convert.ToInt32(row.Cells["Thanhtien"].Value);
                }
            }
            txtTotal.Text = total.ToString("N0");
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(txtHoadon.Text) || dtpNgaydat.Value == null || dtpNgaygiao.Value == null || dgvDonhang.Rows.Count <= 1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hóa đơn, ngày đặt hàng, ngày giao hàng và ít nhất một sản phẩm.");
                return;
            }

            try
            {
                conn.Open();

                // Kiểm tra xem Sohoadon đã tồn tại chưa
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Invoice WHERE Sohoadon = @Sohoadon", conn);
                checkCmd.Parameters.AddWithValue("@Sohoadon", txtHoadon.Text);
                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Số hóa đơn đã tồn tại. Vui lòng nhập số hóa đơn khác.");
                    return;
                }

                // Thêm vào bảng Invoice
                SqlCommand cmdInvoice = new SqlCommand("insert into Invoice (Sohoadon, Ngaydathang, Ngaygiaohang, Ghichu) values (@Sohoadon, @Ngaydathang, @Ngaygiaohang, @Ghichu)", conn);
                cmdInvoice.Parameters.AddWithValue("@Sohoadon", txtHoadon.Text);
                cmdInvoice.Parameters.AddWithValue("@Ngaydathang", dtpNgaydat.Value);
                cmdInvoice.Parameters.AddWithValue("@Ngaygiaohang", dtpNgaygiao.Value);
                cmdInvoice.Parameters.AddWithValue("@Ghichu", txtGhichu.Text);
                cmdInvoice.ExecuteNonQuery();

                // Thêm vào bảng Order
                int stt = 1;
                foreach (DataGridViewRow row in dgvDonhang.Rows)
                {
                    if (row.IsNewRow) continue;

                    SqlCommand cmdOrder = new SqlCommand("INSERT INTO [Order] (Sohoadon, Stt, Masanpham, Tensanpham, Donvitinh, Dongia, Soluong) VALUES (@Sohoadon, @Stt, @Masanpham, @Tensanpham, @Donvitinh, @Dongia, @Soluong)", conn);
                    cmdOrder.Parameters.AddWithValue("@Sohoadon", txtHoadon.Text);
                    cmdOrder.Parameters.AddWithValue("@Stt", stt);
                    cmdOrder.Parameters.AddWithValue("@Masanpham", row.Cells["Masanpham"].Value);
                    cmdOrder.Parameters.AddWithValue("@Tensanpham", row.Cells["Tensanpham"].Value);
                    cmdOrder.Parameters.AddWithValue("@Donvitinh", row.Cells["Donvitinh"].Value);
                    cmdOrder.Parameters.AddWithValue("@Dongia", row.Cells["Dongia"].Value);
                    cmdOrder.Parameters.AddWithValue("@Soluong", row.Cells["Soluong"].Value);
                    cmdOrder.ExecuteNonQuery();
                    stt++;
                }

                MessageBox.Show("Đặt hàng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt hàng: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(txtHoadon.Text))
            {
                MessageBox.Show("Vui lòng nhập số hóa đơn trước khi in.");
                return;
            }

            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT o.*, i.Ngaydathang FROM [Order] o JOIN Invoice i ON o.Sohoadon = i.Sohoadon WHERE o.Sohoadon = @Sohoadon", conn);
                da.SelectCommand.Parameters.AddWithValue("@Sohoadon", txtHoadon.Text);
                DataTable dtReport = new DataTable();
                da.Fill(dtReport);

                if (dtReport.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng với số hóa đơn này.");
                    return;
                }

                // Tải Crystal Report
                ReportDocument report = new ReportDocument();
                report.Load("Report_donhang.rpt"); // Đảm bảo file nằm trong thư mục dự án
                report.SetDataSource(dtReport);

                // Hiển thị báo cáo trong CrystalReportViewer
                ReportForm viewerForm = new ReportForm();
                viewerForm.CrystalReportViewer.ReportSource = report; // Sử dụng thuộc tính public
                viewerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}