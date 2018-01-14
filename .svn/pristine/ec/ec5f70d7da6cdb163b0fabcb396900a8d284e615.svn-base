using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient ;
namespace Shipit
{
    public partial class BokkingConfirmation : Form
    {
        QuantityCalcuulater qtycal = null;
        Transaction.DataTransaction dttran = null;
        public BokkingConfirmation()
        {
            InitializeComponent();
            Showdata();
            loadcategory();
           
            qtycal = new QuantityCalcuulater();
            dttran = new Transaction.DataTransaction();
            LoadAtcnum();
        }

        private void BokkingConfirmation_Load(object sender, EventArgs e)
        {
            loadbuyercombo();
            loadfactorycombo();
          
        }



        public void loadcategory()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from category  in courdatacontext.Category_Masters
                    select category;



            cmbcomplex.DataSource = q;
            cmbcomplex.DisplayMember = "CategoryName";
            cmbcomplex.ValueMember = "CategoryIID";
            //   Buyercombo.DataBind();



        }

        public void LoadAtcnum()
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);

            var q = from cust in couriercontext.Atc_masters
                    select cust;



            AtcNO.DataSource = q;
            AtcNO.DisplayMember = "AtcNum";
            AtcNO.ValueMember = "Atc_id";
            ////   Buyercombo.DataBind();



        }




        public void Showdata()
        {
           
                tbl_bookdata.RowCount = 1;

                
             
                DataTable dt = new DataTable();
                dt = GetBookings();

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        tbl_bookdata.RowCount = dt.Rows.Count;


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            tbl_bookdata.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();// Bookid
                            tbl_bookdata.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();//factoryid
                            tbl_bookdata.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();//factoryname
                            tbl_bookdata.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();//baseqty
                            tbl_bookdata.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString(); //year
                             tbl_bookdata.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();// month
                            tbl_bookdata.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();//booked qty
                            tbl_bookdata.Rows[i].Cells[7].Value = dt.Rows[i][7].ToString();//approval pending
                            tbl_bookdata.Rows[i].Cells[8].Value = dt.Rows[i][8].ToString();//buyer
                            tbl_bookdata.Rows[i].Cells[9].Value = dt.Rows[i][9].ToString(); //style

                            tbl_bookdata.Rows[i].Cells[14].Value = dt.Rows[i][11].ToString();
                            tbl_bookdata.Rows[i].Cells[15].Value = dt.Rows[i][12].ToString();
                        }

                        
                    }
                }

            

        }


        public void showalloffbuyer(String Querystring)
        {
            tbl_bookdata.RowCount = 1;



            DataTable dt = new DataTable();
            dt = GetBookings();
            try
            {
                DataTable results = dt.Select(Querystring).CopyToDataTable();
                //   DataTable results = dt.Select("BuyerName = '" + Buyer+"'").CopyToDataTable();
                dt = results;
            }
            catch (Exception)
            {

                MessageBox.Show("No Pending Booking for Approval on this Search Criteria");
            }
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    tbl_bookdata.RowCount = dt.Rows.Count;


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        tbl_bookdata.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();// Bookid
                        tbl_bookdata.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();//factoryid
                        tbl_bookdata.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();//factoryname
                        tbl_bookdata.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();//baseqty
                        tbl_bookdata.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString(); //year
                        tbl_bookdata.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();// month
                        tbl_bookdata.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();//booked qty
                        tbl_bookdata.Rows[i].Cells[7].Value = dt.Rows[i][7].ToString();//approval pending
                        tbl_bookdata.Rows[i].Cells[8].Value = dt.Rows[i][8].ToString();//buyer
                        tbl_bookdata.Rows[i].Cells[9].Value = dt.Rows[i][9].ToString(); //style

                        tbl_bookdata.Rows[i].Cells[14].Value = dt.Rows[i][11].ToString();
                        tbl_bookdata.Rows[i].Cells[15].Value = dt.Rows[i][12].ToString();
                    }


                }
            }


        }


        public Boolean validationcontrol(int i)
        {



            Boolean sucess = false;

            if (tbl_bookdata.Rows[i].Cells[10].Value == null || tbl_bookdata.Rows[i].Cells[10].Value.ToString().Trim() == "")
            {
                MessageBox.Show("Enter Complexity details");



            }


            else if (tbl_bookdata.Rows[i].Cells[11].Value == null || tbl_bookdata.Rows[i].Cells[11].Value.ToString().Trim() == "")
            {
                MessageBox.Show("Actual Quantity to book not entered");



            }
            else if (tbl_bookdata.Rows[i].Cells[16].Value == null || tbl_bookdata.Rows[i].Cells[16].Value.ToString().Trim() == "")
            {
                MessageBox.Show("Atc# not entered");



            }

            else if (tbl_bookdata.Rows[i].Cells[17].Value == null || tbl_bookdata.Rows[i].Cells[17].Value.ToString().Trim() == "")
            {
                MessageBox.Show("No of Pos not entered");



            }

            else if (tbl_bookdata.Rows[i].Cells[18].Value == null || tbl_bookdata.Rows[i].Cells[18].Value.ToString().Trim() == "")
            {
                MessageBox.Show("Actual Quantity to book not entered");



            }
            else if (!dttran.Isnumbericentry(tbl_bookdata.Rows[i].Cells[11].Value.ToString()))
            {
                MessageBox.Show("Consumption Qty not generated .Specify the Complexity");
            }
            else if (!dttran.Isnumbericentry(tbl_bookdata.Rows[i].Cells[18].Value.ToString ()))
            {
                MessageBox.Show("Actual Quantity to book  entered is numeric");
            }
            else if (!dttran.Isnumbericentry(tbl_bookdata.Rows[i].Cells[17].Value.ToString()))
            {
                MessageBox.Show("No of Pos not entered is not Numeric");
            }                       
            else
            {
                sucess = true;
            }


            return sucess;

        }

        public void updatebooking(int orderid)
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var updategrp = from booking in couriercontext.OrderBooking_tbls
                            where booking.Order_id == orderid
                            select booking;
            foreach (var v in updategrp)
            {
                v.ISApproved = "A";
                v.ApprovalDate = DateTime.Now;
                v.ApprovedBy = Program.uername;
              couriercontext.SubmitChanges();
            }


        }



        public void rejectbooking(int orderid)
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var updategrp = from booking in couriercontext.OrderBooking_tbls
                            where booking.Order_id == orderid
                            select booking;
            foreach (var v in updategrp)
            {
                v.ISApproved = "R";
                v.ApprovalDate = DateTime.Now;
                v.ApprovedBy = Program.uername;
                couriercontext.SubmitChanges();
            }
        }
        public void insertdata()
        {
            int rownumber = tbl_bookdata.CurrentRow.Index;

            CourierDataDataContext curdatacontext = new CourierDataDataContext(Program.ConnStr);
            FinalBooking_master fnlbookmstr = new FinalBooking_master();
            fnlbookmstr.Order_Id = int.Parse(tbl_bookdata.Rows[rownumber].Cells[0].Value.ToString());
            fnlbookmstr.Factory_id = int.Parse(tbl_bookdata.Rows[rownumber].Cells[1].Value.ToString());
            fnlbookmstr.Year = int.Parse(tbl_bookdata.Rows[rownumber].Cells[4].Value.ToString());
            fnlbookmstr.Month = tbl_bookdata.Rows[rownumber].Cells[5].Value.ToString();
            fnlbookmstr.BookQty = int.Parse(tbl_bookdata.Rows[rownumber].Cells[7].Value.ToString());
            fnlbookmstr.BuyerID = int.Parse(tbl_bookdata.Rows[rownumber].Cells[14].Value.ToString());
            fnlbookmstr.Style = tbl_bookdata.Rows[rownumber].Cells[9].Value.ToString();           
            fnlbookmstr.ConsumptionQty = int.Parse(tbl_bookdata.Rows[rownumber].Cells[11].Value.ToString());
            string categorytext = Convert.ToString((tbl_bookdata.Rows[rownumber].Cells[10] as DataGridViewComboBoxCell).FormattedValue.ToString());
            fnlbookmstr.ComplexityLevel = categorytext;
            fnlbookmstr.CategoryID = int.Parse (tbl_bookdata.Rows[rownumber].Cells[10].Value.ToString());
          //  fnlbookmstr.AtcNO = tbl_bookdata.Rows[rownumber].Cells[16].Value.ToString();

            fnlbookmstr.AtcNO = Convert.ToString((tbl_bookdata.Rows[rownumber].Cells[16] as DataGridViewComboBoxCell).FormattedValue.ToString());
            fnlbookmstr.NoOfPO  = int.Parse(tbl_bookdata.Rows[rownumber].Cells[17].Value.ToString());
            fnlbookmstr.ActualQty = int.Parse(tbl_bookdata.Rows[rownumber].Cells[18].Value.ToString());
            fnlbookmstr.ApprovalDate = DateTime.Now.Date;
            curdatacontext.FinalBooking_masters.InsertOnSubmit(fnlbookmstr);


            updatebooking( int.Parse(tbl_bookdata.Rows[rownumber].Cells[0].Value.ToString()));



            curdatacontext.SubmitChanges();

        }
        public DataTable GetBookings()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        OrderBooking_tbl.Order_id, OrderBooking_tbl.Factory_Id, Factory_Master.Factory_name, Factory_Master.MonthlyCapacity, OrderBooking_tbl.Year, 
                         OrderBooking_tbl.Month, ISNULL
                             ((SELECT        SUM(ConsumptionQty) AS Expr1
                                 FROM            FinalBooking_master
                                 WHERE        (Factory_id = OrderBooking_tbl.Factory_Id) AND (Month = OrderBooking_tbl.Month) AND (Year = OrderBooking_tbl.Year)), 0) AS [Booked Qty], 
                         OrderBooking_tbl.BookQty, Buyer_Master.BuyerName, OrderBooking_tbl.Style, OrderBooking_tbl.ISApproved, OrderBooking_tbl.Buyer_id,OrderBooking_tbl.UserId
