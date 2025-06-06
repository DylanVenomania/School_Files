using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1
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
        public void them(string ma, string ho, string ten, DateTime ngaysinh, string phai, string makhoa)
        {
            string sql = "insert into SinhVien(MaSV,HoSV,TenSV,NgaySinh,GioiTinh,MaKhoa)" + "values('" + ma + "',N'" + ho + "',N'" + ten + "','" + ngaysinh.ToShortDateString() + "',N'" + phai + "','" + makhoa + "')";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
        }
        public void xoa(string ma, string ho, string ten, DateTime ngaysinh, string phai, string makhoa)
        {
            string sql = "delete from SinhVien where MaSV='" + ma + "'";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
        }
        public void sua(string ma, string ho, string ten, DateTime ngaysinh, string phai, string makhoa)
        {
            string sql = "update SinhVien set HoSV=N'" + ho + "',TenSV=N'" + ten + "',NgaySinh='" + ngaysinh.ToShortDateString() + "',GioiTinh=N'" + phai + "',MaKhoa='" + makhoa + "' where MaSV='" + ma + "'";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
        }
    }
}
