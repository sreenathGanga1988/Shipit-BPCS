using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.Merchandising
{
    public partial class ArtGridReports : Form
    {
        public ArtGridReports()
        {
            InitializeComponent();
            FillAsnCombo();
        }
        public void FillAsnCombo()
        {
            Transaction.ArtReports artrpt = new Transaction.ArtReports();

            drp_asn.DataSource = artrpt.GetDocumentnumber();
            drp_asn.ValueMember = "pk";
            drp_asn.DisplayMember = "name";
           




        }
        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction.ArtReports artrpt = new Transaction.ArtReports();
           
            DataTable dt = artrpt.GetRollsActionPending("Validation");
            dataGridView1.DataSource = dt;
            ShipitControls.ControlSetupper.UltraGridNormalSetup(dataGridView1);
        }

        private void finalAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction.ArtReports artrpt = new Transaction.ArtReports();

            DataTable dt = artrpt.GetRollsActionPending("Inspection");

            dataGridView1.DataSource = dt;

            ShipitControls.ControlSetupper.UltraGridNormalSetup(dataGridView1);
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Title = "Save an Excel File";
            saveFileDialog1.Filter = "Excel|*.xls|Excel 2010|*.xlsx";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                this.ultraGridExcelExporter1.Export(this.dataGridView1, saveFileDialog1.FileName);
            }
        }

        private void projectionOfPODeliveryDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction.ArtReports artrpt = new Transaction.ArtReports();

            DataTable dt = artrpt.GetRollsActionPending("Grouping");

            dataGridView1.DataSource = dt;

            ShipitControls.ControlSetupper.UltraGridNormalSetup(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Transaction.ArtReports artrpt = new Transaction.ArtReports();

            DataTable dt = artrpt.GetASNREport(int.Parse(drp_asn.SelectedValue.ToString ()));

            dataGridView1.DataSource = dt;

            ShipitControls.ControlSetupper.UltraGridNormalSetup(dataGridView1);



            
        }

        private void groupingCompletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction.ArtReports artrpt = new Transaction.ArtReports();

            DataTable dt = artrpt.GetRollsActionPending("Grouped");

            dataGridView1.DataSource = dt;

            ShipitControls.ControlSetupper.UltraGridNormalSetup(dataGridView1);
        }
    }
}
