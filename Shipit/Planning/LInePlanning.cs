using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.Planning
{    
    public partial class LInePlanning : Form
    {
        Transaction.DataTransaction dttrans = null;
        Transaction.PlanTransaction plntrans = null;
        Transaction.AtracoCalaender atcclndr = null;
        DataTable datesavailable = new DataTable();
        DataTable alreadyplanned = new DataTable();
        DataTable linedata= new DataTable();
        public LInePlanning()
        {
            InitializeComponent();
             dttrans = new Transaction.DataTransaction();
            plntrans = new Transaction.PlanTransaction();
            atcclndr = new Transaction.AtracoCalaender();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void loadAtc()
        {
            try
            {
                DataTable atcnum = dttrans.getAtcnumberforLinePlanning ();

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
        private void LInePlanning_Load(object sender, EventArgs e)
        {
            loadAtc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cmb_Atc.Text.Trim ()!="")
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
                if (podata != null)
                {
                    if (podata.Rows.Count > 0)
                    {
                        for (int i = 0; i < podata.Rows.Count; i++)
                        {
                            cmb_PO .Items.Add(podata.Rows[i][0].ToString().Trim());
                        }
                    }
                    else
                    {
                        MessageBox.Show("No PO available against this Atc ");
                    }

                }
            }
        }

        private void Btn_showdates_Click(object sender, EventArgs e)
        {
            if(cmb_PO.Text.Trim()!="")
            {
                DataTable dt = plntrans.GetPSDAndPDDOFPO(cmb_PO.Text.Trim());

                tbl_lineplanentry.ColumnCount = 6;
                if(dt!=null)
                {
                    if(dt.Rows.Count>0)
                    {
                        try
                        {
                            lblPSD.Text = DateTime.Parse(dt.Rows[0]["PSD"].ToString()).ToString("dd/MM/yyyy");
                            lbl_POdate.Text = DateTime.Parse(dt.Rows[0]["PoDeliverydate"].ToString()).ToString("dd/MM/yyyy");
                            lbl_Qty.Text = dt.Rows[0]["totalqty"].ToString();
                     
                            datesavailable = atcclndr.GetDatesBetweenAPeriod(2005, DateTime.Parse(dt.Rows[0]["PSD"].ToString()), DateTime.Parse(dt.Rows[0]["PoDeliverydate"].ToString()));
                            alreadyplanned = plntrans.GetAllLineplanBetweenDate(DateTime.Parse(dt.Rows[0]["PSD"].ToString()), DateTime.Parse(dt.Rows[0]["PoDeliverydate"].ToString()));
                            linedata = plntrans.GetAllLinesAndCapacityOFAtc(cmb_Atc.Text.ToString());
                            if (alreadyplanned != null)
                            {
                                if (alreadyplanned.Rows.Count > 0)
                                {
                                    ultraGrid1.DataSource = alreadyplanned;
                                }
                            }


                            ShowAlreadyplannedQtyofPO();

                            tbl_lineplanentry.RowCount = 1;
                            for (int i = 0; i < datesavailable.Rows.Count; i++)
                            {
                                tbl_lineplanentry.Rows.Add();
                                tbl_lineplanentry.Rows[i].Cells["Year"].Value = datesavailable.Rows[i]["Year"].ToString();
                                tbl_lineplanentry.Rows[i].Cells["Month"].Value = datesavailable.Rows[i]["Month"].ToString();
                                tbl_lineplanentry.Rows[i].Cells["Dateofprod"].Value = DateTime.Parse(datesavailable.Rows[i]["DateofWeek"].ToString()).ToString("dd/MM/yyyy");
                                 //   datesavailable.Rows[i]["DateofWeek"].ToString();
                                tbl_lineplanentry.Rows[i].Cells["Week"].Value = datesavailable.Rows[i]["Weeknumber"].ToString();
                                tbl_lineplanentry.Rows[i].Cells["WeekDay"].Value = datesavailable.Rows[i]["DayofWeek"].ToString();
                                
                            }
                            gridviewLinesetup(linedata);
                            showholidaysandOffday();
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("PSD or PO Delivery date is not provided Correctly");
                        }
                       
                    }
                    try
                    {
                        ShowUsedLines();
                    }
                    catch (Exception)
                    {
                        
                       
                    }
                }
            }
        }



        public void closeAlreadyBookedDays()
        {
            for (int i = 0; i < tbl_lineplanentry.Rows.Count - 1; i++)
            {


            }

        }

        public void showholidaysandOffday()
        {
            for(int i=0;i<tbl_lineplanentry.Rows.Count-1 ;i++)
            {
                if (tbl_lineplanentry.Rows[i].Cells["WeekDay"].Value.ToString().Trim() == "Sunday")
                {
                tbl_lineplanentry.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                tbl_lineplanentry.Rows[i].ReadOnly = true;
            }

            }
        }

        public void gridviewLinesetup(DataTable linedata)
        {
         if (linedata != null)
                            {
                                if (linedata.Rows.Count > 0)
                                {
                                    tbl_lineplanentry.ColumnCount = tbl_lineplanentry.ColumnCount + linedata.Rows.Count;
                                   for(int i=0;i<linedata.Rows.Count ;i++)
                                   {
                                       tbl_lineplanentry.Columns[i + 6].HeaderText  = linedata.Rows[i][0].ToString();
                                       tbl_lineplanentry.Columns[i + 6].DefaultCellStyle.NullValue = "0";
                                       tbl_lineplanentry.Columns[i + 6].Name = linedata.Rows[i][1].ToString();
                                   }
                                }


                            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
          //  MessageBox.Show("Null");
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_lineplanentry.IsCurrentCellDirty)
            {
                tbl_lineplanentry.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(tbl_lineplanentry.Rows.Count >0)
            {
                for (int i = 0; i < tbl_lineplanentry.Rows.Count ; i++)
                {
                    if (Convert.ToBoolean(tbl_lineplanentry.Rows[i].Cells[0].Value) == true)
                    {
                        for (int j = 6; j < tbl_lineplanentry.ColumnCount; j++)
                        {

                            if (tbl_lineplanentry.Rows[i].Cells[j].Value != null && tbl_lineplanentry.Rows[i].Cells[j].Value.ToString().Trim() != "" && tbl_lineplanentry.Rows[i].Cells[j].Value.ToString().Trim() != "0")
                            {
                                CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
                                FactoryWeeklyPlan_tbl wkplanmstr = new FactoryWeeklyPlan_tbl();
                                wkplanmstr.Factid = Program.lctnpk;
                                wkplanmstr.Year = int.Parse(tbl_lineplanentry.Rows[i].Cells["Year"].Value.ToString());
                                wkplanmstr.Month = tbl_lineplanentry.Rows[i].Cells["Month"].Value.ToString();
                                wkplanmstr.Weeknum = tbl_lineplanentry.Rows[i].Cells["Week"].Value.ToString();
                                wkplanmstr.Ponum = cmb_PO.Text;
                                wkplanmstr.WeekID = 0;
                                wkplanmstr.OurStyle = cmb_ourStyle.Text;
                                wkplanmstr.LineID = int.Parse(tbl_lineplanentry.Columns[j].Name.ToString());
                                wkplanmstr.LineNum = tbl_lineplanentry.Columns[j].HeaderText.ToString();
                                wkplanmstr.DateofProd = DateTime.Parse(tbl_lineplanentry.Rows[i].Cells["DateofProd"].Value.ToString());
                                wkplanmstr.AddedBy = Program.uername;
                                wkplanmstr.AddedDate = DateTime.Now;
                                wkplanmstr.AtcNum = cmb_Atc.Text.Trim();
                                wkplanmstr.Atc_id= int.Parse(cmb_Atc.SelectedValue.ToString());
                                wkplanmstr.TargetQty = int.Parse(tbl_lineplanentry.Rows[i].Cells[j].Value.ToString());
                                courdatacontext.FactoryWeeklyPlan_tbls.InsertOnSubmit(wkplanmstr);
                                courdatacontext.SubmitChanges();
                            }
                        }
                    }
                }
                }
            MessageBox.Show("Done");
            tbl_lineplanentry.ColumnCount = 6;
            }



        public void ShowUsedLines()
        {
            for(int i=0;i<tbl_lineplanentry.Rows.Count;i++)
            {
                DateTime datet = DateTime .Parse ( tbl_lineplanentry.Rows[i].Cells["Dateofprod"].Value.ToString());

                for (int j = 6; j < tbl_lineplanentry.ColumnCount; j++)
                {
                    if (alreadyplanned.Rows.Count != 0)
                    {
                    String linenum=    tbl_lineplanentry.Columns[j].HeaderText.ToString();
                        object sumObject;
                        sumObject = alreadyplanned.Compute("Sum(TargetQty)", "LineNum='" + linenum + "' and Dateofprod='" + datet + "' ");
                        
                        try
                        {
                            if (int.Parse(sumObject.ToString()) > 0)
                            {
                                tbl_lineplanentry.Rows[i].Cells[j].Style.BackColor = Color.Yellow;


                                DataTable dt= alreadyplanned.Select("LineNum='" + linenum + "' and Dateofprod='" + datet + "' ").CopyToDataTable();

                                string tooltip = "";

                                for(int it=0;it<dt.Rows.Count;it++)
                                {
                                    
                                       tooltip = tooltip + dt.Rows[it]["AtcNum"].ToString() + "  / " + dt.Rows[it]["Ponum"].ToString() + "  / " + dt.Rows[it]["TargetQty"].ToString() + "PCS" + System.Environment.NewLine;
                                }
                                tbl_lineplanentry.Rows[i].Cells[j].Value = sumObject.ToString();
                                tbl_lineplanentry.Rows[i].Cells[j].ToolTipText = tooltip;
                            }
                        }
                        catch (Exception)
                        {
                            
                          
                        }
                    }
                }
            }
        }

       /// <summary>
        ///  Shows the Already Planned Qty of PO
       /// </summary>

        public void ShowAlreadyplannedQtyofPO()
        {



            try
            {
                if (alreadyplanned.Rows.Count != 0)
                {
                    object sumObject;
                    sumObject = alreadyplanned.Compute("Sum(TargetQty)", "Ponum='" + cmb_PO.Text.Trim() + "'");

                    lbl_previousPlan.Text = sumObject.ToString();
                    if( lbl_previousPlan.Text.Trim ()=="")
                    {
                        lbl_previousPlan.Text = "0";
                    }
                }
            }
            catch (Exception)
            {
                lbl_previousPlan.Text  ="0";
               
            }
           
        }

        private void tbl_lineplanentry_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int total = 0;

            try
            {
                for (int i = 0; i < tbl_lineplanentry.Rows.Count; i++)
                {
                    for (int j = 6; j < tbl_lineplanentry.ColumnCount; j++)
                    {

                        if (tbl_lineplanentry.Rows[i].Cells[j].Value != null && tbl_lineplanentry.Rows[i].Cells[j].Value.ToString().Trim() != "" && tbl_lineplanentry.Rows[i].Cells[j].Value.ToString().Trim() != "0")
                        {
                            total = total + int.Parse(tbl_lineplanentry.Rows[i].Cells[j].Value.ToString());
                        }
                    }


                }
            }
            catch (Exception)
            {
                
                
            }


                lbl_newbooked.Text = total.ToString();
                CalculateRemaingQty();
        }
    
       /// <summary>
       /// show remaining qty for booking
       /// Balance=bookqty-(alreadybooked+ now Added)
       /// </summary>
        public void CalculateRemaingQty()
        {
            try
            {
                if (lbl_previousPlan.Text.Trim() == "")
                {
                    lbl_previousPlan.Text = "0";
                }
                int totalqty = int.Parse(lbl_Qty.Text);

                int alreadyplannedqty = int.Parse(lbl_previousPlan.Text);

                int addedqty = int.Parse(lbl_newbooked.Text);

                int balance = (totalqty - (alreadyplannedqty + addedqty));
                lbl_balanceqty.Text = balance.ToString ();
            }
            catch (Exception)
            {
                lbl_balanceqty.Text = "0";
               
            }
        }

        private void tbl_lineplanentry_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
          
            if (tbl_lineplanentry.CurrentCell.ColumnIndex>5) //----change with yours
            {

                e.Control.KeyPress += new KeyPressEventHandler(tbl_lineplanentry_KeyPress);
            }
        }

        private void tbl_lineplanentry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
     && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    
    
    }
}
