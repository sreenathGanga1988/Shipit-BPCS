using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shipit.CourierDetailsDataSetTableAdapters;
using Microsoft.Reporting.WinForms;
namespace Shipit.Reports.RDLC
{
    public partial class CapacityReport : Form
    {
        public CapacityReport()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadreport();
        }

        public void loadreport()
        {

            // TODO: This line of code loads data into the 'Shipitdata.LinePlan' table.You can move, or remove it, as needed.
            // this.LinePlanTableAdapter.Fill(this.Shipitdata.LinePlan);
            CourierDetailsDataSet cddta = new CourierDetailsDataSet();
            CourierDetailsDataSetTableAdapters.OrderDetailsTableAdapter adapt = new OrderDetailsTableAdapter();
            adapt.Connection.ConnectionString = Program.ConnStr;
            DataTable dt = adapt.GetDatabyYear(int.Parse (cmb_year.Text ));
            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "D:\\report1.rdlc";
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }



        public void loadreportbymonth()
        {

            // TODO: This line of code loads data into the 'Shipitdata.LinePlan' table.You can move, or remove it, as needed.
            // this.LinePlanTableAdapter.Fill(this.Shipitdata.LinePlan);
            CourierDetailsDataSet cddta = new CourierDetailsDataSet();
            CourierDetailsDataSetTableAdapters.OrderDetailsTableAdapter adapt = new OrderDetailsTableAdapter();
            adapt.Connection.ConnectionString = Program.ConnStr;
            DataTable dt = adapt.GetDataByYearMonth (int.Parse(cmb_year.Text),cmb_month.Text.Trim());
            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "D:\\report1.rdlc";
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadreportbymonth();
        }
    }
}
