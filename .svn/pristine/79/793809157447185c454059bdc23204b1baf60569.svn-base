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
    public partial class SplitBookingFrm : Form
    {
        public SplitBookingFrm()
        {
            InitializeComponent();
        }
        public SplitBookingFrm(int orderid)
        {
            InitializeComponent();

            filldata(orderid);

        }

        public void filldata(int orderid)
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from order in courdatacontext.OrderBooking_tbls
                    where order.Order_id==orderid
                    select order ;

            foreach (var order1 in q)
            {
                txt_order_id.Text = order1.Order_id.ToString();
                txt_quantity.Text = order1.BookQty.ToString();
                txt_factoryId.Text = order1.Factory_Id.ToString();
                txt_year.Text = order1.Year.ToString();
                txt_month.Text = order1.Month.ToString();
                txt_newQty.Text = order1.BookQty.ToString();
                lbl_buyerid.Text = order1.Buyer_ID.ToString();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_neworder.RowCount = int.Parse (txt_num.Text);
            tbl_neworder.Columns["Qty"].DefaultCellStyle.NullValue = "0";
            tbl_neworder.Columns["Style"].DefaultCellStyle.NullValue = "NA";
        }



        public Boolean  isnumeric(String s)
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

        public void quantityreducer()
        {

            int totalqty = int.Parse(txt_quantity  .Text );
            int newqty = 0;
            for(int i=0;i<tbl_neworder.Rows.Count ;i++)
            {
                if (tbl_neworder.Rows[i].Cells[1].Value.ToString().Trim() != "")
                {
                    newqty = newqty + int.Parse(tbl_neworder.Rows[i].Cells[1].Value.ToString());
                }
            }

            if (newqty > totalqty)
            {
                MessageBox.Show("You have exceeded The Intial Book Qty");
            }

            txt_newQty.Text = (totalqty-newqty).ToString();

        }
         public Boolean validationcontrol()
        {



            Boolean sucess = false;

            for (int i = 0; i < tbl_neworder.Rows.Count; i++)
            {


                if (tbl_neworder.Rows[i].Cells[0].Value == null || tbl_neworder.Rows[i].Cells[0].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Enter Style details");



                }


                else if (tbl_neworder.Rows[i].Cells[1].Value == null || tbl_neworder.Rows[i].Cells[1].Value.ToString().Trim() == "")
                {
                    MessageBox.Show(" Quantity  not entered");



                }
                else
                {
                    sucess = true;
                }

            }
            return sucess;

        }


        public void addnewqty()
         {
           
                 for (int i = 0; i < tbl_neworder.Rows.Count; i++)
                 {
                     CourierDataDataContext curdatacontext = new CourierDataDataContext(Program.ConnStr);
                     OrderBooking_tbl ordrbookin = new OrderBooking_tbl();
                     ordrbookin.Factory_Id = int.Parse(txt_factoryId.Text);
                     ordrbookin.Year = int.Parse(txt_year.Text.Trim());
                     ordrbookin.Month = txt_month.Text.Trim();
                     ordrbookin.BookQty = int.Parse(tbl_neworder.Rows[i].Cells[1].Value.ToString());
                     ordrbookin.Style = tbl_neworder.Rows[i].Cells[0].Value.ToString().Trim();
                     ordrbookin.ISApproved = "N";
                     ordrbookin.Buyer_ID = int.Parse(lbl_buyerid.Text);

                     ordrbookin.UserId = Program.uername;
                     ordrbookin.AddedDate = DateTime.Now.Date;
                     curdatacontext.OrderBooking_tbls.InsertOnSubmit(ordrbookin);
                     curdatacontext.SubmitChanges();

                 }
             
         }

        public void UpdateOldBooking()
        {
            int orderid = int.Parse(txt_order_id .Text);
            CourierDataDataContext countxt = new CourierDataDataContext(Program.ConnStr);
            var q = from orderdtl in countxt.OrderBooking_tbls
                    where orderdtl.Order_id == orderid
                    select orderdtl;
            foreach (var order in q)
            {
                int orderqty = int.Parse(txt_newQty .Text);
                order.BookQty = orderqty;
                countxt.SubmitChanges();
                MessageBox.Show("Done");
                this.Close();
            }
        }
         private void toolStripButton1_Click(object sender, EventArgs e)
         {
             if (int.Parse(txt_quantity.Text) > 0)
             {
                 if (validationcontrol())
                 {
                     UpdateOldBooking();
                     addnewqty();
                 }
             }
             else
             {
                 MessageBox.Show("You have exceeded The Intial Book Qty");
             }

         }   

        private void tbl_neworder_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if(isnumeric (e.FormattedValue.ToString()))
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

        private void tbl_neworder_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_neworder.IsCurrentCellDirty)
            {
                tbl_neworder.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
