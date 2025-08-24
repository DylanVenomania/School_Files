using Guna.UI2.WinForms;
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

namespace Pet_Shop_Management_interface
{
    public partial class UserMainForm : Form
    {
        public UserMainForm()
        {
            InitializeComponent();
            lbluser_id.Text = LoginForm.ACCOUNT_ID.ToString();
            lbluser_role.Text = LoginForm.ACCOUNT_ROLE.ToString();
            timer1.Start();
            btnHome_Click(this, EventArgs.Empty);

            openChildForm(guna2CustomGradientPanel4, new RecentCash());
        }

        #region Method

        private Form activeForm = null;
        public void openChildForm(Guna2CustomGradientPanel panelChild, Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion Method

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginForm loginform = new LoginForm();
            loginform.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {

            openChildForm(panelChild, new CustomerForm());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {

            openChildForm(panelChild, new UserProductForm());
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            openChildForm(panelChild, new CashForm());
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            guna2CustomGradientPanel4.Controls.Clear();
            ChangeAvatar user = new ChangeAvatar();
            user.ShowDialog();
           
            string path = "D:/Nam2_2024_2025/Hocki2/LaptrinhWindow/Do_an/Avatar1/avatar.png";

            if (File.Exists(path))
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    picAvatar.Image = Image.FromStream(stream);
                }
            }
        }

        //Tạo đồng hồ ghi lại thời gian sử dụng 
        private int elapsedSeconds = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsedSeconds++;

            // Chuyển đổi số giây thành định dạng HH:mm:ss
            TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedSeconds);
            lblTimeUsed.Text = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            openChildForm(guna2CustomGradientPanel4, new RecentCash());
            openChildForm(panelChild, new Dashboard());
        }

        private void UserMainForm_Load(object sender, EventArgs e)
        {
            string path = "D:/Nam2_2024_2025/Hocki2/LaptrinhWindow/Do_an/Avatar1/avatar.png";

            if (File.Exists(path))
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    picAvatar.Image = Image.FromStream(stream);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
