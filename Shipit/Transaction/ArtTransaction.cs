using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Shipit.DataModels;
namespace Shipit.Transaction
{
    class ArtTransaction
    {
    }


   public  class Atcchart
    {
       public DataTable GetAtcChart(int atcid)
       {
           DataTable BomData = new DataTable();

           using (SqlCommand cmd = new SqlCommand())
           {

                //               cmd.CommandText = @"SELECT        BOMView.SkuDet_PK, BOMView.RMNum, BOMView.Description, BOMView.ColorCode, BOMView.SizeCode, BOMView.ItemColor, BOMView.SupplierColor, BOMView.ItemSize, BOMView.SupplierSize, 
                //                         BOMView.UnitRate, BOMView.Consumption, BOMView.RqdQty, BOMView.PoIssuedQty, BOMView.BalanceQty, BOMView.UomCode, BOMView.Template_pk, BOMView.OrderMin, BOMView.ItemGroup_PK, 
                //                         BOMView.SizeName, BOMView.isCommon, BOMView.IsCD, BOMView.IsSD, PODocview.PONum, PODocview.POQty, PODocview.SupplierSize AS POSSize, PODocview.SupplierColor AS POColor, 
                //                         PODocview.UomCode AS POUOM, PODocview.PODet_PK, PODocview.DocNum, PODocview.ContainerNum, PODocview.Qty, PODocview.Eta, PODocview.Donumber,BOMView.Uom_PK
                //FROM            BOMView LEFT OUTER JOIN
                //                         PODocview ON BOMView.SkuDet_PK = PODocview.SkuDet_PK
                //WHERE        (PODocview.AtcId = @atcid) AND (BOMView.Atc_id = @atcid) order by  BOMView.RMNum";






                cmd.CommandText = @"GetAtcChart_SP";

                cmd.Parameters.AddWithValue("@atcid", atcid);
                cmd.CommandType = CommandType.StoredProcedure;
               BomData= QueryFunctions.ReturnQueryResultDatatableforSP(cmd);
               if (BomData.Rows.Count <= 0)
               {

               }
               else
               {
                   foreach (System.Data.DataColumn col in BomData.Columns) col.ReadOnly = false;
                  // CalculateRequiredPOIssued(BomData);

                    BOMGenerator.CalculateRequiredPOIssued(BomData, atcid);

               }
               return BomData;


           }

       }




        


       public void CalculateRequiredPOIssued(DataTable dt)
       {
          
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               int skudetpk = int.Parse(dt.Rows[i]["SkuDet_PK"].ToString().Trim());

               int uom_pk = int.Parse(dt.Rows[i]["uom_pk"].ToString().Trim());
               String isCD = dt.Rows[i]["IsCD"].ToString().Trim();
               String isSD = dt.Rows[i]["IsSD"].ToString().Trim();
               String isCM = dt.Rows[i]["isCommon"].ToString().Trim();

                //if(skudetpk==30249)
                //{
                //    int k = 0;
                //}
                int reqty = 0;


                if(Program.LogType=="Online")
                {
                    reqty = (int)Math.Round(requiredqtycalculator(skudetpk, isCD, isSD, isCM), 0);
                }
                else
                {
                    reqty = (int)Math.Round(requiredqtycalculatorWeb(skudetpk, isCD, isSD, isCM), 0);
                }
              


               try
               {
                   int ordermin = (int)Math.Round(float.Parse(dt.Rows[i]["OrderMin"].ToString()));
                   if (reqty < ordermin)
                   {
                       reqty = ordermin;
                   }

               }
               catch (Exception)
               {


               }





                //int extrabomqty = (int)Math.Round(bomtrans.GetExtraBOMRequest(skudetpk));


                //int posiisued = (int)Math.Round(bomtrans.GetPoIssuedQtyinBaseUOM(skudetpk, uom_pk), 0);


                //int wrongpoissued = (int)Math.Round(bomtrans.GetWrongPoIssuedQtyinBaseUOMwithApproval(skudetpk, uom_pk), 0);


                //int balanceqty = (reqty - posiisued) + wrongpoissued + extrabomqty;






                int extrabomqty = (int)Math.Round(GetExtraBOMRequest(skudetpk));

                int posiisued = (int)Math.Round(GetPoIssuedQtyinBaseUOM(skudetpk, uom_pk), 0);

                int wrongpoissued = (int)Math.Round(GetWrongPoIssuedQtyinBaseUOMwithApproval(skudetpk, uom_pk), 0);



                int balanceqty = (reqty - posiisued) + wrongpoissued + extrabomqty;



                dt.Rows[i]["RqdQty"] = reqty;
                dt.Rows[i]["PoIssuedQty"] = posiisued;
                dt.Rows[i]["WrongPOQty"] = wrongpoissued;
                dt.Rows[i]["EtraBOMQty"] = extrabomqty;
               dt.Rows[i]["BalanceQty"] = balanceqty;


           }

       }




