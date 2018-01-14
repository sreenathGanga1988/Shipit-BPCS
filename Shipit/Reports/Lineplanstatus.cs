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
    public partial class Lineplanstatus : Form
    {
        public Lineplanstatus()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmb_year.Text.Trim() != "")
            {
                ultraGrid1.DataSource = null;
                pendingLinePlanTableAdapter.Connection.ConnectionString = Program.ConnStr;
                DataTable dt = this.pendingLinePlanTableAdapter.GetData();
                ultraGrid1.DataSource = dt;
                UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            }
        }

        private void Lineplanstatus_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'courierDetailsDataSet.PendingLinePlan' table. You can move, or remove it, as needed.
           // this.pendingLinePlanTableAdapter.Fill(this.courierDetailsDataSet.PendingLinePlan);

        }

        private void ultraButton2_Click(object sender, EventArgs e)
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
    }
}
