using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    public class KetNoiDuLieu
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=SINHVIEN;Integrated Security=True;");

        public void myconnect()
        {
            conn.Open();
        }

        public void myClose()
        {
            conn.Close();
        }
        public DataTable taobang(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(sql, conn);
            ds.Fill(dt);
            return (dt);
        }
    }
}
