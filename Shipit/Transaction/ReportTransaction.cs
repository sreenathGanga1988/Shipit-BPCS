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
    public class ReportTransaction
    {
        public DataTable bookvsWeekplan(int year)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        OrderBooking_tbl.Order_id, FinalBooking_master.Book_Id, OrderBooking_tbl.Year, OrderBooking_tbl.Month, OrderBooking_tbl.BookQty, OrderBooking_tbl.Style, 
                         Factory_Master.Factory_name, Buyer_Master.BuyerName, OrderBooking_tbl.UserId, OrderBooking_tbl.ISApproved, FinalBooking_master.ComplexityLevel, 
                         FinalBooking_master.AtcNO, FinalBooking_master.ConsumptionQty, FinalBooking_master.CategoryID, FinalBooking_master.BookQty AS ApprovedQty, 
                         WeeklyPlan_Master.Qty, WeeklyPlan_Master.PO#, WeeklyPlan_Master.ActualDelivery_date
FROM            OrderBooking_tbl INNER JOIN
                         Factory_Master ON OrderBooking_tbl.Factory_Id = Factory_Master.Factory_ID INNER JOIN
                         Buyer_Master ON OrderBooking_tbl.Buyer_ID = Buyer_Master.Buyer_Id LEFT OUTER JOIN
                         FinalBooking_master ON OrderBooking_tbl.Order_id = FinalBooking_master.Order_Id FULL OUTER JOIN
                         WeeklyPlan_Master ON FinalBooking_master.Book_Id = WeeklyPlan_Master.Book_Id
WHERE        (OrderBooking_tbl.Year = @year) AND (OrderBooking_tbl.ISApproved <> N'R')", con);



                cmd.Parameters.AddWithValue("@year", year);


                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);





            }
            return dt;
        }

        public DataTable BalancePoToAllocate()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string Query1 = @"SELECT    Factory_name,  Month,   Book_Id, ISNULL(RefernceNum, 'NA') AS Ref#, ISNULL(Ponum, 'NA') AS Po#, MAX(BookQty), SUM(ISNULL(PoAllocatedQty, 0)) AS POAllocatedQty, 
                         BookQty - SUM(ISNULL(PoAllocatedQty, 0)) AS BalanceToAllocate
FROM            (SELECT        Factory_Master.Factory_name, FinalBooking_master.Month, FinalBooking_master.Book_Id, FinalBooking_master.AtcNO AS RefernceNum, 
                         WeeklyPlan_Master.PO# AS Ponum, MAX(FinalBooking_master.BookQty) AS BookQty, SUM(ISNULL(WeeklyPlan_Master.Qty, 0)) AS PoAllocatedQty
FROM            FinalBooking_master INNER JOIN
                         Factory_Master ON FinalBooking_master.Factory_id = Factory_Master.Factory_ID LEFT OUTER JOIN
                         WeeklyPlan_Master ON FinalBooking_master.Book_Id = WeeklyPlan_Master.Book_Id
GROUP BY FinalBooking_master.Month, FinalBooking_master.Book_Id, FinalBooking_master.AtcNO, WeeklyPlan_Master.PO#, Factory_Master.Factory_name) AS tt
GROUP BY  Factory_name ,Month, Book_Id,RefernceNum, Ponum, BookQty";


                cmd.CommandText = Query1;





                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }




        public DataTable  GetPOPROJECTION(DateTime fromdate, DateTime todate)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string Query1 = @"SELECT       Factory_Master.Factory_name, WeeklyPlan_Master.PO#, SUM(WeeklyPlan_Master.Qty) AS Qty, WeeklyPlan_Master.stylenum, FinalBooking_master.AtcNO,
                          WeeklyPlan_Master.ActualDelivery_date, Buyer_Master.BuyerName
FROM            WeeklyPlan_Master INNER JOIN
                         Factory_Master ON WeeklyPlan_Master.Factory_Id = Factory_Master.Factory_ID INNER JOIN
                         FinalBooking_master ON WeeklyPlan_Master.Book_Id = FinalBooking_master.Book_Id INNER JOIN
                         Buyer_Master ON FinalBooking_master.BuyerID = Buyer_Master.Buyer_Id
GROUP BY WeeklyPlan_Master.Month, WeeklyPlan_Master.Year, Factory_Master.Factory_name, WeeklyPlan_Master.PO#, WeeklyPlan_Master.stylenum, FinalBooking_master.AtcNO, 
                         WeeklyPlan_Master.ActualDelivery_date, Buyer_Master.BuyerName
HAVING        (WeeklyPlan_Master.ActualDelivery_date BETWEEN @param1 AND @param2)";


                cmd.CommandText = Query1;

                cmd.Parameters.AddWithValue("@param1", fromdate);
                cmd.Parameters.AddWithValue("@param2", todate);



                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }











        public DataTable AtcLineCapacity()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string Query1 = @"SELECT        LineAtcCapacity_tbl.LinCapID, Factory_Master.Factory_name, LineAtcCapacity_tbl.Atcnum, LineAtcCapacity_tbl.LineNum, LineAtcCapacity_tbl.DailyCaspacity, 
                         LineAtcCapacity_tbl.NoOfOperators, LineAtcCapacity_tbl.NoOfHelper, LineAtcCapacity_tbl.TotalHours, LineAtcCapacity_tbl.NoOFMachines, 
                         LineAtcCapacity_tbl.AddedBy, LineAtcCapacity_tbl.AddedDate
FROM            LineAtcCapacity_tbl INNER JOIN
                         Factory_Master ON LineAtcCapacity_tbl.Factid = Factory_Master.Factory_ID";


                cmd.CommandText = Query1;





                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }

        public DataTable GetAtcPendingForCMEntry()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string Query1 = @"SELECT        AtcMaster.AtcId, AtcMaster.AtcNum, AtcDetails.OurStyle
FROM            AtcMaster INNER JOIN
                         AtcDetails ON AtcMaster.AtcId = AtcDetails.AtcId LEFT OUTER JOIN
                         CmMaster ON AtcDetails.OurStyleID = CmMaster.OurStyleID WHERE        (CmMaster.CmId IS NULL)";


                cmd.CommandText = Query1;





                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }



        public DataTable GetPlannedvsactual()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string Query1 = @"SELECT        ApprovedProj_tbl.Projnum, ApprovedProj_tbl.Factoryname, ApprovedProj_tbl.Linenum, ApprovedProj_tbl.Atcnum, ApprovedProj_tbl.ObOperator, ApprovedProj_tbl.ObHelper, ApprovedProj_tbl.ObTarget, 
                         ApprovedProj_tbl.PcPermac, ApprovedProj_tbl.LoadPlanOperator, ApprovedProj_tbl.LoadfPlanHelper, ApprovedProj_tbl.LineCapacity, ApprovedProj_tbl.TotalQty, ApprovedProj_tbl.DolorValue, 
                         MAX(ACTUALPRODUCTION.ActualOperator) AS ActualOperator, MAX(ACTUALPRODUCTION.Actualhealper) AS Actualhealper, MAX(ACTUALPRODUCTION.actualOthours) AS actualOthours, 
                         ACTUALPRODUCTION.DateOfProd, ApprovedProj_tbl.IsApproved, sum(ACTUALPRODUCTION.pRODUCEDqTY) as producedQty
FROM            ApprovedProj_tbl INNER JOIN
                             (SELECT        SUM(ProducedQty) AS pRODUCEDqTY, Atcnum, Linenum, LineID, factid, MAX(Operators) AS ActualOperator, MAX(Helpers) AS Actualhealper, MAX(Hours) AS actualOthours, DateOfProd, 
                                                         ProducedID
                               FROM            ActualProduced_tbl
                               GROUP BY Atcnum, Linenum, LineID, factid, DateOfProd, ProducedID) AS ACTUALPRODUCTION ON ApprovedProj_tbl.LineID = ACTUALPRODUCTION.LineID AND 
                         ApprovedProj_tbl.Atcnum = ACTUALPRODUCTION.Atcnum AND ApprovedProj_tbl.Linenum = ACTUALPRODUCTION.Linenum