       /// <summary>
       /// calculate the required Qty of each SkudetPk
       /// </summary>
       /// <param name="skudetpk"></param>
       /// <param name="isCD"></param>
       /// <param name="isSD"></param>
       /// <param name="isCM"></param>
       /// <param name="ColorCode"></param>
       /// <param name="SizeCode"></param>
       /// <returns></returns>
       public float requiredqtycalculator(int skudetpk, String isCD, String isSD, String isCM)
       {
           float requiredqty = 0;


           if (skudetpk == 30298)
           {
               int k = 0;
           }

           try
           {
               if (isCM == "Y" && isCD == "N" && isSD == "N")
               {

                  using (ArtEntities entty = new ArtEntities())
                   {

                     entty.Configuration.AutoDetectChangesEnabled = false;
                      var query = from SkUD in entty.SkuRawmaterialDetails
                                 join SKUM in entty.SkuRawMaterialMasters on SkUD.Sku_PK equals SKUM.Sku_Pk
                                  join STYCD in entty.StyleCostingDetails on SKUM.Sku_Pk equals STYCD.Sku_PK
                                   join STYCM in entty.StyleCostingMasters on STYCD.Costing_PK equals STYCM.Costing_PK
                                   join PPKD in entty.POPackDetails on STYCM.OurStyleID equals PPKD.OurStyleID
                                   where SkUD.SkuDet_PK == skudetpk && STYCM.IsApproved == "A"
                                   select new { PPKD.PoQty, STYCD.Consumption, SKUM.WastagePercentage };

                       var sum = query.Select(c => c.PoQty).Sum();
                       var CONSUMPTION = query.Select(c => c.Consumption).Max();
                       var wastage = query.Select(c => c.WastagePercentage).DefaultIfEmpty(0).Max();
                       requiredqty = float.Parse((float.Parse(sum.ToString()) * float.Parse(CONSUMPTION.ToString())).ToString());

                       float wastageqty = requiredqty * (float.Parse(wastage.ToString()) / 100);


                       requiredqty = requiredqty + wastageqty;

                   }
               }
               else if (isCM == "N" && isCD == "Y" && isSD == "N")
               {
                   using (
























                       ArtEntities entty = new ArtEntities())
                   {
                       entty.Configuration.AutoDetectChangesEnabled = false;
                       var query = from SkUD in entty.SkuRawmaterialDetails
                                   join SKUM in entty.SkuRawMaterialMasters on SkUD.Sku_PK equals SKUM.Sku_Pk
                                   join STYCD in entty.StyleCostingDetails on SKUM.Sku_Pk equals STYCD.Sku_PK
                                   join STYCM in entty.StyleCostingMasters on STYCD.Costing_PK equals STYCM.Costing_PK
                                   join PPKD in entty.POPackDetails on STYCM.OurStyleID equals PPKD.OurStyleID
                                   where SkUD.SkuDet_PK == skudetpk && PPKD.ColorCode == SkUD.ColorCode && STYCM.IsApproved == "A"
                                   select new { PPKD.PoQty, STYCD.Consumption, SKUM.WastagePercentage };

                       var sum = query.Select(c => c.PoQty).Sum();
                       var CONSUMPTION = query.Select(c => c.Consumption).Max();
                       var wastage = query.Select(c => c.WastagePercentage).DefaultIfEmpty(0).Max();
                       requiredqty = float.Parse((float.Parse(sum.ToString()) * float.Parse(CONSUMPTION.ToString())).ToString());
                       float wastageqty = requiredqty * (float.Parse(wastage.ToString()) / 100);


                       requiredqty = requiredqty + wastageqty;


                   }
               }
               else if (isCM == "N" && isCD == "N" && isSD == "Y")
               {
                   using (ArtEntities entty = new ArtEntities())
                   {
                       entty.Configuration.AutoDetectChangesEnabled = false;
                       var query = from SkUD in entty.SkuRawmaterialDetails
                                   join SKUM in entty.SkuRawMaterialMasters on SkUD.Sku_PK equals SKUM.Sku_Pk
                                   join STYCD in entty.StyleCostingDetails on SKUM.Sku_Pk equals STYCD.Sku_PK
                                   join STYCM in entty.StyleCostingMasters on STYCD.Costing_PK equals STYCM.Costing_PK
                                   join PPKD in entty.POPackDetails on STYCM.OurStyleID equals PPKD.OurStyleID
                                   where SkUD.SkuDet_PK == skudetpk && PPKD.SIzeCode == SkUD.SizeCode && STYCM.IsApproved == "A"
                                   select new { PPKD.PoQty, STYCD.Consumption, SKUM.WastagePercentage };

                       var sum = query.Select(c => c.PoQty).Sum();
                       var CONSUMPTION = query.Select(c => c.Consumption).Max();
                       var wastage = query.Select(c => c.WastagePercentage).DefaultIfEmpty(0).Max();
                       requiredqty = float.Parse((float.Parse(sum.ToString()) * float.Parse(CONSUMPTION.ToString())).ToString());

                       float wastageqty = requiredqty * (float.Parse(wastage.ToString()) / 100);


                       requiredqty = requiredqty + wastageqty;
                   }
               }
               else if (isCM == "N" && isCD == "Y" && isSD == "Y")
               {
                   using (ArtEntities entty = new ArtEntities())
                   {
                       var query = from SkUD in entty.SkuRawmaterialDetails
                                   join SKUM in entty.SkuRawMaterialMasters on SkUD.Sku_PK equals SKUM.Sku_Pk
                                   join STYCD in entty.StyleCostingDetails on SKUM.Sku_Pk equals STYCD.Sku_PK
                                   join STYCM in entty.StyleCostingMasters on STYCD.Costing_PK equals STYCM.Costing_PK
                                   join PPKD in entty.POPackDetails on STYCM.OurStyleID equals PPKD.OurStyleID
                                   where SkUD.SkuDet_PK == skudetpk && PPKD.SIzeCode == SkUD.SizeCode && PPKD.ColorCode == SkUD.ColorCode && STYCM.IsApproved == "A"
                                   select new { PPKD.PoQty, STYCD.Consumption, SKUM.WastagePercentage };

                       var sum = query.Select(c => c.PoQty).Sum();
                       var CONSUMPTION = query.Select(c => c.Consumption).Max();
                       var wastage = query.Select(c => c.WastagePercentage).DefaultIfEmpty(0).Max();
                       requiredqty = float.Parse((float.Parse(sum.ToString()) * float.Parse(CONSUMPTION.ToString())).ToString());

                       float wastageqty = requiredqty * (float.Parse(wastage.ToString()) / 100);


                       requiredqty = requiredqty + wastageqty;
                   }
               }
           }
           catch (Exception)
           {


           }


           return requiredqty;
       }












