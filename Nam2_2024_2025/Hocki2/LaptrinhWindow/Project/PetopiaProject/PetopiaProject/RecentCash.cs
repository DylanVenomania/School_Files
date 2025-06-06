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
    public partial class RecentCash : Form
    {
        public RecentCash()
        {
            InitializeComponent();
        }

        private void RecentCash_Load(object sender, EventArgs e)
        {
            PETSHOPDataContext context = new PETSHOPDataContext();
            var recentBill = (from bill in context.BILLs
                              join cash in context.CASHes on new { bill.TransNo, bill.Pcode } equals new { cash.TransNo, cash.Pcode }
                              join product in context.PRODUCTs on bill.Pcode equals product.Pcode
                              join customer in context.CUSTOMERs on bill.CustomerID equals customer.ID
                              select new
                              {
                                  CustomerName = customer.Name,
                                  Name = product.Name,
                                  cash.Qty,
                                  Total = cash.Qty * cash.Price
                              })
                              .OrderByDescending(b => b.Total)
                              .Take(3)
                              .ToList();

            dgvCash.DataSource = recentBill;
        }
    }
}