GROUP BY ApprovedProj_tbl.Projnum, ApprovedProj_tbl.Factoryname, ApprovedProj_tbl.Linenum, ApprovedProj_tbl.Atcnum, ApprovedProj_tbl.ObOperator, ApprovedProj_tbl.ObHelper, ApprovedProj_tbl.ObTarget, 
                         ApprovedProj_tbl.PcPermac, ApprovedProj_tbl.LoadPlanOperator, ApprovedProj_tbl.LoadfPlanHelper, ApprovedProj_tbl.LineCapacity, ApprovedProj_tbl.TotalQty, ApprovedProj_tbl.DolorValue, 
                         ACTUALPRODUCTION.DateOfProd, ApprovedProj_tbl.IsApproved";


                cmd.CommandText = Query1;





                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }










        public DataTable Projectiondata(DateTime fromdate, DateTime todate,int factid)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //                string Query1 = @"SELECT        FactoryWeeklyPlan_tbl.LineID, Factory_Master.Factory_name, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, MAX(Cm_master.FcmQty) 
                //                         / 100 * 80 AS SewingFcm, MAX(Cm_master.FcmQty) / 100 * 20 AS FinishingFcm, Cm_master.BreakEvenFcmEfficiency, MAX(Cm_master.OBOperators) AS OBOperators, MAX(Cm_master.ObHelpers) 
                //                         AS OBHelpers, Cm_master.OBTarget, MAX(Cm_master.PcsPermachine) AS [PCS/MA], ISNULL(LineAtcCapacity_tbl.NoOfOperators, 0) AS LoadPlanOperator, 
                //                         ISNULL(LineAtcCapacity_tbl.NoOfHelper, 0) AS LoadPlanHelpers, ISNULL(LineAtcCapacity_tbl.DailyCaspacity, 0) AS Linecapacity, 
                //                         SUM(FactoryWeeklyPlan_tbl.TargetQty) AS TotalQty,  0000 AS [Avg OBHelpertoOpr Ratio], 0000 AS [Avg LPHelpertoOpr Ratio], 0000 AS [What is 100% Qty],000 AS percentOB, SUM(FactoryWeeklyPlan_tbl.TargetQty) * MAX(Cm_master.FcmQty) 
                //                         / 100 * 80 / 12 AS Dollarvalue, 0000 AS SewingQtyrequired, Cm_master.BreakEvenFcmEfficiency AS ObPercentageRequired, 0000 AS Dollorvaluerequired, 0000 AS FinishingQtyRecieved, 
                //                         0000 AS finisheddollorrequired, LineAtcCapacity_tbl.TotalHours,'000' as [is LOad Plan Qty Accepted],000 as [sew qty rqd],000 as [Eff rqd],000 as [Sew Val rqd],000 as [fin Qty rqd],000 as [fin Value rqd],000 as [Total CM Value]
                //FROM            Atc_master INNER JOIN
                //                         Cm_master ON Atc_master.Atc_id = Cm_master.Atc_id INNER JOIN
                //                         FactoryWeeklyPlan_tbl ON Atc_master.AtcNum = FactoryWeeklyPlan_tbl.AtcNum INNER JOIN
                //                         Factory_Master ON Cm_master.Factory_id = Factory_Master.Factory_ID LEFT OUTER JOIN
                //                         LineAtcCapacity_tbl ON Atc_master.AtcNum = LineAtcCapacity_tbl.Atcnum AND FactoryWeeklyPlan_tbl.LineID = LineAtcCapacity_tbl.LineID
                //WHERE        (FactoryWeeklyPlan_tbl.DateofProd BETWEEN @param1 AND @param2)
                //GROUP BY FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, LineAtcCapacity_tbl.NoOfOperators, LineAtcCapacity_tbl.NoOfHelper, 
                //                         FactoryWeeklyPlan_tbl.LineID, LineAtcCapacity_tbl.DailyCaspacity, Cm_master.OBTarget, LineAtcCapacity_tbl.TotalHours, Factory_Master.Factory_name, 
                //                         Cm_master.BreakEvenFcmEfficiency";



                //                String q2 = @"SELECT        FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, MAX(Cm_master.OBOperators) AS Operators FactoryWeeklyPlan_tbl.AtcNum, MAX(Cm_master.FcmQty) 
                //                         / 100 * 80 AS SewingFcm, MAX(Cm_master.FcmQty) / 100 * 20 AS FinishingFcm, Cm_master.BreakEvenFcmEfficiency, MAX(Cm_master.ObHelpers) AS Helpers, 
                //                         MAX(Cm_master.PcsPermachine) AS [PCS/MA], SUM(ISNULL(LineAtcCapacity_tbl.NoOfOperators, 0)) AS LoadPlanOperator, 
                //                         MAX(ISNULL(LineAtcCapacity_tbl.NoOfHelper, 0)) AS LoadPlanHelpers, MAX(ISNULL(LineAtcCapacity_tbl.DailyCaspacity, 0)) AS Linecapacity, 
                //                         SUM(FactoryWeeklyPlan_tbl.TargetQty) AS TotalQty, 000 AS percentOB, 0000 AS SewingQtyrequired, 0000 AS ObPercentageRequired, 0000 AS Dollorvaluerequired, 
                //                         0000 AS FinishingQtyRecieved, 0000 AS finisheddollorrequired
                //FROM            Atc_master INNER JOIN
                //                         Cm_master ON Atc_master.Atc_id = Cm_master.Atc_id INNER JOIN
                //                         FactoryWeeklyPlan_tbl ON Atc_master.AtcNum = FactoryWeeklyPlan_tbl.AtcNum LEFT OUTER JOIN
                //                         LineAtcCapacity_tbl ON Atc_master.AtcNum = LineAtcCapacity_tbl.Atcnum AND FactoryWeeklyPlan_tbl.LineID = LineAtcCapacity_tbl.LineID
                //WHERE        (FactoryWeeklyPlan_tbl.DateofProd BETWEEN @param1 AND @param2)
                //GROUP BY FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum";

                //                String q3 = @"SELECT        FactoryWeeklyPlan_tbl.LineID, Factory_Master.Factory_name, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, MAX(Cm_master.FcmQty) 
                //                         / 100 * 80 AS SewingFcm, MAX(Cm_master.FcmQty) / 100 * 20 AS FinishingFcm,
                //                         MAX(Cm_master.BreakEvenFcmEfficiency) AS BreakEvenFcmEfficiency, MAX(Cm_master.OBOperators) AS OBOperators, MAX(Cm_master.ObHelpers) AS OBHelpers, 
                //                         MAX(Cm_master.OBTarget) AS OBTarget, MAX(Cm_master.PcsPermachine) AS [PCS/MA], MAX(ISNULL(LineAtcCapacity_tbl.NoOfOperators, 0)) AS LoadPlanOperator, 
                //                         MAX(ISNULL(LineAtcCapacity_tbl.NoOfHelper, 0)) AS LoadPlanHelpers, 0000 AS [Avg OBHelpertoOpr Ratio], 0000 AS [Avg LPHelpertoOpr Ratio], 0000 AS [What is 100% Qty], MAX(ISNULL(LineAtcCapacity_tbl.DailyCaspacity, 0)) AS Linecapacity, MAX(0000) AS TotalQty, 
                //                         000 AS percentOB, 0000 AS Dollarvalue ,0000 AS SewingQtyrequired, MAX(Cm_master.BreakEvenFcmEfficiency) AS ObPercentageRequired, 0000 AS Dollorvaluerequired, 
                //                         0000 AS FinishingQtyRecieved, 0000 AS finisheddollorrequired, LineAtcCapacity_tbl.TotalHours,'000' as [Is LOad Plan Qty Accepted],000 as [sew qty rqd],000 as [Eff rqd],000 as [Sew Val rqd],000 as [fin Qty rqd],000 as [fin Value rqd],000 as [Total CM Value],000 as [Per Machine Revenue]          
                //FROM            Atc_master INNER JOIN
                //                         Cm_master ON Atc_master.Atc_id = Cm_master.Atc_id INNER JOIN
                //                         FactoryWeeklyPlan_tbl ON Atc_master.AtcNum = FactoryWeeklyPlan_tbl.AtcNum AND Cm_master.Factory_id = FactoryWeeklyPlan_tbl.Factid INNER JOIN
                //                         Factory_Master ON Cm_master.Factory_id = Factory_Master.Factory_ID LEFT OUTER JOIN
                //                         LineAtcCapacity_tbl ON FactoryWeeklyPlan_tbl.Factid = LineAtcCapacity_tbl.Factid AND Atc_master.AtcNum = LineAtcCapacity_tbl.Atcnum AND 
                //                         FactoryWeeklyPlan_tbl.LineID = LineAtcCapacity_tbl.LineID
                //						 WHERE        (FactoryWeeklyPlan_tbl.DateofProd BETWEEN @param1 AND @param2)
                //GROUP BY FactoryWeeklyPlan_tbl.LineID, Factory_Master.Factory_name, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, 
                //                         LineAtcCapacity_tbl.TotalHours";


                //                String q4 = @"SELECT        FactoryWeeklyPlan_tbl.LineID, Factory_Master_1.Factory_name, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, MAX(Cm_master.FcmQty) / 100 * 80 AS SewingFcm, MAX(Cm_master.FcmQty) 
                //                         / 100 * 20 AS FinishingFcm,
                //                             (SELECT        CPM
                //                               FROM            Factory_Master
                //                               WHERE        (Factory_ID = FactoryWeeklyPlan_tbl.Factid)) / (MAX(Cm_master.FcmQty) / 12) / MAX(Cm_master.PcsPermachine) * 100 AS BreakEvenFcmEfficiency, MAX(Cm_master.OBOperators) AS OBOperators, 
                //                         MAX(Cm_master.ObHelpers) AS OBHelpers, MAX(Cm_master.OBTarget) AS OBTarget, MAX(Cm_master.PcsPermachine) AS [PCS/MA], MAX(ISNULL(LineAtcCapacity_tbl.NoOfOperators, 0)) AS LoadPlanOperator, 
                //                         MAX(ISNULL(LineAtcCapacity_tbl.NoOfHelper, 0)) AS LoadPlanHelpers, 0000.00 AS [Avg OBHelpertoOpr Ratio], 0000.00 AS [Avg LPHelpertoOpr Ratio], 0000 AS [What is 100% Qty], 
                //                         MAX(ISNULL(LineAtcCapacity_tbl.DailyCaspacity, 0)) AS Linecapacity, MAX(0000) AS TotalQty, 000 AS percentOB, 0000 AS Dollarvalue, 0000 AS SewingQtyrequired,
                //                             (SELECT        CPM
                //                               FROM            Factory_Master AS Factory_Master_2
                //                               WHERE        (Factory_ID = FactoryWeeklyPlan_tbl.Factid)) / (MAX(Cm_master.FcmQty) / 12) / MAX(Cm_master.PcsPermachine) * 100 AS ObPercentageRequired, 0000 AS Dollorvaluerequired, 
                //                         0000 AS FinishingQtyRecieved, 0000 AS finisheddollorrequired, LineAtcCapacity_tbl.TotalHours, '000' AS [Is LOad Plan Qty Accepted], 000 AS [sew qty rqd], 000 AS [Eff rqd], 000 AS [Sew Val rqd], 
                //                         000 AS [fin Qty rqd], 000 AS [fin Value rqd], 000 AS [Total CM Value], 000 AS [Load  Plan Hours], 000 AS [Days Planned], 000 AS [Days in Period], 000 AS [Total Hours Planned], 0000.0 AS [Operators Planned], 
                //                         000 AS [Per Machine Revenue]
                //FROM            Cm_master INNER JOIN
                //                         FactoryWeeklyPlan_tbl ON Cm_master.Factory_id = FactoryWeeklyPlan_tbl.Factid INNER JOIN
                //                         Factory_Master AS Factory_Master_1 ON Cm_master.Factory_id = Factory_Master_1.Factory_ID INNER JOIN
                //                         AtcMaster ON Cm_master.Atc_id = AtcMaster.AtcId AND FactoryWeeklyPlan_tbl.AtcNum = AtcMaster.AtcNum LEFT OUTER JOIN
                //                         LineAtcCapacity_tbl ON AtcMaster.AtcNum = LineAtcCapacity_tbl.Atcnum AND FactoryWeeklyPlan_tbl.Factid = LineAtcCapacity_tbl.Factid AND FactoryWeeklyPlan_tbl.LineID = LineAtcCapacity_tbl.LineID
                //WHERE        (FactoryWeeklyPlan_tbl.DateofProd BETWEEN @param1 AND @param2) AND (FactoryWeeklyPlan_tbl.Factid = @factid)
                //GROUP BY FactoryWeeklyPlan_tbl.LineID, Factory_Master_1.Factory_name, FactoryWeeklyPlan_tbl.Factid, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, LineAtcCapacity_tbl.TotalHours";

                //  cmd.CommandText = Query1;



                //                String q4 = @"SELECT        FactoryWeeklyPlan_tbl.LineID, Factory_Master_1.Factory_name, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, MAX(CmMaster.FcmQty) / 100 * 80 AS SewingFcm, MAX(CmMaster.FcmQty) 
                //                         / 100 * 20 AS FinishingFcm,
                //                             (SELECT        CPM
                //                               FROM            Factory_Master
                //                               WHERE        (Factory_ID = FactoryWeeklyPlan_tbl.Factid)) / (MAX(CmMaster.FcmQty) / 12) / MAX(CmMaster.PcsPermachine) * 100 AS BreakEvenFcmEfficiency, MAX(CmMaster.OBOperators) AS OBOperators, 
                //                         MAX(CmMaster.ObHelpers) AS OBHelpers, MAX(CmMaster.OBTarget) AS OBTarget, MAX(CmMaster.PcsPermachine) AS [PCS/MA], MAX(ISNULL(LineAtcCapacity_tbl.NoOfOperators, 0)) AS LoadPlanOperator, 
                //                         MAX(ISNULL(LineAtcCapacity_tbl.NoOfHelper, 0)) AS LoadPlanHelpers, 0000.00 AS [Avg OBHelpertoOpr Ratio], 0000.00 AS [Avg LPHelpertoOpr Ratio], 0000 AS [What is 100% Qty], 
                //                         MAX(ISNULL(LineAtcCapacity_tbl.DailyCaspacity, 0)) AS Linecapacity, MAX(0000) AS TotalQty, 000 AS percentOB, 0000 AS Dollarvalue, 0000 AS SewingQtyrequired,
                //                             (SELECT        CPM
                //                               FROM            Factory_Master AS Factory_Master_2
                //                               WHERE        (Factory_ID = FactoryWeeklyPlan_tbl.Factid)) / (MAX(CmMaster.FcmQty) / 12) / MAX(CmMaster.PcsPermachine) * 100 AS ObPercentageRequired, 0000 AS Dollorvaluerequired, 
                //                         0000 AS FinishingQtyRecieved, 0000 AS finisheddollorrequired, LineAtcCapacity_tbl.TotalHours, '000' AS [Is LOad Plan Qty Accepted], 000 AS [sew qty rqd], 000 AS [Eff rqd], 000 AS [Sew Val rqd], 
                //                         000 AS [fin Qty rqd], 000 AS [fin Value rqd], 000 AS [Total CM Value], 000 AS [Load  Plan Hours], 000 AS [Days Planned], 000 AS [Days in Period], 000 AS [Total Hours Planned], 0000.0 AS [Operators Planned], 
                //                         000 AS [Per Machine Revenue]
                //FROM            CmMaster INNER JOIN
                //                         FactoryWeeklyPlan_tbl ON CmMaster.Factory_id = FactoryWeeklyPlan_tbl.Factid INNER JOIN
                //                         Factory_Master AS Factory_Master_1 ON CmMaster.Factory_id = Factory_Master_1.Factory_ID INNER JOIN
                //                         AtcMaster ON CmMaster.Atc_id = AtcMaster.AtcId AND FactoryWeeklyPlan_tbl.AtcNum = AtcMaster.AtcNum LEFT OUTER JOIN
                //                         LineAtcCapacity_tbl ON AtcMaster.AtcNum = LineAtcCapacity_tbl.Atcnum AND FactoryWeeklyPlan_tbl.Factid = LineAtcCapacity_tbl.Factid AND FactoryWeeklyPlan_tbl.LineID = LineAtcCapacity_tbl.LineID
                //WHERE        (FactoryWeeklyPlan_tbl.DateofProd BETWEEN @param1 AND @param2) AND (FactoryWeeklyPlan_tbl.Factid = @factid)
                //GROUP BY FactoryWeeklyPlan_tbl.LineID, Factory_Master_1.Factory_name, FactoryWeeklyPlan_tbl.Factid, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, LineAtcCapacity_tbl.TotalHours";





                String q4 = @"   SELECT FactoryWeeklyPlan_tbl.LineID, Factory_Master_1.Factory_name, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, AtcDetails.OurStyle, MAX(CmMaster.FcmQty) / 100 * 80 AS SewingFcm, MAX(CmMaster.FcmQty)
                  / 100 * 20 AS FinishingFcm,
                      (SELECT        CPM

                        FROM            Factory_Master

                        WHERE(Factory_ID = FactoryWeeklyPlan_tbl.Factid)) / (MAX(CmMaster.FcmQty) / 12) / MAX(CmMaster.PcsPermachine) * 100 AS BreakEvenFcmEfficiency, MAX(CmMaster.OBOperators)AS OBOperators,
          MAX(CmMaster.ObHelpers) AS OBHelpers, MAX(CmMaster.OBTarget) AS OBTarget, MAX(CmMaster.PcsPermachine) AS[PCS/MA], MAX(ISNULL(LineAtcCapacity_tbl.NoOfOperators, 0)) AS LoadPlanOperator,
          MAX(ISNULL(LineAtcCapacity_tbl.NoOfHelper, 0)) AS LoadPlanHelpers, 0000.00 AS[Avg OBHelpertoOpr Ratio], 0000.00 AS[Avg LPHelpertoOpr Ratio], 0000 AS[What is 100% Qty],
          MAX(ISNULL(LineAtcCapacity_tbl.DailyCaspacity, 0)) AS Linecapacity, MAX(0000) AS TotalQty, 000 AS percentOB, 0000 AS Dollarvalue, 0000 AS SewingQtyrequired,
              (SELECT        CPM

                FROM            Factory_Master AS Factory_Master_2

                WHERE(Factory_ID = FactoryWeeklyPlan_tbl.Factid)) / (MAX(CmMaster.FcmQty) / 12) / MAX(CmMaster.PcsPermachine) * 100 AS ObPercentageRequired, 0000 AS Dollorvaluerequired,
                         0000 AS FinishingQtyRecieved, 0000 AS finisheddollorrequired, LineAtcCapacity_tbl.TotalHours, '000' AS[Is LOad Plan Qty Accepted], 000 AS[sew qty rqd], 000 AS[Eff rqd], 000 AS[Sew Val rqd], 
                         000 AS[fin Qty rqd], 000 AS[fin Value rqd], 000 AS[Total CM Value], 000 AS[Load  Plan Hours], 000 AS[Days Planned], 000 AS[Days in Period], 000 AS[Total Hours Planned], 0000.0 AS[Operators Planned], 
                         000 AS[Per Machine Revenue]
