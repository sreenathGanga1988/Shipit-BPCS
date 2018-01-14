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
    public partial class Dataform : Form
    {
        public Dataform()
        {
            InitializeComponent();
        }
        public Dataform(DataTable dt)
        {
            InitializeComponent();
            ultraGrid1.DataSource = null;
           
            ultraGrid1.DataSource = dt;
            ultraGrid1.Text = "Line Plan";
            UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            // Set the RowSelectorHeaderStyle to ColumnChooserButton.
            this.ultraGrid1.DisplayLayout.Override.RowSelectorHeaderStyle =
              RowSelectorHeaderStyle.ColumnChooserButton;

            // Enable the RowSelectors. This is necessary because the column chooser
            // button is displayed over the row selectors in the column headers area.
            this.ultraGrid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;

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
    }
}
