using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Shipit.Transaction
{
    public class DataTransaction
    {
        /// <summary>
        /// Get All booking
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllBookings()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        OrderBooking_tbl.Order_id, OrderBooking_tbl.Factory_Id, Factory_Master.Factory_name, Factory_Master.MonthlyCapacity, OrderBooking_tbl.Year, 
                         OrderBooking_tbl.Month, ISNULL
                             ((SELECT        SUM(ConsumptionQty) AS Expr1
                                 FROM            FinalBooking_master
                                 WHERE        (Factory_id = OrderBooking_tbl.Factory_Id) AND (Month = OrderBooking_tbl.Month) AND (Year = OrderBooking_tbl.Year)), 0) AS [Previous Booked Qty], 
                         OrderBooking_tbl.BookQty, Buyer_Master.BuyerName, OrderBooking_tbl.Style, OrderBooking_tbl.ISApproved, OrderBooking_tbl.Buyer_id,OrderBooking_tbl.UserId
FROM            OrderBooking_tbl INNER JOIN
                         Factory_Master ON OrderBooking_tbl.Factory_Id = Factory_Master.Factory_ID INNER JOIN
                         Buyer_Master ON OrderBooking_tbl.Buyer_ID = Buyer_Master.Buyer_Id ", con);




                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        /// <summary>
        /// getallbookingby year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetAllBookings(int year)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        OrderBooking_tbl.Order_id, OrderBooking_tbl.Factory_Id, Factory_Master.Factory_name, Factory_Master.MonthlyCapacity, OrderBooking_tbl.Year, 
                         OrderBooking_tbl.Month, ISNULL
                             ((SELECT        SUM(ConsumptionQty) AS Expr1
                                 FROM            FinalBooking_master
                                 WHERE        (Factory_id = OrderBooking_tbl.Factory_Id) AND (Month = OrderBooking_tbl.Month) AND (Year = OrderBooking_tbl.Year)), 0) AS [Previous Booked Qty], 
                         OrderBooking_tbl.BookQty, Buyer_Master.BuyerName, OrderBooking_tbl.Style, OrderBooking_tbl.ISApproved, OrderBooking_tbl.Buyer_ID, 
                         OrderBooking_tbl.UserId ,ISNULL((SELECT DISTINCT AtcNO
FROM            FinalBooking_master
WHERE        (Order_Id = OrderBooking_tbl.Order_id)),'NA') AS ATC
FROM            OrderBooking_tbl INNER JOIN
                         Factory_Master ON OrderBooking_tbl.Factory_Id = Factory_Master.Factory_ID INNER JOIN
                         Buyer_Master ON OrderBooking_tbl.Buyer_ID = Buyer_Master.Buyer_Id
WHERE        (OrderBooking_tbl.Year = @Param1)", con);



                cmd.Parameters.AddWithValue("@Param1", year);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }
        /// <summary>
        /// get all Booking of an ATC
        /// </summary>
        /// <param name="Atcno"></param>
        /// <returns></returns>
        public DataTable GetAllBookings(String Atcno)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();







                SqlCommand cmd = new SqlCommand(@"SELECT        OrderBooking_tbl.Order_id, OrderBooking_tbl.Factory_Id, Factory_Master.Factory_name, Factory_Master.MonthlyCapacity, OrderBooking_tbl.Year, 
                         OrderBooking_tbl.Month, FinalBooking_master_1.AtcNO, ISNULL
                             ((SELECT        SUM(ConsumptionQty) AS Expr1
                                 FROM            FinalBooking_master
                                 WHERE        (Factory_id = OrderBooking_tbl.Factory_Id) AND (Month = OrderBooking_tbl.Month) AND (Year = OrderBooking_tbl.Year)), 0) AS [Booked Qty], 
                         OrderBooking_tbl.BookQty, Buyer_Master.BuyerName, OrderBooking_tbl.Style, OrderBooking_tbl.ISApproved, OrderBooking_tbl.Buyer_ID, 
                         OrderBooking_tbl.UserId,OrderBooking_tbl.ApprovedBy, CONVERT(date, OrderBooking_tbl.ApprovalDate) AS ApprovedDate
FROM            OrderBooking_tbl INNER JOIN
                         Factory_Master ON OrderBooking_tbl.Factory_Id = Factory_Master.Factory_ID INNER JOIN
                         Buyer_Master ON OrderBooking_tbl.Buyer_ID = Buyer_Master.Buyer_Id LEFT OUTER JOIN
                         FinalBooking_master AS FinalBooking_master_1 ON OrderBooking_tbl.Order_id = FinalBooking_master_1.Order_Id
WHERE        (OrderBooking_tbl.Style LIKE @atc) OR
                         (FinalBooking_master_1.AtcNO LIKE @atc)", con);



                cmd.Parameters.AddWithValue("@atc", Atcno);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        /// <summary>
        /// get the week plan for atc
        /// </summary>
        /// <param name="Atcno"></param>
        /// <returns></returns>
        public DataTable GetAllWeekPlanForAtc(String Atcno)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();







                SqlCommand cmd = new SqlCommand(@"SELECT    WeeklyPlan_Master.WeekID  ,   FinalBooking_master.Book_Id, FinalBooking_master.Order_Id, Factory_Master.Factory_name, WeeklyPlan_Master.Year, WeeklyPlan_Master.Month, 
                         WeeklyPlan_Master.WeekNo, FinalBooking_master.AtcNO, WeeklyPlan_Master.PO#, WeeklyPlan_Master.stylenum, WeeklyPlan_Master.Qty, 
                         WeeklyPlan_Master.AddedBy, WeeklyPlan_Master.AddedDate,WeeklyPlan_Master.ActualDelivery_date,WeeklyPlan_Master.InhouseDate as PCD
FROM            FinalBooking_master INNER JOIN
                         WeeklyPlan_Master ON FinalBooking_master.Book_Id = WeeklyPlan_Master.Book_Id INNER JOIN
                         Factory_Master ON WeeklyPlan_Master.Factory_Id = Factory_Master.Factory_ID
WHERE        (FinalBooking_master.Style LIKE @atc) OR
                         (FinalBooking_master.AtcNO LIKE @atc)", con);



                cmd.Parameters.AddWithValue("@atc", Atcno);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }



        public DataTable Getdetialsofamonth(int year, String month, String Factory)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();







                SqlCommand cmd = new SqlCommand(@" select sum(tt.booKqtY ) as[ Total Booking],sum(tt.ApprovedQty) as [Confirmed Qty],sum(tt.ConsumptionQty ) as [Capacity Consumed],(sum(tt.booKqtY )-sum(tt.ApprovedQty)) as[ Pending to Confirm ]from (SELECT        OrderBooking_tbl.Order_id, FinalBooking_master.Book_Id, OrderBooking_tbl.Year, OrderBooking_tbl.Month, OrderBooking_tbl.BookQty, OrderBooking_tbl.Style, 
                         Factory_Master.Factory_name, Buyer_Master.BuyerName, OrderBooking_tbl.UserId, OrderBooking_tbl.ISApproved, FinalBooking_master.ComplexityLevel, 
                         FinalBooking_master.AtcNO, FinalBooking_master.ConsumptionQty, FinalBooking_master.CategoryID, FinalBooking_master.BookQty AS ApprovedQty
FROM            OrderBooking_tbl INNER JOIN
                         Factory_Master ON OrderBooking_tbl.Factory_Id = Factory_Master.Factory_ID INNER JOIN
                         Buyer_Master ON OrderBooking_tbl.Buyer_ID = Buyer_Master.Buyer_Id LEFT OUTER JOIN
                         FinalBooking_master ON OrderBooking_tbl.Order_id = FinalBooking_master.Order_Id
WHERE        (OrderBooking_tbl.Year = @year) AND (OrderBooking_tbl.ISApproved <> N'R') AND (OrderBooking_tbl.Month = @month) AND 
                         (Factory_Master.Factory_name = @factoryname))tt", con);



                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@factoryname", Factory);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        /// <summary>
        /// get booking of a factory  and year and month
        /// </summary>
        /// <param name="factid"></param>
        /// <param name="buyername"></param>
        /// <param name="year"></param>
        /// <param name="Monnth"></param>
        /// <returns></returns>
        public DataTable getBookingbyfilter(int factid, String buyername, int year, String Monnth)
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
                         OrderBooking_tbl.BookQty, Buyer_Master.BuyerName, OrderBooking_tbl.Style, OrderBooking_tbl.ISApproved, OrderBooking_tbl.Buyer_ID, 
                         OrderBooking_tbl.UserId
FROM            OrderBooking_tbl INNER JOIN
                         Factory_Master ON OrderBooking_tbl.Factory_Id = Factory_Master.Factory_ID INNER JOIN
                         Buyer_Master ON OrderBooking_tbl.Buyer_ID = Buyer_Master.Buyer_Id
WHERE        (OrderBooking_tbl.Factory_Id = @factid) AND (OrderBooking_tbl.Year = @year) AND (OrderBooking_tbl.Month = @month) AND 
                         (Buyer_Master.BuyerName = @buyername)", con);


                cmd.Parameters.AddWithValue("@factid", factid);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@month", Monnth);
                cmd.Parameters.AddWithValue("@buyername", buyername);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }
        /// <summary>
        /// get all buyer
        /// </summary>
        /// <returns></returns>
        public DataTable GetBuyer()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        Buyer_Id, BuyerName
FROM            Buyer_Master ", con);




                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }
        /// <summary>
        /// get the factory
        /// </summary>
        /// <returns></returns>
        public DataTable getfactory()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        Factory_ID, Factory_name