FROM            AtcDetails INNER JOIN
                        AtcMaster ON AtcDetails.AtcId = AtcMaster.AtcId INNER JOIN
                         CmMaster INNER JOIN
                         FactoryWeeklyPlan_tbl ON CmMaster.Factory_id = FactoryWeeklyPlan_tbl.Factid INNER JOIN
                         Factory_Master AS Factory_Master_1 ON CmMaster.Factory_id = Factory_Master_1.Factory_ID ON AtcDetails.OurStyleID = CmMaster.OurStyleID AND
                         AtcDetails.OurStyle = FactoryWeeklyPlan_tbl.OurStyle LEFT OUTER JOIN
                         LineAtcCapacity_tbl ON AtcDetails.OurStyle = LineAtcCapacity_tbl.OurStyleNum AND FactoryWeeklyPlan_tbl.Factid = LineAtcCapacity_tbl.Factid AND
                         FactoryWeeklyPlan_tbl.LineID = LineAtcCapacity_tbl.LineID
WHERE(FactoryWeeklyPlan_tbl.DateofProd BETWEEN @param1 AND @param2) AND(FactoryWeeklyPlan_tbl.Factid = @factid)
GROUP BY FactoryWeeklyPlan_tbl.LineID, Factory_Master_1.Factory_name, FactoryWeeklyPlan_tbl.Factid, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, LineAtcCapacity_tbl.TotalHours, 
                         AtcDetails.OurStyle";




                cmd.CommandText = q4;
                cmd.Parameters.AddWithValue("@param1", fromdate);
                cmd.Parameters.AddWithValue("@param2", todate);
                cmd.Parameters.AddWithValue("@Factid", factid);
                



                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }




        public DataTable CurrrentProjectionDataofFact(DateTime fromdate, DateTime todate, int factid, String typeofdata)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //                String q4 = @"SELECT        FactoryWeeklyPlan_tbl.LineID, Factory_Master.Factory_name, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, MAX(Cm_master.FcmQty) 
                //                         / 100 * 80 AS SewingFcm, MAX(Cm_master.FcmQty) / 100 * 20 AS FinishingFcm,
                //                        ( (((select  cpm from Factory_Master where Factory_ID=FactoryWeeklyPlan_tbl.Factid)/( MAX(cm_master.FcmQty)/12))/MAX(Cm_master.PcsPermachine))*100 )AS BreakEvenFcmEfficiency, MAX(Cm_master.OBOperators) AS OBOperators, MAX(Cm_master.ObHelpers) AS OBHelpers, 
                //                         MAX(Cm_master.OBTarget) AS OBTarget, MAX(Cm_master.PcsPermachine) AS [PCS/MA], MAX(ISNULL(LineAtcCapacity_tbl.NoOfOperators, 0)) AS LoadPlanOperator, 
                //                         MAX(ISNULL(LineAtcCapacity_tbl.NoOfHelper, 0)) AS LoadPlanHelpers, 0000.00 AS [Avg OBHelpertoOpr Ratio], 0000.00 AS [Avg LPHelpertoOpr Ratio], 0000 AS [What is 100% Qty], MAX(ISNULL(LineAtcCapacity_tbl.DailyCaspacity, 0)) AS Linecapacity, MAX(0000) AS TotalQty, 
                //                         000 AS percentOB, 0000 AS Dollarvalue ,0000 AS SewingQtyrequired,  ( (((select  cpm from Factory_Master where Factory_ID=FactoryWeeklyPlan_tbl.Factid)/( MAX(cm_master.FcmQty)/12))/MAX(Cm_master.PcsPermachine))*100 ) AS ObPercentageRequired, 0000 AS Dollorvaluerequired, 
                //                         0000 AS FinishingQtyRecieved, 0000 AS finisheddollorrequired, LineAtcCapacity_tbl.TotalHours,'000' as [Is LOad Plan Qty Accepted],000 as [sew qty rqd],000 as [Eff rqd],000 as [Sew Val rqd],000 as [fin Qty rqd],000 as [fin Value rqd]   ,000 as [Total CM Value],000 as [Load  Plan Hours],000 as [Days Planned] ,000 as [Days in Period], 000 as [Total Hours Planned] ,0000.0 as [Operators Planned]  ,000 as [Per Machine Revenue]               
                //FROM            Atc_master INNER JOIN
                //                         Cm_master ON Atc_master.Atc_id = Cm_master.Atc_id INNER JOIN
                //                         FactoryWeeklyPlan_tbl ON Atc_master.AtcNum = FactoryWeeklyPlan_tbl.AtcNum AND Cm_master.Factory_id = FactoryWeeklyPlan_tbl.Factid INNER JOIN
                //                         Factory_Master ON Cm_master.Factory_id = Factory_Master.Factory_ID LEFT OUTER JOIN
                //                         LineAtcCapacity_tbl ON FactoryWeeklyPlan_tbl.Factid = LineAtcCapacity_tbl.Factid AND Atc_master.AtcNum = LineAtcCapacity_tbl.Atcnum AND 
                //                         FactoryWeeklyPlan_tbl.LineID = LineAtcCapacity_tbl.LineID
                //						 WHERE        (FactoryWeeklyPlan_tbl.DateofProd BETWEEN @param1 AND @param2) and FactoryWeeklyPlan_tbl.factid=@factid
                //GROUP BY FactoryWeeklyPlan_tbl.LineID, Factory_Master.Factory_name,FactoryWeeklyPlan_tbl.Factid, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, 
                //                         LineAtcCapacity_tbl.TotalHours";


