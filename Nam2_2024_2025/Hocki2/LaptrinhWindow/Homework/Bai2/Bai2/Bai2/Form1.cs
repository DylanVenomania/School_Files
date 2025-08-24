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
using CrystalDecisions.Shared;


namespace Bai2
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=.;Initial Catalog=SanPham;Integrated Security=True;TrustServerCertificate=True";
        private DataTable dtProducts;
        private BindingSource bsOrderDetails = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            dtgvThongTinDonHang.RowPostPaint += DtgvThongTinDonHang_RowPostPaint;
            dtgvThongTinDonHang.EditingControlShowing += DtgvThongTinDonHang_EditingControlShowing;
            dtgvThongTinDonHang.CellValueChanged += DtgvThongTinDonHang_CellValueChanged;

            btnIn.Click -= btnIn_Click;
            btnIn.Click += btnIn_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();         
            SetupDataGridView();
            ResetForm();
            CapNhatTongCong();
        }
        #region Các hàm xử lý dữ liệu và giao diện

        private void LoadProducts()
        {
            using (var conn = new SqlConnection(connectionString))
            using (var da = new SqlDataAdapter("SELECT MaSanPham, TenSanPham, DonViTinh, GiaBan FROM SanPham", conn))
            {
                dtProducts = new DataTable();
                da.Fill(dtProducts);
            }
        }

        private void SetupDataGridView()
        {
            dtgvThongTinDonHang.Columns.Clear();

            var cbo = new DataGridViewComboBoxColumn
            {
                Name = "MaSanPham",
                HeaderText = "Mã SP",
                DataPropertyName = "MaSanPham",
                DataSource = dtProducts.Copy(),
                ValueMember = "MaSanPham",
                DisplayMember = "MaSanPham",
                Width = 80
            };
            dtgvThongTinDonHang.Columns.Add(cbo);
            dtgvThongTinDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenSanPham",
                HeaderText = "Tên SP",
                ReadOnly = true,
                DataPropertyName = "TenSanPham",
                Width = 175
            });
            dtgvThongTinDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DonViTinh",
                HeaderText = "ĐVT",
                ReadOnly = true,
                DataPropertyName = "DonViTinh",
                Width = 125
            });
            dtgvThongTinDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoLuong",
                HeaderText = "Số Lượng",
                DataPropertyName = "SoLuong",
                Width = 150
            });
            dtgvThongTinDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GiaBan",
                HeaderText = "Đơn Giá",
                ReadOnly = true,
                DataPropertyName = "GiaBan",
                Width = 150
            });
            dtgvThongTinDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ThanhTien",
                HeaderText = "Thành Tiền",
                ReadOnly = true,
                DataPropertyName = "ThanhTien",
                Width = 150
            });

            dtgvThongTinDonHang.AllowUserToAddRows = true;
        }
        private void ResetForm()
        {
            txtSoHoaDon.Clear();
            dtNgayDatHang.Value = DateTime.Today;
            dtNgayGiaoHang.Value = DateTime.Today;
            txtGhiChu.Clear();
            txtTongCong.Text = "0";
            dtgvThongTinDonHang.Rows.Clear();
        }

        #endregion

        #region Xử lý sự kiện của DataGridView
        private void DtgvThongTinDonHang_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex < dtgvThongTinDonHang.Rows.Count - 1)
            {
                dtgvThongTinDonHang.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
            }
        }
        private void DtgvThongTinDonHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var row = dtgvThongTinDonHang.Rows[e.RowIndex];
            if (dtgvThongTinDonHang.Columns[e.ColumnIndex].Name == "MaSanPham")
            {
                var ma = row.Cells["MaSanPham"].Value?.ToString();
                if (!string.IsNullOrEmpty(ma))
                {
                    var prod = dtProducts.AsEnumerable()
                        .FirstOrDefault(r => r["MaSanPham"].ToString() == ma);
                    if (prod != null)
                    {
                        row.Cells["TenSanPham"].Value = prod["TenSanPham"];
                        row.Cells["DonViTinh"].Value = prod["DonViTinh"];
                        row.Cells["GiaBan"].Value = prod["GiaBan"];
                    }
                }
            }

            if (dtgvThongTinDonHang.Columns[e.ColumnIndex].Name == "SoLuong" ||dtgvThongTinDonHang.Columns[e.ColumnIndex].Name == "GiaBan")
            {
                if (decimal.TryParse(row.Cells["GiaBan"].Value?.ToString(), out decimal giaBan) &&
                    int.TryParse(row.Cells["SoLuong"].Value?.ToString(), out int soLuong))
                {
                    row.Cells["ThanhTien"].Value = giaBan * soLuong;
                }
                else
                {
                    row.Cells["ThanhTien"].Value = 0;
                }
                CapNhatTongCong();
            }
        }
        private void DtgvThongTinDonHang_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dtgvThongTinDonHang.CurrentCell.OwningColumn.Name == "MaSanPham" && e.Control is ComboBox cb)
            {
                cb.SelectedIndexChanged -= Cb_SelectedIndexChanged;
                cb.SelectedIndexChanged += Cb_SelectedIndexChanged;
            }
        }
        private void CapNhatTongCong()
        {
            decimal sum = 0;
            foreach (DataGridViewRow r in dtgvThongTinDonHang.Rows)
            {
                if (r.Cells["ThanhTien"].Value != null &&
                    decimal.TryParse(r.Cells["ThanhTien"].Value.ToString(), out decimal value))
                {
                    sum += value;
                }
            }
            txtTongCong.Text = sum.ToString("N0");
        }

        private void Cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgvThongTinDonHang.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        #endregion

        #region Hiển thị danh sách sản phẩm trong đơn hàng

        private void HienThiSanPham()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT sp.MaSanPham, sp.TenSanPham, sp.DonViTinh, ctdh.SoLuong, sp.GiaBan
                                FROM SanPham sp
                                INNER JOIN ChiTietDonHang ctdh ON sp.MaSanPham = ctdh.MaSanPham";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dt.Columns.Add("ThanhTien", typeof(decimal));
                foreach (DataRow row in dt.Rows)
                {
                    if (decimal.TryParse(row["GiaBan"].ToString(), out decimal giaBan) &&
                        int.TryParse(row["SoLuong"].ToString(), out int soLuong))
                    {
                        row["ThanhTien"] = giaBan * soLuong;
                    }
                }

                dtgvThongTinDonHang.DataSource = dt;
                if (!dtgvThongTinDonHang.Columns.Contains("STT"))
                {
                    var sttCol = new DataGridViewTextBoxColumn()
                    {
                        Name = "STT",
                        HeaderText = "STT",
                        ReadOnly = true,
                        Width = 50
                    };
                    dtgvThongTinDonHang.Columns.Insert(0, sttCol);
                }

                dtgvThongTinDonHang.Columns["MaSanPham"].HeaderText = "Mã SP";
                dtgvThongTinDonHang.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                dtgvThongTinDonHang.Columns["DonViTinh"].HeaderText = "ĐVT";
                dtgvThongTinDonHang.Columns["SoLuong"].HeaderText = "Số Lượng";
                dtgvThongTinDonHang.Columns["GiaBan"].HeaderText = "Giá Bán";
                dtgvThongTinDonHang.Columns["ThanhTien"].HeaderText = "Thành Tiền";

                if (dtgvThongTinDonHang.Columns.Count >= 7)
                {
                    dtgvThongTinDonHang.Columns[1].Width = 75;
                    dtgvThongTinDonHang.Columns[2].Width = 175;
                    dtgvThongTinDonHang.Columns[3].Width = 125;
                    dtgvThongTinDonHang.Columns[4].Width = 100;
                    dtgvThongTinDonHang.Columns[5].Width = 150;
                    dtgvThongTinDonHang.Columns[6].Width = 150;
                }
            }
        }

        #endregion
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSoHoaDon.Text, out int soHoaDon))
            {
                MessageBox.Show("Nhập đúng số hóa đơn để in!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ds = new DataSet();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var daH = new SqlDataAdapter(
                    "SELECT SoHoaDon, NgayDatHang, NgayGiaoHang, GhiChu FROM HoaDon WHERE SoHoaDon = @SoHoaDon", conn))
                {
                    daH.SelectCommand.Parameters.AddWithValue("@SoHoaDon", soHoaDon);
                    daH.Fill(ds, "Invoice");
                }
                if (ds.Tables["Invoice"].Rows.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy hóa đơn số {soHoaDon}!",
                                    "Không tìm thấy hóa đơn",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
                using (var daD = new SqlDataAdapter(
                    @"SELECT SoHoaDon, SoThuTu, MaSanPham, TenSanPham, DonViTinh, DonGia, SoLuong FROM ChiTietDonHang WHERE SoHoaDon = @SoHoaDon ORDER BY SoThuTu", conn))
                {
                    daD.SelectCommand.Parameters.AddWithValue("@SoHoaDon", soHoaDon);
                    daD.Fill(ds, "InvoiceDetail");
                }
            }

            var dtDetail = ds.Tables["InvoiceDetail"];
            if (!dtDetail.Columns.Contains("ThanhTien"))
                dtDetail.Columns.Add("ThanhTien", typeof(decimal));

            decimal tong = 0;
            foreach (DataRow r in dtDetail.Rows)
            {
                decimal dg = Convert.ToDecimal(r["DonGia"]);
                int sl = Convert.ToInt32(r["SoLuong"]);
                decimal tt = dg * sl;
                r["ThanhTien"] = tt;
                tong += tt;
            }

            ds.Tables["Invoice"].TableName = "HoaDon";
            ds.Tables["InvoiceDetail"].TableName = "ChiTietDonHang";

            var rpt = new CrystalReport1();
            var connInfo = new ConnectionInfo
            {
                ServerName = @".",                      
                IntegratedSecurity = false,
                UserID = "sa",
                Password = "123456"
            };

            foreach (CrystalDecisions.CrystalReports.Engine.Table tbl in rpt.Database.Tables)
            {
                TableLogOnInfo logOnInfo = tbl.LogOnInfo;
                logOnInfo.ConnectionInfo = connInfo;
                tbl.ApplyLogOnInfo(logOnInfo);
            }

            // Đổ dữ liệu
            rpt.Database.Tables["HoaDon"].SetDataSource(ds.Tables["HoaDon"]);
            rpt.Database.Tables["ChiTietDonHang"].SetDataSource(ds.Tables["ChiTietDonHang"]);

            var frm = new fIn();
            frm.LoadReport(rpt);
            frm.ShowDialog();
        }
        #region
        private void btnDatHang_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoHoaDon.Text))
            {
                MessageBox.Show("Vui lòng nhập số hóa đơn!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtNgayGiaoHang.Value < dtNgayDatHang.Value)
            {
                MessageBox.Show("Ngày giao hàng không thể trước ngày đặt hàng!", "Lỗi ngày tháng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool coSanPham = dtgvThongTinDonHang.Rows.Cast<DataGridViewRow>()
                .Any(r => !r.IsNewRow);
            if (!coSanPham)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một sản phẩm vào đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtSoHoaDon.Text, out int soHoaDon))
            {
                MessageBox.Show("Số hóa đơn phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmdCheck = new SqlCommand("SELECT COUNT(*) FROM HoaDon WHERE SoHoaDon = @SoHoaDon", conn))
                {
                    cmdCheck.Parameters.AddWithValue("@SoHoaDon", soHoaDon);
                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show($"Số hóa đơn {soHoaDon} đã tồn tại! Vui lòng nhập số khác.","Lỗi trùng hóa đơn",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }
                }
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string insertOrder = @"
                    INSERT INTO HoaDon (SoHoaDon, NgayDatHang, NgayGiaoHang, GhiChu)
                    VALUES (@SoHoaDon, @NgayDatHang, @NgayGiaoHang, @GhiChu)";
                        using (var cmd = new SqlCommand(insertOrder, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@SoHoaDon", soHoaDon);
                            cmd.Parameters.AddWithValue("@NgayDatHang", dtNgayDatHang.Value);
                            cmd.Parameters.AddWithValue("@NgayGiaoHang", dtNgayGiaoHang.Value);
                            cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                            cmd.ExecuteNonQuery();
                        }
                        int soThuTu = 1;
                        foreach (DataGridViewRow row in dtgvThongTinDonHang.Rows)
                        {
                            if (row.IsNewRow || row.Cells["MaSanPham"].Value == null) continue;

                            string insertDetail = @"
                        INSERT INTO ChiTietDonHang
                          (SoHoaDon, SoThuTu, MaSanPham, TenSanPham, DonViTinh, DonGia, SoLuong)
                        VALUES
                          (@SoHoaDon, @SoThuTu, @MaSP, @TenSP, @DVT, @DonGia, @SoLuong)";
                            using (var cmd = new SqlCommand(insertDetail, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@SoHoaDon", soHoaDon);
                                cmd.Parameters.AddWithValue("@SoThuTu", soThuTu++);
                                cmd.Parameters.AddWithValue("@MaSP", row.Cells["MaSanPham"].Value);
                                cmd.Parameters.AddWithValue("@TenSP", row.Cells["TenSanPham"].Value ?? "");
                                cmd.Parameters.AddWithValue("@DVT", row.Cells["DonViTinh"].Value ?? "");
                                cmd.Parameters.AddWithValue("@DonGia", Convert.ToDecimal(row.Cells["GiaBan"].Value));
                                cmd.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(row.Cells["SoLuong"].Value));
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Đặt hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Có lỗi xảy ra khi đặt hàng: {ex.Message}","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
        }
            #endregion
    }
}
