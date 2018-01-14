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
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
namespace Shipit.Reports
{
    public partial class AtcLinePlanrReportfrm : Form
    {
        Transaction.DataTransaction dttrans = null;
        Transaction.PlanTransaction plntrans = null;
        public AtcLinePlanrReportfrm()
        {
            InitializeComponent();
            dttrans = new Transaction.DataTransaction();
            plntrans = new Transaction.PlanTransaction();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillLinplanOfAtc();
        }

        public void FillLinplanOfAtc()
        {
           
                if (cmb_Atc.Text.Trim() != "")
                {
                    CourierDetailsDataSetTableAdapters.LineDataPreviewTableAdapter adapt = new LineDataPreviewTableAdapter();
                    adapt.Connection.ConnectionString = Program.ConnStr;

                    ultraGrid1.DataSource = null;
                    ultraGrid1.Text = "Line Plan";
                    DataTable dt = adapt.GetDataByAtc(cmb_Atc.Text);
                    ultraGrid1.DataSource = dt;
                    UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                    band.Override.AllowRowFiltering = DefaultableBoolean.True;
                    band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
                }

           
        }

        public void FillCapacityOfAtc()
        {

            if (cmb_Atc.Text.Trim() != "")
            {
                CourierDetailsDataSetTableAdapters.AtcLineCapacityTableAdapter adapt = new AtcLineCapacityTableAdapter();
                adapt.Connection.ConnectionString = Program.ConnStr;

                ultraGrid1.DataSource = null;
                ultraGrid1.Text = "Atc Capacity";
                DataTable dt = adapt.GetDataByAtc(cmb_Atc.Text.Trim ());
                ultraGrid1.DataSource = dt;
                UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            }


        }

        public void loadAtc()
        {
            try
            {
                DataTable atcnum = dttrans.getAtcnumbers();

                if(atcnum!=null)
                {
                    if(atcnum.Rows.Count>0)
                    {
                     for(int i=0;i<atcnum.Rows.Count;i++)
                     {
                         cmb_Atc.Items.Add(atcnum.Rows[i][0].ToString().Trim());
                     }
                    }
                }
                

               
                
            }
            catch (Exception )
            {
                
                throw;
            }
       //     cmb_factory.ValueMember = "atcmaster";
            //   Buyercombo.DataBind();



        }

        private void AtcLinePlanrReportfrm_Load(object sender, EventArgs e)
        {
            loadAtc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FillCapacityOfAtc();
        }



        public void AtcCapacityRemover()
        {
           int lineplanid = int.Parse(ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["LinCapID"].Value.ToString());
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var q = from lineplan in couriercontext.LineAtcCapacity_tbls
                    where lineplan.LinCapID == lineplanid
                    select lineplan;

            foreach (var detail in q)
            {
                couriercontext.LineAtcCapacity_tbls .DeleteOnSubmit(detail);
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
        private void deleteCapacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ultraGrid1.Text == "Atc Capacity")
            {
                AtcCapacityRemover();
            }
            else
            {

            }
        }

    }
}
