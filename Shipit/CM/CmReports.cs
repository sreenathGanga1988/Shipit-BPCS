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

namespace Shipit.CM
{
    public partial class CmReports : Form
    {
        Transaction.ReportTransaction rpttran = null;
        Transaction.DataExporter DTPEXPTR = null;
        DataTable newdata = new DataTable();
        public CmReports()
        {
            InitializeComponent(); 
            rpttran = new Transaction.ReportTransaction();
        }

       

        private void cmPendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = rpttran.GetAtcPendingForCMEntry();
            ultraGrid1.DataSource = null;
            ultraGrid1.DataSource = dt;
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = rpttran.CMReport();
            foreach (DataColumn clmn in dt.Columns)
            {
                clmn.ReadOnly = false;
            }
            ultraGrid1.DataSource = null;
            ultraGrid1.DataSource = dt;
            ultraGrid1.Text = "CM Report";
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
        }

        private void croppedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = rpttran.CMnotmadeButLinePlanned();
            foreach (DataColumn clmn in dt.Columns)
            {
                clmn.ReadOnly = false;
            }
            ultraGrid1.DataSource = null;
            ultraGrid1.DataSource = dt;
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
        }

        private void editCMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ultraGrid1.Text == "CM Report")
            {
                int cmid = int.Parse(ultraGrid1.Rows[ultraGrid1.ActiveCell.Row.Index ].Cells["cmid"].Value.ToString());
                CM.CmCalculatorForm cmfrm = new CmCalculatorForm(cmid);
                cmfrm.Show();
            }
        }

        private void deleteCMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ultraGrid1.Text == "CM Report")
            {
                int cmid = int.Parse(ultraGrid1.Rows[ultraGrid1.ActiveCell.Row.Index].Cells["cmid"].Value.ToString());


                CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
                var q = from cmplan in couriercontext.CmMasters
                        where cmplan.CmId == cmid
                        select cmplan;

                foreach (var detail in q)
                {
                    couriercontext.CmMasters.DeleteOnSubmit(detail);
                }

                try
                {
                    couriercontext.SubmitChanges();
                }
                catch (Exception)
                {

                    // Provide for exceptions.
                }

                MessageBox.Show("Done");
            }
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

                MessageBox.Show("Done");
            }
        }

        private void plannedVsActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

                DataTable dt = rpttran.GetPlannedvsactual();
            foreach (DataColumn clmn in dt.Columns)
            {
                clmn.ReadOnly = false;
            }
            ultraGrid1.DataSource = null;
            ultraGrid1.DataSource = dt;
            ultraGrid1.Text = "CM Report";
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
        }
    }
}
