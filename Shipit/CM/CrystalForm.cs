using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.CM
{
    public partial class CrystalForm : Form
    {
        public CrystalForm()
        {
            InitializeComponent();
            loadprojectionnumber();
        }


        public void loadprojectionnumber()
        {
            using (CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr))
            {
                var results = (from appr in cntxt.ApprovedProj_tbls
                               select appr.Projnum).Distinct();
                cmb_proj.DataSource = results;
                //cmb_proj.ValueMember = "Projnum";
                cmb_proj.DisplayMember = "Projnum";

            }
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr))
            {
                var q = from proj in cntxt.ApprovedProj_tbls
                        where proj.Projnum == cmb_proj.Text.Trim()
                        select proj;
                foreach (var detail in q)
                {
                    cntxt.ApprovedProj_tbls.DeleteOnSubmit(detail);
                }

                try
                {
                    cntxt.SubmitChanges();
                }
                catch (Exception)
                {


                }
            }
        }

        private void exportToPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr))
            {
                var q = from proj in cntxt.ApprovedProj_tbls
                        where proj.Projnum == cmb_proj.Text.Trim()
                        select proj;
                foreach (var detail in q)
                {
                  detail.IsApproved="A";
                }

                try
                {
                    cntxt.SubmitChanges();
                }
                catch (Exception)
                {


                }
            }
        }

        private void dailyEfficencyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadProjreport();
        }
        public void loadProjreport()
        {

            if (Program.LogType == "Office")
            {
              
            }
            else
            {
                Program.OurReportSource = @"\\213.42.33.230\Project\ShipITReports";
            }
            ReportDocument cryrpt = Reports.Logonvalues.getpeport(Program.OurReportSource + "\\Projection.rpt");
            
            cryrpt.RecordSelectionFormula = " {ApprovedProj_tbl.Projnum}='" + cmb_proj.Text.Trim ()+"'";
           // cryrpt.RecordSelectionFormula = "{EmployeePersonalMaster_tbl.Status}='A' and {EmployeeDesignation_tbl.BranchLocationPK}=" + int.Parse(cmb_location.SelectedValue.ToString());

            crystalReportViewer1.ReportSource = cryrpt;
            cryrpt.Refresh();

        }

    }
}
