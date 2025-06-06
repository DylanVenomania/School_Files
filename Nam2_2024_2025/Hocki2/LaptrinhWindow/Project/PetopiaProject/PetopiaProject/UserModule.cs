using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Pet_Shop_Management_interface
{
    public partial class UserModule : Form
    {
        PETSHOPDataContext context = new PETSHOPDataContext();
        UserForm userForm;
        private bool check = false;
        public UserModule(UserForm user)
        {
            InitializeComponent();
            userForm = user;
         
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            int newId = 10000;
            if (context.USERs.Any()) // Kiểm tra xem có dữ liệu chưa
            {
                newId = context.USERs.Max(u => u.ID) + 1;
            }
            try
            {
                CheckField();
                if (check == true)
                {
                    USER user = new USER();
                    user.ID = newId;
                    user.Name = txtName.Text;
                    user.Address = txtAddress.Text;
                    user.Phone = txtPhone.Text;
                    user.Role = "User";
                    user.Dateofbirth = dtDoB.Value;
                    user.Password = txtPass.Text;
                    user.Balance = int.Parse(txtBalance.Text);
                    user.Email = txtEmail.Text;
                    context.USERs.InsertOnSubmit(user);
                    context.SubmitChanges();

                    MessageBox.Show("User data has been successfully added", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Clear();
                    userForm.LoadUser();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                CheckField();
                if (check == true)
                {
                    USER user = context.USERs.FirstOrDefault(x => x.ID == int.Parse(lblID.Text.Trim()));
                    user.Name = txtName.Text;
                    user.Address = txtAddress.Text;
                    user.Phone = txtPhone.Text;
                    user.Dateofbirth = dtDoB.Value;
                    user.Password = txtPass.Text;
                    user.Balance = string.IsNullOrWhiteSpace(txtEmail.Text) ? 0 : int.Parse(txtBalance.Text);
                    user.Email = txtEmail.Text;
                    context.SubmitChanges();
                    MessageBox.Show("User data has been successfully updated", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Clear();
                    userForm.LoadUser();
                    this.Dispose();
                    
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #region method
        private void Clear()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtPass.Clear();
            txtEmail.Clear();
            txtBalance.Clear();
            dtDoB.Value = DateTime.Now;
        }
        private static int checkAge(DateTime dateofBirth)
        {
            int age = DateTime.Now.Year - dateofBirth.Year;
            if (DateTime.Now.DayOfYear < dateofBirth.DayOfYear)
                age = age - 1;
            return age;
        }
        public void CheckField()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Required data field!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtPhone.Text.All(char.IsDigit) || txtPhone.Text.Length != 10)
            {
                MessageBox.Show("Phone number must be 10 digits!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Invalid email format!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkAge(dtDoB.Value) <= 3)
            {
                MessageBox.Show("User is not old enough!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtBalance.Text, out int balance) || balance < 0)
            {
                MessageBox.Show("Balance must be a valid non-negative number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            check = true;
        }
        #endregion method
    }
}