//                String q5 = @"					 SELECT        FactoryWeeklyPlan_tbl.LineID, Factory_Master.Factory_name, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, MAX(Cm_master.FcmQty) 
//                         / 100 * 80 AS SewingFcm, MAX(Cm_master.FcmQty) / 100 * 20 AS FinishingFcm,
//Max(Cm_master.BreakEvenFcmEfficiency), MAX(Cm_master.OBOperators) AS OBOperators, MAX(Cm_master.ObHelpers) AS OBHelpers, 
//                         MAX(Cm_master.OBTarget) AS OBTarget, MAX(Cm_master.PcsPermachine) AS [PCS/MA], MAX(ISNULL(LineAtcCapacity_tbl.NoOfOperators, 0)) AS LoadPlanOperator, 
//                         MAX(ISNULL(LineAtcCapacity_tbl.NoOfHelper, 0)) AS LoadPlanHelpers, 0000.00 AS [Avg OBHelpertoOpr Ratio], 0000.00 AS [Avg LPHelpertoOpr Ratio], 0000 AS [What is 100% Qty], MAX(ISNULL(LineAtcCapacity_tbl.DailyCaspacity, 0)) AS Linecapacity, MAX(0000) AS TotalQty, 
//                         000 AS percentOB, 0000 AS Dollarvalue ,0000 AS SewingQtyrequired,  Max(Cm_master.BreakEvenFcmEfficiency) AS ObPercentageRequired, 0000 AS Dollorvaluerequired, 
//                         0000 AS FinishingQtyRecieved, 0000 AS finisheddollorrequired, LineAtcCapacity_tbl.TotalHours,'000' as [Is LOad Plan Qty Accepted],000 as [sew qty rqd],000 as [Eff rqd],000 as [Sew Val rqd],000 as [fin Qty rqd],000 as [fin Value rqd]   ,000 as [Total CM Value],000 as [Load  Plan Hours],000 as [Days Planned] ,000 as [Days in Period], 000 as [Total Hours Planned] ,0000.0 as [Operators Planned]  ,000 as [Per Machine Revenue]               
//FROM            Atc_master INNER JOIN
//                         Cm_master ON Atc_master.Atc_id = Cm_master.Atc_id INNER JOIN
//                         FactoryWeeklyPlan_tbl ON Atc_master.AtcNum = FactoryWeeklyPlan_tbl.AtcNum AND Cm_master.Factory_id = FactoryWeeklyPlan_tbl.Factid INNER JOIN
//                         Factory_Master ON Cm_master.Factory_id = Factory_Master.Factory_ID LEFT OUTER JOIN
//                         LineAtcCapacity_tbl ON FactoryWeeklyPlan_tbl.Factid = LineAtcCapacity_tbl.Factid AND Atc_master.AtcNum = LineAtcCapacity_tbl.Atcnum AND 
//                         FactoryWeeklyPlan_tbl.LineID = LineAtcCapacity_tbl.LineID
//						 WHERE        (FactoryWeeklyPlan_tbl.DateofProd BETWEEN @param1 AND @param2) and FactoryWeeklyPlan_tbl.factid=@factid
//GROUP BY FactoryWeeklyPlan_tbl.LineID, Factory_Master.Factory_name,FactoryWeeklyPlan_tbl.Factid, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, 
//                         LineAtcCapacity_tbl.TotalHours";



                String q4 = @" SELECT FactoryWeeklyPlan_tbl.LineID, Factory_Master_1.Factory_name, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, MAX(Cm_master.FcmQty) / 100 * 80 AS SewingFcm, MAX(Cm_master.FcmQty)
                  / 100 * 20 AS FinishingFcm,
                      (SELECT        CPM

                        FROM            Factory_Master

                        WHERE(Factory_ID = FactoryWeeklyPlan_tbl.Factid)) / (MAX(Cm_master.FcmQty) / 12) / MAX(Cm_master.PcsPermachine) * 100 AS BreakEvenFcmEfficiency, MAX(Cm_master.OBOperators)AS OBOperators,
          MAX(Cm_master.ObHelpers) AS OBHelpers, MAX(Cm_master.OBTarget) AS OBTarget, MAX(Cm_master.PcsPermachine) AS[PCS / MA], MAX(ISNULL(LineAtcCapacity_tbl.NoOfOperators, 0)) AS LoadPlanOperator,
          MAX(ISNULL(LineAtcCapacity_tbl.NoOfHelper, 0)) AS LoadPlanHelpers, 0000.00 AS[Avg OBHelpertoOpr Ratio], 0000.00 AS[Avg LPHelpertoOpr Ratio], 0000 AS[What is 100 % Qty],
          MAX(ISNULL(LineAtcCapacity_tbl.DailyCaspacity, 0)) AS Linecapacity, MAX(0000) AS TotalQty, 000 AS percentOB, 0000 AS Dollarvalue, 0000 AS SewingQtyrequired,
              (SELECT        CPM

                FROM            Factory_Master AS Factory_Master_2

                WHERE(Factory_ID = FactoryWeeklyPlan_tbl.Factid)) / (MAX(Cm_master.FcmQty) / 12) / MAX(Cm_master.PcsPermachine) * 100 AS ObPercentageRequired, 0000 AS Dollorvaluerequired,
                         0000 AS FinishingQtyRecieved, 0000 AS finisheddollorrequired, LineAtcCapacity_tbl.TotalHours, '000' AS[Is LOad Plan Qty Accepted], 000 AS[sew qty rqd], 000 AS[Eff rqd], 000 AS[Sew Val rqd], 
                         000 AS[fin Qty rqd], 000 AS[fin Value rqd], 000 AS[Total CM Value], 000 AS[Load  Plan Hours], 000 AS[Days Planned], 000 AS[Days in Period], 000 AS[Total Hours Planned], 0000.0 AS[Operators Planned], 
                         000 AS[Per Machine Revenue]