FROM            Factory_Master
WHERE        (IsActive = N'Y') ", con);




                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        /// <summary>
        /// get the monthnumber of month
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public int getmonthname(string month)
        {
            int monthnum = 0;


            switch (month.Trim())
            {
                case "January":
                    monthnum = 1;
                    break;

                case "February":
                    monthnum = 2;
                    break;
                case "March":
                    monthnum = 3;
                    break;

                case "April":
                    monthnum = 4;
                    break;

                case "May":
                    monthnum = 5;
                    break;

                case "June":
                    monthnum = 6;
                    break;
                case "July":
                    monthnum = 7;
                    break;
                case "August":
                    monthnum = 8;
                    break;

                case "September":
                    monthnum = 9;
                    break;

                case "October":
                    monthnum = 10;
                    break;
                case "November":
                    monthnum = 11;
                    break;
                case "December":
                    monthnum = 12;
                    break;

                default:
                    {
                        monthnum = 0;
                        break;
                    }




            }
            return monthnum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        public DataTable getAllConsolidatedBookingfactory(int year, String Month)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        SUM(OrderBooking_tbl.BookQty) AS Expr1, Buyer_Master.BuyerName, Factory_Master.Factory_name, OrderBooking_tbl.Year, OrderBooking_tbl.Month,OrderBooking_tbl.ISApproved
FROM            OrderBooking_tbl INNER JOIN
                         Buyer_Master ON OrderBooking_tbl.Buyer_ID = Buyer_Master.Buyer_Id INNER JOIN
                         Factory_Master ON OrderBooking_tbl.Factory_Id = Factory_Master.Factory_ID
GROUP BY Buyer_Master.BuyerName, Factory_Master.Factory_name, OrderBooking_tbl.Year, OrderBooking_tbl.Month,OrderBooking_tbl.ISApproved
HAVING        (OrderBooking_tbl.Year = @year) AND (OrderBooking_tbl.Month = @month) and (OrderBooking_tbl.ISApproved!='R')", con);

//                SqlCommand cmd = new SqlCommand(@"SELECT        SUM(OrderBooking_tbl.BookQty) AS Expr1, Buyer_Master.BuyerName, Factory_Master.Factory_name, OrderBooking_tbl.Year, OrderBooking_tbl.Month
//FROM            OrderBooking_tbl INNER JOIN
//                         Buyer_Master ON OrderBooking_tbl.Buyer_ID = Buyer_Master.Buyer_Id INNER JOIN
//                         Factory_Master ON OrderBooking_tbl.Factory_Id = Factory_Master.Factory_ID
//GROUP BY Buyer_Master.BuyerName, Factory_Master.Factory_name, OrderBooking_tbl.Year, OrderBooking_tbl.Month
//HAVING        (OrderBooking_tbl.Year = @year) AND (OrderBooking_tbl.Month = @month) and (OrderBooking_tbl.ISApproved!='R')", con);


                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@month", Month);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }

        public void getallnonapprovedentries(DataGridView tbl_dgv)
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);

            var orderdetails = from c in couriercontext.OrderBooking_tbls
                               join b in couriercontext.Buyer_Masters on c.Buyer_ID equals b.Buyer_Id
                               join f in couriercontext.Factory_Masters on c.Factory_Id equals f.Factory_ID
                               where c.ISApproved != "Y" && c.UserId == Program.uername
                               select new
                               {
                                   bookid = c.Order_id,
                                   factoryname = f.Factory_name,
                                   year = c.Year,
                                   month = c.Month,
                                   buyer = b.BuyerName,
                                   style = c.Style,
                                   qty = c.BookQty,

                               };
            int i = 0;
            tbl_dgv.RowCount = 1;
            foreach (var element in orderdetails)
            {

                int monthnum = getmonthname(element.month);
                DateTime startdate = new DateTime(int.Parse((element.year).ToString()), monthnum, 1);
                DateTime datetoday = DateTime.Now.Date;

                if ((startdate - datetoday).TotalDays < 150)
                {
                    tbl_dgv.Rows.Add();
                    tbl_dgv.Rows[i].Cells[0].Value = element.bookid;
                    tbl_dgv.Rows[i].Cells[1].Value = element.factoryname;
                    tbl_dgv.Rows[i].Cells[2].Value = element.year;
                    tbl_dgv.Rows[i].Cells[3].Value = element.month;
                    tbl_dgv.Rows[i].Cells[4].Value = element.buyer;
                    tbl_dgv.Rows[i].Cells[5].Value = element.qty;
                    tbl_dgv.Rows[i].Cells[6].Value = element.style;




                    ++i;
                }
            }

        }

        public int getbalance(int orderid, int factoryid)
        {


            int balance = 0;
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        Order_id, 
    (SELECT        MonthlyCapacity - (ISNULL ((SELECT SUM(BookQty) AS Expr1
         FROM      OrderBooking_tbl  WHERE (ISApproved = N'N') AND (Year = O.Year) AND (Month = O.Month) AND (Factory_Id = @factoryid)), 0) + ISNULL
          ((SELECT        SUM(BookQty) AS Expr1 FROM FinalBooking_master WHERE (Year = O.Year) AND (Month = O.Month) AND (Factory_id = @factoryid)), 0)) AS Expr1
                FROM Factory_Master WHERE (Factory_ID =@factoryid)) AS Expr1 FROM  OrderBooking_tbl AS O WHERE (o.Order_id = @orderid)
", con);



                cmd.Parameters.AddWithValue("@factoryid", factoryid);
                cmd.Parameters.AddWithValue("@orderid", orderid);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);


                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        if (dt.Rows[0][1].ToString().Trim() == "")
                        {
                            balance = 0;
                        }
                        else
                        {
                            balance = int.Parse(dt.Rows[0][1].ToString());
                        }
                    }
                }


            }
            return balance;
        }



        public int getbalancebyfactoryname(String factoryname, int Year, String Month)
        {
            int balance = 0;
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT  ( MonthlyCapacity  -( isnull((SELECT SUM(BookQty) AS Expr1
         FROM      OrderBooking_tbl  WHERE (ISApproved = N'N') AND (Year = @YEAR) AND (Month = @month) AND (Factory_Id = fm.Factory_ID )),0)   + isnull( (SELECT SUM(BookQty) AS Expr1
         FROM      FinalBooking_master   WHERE (Year = @year) AND (Month = @month) AND (Factory_Id = fm.Factory_ID )),0))) as Balance
FROM            Factory_Master fM
WHERE        (Factory_name = @factoryname)", con);



                cmd.Parameters.AddWithValue("@year", Year);
                cmd.Parameters.AddWithValue("@month", Month);
                cmd.Parameters.AddWithValue("@factoryname", factoryname);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);


                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        if (dt.Rows[0][0].ToString().Trim() == "")
                        {
                            balance = 0;
                        }
                        else
                        {
                            balance = int.Parse(dt.Rows[0][0].ToString());
                        }
                    }
                }


            }
            return balance;

        }









        /// <summary>
        /// get non approved entries which have more than 150 days for production
        /// </summary>
        /// <param name="tbl_dgv"></param>
        public void getallnonapprovedentriesforEditing(DataGridView tbl_dgv)
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);

            var orderdetails = from c in couriercontext.OrderBooking_tbls
                               join b in couriercontext.Buyer_Masters on c.Buyer_ID equals b.Buyer_Id
                               join f in couriercontext.Factory_Masters on c.Factory_Id equals f.Factory_ID
                               where c.ISApproved != "A" && c.UserId == Program.uername
                               select new
                               {
                                   bookid = c.Order_id,
                                   factoryname = f.Factory_name,
                                   year = c.Year,
                                   month = c.Month,
                                   buyer = b.BuyerName,
                                   style = c.Style,
                                   qty = c.BookQty,

                               };
            int i = 0;
            tbl_dgv.RowCount = 1;
            foreach (var element in orderdetails)
            {

                int monthnum = getmonthname(element.month);
                DateTime startdate = new DateTime(int.Parse((element.year).ToString()), monthnum, 1);
                DateTime datetoday = DateTime.Now.Date;

                //if ((startdate - datetoday).TotalDays > 1)
                //{
                tbl_dgv.Rows.Add();
                tbl_dgv.Rows[i].Cells[0].Value = element.bookid;
                tbl_dgv.Rows[i].Cells[1].Value = element.factoryname;
                tbl_dgv.Rows[i].Cells[2].Value = element.year;
                tbl_dgv.Rows[i].Cells[3].Value = element.month;
                tbl_dgv.Rows[i].Cells[4].Value = element.buyer;
                tbl_dgv.Rows[i].Cells[5].Value = element.qty;
                tbl_dgv.Rows[i].Cells[6].Value = element.style;




                ++i;
                //}
            }

        }


        /// <summary>
        /// get the weekly plan of a factory
        /// </summary>
        /// <param name="factorid"></param>
        /// <param name="year"></param>
        /// <param name="Month"></param>
        /// <param name="Weekno"></param>
        /// <returns></returns>
        public DataTable Getweeklyplan(int factorid, int year, string Month, String Weekno)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        WeekID, Month, Year, Factory_Id, Book_Id, WeekNo, PO#, SUM(Qty) AS Expr1, isnull((SELECT SUM(Qty) AS qty
