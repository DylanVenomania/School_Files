using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Pet_Shop_Management_interface
{
    public partial class LoginForm : Form
    {
        PETSHOPDataContext context = new PETSHOPDataContext();
        public static int ACCOUNT_ID { get; set; }
        public static string ACCOUNT_ROLE { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string ID = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                USER user = context.USERs.FirstOrDefault(x => x.ID == int.Parse(ID) && x.Password == password);
                if (user != null)
                {
                    ACCOUNT_ID = user.ID;
                    ACCOUNT_ROLE = user.Role;
                    this.Dispose();
                    if (user.Role == "Admin")
                    {
                        MainForm mainForm = new MainForm();
                        mainForm.ShowDialog();
                    }
                    else
                    {
                        UserMainForm mainForm = new UserMainForm();
                        mainForm.ShowDialog();
                    }
                   
                }
                else
                {
                    MessageBox.Show("Incorrect username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Incorrect username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnForgetPassword_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotEmail = new ForgotPassword();
            this.Dispose();
            forgotEmail.ShowDialog();
        }
    }
}
