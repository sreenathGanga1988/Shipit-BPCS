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
    public partial class ProductionPOSplitter : Form
    {
        Transaction.DataTransaction dttrans = null;
        public ProductionPOSplitter()
        {
            InitializeComponent();
            dttrans = new Transaction.DataTransaction();
        }
        public ProductionPOSplitter(int factid,int lineid,int qty, string linenum, string atcnnum,string ponum,DateTime dateofprod)
        {
            InitializeComponent();
            lbl_atcid.Text = atcnnum;
            lbl_dateofprod.Text = dateofprod.ToString();
            lbl_factid.Text = factid.ToString();
            lbl_linenum.Text=linenum;
            lbl_ponum.Text = ponum;
            lbl_qty.Text = qty.ToString ();
            lbl_lineid.Text = lineid.ToString();
            dttrans = new Transaction.DataTransaction();
            fillPO();
            tbl_dataentry.RowCount = 1;
        }


        public void fillPO()
        {
            DataTable podata = dttrans.GetPoOfAAtc(lbl_atcid.Text.Trim());
            POnum.Items.Clear();
         
            if (podata != null)
            {
                if (podata.Rows.Count > 0)
                {
                    POnum.DataSource = podata;
                    POnum.DisplayMember = "PO#";
                    POnum.ValueMember = "PO#";
                }
                else
                {
                    MessageBox.Show("No PO available against this Atc ");
                }

            }
        }

        private void tbl_dataentry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (tbl_dataentry.Rows.Count >= 0)
                {

                    if (e.RowIndex >= 0)
                    {
                        if (e.ColumnIndex== 2)
                        {

                            tbl_dataentry.Rows.Add();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
            }
        }

        public Boolean validationcontrol()
        {
            Boolean sucess = false;
            int sum = 0;


            for (int i = 0; i < tbl_dataentry.Rows.Count; i++)
            {


                if (tbl_dataentry.Rows[i].Cells[0].Value == null || tbl_dataentry.Rows[i].Cells[0].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Enter PO details");
                    sucess = false;

                }

                else if (tbl_dataentry.Rows[i].Cells[1].Value == null || tbl_dataentry.Rows[i].Cells[1].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Produced Qty not Entered");
                    sucess = false;
                }

                else if (!dttrans.Isnumbericentry(tbl_dataentry.Rows[i].Cells[1].Value.ToString()))
                {
                    MessageBox.Show(" Pos Qty entered is not Numeric");
                    sucess = false;
                }
                else
                {
                    sucess = true;
                }

                sum = sum + int.Parse(tbl_dataentry.Rows[i].Cells[1].Value.ToString());

            }


            if(int.Parse (lbl_qty.Text)!=sum )
            {
                MessageBox.Show(" Pos Qty entered No matching Produced Qty");
                sucess = false;
            }


            return sucess;

        }


     
    
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(validationcontrol ())
            {
                for (int i = 0; i < tbl_dataentry.Rows.Count; i++)
                {



                    CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
                    POProduced actualtaprod = new POProduced();
                   
                    actualtaprod.DateofProd = DateTime.Parse (lbl_dateofprod.Text);
                    actualtaprod.AddedBy = Program.uername;
                    actualtaprod.AddedDate = DateTime.Now ;
                    actualtaprod.POQty = int.Parse(tbl_dataentry.Rows[i].Cells["POQty"].Value.ToString());
                    actualtaprod.POnum = tbl_dataentry.Rows[i].Cells["Ponum"].Value.ToString().Trim ();
                    actualtaprod.AtcNum = lbl_atcid.Text.Trim();
                    actualtaprod.Factid = int.Parse(lbl_factid.Text);
                    actualtaprod.LineNum= lbl_linenum.Text.ToString();
                    actualtaprod.LineID = int.Parse (lbl_lineid.Text);
                  

                   
                    courdatacontext.POProduceds.InsertOnSubmit(actualtaprod);
                    courdatacontext.SubmitChanges();
                }
                MessageBox.Show("Done");
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbl_dataentry.Rows.RemoveAt(this.tbl_dataentry.CurrentRow.Index);
        }
    
    
    
    
    
    
    
    
    
    
    }
}
