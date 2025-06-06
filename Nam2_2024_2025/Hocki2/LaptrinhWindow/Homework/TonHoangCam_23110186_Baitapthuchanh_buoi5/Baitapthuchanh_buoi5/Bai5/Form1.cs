using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Bai5
{
    public partial class Form1: Form
    {
        KetNoiDuLieu ketnoi = new KetNoiDuLieu();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.departmentTableAdapter.Fill(this.cONGTYDataSet.Department);
            ketnoi.myconnect();
            LoadDuLieu();
        }

        public void LoadDuLieu()
        {
            string sql = "SELECT * FROM Employee";
            dataGridViewNV.DataSource = ketnoi.taobang(sql);
        }

        private void dataGridViewNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int chiso = -1;
            DataTable bang = new DataTable();

            bang = (DataTable)dataGridViewNV.DataSource;
            chiso = dataGridViewNV.SelectedCells[0].RowIndex;
            DataRow hang = bang.Rows[chiso];

            txbMaNV.Text = hang["MaNV"].ToString();
            txbTenNV.Text = hang["HoTen"].ToString();
            txbMaPB.Text = hang["MaPB"].ToString();
            txbSoDT.Text = hang["SoDT"].ToString();
            txbNgSinh.Text = hang["NgaySinh"].ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txbMaNV.ResetText();
            txbTenNV.ResetText();
            txbMaPB.ResetText();
            txbSoDT.ResetText();
            txbNgSinh.ResetText();
            txbMaNV.Focus();

            this.btnChapNhan.Enabled = true;
            this.btnHuy.Enabled = true;
            this.btnThem.Enabled = false;

            LoadDuLieu();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string s = "SELECT * FROM Employee where MaNV='" + txbMaNV.Text + "'";
            DataTable dt = new DataTable();
            dt = ketnoi.taobang(s);

            if (dt.Rows.Count != 0)
            {
                ketnoi.sua(txbMaNV.Text, txbTenNV.Text, DateTime.Parse(txbNgSinh.Text), txbSoDT.Text, txbMaPB.Text);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadDuLieu();
        }

        private void btnChapNhan_Click(object sender, EventArgs e)
        {
            this.btnThem.Enabled = true;
            this.btnChapNhan.Enabled = false;
            this.btnHuy.Enabled = false;

            string s = "SELECT * FROM Employee where MaNV='" + txbMaNV.Text + "'";
            DataTable dt = new DataTable();
            dt = ketnoi.taobang(s);

            if (dt.Rows.Count == 0)
            {
                ketnoi.them(txbMaNV.Text, txbTenNV.Text, DateTime.Parse(txbNgSinh.Text), txbSoDT.Text, txbMaPB.Text);

                txbMaNV.ResetText();
                txbTenNV.ResetText();
                txbNgSinh.ResetText();
                txbSoDT.ResetText();
                txbMaPB.ResetText();
                txbMaNV.Focus();
            }
            else
            {
                MessageBox.Show("Mssv đã có, vui lòng nhập lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDuLieu();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txbMaNV.ResetText();
            txbTenNV.ResetText();
            txbNgSinh.ResetText();
            txbSoDT.ResetText();
            txbMaPB.ResetText();
            txbMaNV.Focus();

            this.btnThem.Enabled = true;
            this.btnChapNhan.Enabled = false;
            this.btnHuy.Enabled = false;
            LoadDuLieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string s = "SELECT * FROM Employee where MaNV='" + txbMaNV.Text + "'";
            DataTable dt = new DataTable();
            dt = ketnoi.taobang(s);


            if (dt.Rows.Count != 0)
            {
                ketnoi.xoa(txbMaNV.Text);

                txbMaNV.ResetText();
                txbTenNV.ResetText();
                txbNgSinh.ResetText();
                txbSoDT.ResetText();
                txbMaPB.ResetText();
                txbMaNV.Focus();
            }
            else
            {
                MessageBox.Show("Hãy chọn dữ liệu để xoá", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadDuLieu();
        }
    }
}
