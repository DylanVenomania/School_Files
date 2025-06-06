using Pet_Shop_Management_interface.Properties;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace Pet_Shop_Management_interface
{
    public partial class UserForm : Form
    {
        PETSHOPDataContext context = new PETSHOPDataContext();
        private Image eyeOpenImage;
        private Image eyeCloseImage;

        public UserForm()
        {
            InitializeComponent();
            LoadUser();
            LoadImages();
        }

        #region Method

        public void LoadImages()
        {
            using (var ms = new MemoryStream(Resources.eyeopen1))
            {
                eyeOpenImage = Image.FromStream(ms);
            }
            using (var ms = new MemoryStream(Resources.eyeclose))
            {
                eyeCloseImage = Image.FromStream(ms);
            }
        }

        public void LoadUser()
        {
            dgvUser.AutoGenerateColumns = false;
            if (context != null)
                context.Dispose();
            context = new PETSHOPDataContext();

            var userList = context.USERs.ToList();

            var List = userList
                .Select((u, index) => new
                {
                    No = index + 1,
                    u.ID,
                    u.Name,
                    u.Address,
                    u.Phone,
                    u.Role,
                    u.Dateofbirth,
                    u.Balance,
                    u.Email,
                    //Password = new string('*', u.Password.Length)
                }).ToList();

            dgvUser.DataSource = List;


        }
        #endregion Method

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string colName = dgvUser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                
                UserModule module = new UserModule(this);
                module.lblID.Text = dgvUser.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                module.txtName.Text = dgvUser.Rows[e.RowIndex].Cells["colName"].Value.ToString();
                module.txtAddress.Text = dgvUser.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                module.txtPhone.Text = dgvUser.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                module.dtDoB.Value = Convert.ToDateTime(dgvUser.Rows[e.RowIndex].Cells["Dateofbirth"].Value);
                USER originalUser = context.USERs.FirstOrDefault(u => u.ID == int.Parse(dgvUser.Rows[e.RowIndex].Cells["ID"].Value.ToString()));
                module.txtPass.Text = originalUser.Password;
                module.txtBalance.Text = originalUser.Balance.ToString();
                module.txtEmail.Text = originalUser.Email;
                module.btnSave.Enabled = false;
                module.btnUpdate.Enabled = true;
                module.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    USER dm = context.USERs.FirstOrDefault(x => x.ID == int.Parse(dgvUser.Rows[e.RowIndex].Cells["ID"].Value.ToString()));
                    context.USERs.DeleteOnSubmit(dm);
                    context.SubmitChanges();
                    LoadUser();

                    MessageBox.Show("User data has been successfully removed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else if (colName == "Eye")
            {
                DataGridViewRow row = dgvUser.Rows[e.RowIndex];
                var currentImageTag = row.Cells["Eye"].Tag as string;

                try
                {
                    USER originalUser = context.USERs.FirstOrDefault(u => u.ID == int.Parse(dgvUser.Rows[e.RowIndex].Cells["ID"].Value.ToString()));
                    if (originalUser == null)
                    {
                        return;
                    }

                    if (currentImageTag == "open" || currentImageTag == null)
                    {
                        row.Cells["Password"].Value = originalUser.Password;
                        row.Cells["Eye"].Value = eyeCloseImage;
                        row.Cells["Eye"].Tag = "close";
                        
                        row.Cells["Password"].Style.ForeColor = Color.Black;
                    }
                    else if (currentImageTag == "close")
                    {
                        row.Cells["Password"].Value = "";
                        row.Cells["Eye"].Value = eyeOpenImage;
                        row.Cells["Eye"].Tag = "open";
                        row.Cells["Password"].Style.ForeColor = Color.Gray;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                
            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserModule module = new UserModule(this);
            module.btnSave.Enabled = true;
            module.btnUpdate.Enabled = false;
            module.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvUser.AutoGenerateColumns = false;
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadUser();
                return;
            }

            var filteredList = context.USERs
                .Where(u =>
                    u.ID.ToString().Contains(keyword) ||
                    u.Name.ToLower().Contains(keyword) ||
                    u.Phone.ToLower().Contains(keyword) ||
                    u.Address.ToLower().Contains(keyword) ||
                    u.Role.ToLower().Contains(keyword) ||
                    u.Dateofbirth.ToString().Contains(keyword) ||
                    u.Email.Contains(keyword)
                    )
                .ToList();

            var displayList = filteredList
            .Select((u,index) => new
            {
                No = index + 1,
                u.ID,
                u.Name,
                u.Address,
                u.Phone,
                u.Role,
                u.Dateofbirth,
                u.Email,
                u.Balance
                //Password = "******"
            }).ToList();

                dgvUser.DataSource = displayList;

        }
    }


}
