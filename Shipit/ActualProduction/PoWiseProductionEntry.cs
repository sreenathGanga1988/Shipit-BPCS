using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.ActualProduction
{
    public partial class PoWiseProductionEntry : Form
    {
        Transaction.DataTransaction dttrans = null;
        public PoWiseProductionEntry()
        {
            InitializeComponent();
            dttrans = new Transaction.DataTransaction();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = dttrans.GetProductionPoPending(dtp_fromdate.Value.Date, dtp_todate.Value.Date, Program.lctnpk);
            ultraGrid1.DataSource = dt;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int factid = int.Parse(ultraGrid1.Rows[ultraGrid1.ActiveCell.Row.Index].Cells["factid"].Value.ToString());
                int lineid = int.Parse(ultraGrid1.Rows[ultraGrid1.ActiveCell.Row.Index].Cells["lineid"].Value.ToString());
                int producedQty = int.Parse(ultraGrid1.Rows[ultraGrid1.ActiveCell.Row.Index].Cells["producedQty"].Value.ToString());
                String Linenum = ultraGrid1.Rows[ultraGrid1.ActiveCell.Row.Index].Cells["Linenum"].Value.ToString();
                String ponum = ultraGrid1.Rows[ultraGrid1.ActiveCell.Row.Index].Cells["Ponum"].Value.ToString();
                String Atcnum = ultraGrid1.Rows[ultraGrid1.ActiveCell.Row.Index].Cells["Atcnum"].Value.ToString();
                DateTime dateofprod = DateTime.Parse(ultraGrid1.Rows[ultraGrid1.ActiveCell.Row.Index].Cells["DateOfProd"].Value.ToString());


                ActualProduction.ProductionPOSplitter pps = new ProductionPOSplitter(factid,lineid,producedQty, Linenum, Atcnum, ponum, dateofprod);
                pps.ShowDialog();
            }
            catch (Exception)
            {
                
               
            }
        }
    }
}
