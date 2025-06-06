using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Shop_Management_interface
{
    public partial class Dashboard : Form
    {
        PETSHOPDataContext context = new PETSHOPDataContext();
        public Dashboard()
        {
            InitializeComponent();
            //cn = new SqlConnection(dbcon.connection());
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadPet();
        }
        private void LoadPet()
        {
            var pet = context.PRODUCTs
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Counts = g.Sum(p => p.Qty)})
                .ToDictionary(g => g.Category, g => g.Counts);
            var labelMap = new Dictionary<string, Label>()
    {
                { "Dog", lblDog },
                { "Cat", lblCat },
                { "Bunny", lblBunny },
                { "Bird", lblbird },
                { "Fish", lblFish }
                
            };
            foreach (var pair in labelMap)
            {
                pair.Value.Text = pet.ContainsKey(pair.Key) ? pet[pair.Key].ToString() : "0";
            }
        }

        private void lblbird_Click(object sender, EventArgs e)
        {

        }
    }
}
