using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai5
{
    public class KetNoiDuLieu
    {
        public SqlConnection cnn = new SqlConnection("Data Source=.;Initial Catalog=CONGTY;Integrated Security=True;");
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
        public void them(string ma, string hoten, DateTime ngaysinh, string sdt, string maPB)
        {

            string sql = "insert into Employee(MaNV,HoTen,NgaySinh,SoDT,MaPB)" + "values('" + ma + "',N'" + hoten + "',N'" + ngaysinh.ToShortDateString() + "',N'" + sdt + "','" + maPB + "')";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
        }
        public void xoa(string ma)
        {
            string sql = "delete from Employee where MaNV='" + ma + "'";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
        }
        public void sua(string ma, string hoten, DateTime ngaysinh, string sdt, string maPB)
        {

            string sql = "update Employee set HoTen=N'" + hoten + "'," + " NgaySinh='" + ngaysinh.ToShortDateString() + "',SoDT=N'" + sdt + "',MaPB='" + maPB + "' where MaNV='" + ma + "'";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();

        }
    }
}