FROM AtcMaster INNER JOIN
                         FactoryWeeklyPlan_tbl INNER JOIN
                         Cm_master ON FactoryWeeklyPlan_tbl.Factid = Cm_master.Factory_id INNER JOIN
                         Factory_Master AS Factory_Master_1 ON Cm_master.Factory_id = Factory_Master_1.Factory_ID ON AtcMaster.AtcId = Cm_master.Atc_id AND AtcMaster.AtcNum = FactoryWeeklyPlan_tbl.AtcNum FULL OUTER JOIN
                         LineAtcCapacity_tbl ON AtcMaster.AtcNum = LineAtcCapacity_tbl.Atcnum AND FactoryWeeklyPlan_tbl.Factid = LineAtcCapacity_tbl.Factid AND FactoryWeeklyPlan_tbl.LineID = LineAtcCapacity_tbl.LineID
WHERE(FactoryWeeklyPlan_tbl.DateofProd BETWEEN @param1 AND @param2) AND(FactoryWeeklyPlan_tbl.Factid = @factid)
GROUP BY FactoryWeeklyPlan_tbl.LineID, Factory_Master_1.Factory_name, FactoryWeeklyPlan_tbl.Factid, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, LineAtcCapacity_tbl.TotalHours";










               






                String q5 = @"						 SELECT        FactoryWeeklyPlan_tbl.LineID, Factory_Master.Factory_name, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, MAX(Cm_master.FcmQty) 
                         / 100 * 80 AS SewingFcm, MAX(Cm_master.FcmQty) / 100 * 20 AS FinishingFcm,
Max(Cm_master.BreakEvenFcmEfficiency), MAX(Cm_master.OBOperators) AS OBOperators, MAX(Cm_master.ObHelpers) AS OBHelpers, 
                         MAX(Cm_master.OBTarget) AS OBTarget, MAX(Cm_master.PcsPermachine) AS [PCS/MA], MAX(ISNULL(LineAtcCapacity_tbl.NoOfOperators, 0)) AS LoadPlanOperator, 
                         MAX(ISNULL(LineAtcCapacity_tbl.NoOfHelper, 0)) AS LoadPlanHelpers, 0000.00 AS [Avg OBHelpertoOpr Ratio], 0000.00 AS [Avg LPHelpertoOpr Ratio], 0000 AS [What is 100% Qty], MAX(ISNULL(LineAtcCapacity_tbl.DailyCaspacity, 0)) AS Linecapacity, MAX(0000) AS TotalQty, 
                         000 AS percentOB, 0000 AS Dollarvalue ,0000 AS SewingQtyrequired,  Max(Cm_master.BreakEvenFcmEfficiency) AS ObPercentageRequired, 0000 AS Dollorvaluerequired, 
                         0000 AS FinishingQtyRecieved, 0000 AS finisheddollorrequired, LineAtcCapacity_tbl.TotalHours,'000' as [Is LOad Plan Qty Accepted],000 as [sew qty rqd],000 as [Eff rqd],000 as [Sew Val rqd],000 as [fin Qty rqd],000 as [fin Value rqd]   ,000 as [Total CM Value],000 as [Load  Plan Hours],000 as [Days Planned] ,000 as [Days in Period], 000 as [Total Hours Planned] ,0000.0 as [Operators Planned]  ,000 as [Per Machine Revenue]               
FROM            AtcMaster INNER JOIN
                         Cm_master ON AtcMaster.AtcId = Cm_master.Atc_id INNER JOIN
                         FactoryWeeklyPlan_tbl ON AtcMaster.AtcNum = FactoryWeeklyPlan_tbl.AtcNum AND Cm_master.Factory_id = FactoryWeeklyPlan_tbl.Factid INNER JOIN
                         Factory_Master ON Cm_master.Factory_id = Factory_Master.Factory_ID LEFT OUTER JOIN
                         LineAtcCapacity_tbl ON FactoryWeeklyPlan_tbl.Factid = LineAtcCapacity_tbl.Factid AND AtcMaster.AtcNum = LineAtcCapacity_tbl.Atcnum AND 
                         FactoryWeeklyPlan_tbl.LineID = LineAtcCapacity_tbl.LineID
						 WHERE        (FactoryWeeklyPlan_tbl.DateofProd BETWEEN @param1 AND @param2) and FactoryWeeklyPlan_tbl.factid=@factid
GROUP BY FactoryWeeklyPlan_tbl.LineID, Factory_Master.Factory_name,FactoryWeeklyPlan_tbl.Factid, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.AtcNum, 
                         LineAtcCapacity_tbl.TotalHours";






                //  cmd.CommandText = Query1;
                if (typeofdata == "Current")
                {
                    cmd.CommandText = q4;
                }
                else
                {
                    cmd.CommandText = q5;
                }
                cmd.CommandText = q4;
                cmd.Parameters.AddWithValue("@param1", fromdate);
                cmd.Parameters.AddWithValue("@param2", todate);
                cmd.Parameters.AddWithValue("@factid", factid);



                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }










        public DataTable LinedataCM(DateTime fromdate, DateTime todate, int lineid, String OurStyle)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string Query1 = @"SELECT        DateofProd,datename (month,DateofProd) as Month,  datename (dw,DateofProd) as DayofWeek,TargetQty, FctProdID,00 as hours ,00 PlannedOperators,00 PlannedOHelpers,00000 as OBtargetpercent,00 as OBHour,0000 as ObOperators,0000 as OBHelpers,00 as Planhours
FROM            FactoryWeeklyPlan_tbl

WHERE        (DateofProd BETWEEN @param1 AND @param2) AND (LineID = @Param3)AND (AtcNum = @atcnum)";


                //                String Query2 = @"SELECT        DateofProd, DATENAME(Month, DateofProd) AS Month, DATENAME(dw, DateofProd) AS DayofWeek,  00000 AS OBtargetpercent, 00 AS OBHour, 0000 AS ObOperators, 0000 AS OBHelpers, 00 AS hours, 00 AS PlannedOperators, 
                //                         00 AS PlannedHelpers,00 AS Planhours,sum(TargetQty)as TargetQty
                //FROM            FactoryWeeklyPlan_tbl
                //WHERE        (DateofProd BETWEEN @param1 AND @param2) AND (LineID = @Param3)AND (AtcNum = @atcnum)
                //GROUP BY LineID, AtcNum, DateofProd, DATENAME(Month, DateofProd), DATENAME(dw, DateofProd)";





                String Query2 = @"SELECT DateofProd, DATENAME(Month, DateofProd) AS Month, DATENAME(dw, DateofProd) AS DayofWeek, 00000 AS OBtargetpercent, 00 AS OBHour, 0000 AS ObOperators, 0000 AS OBHelpers, 00 AS hours,
                         00 AS PlannedOperators, 00 AS PlannedHelpers, 00 AS Planhours, SUM(TargetQty) AS TargetQty, OurStyle
