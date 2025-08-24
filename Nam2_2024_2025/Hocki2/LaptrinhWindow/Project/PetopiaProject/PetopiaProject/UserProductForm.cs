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
    public partial class UserProductForm : Form
    {
        PETSHOPDataContext context = new PETSHOPDataContext();
        public UserProductForm()
        {
            InitializeComponent();
            ProductForm_Load();
        }
        private void ProductForm_Load()
        {
            dgvProduct.AutoGenerateColumns = false;
            if (context != null)
                context.Dispose();
            context = new PETSHOPDataContext();

            var userList = context.PRODUCTs.ToList();

            var List = userList
                .Select((u, index) => new
                {
                    No = index + 1,
                    u.Pcode,
                    u.Name,
                    u.Category,
                    u.Qty,
                    u.Price
                }).ToList();

            dgvProduct.DataSource = List;
        }
    }
}
