using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shipit.Production
{
    public partial class ProductionReport : Form
    {
        Transaction.DataTransaction trans = null;
      //  Transaction.DataExporter DTPEXPTR = null;
       String type = "";

        public ProductionReport()
        {
            InitializeComponent();
            type = "normal";
            trans = new Transaction.DataTransaction();
            loadfactorycombo();
        }


        public void loadfactorycombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from factory in courdatacontext.Factory_Masters
                    select factory;



            factorycombo.DataSource = q;
            factorycombo.DisplayMember = "Factory_name";
            factorycombo.ValueMember = "Factory_ID";
            //   Buyercombo.DataBind();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ( factorycombo.Text.Trim() != "")
            {

                DataTable dt = trans.GetPOwiseProductionofamonth(dtp_from.Value.Date , dtp_to.Value.Date,int.Parse(factorycombo.SelectedValue.ToString()));

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Text = "Production";

                }
            }

        }

        private void factorycombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if(dataGridView1.Text.Trim ()=="Packing")
            {
                Packingremover();
            }
            else if(dataGridView1.Text.Trim ()=="Production")
            {
                ProductionRemover();
            }
           
        }

        public void ProductionRemover()
        {
            int ProducedID = int.Parse(dataGridView1.Rows[dataGridView1.ActiveRow.Index].Cells["ProducedID"].Value.ToString());
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var q = from productiondata in couriercontext.ActualProduced_tbls
                    where productiondata.ProducedID == ProducedID
                    select productiondata;

            foreach (var detail in q)
            {
                couriercontext.ActualProduced_tbls.DeleteOnSubmit(detail);
            }

            try
            {
                couriercontext.SubmitChanges();
            }
            catch (Exception)
            {

                
            }

            MessageBox.Show("Done");

        }


        public void Packingremover()
        {
            int pacid = int.Parse(dataGridView1.Rows[dataGridView1.ActiveRow.Index].Cells["PackID"].Value.ToString());
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var q = from pa in couriercontext.ActualPacked_tbls
                    where pa.PackID == pacid
                    select pa;

            foreach (var detail in q)
            {
                couriercontext.ActualPacked_tbls.DeleteOnSubmit(detail);
            }

            try
            {
                couriercontext.SubmitChanges();
            }
            catch (Exception)
            {


            }

            MessageBox.Show("Done");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (factorycombo.Text.Trim() != "")
            {

                DataTable dt = trans.GetPOwisePackingofamonth(dtp_from.Value.Date, dtp_to.Value.Date, int.Parse(factorycombo.SelectedValue.ToString()));

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Text = "Packing";

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (factorycombo.Text.Trim() != "")
            {

                DataTable dt = trans.GetPOwiseProdofamonth(dtp_from.Value.Date, dtp_to.Value.Date, int.Parse(factorycombo.SelectedValue.ToString()));

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Text = "Packing";

                }
            }
        }
    }
}
