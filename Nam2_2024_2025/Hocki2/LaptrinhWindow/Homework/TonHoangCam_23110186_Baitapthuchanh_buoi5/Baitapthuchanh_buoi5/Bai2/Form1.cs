using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai2
{
    public partial class Form1: Form
    {
        KetNoiDuLieu ketnoi = new KetNoiDuLieu();
        bool isStarted = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void cmd_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
            ketnoi.myclose();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ketnoi.myconnect();
            string sql = "SELECT * FROM Khoa";
            cbMaKhoa.DataSource = ketnoi.taobang(sql);
            cbMaKhoa.DisplayMember = "MaKhoa";
        }

        private void cbMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(isStarted)
            {
                isStarted = false;
                cbMaKhoa.Text = "0";
            }
      

            string s = "SELECT * FROM Khoa where MaKhoa='" + cbMaKhoa.Text + "'";
            DataTable d = ketnoi.taobang(s);
            foreach (DataRow hang in d.Rows)
                txt_TenKhoa.Text = hang["TenKhoa"].ToString();




            string s1 = "SELECT MaSV,HoSV,TenSV,NgaySinh From SinhVien sv,Khoa kh where (sv.MaKhoa=kh.MaKhoa) and (kh.MaKhoa='" + cbMaKhoa.Text + "')";
            dataGridViewSV.DataSource = ketnoi.taobang(s1);

            txt_TongSV.Text = (dataGridViewSV.Rows.Count - 1).ToString();
        }
    }
}
