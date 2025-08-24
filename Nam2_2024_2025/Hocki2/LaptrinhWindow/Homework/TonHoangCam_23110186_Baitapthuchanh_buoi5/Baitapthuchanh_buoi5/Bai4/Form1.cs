using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4
{
    public partial class Form1: Form
    {
        KetNoiDuLieu ketnoi = new KetNoiDuLieu();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            ketnoi.myClose();
        }
        public void LoadDuLieu()
        {
            string sql = "SELECT * FROM Khoa";
            dataGridViewKhoa.DataSource = ketnoi.taobang(sql);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ketnoi.myconnect();
            LoadDuLieu();
        }

        private void dataGridViewKhoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int chiso = -1;
            DataTable bang = new DataTable();
            bang = (DataTable)dataGridViewKhoa.DataSource;
            chiso = dataGridViewKhoa.SelectedCells[0].RowIndex;
            DataRow hang = bang.Rows[chiso];

            txbMaKhoa.Text = hang["MaKhoa"].ToString();
            txbTenKhoa.Text = hang["TenKhoa"].ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txbMaKhoa.ResetText();
            txbTenKhoa.ResetText();
            txbMaKhoa.Focus();

            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.btnThem.Enabled = false;
            LoadDuLieu();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.btnThem.Enabled = true;
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;

            string s = "SELECT * FROM Khoa where MaKhoa='" + txbMaKhoa.Text + "'";
            DataTable dt = new DataTable();
            dt = ketnoi.taobang(s);
            if (dt.Rows.Count == 0)
            {
                ketnoi.them(txbMaKhoa.Text, txbTenKhoa.Text);

                txbMaKhoa.ResetText();
                txbTenKhoa.ResetText();
                txbMaKhoa.Focus();
            }
            else
            {
                MessageBox.Show("Mã khoa đã có, xin nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDuLieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string s = "SELECT * FROM Khoa where MaKhoa='" + txbMaKhoa.Text + "'";
            DataTable dt = new DataTable();
            dt = ketnoi.taobang(s);
            if (dt.Rows.Count != 0)
            {
                ketnoi.xoa(txbMaKhoa.Text);

                txbMaKhoa.ResetText();
                txbTenKhoa.ResetText();
                txbMaKhoa.Focus();
            }
            else
            {
                MessageBox.Show("Hãy chọn dữ liệu để xoá", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDuLieu();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string s = "SELECT * FROM Khoa where MaKhoa='" + txbMaKhoa.Text + "'";
            DataTable dt = new DataTable();
            dt = ketnoi.taobang(s);

            if (dt.Rows.Count != 0)
            {
                ketnoi.sua(txbMaKhoa.Text, txbTenKhoa.Text);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu để sửa", "Thông bâo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDuLieu();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txbMaKhoa.ResetText();
            txbTenKhoa.ResetText();
            txbMaKhoa.Focus();

            this.btnThem.Enabled = true;
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            LoadDuLieu();
        }

        private void txbTenKhoa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
