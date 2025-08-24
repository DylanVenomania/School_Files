using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.lstkhungsite.Items.Add("www.tuoitre.com.vn");
            this.lstkhungsite.Items.Add("www.thanhnien.com.vn");
            this.lstkhungsite.Items.Add("www.vnexpress.net");
            this.lstkhungsite.SelectedItem = "www.tuoitre.com.vn";
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.khungketqua.Text = "Bạn đã chọn Website : \n\n";
            this.khungketqua.Text += this.lstkhungsite.SelectedItem.ToString();
        }

        private void khungketqua_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
