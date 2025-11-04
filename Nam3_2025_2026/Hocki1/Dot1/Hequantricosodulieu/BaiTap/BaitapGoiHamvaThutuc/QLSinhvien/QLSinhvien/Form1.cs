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


namespace QLSinhvien
{
    public partial class Form1 : Form
    {
        string connect = @"Data Source=.;Initial Catalog=StudentUniversityManager;Integrated Security=True";
        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable StudentTable;
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(connect);
            StudentTable = new DataTable();
        }

        private void ketnoi_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    MessageBox.Show("Kết nối thành công");
                    LoadStudentTable();
                }
                else
                {
                    MessageBox.Show("Kết nối đã có sẵn!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại!" + ex.Message);
            }

        }

        private void LoadStudentTable()
        {
            try
            {
                string sql = "SELECT * FROM StudentList";
                adapter = new SqlDataAdapter(sql, conn);
                StudentTable.Clear();
                adapter.Fill(StudentTable);
                dgv_sinhvien.DataSource = StudentTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu!" + ex.Message);
            }
        }
        private void add_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txt_id.Text.Trim();
                string name = txt_name.Text;
                int age = int.Parse(txt_age.Text);
                decimal gpa = decimal.Parse(txt_gpa.Text);

                command = new SqlCommand("sp_AddStudent", conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@gpa", gpa);

                //Mở kết nối nếu chưa mở
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                command.ExecuteNonQuery();
                MessageBox.Show("Thêm sinh viên thành công!");

                LoadStudentTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sinh viên!" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void getgpa_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txt_id.Text.Trim();

                command = new SqlCommand("SELECT dbo.fn_GetGPA(@id)", conn);
                command.Parameters.AddWithValue("@id", id);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    decimal gpa = Convert.ToDecimal(result);
                    MessageBox.Show($"GPA của sinh viên có ID {id} là: {gpa}");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên với ID đã cho.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy GPA!" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txt_id.Text.Trim();
                string name = txt_name.Text;
                int age = int.Parse(txt_age.Text);
                decimal gpa = decimal.Parse(txt_gpa.Text);

                string sql = "UPDATE StudentList SET Fullname = @name, Age = @age, GPA = @gpa WHERE StudentID = @id";

                command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@gpa", gpa);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Cập nhật sinh viên thành công!");
                    LoadStudentTable();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên với ID đã cho.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sinh viên!" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void showAddLog_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT LogID, Eventname, LogDate FROM AddStudentLog ORDER BY LogID DESC";
                adapter = new SqlDataAdapter(sql, conn);
                DataTable studentlog = new DataTable();
                adapter.Fill(studentlog);

                dgv_AddLog.DataSource = studentlog;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị log thêm sinh viên!" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void showUpdateLog_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT LogID, Eventname, LogDate FROM UpdateStudentLog ORDER BY Logid DESC";
                adapter = new SqlDataAdapter(sql, conn);
                DataTable updatelog = new DataTable();
                adapter.Fill(updatelog);

                dgv_UpdateLog.DataSource = updatelog;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị log cập nhật sinh viên!" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

    }
}