        /// <summary>
        /// calculate the required Qty of each SkudetPk
        /// </summary>
        /// <param name="skudetpk"></param>
        /// <param name="isCD"></param>
        /// <param name="isSD"></param>
        /// <param name="isCM"></param>
        /// <param name="ColorCode"></param>
        /// <param name="SizeCode"></param>
        /// <returns></returns>
        public float requiredqtycalculatorWeb(int skudetpk, String isCD, String isSD, String isCM)
        {
            float requiredqty = 0;


            if (skudetpk == 30298)
            {
                int k = 0;
            }

            try
            {
                if (isCM == "Y" && isCD == "N" && isSD == "N")
                {

                    using (ArtEntities entty = new ArtEntities("D"))
                    {

                        entty.Configuration.AutoDetectChangesEnabled = false;
                        var query = from SkUD in entty.SkuRawmaterialDetails
                                    join SKUM in entty.SkuRawMaterialMasters on SkUD.Sku_PK equals SKUM.Sku_Pk
                                    join STYCD in entty.StyleCostingDetails on SKUM.Sku_Pk equals STYCD.Sku_PK
                                    join STYCM in entty.StyleCostingMasters on STYCD.Costing_PK equals STYCM.Costing_PK
                                    join PPKD in entty.POPackDetails on STYCM.OurStyleID equals PPKD.OurStyleID
                                    where SkUD.SkuDet_PK == skudetpk && STYCM.IsApproved == "A"
                                    select new { PPKD.PoQty, STYCD.Consumption, SKUM.WastagePercentage };

                        var sum = query.Select(c => c.PoQty).Sum();
                        var CONSUMPTION = query.Select(c => c.Consumption).Max();
                        var wastage = query.Select(c => c.WastagePercentage).DefaultIfEmpty(0).Max();
                        requiredqty = float.Parse((float.Parse(sum.ToString()) * float.Parse(CONSUMPTION.ToString())).ToString());

                        float wastageqty = requiredqty * (float.Parse(wastage.ToString()) / 100);


                        requiredqty = requiredqty + wastageqty;

                    }
                }
                else if (isCM == "N" && isCD == "Y" && isSD == "N")
                {
                    using (
























                        ArtEntities entty = new ArtEntities("D"))
                    {
                        entty.Configuration.AutoDetectChangesEnabled = false;
                        var query = from SkUD in entty.SkuRawmaterialDetails
                                    join SKUM in entty.SkuRawMaterialMasters on SkUD.Sku_PK equals SKUM.Sku_Pk
                                    join STYCD in entty.StyleCostingDetails on SKUM.Sku_Pk equals STYCD.Sku_PK
                                    join STYCM in entty.StyleCostingMasters on STYCD.Costing_PK equals STYCM.Costing_PK
                                    join PPKD in entty.POPackDetails on STYCM.OurStyleID equals PPKD.OurStyleID
                                    where SkUD.SkuDet_PK == skudetpk && PPKD.ColorCode == SkUD.ColorCode && STYCM.IsApproved == "A"
                                    select new { PPKD.PoQty, STYCD.Consumption, SKUM.WastagePercentage };

                        var sum = query.Select(c => c.PoQty).Sum();
                        var CONSUMPTION = query.Select(c => c.Consumption).Max();
                        var wastage = query.Select(c => c.WastagePercentage).DefaultIfEmpty(0).Max();
                        requiredqty = float.Parse((float.Parse(sum.ToString()) * float.Parse(CONSUMPTION.ToString())).ToString());
                        float wastageqty = requiredqty * (float.Parse(wastage.ToString()) / 100);


                        requiredqty = requiredqty + wastageqty;


                    }
                }
                else if (isCM == "N" && isCD == "N" && isSD == "Y")
                {
                    using (ArtEntities entty = new ArtEntities("D"))
                    {
                        entty.Configuration.AutoDetectChangesEnabled = false;
                        var query = from SkUD in entty.SkuRawmaterialDetails
                                    join SKUM in entty.SkuRawMaterialMasters on SkUD.Sku_PK equals SKUM.Sku_Pk
                                    join STYCD in entty.StyleCostingDetails on SKUM.Sku_Pk equals STYCD.Sku_PK
                                    join STYCM in entty.StyleCostingMasters on STYCD.Costing_PK equals STYCM.Costing_PK
                                    join PPKD in entty.POPackDetails on STYCM.OurStyleID equals PPKD.OurStyleID
                                    where SkUD.SkuDet_PK == skudetpk && PPKD.SIzeCode == SkUD.SizeCode && STYCM.IsApproved == "A"
                                    select new { PPKD.PoQty, STYCD.Consumption, SKUM.WastagePercentage };

                        var sum = query.Select(c => c.PoQty).Sum();
                        var CONSUMPTION = query.Select(c => c.Consumption).Max();
                        var wastage = query.Select(c => c.WastagePercentage).DefaultIfEmpty(0).Max();
                        requiredqty = float.Parse((float.Parse(sum.ToString()) * float.Parse(CONSUMPTION.ToString())).ToString());

                        float wastageqty = requiredqty * (float.Parse(wastage.ToString()) / 100);


                        requiredqty = requiredqty + wastageqty;
                    }
                }
                else if (isCM == "N" && isCD == "Y" && isSD == "Y")
                {
                    using (ArtEntities entty = new ArtEntities("D"))
                    {
                        var query = from SkUD in entty.SkuRawmaterialDetails
                                    join SKUM in entty.SkuRawMaterialMasters on SkUD.Sku_PK equals SKUM.Sku_Pk
                                    join STYCD in entty.StyleCostingDetails on SKUM.Sku_Pk equals STYCD.Sku_PK
                                    join STYCM in entty.StyleCostingMasters on STYCD.Costing_PK equals STYCM.Costing_PK
                                    join PPKD in entty.POPackDetails on STYCM.OurStyleID equals PPKD.OurStyleID
                                    where SkUD.SkuDet_PK == skudetpk && PPKD.SIzeCode == SkUD.SizeCode && PPKD.ColorCode == SkUD.ColorCode && STYCM.IsApproved == "A"
                                    select new { PPKD.PoQty, STYCD.Consumption, SKUM.WastagePercentage };

                        var sum = query.Select(c => c.PoQty).Sum();
                        var CONSUMPTION = query.Select(c => c.Consumption).Max();
                        var wastage = query.Select(c => c.WastagePercentage).DefaultIfEmpty(0).Max();
                        requiredqty = float.Parse((float.Parse(sum.ToString()) * float.Parse(CONSUMPTION.ToString())).ToString());

                        float wastageqty = requiredqty * (float.Parse(wastage.ToString()) / 100);


                        requiredqty = requiredqty + wastageqty;
                    }
                }
            }
            catch (Exception)
            {


            }


            return requiredqty;
        }





        /// <summary>
        /// Get all the po issued qty and convert them into
        /// baseuom
        /// </summary>
        /// <param name="skudetpk"></param>
        /// <param name="baseuom_pk"></param>
        /// <returns></returns>

