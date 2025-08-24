using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1
{
    public partial class Form1: Form
    {
        KetNoiDuLieu ketnoi = new KetNoiDuLieu();
        public Form1()
        {
            InitializeComponent();
            ketnoi.myconnect();
            this.cmd_Luu.Enabled = false;
            this.cmd_Huy.Enabled = false;
            LoadDuLieu();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            this.sinhVienTableAdapter.Fill(this.sINHVIENDataSet.SinhVien);


        }

        private void LoadDuLieu()
        {
            string sql = "SELECT * FROM SinhVien";
            dataGridViewSV.DataSource = ketnoi.taobang(sql);
        }

        private void cmd_Them_Click(object sender, EventArgs e)
        {
            txt_MaSV.ResetText();
            txt_HoSV.ResetText();
            txt_MaKhoa.ResetText();
            txt_GioiTinh.ResetText();
            dt_NgaySinh.ResetText();
            txt_TenSV.ResetText();
            txt_MaSV.Focus();

            this.cmd_Luu.Enabled = true;
            this.cmd_Huy.Enabled = true;
            this.cmd_Them.Enabled = false;
            LoadDuLieu();
        }

        private void cmd_Luu_Click(object sender, EventArgs e)
        {
            this.cmd_Them.Enabled = true;
            this.cmd_Luu.Enabled = false;
            this.cmd_Huy.Enabled = false;

            string s = "SELECT * FROM SinhVien where MaSV='" + txt_MaSV.Text + "'";
            DataTable dt = new DataTable();
            dt = ketnoi.taobang(s);
            if (dt.Rows.Count == 0)
            {
                ketnoi.them(txt_MaSV.Text, txt_HoSV.Text, txt_TenSV.Text, dt_NgaySinh.Value, txt_GioiTinh.Text, txt_MaKhoa.Text);

                txt_GioiTinh.ResetText();
                txt_HoSV.ResetText();
                txt_MaKhoa.ResetText();
                txt_MaSV.ResetText();
                dt_NgaySinh.ResetText();
                txt_TenSV.ResetText();
                txt_MaSV.Focus();
            }
            else
            {
                MessageBox.Show("Mã số sinh viên đã có, vui lòng nhập lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDuLieu();
        }

        private void cmd_Sua_Click(object sender, EventArgs e)
        {
            string s = "SELECT * FROM SinhVien where MaSV='" + txt_MaSV.Text + "'";
            DataTable dt = new DataTable(); 
            dt = ketnoi.taobang(s);

            if (dt.Rows.Count != 0)
            {
                ketnoi.sua(txt_MaSV.Text, txt_HoSV.Text, txt_TenSV.Text, dt_NgaySinh.Value, txt_GioiTinh.Text, txt_MaKhoa.Text);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDuLieu();
        }

        private void cmd_Huy_Click(object sender, EventArgs e)
        {
            txt_GioiTinh.ResetText();
            txt_HoSV.ResetText();
            txt_MaKhoa.ResetText();
            txt_MaSV.ResetText();
            dt_NgaySinh.ResetText();
            txt_TenSV.ResetText();
            txt_MaSV.Focus();

            this.cmd_Them.Enabled = true;
            this.cmd_Luu.Enabled = false;
            this.cmd_Huy.Enabled = false;
            LoadDuLieu();
        }

        private void dataGridViewSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int chiso = -1;
            DataTable bang = new DataTable();
            bang = (DataTable)dataGridViewSV.DataSource;
            chiso = dataGridViewSV.SelectedCells[0].RowIndex;
            DataRow hang = bang.Rows[chiso];

            txt_MaSV.Text = hang["masv"].ToString();
            txt_HoSV.Text = hang["hosv"].ToString();
            txt_TenSV.Text = hang["tensv"].ToString();
            txt_MaKhoa.Text = hang["makhoa"].ToString();
            txt_GioiTinh.Text = hang["gioitinh"].ToString();
            dt_NgaySinh.Value = Convert.ToDateTime(hang["ngaysinh"].ToString());
        }

        private void cmd_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
            ketnoi.myClose();
        }

        private void cmd_Xoa_Click(object sender, EventArgs e)
        {
            string s = "SELECT * FROM SinhVien where MaSV='" + txt_MaSV.Text + "'";
            DataTable dt = new DataTable();
            dt = ketnoi.taobang(s);

            if (dt.Rows.Count != 0)
            {
                ketnoi.xoa(txt_MaSV.Text, txt_HoSV.Text, txt_TenSV.Text, dt_NgaySinh.Value, txt_GioiTinh.Text, txt_MaKhoa.Text);

                txt_GioiTinh.ResetText();
                txt_HoSV.ResetText();
                txt_MaKhoa.ResetText();
                txt_MaSV.ResetText();
                dt_NgaySinh.ResetText();
                txt_TenSV.ResetText();
                txt_MaSV.Focus();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để xoá", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDuLieu();
        }

        private void txt_MaSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
