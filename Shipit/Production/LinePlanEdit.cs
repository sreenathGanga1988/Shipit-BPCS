using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shipit.Production
{
    public partial class LinePlanEdit : Form
    {
        public LinePlanEdit()
        {
            InitializeComponent();
        }
        public LinePlanEdit(DataTable dt)
        {
            InitializeComponent();
            tbl_weekrequirement.DataSource = dt;
        }
        private void LinePlanEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
