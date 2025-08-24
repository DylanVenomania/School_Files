using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4
{
    public class KetNoiDuLieu
    {
        public SqlConnection cnn = new SqlConnection("Data Source=.;Initial Catalog=SINHVIEN;Integrated Security=True;");
        public void myconnect()
        {
            cnn.Open();
        }

        public void myClose()
        {
            cnn.Close();
        }

        public DataTable taobang(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(sql, cnn);
            ds.Fill(dt);
            return dt;
        }

        public void them(string maKhoa, string tenKhoa)
        {
            string sql = "insert into Khoa(MaKhoa,TenKhoa)" + "values('" + maKhoa + "',N'" + tenKhoa + "')";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
        }

        public void xoa(string maKhoa)
        {
            string sql = "delete from Khoa where MaKhoa='" + maKhoa + "'";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
        }

        public void sua(string maKhoa, string tenKhoa)
        {
            string sql = "update Khoa set TenKhoa='" + tenKhoa + "' where MaKhoa='" + maKhoa + "'";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
        }
    }
}
