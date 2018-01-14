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

namespace Shipit.Reports
{
    public partial class Frm_ProductionActual : Form
    {
        Transaction.ReportTransaction rtptran = new Transaction.ReportTransaction();

        public Frm_ProductionActual()
        {
            InitializeComponent();
            LoadFactoryCombo();
        }
        public void LoadFactoryCombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from fctry in courdatacontext.Factory_Masters
                    select fctry;



            cmb_factory.DataSource = q;
            cmb_factory.DisplayMember = "Factory_name";
            cmb_factory.ValueMember = "Factory_ID";
            //   Buyercombo.DataBind();



        }
        private void Frm_ProductionActual_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rtptran = new Transaction.ReportTransaction();

            DataTable dt = rtptran.GetDailyProduction(int.Parse(cmb_factory.SelectedValue.ToString()), dtp_from.Value.Date, dtp_to.Value.Date);

            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "D:\\report1.rdlc";
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
           
        }

      

        private void cmb_factory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtptran = new Transaction.ReportTransaction();

            DataTable dt = rtptran.GetDailyPacking (int.Parse(cmb_factory.SelectedValue.ToString()), dtp_from.Value.Date, dtp_to.Value.Date);

            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "D:\\report1.rdlc";
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

       




    }
}
