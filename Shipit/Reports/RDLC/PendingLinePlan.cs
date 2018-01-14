using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.Reports.RDLC
{
    public partial class PendingLinePlan : Form
    {
        Transaction.DataTransaction dtran = new Transaction.DataTransaction();
        public PendingLinePlan()
        {
            InitializeComponent();
            dtran = new Transaction.DataTransaction();
        }

        private void PendingLinePlan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'courierDetailsDataSet.PendingLinePlan_VW' table. You can move, or remove it, as needed.
            this.pendingLinePlan_VWTableAdapter.Connection.ConnectionString = Program.ConnStr;
            this.pendingLinePlan_VWTableAdapter.Fill(this.courierDetailsDataSet.PendingLinePlan_VW);

            this.reportViewer1.RefreshReport();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CourierDetailsDataSet cddta = new CourierDetailsDataSet();

            CourierDetailsDataSetTableAdapters.PendingPOAllocation_VWTableAdapter adapt = new CourierDetailsDataSetTableAdapters.PendingPOAllocation_VWTableAdapter();
            adapt.Connection.ConnectionString = Program.ConnStr;
            DataTable dt = dtran.pendingPOdata();
            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
            this.reportViewer2 .LocalReport.DataSources.Clear();
            this.reportViewer2.LocalReport.DataSources.Add(datasource);
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "D:\\report1.rdlc";
            this.reportViewer2.RefreshReport();
        }
    }
}