FROM ProductionReport_Detail GROUP BY WeekID HAVING (WeekID = P.WeekID )),0) as Produced
FROM            WeeklyPlan_Master P
GROUP BY Month, Year, WeekNo, Book_Id, PO#, WeekID, Factory_Id
HAVING        (WeekNo = @Weekno) AND (Month = @month) AND (Year = @year) AND (Factory_Id = @factid)", con);


                cmd.Parameters.AddWithValue("@factid", factorid);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@month", Month);
                cmd.Parameters.AddWithValue("@Weekno", Weekno);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }







        public DataTable GetPoOfAAtc(String Atcnum)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string Query1 = @"SELECT        distinct WeeklyPlan_Master.PO#
FROM            FinalBooking_master INNER JOIN
                         WeeklyPlan_Master ON FinalBooking_master.Book_Id = WeeklyPlan_Master.Book_Id
WHERE        (FinalBooking_master.AtcNO = @atcnum) ";


                cmd.CommandText = Query1;
                cmd.Parameters.AddWithValue("@atcnum", Atcnum);
              //  cmd.Parameters.AddWithValue("@factid", Program.lctnpk);




                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }

        public DataTable getAtcnumbers()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string Query1 = @"SELECT      DISTINCT Atc_master.Atc_id,  Atc_master.AtcNum
FROM            Atc_master INNER JOIN
                         FinalBooking_master ON Atc_master.AtcNum = FinalBooking_master.AtcNO
WHERE        (FinalBooking_master.Factory_id = @factid)";
                string Query2 = "SELECT DISTINCT AtcNum,AtcId FROM  AtcMaster ";

                if (Program.lctnpk == 0)
                {
                    cmd.CommandText = Query2;
                }
                else
                {
                    cmd.CommandText = Query2;
                    // cmd.Parameters.AddWithValue("@factid", Program.lctnpk);

                }








                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        public DataTable getAtcnumberforLinePlanning()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

//                string Query2 = @"SELECT DISTINCT Atc_master.AtcNum, Atc_master.Atc_id
//FROM            Atc_master INNER JOIN
//                         LineAtcCapacity_tbl ON Atc_master.AtcNum = LineAtcCapacity_tbl.Atcnum
//WHERE        (LineAtcCapacity_tbl.Factid = @Param1)";

                string Query2 = @"  SELECT DISTINCT AtcMaster.AtcNum, AtcMaster.AtcId
FROM            LineAtcCapacity_tbl INNER JOIN
                         AtcMaster ON LineAtcCapacity_tbl.Atcnum = AtcMaster.AtcNum