FROM            FactoryWeeklyPlan_tbl
WHERE(DateofProd BETWEEN @param1 AND @param2) AND(LineID = @Param3) AND(OurStyle = @atcnum)
GROUP BY LineID, AtcNum, DateofProd, DATENAME(Month, DateofProd), DATENAME(dw, DateofProd), OurStyle";
                cmd.CommandText = Query2;
                cmd.Parameters.AddWithValue("@param1", fromdate);
                cmd.Parameters.AddWithValue("@param2", todate);
                cmd.Parameters.AddWithValue("@param3", lineid);
                cmd.Parameters.AddWithValue("@atcnum", OurStyle);




                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }

        public DataTable CMReport()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string Query1 = @"SELECT        CmMaster.CmId, AtcMaster.AtcNum, AtcDetails.OurStyle, Factory_Master.Factory_name, CmMaster.AcmQty AS ACM, CmMaster.FcmQty AS FCM, CmMaster.OBTarget AS [OB Target], 
                         CmMaster.PcsPermachine AS [PCS/MA], CmMaster.OBOperators AS [No Of Operators], CmMaster.ObHelpers AS [No Of  helper], CmMaster.BreakEvenAcmTarget, CmMaster.BreakEvenAcmEfficency, 
                         CmMaster.BreakEvenFcmTarget, CmMaster.BreakEvenFcmEfficiency, CmMaster.OurStyleID, CmMaster.CPM, CmMaster.AddedDate, CmMaster.Addedvia, CmMaster.ActionType, CmMaster.Writer, 
                         CmMaster.Feeder, CmMaster.Bundlemover, CmMaster.Supervisor, CmMaster.PE, CmMaster.Helper, CmMaster.AddedBy, CmMaster.Atc_id
FROM            CmMaster INNER JOIN
                         AtcDetails ON CmMaster.OurStyleID = AtcDetails.OurStyleID INNER JOIN
                         AtcMaster ON AtcDetails.AtcId = AtcMaster.AtcId INNER JOIN
                         Factory_Master ON CmMaster.Factory_id = Factory_Master.Factory_ID";





                cmd.CommandText = Query1;





                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }

        public DataTable CMnotmadeButLinePlanned()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string Query1 = @"SELECT     tt.Factory_name ,tt.Year,tt.Month ,tt.AtcNum ,tt.LineNum,Cm_master.*
FROM            (SELECT  FactoryWeeklyPlan_tbl.Factid,  FactoryWeeklyPlan_tbl.AtcNum, AtcMaster.Atcid, Factory_Master.Factory_name, MAX(FactoryWeeklyPlan_tbl.Month) AS Month, 
                         MAX(FactoryWeeklyPlan_tbl.Year) AS Year, FactoryWeeklyPlan_tbl.LineNum
FROM            AtcMaster INNER JOIN
                         FactoryWeeklyPlan_tbl ON AtcMaster.AtcNum = FactoryWeeklyPlan_tbl.AtcNum INNER JOIN
                         Factory_Master ON FactoryWeeklyPlan_tbl.Factid = Factory_Master.Factory_ID
GROUP BY FactoryWeeklyPlan_tbl.AtcNum, FactoryWeeklyPlan_tbl.Factid, AtcMaster.Atcid, Factory_Master.Factory_name, FactoryWeeklyPlan_tbl.LineNum) AS tt LEFT  JOIN
                         Cm_master ON tt.Factid = Cm_master.Factory_id AND tt.Atcid = Cm_master.Atc_id 
						 where Cm_master.CmId is null ";





                cmd.CommandText = Query1;





                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }
        public DataTable OBCalculaterTable(DateTime fromdate, DateTime todate)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string Query1 = @"SELECT        FactoryWeeklyPlan_tbl.AtcNum, FactoryWeeklyPlan_tbl.LineNum, FactoryWeeklyPlan_tbl.DateofProd, LineAtcCapacity_tbl.TotalHours, 
                         LineAtcCapacity_tbl.NoOfOperators, LineAtcCapacity_tbl.NoOfHelper, Cm_master_1.OBTarget, Cm_master_1.OBOperators, Cm_master_1.ObHelpers, 
                         8 AS Obhours,datepart(dw,DateofProd)as weekofday,00 as Hours
FROM            Cm_master AS Cm_master_1 INNER JOIN
                         Atc_master ON Cm_master_1.Atc_id = Atc_master.Atc_id INNER JOIN
                         LineAtcCapacity_tbl INNER JOIN
                         FactoryWeeklyPlan_tbl ON LineAtcCapacity_tbl.Factid = FactoryWeeklyPlan_tbl.Factid AND LineAtcCapacity_tbl.Atcnum = FactoryWeeklyPlan_tbl.AtcNum AND 
                         LineAtcCapacity_tbl.LineNum = FactoryWeeklyPlan_tbl.LineNum ON Atc_master.AtcNum = LineAtcCapacity_tbl.Atcnum AND 
                         Cm_master_1.Factory_id = LineAtcCapacity_tbl.Factid
