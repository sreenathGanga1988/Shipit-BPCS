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
    public partial class PlanningFormDragable : Form
    {
        Transaction.DataTransaction dttrans = null;
        Transaction.PlanTransaction plntrans = null;
        Transaction.AtracoCalaender atcclndr = null;
        DataTable datesavailable = new DataTable();
        DataTable alreadyplanned = new DataTable();
        DataTable linedata = new DataTable();
        public PlanningFormDragable()
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
                DataTable atcnum = dttrans.getAtcnumberforLinePlanning();

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

        }

        private void Btn_showdates_Click(object sender, EventArgs e)
        {

        }



        public void closeAlreadyBookedDays()
        {
            for (int i = 0; i < tbl_lineplanentry.Rows.Count - 1; i++)
            {


            }

        }

        public void showholidaysandOffday()
        {
            for (int i = 0; i < tbl_lineplanentry.Rows.Count - 1; i++)
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
                    for (int i = 0; i < linedata.Rows.Count; i++)
                    {
                        tbl_lineplanentry.Columns[i + 6].HeaderText = linedata.Rows[i][0].ToString();
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

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }



        public void ShowUsedLines()
        {
            for (int i = 0; i < tbl_lineplanentry.Rows.Count; i++)
            {
                DateTime datet = DateTime.Parse(tbl_lineplanentry.Rows[i].Cells["Dateofprod"].Value.ToString());

                for (int j = 6; j < tbl_lineplanentry.ColumnCount; j++)
                {
                    if (alreadyplanned.Rows.Count != 0)
                    {
                        String linenum = tbl_lineplanentry.Columns[j].HeaderText.ToString();
                        object sumObject;
                        sumObject = alreadyplanned.Compute("Sum(TargetQty)", "LineNum='" + linenum + "' and Dateofprod='" + datet + "' ");

                        try
                        {
                            if (int.Parse(sumObject.ToString()) > 0)
                            {
                                tbl_lineplanentry.Rows[i].Cells[j].Style.BackColor = Color.Yellow;


                                DataTable dt = alreadyplanned.Select("LineNum='" + linenum + "' and Dateofprod='" + datet + "' ").CopyToDataTable();

                                string tooltip = "";

                                for (int it = 0; it < dt.Rows.Count; it++)
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
                    if (lbl_previousPlan.Text.Trim() == "")
                    {
                        lbl_previousPlan.Text = "0";
                    }
                }
            }
            catch (Exception)
            {
                lbl_previousPlan.Text = "0";

            }

        }

        private void tbl_lineplanentry_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

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
                lbl_balanceqty.Text = balance.ToString();
            }
            catch (Exception)
            {
                lbl_balanceqty.Text = "0";

            }
        }

        private void tbl_lineplanentry_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void tbl_lineplanentry_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


    }
}
