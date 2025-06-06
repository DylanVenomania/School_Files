namespace Bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_xem_Click(object sender, EventArgs e)
        {
            txt_khungketqua.Text = txt_hoten.Text + Environment.NewLine
                + comboBox_ngay.Text + "/" + comboBox_thang.Text + "/" + comboBox_nam.Text + Environment.NewLine
                + txt_sothich.Text;
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
