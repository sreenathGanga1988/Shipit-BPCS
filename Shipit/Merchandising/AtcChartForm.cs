using Shipit.DataModels;
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
    public partial class AtcChartForm : Form
    {
        public AtcChartForm()
        {
            InitializeComponent();


            if (Program.LogType == "Office")
            {
                fillAtc();
            }
            else
            {
                fillonlineAtc();
            }
           
        }
         public void fillAtc()
        {
            using (ArtEntities enty = new ArtEntities())
            {

                var PoQuery = from atcmst in enty .AtcMasters
                             select new
                              {
                                  name = atcmst.AtcNum,
                                  pk = atcmst.AtcId
                              };
                cmb_atc.DataSource = PoQuery.ToList();
                cmb_atc.DisplayMember = "name";
                cmb_atc.ValueMember = "pk";


            }
        }

        public void fillonlineAtc()
        {
            using (ArtEntities enty = new ArtEntities("D"))
            {

                var PoQuery = from atcmst in enty.AtcMasters
                              select new
                              {
                                  name = atcmst.AtcNum,
                                  pk = atcmst.AtcId
                              };
                cmb_atc.DataSource = PoQuery.ToList();
                cmb_atc.DisplayMember = "name";
                cmb_atc.ValueMember = "pk";


            }
        }

        private void btn_showourstyle_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Transaction.Atcchart atcchrt = new Transaction.Atcchart();

            tbl_atcchart.DataSource = atcchrt.GetAtcChart(int.Parse(cmb_atc.SelectedValue.ToString()));
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            MessageBox.Show("Time taken for filling this atchart is(in MS)   " + elapsedMs.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Title = "Save an Excel File";
            saveFileDialog1.Filter = "Excel|*.xls|Excel 2010|*.xlsx";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                this.ultraGridExcelExporter1.Export(this.tbl_atcchart, saveFileDialog1.FileName);
            }
        }
    }
}
