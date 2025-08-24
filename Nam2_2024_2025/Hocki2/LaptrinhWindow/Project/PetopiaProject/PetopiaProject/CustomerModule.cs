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
    public partial class CustomerModule : Form
    {
        PETSHOPDataContext context = new PETSHOPDataContext();
        int customerId;
        public CustomerModule(int CustomerID)
        {
            InitializeComponent();
            customerId = CustomerID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int newId = 1000;
            if (context.CUSTOMERs.Any())
            {
                newId = context.CUSTOMERs.Max(u => u.ID) + 1;
            }
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Please enter customer name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                MessageBox.Show("Please enter customer address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                MessageBox.Show("Please enter customer phone", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text.Trim(), @"^\d{10}$"))
            {
                MessageBox.Show("Phone number must be exactly 10 digits", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (context.CUSTOMERs.Any(c => c.Phone == txtPhone.Text.Trim()))
            {
                MessageBox.Show("Phone number already exists. Please enter a unique phone number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CUSTOMER customer = new CUSTOMER();
            customer.ID = newId;
            customer.Name = txtName.Text.Trim();
            customer.Address = txtAddress.Text.Trim();
            customer.Phone = txtPhone.Text.Trim();
            context.CUSTOMERs.InsertOnSubmit(customer);
            context.SubmitChanges();
            MessageBox.Show("Add successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Please enter customer name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                MessageBox.Show("Please enter customer address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                MessageBox.Show("Please enter customer phone", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text.Trim(), @"^\d{10}$"))
            {
                MessageBox.Show("Phone number must be exactly 10 digits", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CUSTOMER customer = context.CUSTOMERs.FirstOrDefault(x => x.ID == customerId);
            if (customer != null)
            {
                customer.Name = txtName.Text.Trim();
                customer.Address = txtAddress.Text.Trim();
                customer.Phone = txtPhone.Text.Trim();
                context.SubmitChanges();
                MessageBox.Show("Update successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Customer not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
        }
    }
}