where        (FactoryWeeklyPlan_tbl.DateofProd BETWEEN @param1 AND @param2)";





                cmd.CommandText = Query1;

                cmd.Parameters.AddWithValue("@param1", fromdate);
                cmd.Parameters.AddWithValue("@param2", todate);



                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        public DataTable GetFactoriesCapacities(int year, String Month)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                try
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand(@"
select tt.Factory_name ,tt.MonthlyCapacity ,tt.PendingApprovalQty+tt.ApprovedQty as TotalBookedQty,tt.ApprovedQty,tt.ConsumptionQty, tt.POAllocatedforMonth as [Total PO Qty Allocated for Month] ,tt.POsofMothsAllocation,tt.PendingApprovalQty ,(tt.PendingApprovalQty+tt.ApprovedQty)-POsofMothsAllocation as [Pending for PO Allocation], (tt.MonthlyCapacity-( tt.PendingApprovalQty+POAllocatedforMonth+((tt.PendingApprovalQty+tt.ApprovedQty)-POsofMothsAllocation))) as CapacityAvailable from

(SELECT       f.Factory_ID  Factory_ID, f.Factory_name Factory_name,f.MonthlyCapacity MonthlyCapacity,ISNULL ((SELECT        sum(BookQty)
FROM            OrderBooking_tbl
WHERE        (ISApproved = N'N') AND (Factory_Id = f.Factory_ID ) AND (Year = @year) AND (Month = @month)) ,0) as PendingApprovalQty ,ISNULL ((SELECT      sum (  ConsumptionQty )
FROM            FinalBooking_master
WHERE        (Factory_Id = f.Factory_ID ) AND (Year = @year) AND (Month = @month)) ,0) as ConsumptionQty,ISNULL ((SELECT      sum (  BookQty )
FROM            FinalBooking_master
WHERE       (Factory_Id = f.Factory_ID ) AND (Year = @year) AND (Month = @month)) ,0) as ApprovedQty,(SELECT       sum( Qty)
FROM            WeeklyPlan_Master
WHERE        (Month = @month) AND (Year = @year) AND (Factory_Id = f.Factory_ID)) as POAllocatedforMonth,(SELECT        sum( WeeklyPlan_Master.Qty)
FROM            FinalBooking_master INNER JOIN
                         WeeklyPlan_Master ON FinalBooking_master.Book_Id = WeeklyPlan_Master.Book_Id
WHERE        (FinalBooking_master.Month = @MONTH) AND (FinalBooking_master.Year = @Year) AND (FinalBooking_master.Factory_id = f.Factory_ID)) as POsofMothsAllocation
FROM            Factory_Master f)tt
", con);


                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@month", Month);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    dt.Load(rdr);
                }
                catch (Exception)
                {

                    MessageBox.Show("Cannot Access database " + Program.ConnStr);
                }



            }
            return dt;
        }

        public DataTable GetDERData(DateTime fromdate, DateTime todate)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                //                String q3 = @"SELECT        ActualProduced_tbl.LineID, Factory_Master.Factory_name, ActualProduced_tbl.Linenum, ActualProduced_tbl.Atcnum, ActualProduced_tbl.DateOfProd, datename (dw,DateofProd) as DayofWeek,'' as ObHours,
                //                         MAX(Cm_master.FcmQty) / 100 * 80 AS SewingFcm, MAX(Cm_master.FcmQty) / 100 * 20 AS FinishingFcm, MAX(Cm_master.BreakEvenFcmEfficiency) 
                //                         AS BreakEvenFcmEfficiency, MAX(Cm_master.BreakEvenFcmTarget) as BreakEvenFcmTarget,  MAX(Cm_master.OBOperators) AS OBOperators, MAX(Cm_master.ObHelpers) AS OBHelpers, MAX(Cm_master.OBTarget) AS OBTarget, 
                //                         MAX(Cm_master.PcsPermachine) AS [PCS/MA], MAX(ISNULL(ActualProduced_tbl.Operators, 0)) AS ActualOperator, MAX(ISNULL(ActualProduced_tbl.Helpers, 0)) 
                //                         AS ActualHelpers,000.00 AS [OB Helper Ratio],000.00 AS [Actual Helper Ratio] ,'000000' AS IsPlannedRatioGreater, 000 AS [Expected Hr] , 0000 as TargetBasedon8by5,0000 as actual100, sum(ActualProduced_tbl.ProducedQty) AS TotalQty, 000 AS percentOB, sum(ActualProduced_tbl.Hours ) as OTHOurs,000 as Expected100,000 as ProducedPercent,000 as BDPercent,000 as BETarget ,000 as BDqty,000 as BDDollor,000.00 as BEPercentOB
                //FROM            ActualProduced_tbl INNER JOIN
                //                         Atc_master ON ActualProduced_tbl.Atcnum = Atc_master.AtcNum INNER JOIN
                //                         Cm_master ON Atc_master.Atc_id = Cm_master.Atc_id AND ActualProduced_tbl.factid = Cm_master.Factory_id INNER JOIN
                //                         Factory_Master ON ActualProduced_tbl.factid = Factory_Master.Factory_ID 
                // WHERE        (ActualProduced_tbl.DateOfProd BETWEEN @param1 AND @param2)
                //GROUP BY ActualProduced_tbl.LineID, Factory_Master.Factory_name, ActualProduced_tbl.Linenum, ActualProduced_tbl.Atcnum, ActualProduced_tbl.DateOfProd";

                //                String q3 = @"SELECT        ActualProduced_tbl.LineID, Factory_Master.Factory_name, ActualProduced_tbl.Linenum, ActualProduced_tbl.Atcnum, ActualProduced_tbl.DateOfProd, datename (dw,DateofProd) as DayofWeek,'' as ObHours,
                //                         MAX(Cm_master.FcmQty) / 100 * 80 AS SewingFcm, MAX(Cm_master.FcmQty) / 100 * 20 AS FinishingFcm, MAX(Cm_master.BreakEvenFcmEfficiency) 
                //                         AS BreakEvenFcmEfficiency, MAX(Cm_master.BreakEvenFcmTarget) as BreakEvenFcmTarget,  MAX(Cm_master.OBOperators) AS OBOperators, MAX(Cm_master.ObHelpers) AS OBHelpers, MAX(Cm_master.OBTarget) AS OBTarget, 
                //                         MAX(Cm_master.PcsPermachine) AS [PCS/MA], MAX(ISNULL(ActualProduced_tbl.Operators, 0)) AS ActualOperator, MAX(ISNULL(ActualProduced_tbl.Helpers, 0)) 
                //                         AS ActualHelpers,000.00 AS [OB Helper Ratio],000.00 AS [Actual Helper Ratio] ,'000000' AS IsPlannedRatioGreater, 000 AS [Expected Hr] , 0000 as TargetBasedon8by5,0000 as actual100, sum(ActualProduced_tbl.ProducedQty) AS TotalQty, 000 AS percentOB, sum(ActualProduced_tbl.Hours ) as OTHOurs,000 as Expected100,000 as ProducedPercent,000 as BDPercent,000 as BETarget ,000 as BDqty,000 as BDDollor,000.00 as BEPercentOB
                //FROM            ActualProduced_tbl INNER JOIN
                //                         AtcMaster ON ActualProduced_tbl.Atcnum = AtcMaster.AtcNum INNER JOIN
                //                         Cm_master ON AtcMaster.AtcId = Cm_master.Atc_id AND ActualProduced_tbl.factid = Cm_master.Factory_id INNER JOIN
                //                         Factory_Master ON ActualProduced_tbl.factid = Factory_Master.Factory_ID 
                // WHERE        (ActualProduced_tbl.DateOfProd BETWEEN @param1 AND @param2)
                //GROUP BY ActualProduced_tbl.LineID, Factory_Master.Factory_name, ActualProduced_tbl.Linenum, ActualProduced_tbl.Atcnum, ActualProduced_tbl.DateOfProd";




                String q3 = @"SELECT        ActualProduced_tbl.LineID, Factory_Master.Factory_name, ActualProduced_tbl.Linenum, ActualProduced_tbl.Atcnum, ActualProduced_tbl.DateOfProd, DATENAME(dw, ActualProduced_tbl.DateOfProd) 
                         AS DayofWeek, '' AS ObHours, MAX(CmMaster.FcmQty) / 100 * 80 AS SewingFcm, MAX(CmMaster.FcmQty) / 100 * 20 AS FinishingFcm, MAX(CmMaster.BreakEvenFcmEfficiency) AS BreakEvenFcmEfficiency, 
                         MAX(CmMaster.BreakEvenFcmTarget) AS BreakEvenFcmTarget, MAX(CmMaster.OBOperators) AS OBOperators, MAX(CmMaster.ObHelpers) AS OBHelpers, MAX(CmMaster.OBTarget) AS OBTarget, 
                         MAX(CmMaster.PcsPermachine) AS [PCS/MA], MAX(ISNULL(ActualProduced_tbl.Operators, 0)) AS ActualOperator, MAX(ISNULL(ActualProduced_tbl.Helpers, 0)) AS ActualHelpers, 000.00 AS [OB Helper Ratio], 
                         000.00 AS [Actual Helper Ratio], '000000' AS IsPlannedRatioGreater, 000 AS [Expected Hr], 0000 AS TargetBasedon8by5, 0000 AS actual100, SUM(ActualProduced_tbl.ProducedQty) AS TotalQty, 000 AS percentOB, 
                         SUM(ActualProduced_tbl.Hours) AS OTHOurs, 000 AS Expected100, 000 AS ProducedPercent, 000 AS BDPercent, 000 AS BETarget, 000 AS BDqty, 000 AS BDDollor, 000.00 AS BEPercentOB, 
                         AtcDetails.OurStyle
FROM            ActualProduced_tbl INNER JOIN
                         CmMaster ON ActualProduced_tbl.factid = CmMaster.Factory_id INNER JOIN
                         Factory_Master ON ActualProduced_tbl.factid = Factory_Master.Factory_ID INNER JOIN
                         AtcDetails ON ActualProduced_tbl.OurStyle = AtcDetails.OurStyle AND CmMaster.OurStyleID = AtcDetails.OurStyleID INNER JOIN
                         AtcMaster ON AtcDetails.AtcId = AtcMaster.AtcId AND ActualProduced_tbl.Atcnum = AtcMaster.AtcNum
 WHERE        (ActualProduced_tbl.DateOfProd BETWEEN @param1 AND @param2)
GROUP BY ActualProduced_tbl.LineID, Factory_Master.Factory_name, ActualProduced_tbl.Linenum, ActualProduced_tbl.Atcnum, ActualProduced_tbl.DateOfProd, AtcDetails.OurStyle";




                //  cmd.CommandText = Query1;
                cmd.CommandText = q3;
                cmd.Parameters.AddWithValue("@param1", fromdate);
                cmd.Parameters.AddWithValue("@param2", todate);




                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        public DataTable GetAERData(DateTime fromdate, DateTime todate)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


