using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace QLVatTu
{
    public partial class frm_qlvattu : Form
    {


        QLVatTuDataContext db = new QLVatTuDataContext();
        
        
        public frm_qlvattu()
        {
            InitializeComponent();
        }


        private void loaddata()
        {
            var data = from vattu in db.VatTus select vattu;
            dgv_vattu.DataSource = data.ToList();
        }

        private void dgv_vattu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_vattu.Rows[e.RowIndex];
                txt_mavt.Text = row.Cells["mavt"].Value.ToString();
                txt_tenvt.Text = row.Cells["tenvt"].Value.ToString();
                txt_nhasx.Text = row.Cells["nhasx"].Value.ToString();

                dtp_ngaysx.Value = Convert.ToDateTime(row.Cells["ngaysx"].Value);

                txt_hansd.Text = row.Cells["hansd"].Value.ToString();
                txt_soluong.Text = row.Cells["soluong"].Value.ToString();
                txt_dongia.Text = row.Cells["dongia"].Value.ToString();


            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            VatTu vt = new VatTu
            {
                mavt = txt_mavt.Text,
                tenvt = txt_tenvt.Text,
                nhasx = txt_nhasx.Text,
                ngaysx = dtp_ngaysx.Value,
                hansd = int.Parse( txt_hansd.Text),
                soluong = int.Parse(txt_soluong.Text),
                dongia = decimal.Parse(txt_dongia.Text)
            };


            db.VatTus.InsertOnSubmit(vt);
            db.SubmitChanges();

            loaddata();

            MessageBox.Show("Thêm vật tư thành công!");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            VatTu vt = db.VatTus.FirstOrDefault(v => v.mavt == txt_mavt.Text);

            if (vt != null)
            {
                vt.mavt = txt_mavt.Text;
                vt.tenvt = txt_tenvt.Text;
                vt.nhasx = txt_nhasx.Text;
                vt.ngaysx = dtp_ngaysx.Value;
                vt.hansd = int.Parse(txt_hansd.Text);
                vt.soluong = int.Parse(txt_soluong.Text);
                vt.dongia = decimal.Parse(txt_dongia.Text);

                db.SubmitChanges();
                loaddata();

                MessageBox.Show("Sửa thành công vật tư!");

            }
            else
                MessageBox.Show("Không tìm thấy vật tư muốn sửa !");
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            VatTu vt = db.VatTus.FirstOrDefault(v => v.mavt == txt_mavt.Text);

            if( vt != null )
            {
                db.VatTus.DeleteOnSubmit(vt);
                db.SubmitChanges();
                loaddata();
                MessageBox.Show("Xóa thành công!");
            }    
            else
                MessageBox.Show("Xóa không thành công!");

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