WHERE(LineAtcCapacity_tbl.Factid = @Param1)";
                cmd.CommandText = Query2;
                // cmd.Parameters.AddWithValue("@factid", Program.lctnpk);

                cmd.Parameters.AddWithValue("@Param1", Program.lctnpk);








                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }

        /// <summary>
        /// whether a String is Numeric or not
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public Boolean Isnumbericentry(String txt)
        {
            Boolean iscorrect = false;

            try
            {
                int asd = int.Parse(txt);
                iscorrect = true;
            }
            catch (Exception)
            {
                iscorrect = false;

            }
            return iscorrect;

        }



        public Boolean IsTextboxemptyorNull(TextBox txtbox)
        {
            Boolean iscorrect = false;

            try
            {
                if (txtbox.Text != null && txtbox.Text.Trim() != "")
                {
                    iscorrect = true;
                }
                else
                {
                    iscorrect = false;
                }
            }
            catch (Exception)
            {
                iscorrect = false;

            }
            return iscorrect;

        }
        public Boolean IsComboboxemptyorNull(ComboBox cmbbox)
        {
            Boolean iscorrect = false;

            try
            {
                if (cmbbox.Text != null && cmbbox.Text.Trim() != "")
                {
                    iscorrect = true;
                }
                else
                {
                    iscorrect = false;
                }
            }
            catch (Exception)
            {
                iscorrect = false;

            }
            return iscorrect;

        }



        public static DataSet Get_Data(String qry)
        {
            DataSet ds = new DataSet();
            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();

                SqlCommand com = new SqlCommand();
                com.Connection = sqlConnection1;
                com.CommandText = qry;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                sqlConnection1.Close();



            };
            return ds;

        }

        public void getexistingprivillege(int userid, TreeView treeView1)
        {

            using (SqlConnection sqlConnection1 = new SqlConnection(Program.ConnStr))
            {

                sqlConnection1.Open();

                using (SqlCommand command = new SqlCommand(@" SELECT        User_Rights.Form_name
FROM            User_Rights 
WHERE        (User_Rights.Access_Right = 'Y') AND (User_Rights.User_id = @Param2)", sqlConnection1))
                {

                    command.Parameters.AddWithValue("@Param2", userid);

                    SqlDataReader reader = command.ExecuteReader();
                    DataTable DT = new DataTable();

                    DT.Load(reader);

                    if (DT != null)
                    {
                        if (DT.Rows.Count != 0)
                        {

                            for (int i = 0; i < DT.Rows.Count; i++)
                            {
                                for (int x = 0; x < treeView1.Nodes.Count; x++)
                                {
                                    if (treeView1.Nodes[x].Text.ToString() == DT.Rows[i][0].ToString())
                                    {
                                        treeView1.Nodes[x].Checked = true;
                                    }

                                }

                            }

                        }
                    }

                }

                sqlConnection1.Close();



            }
        }






        // <summary>
        ///restrict the acess to other loacation
        /// </summary>

        public void resrictacess(ComboBox cmb_location)
        {
            try
            {

                if (Program.lctnpk == 0)
                {

                }
                else
                {

                    if (int.Parse(cmb_location.SelectedValue.ToString()) != Program.lctnpk)
                    {
                        MessageBox.Show("You Are Not Allowed to Access This Location Data");
                        cmb_location.SelectedValue = Program.lctnpk;
                    }



                }

            }
            catch (Exception)
            {


            }
        }





        public DataTable GetProductionofamonth(String month, int year, int factid)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT      isnull( SUM(WeeklyPlan_Master.Qty),0) AS target, isnull(SUM(ProductionReport_Detail.Qty),0) AS Produced , WeeklyPlan_Master.WeekNo
FROM            WeeklyPlan_Master LEFT OUTER JOIN
                         ProductionReport_Detail ON WeeklyPlan_Master.WeekID = ProductionReport_Detail.WeekID
GROUP BY WeeklyPlan_Master.Month, WeeklyPlan_Master.Year, WeeklyPlan_Master.Factory_Id, WeeklyPlan_Master.WeekNo
HAVING        (WeeklyPlan_Master.Month = @month) AND (WeeklyPlan_Master.Year = @year) AND (WeeklyPlan_Master.Factory_Id = @factid)", con);




                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@factid", factid);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        public DataTable GetAllApprovedBookings(int year)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        OrderBooking_tbl.Order_id, FinalBooking_master.Book_Id, Factory_Master.Factory_name, FinalBooking_master.Year, FinalBooking_master.Month, 
                         Buyer_Master.BuyerName, FinalBooking_master.AtcNO, FinalBooking_master.Style, OrderBooking_tbl.BookQty , FinalBooking_master.ConsumptionQty, 
                         FinalBooking_master.ApprovalDate, FinalBooking_master.NoOfPO,FinalBooking_master.ComplexityLevel
FROM            OrderBooking_tbl INNER JOIN
                         FinalBooking_master ON OrderBooking_tbl.Order_id = FinalBooking_master.Order_Id INNER JOIN
                         Factory_Master ON FinalBooking_master.Factory_id = Factory_Master.Factory_ID INNER JOIN
                         Buyer_Master ON FinalBooking_master.BuyerID = Buyer_Master.Buyer_Id
WHERE        (OrderBooking_tbl.ISApproved = N'A') AND (FinalBooking_master.Year = @Param1)", con);


                cmd.Parameters.AddWithValue("@Param1", year);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }




        public DataTable GetPOwiseProductionofamonth(DateTime fromdate, DateTime todate, int factid)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        ActualProduced_tbl.ProducedID, Factory_Master.Factory_name, ActualProduced_tbl.DateOfProd,datename(dw,ActualProduced_tbl.DateOfProd) as DayOfWeek, ActualProduced_tbl.Linenum, ActualProduced_tbl.Atcnum, ActualProduced_tbl.OurStyle,ActualProduced_tbl.Ponum, 
                         ActualProduced_tbl.ProducedQty, ActualProduced_tbl.Operators, ActualProduced_tbl.Helpers, ActualProduced_tbl.Hours, ActualProduced_tbl.AddedBy, ActualProduced_tbl.AddedDate
FROM            ActualProduced_tbl INNER JOIN
                         Factory_Master ON ActualProduced_tbl.factid = Factory_Master.Factory_ID
WHERE        (ActualProduced_tbl.DateOfProd BETWEEN @param1 AND @param2) AND (Factory_Master.Factory_ID = @Param3)", con);




                cmd.Parameters.AddWithValue("@param1", fromdate);
                cmd.Parameters.AddWithValue("@param2", todate);
                cmd.Parameters.AddWithValue("@param3", factid);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }

        public DataTable GetPOwisePackingofamonth(DateTime fromdate, DateTime todate, int factid)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        ActualPacked_tbl.PackID, Factory_Master.Factory_name, ActualPacked_tbl.Linenum, ActualPacked_tbl.Atcnum,  ActualPacked_tbl.POnum, ActualPacked_tbl.PackedQty, ActualPacked_tbl.DateofPacking, 
                         ActualPacked_tbl.Addeddate, ActualPacked_tbl.AddedBy
FROM            Factory_Master INNER JOIN
                         ActualPacked_tbl ON Factory_Master.Factory_ID = ActualPacked_tbl.factid