//                String q3 = @"SELECT        ActualProduced_tbl.LineID, Factory_Master.Factory_name, ActualProduced_tbl.Linenum, ActualProduced_tbl.Atcnum, ActualProduced_tbl.DateOfProd, datename (dw,DateofProd) as DayofWeek,'' as ObHours,
//                         MAX(Cm_master.AcmQty) / 100 * 80 AS SewingFcm, MAX(Cm_master.AcmQty) / 100 * 20 AS FinishingFcm, MAX(Cm_master.BreakEvenAcmEfficency) 
//                         AS BreakEvenFcmEfficiency, MAX(Cm_master.BreakEvenAcmTarget) as BreakEvenFcmTarget,  MAX(Cm_master.OBOperators) AS OBOperators, MAX(Cm_master.ObHelpers) AS OBHelpers, MAX(Cm_master.OBTarget) AS OBTarget, 
//                         MAX(Cm_master.PcsPermachine) AS [PCS/MA], MAX(ISNULL(ActualProduced_tbl.Operators, 0)) AS ActualOperator, MAX(ISNULL(ActualProduced_tbl.Helpers, 0)) 
//                         AS ActualHelpers,000.00 AS [OB Helper Ratio],000.00 AS [Actual Helper Ratio] ,'000000' AS IsPlannedRatioGreater, 000 AS [Expected Hr] , 0000 as TargetBasedon8by5,0000 as actual100, sum(ActualProduced_tbl.ProducedQty) AS TotalQty, 000 AS percentOB, sum(ActualProduced_tbl.Hours ) as OTHOurs,000 as Expected100,000 as ProducedPercent,000 as BETarget,000 as BDPercent,000 as BDqty,000 as BDDollor,000.00 as BEPercentOB
//FROM            ActualProduced_tbl INNER JOIN
//                         Atc_master ON ActualProduced_tbl.Atcnum = Atc_master.AtcNum INNER JOIN
//                         Cm_master ON Atc_master.Atc_id = Cm_master.Atc_id AND ActualProduced_tbl.factid = Cm_master.Factory_id INNER JOIN
//                         Factory_Master ON ActualProduced_tbl.factid = Factory_Master.Factory_ID 
// WHERE        (ActualProduced_tbl.DateOfProd BETWEEN @param1 AND @param2)
//GROUP BY ActualProduced_tbl.LineID, Factory_Master.Factory_name, ActualProduced_tbl.Linenum, ActualProduced_tbl.Atcnum, ActualProduced_tbl.DateOfProd";


                String q3 = @"SELECT        ActualProduced_tbl.LineID, Factory_Master.Factory_name, ActualProduced_tbl.Linenum, ActualProduced_tbl.Atcnum, ActualProduced_tbl.DateOfProd, datename (dw,DateofProd) as DayofWeek,'' as ObHours,
                         MAX(Cm_master.AcmQty) / 100 * 80 AS SewingFcm, MAX(Cm_master.AcmQty) / 100 * 20 AS FinishingFcm, MAX(Cm_master.BreakEvenAcmEfficency) 
                         AS BreakEvenFcmEfficiency, MAX(Cm_master.BreakEvenAcmTarget) as BreakEvenFcmTarget,  MAX(Cm_master.OBOperators) AS OBOperators, MAX(Cm_master.ObHelpers) AS OBHelpers, MAX(Cm_master.OBTarget) AS OBTarget, 
                         MAX(Cm_master.PcsPermachine) AS [PCS/MA], MAX(ISNULL(ActualProduced_tbl.Operators, 0)) AS ActualOperator, MAX(ISNULL(ActualProduced_tbl.Helpers, 0)) 
                         AS ActualHelpers,000.00 AS [OB Helper Ratio],000.00 AS [Actual Helper Ratio] ,'000000' AS IsPlannedRatioGreater, 000 AS [Expected Hr] , 0000 as TargetBasedon8by5,0000 as actual100, sum(ActualProduced_tbl.ProducedQty) AS TotalQty, 000 AS percentOB, sum(ActualProduced_tbl.Hours ) as OTHOurs,000 as Expected100,000 as ProducedPercent,000 as BETarget,000 as BDPercent,000 as BDqty,000 as BDDollor,000.00 as BEPercentOB
FROM            ActualProduced_tbl INNER JOIN
                         AtcMaster ON ActualProduced_tbl.Atcnum = AtcMaster.AtcNum INNER JOIN
                         Cm_master ON AtcMaster.Atcid = Cm_master.Atc_id AND ActualProduced_tbl.factid = Cm_master.Factory_id INNER JOIN
                         Factory_Master ON ActualProduced_tbl.factid = Factory_Master.Factory_ID 
 WHERE        (ActualProduced_tbl.DateOfProd BETWEEN @param1 AND @param2)
GROUP BY ActualProduced_tbl.LineID, Factory_Master.Factory_name, ActualProduced_tbl.Linenum, ActualProduced_tbl.Atcnum, ActualProduced_tbl.DateOfProd";


                //  cmd.CommandText = Query1;
                cmd.CommandText = q3;
                cmd.Parameters.AddWithValue("@param1", fromdate);
                cmd.Parameters.AddWithValue("@param2", todate);




                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }

















        public DataTable GetSavedDERReport(DateTime fromdate, DateTime todate)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                String q3 = @"SELECT        DERid, Atcnum, Linenum, Factory_name, DateOfProd, TotalQty, ProducedPercent, BDqty, BDDollor, BDPercent, TargetProduction, BDTarget,BEpercentOB
FROM            DER_TEMP
WHERE        (DateOfProd BETWEEN @param1 AND @param2)";



                //  cmd.CommandText = Query1;
                cmd.CommandText = q3;
                cmd.Parameters.AddWithValue("@param1", fromdate);
                cmd.Parameters.AddWithValue("@param2", todate);




                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }
        public DataTable GetSavedAERReport(DateTime fromdate, DateTime todate)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                String q3 = @"SELECT        AERid, Atcnum, Linenum, Factory_name, DateOfProd, TotalQty, ProducedPercent, BDqty, BDDollor, BDPercent, TargetProduction, BDTarget,BEpercentOB
FROM            AER_TEMP
WHERE        (DateOfProd BETWEEN @param1 AND @param2) ";



                //  cmd.CommandText = Query1;
                cmd.CommandText = q3;
                cmd.Parameters.AddWithValue("@param1", fromdate);
                cmd.Parameters.AddWithValue("@param2", todate);




                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }
        public DataTable GetSavedDERReport(DateTime fromdate, DateTime todate,String factoryname)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                String q3 = @"SELECT        DERid, Atcnum, Linenum, Factory_name, DateOfProd, TotalQty, ProducedPercent, BDqty, BDDollor, BDPercent, TargetProduction, BDTarget,BEpercentOB
FROM            DER_TEMP
WHERE        (DateOfProd BETWEEN @param1 AND @param2) and Factory_name=@param3 ";



                //  cmd.CommandText = Query1;
                cmd.CommandText = q3;
                cmd.Parameters.AddWithValue("@param1", fromdate);
                cmd.Parameters.AddWithValue("@param2", todate);
                cmd.Parameters.AddWithValue("@param3", factoryname);



                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }






        public DataTable getSavedDerwithvalue(DateTime fromdate, DateTime todate)
        {

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                cmd.CommandText = "GetDERVALUES_SP";
                cmd.Parameters.AddWithValue("@fromDate", fromdate);
                cmd.Parameters.AddWithValue("@ToDate", todate);
                cmd.CommandType = CommandType.StoredProcedure;



                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }






        public DataTable GetDailyProduction(int factid, DateTime fromdate, DateTime todate)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                String q3 = @"SELECT        Factory_Master.Factory_name, ActualProduced_tbl.LineID, ActualProduced_tbl.Atcnum, ActualProduced_tbl.Ponum, ActualProduced_tbl.DateOfProd, 
                         ActualProduced_tbl.Linenum, SUM(ActualProduced_tbl.ProducedQty) AS Qty, Factory_Master.Factory_ID
FROM            ActualProduced_tbl INNER JOIN
                         Factory_Master ON ActualProduced_tbl.factid = Factory_Master.Factory_ID
WHERE        (ActualProduced_tbl.DateOfProd BETWEEN @param1 AND @param2)
GROUP BY ActualProduced_tbl.LineID, Factory_Master.Factory_name, ActualProduced_tbl.Atcnum, ActualProduced_tbl.Ponum, ActualProduced_tbl.DateOfProd, 
                         ActualProduced_tbl.Linenum, Factory_Master.Factory_ID
HAVING        (Factory_Master.Factory_ID = @Param3)";



                //  cmd.CommandText = Query1;
                cmd.CommandText = q3;
                cmd.Parameters.AddWithValue("@param1", fromdate);
                cmd.Parameters.AddWithValue("@param2", todate);
                cmd.Parameters.AddWithValue("@param3", factid);




                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        public DataTable GetDailyPacking(int factid, DateTime fromdate, DateTime todate)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                String q3 = @"SELECT        Factory_Master.Factory_name, ActualPacked_tbl.factid, ActualPacked_tbl.Atcnum, ActualPacked_tbl.Linenum, ActualPacked_tbl.POnum, 
                         ActualPacked_tbl.DateofPacking AS DateOfProd, SUM(ActualPacked_tbl.PackedQty) AS Qty, 0 AS lineid
FROM            ActualPacked_tbl INNER JOIN
                         Factory_Master ON ActualPacked_tbl.factid = Factory_Master.Factory_ID
WHERE        (ActualPacked_tbl.DateofPacking BETWEEN @param1 AND @param2)
GROUP BY Factory_Master.Factory_name, ActualPacked_tbl.factid, ActualPacked_tbl.Atcnum, ActualPacked_tbl.Linenum, ActualPacked_tbl.POnum, 
                         ActualPacked_tbl.DateofPacking, ActualPacked_tbl.PackedQty
HAVING        (ActualPacked_tbl.factid = @Param3)";



                //  cmd.CommandText = Query1;
                cmd.CommandText = q3;
                cmd.Parameters.AddWithValue("@param1", fromdate);
                cmd.Parameters.AddWithValue("@param2", todate);
                cmd.Parameters.AddWithValue("@param3", factid);




                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }

        public  void DeleteDER()
        {          

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                
                String q3 = @"DELETE FROM DER_TEMP";
                               
                cmd.CommandText = q3;
              
               cmd.ExecuteNonQuery ();
                              



            }
           
        }
        public void DeleteAER()
        {

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                String q3 = @"DELETE FROM AER_TEMP";

                cmd.CommandText = q3;

                cmd.ExecuteNonQuery();




            }

        }
    }
}
