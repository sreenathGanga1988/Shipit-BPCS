﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shipit
{
    public partial class BookingChanges : Form
    {
        QuantityCalcuulater qtycal = null;
        Transaction.DataTransaction dtrans = null;
        String year = "";
        String month = "";
        ArrayList orderdetail = new ArrayList();
        public BookingChanges()
        {
            InitializeComponent();
        }

        public BookingChanges(int bookid)
        {
            InitializeComponent();
            lbl_atcchangebookid.Text = bookid.ToString ();
            tabControl1.SelectedTab = tb_atc;
            LoadAtcnum();

        }

        /// <summary>
        /// changing factory
        /// </summary>
        /// <param name="bookid"></param>
        /// <param name="currentfact"></param>
        /// 
        public BookingChanges(int bookid,String currentfact)
        {
            InitializeComponent();
            tabControl1.SelectedTab = tb_factory;
            lbl_orderid.Text = bookid.ToString();
            lbl_currentvalue.Text = currentfact;
            LoadFactoryCombo();
            dtrans = new Transaction.DataTransaction();
        }
        /// <summary>
        /// changing complexity of Approved
        /// </summary>
        /// <param name="bookid"></param>
        /// <param name="currentcomplexity"></param>
        /// <param name="consumptionqty"></param>
        public BookingChanges(int bookid, String currentcomplexity, int consumptionqty,DateTime dummydate)
        {
            InitializeComponent();
            qtycal = new QuantityCalcuulater();
            tabControl1.SelectedTab = tbl_category ;
            lbl_catchangeBookid.Text = bookid.ToString();
                lbl_currentcategory.Text=currentcomplexity.ToString();
            dtrans = new Transaction.DataTransaction();
            loadcategory();
        }
        /// <summary>
        /// change Qty of order
        /// </summary>
        /// <param name="bookid"></param>
        /// <param name="currentfact"></param>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <param name="currentqty"></param>
        public BookingChanges(int bookid, String currentfact,String Year,String Month,int currentqty)
        {
            InitializeComponent();
            tabControl1.SelectedTab = tb_qty;
            lbl_orderidforqty .Text = bookid.ToString();
            lbl_fct .Text = currentfact;
            lbl_currentQty.Text = currentqty.ToString();
            year = Year;
            month = Month;
            dtrans = new Transaction.DataTransaction();

            
        }
        /// <summary>
        /// change Qty of Approved Booking
        /// </summary>
        /// <param name="bookid"></param>
        /// <param name="orderid"></param>
        /// <param name="qty"></param>
        /// <param name="consumption"></param>
        public BookingChanges(int bookid, int orderid,int qty,int consumption)
        {
            InitializeComponent();
            tabControl1.SelectedTab = tb_approvedqty ;
            lbl_aapporderid.Text = orderid.ToString();
            lbl_appbookid.Text = bookid.ToString ();
            lbl_apprvdqty.Text = qty.ToString();
            lbl_consumption.Text = consumption.ToString ();
            dtrans = new Transaction.DataTransaction();


        }
        /// <summary>
        /// change factory of Approved Booking
        /// </summary>
        /// <param name="bookid"></param>
        /// <param name="orderid"></param>
        /// <param name="currentfact"></param>
        /// <param name="arry"></param>
         public BookingChanges(int bookid, int orderid,String currentfact,ArrayList arry)
        {
            InitializeComponent();
            tabControl1.SelectedTab = tb_Appfact ;
            lbl_appforfactorderid.Text = orderid.ToString ();
            lblappforfactbookid.Text = bookid.ToString();
            lbl_currentfactforfact.Text = currentfact.ToString();
            LoadappFactoryCombo();
            orderdetail = arry;
             
        }

      
        /// <summary>
        /// change the style of Order
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="curentstyle"></param>
        /// <param name="asd"></param>
        public BookingChanges(int orderid, String curentstyle,int asd)
        {
            InitializeComponent();
            tabControl1.SelectedTab = tb_style ;
            lbl_currentstyleBookid.Text = orderid.ToString();
            lbl_currentstyle.Text = curentstyle;


        }
        public void LoadFactoryCombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from fctry in courdatacontext.Factory_Masters
                    select fctry;



            cmb_factory.DataSource = q;
            cmb_factory.DisplayMember = "Factory_name";
            cmb_factory.ValueMember = "Factory_ID";
            //   Buyercombo.DataBind();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            int factoryid = int.Parse(cmb_factory.SelectedValue.ToString());
            int orderid = int.Parse(lbl_orderid.Text.ToString());

            int balance = dtrans.getbalance(orderid, factoryid);
            int orderqty = 0;

            if (balance > 0)
            {
                MessageBox.Show("Balance Available is " +balance .ToString ());

                CourierDataDataContext countxt = new CourierDataDataContext(Program.ConnStr);
                var q = from orderdtl in countxt.OrderBooking_tbls
                        where orderdtl.Order_id == orderid
                        select orderdtl;
                foreach (var order in q)
                {

                    orderqty = int.Parse(order.BookQty .ToString());
                    if (balance - orderqty >= 0)
                    {

                        order.Factory_Id = int.Parse (factoryid.ToString ());
                        countxt.SubmitChanges();
                        MessageBox.Show("Done");
                        this.Close();
                    }


                    else
                    {
                        MessageBox.Show("Not enough quantity to accumalate ther Order ");
                    }
                }

               



                

            }
            else
            {
                MessageBox.Show("No Balance Capacity available in the Location");
            }
        }













        public void LoadAtcnum()
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);

            var q = from cust in couriercontext.Atc_masters
                    select cust;



            cmb_atc .DataSource = q;
            cmb_atc.DisplayMember = "AtcNum";
            cmb_atc.ValueMember = "Atc_id";
            ////   Buyercombo.DataBind();



        }



        private void button2_Click(object sender, EventArgs e)
        {
         if( validationcontrol())
            {
                int orderid = int.Parse ( lbl_orderidforqty.Text);
               CourierDataDataContext countxt = new CourierDataDataContext(Program.ConnStr);
                var q = from orderdtl in countxt.OrderBooking_tbls
                        where orderdtl.Order_id == orderid
                        select orderdtl;
                foreach (var order in q)
                {
                    int   orderqty = int.Parse(txt_newqty.Text);
                    order.BookQty = orderqty;
                    countxt.SubmitChanges();
                    MessageBox.Show("Done");
                    this.Close();
                }


            }

            
        }


        public Boolean iscorrectentry()
        {
            Boolean iscorrect = false;

            try
            {
                int asd = int.Parse(txt_newqty.Text);
                iscorrect = true;
            }
            catch (Exception )
            {
                iscorrect = false;
               
            }
            return iscorrect;

        }


        public Boolean isqtyok()
        {



            Boolean sucess = false;


           

            int blance = dtrans.getbalancebyfactoryname(lbl_fct.Text.Trim(), int.Parse ( year), month.Trim ());
            int currentqty = int.Parse(lbl_currentQty.Text);
            blance = blance + currentqty;

            if (blance < int.Parse(txt_newqty.Text))
            {
               
            }
            else
            {
                sucess = true;
            }


            if (currentqty > int.Parse(txt_newqty.Text))
            {
                sucess = true;
            }

            return sucess;
        }


        public Boolean validationcontrol()
        {



            Boolean sucess = false;

            if (txt_newqty.Text == null || txt_newqty.Text == "")
            {
                MessageBox.Show("Error In factory details");

            }

            else if (!iscorrectentry())
            {
                MessageBox.Show("Enter the correct Data");
            }
            else if (!isqtyok())
            {
                MessageBox.Show("No Capacity Available");
            }

            else
            {
                sucess = true;
            }


            return sucess;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string isapproved = "";
            if (txt_style.Text.Trim()!="")
            {
                int orderid = int.Parse(lbl_currentstyleBookid .Text);
                CourierDataDataContext countxt = new CourierDataDataContext(Program.ConnStr);
                var q = from orderdtl in countxt.OrderBooking_tbls
                        where orderdtl.Order_id == orderid
                        select orderdtl;
                foreach (var order in q)
                {
                   
                    order.Style = txt_style.Text.Trim ();
                    if(order.ISApproved.Trim ()=="A")
                    {
                        isapproved = "A";
                    }
                    countxt.SubmitChanges();
                    MessageBox.Show("Done Updating Enquiry");
                    this.Close();
                }
                if(isapproved=="A")
                {
                    DialogResult result = MessageBox.Show("Do you want to change the Style of the Approved Booking Whose Po Allocation May be done?", "Alert",
        MessageBoxButtons.OKCancel);
                    switch (result)
                    {
                        case DialogResult.OK:
                            {
                                var q1 = from bookingtbl in countxt.FinalBooking_masters
                                         where bookingtbl.Order_Id == orderid
                                         select bookingtbl;
                            foreach (var order in q1)
                            {
                                order.Style = txt_style.Text.Trim();
                                countxt.SubmitChanges();
                                MessageBox.Show("Done Updating Booking");
                            }
                               
                                break;
                            }
                        case DialogResult.Cancel:
                            {
                               
                                break;
                            }
                    }
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txt_approvedqty .Text.Trim() != "")
            {
                int orderid = int.Parse(lbl_aapporderid .Text);

                CourierDataDataContext countxt = new CourierDataDataContext(Program.ConnStr);
                var q = from orderdtl in countxt.OrderBooking_tbls
                        where orderdtl.Order_id == orderid
                        select orderdtl;
                foreach (var order in q)
                {

                    order.BookQty = int.Parse( txt_approvedqty.Text.Trim());
                    countxt.SubmitChanges();
                   
                }

                int bookid = int.Parse(lbl_appbookid .Text);
                var q1 = from fnlmstr in countxt.FinalBooking_masters
                         where fnlmstr.Book_Id == bookid
                         select fnlmstr;
                foreach (var order in q1)
                {
                    float consumptionqty = (float.Parse(order.ConsumptionQty.ToString()) / float.Parse(order.BookQty.ToString())) * float.Parse(txt_approvedqty.Text.Trim());
                    order.BookQty  = int.Parse(txt_approvedqty.Text.Trim());
                    order.ConsumptionQty = (int)(consumptionqty) ;
                    countxt.SubmitChanges();

                }
                Transaction.Actionlog.actiondone("Approved Qty changed", "Approved Qty Changed for Bookid " + bookid + " from " + lbl_apprvdqty .Text + "to " + txt_approvedqty .Text);
                MessageBox.Show("Done");
                this.Close();
            }

        }

        private void BookingChanges_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(cmb_factory1.Text!="")
            {
                changeAppfactory();
                Transaction.ClsEmailer.factorychangingNotifier(orderdetail[2].ToString(), orderdetail[3].ToString(), orderdetail[4].ToString(), orderdetail[0].ToString(), orderdetail[1].ToString(), cmb_factory1.Text.ToString());
                Transaction.Actionlog.actiondone("Production Factory Change", "Approved factory Changed for "+ lblappforfactbookid.Text+ " from "+lbl_currentfactforfact.Text+"to "+cmb_factory1.Text );
                this.Close();
            }
        }


        public void changeAppfactory()
        {
             
            int Book_Id = int.Parse( lblappforfactbookid.Text);
            int Order_id = int.Parse(lbl_appforfactorderid.Text);
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var delet = from details in couriercontext.FinalBooking_masters
                        where details.Book_Id == Book_Id
                        select details;
            foreach (var detail in delet)
            {
                detail.Factory_id = int.Parse(cmb_factory1.SelectedValue.ToString());
            }

            try
            {
                couriercontext.SubmitChanges();
            }
            catch (Exception)
            {
            }


            var delet1 = from details1 in couriercontext.OrderBooking_tbls
                         where details1.Order_id == Order_id
                         select details1;

            foreach (var detail in delet1)
            {
                detail.Factory_Id =  int.Parse(cmb_factory1.SelectedValue.ToString());
            }

            try
            {
                couriercontext.SubmitChanges();
            }
            catch (Exception)
            {
            }

        }


        public void loadcategory()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from category in courdatacontext.Category_Masters
                    select category;



            cmb_category .DataSource = q;
            cmb_category.DisplayMember = "CategoryName";
            cmb_category.ValueMember = "CategoryIID";
            //   Buyercombo.DataBind();



        }







        public void LoadappFactoryCombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from fctry in courdatacontext.Factory_Masters
                    select fctry;



            cmb_factory1.DataSource = q;
            cmb_factory1.DisplayMember = "Factory_name";
            cmb_factory1.ValueMember = "Factory_ID";
            //   Buyercombo.DataBind();



        }

        private void button6_Click(object sender, EventArgs e)
        {
            int Book_Id = int.Parse(lbl_catchangeBookid.Text);
            int catgid = int.Parse(cmb_category.SelectedValue.ToString());
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var delet = from details in courdatacontext.FinalBooking_masters
                        where details.Book_Id == Book_Id
                        select details;
            foreach (var detail in delet)
            {
                detail.CategoryID = catgid;
                detail.ComplexityLevel = cmb_category.Text.ToString();
                detail.ConsumptionQty = qtycal.calculatedata(catgid,int.Parse ( detail.Factory_id.ToString ()) , int.Parse ( detail.BookQty.ToString ()) );
                Transaction.Actionlog.actiondone("Category Changed", "Approved category  Changed for " + Book_Id.ToString() + " from " + lbl_currentcategory .Text  + "to " + cmb_category.Text);
              
            }
            try
            {
                courdatacontext.SubmitChanges();
            }
            catch (Exception)
            {
            }

            MessageBox.Show("Done");
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String oldatc = "";
            int Book_Id = int.Parse(lbl_atcchangebookid.Text);
           
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var delet = from details in courdatacontext.FinalBooking_masters
                        where details.Book_Id == Book_Id
                        select details;
            foreach (var detail in delet)
            {

                oldatc = detail.AtcNO;
                detail.AtcNO = cmb_atc.Text;
                

                
                Transaction.Actionlog.actiondone("Atc Changed", "Approved Atc  Changed for " + Book_Id.ToString() + " from  "+oldatc +" to " + cmb_atc .Text);

            }
            try
            {
                courdatacontext.SubmitChanges();
            }
            catch (Exception)
            {
            }

        }

    }
}
