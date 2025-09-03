using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
namespace BTKetnoiDatabase
{
    public partial class Form1 : Form
    {
        string connect = "Data Source=.;Initial Catalog=StudentUniversityManager;Integrated Security=True;TrustServerCertificate=True;";
        SqlConnection conn;
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable StudentTable = new DataTable();
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(connect);
        }

        private void ketnoi_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    MessageBox.Show("Kết nối thành công");
                }
                else
                {
                    conn.Close();
                    MessageBox.Show("Kết nối đã đóng");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở kết nối : " + ex.Message);
            }
        }

        private void dongketnoi_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    MessageBox.Show("Đóng kết nối thành công");
                }
                else
                {
                    MessageBox.Show("Kết nối đã đóng");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Lỗi đóng kết nối : " + ex.Message);
            }
        }
    }
}
