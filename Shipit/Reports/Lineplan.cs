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
    public partial class Lineplan : Form
    {
        public Lineplan()
        {
            InitializeComponent();
        }

        private void Lineplan_Load(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.Text=="Lineplan")
            {
            //    this.linedatapreviewTableAdapter.Connection.ConnectionString = Program.ConnStr;
                // TODO: This line of code loads data into the 'courierDetailsDataSet.Linedatapreview' table. You can move, or remove it, as needed.
             //   this.linedatapreviewTableAdapter.Fill(this.courierDetailsDataSet.Linedatapreview);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Text == "Lineplan")
            {
                if (cmb_year.Text.Trim() != "")
                {
                    CourierDetailsDataSetTableAdapters.LineDataPreviewTableAdapter adapt = new LineDataPreviewTableAdapter();
                      adapt.  Connection.ConnectionString = Program.ConnStr;
                   
                    ultraGrid1 .DataSource = null;
                    DataTable dt = adapt.GetDataYear(int.Parse(cmb_year.Text));
                    ultraGrid1.DataSource = dt;
                    UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                    band.Override.AllowRowFiltering = DefaultableBoolean.True;
                    band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cmb_year.Text.Trim() != "" && cmb_month .Text.Trim() != "")
            {
                ultraGrid1.DataSource = null;

                CourierDetailsDataSetTableAdapters.LineDataPreviewTableAdapter adapt = new LineDataPreviewTableAdapter();
                adapt.Connection.ConnectionString = Program.ConnStr;
                DataTable dt = adapt.GetDataByYearandMonth (int.Parse(cmb_year.Text), cmb_month.Text.Trim());
                ultraGrid1.DataSource = dt;
                UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            }
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            ultraGrid1.DataSource = null;

                CourierDetailsDataSetTableAdapters.LineDataPreviewTableAdapter adapt = new LineDataPreviewTableAdapter();
                adapt.Connection.ConnectionString = Program.ConnStr;
                DataTable dt = adapt.GetDataBydate (dtp_from.Value.Date,dtp_to.Value.Date);
                ultraGrid1.DataSource = dt;
                UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
           
        }
    }
}
