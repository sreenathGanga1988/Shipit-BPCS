using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shipit.CourierDetailsDataSetTableAdapters;
using Microsoft.Reporting.WinForms;
namespace Shipit.Reports.RDLC
{
    public partial class LineplanReportForm : Form
    {
        Transaction.DataTransaction dttrans = null;
        public LineplanReportForm()
        {
            InitializeComponent();
            dttrans = new Transaction.DataTransaction();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (cmb_year.Text.Trim() != "" && cmb_month.Text.Trim() != "")
            {
                 loadreport();
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
            CourierDetailsDataSetTableAdapters.LinePlanDataTableAdapter adapt = new LinePlanDataTableAdapter();
            adapt.Connection.ConnectionString = Program.ConnStr ;
            if(Program.LogType=="User")
            {

            }
            DataTable dt = adapt.GetDataByMonthandFactory(int.Parse(cmb_year.Text), cmb_month.Text.Trim(), int.Parse(cmb_factory.SelectedValue.ToString()));
            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "D:\\report1.rdlc";
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void LineplanReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'courierDetailsDataSet.LinePlanData' table. You can move, or remove it, as needed.
         //   linePlanDataTableAdapter.Connection.ConnectionString = Program.ConnStr;
          //  this.linePlanDataTableAdapter.Fill(this.courierDetailsDataSet.LinePlanData);
            
            loadfactorycombo();

            //this.reportViewer1.RefreshReport();
        }

        private void cmb_factory_SelectedIndexChanged(object sender, EventArgs e)
        {
            dttrans.resrictacess(cmb_factory);
        }
    }
}