WHERE        (ActualPacked_tbl.DateofPacking BETWEEN @param1 AND @param2) AND (Factory_Master.Factory_ID = @Param3)", con);




                cmd.Parameters.AddWithValue("@param1", fromdate);
                cmd.Parameters.AddWithValue("@param2", todate);
                cmd.Parameters.AddWithValue("@param3", factid);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }



        public DataTable GetPOwiseProdofamonth(DateTime fromdate, DateTime todate, int factid)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        ActualProduced_tbl.ProducedID, Factory_Master.Factory_name, ActualProduced_tbl.DateOfProd, DATENAME(dw, ActualProduced_tbl.DateOfProd) AS DayOfWeek, ActualProduced_tbl.Linenum, 
                         ActualProduced_tbl.Atcnum,POProduced.POnum, ActualProduced_tbl.Operators, ActualProduced_tbl.Helpers, ActualProduced_tbl.Hours, POProduced.POQty, POProduced.AddedBy, POProduced.AddedDate
FROM            ActualProduced_tbl INNER JOIN
                         Factory_Master ON ActualProduced_tbl.factid = Factory_Master.Factory_ID INNER JOIN
                         POProduced ON ActualProduced_tbl.LineID = POProduced.LineID AND ActualProduced_tbl.factid = POProduced.Factid AND ActualProduced_tbl.DateOfProd = POProduced.DateofProd AND 
                         ActualProduced_tbl.Linenum = POProduced.LineNum AND ActualProduced_tbl.Atcnum = POProduced.AtcNum 


						 WHERE        (ActualProduced_tbl.DateOfProd BETWEEN @param1 AND @param2) AND (Factory_Master.Factory_ID = @Param3)", con);




                cmd.Parameters.AddWithValue("@param1", fromdate);
                cmd.Parameters.AddWithValue("@param2", todate);
                cmd.Parameters.AddWithValue("@param3", factid);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }

        /// <summary>
        /// get all the pos allocated for the week for a factory
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="factid"></param>
        /// <param name="Weeknum"></param>
        /// <returns></returns>
        public DataTable GetPosOfaMonth(String month, int year, int factid, String Weeknum)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        PO#,WeekID,SUM(Qty) AS targetQty, stylenum
FROM            WeeklyPlan_Master
GROUP BY PO#, WeekID, Month, Year, WeekNo, Factory_Id, stylenum
HAVING        (Month = @month) AND (Year = @year) AND (WeekNo = @Weekno) AND (Factory_Id = @facftid)", con);




                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@facftid", factid);
                cmd.Parameters.AddWithValue("@Weekno", Weeknum);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        /// <summary>
        /// get the Atc by searching the PO#
        /// </summary>
        /// <param name="POnum"></param>
        /// <returns></returns>
        public String GetAtcByPOnum(String POnum)
        {
            DataTable dt = new DataTable();
            String Atcnum = "NA";

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        FinalBooking_master.AtcNO
FROM            FinalBooking_master INNER JOIN
                         WeeklyPlan_Master ON FinalBooking_master.Book_Id = WeeklyPlan_Master.Book_Id
WHERE        (WeeklyPlan_Master.PO# = @ponum)", con);




                cmd.Parameters.AddWithValue("@ponum", POnum);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



                if (dt != null)
                {
                    if (dt.Rows.Count >= 1)
                    {
                        if (dt.Rows[0][0].ToString().Trim() != "")
                        {
                            Atcnum = dt.Rows[0][0].ToString();

                        }
                    }
                }

            }
            return Atcnum;
        }

        public DataTable GetAtcAndStyleByPOnum(int weekid)
        {
            DataTable dt = new DataTable();

            ArrayList arry = new ArrayList();
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        FinalBooking_master.AtcNO, WeeklyPlan_Master.stylenum
FROM            FinalBooking_master INNER JOIN
                         WeeklyPlan_Master ON FinalBooking_master.Book_Id = WeeklyPlan_Master.Book_Id
WHERE        (WeeklyPlan_Master.weekid = @weekid)", con);




                cmd.Parameters.AddWithValue("@weekid", weekid);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);


            }

            return dt;
        }
        /// <summary>
        /// get previouslineplans of a PO
        /// </summary>
        /// <param name="POnum"></param>
        /// <returns></returns>

        public DataTable GettPreviousLineplanOfPO(String POnum)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        FactoryWeeklyPlan_tbl.FctProdID, FactoryWeeklyPlan_tbl.LineID, Factory_Master.Factory_name, FactoryWeeklyPlan_tbl.Year, FactoryWeeklyPlan_tbl.Month, 
                         FactoryWeeklyPlan_tbl.Weeknum, FactoryWeeklyPlan_tbl.Ponum, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.DateofProd, 
                         FactoryWeeklyPlan_tbl.TargetQty
FROM            Factory_Master INNER JOIN
                         FactoryWeeklyPlan_tbl ON Factory_Master.Factory_ID = FactoryWeeklyPlan_tbl.Factid
WHERE        (FactoryWeeklyPlan_tbl.Ponum = @ponum)", con);




                cmd.Parameters.AddWithValue("@ponum", POnum);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        public DataTable GetAtc()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        AtcNum, Atc_id
FROM            Atc_master", con);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }



        public DataTable GettargetsofADay(int factid, DateTime datetoday)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        FctProdID, LineNum, Ponum, SUM(TargetQty) AS TargetQty, DateofProd
