using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai2
{
    public class KetNoiDuLieu
    {
        public SqlConnection cnn = new SqlConnection("Data Source=.;Initial Catalog=SINHVIEN;Integrated Security=True;");
        public void myconnect()
        {
            cnn.Open();
        }
        public void myclose()
        {
            cnn.Close();
        }
        public DataTable taobang(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(sql, cnn);
            ds.Fill(dt);
            return (dt);
        }
    }
}
