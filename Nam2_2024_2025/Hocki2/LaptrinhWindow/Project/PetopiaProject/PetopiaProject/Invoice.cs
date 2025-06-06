using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Shop_Management_interface
{
    public partial class Invoice : Form
    {
        private string connectionString = "Data Source=.;Initial Catalog=PETSHOP;Integrated Security=True";
        CashForm CASHFORM;
        public Invoice(CashForm cashForm)
        {
            InitializeComponent();
            CASHFORM = cashForm;
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Sửa lại câu truy vấn: Thêm điều kiện JOIN chính xác
                    string query = @"
                                    SELECT 
                                        p.Name AS PetName,
                                        c.Qty AS Quantity,
                                        c.Price,
                                        cu.Name AS CustomerName,
                                        cu.Phone AS CustomerPhone,
                                        cu.Address AS CustomerAddress,
                                        u.Name AS Creator,
                                        u.Phone AS ContactInfo,
                                        u.Address AS ContactAddress,
                                        u.Email AS ContactEmail
                                    FROM CASH c
                                    JOIN PRODUCT p ON c.Pcode = p.Pcode
                                    JOIN CUSTOMER cu ON c.CustomerID = cu.ID
                                    JOIN [USER] u ON c.CashierID = u.ID
                                    WHERE c.TransNo = @TransNo
                                    ";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@TransNo", CASHFORM.lblTransno.Text.Trim());
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "INVOICE");

                    if (ds.Tables["INVOICE"].Rows.Count > 0)
                    {
                        ReportDocument report = new ReportDocument();
                        string reportPath = Path.Combine(Application.StartupPath, @"..\..\Report_Cash.rpt");
                        reportPath = Path.GetFullPath(reportPath);

                        if (!File.Exists(reportPath))
                        {
                            MessageBox.Show("Không tìm thấy file báo cáo: " + reportPath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        report.Load(reportPath);
                        report.SetDataSource(ds.Tables["INVOICE"]);
                        CRvInvoice.ReportSource = report;
                        CRvInvoice.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để hiển thị báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
