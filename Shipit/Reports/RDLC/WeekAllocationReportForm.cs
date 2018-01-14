using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shipit.CourierDetailsDataSetTableAdapters;
namespace Shipit.Reports.RDLC
{
    public partial class WeekAllocationReportForm : Form
    {
        Transaction.DataTransaction dttrans = null;
        public WeekAllocationReportForm()
        {
            InitializeComponent();
            dttrans = new Transaction.DataTransaction();
        }

        private void WeekAllocationReportForm_Load(object sender, EventArgs e)
        {
            loadfactorycombo();
            if(Program.lctnpk!=0)
            {
                cmb_factory.SelectedValue = Program.lctnpk;
                button1.Enabled = false;
                button3.Enabled = false;
            }
            
        }

        public void loadfactorycombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from factory in courdatacontext.Factory_Masters
                    select factory;



            cmb_factory.DataSource = q;
            cmb_factory.DisplayMember = "Factory_name";
            cmb_factory.ValueMember = "Factory_ID";
            //   Buyercombo.DataBind();



        }

        public void loadreport()
        {

            // TODO: This line of code loads data into the 'Shipitdata.LinePlan' table.You can move, or remove it, as needed.
            // this.LinePlanTableAdapter.Fill(this.Shipitdata.LinePlan);
            CourierDetailsDataSet cddta = new CourierDetailsDataSet();
            CourierDetailsDataSetTableAdapters.WeeklyAllocationTableAdapter adapt = new WeeklyAllocationTableAdapter();
            adapt.Connection.ConnectionString = Program.ConnStr;
            DataTable dt = adapt.GetData();
            ReportDataSource datasource = new ReportDataSource("weekplan", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "D:\\report1.rdlc";
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
        public void loadreportbyatc()
        {

            // TODO: This line of code loads data into the 'Shipitdata.LinePlan' table.You can move, or remove it, as needed.
            // this.LinePlanTableAdapter.Fill(this.Shipitdata.LinePlan);
            CourierDetailsDataSet cddta = new CourierDetailsDataSet();
            CourierDetailsDataSetTableAdapters.WeeklyAllocationTableAdapter adapt = new WeeklyAllocationTableAdapter();
            adapt.Connection.ConnectionString = Program.ConnStr;
            DataTable dt = adapt.GetDataByYear  (int.Parse (cmb_year.Text ));
            ReportDataSource datasource = new ReportDataSource("weekplan", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "D:\\report1.rdlc";
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }


        public void loadreportbyyearandmonth()
        {

            // TODO: This line of code loads data into the 'Shipitdata.LinePlan' table.You can move, or remove it, as needed.
            // this.LinePlanTableAdapter.Fill(this.Shipitdata.LinePlan);
            CourierDetailsDataSet cddta = new CourierDetailsDataSet();
            CourierDetailsDataSetTableAdapters.WeeklyAllocationTableAdapter adapt = new WeeklyAllocationTableAdapter();
            adapt.Connection.ConnectionString = Program.ConnStr;
            DataTable dt = adapt.GetDataByYearandMonth(int.Parse(cmb_year.Text),cmb_month .Text );
            ReportDataSource datasource = new ReportDataSource("weekplan", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "D:\\report1.rdlc";
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (cmb_year.Text != "" && cmb_month.Text.Trim() != "")
            {
                loadreportbyyearandmonth();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmb_year.Text != "")
            {
                loadreportbyatc();
            }
        }

        private void cmb_factory_SelectedIndexChanged(object sender, EventArgs e)
        {
            dttrans.resrictacess(cmb_factory);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmb_year.Text != "" && cmb_month.Text.Trim() != "")
            {
                loadreportbyyearandmonthandfact();
            }

        }
        public void loadreportbyyearandmonthandfact()
        {

            // TODO: This line of code loads data into the 'Shipitdata.LinePlan' table.You can move, or remove it, as needed.
            // this.LinePlanTableAdapter.Fill(this.Shipitdata.LinePlan);
            CourierDetailsDataSet cddta = new CourierDetailsDataSet();
            CourierDetailsDataSetTableAdapters.WeeklyAllocationTableAdapter adapt = new WeeklyAllocationTableAdapter();
            adapt.Connection.ConnectionString = Program.ConnStr;
            DataTable dt = adapt.GetDataByFactoryAndPeriod(int.Parse(cmb_year.Text), cmb_month.Text.Trim(), int.Parse(cmb_factory.SelectedValue.ToString()));
            ReportDataSource datasource = new ReportDataSource("weekplan", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "D:\\report1.rdlc";
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
