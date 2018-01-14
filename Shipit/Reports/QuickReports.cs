using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
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
     
    public partial class QuickReports : Form
    {
        Transaction.DataTransaction dttrans = null;
        Transaction.ReportTransaction rpttran = null;
        public QuickReports()
        {
            InitializeComponent();
            dttrans = new Transaction.DataTransaction();
            rpttran = new Transaction.ReportTransaction();
        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmb_year.Text!= "" )
            {
                DataTable dt = rpttran.bookvsWeekplan(int.Parse(cmb_year.Text));
                ultraGrid1.DataSource = null;
                ultraGrid1.DataSource = dt;
                UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            }
            else
            {
                MessageBox.Show("Select Year ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void finalAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
                DataTable dt = rpttran.BalancePoToAllocate ();
                ultraGrid1.DataSource = null;
                ultraGrid1.DataSource = dt;
                UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
           
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Title = "Save an Excel File";
            saveFileDialog1.Filter = "Excel|*.xls|Excel 2010|*.xlsx";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                this.ultraGridExcelExporter1.Export(this.ultraGrid1, saveFileDialog1.FileName);
            }
        }

        private void croppedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                DataTable dt = rpttran.AtcLineCapacity();
                ultraGrid1.DataSource = null;
                ultraGrid1.DataSource = dt;
                UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            
        }

        private void actualCapacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmb_year.Text != "" && cmb_month.Text != "")
            {
                DataTable dt = rpttran.GetFactoriesCapacities (int.Parse (cmb_year.Text ),cmb_month.Text.Trim ());
                ultraGrid1.DataSource = null;
                ultraGrid1.DataSource = dt;
                UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            }
            else
            {
                MessageBox.Show("Select Year And Month");
            }
        }

        private void cmEntryPendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
               
           
        }

        private void productionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (cmb_year.Text.Trim() != "")
            {
                ActualProducedTableAdapter adapt = new ActualProducedTableAdapter();
                adapt.Connection.ConnectionString = Program.ConnStr;

                DataTable dt = new DataTable();

                
                dt = adapt.GetDataByYear (int.Parse (cmb_year.Text) );
                ultraGrid1.DataSource = null;
                ultraGrid1.DataSource = dt;
                UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            }
            else
            {
                MessageBox.Show("Select the Year");
            }
        }

        private void packingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (cmb_year.Text.Trim() != "")
            {
                ActualPackedTableAdapter adapt = new ActualPackedTableAdapter();
                adapt.Connection.ConnectionString = Program.ConnStr;

                DataTable dt = new DataTable();


                dt = adapt.GetDataByYear(int.Parse(cmb_year.Text));
                ultraGrid1.DataSource = null;
                ultraGrid1.DataSource = dt;
                UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            }
            else
            {
                MessageBox.Show("Select the Year");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void projectionOfPODeliveryDateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataTable dt = rpttran.GetPOPROJECTION(dtp_from.Value.Date,dtp_to.Value.Date);
            ultraGrid1.DataSource = null;
            ultraGrid1.DataSource = dt;
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            
        }
    }
}
