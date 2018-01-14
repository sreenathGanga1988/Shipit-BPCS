using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Shipit.Production
{
    class Productiontransaction
    {
        public DataTable GetAllFinalBookings(int year,String Month,int factoryid)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


//                SqlCommand cmd = new SqlCommand(@"SELECT    FinalBooking_master.Book_id, Buyer_Master.BuyerName as Buyer, FinalBooking_master.AtcNO as Atc# , FinalBooking_master.Style as Style, FinalBooking_master.BookQty as BookQty,isnull( (SELECT        SUM(Qty) AS Expr1
//FROM            WeeklyPlan_Master
//GROUP BY Year, Month, WeekNo, Factory_Id ,Book_Id
//HAVING        (WeekNo = N'Week1') AND (Factory_Id = FinalBooking_master.Factory_id ) AND (Year = @year) AND (Month = @month)and Book_Id=FinalBooking_master.Book_Id ) ,0)as Week1, isnull((SELECT        SUM(Qty) AS Expr1
//FROM            WeeklyPlan_Master
//GROUP BY Year, Month, WeekNo, Factory_Id,Book_Id
//HAVING        (WeekNo = N'Week2') AND (Factory_Id = FinalBooking_master.Factory_id ) AND (Year = @year) AND (Month = @month) and Book_Id=FinalBooking_master.Book_Id ),0) as Week2,isnull( (SELECT      SUM(Qty) AS Expr1
//FROM            WeeklyPlan_Master
//GROUP BY Year, Month, WeekNo, Factory_Id,Book_Id
//HAVING        (WeekNo = N'Week3') AND (Factory_Id = FinalBooking_master.Factory_id ) AND (Year = @year) AND (Month = @month)and Book_Id=FinalBooking_master.Book_Id ),0) as Week3,isnull( (SELECT      SUM(Qty) AS Expr1
//FROM            WeeklyPlan_Master
//GROUP BY Year, Month, WeekNo, Factory_Id,Book_Id
//HAVING        (WeekNo = N'Week4') AND (Factory_Id = FinalBooking_master.Factory_id ) AND (Year = @year) AND (Month = @month)and Book_Id=FinalBooking_master.Book_Id ) ,0)as Week4 , isnull((SELECT        SUM(Qty) AS Expr1
//FROM            WeeklyPlan_Master
//GROUP BY Year, Month, WeekNo, Factory_Id,Book_Id
//HAVING        (WeekNo = N'Week5') AND (Factory_Id = FinalBooking_master.Factory_id ) AND (Year = @year) AND (Month = @month) and Book_Id=FinalBooking_master.Book_Id ),0) as Week5, '0' as [Balance to Schedule]
//FROM            FinalBooking_master INNER JOIN
//                         Buyer_Master ON FinalBooking_master.BuyerID = Buyer_Master.Buyer_Id
//WHERE        (FinalBooking_master.Factory_id = @factid) AND (FinalBooking_master.Year = @year) AND (FinalBooking_master.Month = @month)", con);

                SqlCommand cmd = new SqlCommand(@"SELECT FinalBooking_master.Book_Id, Buyer_Master.BuyerName AS Buyer, FinalBooking_master.AtcNO AS Atc#, FinalBooking_master.Style, FinalBooking_master.BookQty, ISNULL
                      ((SELECT SUM(Qty) AS Expr1
                        FROM      WeeklyPlan_Master
                        GROUP BY Year, Month, WeekNo, Factory_Id, Book_Id
                        HAVING  (WeekNo = N'Week1') AND (Factory_Id = FinalBooking_master.Factory_id) AND (Year = @year) AND (Month = @month) AND (Book_Id = FinalBooking_master.Book_Id)), 0) AS Week1, ISNULL
                      ((SELECT SUM(Qty) AS Expr1
                        FROM      WeeklyPlan_Master AS WeeklyPlan_Master_4
                        GROUP BY Year, Month, WeekNo, Factory_Id, Book_Id
                        HAVING  (WeekNo = N'Week2') AND (Factory_Id = FinalBooking_master.Factory_id) AND (Year = @year) AND (Month = @month) AND (Book_Id = FinalBooking_master.Book_Id)), 0) AS Week2, ISNULL
                      ((SELECT SUM(Qty) AS Expr1
                        FROM      WeeklyPlan_Master AS WeeklyPlan_Master_3
                        GROUP BY Year, Month, WeekNo, Factory_Id, Book_Id
                        HAVING  (WeekNo = N'Week3') AND (Factory_Id = FinalBooking_master.Factory_id) AND (Year = @year) AND (Month = @month) AND (Book_Id = FinalBooking_master.Book_Id)), 0) AS Week3, ISNULL
                      ((SELECT SUM(Qty) AS Expr1
                        FROM      WeeklyPlan_Master AS WeeklyPlan_Master_2
                        GROUP BY Year, Month, WeekNo, Factory_Id, Book_Id
                        HAVING  (WeekNo = N'Week4') AND (Factory_Id = FinalBooking_master.Factory_id) AND (Year = @year) AND (Month = @month) AND (Book_Id = FinalBooking_master.Book_Id)), 0) AS Week4, ISNULL
                      ((SELECT SUM(Qty) AS Expr1
                        FROM      WeeklyPlan_Master AS WeeklyPlan_Master_1
                        GROUP BY Year, Month, WeekNo, Factory_Id, Book_Id
                        HAVING  (WeekNo = N'Week5') AND (Factory_Id = FinalBooking_master.Factory_id) AND (Year = @year) AND (Month = @month) AND (Book_Id = FinalBooking_master.Book_Id)), 0) AS Week5,
                  (FinalBooking_master.BookQty-ISNULL((sELECT sUM(W.Qty) FROM WeeklyPlan_Master w WHERE W.Book_Id=FinalBooking_master.Book_Id ),0))   AS [Balance to Schedule]
                            
                             
                             , OrderBooking_tbl.ISApproved
FROM     FinalBooking_master INNER JOIN
                  Buyer_Master ON FinalBooking_master.BuyerID = Buyer_Master.Buyer_Id INNER JOIN
                  OrderBooking_tbl ON FinalBooking_master.Order_Id = OrderBooking_tbl.Order_id
WHERE  (FinalBooking_master.Factory_id = @factid) AND (FinalBooking_master.Year = @year) AND (FinalBooking_master.Month = @month) AND (OrderBooking_tbl.ISApproved = N'A')", con);

                cmd.Parameters.AddWithValue("@factid", factoryid);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@month", Month);
               



                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }

        public DataTable GetweeklyAllocationofamonth(String month, int year, int factid)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        WeeklyPlan_Master.Factory_Id, WeeklyPlan_Master.WeekID, WeeklyPlan_Master.Month, WeeklyPlan_Master.Year, WeeklyPlan_Master.WeekNo as Week, 
                         FinalBooking_master.AtcNO, WeeklyPlan_Master.ActualDelivery_date,WeeklyPlan_Master.InhouseDate as PSD, WeeklyPlan_Master.PO#, WeeklyPlan_Master.stylenum,WeeklyPlan_Master.Qty
FROM            WeeklyPlan_Master INNER JOIN
                         FinalBooking_master ON WeeklyPlan_Master.Book_Id = FinalBooking_master.Book_Id
WHERE        (WeeklyPlan_Master.Factory_Id = @factid) AND (WeeklyPlan_Master.Month = @month) AND (WeeklyPlan_Master.Year = @year)", con);




                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@factid", factid);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }
    }
}
