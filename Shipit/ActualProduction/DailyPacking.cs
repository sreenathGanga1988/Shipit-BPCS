using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit
{
    public partial class DailyPacking : Form
    {
        Transaction.DataTransaction dttrans = null;
        public DailyPacking()
        {
            InitializeComponent();
            dttrans = new Transaction.DataTransaction();
            loadAtc();
        }
        public void loadAtc()
        {
            try
            {
                DataTable atcnum = dttrans.getAtcnumbers();

                if (atcnum != null)
                {
                    if (atcnum.Rows.Count > 0)
                    {
                        cmb_Atc.DataSource = atcnum;
                        cmb_Atc.DisplayMember = "Atcnum";
                        cmb_Atc.ValueMember = "Atcid";
                    }
                }




            }
            catch (Exception)
            {

                throw;
            }
            //     cmb_factory.ValueMember = "atcmaster";
            //   Buyercombo.DataBind();



        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cmb_PO.Text.Trim() != "")
            {
                tbl_dataentry.Rows.Add();
                int lastrow = tbl_dataentry.RowCount - 1;
                tbl_dataentry.Rows[lastrow].Cells["PO"].Value = cmb_PO.Text.ToString();

                tbl_dataentry.Rows[lastrow].Cells["PackedQty"].Value = "0";
              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmb_Atc.Text.Trim() != "")
            {
                DataTable podata = dttrans.GetPoOfAAtc(cmb_Atc.Text.Trim());
                cmb_PO.Items.Clear();
                cmb_PO.Text = "";
                cmb_PO.Items.Add(cmb_Atc.Text.Trim());
                if (podata != null)
                {
                    if (podata.Rows.Count > 0)
                    {
                        for (int i = 0; i < podata.Rows.Count; i++)
                        {
                            cmb_PO.Items.Add(podata.Rows[i][0].ToString().Trim());
                        }
                    }
                    else
                    {
                        MessageBox.Show("No PO available against this Atc ");
                    }

                }
            }
        }


        private void tbl_dataentry_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            String sCellName = tbl_dataentry.Columns[tbl_dataentry.CurrentCell.ColumnIndex].Name;
            if (sCellName != "PO") //----change with yours
            {

                e.Control.KeyPress += new KeyPressEventHandler(tbl_dataentry_KeyPress);
            }

        }




        private void tbl_dataentry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
     && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dttrans.isDayClosed(dateTimePicker1.Value.Date, Program.lctnpk)==false)
            {
                insertWeeklyPlan();
                MessageBox.Show("Done");
                tbl_dataentry.RowCount = 0;
            }
            else
            {
                MessageBox.Show("Day Closed");
            }


           
        }
        public void insertWeeklyPlan()
        {
            if (validationcontrol())
            {
                for (int i = 0; i < tbl_dataentry.Rows.Count; i++)
                {



                    CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
                    ActualPacked_tbl actualpack = new ActualPacked_tbl();
                    
                    actualpack.DateofPacking= dateTimePicker1.Value.Date;
                    actualpack.PackedQty  = int.Parse(tbl_dataentry.Rows[i].Cells["PackedQty"].Value.ToString());                   
                    actualpack.factid = Program.lctnpk;
                    actualpack.Atcnum = cmb_Atc.Text.Trim();
                    actualpack.POnum = tbl_dataentry.Rows[i].Cells["PO"].Value.ToString().Trim();
                    actualpack.Linenum = cmb_line.Text.ToString();                   
                    actualpack.AddedBy = Program.uername;
                    actualpack.Addeddate = DateTime.Now;                   
                    courdatacontext.ActualPacked_tbls.InsertOnSubmit(actualpack);
                    courdatacontext.SubmitChanges();
                }

            }
        }

        public Boolean validationcontrol()
        {



            Boolean sucess = false;

            if (cmb_Atc.Text.ToString().Trim() == null || cmb_Atc.Text.ToString().ToString().Trim() == "")
            {
                MessageBox.Show("Enter Atc ");
                sucess = false;

            }
            else if (cmb_PO.Text.ToString().Trim() == null || cmb_Atc.Text.ToString().ToString().Trim() == "")
            {
                MessageBox.Show("Enter the PO ");
                sucess = false;
            }
            else if (cmb_line.Text.ToString().Trim() == null || cmb_Atc.Text.ToString().ToString().Trim() == "")
            {
                MessageBox.Show("Enter the Numeric Value ");
                sucess = false;
            }



            for (int i = 0; i < tbl_dataentry.Rows.Count; i++)
            {

                if (tbl_dataentry.Rows[i].Cells["PackedQty"].Value == null || tbl_dataentry.Rows[i].Cells["PackedQty"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Produced Qty not Entered");
                    sucess = false;

                }
               



                else
                {
                    sucess = true;
                }

            }
            return sucess;

        }

        private void tbl_dataentry_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_dataentry.IsCurrentCellDirty)
            {
                tbl_dataentry.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            tbl_dataentry.RowCount = 0;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tbl_dataentry.RowCount = 0;
        }

        private void cmb_line_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbl_dataentry.RowCount = 0;
        }

        private void cmb_Atc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_PO.Items.Clear();
            cmb_PO.Text = "";
        }
    }
}
