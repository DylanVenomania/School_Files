using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai3
{
    public partial class frm_nhanvien : Form
    {
        public frm_nhanvien()
        {
            InitializeComponent();
            
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_manhanvien.Text) || string.IsNullOrWhiteSpace(txt_hoten.Text) ||
              string.IsNullOrWhiteSpace(txt_cmnd.Text) || string.IsNullOrWhiteSpace(txt_sdt.Text) || string.IsNullOrWhiteSpace(txt_diachi.Text))
            {
                MessageBox.Show("Vui lòng nhập ô có *!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string maNV = txt_manhanvien.Text;
                string hoTen = txt_hoten.Text;
                string ngaySinh = date_ngaysinh.Value.ToString("dd/MM/yyyy");
                string gioiTinh = btn_nam.Checked ? "Nam" : "Nữ";
                string cmnd = txt_cmnd.Text;
                string sdt = txt_sdt.Text;
                string diaChi = txt_diachi.Text;
                string honNhan = btn_co.Checked ? "Có" : "Không";

                string queQuan;
                if ( string.IsNullOrEmpty(txt_quequan.Text) )
                {
                    queQuan = "Không có";
                }
                else
                    queQuan = txt_quequan.Text;
                

                string email;
                if (string.IsNullOrEmpty(txt_email.Text))
                {
                    email = "Không có";
                }
                else
                    email = txt_email.Text;


                grid_thongtinnhanvien.Rows.Add(maNV, hoTen, ngaySinh, gioiTinh, cmnd, sdt, diaChi, queQuan, honNhan, email, "");

            }
            Clearfields();
        }

        private void Clearfields()
        {
            txt_manhanvien.Clear();
            txt_hoten.Clear();
            txt_cmnd.Clear();
            txt_sdt.Clear();
            txt_diachi.Clear();
            txt_quequan.Clear();
            txt_email.Clear();
            btn_nam.Checked = true;
            btn_co.Checked = false;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (grid_thongtinnhanvien.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in grid_thongtinnhanvien.SelectedRows)
                {
                    grid_thongtinnhanvien.Rows.Remove(row);
                }
            }
            else
                MessageBox.Show("Vui lòng chọn 1 hàng để xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btn_xem_Click(object sender, EventArgs e)
        {
            if (grid_thongtinnhanvien.SelectedRows.Count > 0)
            {
                DataGridViewRow row = grid_thongtinnhanvien.SelectedRows[0];

                string maNV = row.Cells[0].Value.ToString();
                string hoTen = row.Cells[1].Value.ToString();
                string ngaySinh = row.Cells[2].Value.ToString();
                string gioiTinh = row.Cells[3].Value.ToString();
                string cmnd = row.Cells[4].Value.ToString();
                string sdt = row.Cells[5].Value.ToString();
                string diaChi = row.Cells[6].Value.ToString();
                string queQuan = row.Cells[7].Value.ToString();
                string honNhan = row.Cells[8].Value.ToString();
                string email = row.Cells[9].Value.ToString();

                MessageBox.Show($"Mã NV: {maNV}\nHọ tên: {hoTen}\nNgày sinh: {ngaySinh}\nGiới tính: {gioiTinh}\n" +
                        $"CMND: {cmnd}\nSĐT: {sdt}\nĐịa chỉ: {diaChi}\nQuê quán: {queQuan}\nHôn nhân: {honNhan}\nEmail: {email}",
                        "Thông tin Nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Vui lòng chọn 1 hàng để xem ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog savefile = new SaveFileDialog())
            {
                savefile.Filter = "CSV files (*.csv)|*.csv";
                savefile.FileName = "nhanvien.csv";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(savefile.FileName, false, Encoding.UTF8))
                    {

                        string header = "Mã nhân viên,Họ Tên,Ngày Sinh,Giới Tính,CMND,SĐT,Địa Chỉ,Quê Quán,Hôn Nhân,Email";
                        sw.WriteLine(header);

                        foreach (DataGridViewRow row in grid_thongtinnhanvien.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                List<string> cells = new List<string>();
                                for (int i = 0; i < row.Cells.Count - 1; i++)
                                {
                                    cells.Add(row.Cells[i].Value?.ToString() ?? "");
                                }
                                sw.WriteLine(string.Join(",", cells));
                            }
                        }
                    }

                    MessageBox.Show("Dữ liệu đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
