namespace Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            if (this.txt_tennguoidung.Text == "trinh" && this.txt_matkhau.Text == "123")
                MessageBox.Show("Bạn đã đăng nhập thành công!");
            else
                MessageBox.Show("Thông báo, vui lòng nhập lại");
            this.txt_tennguoidung.Focus();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = (MessageBox.Show("Bạn có muốn thoát?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (thongbao == DialogResult.Yes)
                Application.Exit();
        }
    }
}
