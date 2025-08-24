using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai2
{
    public partial class frm_themhanghoa : Form
    {
        public frm_themhanghoa()
        {
            InitializeComponent();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            grid_hanghoa.AllowUserToAddRows = false; //ngăn người dùng tuỳ ý chỉnh sửa hàng
            grid_hanghoa.Rows.Add(1);  //thêm 1 hàng

            int indexRow = grid_hanghoa.Rows.Count - 1;  //lấy chỉ số dòng cuối cùng
            grid_hanghoa[0, indexRow].Value = txt_hanghoa.Text; //hàng hoá ở cột 0
            grid_hanghoa[1, indexRow].Value = txt_soluong.Text; //số lượng ở cột 1

            int sc = grid_hanghoa.Rows.Count;  //số lượng dòng
            int Tongsoluong = 0;

            for( int i = 0; i< sc; i++)
            {
                Tongsoluong += int.Parse( grid_hanghoa.Rows[i].Cells["col_soluong"].Value.ToString() );

                txt_tongsoluong.Text = Tongsoluong.ToString();

            }    


        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            int RowIndex = grid_hanghoa.CurrentRow.Index;
            grid_hanghoa.Rows.RemoveAt(RowIndex);
        }


    }
}
