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
    public partial class DailyProduction : Form
    {
        Transaction.DataTransaction dttrans = null;
        public DailyProduction()
        {
            InitializeComponent();
            dttrans = new Transaction.DataTransaction();
            loadlinenum();
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
                        cmb_Atc.ValueMember = "AtcId";
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


        public void bindOurstylecombo()
        {
            int atcid = int.Parse(cmb_Atc.SelectedValue.ToString());
            CourierDataDataContext cntxt = new CourierDataDataContext(Program.ArtConnStr);
            var q = from atcname in cntxt.AtcDetails
                    where atcname.AtcId == atcid

                    select atcname;

            cmb_ourStyle.DataSource = q;
            cmb_ourStyle.DisplayMember = "OurStyle";
            cmb_ourStyle.ValueMember = "OurStyleID";


        }




        private void button1_Click(object sender, EventArgs e)
        {
            if (cmb_PO.Text.Trim() != "")
            {
                tbl_dataentry.Rows.Add();
                int lastrow = tbl_dataentry.RowCount - 1;
                tbl_dataentry.Rows[lastrow].Cells["PO"].Value = cmb_PO.Text.ToString();

                tbl_dataentry.Rows[lastrow].Cells["ProducedQty"].Value = "0";
                tbl_dataentry.Rows[lastrow].Cells["Operators"].Value = "0";
                tbl_dataentry.Rows[lastrow].Cells["Helpers"].Value = "0";
                tbl_dataentry.Rows[lastrow].Cells["Hours"].Value = "0";
            }
        }
        public void loadlinenum()
        {
            CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr);
            var q = from fm in cntxt.LineMasters
                    where fm.FactoryID == Program.lctnpk
                    select fm;


            cmb_line.DataSource = q;
            cmb_line.DisplayMember = "LineNum";
            cmb_line.ValueMember = "Lineid";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (cmb_Atc.Text.Trim() != "")
            {
                try
                {
                    bindOurstylecombo();

                }
                catch (Exception)
                {


                }






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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dttrans.isDayClosed(dateTimePicker1.Value.Date,Program.lctnpk)==false)
            {
                insertWeeklyPlan();
                MessageBox.Show("Done");
                tbl_dataentry.RowCount = 0;
            }else
            {
                MessageBox.Show("Day Closed");
            }
        }

        public void insertWeeklyPlan()
        { if (validationcontrol ())
                        {
            for (int i = 0; i < tbl_dataentry.Rows.Count; i++)
            {

               
                       
                            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
                            ActualProduced_tbl actualtaprod = new ActualProduced_tbl();
                            actualtaprod.FctProdID = 0;
                            actualtaprod.DateOfProd = dateTimePicker1.Value.Date;
                            actualtaprod.ProducedQty = int.Parse(tbl_dataentry.Rows[i].Cells["ProducedQty"].Value.ToString());
                            actualtaprod.Helpers = int.Parse(tbl_dataentry.Rows[i].Cells["Helpers"].Value.ToString());
                            actualtaprod.Operators = int.Parse(tbl_dataentry.Rows[i].Cells["Operators"].Value.ToString());
                            actualtaprod.Hours = float .Parse(tbl_dataentry.Rows[i].Cells["Hours"].Value.ToString());
                            actualtaprod.factid = Program.lctnpk;
                            actualtaprod.Atcnum = cmb_Atc.Text.Trim();
                            actualtaprod.Ponum = tbl_dataentry.Rows[i].Cells["PO"].Value.ToString().Trim();
                            actualtaprod.Linenum = cmb_line.Text.ToString();
                            actualtaprod.LineID = int.Parse(cmb_line.SelectedValue.ToString());
                            actualtaprod.AddedBy = Program.uername;
                            actualtaprod.AddedDate = DateTime.Now;                        
                            actualtaprod.OurStyleId = int.Parse(cmb_ourStyle.SelectedValue.ToString());
                            actualtaprod.OurStyle = cmb_ourStyle.Text.ToString();
                    actualtaprod.PackedQty = 0;
                    actualtaprod.Writer = Decimal.Parse(tbl_dataentry.Rows[0].Cells["Writer"].Value.ToString());
                    actualtaprod.Feeder = Decimal.Parse(tbl_dataentry.Rows[0].Cells["Feeder"].Value.ToString());
                    actualtaprod.Bundlemover = Decimal.Parse(tbl_dataentry.Rows[0].Cells["BundleMover"].Value.ToString());
                    actualtaprod.Supervisor = Decimal.Parse(tbl_dataentry.Rows[0].Cells["Supervisor"].Value.ToString());
                    actualtaprod.PE = Decimal.Parse(tbl_dataentry.Rows[0].Cells["PE"].Value.ToString());
                    actualtaprod.Help = Decimal.Parse(tbl_dataentry.Rows[0].Cells["Helper"].Value.ToString());
                    courdatacontext.ActualProduced_tbls.InsertOnSubmit(actualtaprod);
                            courdatacontext.SubmitChanges();
                        }
                    
                }
            }
        

        private void tbl_dataentry_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            String sCellName =  tbl_dataentry.Columns[tbl_dataentry.CurrentCell.ColumnIndex].Name; 
    if  (sCellName != "PO") //----change with yours
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
             else if (cmb_line.Text.ToString().Trim() == null || cmb_Atc.Text.ToString().ToString().Trim()== "")
                {
                    MessageBox.Show("Enter the Numeric Value ");
                    sucess = false;
                }



            for (int i = 0; i < tbl_dataentry.Rows.Count; i++)
            {

                if (tbl_dataentry.Rows[i].Cells["ProducedQty"].Value.ToString().Trim() == null || tbl_dataentry.Rows[i].Cells["ProducedQty"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Produced Qty not Entered");
                    sucess = false;

                }

                else if (tbl_dataentry.Rows[i].Cells["Operators"].Value == null || tbl_dataentry.Rows[i].Cells["Operators"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Enter the Numeric Value for Operator ");
                    sucess = false;
                }
                else if (tbl_dataentry.Rows[i].Cells["Helpers"].Value == null || tbl_dataentry.Rows[i].Cells["Helpers"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Enter the Numeric Value for Helper ");
                    sucess = false;
                }
                else if (tbl_dataentry.Rows[i].Cells["Operators"].Value.ToString().Trim() == "0")
                {
                    MessageBox.Show("Enter Value for Operator greater Than Zero ");
                    sucess = false;
                }
                else if (tbl_dataentry.Rows[i].Cells["ProducedQty"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Enter Value for ProducedQty greater Than Zero ");
                    sucess = false;
                }
                else if (tbl_dataentry.Rows[i].Cells["Hours"].Value == null || tbl_dataentry.Rows[i].Cells["ProducedQty"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Enter the Numeric Value for Hours");
                    sucess = false;

                }

               

                else
                {
                    sucess = true;
                }

            }
            return sucess;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            tbl_dataentry.RowCount = 0;
        }

        private void tbl_dataentry_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_dataentry.IsCurrentCellDirty)
            {
                tbl_dataentry.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void cmb_line_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbl_dataentry.RowCount = 0;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tbl_dataentry.RowCount = 0;

        }

        private void DailyProduction_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Transaction.ClsEmailer.LastCloseDateofFactory();
        }

        private void cmb_Atc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_PO.Items.Clear();
            cmb_PO.Items.Clear();
            cmb_PO.Text = "";
        }

        private void tbl_dataentry_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8)
            {
                calculatehelper();
            }
        }











        public void calculatehelper()
        {
            try
            {

                float helpersum = float.Parse(tbl_dataentry.Rows[0].Cells["Writer"].Value.ToString()) + float.Parse(tbl_dataentry.Rows[0].Cells["Feeder"].Value.ToString()) + float.Parse(tbl_dataentry.Rows[0].Cells["BundleMover"].Value.ToString()) + float.Parse(tbl_dataentry.Rows[0].Cells["Supervisor"].Value.ToString()) + float.Parse(tbl_dataentry.Rows[0].Cells["PE"].Value.ToString())+ float.Parse(tbl_dataentry.Rows[0].Cells["Helper"].Value.ToString());

                tbl_dataentry.Rows[0].Cells["Helpers"].Value = helpersum.ToString();
            }
            catch (Exception)
            {


            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