FROM            FactoryWeeklyPlan_tbl
GROUP BY FctProdID, Ponum, LineNum, Factid, DateofProd
HAVING        (Factid = @facftid) AND (DateofProd = @Datetoday)", con);





                cmd.Parameters.AddWithValue("@facftid", factid);
                cmd.Parameters.AddWithValue("@Datetoday", datetoday);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        public DataTable GetFactoryPlanofaMonth(String month, int year, int factid)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                //                SqlCommand cmd = new SqlCommand(@"SELECT        FactoryWeeklyPlan_tbl.FctProdID, WeeklyPlan_Master.WeekID, FactoryWeeklyPlan_tbl.Weeknum, FactoryWeeklyPlan_tbl.LineNum, 
                //                         FactoryWeeklyPlan_tbl.DateofProd, FactoryWeeklyPlan_tbl.Ponum as [PO#], '0' as DeliveryDate ,WeeklyPlan_Master.Qty AS WeeklyRequirement, FactoryWeeklyPlan_tbl.TargetQty AS FactoryTarget ,isnull((SELECT  ProducedQty
                //FROM            ActualProduced_tbl
                //WHERE        (FctProdID = FactoryWeeklyPlan_tbl.FctProdID)) ,0) as Produced ,isnull((SELECT  PackedQty
                //FROM            ActualProduced_tbl
                //WHERE        (FctProdID = FactoryWeeklyPlan_tbl.FctProdID)) ,0) as PackedQty
                //FROM            WeeklyPlan_Master INNER JOIN
                //                         FactoryWeeklyPlan_tbl ON WeeklyPlan_Master.WeekID = FactoryWeeklyPlan_tbl.WeekID
                //WHERE        (FactoryWeeklyPlan_tbl.Factid = @factid) AND (FactoryWeeklyPlan_tbl.Year = @year) AND (FactoryWeeklyPlan_tbl.Month = @month)", con);


                //                SqlCommand cmd = new SqlCommand(@"Select FctProdID, WeekID, Weeknum, LineNum, DateofProd,  [PO#],  DeliveryDate , WeeklyRequirement,  FactoryTarget ,Produced , PackedQty,(FactoryTarget -Produced) as [BalanceToProduce],(Produced -PackedQty) as [BalanceToPack] from (
                // 
                //SELECT        FactoryWeeklyPlan_tbl.FctProdID, WeeklyPlan_Master.WeekID, FactoryWeeklyPlan_tbl.Weeknum, FactoryWeeklyPlan_tbl.LineNum,
                //                         FactoryWeeklyPlan_tbl.DateofProd, FactoryWeeklyPlan_tbl.Ponum as [PO#], '0' as DeliveryDate ,WeeklyPlan_Master.Qty AS WeeklyRequirement, FactoryWeeklyPlan_tbl.TargetQty AS FactoryTarget ,isnull((SELECT sum(  ProducedQty)
                //FROM            ActualProduced_tbl
                //WHERE        (FctProdID = FactoryWeeklyPlan_tbl.FctProdID)) ,0) as Produced ,isnull((SELECT  sum( PackedQty)
                //FROM            ActualProduced_tbl
                //WHERE        (FctProdID = FactoryWeeklyPlan_tbl.FctProdID)) ,0) as PackedQty
                //FROM            WeeklyPlan_Master INNER JOIN
                //                         FactoryWeeklyPlan_tbl ON WeeklyPlan_Master.WeekID = FactoryWeeklyPlan_tbl.WeekID
                //WHERE        (FactoryWeeklyPlan_tbl.Factid = @factid) AND (FactoryWeeklyPlan_tbl.Year = @year) AND (FactoryWeeklyPlan_tbl.Month = @month))tt
                // ", con);

                SqlCommand cmd = new SqlCommand(@"Select FctProdID, WeekID, Weeknum, LineNum, DateofProd,AtcNO,  [PO#], stylenum as Stylenum, DeliveryDate , WeeklyRequirement,  FactoryTarget ,Produced ,
 PackedQty,(FactoryTarget -Produced) as [BalanceToProduce],(Produced -PackedQty) as [BalanceToPack] from (
 SELECT        FactoryWeeklyPlan_tbl.FctProdID, WeeklyPlan_Master.WeekID, FactoryWeeklyPlan_tbl.Weeknum, FactoryWeeklyPlan_tbl.LineNum, 
                         FactoryWeeklyPlan_tbl.DateofProd, FactoryWeeklyPlan_tbl.Ponum AS PO#, '0' AS DeliveryDate, WeeklyPlan_Master.Qty AS WeeklyRequirement, 
                         FactoryWeeklyPlan_tbl.TargetQty AS FactoryTarget, ISNULL
                             ((SELECT        SUM(ProducedQty) AS Expr1
                                 FROM            ActualProduced_tbl
                                 WHERE        (FctProdID = FactoryWeeklyPlan_tbl.FctProdID)), 0) AS Produced, ISNULL
                             ((SELECT        SUM(PackedQty) AS Expr1
                                 FROM            ActualProduced_tbl AS ActualProduced_tbl_1
                                 WHERE        (FctProdID = FactoryWeeklyPlan_tbl.FctProdID)), 0) AS PackedQty, FinalBooking_master_1.AtcNO, WeeklyPlan_Master.stylenum
FROM            WeeklyPlan_Master INNER JOIN
                         FactoryWeeklyPlan_tbl ON WeeklyPlan_Master.WeekID = FactoryWeeklyPlan_tbl.WeekID INNER JOIN
                         FinalBooking_master ON WeeklyPlan_Master.Book_Id = FinalBooking_master.Book_Id INNER JOIN
                         FinalBooking_master AS FinalBooking_master_1 ON WeeklyPlan_Master.Book_Id = FinalBooking_master_1.Book_Id
WHERE        (FactoryWeeklyPlan_tbl.Factid = @factid) AND (FactoryWeeklyPlan_tbl.Year = @year) AND (FactoryWeeklyPlan_tbl.Month = @month))tt
 ", con);





                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@factid", factid);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        public DataTable ATCplanofFactory(String atcdetail)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"Select FctProdID, WeekID, Year ,Month,Weeknum, LineNum, DateofProd, AtcNO,  [PO#],  DeliveryDate , WeeklyRequirement,  FactoryTarget ,Produced , PackedQty,(FactoryTarget -Produced) as [BalanceToProduce],(Produced -PackedQty) as [BalanceToPack] from (
 
SELECT        FactoryWeeklyPlan_tbl.FctProdID, WeeklyPlan_Master.WeekID, FactoryWeeklyPlan_tbl.Weeknum, FactoryWeeklyPlan_tbl.LineNum, 
                         FactoryWeeklyPlan_tbl.DateofProd, FactoryWeeklyPlan_tbl.Ponum AS PO#, '0' AS DeliveryDate, WeeklyPlan_Master.Qty AS WeeklyRequirement, 
                         FactoryWeeklyPlan_tbl.TargetQty AS FactoryTarget, ISNULL
                             ((SELECT        ProducedQty
                                 FROM            ActualProduced_tbl
                                 WHERE        (FctProdID = FactoryWeeklyPlan_tbl.FctProdID)), 0) AS Produced, ISNULL
                             ((SELECT        SUM(PackedQty) AS Expr1
                                 FROM            ActualProduced_tbl AS ActualProduced_tbl_1
                                 WHERE        (FctProdID = FactoryWeeklyPlan_tbl.FctProdID)), 0) AS PackedQty, FinalBooking_master.AtcNO, FinalBooking_master.Month, 
                         FinalBooking_master.Year
FROM            WeeklyPlan_Master INNER JOIN
                         FactoryWeeklyPlan_tbl ON WeeklyPlan_Master.WeekID = FactoryWeeklyPlan_tbl.WeekID INNER JOIN
                         FinalBooking_master ON WeeklyPlan_Master.Book_Id = FinalBooking_master.Book_Id
WHERE        (FinalBooking_master.AtcNO =@atcdetail))tt
 
 ", con);


                cmd.Parameters.AddWithValue("@atcdetail", atcdetail);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }



        public DataTable OrderDetailsofYear(String Year)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        SUM(OrderBooking_tbl.BookQty) AS BookedQty, ISNULL(SUM(FinalBooking_master.BookQty), 0) AS ApprovedQty, 
                         ISNULL(SUM(FinalBooking_master.ConsumptionQty), 0) AS ConsumptionQty, OrderBooking_tbl.Month, OrderBooking_tbl.ISApproved, OrderBooking_tbl.Year
FROM            OrderBooking_tbl LEFT OUTER JOIN
                         FinalBooking_master ON OrderBooking_tbl.Order_id = FinalBooking_master.Order_Id
