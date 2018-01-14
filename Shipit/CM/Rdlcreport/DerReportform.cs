using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.CM.Rdlcreport
{
    public partial class DerReportform : Form
    {
        public DerReportform()
        {
            InitializeComponent();
        }
        public DerReportform(DataTable dt)
        {
            InitializeComponent();
            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "D:\\report1.rdlc";
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void DerReportform_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
