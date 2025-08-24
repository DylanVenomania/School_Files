using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Shop_Management_interface
{
    public partial class CustomerForm : Form
    {
        PETSHOPDataContext context = new PETSHOPDataContext();
        public CustomerForm()
        {
            InitializeComponent();
            CustomerForm_Load();
        }

        private void CustomerForm_Load()
        {
            dgvCustomer.AutoGenerateColumns = false;
            if (context != null)
                context.Dispose();
            context = new PETSHOPDataContext();

            var userList = context.CUSTOMERs.ToList();

            var List = userList
                .Select((u, index) => new
                {
                    No = index + 1,
                    u.ID,
                    u.Name,
                    u.Address,
                    u.Phone
                }).ToList();

            dgvCustomer.DataSource = List;
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerModule module = new CustomerModule(0);
            module.btnUpdate.Enabled = false;
            module.ShowDialog();
            CustomerForm_Load();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvCustomer.AutoGenerateColumns = false;
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                CustomerForm_Load();
                return;
            }

            var filteredList = context.CUSTOMERs
                .Where(u =>
                    u.ID.ToString().Contains(keyword) ||
                    u.Name.ToLower().Contains(keyword) ||
                    u.Phone.ToLower().Contains(keyword) ||
                    u.Address.ToLower().Contains(keyword)
                    )
                .ToList();

            var displayList = filteredList
            .Select((u, index) => new
            {
                No = index + 1,
                u.ID,
                u.Name,
                u.Address,
                u.Phone
            }).ToList();

            dgvCustomer.DataSource = displayList;
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "OrderHistory")
            {
                int customerId = int.Parse(dgvCustomer.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                HistoryForm historyForm = new HistoryForm(customerId);
                if (historyForm.Is_Empty_HisTory == false)
                    historyForm.ShowDialog();
            }
            else if (colName == "Edit")
            {
                int customerId = int.Parse(dgvCustomer.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                string customerName = dgvCustomer.Rows[e.RowIndex].Cells["colName"].Value.ToString();
                string customerAddress = dgvCustomer.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                string customerPhone = dgvCustomer.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                CustomerModule module = new CustomerModule(customerId);
                module.txtName.Text = customerName;
                module.txtAddress.Text = customerAddress;
                module.txtPhone.Text = customerPhone;
                module.btnSave.Enabled = false;

                module.ShowDialog();
                CustomerForm_Load();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int customerId = int.Parse(dgvCustomer.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    var customer = context.CUSTOMERs.FirstOrDefault(x => x.ID == customerId);
                    if (customer != null)
                    {
                        context.CUSTOMERs.DeleteOnSubmit(customer);
                        context.SubmitChanges();
                        MessageBox.Show("Delete successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CustomerForm_Load();
                    }


                }
            }
        }
    }
}
