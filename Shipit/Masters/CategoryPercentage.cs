using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shipit
{
    public partial class CategoryPercentage : Form
    {
        public CategoryPercentage()
        {
            InitializeComponent();
            ShowCategoryPercentage();
        }




        public void ShowCategoryPercentage()
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);

            var q = from cust in couriercontext.Category_Masters
                    select new { cust.CategoryIID ,cust.CategoryName ,cust.PcsPerline,credit1=0};
            dataGridView1.DataSource = q;
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
