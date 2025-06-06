using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSinhvien_Report
{
    public partial class frm_sinhvien_report : Form
    {
        private string connectionString = "Data Source=.;Initial Catalog=Winform_report_sinhvien;Integrated Security=True";

        public frm_sinhvien_report()
        {
            InitializeComponent();
        }

        private void LoadKhoaToComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "select distinct Khoa from sinhvien";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbKhoa.Items.Add(reader["Khoa"].ToString());

                        if (cmbKhoa.Items.Count > 0)
                            cmbKhoa.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            } 
                
        }

        private void frm_sinhvien_report_Load(object sender, EventArgs e)
        {
            LoadKhoaToComboBox();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string selectedKhoa = cmbKhoa.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedKhoa))
                return;

            using ( SqlConnection conn = new SqlConnection( connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from sinhvien where Khoa = @khoa", conn);
                da.SelectCommand.Parameters.AddWithValue("@khoa", selectedKhoa);

                DataSet ds = new DataSet();
                da.Fill(ds, "sinhvien");

                Report_sinhvien report = new Report_sinhvien();
                report.SetDataSource(ds.Tables["sinhvien"]);
                report.SetParameterValue("tenKhoa", selectedKhoa);

                crystalReportViewer.ReportSource = report;
                crystalReportViewer.Refresh();
            }    
        }

    }
}
