using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using Guna.UI2.WinForms;
using System.Runtime.CompilerServices;
using DocumentFormat.OpenXml.Vml;


namespace Pet_Shop_Management_interface
{
    public partial class MainForm : Form
    {
        PETSHOPDataContext context = new PETSHOPDataContext();
        public MainForm()
        {
            InitializeComponent();
            timer1.Start();
            this.IsMdiContainer = true;
            lbluser_id.Text = LoginForm.ACCOUNT_ID.ToString();
            lbluser_role.Text = LoginForm.ACCOUNT_ROLE.ToString();
            btnDashboard_Click(this, EventArgs.Empty);
            openChildForm(panelChildforDashBoard, new RecentCash());

        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            StatisticsForm statsForm = new StatisticsForm();
            statsForm.ShowDialog();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            openChildForm(panelChild, new Dashboard());
            openChildForm(panelChildforDashBoard, new RecentCash());
        }

        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {
            ChangeAvatarAdmin changeAvatar = new ChangeAvatarAdmin();
            changeAvatar.ShowDialog();
            string path = "D:/Nam2_2024_2025/Hocki2/LaptrinhWindow/Do_an/Avatar/avatar.png";

            if (File.Exists(path))
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    picAvatar.Image = Image.FromStream(stream);
                }
            }
        }

        private int elapsedSeconds = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            

            elapsedSeconds++;

            TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedSeconds);
            lblTimeUsed.Text = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";


            try
            {
            string Sale = context.BILLs
                .Where(x => x.TransNo.StartsWith(DateTime.Now.ToString("yyyyMMdd")))
                .Join(context.CASHes,
                      bill => bill.TransNo,
                      cash => cash.TransNo,
                      (bill, cash) => cash)
                .Distinct()
                .Sum(c => c.Total)
                .ToString();

            int DailySale = int.Parse(Sale);
            lblDailySale.Text = string.IsNullOrEmpty(Sale) ? "0.00" : $"{DailySale:N0}";

            }
            catch (Exception ex)
            {
                lblDailySale.Text = "0.00";
            }
            //lblDailySale.Text = string.IsNullOrEmpty(Sale) ? "0.00" : $"{Sale1:N0}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            this.Hide();
            
            LoginForm loginform = new LoginForm();
            loginform.ShowDialog();
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


        private void btnCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(panelChild, new CustomerForm());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            openChildForm(panelChild, new UserForm());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildForm(panelChild, new ProductForm());
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            openChildForm(panelChild, new CashForm());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string path = "D:/Nam2_2024_2025/Hocki2/LaptrinhWindow/Do_an/Avatar/avatar.png";

            if (File.Exists(path))
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    picAvatar.Image = Image.FromStream(stream);
                }
            }
        }
    }
}
