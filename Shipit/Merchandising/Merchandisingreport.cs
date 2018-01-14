using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.Merchandising
{
    public partial class Merchandisingreport : Form
    {
        public Merchandisingreport()
        {
            InitializeComponent();
          
        }


        public Merchandisingreport(int atcid,String status)
        {
            InitializeComponent();
            ASQofreport(atcid,status);
        }

        public void ASQofreport(int atcid, String status)
        {

            if (Program.LogType == "Office")
            {
                Program.OurReportSource = @"\\it-dept\Project\ShipITReports";
            }
            else
            {
                Program.OurReportSource = @"\\213.42.33.230\Project\ShipITReports";
            }
            ReportDocument cryrpt = Reports.ARTLogonvalues.getpeport(Program.OurReportSource + "\\ASQ.rpt");

          if(status.Trim()=="atc")
          {
              cryrpt.RecordSelectionFormula = "{AtcDetails.AtcId}=" + atcid;
          }
          else if (status.Trim() == "ourstyle")
          {
              cryrpt.RecordSelectionFormula = "{AtcDetails.OurStyleID}=" + atcid;
          }
             
            

            crystalReportViewer3.ReportSource = cryrpt;
            cryrpt.Refresh();

        }
   

    }
}
