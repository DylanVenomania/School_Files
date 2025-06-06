using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlynhanvien_LinQ
{
    public partial class frm_quanlynhanvien : Form
    {
        QLNhanVienDataContext database = new QLNhanVienDataContext();


        private void load()
        {
            dg_thongtinchung.DataSource = database.NhanViens.ToList();
        }
        public frm_quanlynhanvien()
        {
            InitializeComponent();
            load();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {

            //Đang trong chế độ thêm mới


            NhanVien nv = new NhanVien()
            {
                Hoten = txt_hoten.Text,
                Ngaysinh = dtp_date.Value,
                Diachi = txt_diachi.Text,
                Dienthoai = txt_dienthoai.Text,
                Bangcap = combobox_bangcap.Text
            };

            database.NhanViens.InsertOnSubmit(nv);
            database.SubmitChanges();

            load();
            MessageBox.Show("Them nhan vien thanh cong !");
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dg_thongtinchung.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui long chon 1 nhan vien de xoa!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
            if ( dg_thongtinchung.SelectedRows.Count > 0 )
            {
                foreach ( DataGridViewRow row in dg_thongtinchung.SelectedRows)
                {
                    int maNV = Convert.ToInt32(row.Cells[0].Value);
                    var nv = database.NhanViens.SingleOrDefault(n => n.MaNV == maNV);

                    if (nv != null)
                    {
                        database.NhanViens.DeleteOnSubmit(nv);
                    }    
                }
                database.SubmitChanges();
                load();
                MessageBox.Show("Xoa nhan vien thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }    
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {


            if (dg_thongtinchung.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui long chon 1 nhan vien de sua!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ( dg_thongtinchung.SelectedRows.Count > 0 )
            {
                int maNV = Convert.ToInt32(dg_thongtinchung.SelectedRows[0].Cells[0].Value);
                var nv = database.NhanViens.SingleOrDefault(n => n.MaNV == maNV);

                if (nv != null )
                {
                    nv.Hoten = txt_hoten.Text;
                    nv.Ngaysinh = dtp_date.Value;
                    nv.Diachi = txt_diachi.Text;
                    nv.Dienthoai = txt_dienthoai.Text;
                    nv.Bangcap = combobox_bangcap.Text;


                    database.SubmitChanges();
                    load();
                    MessageBox.Show("Sua nhan vien thanh cong!");
                }    
            }    
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog savefile = new SaveFileDialog())
            {
                savefile.Filter = "CSV files (*.csv)|*.csv";
                savefile.FileName = "QLNhanVien.csv";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(savefile.FileName, false, Encoding.UTF8))
                    {
                        sw.WriteLine("MaNV,Hoten,Diachi,Dienthoai"); // Header

                        foreach (DataGridViewRow row in dg_thongtinchung.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                sw.WriteLine($"{row.Cells["MaNV"].Value},{row.Cells["Hoten"].Value},{row.Cells["Diachi"].Value},{row.Cells["Dienthoai"].Value}");
                            }
                        }
                    }
                    MessageBox.Show("Luu thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_hoten.Clear();
            txt_diachi.Clear();
            txt_dienthoai.Clear();
           
        }
    }
}