GROUP BY OrderBooking_tbl.Month, OrderBooking_tbl.ISApproved, OrderBooking_tbl.Year
HAVING        (OrderBooking_tbl.Year = @year) AND (OrderBooking_tbl.ISApproved <> N'R') 
 ", con);


                cmd.Parameters.AddWithValue("@year", @Year);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        public DataTable GetAvailabilityofAWeek(int year, String month, String Weeknum, int factid, float noofdaysinweek, int noofdaysinmonth)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();








                SqlCommand cmd = new SqlCommand(@"select  MonthlyCapacity , ISNULL(((MonthlyCapacity/@monthdays)*@weekdays) ,0)as WeeklyCapacity ,ISNULL((SELECT        SUM(WeeklyPlan_Master.Qty) 
FROM            Factory_Master INNER JOIN
                         WeeklyPlan_Master ON Factory_Master.Factory_ID = WeeklyPlan_Master.Factory_Id
GROUP BY Factory_Master.Factory_ID, WeeklyPlan_Master.Year, WeeklyPlan_Master.WeekNo, WeeklyPlan_Master.Month
HAVING        (Factory_Master.Factory_ID = @factid) AND (WeeklyPlan_Master.Year = @year) AND (WeeklyPlan_Master.WeekNo = @Weeknum) AND 
                         (WeeklyPlan_Master.Month = @month)),0) AS AlreadyAllocated from Factory_Master where Factory_ID=@factid ", con);

                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@factid", factid);
                cmd.Parameters.AddWithValue("@Weeknum", Weeknum);
                cmd.Parameters.AddWithValue("@weekdays", noofdaysinweek);
                cmd.Parameters.AddWithValue("@monthdays", noofdaysinmonth);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }




        public DataTable PendingOrderDetailForWeekPlan(String Year)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"  SELECT        FinalBooking_master.Book_Id, OrderBooking_tbl.Order_id, Factory_Master.Factory_name, FinalBooking_master.Year, FinalBooking_master.Month, 
                         Buyer_Master.BuyerName, FinalBooking_master.AtcNO, FinalBooking_master.Style, FinalBooking_master.BookQty, FinalBooking_master.ComplexityLevel
FROM            FinalBooking_master INNER JOIN
                         OrderBooking_tbl ON FinalBooking_master.Order_Id = OrderBooking_tbl.Order_id INNER JOIN
                         Factory_Master ON FinalBooking_master.Factory_id = Factory_Master.Factory_ID INNER JOIN
                         Buyer_Master ON OrderBooking_tbl.Buyer_ID = Buyer_Master.Buyer_Id AND FinalBooking_master.BuyerID = Buyer_Master.Buyer_Id
WHERE        (FinalBooking_master.Book_Id NOT IN
                             (SELECT DISTINCT Book_Id
                               FROM            WeeklyPlan_Master)) AND (FinalBooking_master.Year = @Year) ", con);


                cmd.Parameters.AddWithValue("@year", @Year);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }



        public DataTable PendingPOWithlessthan120days()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@" Select kk.* ,DATEDIFF(dd,GETDATE(),kk.productionmonthstart) as Daysleft from (select tt.Book_Id,tt.BuyerName,tt.Factory_name,tt.Year,tt.Month,tt.AtcNO,tt.Style ,tt.BookQty  ,DATEFROMPARTS (tt.year,tt.MonthNumber,01) as productionmonthstart from (SELECT        FinalBooking_master.Book_Id, FinalBooking_master.Year, 
                         CASE WHEN FinalBooking_master.Month = 'January' THEN 1 WHEN FinalBooking_master.Month = 'February' THEN 2 WHEN FinalBooking_master.Month = 'March' THEN 3 WHEN FinalBooking_master.Month = 'April'
                          THEN 4 WHEN FinalBooking_master.Month = 'May' THEN 5 WHEN FinalBooking_master.Month = 'June' THEN 6 WHEN FinalBooking_master.Month = 'July' THEN 7 WHEN FinalBooking_master.Month = 'August' THEN
                          8 WHEN FinalBooking_master.Month = 'September' THEN 9 WHEN FinalBooking_master.Month = 'October' THEN 10 WHEN FinalBooking_master.Month = 'November' THEN 11 WHEN FinalBooking_master.Month
                          = 'December' THEN 12 END AS MonthNumber, Buyer_Master.BuyerName,FinalBooking_master.Month ,FinalBooking_master.AtcNO, FinalBooking_master.BookQty, Factory_Master.Factory_name, FinalBooking_master.Style
FROM            FinalBooking_master INNER JOIN
                         Buyer_Master ON FinalBooking_master.BuyerID = Buyer_Master.Buyer_Id INNER JOIN
                         Factory_Master ON FinalBooking_master.Factory_id = Factory_Master.Factory_ID
WHERE        (FinalBooking_master.Book_Id NOT IN
                             (SELECT        Book_Id
                               FROM            WeeklyPlan_Master)))tt) kk where DATEDIFF(dd,GETDATE(),kk.productionmonthstart)<120 and( DATEDIFF(dd,GETDATE(),kk.productionmonthstart)>0) and kk.BookQty>0", con);


               

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }



        public DataTable pendingPOdata()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@" SELECT        Book_Id, isnull(RefernceNum,'NA') as RefernceNum, isnull(Ponum,'NA')as Ponum, BookQty, SUM(isnull(PoAllocatedQty,0)) AS POAllocatedQty,BookQty-SUM(isnull(PoAllocatedQty,0)) as BalanceToAllocate
