using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.Reports
{
    public partial class ApprovedReports : Form
    {
        public ApprovedReports()
        {
            InitializeComponent();
        }

        private void cmb_proj_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_type.Text.Trim() == "Projection")
            {
                loadprojectionnumber();
            }
        }



        public void loadprojectionnumber()
        {
            using (CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr))
            {
                var results = (from appr in cntxt.ApprovedProj_tbls
                               select appr.Projnum).Distinct();
                cmb_number.DataSource = results;
                //cmb_proj.ValueMember = "Projnum";
                cmb_number.DisplayMember = "Projnum";

            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr))
            {
                var q = from proj in cntxt.ApprovedProj_tbls
                        where proj.Projnum == cmb_number.Text.Trim() && proj.IsApproved=="A"
                        select proj;

                ultraGrid1.DataSource = q;

            }
        }
    }
}
