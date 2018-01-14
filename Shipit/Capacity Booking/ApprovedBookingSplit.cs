using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.Capacity_Booking
{
    public partial class ApprovedBookingSplit : Form
    {
        public ApprovedBookingSplit()
        {
            InitializeComponent();
        }

        public ApprovedBookingSplit(int bookid)
        {
            InitializeComponent();
            FillBookingDetails(bookid);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_neworder.RowCount = int.Parse(txt_num.Text);
            tbl_neworder.Columns["Qty"].DefaultCellStyle.NullValue = "0";
          
        }


        public void FillBookingDetails(int Book_id)
        {

            
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var delet = from details in couriercontext.FinalBooking_masters
                        where details.Book_Id == Book_id
                        select details;
            foreach (var detail in delet)
            {
                lbl_buyerid.Text = detail.BuyerID.ToString ();
                lbl_factid .Text=detail.Factory_id.ToString ();
                txt_order_id.Text = detail.Order_Id.ToString();
                txt_quantity.Text = detail.BookQty.ToString ();
                lbl_year.Text = detail.Year.ToString();
                lbl_month.Text = detail.Month.ToString();
                lbl_category.Text = detail.ComplexityLevel;
                lbl_consumptionQty.Text = detail.ConsumptionQty.ToString();
                lbl_bookid.Text = detail.Book_Id.ToString();
            }

            loadfactorycombo();
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tbl_neworder.RowCount = int.Parse(txt_num.Text);
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

        private void tbl_neworder_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (isnumeric(e.FormattedValue.ToString()))
                {
                    try
                    {
                        quantityreducer();
                    }
                    catch (Exception)
                    {


                    }
                }
                else
                {
                    e.Cancel = true;

                }
            }
            else if (e.ColumnIndex == 0)
            {
                try
                {
                    String style = e.FormattedValue.ToString();
                }
                catch (Exception)
                {

                    e.Cancel = true;
                }
            }
        }


        public void quantityreducer()
        {

            int totalqty = int.Parse(txt_quantity.Text);
            int newqty = 0;
            for (int i = 0; i < tbl_neworder.Rows.Count; i++)
            {
                if (tbl_neworder.Rows[i].Cells["Qty"].Value.ToString().Trim() != "")
                {
                    newqty = newqty + int.Parse(tbl_neworder.Rows[i].Cells["Qty"].Value.ToString());
                }
            }

            if (newqty > totalqty)
            {
                MessageBox.Show("You have exceeded The Intial Book Qty");
            }

            txt_newQty.Text = (totalqty - newqty).ToString();

        }
        public Boolean isnumeric(String s)
        {
            Boolean isnumeric = true;
            try
            {
                int k = int.Parse(s);
            }
            catch (Exception)
            {
                isnumeric = false;

            }
            return isnumeric;
        }

        private void tbl_neworder_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_neworder.IsCurrentCellDirty)
            {
                tbl_neworder.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            UpdateOldBooking();
            addnewqty();
        }

        /// <summary>
        /// change the Qty of Old Bookid
        /// </summary>
        public void UpdateOldBooking()
        {
            if (txt_newQty.Text.Trim() != "")
            {
                int orderid = int.Parse(txt_order_id .Text);

                CourierDataDataContext countxt = new CourierDataDataContext(Program.ConnStr);
                var q = from orderdtl in countxt.OrderBooking_tbls
                        where orderdtl.Order_id == orderid
                        select orderdtl;
                foreach (var order1 in q)
                {

                    order1.BookQty = int.Parse(txt_newQty .Text.Trim());
                    countxt.SubmitChanges();

                }

                int bookid = int.Parse(lbl_bookid.Text);
                var q1 = from fnlmstr in countxt.FinalBooking_masters
                         where fnlmstr.Book_Id == bookid
                         select fnlmstr;
                foreach (var order in q1)
                {
                    float consumptionqty = (float.Parse(order.ConsumptionQty.ToString()) / float.Parse(order.BookQty.ToString())) * float.Parse(txt_newQty.Text.Trim());
                    order.BookQty = int.Parse(txt_newQty.Text.Trim());
                    order.ConsumptionQty = (int)(consumptionqty);
                    countxt.SubmitChanges();

                }
                Transaction.Actionlog.actiondone("Approved Qty Splitted", "Approved Qty Changed for Bookid " + bookid + " from " + txt_quantity.Text + "to " + txt_newQty.Text);
                MessageBox.Show("Done");
                this.Close();
            }
        }
        public void addnewqty()
        {

            for (int i = 0; i < tbl_neworder.Rows.Count; i++)
            {
                CourierDataDataContext curdatacontext = new CourierDataDataContext(Program.ConnStr);
                OrderBooking_tbl ordrbookin = new OrderBooking_tbl();
                string month = Convert.ToString((tbl_neworder.Rows[i].Cells["Month"] as DataGridViewComboBoxCell).FormattedValue.ToString());
                string Year = Convert.ToString((tbl_neworder.Rows[i].Cells["Year"] as DataGridViewComboBoxCell).FormattedValue.ToString());
                string factid = Convert.ToString((tbl_neworder.Rows[i].Cells["FactoryCombo"].Value.ToString()));
                ordrbookin.Factory_Id = int.Parse(factid);
                ordrbookin.Year = int.Parse(Year);
                ordrbookin.Month = month.Trim();
                ordrbookin.BookQty = int.Parse(tbl_neworder.Rows[i].Cells["Qty"].Value.ToString());
                ordrbookin.Style = tbl_neworder.Rows[i].Cells["Style"].Value.ToString().Trim();
                ordrbookin.ISApproved = "N";
                ordrbookin.Buyer_ID = int.Parse(lbl_buyerid.Text);

                ordrbookin.UserId = Program.uername;
                ordrbookin.AddedDate = DateTime.Now.Date;
                curdatacontext.OrderBooking_tbls.InsertOnSubmit(ordrbookin);
                curdatacontext.SubmitChanges();

            }

        }



    }
}
