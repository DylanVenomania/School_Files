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

namespace BT_QLPhongBan
{
    public partial class frm_qlphongban : Form
    {
        string connection = Properties.Settings.Default.ConnectionString;

        public frm_qlphongban()
        {
            InitializeComponent();
        }

        private void loaddata()
        {
            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();

                string query = "select * from Phongban";

                SqlDataAdapter adap = new SqlDataAdapter(query, connect);
                DataTable dt = new DataTable();

                adap.Fill(dt);
                grid_phongban.DataSource = dt;
            }
        }

        private void frm_qlphongban_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void grid_phongban_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grid_phongban.Rows[e.RowIndex];

                txt_maphongban.Text = row.Cells["Maphongban"].Value.ToString();
                txt_tenphongban.Text = row.Cells["Tenphongban"].Value.ToString();
                txt_mota.Text = row.Cells["Mota"].Value.ToString();

            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();

                string checkquery = "select count (*) from Phongban where Maphongban=@Maphongban";
                SqlCommand checkcmd = new SqlCommand(checkquery, connect);
                checkcmd.Parameters.AddWithValue("@Maphongban", txt_maphongban.Text);

                int count = (int)checkcmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Đã tồn tại mã phòng ban, vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }    


                string query = "insert into Phongban(Maphongban, Tenphongban, Mota) values (@Maphongban, @Tenphongban, @Mota )";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@Maphongban", txt_maphongban.Text);
                    cmd.Parameters.AddWithValue("@Tenphongban", txt_tenphongban.Text);
                    cmd.Parameters.AddWithValue("@Mota", txt_mota.Text);

                    cmd.ExecuteNonQuery();
                }    
            }
            MessageBox.Show("Thêm vào thành công!");
            loaddata();
                
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_maphongban.Text))
            {
                MessageBox.Show("Vui lòng nhập mã phòng ban muốn sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
            
                string query = "update Phongban set Tenphongban=@Tenphongban, Mota=@Mota where Maphongban=@Maphongban";

                using (SqlCommand cmd = new SqlCommand(query, connect)) 
                {
                    cmd.Parameters.AddWithValue("@Maphongban", txt_maphongban.Text);
                    cmd.Parameters.AddWithValue("@Tenphongban", txt_tenphongban.Text);
                    cmd.Parameters.AddWithValue("@Mota", txt_mota.Text);


                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loaddata(); 
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phòng cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }

                MessageBox.Show("Sửa thành công!");
                loaddata();
                    
            }    
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                string query = "delete from Phongban where Maphongban=@Maphongban";

                using (SqlCommand cmd = new SqlCommand(query, connect ))
                {
                    cmd.Parameters.AddWithValue("@Maphongban", txt_maphongban.Text);
                    cmd.ExecuteNonQuery();
                }    
            }
            MessageBox.Show("Xoá thành công!");
            loaddata();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();

                string query = "select * from Phongban where Maphongban like @search or Tenphongban like @search";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + txt_timkiem.Text + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter( cmd );
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    grid_phongban.DataSource = data;
                }    
            } 
            
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
