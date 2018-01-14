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

namespace Shipit.Reports
{
    public partial class BookingReport : Form
    {
        public BookingReport()
        {
            InitializeComponent();
        }

        private void BookingReport_Load(object sender, EventArgs e)
        {
            //this.orderDetailFullTableAdapter.Connection.ConnectionString = Program.ConnStr;
            // TODO: This line of code loads data into the 'courierDetailsDataSet.OrderDetailFull' table. You can move, or remove it, as needed.
          //  this.orderDetailFullTableAdapter.Fill(this.courierDetailsDataSet.OrderDetailFull);
            loadfactorycombo();
        }
        public void loadfactorycombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from factory in courdatacontext.Factory_Masters
                    select factory;



           cmb_factory .DataSource = q;
           cmb_factory.DisplayMember = "Factory_name";
            cmb_factory.ValueMember = "Factory_ID";
            //   Buyercombo.DataBind();



        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            this.ultraGrid1.Rows.ColumnFilters.ClearAllFilters();
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

        private void cmb_factory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cmb_year.Text.Trim() != "" && cmb_month.Text.Trim() != "")
            {
                orderDetailFullTableAdapter.Connection.ConnectionString = Program.ConnStr;
                ultraGrid1.DataSource = null;
                DataTable dt = this.orderDetailFullTableAdapter.GetDataBy1(int.Parse(cmb_year.Text), cmb_month.Text.Trim());
                ultraGrid1.DataSource = dt;
                UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmb_year.Text.Trim() != "")
            {
                ultraGrid1.DataSource = null;
                orderDetailFullTableAdapter.Connection.ConnectionString = Program.ConnStr;
                DataTable dt = this.orderDetailFullTableAdapter.GetDataBy(int.Parse(cmb_year.Text));
                ultraGrid1.DataSource = dt;
                UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmb_year.Text.Trim() != "" && cmb_month.Text.Trim() != "" && cmb_factory .Text.Trim() != "")
            {
                orderDetailFullTableAdapter.Connection.ConnectionString = Program.ConnStr;
                ultraGrid1.DataSource = null;
                DataTable dt = this.orderDetailFullTableAdapter.GetDataBy2(int.Parse(cmb_year.Text), cmb_month.Text.Trim(), int.Parse(cmb_factory .SelectedValue .ToString ()));
                ultraGrid1.DataSource = dt;
                UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            }
        }
    }
}