FROM            OrderBooking_tbl INNER JOIN
                         Factory_Master ON OrderBooking_tbl.Factory_Id = Factory_Master.Factory_ID INNER JOIN
                         Buyer_Master ON OrderBooking_tbl.Buyer_ID = Buyer_Master.Buyer_Id
WHERE        (OrderBooking_tbl.ISApproved = N'N')", con);


              

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }

        private void tbl_bookdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (tbl_bookdata.Rows.Count >= 0)
                {

                    if (e.RowIndex >= 0)
                    {
                        if (e.ColumnIndex == 12)
                        {

                            if (validationcontrol(tbl_bookdata.CurrentRow.Index))
                            {
                                insertdata();
                                sendnotification("Approved");
                                Showdata();

                            }
                        }
                        else if (e.ColumnIndex == 13)
                        {
                            rejectbooking(int.Parse(tbl_bookdata.Rows[tbl_bookdata.CurrentRow.Index].Cells[0].Value.ToString()));
                            sendnotification("Canceled");
                            Showdata();

                        }
                    }
                }
            }
            catch (Exception)
            {
                
                MessageBox.Show("tbl_bookdata_CellClick");
            }
            
        }

        
        private void tbl_bookdata_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (tbl_bookdata.CurrentCell.ColumnIndex == 10 && e.Control is ComboBox)
                {
                    ComboBox comboBox = e.Control as ComboBox;

                    comboBox.SelectionChangeCommitted -= new EventHandler(cmb_SelectionChangeCommitted);
                    comboBox.SelectionChangeCommitted += new EventHandler(cmb_SelectionChangeCommitted);
                    comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
                    //  comboBox.DropDownClosed += LastColumnComboSelectionChanged;
                    //   comboBox.DropDownClosed += comboBox_DropDownClosed;
                }
            }
            catch (Exception)
            {
                
               MessageBox.Show("bl_bookdata_EditingControlShowingd");
            }
        }
           

        private void tbl_bookdata_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbl_bookdata.IsCurrentCellDirty)
                {
                    tbl_bookdata.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception)
            {
                
                 MessageBox.Show("Error in tbl_bookdata_CurrentCellDirtyStateChanged");
            }
        }

        private void tbl_bookdata_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showalloffbuyer("BuyerName = '" + Buyercombo.Text  + "'");
           
        }


        void cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (tbl_bookdata.CurrentCell.ColumnIndex != 16)
                {
                    tbl_bookdata.Rows[tbl_bookdata.CurrentRow.Index].Cells[10].Value = ((DataGridViewComboBoxEditingControl)sender).EditingControlFormattedValue;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error in cmb_SelectionChangeCommitted");
            }
        }


        public void sendnotification(String actiontype)
        {
            String touserName = tbl_bookdata.Rows[tbl_bookdata.CurrentRow.Index].Cells[15].Value.ToString();
            String Buyer = tbl_bookdata.Rows[tbl_bookdata.CurrentRow.Index].Cells[8].Value.ToString();
            String factory = tbl_bookdata.Rows[tbl_bookdata.CurrentRow.Index].Cells[2].Value.ToString();
            String Month = tbl_bookdata.Rows[tbl_bookdata.CurrentRow.Index].Cells[5].Value.ToString();
            String year = tbl_bookdata.Rows[tbl_bookdata.CurrentRow.Index].Cells[4].Value.ToString();
            String qty = tbl_bookdata.Rows[tbl_bookdata.CurrentRow.Index].Cells[7].Value.ToString();
            String ourstyle = tbl_bookdata.Rows[tbl_bookdata.CurrentRow.Index].Cells[9].Value.ToString();
            String actntype = actiontype;
            Transaction.ClsEmailer.approvalorrejectnotifier(touserName, Buyer, factory, year, Month, qty, ourstyle, actiontype);

        }
        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            //  ((ComboBox)sender)

            if (tbl_bookdata.CurrentCell.ColumnIndex != 16)
            {
                var currentcell = tbl_bookdata.CurrentCellAddress;
                var sendingCB = sender as DataGridViewComboBoxEditingControl;
                DataGridViewTextBoxCell cel = (DataGridViewTextBoxCell)tbl_bookdata.Rows[currentcell.Y].Cells[11];
                DataGridViewTextBoxCell cel1 = (DataGridViewTextBoxCell)tbl_bookdata.Rows[currentcell.Y].Cells[18];
                int rownumber = tbl_bookdata.CurrentRow.Index;
                try
                {

                    int factid = int.Parse(tbl_bookdata.Rows[rownumber].Cells[1].Value.ToString());
                    int catgid = 0;
                    try
                    {
                        catgid = int.Parse(tbl_bookdata.Rows[rownumber].Cells[10].Value.ToString());
                    }
                    catch (Exception)
                    {

                        //   ((ComboBox)sender).BackColor = (Color)((ComboBox)sender).SelectedItem;
                        string catgid12 = ((ComboBox)sender).SelectedValue.ToString();

                        catgid = int.Parse(catgid12);
                    }
                    int orderqty = int.Parse(tbl_bookdata.Rows[rownumber].Cells[7].Value.ToString());
                    int consumptionvalue = qtycal.calculatedata(catgid, factid, orderqty);
                    cel.Value = consumptionvalue.ToString();
                    cel1.Value = consumptionvalue.ToString();
                }
                catch (Exception)
                {

                    cel.Value = 0;
                    MessageBox.Show("LastColumnComboSelectionChanged");
                }
            }
        }

        public void loadbuyercombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from buyer in courdatacontext.Buyer_Masters
                    select buyer;



            Buyercombo.DataSource = q;
            Buyercombo.DisplayMember = "BuyerName";
            Buyercombo.ValueMember = "Buyer_Id";
            //   Buyercombo.DataBind();



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

        private void button1_Click(object sender, EventArgs e)
        {
            showalloffbuyer("factory_name = '" + factorycombo .Text + "'");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Showdata();
        }

        private void tbl_bookdata_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error happened " + e.Context.ToString());

            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (e.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (e.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }
        }

        private void tbl_bookdata_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
           //// ((DataTable)tbl_bookdata.DataSource).AcceptChanges();
          
        }

       

    }
}