FROM            (SELECT        FinalBooking_master.Book_Id, FinalBooking_master.AtcNO AS RefernceNum, WeeklyPlan_Master.PO# AS Ponum, SUM(FinalBooking_master.BookQty) AS BookQty, 
                         SUM(WeeklyPlan_Master.Qty) AS PoAllocatedQty
FROM            FinalBooking_master LEFT OUTER JOIN
                         WeeklyPlan_Master ON FinalBooking_master.Book_Id = WeeklyPlan_Master.Book_Id
GROUP BY FinalBooking_master.Book_Id, WeeklyPlan_Master.PO#, FinalBooking_master.AtcNO) AS tt
GROUP BY RefernceNum, Ponum, BookQty, Book_Id ", con);




                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;

        }

        /// <summary>
        /// Convert a datacontext to Datatable
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable ToDataTable(System.Data.Linq.DataContext ctx, object query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            IDbCommand cmd = ctx.GetCommand(query as IQueryable);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = (SqlCommand)cmd;
            DataTable dt = new DataTable("sd");

            try
            {
                cmd.Connection.Open();
                adapter.FillSchema(dt, SchemaType.Source);
                adapter.Fill(dt);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }





        /// <summary>
        /// Check Whether ithe day is Dayclosed for a location
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="factid"></param>
        /// <returns></returns>

        public Boolean isDayClosed(DateTime dt, int factid)
        {
            Boolean isclosed = false;

            using (CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr))
            {
                var q = (from daydetail in cntxt.ProductionDayClose_tbls
                         where daydetail.factid == factid && daydetail.DateofProd == dt
                         select daydetail).Count();
                if (q > 0)
                {
                    isclosed = true;
                }
                else
                {
                    isclosed = false;
                }
            }
            return isclosed;
        }



        /// <summary>
        /// Show All the Pending Production Entries that are needed to Split Po Wisw
        /// </summary>
        /// <param name="fromdate"></param>
        /// <param name="todate"></param>
        /// <param name="factid"></param>
        /// <returns></returns>
        public DataTable GetProductionPoPending(DateTime fromdate, DateTime todate, int factid)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                String q3 = @"SELECT    LineID ,    factid, DateOfProd , Atcnum, OurStyle,Linenum, Ponum, ProducedQty AS producedQty,isnull( (SELECT     sum(   POQty)
                               FROM            POProduced
                               WHERE        (DateofProd = ActualProduced_tbl.DateOfProd) AND (LineNum = ActualProduced_tbl.Linenum) AND (Factid = ActualProduced_tbl.factid) AND (AtcNum = ActualProduced_tbl.Atcnum)
),0) AS POQty
FROM            ActualProduced_tbl
GROUP BY LineID , factid, DateOfProd, Atcnum,Linenum, Ponum, ProducedQty,OurStyle
HAVING        (factid = @factid) AND (DateOfProd BETWEEN @fromdate AND @todate) ";



                //  cmd.CommandText = Query1;
                cmd.CommandText = q3;
                cmd.Parameters.AddWithValue("@fromdate", fromdate);
                cmd.Parameters.AddWithValue("@todate", todate);
                cmd.Parameters.AddWithValue("@factid", factid);



                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        # region Notification Area

        /// <summary>
        /// get All produced ATc which doesnt have A CM Allocated to that factory
        /// </summary>
        /// <param name="factid"></param>
        /// <returns></returns>
        public String  GetAtcProducedWithoutCM( int factid)
        {
            DataTable dt = new DataTable();
            String cmnotmade = "";
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                //                String q3 = @" SELECT     Distinct   Atcnum
                //FROM            ActualProduced_tbl
                //WHERE        (factid =@factid)
                //Except
                //SELECT     Distinct   Atc_master.AtcNum
                //FROM            Atc_master INNER JOIN
                //                         Cm_master ON Atc_master.Atc_id = Cm_master.Atc_id
                //WHERE        (Cm_master.Factory_id = @factid)




                String q3 = @" SELECT     Distinct   Atcnum
FROM            ActualProduced_tbl
WHERE        (factid =@factid)
Except
SELECT     Distinct   AtcMaster.AtcNum
FROM            AtcMaster INNER JOIN
                         Cm_master ON AtcMaster.Atcid = Cm_master.Atc_id
WHERE        (Cm_master.Factory_id = @factid)";









                //  cmd.CommandText = Query1;
                cmd.CommandText = q3;
               
                cmd.Parameters.AddWithValue("@factid", factid);



                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);

                if(dt!=null)
                {
                    cmnotmade = "";
               if(dt.Rows.Count >=1)
               {

                   for (int i = 0; i < dt.Rows.Count; i++)
			{
                       if (cmnotmade == "")
                   {
                       cmnotmade = cmnotmade + dt.Rows[i]["Atcnum"].ToString() + " Produced doesn't have a CM for you" + Environment.NewLine;
                   }
                   else
                   {
                       cmnotmade = cmnotmade + Environment.NewLine + dt.Rows[i]["Atcnum"].ToString() + " Produced doesn't have a CM for you" + Environment.NewLine;
                   }
			 
			}
                   
               }

                }

            }
            return cmnotmade;
        }
        /// <summary>
        /// get All produced ATc which doesnt have A Capacity assigned Allocated to that factory
        /// </summary>
        /// <param name="factid"></param>
        /// <returns></returns>
        public String GetProducedWithoutLineCapacity(int factid)
        {
            DataTable dt = new DataTable();
            String cmnotmade = "";
            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                String q3 = @" SELECT        ActualProduced_tbl.Atcnum, ActualProduced_tbl.Linenum, ActualProduced_tbl.DateOfProd
FROM            ActualProduced_tbl LEFT OUTER JOIN
                         LineAtcCapacity_tbl ON ActualProduced_tbl.LineID = LineAtcCapacity_tbl.LineID AND ActualProduced_tbl.factid = LineAtcCapacity_tbl.Factid
WHERE        (LineAtcCapacity_tbl.Factid IS NULL) AND (LineAtcCapacity_tbl.LineID IS NULL) AND (ActualProduced_tbl.factid = @factid) AND (ActualProduced_tbl.DateOfProd > CONVERT(DATETIME, '2015-10-25 00:00:00', 102))

";



                //  cmd.CommandText = Query1;
                cmd.CommandText = q3;

                cmd.Parameters.AddWithValue("@factid", factid);



                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);

                if (dt != null)
                {
                    if (dt.Rows.Count >= 1)
                    {
                        cmnotmade = "";

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (cmnotmade == "")
                            {
                                cmnotmade = cmnotmade + dt.Rows[i]["Atcnum"].ToString() + " Produced in " + dt.Rows[i]["Linenum"].ToString() + " at  " + DateTime.Parse(dt.Rows[i]["DateOfProd"].ToString()).ToString("dd/MM/yyyy") + " is not Planned" + Environment.NewLine;
                            }
                            else
                            {
                                cmnotmade = cmnotmade + Environment.NewLine + dt.Rows[i]["Atcnum"].ToString() + " Produced in " + dt.Rows[i]["Linenum"].ToString() + " at  " + DateTime.Parse ( dt.Rows[i]["DateOfProd"].ToString()).ToString ("dd/MM/yyyy") + " is not Planned" + Environment.NewLine;
                            }

                        }

                    }

                }

            }
            return cmnotmade;
        }

//        public String GetProducedWithoutLineCapacity(int factid)
//        {
//            DataTable dt = new DataTable();
//            String cmnotmade = "";
//            using (SqlConnection con = new SqlConnection(Program.ConnStr))
//            {
//                con.Open();
//                SqlCommand cmd = new SqlCommand();
//                cmd.Connection = con;


//                String q3 = @" SELECT        ActualProduced_tbl.Atcnum, ActualProduced_tbl.Linenum, ActualProduced_tbl.DateOfProd
//FROM            ActualProduced_tbl LEFT OUTER JOIN
//                         LineAtcCapacity_tbl ON ActualProduced_tbl.LineID = LineAtcCapacity_tbl.LineID AND ActualProduced_tbl.factid = LineAtcCapacity_tbl.Factid
//WHERE        (LineAtcCapacity_tbl.Factid IS NULL) AND (LineAtcCapacity_tbl.LineID IS NULL) AND (ActualProduced_tbl.factid = @factid) AND (ActualProduced_tbl.DateOfProd > CONVERT(DATETIME, '2015-10-25 00:00:00', 102))
//
//";



//                //  cmd.CommandText = Query1;
//                cmd.CommandText = q3;

//                cmd.Parameters.AddWithValue("@factid", factid);



//                SqlDataReader rdr = cmd.ExecuteReader();

//                dt.Load(rdr);

//                if (dt != null)
//                {
//                    if (dt.Rows.Count >= 1)
//                    {
//                        cmnotmade = "";

//                        for (int i = 0; i < dt.Rows.Count; i++)
//                        {
//                            if (cmnotmade == "")
//                            {
//                                cmnotmade = cmnotmade + dt.Rows[i]["Atcnum"].ToString() + " Produced in " + dt.Rows[i]["Linenum"].ToString() + " at  " + DateTime.Parse(dt.Rows[i]["DateOfProd"].ToString()).ToString("dd/MM/yyyy") + " is not Planned" + Environment.NewLine;
//                            }
//                            else
//                            {
//                                cmnotmade = cmnotmade + Environment.NewLine + dt.Rows[i]["Atcnum"].ToString() + " Produced in " + dt.Rows[i]["Linenum"].ToString() + " at  " + DateTime.Parse(dt.Rows[i]["DateOfProd"].ToString()).ToString("dd/MM/yyyy") + " is not Planned" + Environment.NewLine;
//                            }

//                        }

//                    }

//                }

//            }
//            return cmnotmade;
//        }

        #endregion


    }
}
