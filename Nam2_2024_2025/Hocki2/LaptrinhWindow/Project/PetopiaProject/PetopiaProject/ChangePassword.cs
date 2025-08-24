using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Shop_Management_interface
{
    public partial class ChangePassword : Form
    {
        PETSHOPDataContext context = new PETSHOPDataContext();
        ForgotPassword FORGOTEMAIL;
        public ChangePassword(ForgotPassword forgotEmail)
        {
            InitializeComponent();
            FORGOTEMAIL = forgotEmail;
        }

        

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPassword.Text.Trim()) || string.IsNullOrEmpty(txtConfirm.Text.Trim()))
                {
                    MessageBox.Show("Please enter both password and confirm password", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPassword.Text.Trim() != txtConfirm.Text.Trim())
                {
                    MessageBox.Show("Password and confirm password do not match", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                USER user = context.USERs.FirstOrDefault(x => x.ID == FORGOTEMAIL.user.ID);
                if (user == null)
                {
                    MessageBox.Show("User not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoginForm.ACCOUNT_ID = user.ID;
                LoginForm.ACCOUNT_ROLE = user.Role;

                user.Password = txtPassword.Text.Trim();
                context.SubmitChanges();
                
                if (user.Role == "Admin")
                {
                    MainForm mainForm = new MainForm();
                    mainForm.ShowDialog();
                }
                else
                {
                    UserMainForm usermainForm = new UserMainForm();
                    usermainForm.ShowDialog();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            LoginForm loginform = new LoginForm();
            loginform.ShowDialog();
        }
    }
}
