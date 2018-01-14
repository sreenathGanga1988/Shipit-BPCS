using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Shipit.Transaction
{
    class PlanTransaction
    {
        /// <summary>
        /// get all the atclines of a factory
        /// </summary>
        /// <returns></returns>
        public DataTable GetLinesForEnteringCapacity()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string Query1 = @"SELECT        FactoryID, Lineid, LineNum, 000000 AS DailyCapacity, 000000 AS [No Of Machines], 000000 AS [No Of Operators], 000000 AS [No Of Helpers]
FROM            LineMaster
WHERE        (IsWorking = N'Y') AND (FactoryID = @factid)";

                
                    cmd.CommandText = Query1;
                    cmd.Parameters.AddWithValue("@factid", Program.lctnpk);
                               
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        /// <summary>
        /// get maxof PSD and PODelivery Date Along with sum of PO
        /// </summary>
        /// <returns></returns>
        public DataTable GetPSDAndPDDOFPO(String PO)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string Query1 = @"SELECT        MIN(InhouseDate) AS PSD, MAX(ActualDelivery_date) AS PoDeliverydate,sum(qty) as totalqty
FROM            WeeklyPlan_Master
GROUP BY PO#
HAVING        (PO# = @PONUm)";


                cmd.CommandText = Query1;
                cmd.Parameters.AddWithValue("@PONUm", PO);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }



        /// <summary>
        /// get all the atclines of a factory
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllLineplanBetweenDate(DateTime fromdate ,DateTime todate)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string Query1 = @"SELECT        Year, Month, Weeknum, FctProdID, LineID, LineNum,AtcNum, Ponum, DateofProd, TargetQty
FROM            FactoryWeeklyPlan_tbl
WHERE        (DateofProd BETWEEN @param1 AND @param2) AND (Factid = @factid)";


                cmd.CommandText = Query1;
                cmd.Parameters.AddWithValue("@factid", Program.lctnpk);
                cmd.Parameters.AddWithValue("@param1", fromdate );
                cmd.Parameters.AddWithValue("@param2", todate);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        public DataTable GetAllLinesAndCapacityOFAtc(String Atcnum)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string Query1 = @"SELECT       distinct  LineNum, LineID, DailyCaspacity
FROM            LineAtcCapacity_tbl
WHERE        (Atcnum = @atc) AND (Factid = @factid)";


                cmd.CommandText = Query1;
                cmd.Parameters.AddWithValue("@factid", Program.lctnpk);
                cmd.Parameters.AddWithValue("@atc", Atcnum);
               

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }

    }
}