        public float GetPoIssuedQtyinBaseUOM(int skudetpk, int baseuom_pk)
        {
            float poissuedqty = 0;
            DataTable dt = new DataTable();
           




            using (SqlConnection con = new SqlConnection(Program.ArtConnStr))
            {
                con.Open();


                //                SqlCommand cmd = new SqlCommand(@"SELECT        SUM(POQty) AS Poqty, Uom_PK
                //FROM            ProcurementDetails

                //GROUP BY Uom_PK, SkuDet_PK
                //HAVING        (SkuDet_PK = @Param1)
                //", con);

                SqlCommand cmd = new SqlCommand(@"SELECT SUM(ProcurementDetails.POQty)AS Poqty, ProcurementDetails.Uom_PK
FROM            ProcurementDetails INNER JOIN
                         ProcurementMaster ON ProcurementDetails.PO_Pk = ProcurementMaster.PO_Pk

                         WHERE(ProcurementMaster.IsDeleted <> N'Y')
GROUP BY ProcurementDetails.Uom_PK, ProcurementDetails.SkuDet_PK
HAVING(ProcurementDetails.SkuDet_PK = @Param1)
", con);
                

                cmd.Parameters.AddWithValue("@Param1", skudetpk);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);
            }


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Uom_PK"].ToString().Trim() == baseuom_pk.ToString().Trim())
                        {
                            poissuedqty = poissuedqty + float.Parse(dt.Rows[i]["POQty"].ToString());
                        }
                        else
                        {
                            poissuedqty = poissuedqty + UOMConvertortoAlt(baseuom_pk, int.Parse(dt.Rows[i]["Uom_PK"].ToString()), float.Parse(dt.Rows[i]["POQty"].ToString()));
                        }
                    }
                }
            }













            return poissuedqty;
        }

        /// <summary>
        /// convert the qnty in base UOm to the Qty in Alt UOm
        /// </summary>
        /// <param name="uomPK"></param>
        /// <param name="auomPk"></param>
        /// <param name="balqtyinBaseuom"></param>
        /// <returns></returns>
        public float UOMConvertortoAlt(int uomPK, int auomPk, float balqtyinBaseuom)
        {

            float converttobaseqty = 0;
            float operend = 1;
            String operatorused = "*";

            DataTable dt = getAltuomdata(uomPK, auomPk);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    operend = float.Parse(dt.Rows[0]["Conv_fact"].ToString());
                    operatorused = dt.Rows[0]["Operator"].ToString().Trim();
                    if (operatorused == "*")
                    {

                        converttobaseqty = balqtyinBaseuom / operend;
                    }
                    else if (operatorused == "/")
                    {
                        converttobaseqty = balqtyinBaseuom * operend;
                    }
                }





            }
            return converttobaseqty;


        }


        /// <summary>
        /// Get the conversion factor and Operator for altuom conversion
        /// </summary>
        /// <param name="baseuom_pk"></param>
        /// <param name="altuom_pk"></param>
        /// <returns></returns>

        public DataTable getAltuomdata(int baseuom_pk, int altuom_pk)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ArtConnStr))
            {
                con.Open();




                SqlCommand cmd = new SqlCommand(@"SELECT        Conv_fact, Operator
FROM            AltUOMMaster
WHERE        (Uom_PK = @baseuom) AND (AltUom_PK = @altuom)", con);
                cmd.Parameters.AddWithValue("@baseuom", baseuom_pk);
                cmd.Parameters.AddWithValue("@altuom", altuom_pk);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        /// <summary>
        /// get the wrong PO approved nd add it to BOM
        /// </summary>
        /// <param name="skudetpk"></param>
        /// <param name="baseuom_pk"></param>
        /// <returns></returns>
        public float GetWrongPoIssuedQtyinBaseUOMwithApproval(int skudetpk, int baseuom_pk)
        {
            float poissuedqty = 0;
            DataTable dt = new DataTable();
           




            using (SqlConnection con = new SqlConnection(Program.ArtConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT        ProcurementDetails.Uom_PK, SUM(WrongPODetail.Qty) AS POQty
FROM            ProcurementDetails INNER JOIN
                         WrongPODetail ON ProcurementDetails.PODet_PK = WrongPODetail.Podet_PK INNER JOIN
                         WrongPOMaster ON WrongPODetail.WrongPO_Pk = WrongPOMaster.WrongPO_Pk
GROUP BY ProcurementDetails.Uom_PK, ProcurementDetails.SkuDet_PK, WrongPOMaster.IsApproved
HAVING        (ProcurementDetails.SkuDet_PK = @Param1) AND (WrongPOMaster.IsApproved = N'Y')
", con);


                cmd.Parameters.AddWithValue("@Param1", skudetpk);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);
            }


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Uom_PK"].ToString().Trim() == baseuom_pk.ToString().Trim())
                        {
                            poissuedqty = poissuedqty + float.Parse(dt.Rows[i]["POQty"].ToString());
                        }
                        else
                        {
                            poissuedqty = poissuedqty + UOMConvertortoAlt(baseuom_pk, int.Parse(dt.Rows[i]["Uom_PK"].ToString()), float.Parse(dt.Rows[i]["POQty"].ToString()));
                        }
                    }
                }
            }













            return poissuedqty;
        }





        /// <summary>
        /// Get all extrabomRequest of an SKUDETPK
        /// baseuom
        /// </summary>
        /// <param name="skudetpk"></param>
        /// <param name="baseuom_pk"></param>
        /// <returns></returns>

        public float GetExtraBOMRequest(int skudetpk)
        {
            float poissuedqty = 0;
            DataTable dt = new DataTable();
            




            using (SqlConnection con = new SqlConnection(Program.ArtConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"SELECT      ISNULL(  SUM(ExtraBOMRequestDetail.Qty),0 ) as ExtraQty
FROM            ExtraBOMRequestMaster INNER JOIN
                         ExtraBOMRequestDetail ON ExtraBOMRequestMaster.ExtraBOM_PK = ExtraBOMRequestDetail.ExtraBOM_PK
GROUP BY ExtraBOMRequestMaster.IsApproved, ExtraBOMRequestDetail.Skudet_PK
HAVING        (ExtraBOMRequestMaster.IsApproved = N'Y') AND (ExtraBOMRequestDetail.Skudet_PK = @Param1)
", con);


                cmd.Parameters.AddWithValue("@Param1", skudetpk);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);
            }


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        poissuedqty = poissuedqty + float.Parse(dt.Rows[i]["ExtraQty"].ToString());

                    }
                }
            }













            return poissuedqty;
        }





    }


    public class ArtReports
    {
        public DataTable GetRollsActionPending(String pendingstage)
        {

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ArtConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string Query1 = "GetQualityPendingReport_SP";


                cmd.CommandText = Query1;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Pending", pendingstage);


                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;


        }



        public DataTable GetASNREport(int asn_pk)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ArtConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string Query1 = "GetASNReport_SP";


                cmd.CommandText = Query1;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@asn_pk", asn_pk);
                cmd.Parameters.AddWithValue("@skudet_PK", 0);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        public DataTable GetDocumentnumber()
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"SELECT       DISTINCT  (SupplierDocumentMaster.SupplierDocnum +' / '+SupplierDocumentMaster.AtracotrackingNum) AS name, SupplierDocumentMaster.SupplierDoc_pk as pk
FROM            SupplierDocumentMaster INNER JOIN
                         FabricRollmaster ON SupplierDocumentMaster.SupplierDoc_pk = FabricRollmaster.SupplierDoc_pk INNER JOIN
                         ProcurementDetails ON FabricRollmaster.podet_pk = ProcurementDetails.PODet_PK INNER JOIN
                         ProcurementMaster ON ProcurementDetails.PO_Pk = ProcurementMaster.PO_Pk";
             

                return QueryFunctions.ReturnQueryResultDatatable(cmd);
            }
        }


    }



    public static class BOMGenerator
    {

        static String connStr = Program.ArtConnStr;
        public static DataTable CalculateRequiredPOIssued(DataTable dt, int atcid)
        {
            DataTable skudata = GetSKUData(atcid);
            DataTable EBOMData = GetEBOMData(atcid);
            DataTable POData = GetPOData(atcid);
            DataTable WPOData = GetWPOData(atcid);




         
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                float requiredqty = 0;
                int extrabomqty = 0;
                int posiisued = 0;
                int wrongpoissued = 0;


                int balanceqty = 0;

                int skudetpk = int.Parse(dt.Rows[i]["SkuDet_PK"].ToString().Trim());

                if (skudetpk == 54260)
                {
                    int k = 9;
                }
                int uom_pk = int.Parse(dt.Rows[i]["uom_pk"].ToString().Trim());
                String isCD = dt.Rows[i]["IsCD"].ToString().Trim();
                String isSD = dt.Rows[i]["IsSD"].ToString().Trim();
                String isCM = dt.Rows[i]["isCommon"].ToString().Trim();
                String IsGD = dt.Rows[i]["IsGD"].ToString().Trim();



                int reqty = (int)Math.Round(requiredQtyCalculate(skudetpk, isCD, isSD, isCM, IsGD, skudata), 0);

                try
                {
                    int ordermin = (int)Math.Round(float.Parse(dt.Rows[i]["OrderMin"].ToString()));
                    if (reqty < ordermin)
                    {
                        reqty = ordermin;
                    }

                }
                catch (Exception)
                {


                }
                try
                {
                    extrabomqty = (int)Math.Round(GetExtraBOMRequest(skudetpk, EBOMData));
                }
                catch (Exception)
                {


                }
                try
                {
                    posiisued = (int)Math.Round(GetPoIssuedQtyinBaseUOM(skudetpk, uom_pk, POData), 0);
                }
                catch (Exception)
                {


                }
                try
                {
                    wrongpoissued = (int)Math.Round(GetWrongPoIssuedQtyinBaseUOMwithApproval(skudetpk, uom_pk, WPOData), 0);
                }
                catch (Exception)
                {


                }
                try
                {
                    balanceqty = (reqty - posiisued) + wrongpoissued + extrabomqty;

                }
                catch (Exception)
                {


                }

                dt.Rows[i]["RqdQty"] = reqty;
                dt.Rows[i]["PoIssuedQty"] = posiisued;
                dt.Rows[i]["BalanceQty"] = balanceqty;


            }
            return dt;
        }











        public static float requiredQtyCalculate(int skudetpk, String isCD, String isSD, String isCM, String IsGD, DataTable skudata)
        {
            float requiredqty = 0;
            if (isCM == "Y" && isCD == "N" && isSD == "N" && IsGD == "N")
            {
                try
                {
                    DataTable newresult = skudata.Select("SkuDet_PK = " + skudetpk + "").CopyToDataTable();

                    var sum = newresult.Compute("SUM(PoQty)", "");
                    var CONSUMPTION = newresult.Compute("MAX(Consumption)", "");
                    var wastage = newresult.Compute("MAX(WastagePercentage)", "");

                    requiredqty = float.Parse((float.Parse(sum.ToString()) * float.Parse(CONSUMPTION.ToString())).ToString());

                    float wastageqty = requiredqty * (float.Parse(wastage.ToString()) / 100);


                    requiredqty = requiredqty + wastageqty;
                }
                catch (Exception)
                {


                }
            }
            else if (isCM == "N" && isCD == "Y" && isSD == "N" && IsGD == "N")
            {

                try
                {
                    DataTable newresult = skudata.Select("SkuDet_PK = " + skudetpk + " and ColorCode =SKUColorCode").CopyToDataTable();

                    var sum = newresult.Compute("SUM(PoQty)", "");
                    var CONSUMPTION = newresult.Compute("MAX(Consumption)", "");
                    var wastage = newresult.Compute("MAX(WastagePercentage)", "");

                    requiredqty = float.Parse((float.Parse(sum.ToString()) * float.Parse(CONSUMPTION.ToString())).ToString());

                    float wastageqty = requiredqty * (float.Parse(wastage.ToString()) / 100);


                    requiredqty = requiredqty + wastageqty;
                }
                catch (Exception)
                {


                }

            }
            else if (isCM == "N" && isCD == "N" && isSD == "Y" && IsGD == "N")
            {
                try
                {
                    DataTable newresult = skudata.Select("SkuDet_PK = " + skudetpk + " and SIzeCode =SKUSizeCode").CopyToDataTable();

                    var sum = newresult.Compute("SUM(PoQty)", "");
                    var CONSUMPTION = newresult.Compute("MAX(Consumption)", "");
                    var wastage = newresult.Compute("MAX(WastagePercentage)", "");

                    requiredqty = float.Parse((float.Parse(sum.ToString()) * float.Parse(CONSUMPTION.ToString())).ToString());

                    float wastageqty = requiredqty * (float.Parse(wastage.ToString()) / 100);


                    requiredqty = requiredqty + wastageqty;
                }
                catch (Exception)
                {


                }
            }
            else if (isCM == "N" && isCD == "Y" && isSD == "Y" && IsGD == "N")
            {
                try
                {
                    DataTable newresult = skudata.Select("SkuDet_PK = " + skudetpk + " and SIzeCode =SKUSizeCode and ColorCode =SKUColorCode").CopyToDataTable();

                    var sum = newresult.Compute("SUM(PoQty)", "");
                    var CONSUMPTION = newresult.Compute("MAX(Consumption)", "");
                    var wastage = newresult.Compute("MAX(WastagePercentage)", "");

                    requiredqty = float.Parse((float.Parse(sum.ToString()) * float.Parse(CONSUMPTION.ToString())).ToString());

                    float wastageqty = requiredqty * (float.Parse(wastage.ToString()) / 100);


                    requiredqty = requiredqty + wastageqty;
                }
                catch (Exception exp)
                {


                }
            }
            else if (IsGD == "Y")
            {
                // if ggroup dependa

                try
                {
                    if (isCM == "Y" && isCD == "N" && isSD == "N" && IsGD == "Y")
                    {
                        requiredqty = GroupDependantCommonQty(skudetpk);
                    }
                    else if (isCM == "N" && isCD == "Y" && isSD == "N" && IsGD == "Y")
                    {
                        requiredqty = GroupDependantColorQty(skudetpk);

                    }
                    else if (isCM == "N" && isCD == "N" && isSD == "Y" && IsGD == "Y")
                    {
                        requiredqty = GroupDependantSizeQty(skudetpk);

                    }
                    else if (isCM == "N" && isCD == "Y" && isSD == "Y" && IsGD == "Y")
                    {
                        requiredqty = GroupDependantSizeandColorQty(skudetpk);

                    }
                }
                catch (Exception)
                {


                }
            }

            return requiredqty;
        }


        public static float GetExtraBOMRequest(int skudetpk, DataTable EBomData)

        {
            float extraqty = 0;
            try
            {
                var sum = EBomData.Compute("SUM(PoQty)", "Skudet_PK=" + skudetpk + "");
                extraqty = float.Parse(sum.ToString());
            }
            catch (Exception)
            {


            }
            return extraqty;
        }



        /// <summary>
        /// Get all the po issued qty and convert them into
        /// baseuom
        /// </summary>
        /// <param name="skudetpk"></param>
        /// <param name="baseuom_pk"></param>
        /// <returns></returns>

        public static float GetPoIssuedQtyinBaseUOM(int skudetpk, int baseuom_pk, DataTable POData)
        {
            float poissuedqty = 0;



            DataTable dt = POData.Select("SkuDet_PK = " + skudetpk + "").CopyToDataTable();



            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Uom_PK"].ToString().Trim() == baseuom_pk.ToString().Trim())
                        {
                            poissuedqty = poissuedqty + float.Parse(dt.Rows[i]["POQty"].ToString());
                        }
                        else
                        {
                            poissuedqty = poissuedqty + UOMConvertortoAlt(baseuom_pk, int.Parse(dt.Rows[i]["Uom_PK"].ToString()), float.Parse(dt.Rows[i]["POQty"].ToString()));
                        }
                    }
                }
            }













            return poissuedqty;
        }


        /// <summary>
        /// convert the qnty in base UOm to the Qty in Alt UOm
        /// </summary>
        /// <param name="uomPK"></param>
        /// <param name="auomPk"></param>
        /// <param name="balqtyinBaseuom"></param>
        /// <returns></returns>
        public static float UOMConvertortoAlt(int uomPK, int auomPk, float balqtyinBaseuom)
        {

            float converttobaseqty = 0;
            float operend = 1;
            String operatorused = "*";

            DataTable dt = getAltuomdata(uomPK, auomPk);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    operend = float.Parse(dt.Rows[0]["Conv_fact"].ToString());
                    operatorused = dt.Rows[0]["Operator"].ToString().Trim();
                    if (operatorused == "*")
                    {

                        converttobaseqty = balqtyinBaseuom / operend;
                    }
                    else if (operatorused == "/")
                    {
                        converttobaseqty = balqtyinBaseuom * operend;
                    }
                }





            }
            return converttobaseqty;


        }


        /// <summary>
        /// Get the conversion factor and Operator for altuom conversion
        /// </summary>
        /// <param name="baseuom_pk"></param>
        /// <param name="altuom_pk"></param>
        /// <returns></returns>

        public static DataTable getAltuomdata(int baseuom_pk, int altuom_pk)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();




                SqlCommand cmd = new SqlCommand(@"SELECT        Conv_fact, Operator
FROM            AltUOMMaster
WHERE        (Uom_PK = @baseuom) AND (AltUom_PK = @altuom)", con);
                cmd.Parameters.AddWithValue("@baseuom", baseuom_pk);
                cmd.Parameters.AddWithValue("@altuom", altuom_pk);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        public static float GetWrongPoIssuedQtyinBaseUOMwithApproval(int skudetpk, int baseuom_pk, DataTable WPOData)
        {
            float poissuedqty = 0;
            DataTable dt = WPOData.Select("SkuDet_PK = " + skudetpk + "").CopyToDataTable();




            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Uom_PK"].ToString().Trim() == baseuom_pk.ToString().Trim())
                        {
                            poissuedqty = poissuedqty + float.Parse(dt.Rows[i]["POQty"].ToString());
                        }
                        else
                        {
                            poissuedqty = poissuedqty + UOMConvertortoAlt(baseuom_pk, int.Parse(dt.Rows[i]["Uom_PK"].ToString()), float.Parse(dt.Rows[i]["POQty"].ToString()));
                        }
                    }
                }
            }













            return poissuedqty;
        }


        /// <summary>
        /// Group Dependant and Common
        /// </summary>
        /// <param name="skudetpk"></param>
        /// <returns></returns>
        public static float GroupDependantCommonQty(int skudetpk)
        {
            float requiredqty = 0;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT        ISNULL(MAX(StyleCostingDetails.Consumption), 0) AS Consumption, ISNULL(SUM(POPackDetails.PoQty), 0) AS PoQty, ISNULL(AVG(SkuRawMaterialMaster.WastagePercentage), 0) AS WastagePercentage
FROM            SkuRawmaterialDetail INNER JOIN
                         SkuRawMaterialMaster ON SkuRawmaterialDetail.Sku_PK = SkuRawMaterialMaster.Sku_Pk INNER JOIN
                         GroupDependantItems ON SkuRawMaterialMaster.Sku_Pk = GroupDependantItems.Sku_PK INNER JOIN
                         StyleCostingDetails ON SkuRawMaterialMaster.Sku_Pk = StyleCostingDetails.Sku_PK INNER JOIN
                         StyleCostingMaster ON StyleCostingDetails.Costing_PK = StyleCostingMaster.Costing_PK INNER JOIN
                         POPackDetails ON StyleCostingMaster.OurStyleID = POPackDetails.OurStyleID AND GroupDependantItems.POPackID = POPackDetails.POPackId
WHERE        (StyleCostingMaster.IsApproved = N'A')
GROUP BY SkuRawmaterialDetail.SkuDet_PK
HAVING        (SkuRawmaterialDetail.SkuDet_PK = @Param1)";


            cmd.Parameters.AddWithValue("@param1", skudetpk);



            DataTable dt = QueryFunctions.ReturnQueryResultDatatable(cmd);
            try
            {

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var sum = dt.Rows[0]["PoQty"];
                        var CONSUMPTION = dt.Rows[0]["Consumption"];
                        var wastage = dt.Rows[0]["WastagePercentage"];
                        requiredqty = float.Parse((float.Parse(sum.ToString()) * float.Parse(CONSUMPTION.ToString())).ToString());

                        float wastageqty = requiredqty * (float.Parse(wastage.ToString()) / 100);


                        requiredqty = requiredqty + wastageqty;

                    }
                }
            }
            catch (Exception)
            {


            }

            return requiredqty;
        }




        /// <summary>
        /// Group Dependant and Color
        /// </summary>
        /// <param name="skudetpk"></param>
        /// <returns></returns>
        public static float GroupDependantColorQty(int skudetpk)
        {
            float requiredqty = 0;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT        ISNULL(MAX(StyleCostingDetails.Consumption), 0) AS Consumption, ISNULL(SUM(POPackDetails.PoQty), 0) AS PoQty, ISNULL(AVG(SkuRawMaterialMaster.WastagePercentage), 0) AS WastagePercentage
FROM            SkuRawmaterialDetail INNER JOIN
                         SkuRawMaterialMaster ON SkuRawmaterialDetail.Sku_PK = SkuRawMaterialMaster.Sku_Pk INNER JOIN
                         GroupDependantItems ON SkuRawMaterialMaster.Sku_Pk = GroupDependantItems.Sku_PK INNER JOIN
                         StyleCostingDetails ON SkuRawMaterialMaster.Sku_Pk = StyleCostingDetails.Sku_PK INNER JOIN
                         StyleCostingMaster ON StyleCostingDetails.Costing_PK = StyleCostingMaster.Costing_PK INNER JOIN
                         POPackDetails ON StyleCostingMaster.OurStyleID = POPackDetails.OurStyleID AND GroupDependantItems.POPackID = POPackDetails.POPackId AND 
                         SkuRawmaterialDetail.ColorCode = POPackDetails.ColorCode
WHERE        (StyleCostingMaster.IsApproved = N'A')
GROUP BY SkuRawmaterialDetail.SkuDet_PK
HAVING        (SkuRawmaterialDetail.SkuDet_PK = @Param1)";


            cmd.Parameters.AddWithValue("@param1", skudetpk);



            DataTable dt = QueryFunctions.ReturnQueryResultDatatable(cmd);
            try
            {

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var sum = dt.Rows[0]["PoQty"];
                        var CONSUMPTION = dt.Rows[0]["Consumption"];
                        var wastage = dt.Rows[0]["WastagePercentage"];
                        requiredqty = float.Parse((float.Parse(sum.ToString()) * float.Parse(CONSUMPTION.ToString())).ToString());

                        float wastageqty = requiredqty * (float.Parse(wastage.ToString()) / 100);


                        requiredqty = requiredqty + wastageqty;

                    }
                }
            }
            catch (Exception)
            {


            }

            return requiredqty;
        }


        /// <summary>
        /// Group Dependant and Size
        /// </summary>
        /// <param name="skudetpk"></param>
        /// <returns></returns>
        public static float GroupDependantSizeQty(int skudetpk)
        {
            float requiredqty = 0;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT        ISNULL(MAX(StyleCostingDetails.Consumption), 0) AS Consumption, ISNULL(SUM(POPackDetails.PoQty), 0) AS PoQty, ISNULL(AVG(SkuRawMaterialMaster.WastagePercentage), 0) AS WastagePercentage
FROM            SkuRawmaterialDetail INNER JOIN
                         SkuRawMaterialMaster ON SkuRawmaterialDetail.Sku_PK = SkuRawMaterialMaster.Sku_Pk INNER JOIN
                         GroupDependantItems ON SkuRawMaterialMaster.Sku_Pk = GroupDependantItems.Sku_PK INNER JOIN
                         StyleCostingDetails ON SkuRawMaterialMaster.Sku_Pk = StyleCostingDetails.Sku_PK INNER JOIN
                         StyleCostingMaster ON StyleCostingDetails.Costing_PK = StyleCostingMaster.Costing_PK INNER JOIN
                         POPackDetails ON StyleCostingMaster.OurStyleID = POPackDetails.OurStyleID AND GroupDependantItems.POPackID = POPackDetails.POPackId AND 
                         SkuRawmaterialDetail.SizeCode = POPackDetails.SizeCode
WHERE        (StyleCostingMaster.IsApproved = N'A')
GROUP BY SkuRawmaterialDetail.SkuDet_PK
HAVING        (SkuRawmaterialDetail.SkuDet_PK = @Param1)";


            cmd.Parameters.AddWithValue("@param1", skudetpk);



            DataTable dt = QueryFunctions.ReturnQueryResultDatatable(cmd);
            try
            {

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var sum = dt.Rows[0]["PoQty"];
                        var CONSUMPTION = dt.Rows[0]["Consumption"];
                        var wastage = dt.Rows[0]["Consumption"];
                        requiredqty = float.Parse((float.Parse(sum.ToString()) * float.Parse(CONSUMPTION.ToString())).ToString());

                        float wastageqty = requiredqty * (float.Parse(wastage.ToString()) / 100);


                        requiredqty = requiredqty + wastageqty;

                    }
                }
            }
            catch (Exception)
            {


            }

            return requiredqty;
        }




        /// <summary>
        /// Group Dependant and Color and Size
        /// </summary>
        /// <param name="skudetpk"></param>
        /// <returns></returns>
        public static float GroupDependantSizeandColorQty(int skudetpk)
        {
            float requiredqty = 0;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT        ISNULL(MAX(StyleCostingDetails.Consumption), 0) AS Consumption, ISNULL(SUM(POPackDetails.PoQty), 0) AS PoQty, ISNULL(AVG(SkuRawMaterialMaster.WastagePercentage), 0) AS WastagePercentage
FROM            SkuRawmaterialDetail INNER JOIN
                         SkuRawMaterialMaster ON SkuRawmaterialDetail.Sku_PK = SkuRawMaterialMaster.Sku_Pk INNER JOIN
                         GroupDependantItems ON SkuRawMaterialMaster.Sku_Pk = GroupDependantItems.Sku_PK INNER JOIN
                         StyleCostingDetails ON SkuRawMaterialMaster.Sku_Pk = StyleCostingDetails.Sku_PK INNER JOIN
                         StyleCostingMaster ON StyleCostingDetails.Costing_PK = StyleCostingMaster.Costing_PK INNER JOIN
                         POPackDetails ON StyleCostingMaster.OurStyleID = POPackDetails.OurStyleID AND GroupDependantItems.POPackID = POPackDetails.POPackId AND 
                         SkuRawmaterialDetail.SizeCode = POPackDetails.SizeCode and     SkuRawmaterialDetail.ColorCode = POPackDetails.ColorCode
WHERE        (StyleCostingMaster.IsApproved = N'A')
GROUP BY SkuRawmaterialDetail.SkuDet_PK
HAVING        (SkuRawmaterialDetail.SkuDet_PK = @Param1)";


            cmd.Parameters.AddWithValue("@param1", skudetpk);



            DataTable dt = QueryFunctions.ReturnQueryResultDatatable(cmd);
            try
            {

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var sum = dt.Rows[0]["PoQty"];
                        var CONSUMPTION = dt.Rows[0]["Consumption"];
                        var wastage = dt.Rows[0]["WastagePercentage"];
                        requiredqty = float.Parse((float.Parse(sum.ToString()) * float.Parse(CONSUMPTION.ToString())).ToString());

                        float wastageqty = requiredqty * (float.Parse(wastage.ToString()) / 100);


                        requiredqty = requiredqty + wastageqty;

                    }
                }
            }
            catch (Exception)
            {


            }

            return requiredqty;
        }






        public static System.Data.DataTable GetSKUData(int ATCID)
        {
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand())
            {


                cmd.CommandText = @" SELECT        SkuRawMaterialMaster.WastagePercentage, SkuRawMaterialMaster.Sku_Pk, SkuRawmaterialDetail.SkuDet_PK, StyleCostingDetails.Consumption, StyleCostingMaster.OurStyleID, POPackDetails.ColorCode, 
                         POPackDetails.SIzeCode, POPackDetails.PoQty, StyleCostingMaster.IsApproved, SkuRawMaterialMaster.Atc_id, StyleCostingDetails.IsRequired,SkuRawmaterialDetail.ColorCode AS SKUColorCode, 
                         SkuRawmaterialDetail.SizeCode AS SKUSizeCode
FROM            SkuRawMaterialMaster INNER JOIN
                         StyleCostingDetails ON SkuRawMaterialMaster.Sku_Pk = StyleCostingDetails.Sku_PK INNER JOIN
                         StyleCostingMaster ON StyleCostingDetails.Costing_PK = StyleCostingMaster.Costing_PK INNER JOIN
                         POPackDetails ON StyleCostingMaster.OurStyleID = POPackDetails.OurStyleID INNER JOIN
                         SkuRawmaterialDetail ON StyleCostingDetails.Sku_PK = SkuRawmaterialDetail.Sku_PK
WHERE        (StyleCostingMaster.IsApproved = N'A') AND (SkuRawMaterialMaster.Atc_id = @ATCID) AND (StyleCostingDetails.IsRequired = N'Y')";



                cmd.Parameters.AddWithValue("@ATCID", ATCID);

                dt = QueryFunctions.ReturnQueryResultDatatable(cmd);



            }
            return dt;
        }

        public static System.Data.DataTable GetEBOMData(int ATCID)
        {
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand())
            {


                cmd.CommandText = @"SELECT        ISNULL(SUM(ExtraBOMRequestDetail.Qty), 0) AS ExtraQty,ExtraBOMRequestDetail.Skudet_PK
FROM            ExtraBOMRequestMaster INNER JOIN
                         ExtraBOMRequestDetail ON ExtraBOMRequestMaster.ExtraBOM_PK = ExtraBOMRequestDetail.ExtraBOM_PK
GROUP BY ExtraBOMRequestMaster.IsApproved, ExtraBOMRequestDetail.Skudet_PK, ExtraBOMRequestMaster.AtcId
HAVING        (ExtraBOMRequestMaster.IsApproved = N'Y') AND (ExtraBOMRequestMaster.AtcId = @ATCID)";



                cmd.Parameters.AddWithValue("@ATCID", ATCID);

                dt = QueryFunctions.ReturnQueryResultDatatable(cmd);



            }
            return dt;
        }


        public static System.Data.DataTable GetPOData(int ATCID)
        {
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand())
            {


                cmd.CommandText = @"SELECT SUM(ProcurementDetails.POQty) AS Poqty, ProcurementDetails.Uom_PK, ProcurementMaster.AtcId,ProcurementDetails.SkuDet_PK
FROM            ProcurementDetails INNER JOIN
                  ProcurementMaster ON ProcurementDetails.PO_Pk = ProcurementMaster.PO_Pk
WHERE        (ProcurementMaster.IsDeleted<> N'Y')
GROUP BY ProcurementDetails.Uom_PK, ProcurementDetails.SkuDet_PK, ProcurementMaster.AtcId
HAVING(ProcurementMaster.AtcId = @ATCID)";



                cmd.Parameters.AddWithValue("@ATCID", ATCID);

                dt = QueryFunctions.ReturnQueryResultDatatable(cmd);



            }
            return dt;
        }



        public static System.Data.DataTable GetWPOData(int ATCID)
        {
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand())
            {


                cmd.CommandText = @"SELECT        ProcurementDetails.Uom_PK, SUM(WrongPODetail.Qty) AS POQty, WrongPODetail.Skudet_pk, ProcurementMaster.AtcId
FROM            ProcurementDetails INNER JOIN
                         WrongPODetail ON ProcurementDetails.PODet_PK = WrongPODetail.Podet_PK INNER JOIN
                         WrongPOMaster ON WrongPODetail.WrongPO_Pk = WrongPOMaster.WrongPO_Pk INNER JOIN
                         ProcurementMaster ON ProcurementDetails.PO_Pk = ProcurementMaster.PO_Pk
GROUP BY ProcurementDetails.Uom_PK, ProcurementDetails.SkuDet_PK, WrongPOMaster.IsApproved, WrongPODetail.Skudet_pk, ProcurementMaster.AtcId
HAVING        (WrongPOMaster.IsApproved = N'Y') AND (ProcurementMaster.AtcId = @ATCID)";



                cmd.Parameters.AddWithValue("@ATCID", ATCID);

                dt = QueryFunctions.ReturnQueryResultDatatable(cmd);



            }
            return dt;
        }













    }


    public static class QueryFunctions
    {

        public static Object ReturnQueryValue(SqlCommand cmd)
        {
            Object returnValue;
            using (SqlConnection con = new SqlConnection(Program.ArtConnStr))
            {




                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();

                returnValue = cmd.ExecuteScalar();
            }

            return returnValue;
        }



        public static DataTable ReturnQueryResultDatatable(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ArtConnStr))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);
            }

            return dt;
        }


        public static DataTable ReturnQueryResultDatatableforSP(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Program.ArtConnStr))
            {
               
                cmd.Connection = con;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);
            }

            return dt;
        }



    }
}
