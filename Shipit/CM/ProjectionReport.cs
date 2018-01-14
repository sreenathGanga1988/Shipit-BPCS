using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit
{
    public partial class ProjectionReport : Form
    {
        Transaction.ReportTransaction rpttran = null;
        Transaction.DataExporter DTPEXPTR = null;
        DataTable newdata = new DataTable();
        public ProjectionReport()
        {
            InitializeComponent();
            rpttran = new Transaction.ReportTransaction();
            LoadFactoryCombo();
        }
        public void LoadFactoryCombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from fctry in courdatacontext.Factory_Masters
                    select fctry;



            factorycombo.DataSource = q;
            factorycombo.DisplayMember = "Factory_name";
            factorycombo.ValueMember = "Factory_ID";
            //   Buyercombo.DataBind();



        }
        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = rpttran.CMReport();
            foreach (DataColumn clmn in dt.Columns)
            {
                clmn.ReadOnly = false;
            }
            dataGridView1.DataSource = dt;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void croppedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }




        public void getlinewiseob()
        {


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                
                // DataTable linedata = rpttran.LinedataCM(dtp_from.Value.Date, dtp_to.Value.Date, int.Parse(dataGridView1.Rows[i].Cells["Lineid"].Value.ToString()), dataGridView1.Rows[i].Cells["Atcnum"].Value.ToString());
                DataTable linedata = rpttran.LinedataCM(dtp_from.Value.Date, dtp_to.Value.Date, int.Parse(dataGridView1.Rows[i].Cells["Lineid"].Value.ToString()), dataGridView1.Rows[i].Cells["OurStyle"].Value.ToString());
                foreach (DataColumn clmn in linedata.Columns)
                {
                    clmn.ReadOnly = false;
                }
                linedata.Columns.Add("OBHelpertoOperator", typeof(float));
                linedata.Columns.Add("LinePlanHelpertoOperator", typeof(float));
                linedata.Columns.Add("pcsperMachine", typeof(float));
                linedata.Columns.Add("LineplanAllowednampower", typeof(float));
                linedata.Columns.Add("IsPlannedRatioGreater", typeof(String));
                linedata.Columns.Add("targetBasedon8by5", typeof(float));
                
                linedata.Columns.Add("WhatSholudbe100percent", typeof(float));
                linedata.Columns.Add("actualPercent", typeof(float));
                linedata.Columns.Add("WhatShouldbeActualQty", typeof(float));
                linedata.Columns.Add("percentWeighted", typeof(float));
                linedata.Columns.Add("LineID", typeof(int));
                linedata.Columns.Add("TotalHourWorked", typeof(int));
                linedata.Columns.Add("Atcnum", typeof(String));
                
                if (linedata.Rows.Count != 0)
                {
                    for (int j = 0; j < linedata.Rows.Count; j++)
                    {
                        linedata.Rows[j]["LineID"] = int.Parse(dataGridView1.Rows[i].Cells["Lineid"].Value.ToString());
                        linedata.Rows[j]["Atcnum"] = dataGridView1.Rows[i].Cells["Atcnum"].Value.ToString();
                      
                        linedata.Rows[j]["PlannedOperators"] = int.Parse(dataGridView1.Rows[i].Cells["LoadPlanOperator"].Value.ToString());
                        linedata.Rows[j]["PlannedHelpers"] = int.Parse(dataGridView1.Rows[i].Cells["LoadPlanHelpers"].Value.ToString());
                        linedata.Rows[j]["OBtargetpercent"] = (int)float.Parse(dataGridView1.Rows[i].Cells["OBTarget"].Value.ToString());
                        linedata.Rows[j]["OBHour"] = 8;
                        linedata.Rows[j]["ObOperators"] = (int)float.Parse(dataGridView1.Rows[i].Cells["OBOperators"].Value.ToString());
                        linedata.Rows[j]["OBHelpers"] = (int)float.Parse(dataGridView1.Rows[i].Cells["OBHelpers"].Value.ToString());
                        linedata.Rows[j]["pcsperMachine"] = float.Parse(dataGridView1.Rows[i].Cells["PCS/MA"].Value.ToString());

                        float OBhelperOperatorratio = (float.Parse(linedata.Rows[j]["OBHelpers"].ToString()) / float.Parse(linedata.Rows[j]["ObOperators"].ToString())) * 100;
                        float LanPlanhelperOperatorratio = (float.Parse(linedata.Rows[j]["PlannedHelpers"].ToString()) / float.Parse(linedata.Rows[j]["PlannedOperators"].ToString())) * 100;


                        if (linedata.Rows[j]["DayofWeek"].ToString().Trim() == "Saturday")
                        {
                            if (dataGridView1.Rows[i].Cells["TotalHours"].Value.ToString().Trim() == "")
                            {
                                linedata.Rows[j]["Planhours"] = 0;
                                linedata.Rows[j]["OBHour"] = 0;
                                dataGridView1.Rows[i].Appearance.BackColor = Color.Red;
                                linedata.Rows[j]["pcsperMachine"] = 0;
                            }
                            else
                            {

                                String satdayhour = geSaturdayDayduration(dataGridView1.Rows[i].Cells["TotalHours"].Value.ToString());
                                linedata.Rows[j]["Planhours"] = satdayhour;
                                linedata.Rows[j]["OBHour"] = 5;
                                linedata.Rows[j]["pcsperMachine"] = (float.Parse(linedata.Rows[j]["pcsperMachine"].ToString()) / 8) * 5;

                            }
                        }
                        else if (linedata.Rows[j]["DayofWeek"].ToString().Trim() == "Sunday")
                        {
                            linedata.Rows[j]["Planhours"] = '0';
                            linedata.Rows[j]["OBHour"] = 0;

                        }
                        else
                        {
                            if (dataGridView1.Rows[i].Cells["TotalHours"].Value.ToString().Trim() == "")
                            {
                                dataGridView1.Rows[i].Appearance.BackColor = Color.Red;
                                linedata.Rows[j]["Planhours"] = 0;
                            }
                            else
                            {
                                String normalhour = getnormalDayduration(dataGridView1.Rows[i].Cells["TotalHours"].Value.ToString());
                                linedata.Rows[j]["Planhours"] = normalhour;
                            }
                        }




                        linedata.Rows[j]["OBHelpertoOperator"] = OBhelperOperatorratio;
                        linedata.Rows[j]["LinePlanHelpertoOperator"] = LanPlanhelperOperatorratio;
                        linedata.Rows[j]["TotalHourWorked"] = float.Parse(linedata.Rows[j]["PlannedOperators"].ToString()) * float.Parse(linedata.Rows[j]["Planhours"].ToString());
                        
                        float expectedSumm = 0;
                        float expectedhroperator = 0;

                        if (OBhelperOperatorratio >= LanPlanhelperOperatorratio)
                        {
                            expectedSumm = float.Parse(linedata.Rows[j]["PlannedOperators"].ToString()) * float.Parse(linedata.Rows[j]["pcsperMachine"].ToString());
                            expectedhroperator = float.Parse(linedata.Rows[j]["PlannedOperators"].ToString());
                            linedata.Rows[j]["IsPlannedRatioGreater"] = "False";
                        }
                        else
                        {
                            float partialexpected = float.Parse(linedata.Rows[j]["PlannedOperators"].ToString()) * float.Parse(linedata.Rows[j]["pcsperMachine"].ToString());

                            float expectedhlpr = (float.Parse(linedata.Rows[j]["PlannedOperators"].ToString()) * OBhelperOperatorratio) / 100;
                         
                            float extrahlpr = float.Parse(linedata.Rows[j]["PlannedOperators"].ToString()) + expectedhlpr;
                            expectedhroperator = extrahlpr;
                            expectedSumm = extrahlpr * float.Parse(linedata.Rows[j]["pcsperMachine"].ToString());
                            expectedSumm = (partialexpected / expectedhroperator) * (float.Parse(dataGridView1.Rows[i].Cells["LoadPlanHelpers"].Value.ToString())+ float.Parse(dataGridView1.Rows[i].Cells["LoadPlanOperator"].Value.ToString()));
                            linedata.Rows[j]["IsPlannedRatioGreater"] = "True";
                            dataGridView1.Rows[i].Appearance.BackColor = Color.Yellow;
                        }
                        linedata.Rows[j]["targetBasedon8by5"] = expectedSumm;
                        linedata.Rows[j]["LineplanAllowednampower"] = expectedhroperator;
                      
                        //float get100percent = getHundredpercent(float.Parse(dataGridView1.Rows[i].Cells["OBTARget"].Value.ToString()), float.Parse(linedata.Rows[j]["ObOperators"].ToString()), float.Parse(linedata.Rows[j]["OBHelpers"].ToString()),
                        //    float.Parse(linedata.Rows[j]["PlannedOperators"].ToString()), float.Parse(linedata.Rows[j]["PlannedOHelpers"].ToString()), float.Parse(linedata.Rows[j]["OBHour"].ToString()), float.Parse(linedata.Rows[j]["Planhours"].ToString()));

                        float get100percent = getnewHundredpercent(float.Parse(linedata.Rows[j]["targetBasedon8by5"].ToString()), float.Parse(linedata.Rows[j]["OBHour"].ToString()), float.Parse(linedata.Rows[j]["Planhours"].ToString()));
                        
                        float fcmefficencyBE = float.Parse(dataGridView1.Rows[i].Cells["BreakEvenFcmEfficiency"].Value.ToString());
                        float percent = getpercent(get100percent, float.Parse(linedata.Rows[j]["TargetQty"].ToString()));
                        float whatshouldbeactual = WhatShouldbeactual(get100percent, fcmefficencyBE);
                        linedata.Rows[j]["WhatSholudbe100percent"] = get100percent;
                        linedata.Rows[j]["percentWeighted"] =( percent * float.Parse(linedata.Rows[j]["TargetQty"].ToString()))/100;
                        linedata.Rows[j]["actualPercent"] = percent;
                        linedata.Rows[j]["WhatShouldbeActualQty"] = whatshouldbeactual;
                        
                    }
                }



                try
                {
                    object Sumtarget;
                    object sumof100percent;
                    object sumof100percentforweighetd;
                    object sumofactual;
                    object sumofhoursworked;
                    object OBHelpertoOperatorRatio;
                    object LPHelpertoOperatorRatio;
                    object sumplanhours;
                    object daysplanned;
                    Sumtarget = linedata.Compute("Sum(TargetQty)", "");
                    sumof100percentforweighetd = linedata.Compute("Sum(WhatSholudbe100percent)", "");
                    sumof100percent = linedata.Compute("Sum(percentWeighted)", "");
                    sumofactual = linedata.Compute("Sum(WhatShouldbeActualQty)", "");
                    sumofhoursworked = linedata.Compute("Sum(TotalHourWorked)", "");
                    OBHelpertoOperatorRatio = linedata.Compute("Avg(OBHelpertoOperator)", "");
                    LPHelpertoOperatorRatio = linedata.Compute("Avg(LinePlanHelpertoOperator)","");
                    sumplanhours = linedata.Compute("Sum(PlanHours)", "");
                    daysplanned=linedata.Compute("Count(PlanHours)", "");
                    float sewingfcm = float.Parse(dataGridView1.Rows[i].Cells["SewingFcm"].Value.ToString());
                    float finishingfcm = float.Parse(dataGridView1.Rows[i].Cells["FinishingFcm"].Value.ToString());
                    float prcent = 0;

                    if (Double.IsInfinity(float.Parse(Sumtarget.ToString()) / float.Parse(sumof100percent.ToString())))
                    {
                        prcent = 0;
                    }
                    else
                    {
                     //   prcent = (float.Parse(sumof100percent.ToString()) / float.Parse(Sumtarget.ToString())) * 100;
                        prcent = (float.Parse(Sumtarget.ToString()) / float.Parse(sumof100percentforweighetd.ToString())) * 100;

                    }


                    if (int.Parse(dataGridView1.Rows[i].Cells["TotalQty"].Value.ToString()) != Convert.ToInt32(Sumtarget))
                    {
                        // dataGridView1.Rows[i].Cells["TotalQty"].Style.BackColor=Color.Green;
                    }
                    dataGridView1.Rows[i].Cells["TotalQty"].Value = Convert.ToInt32(Sumtarget);
                    dataGridView1.Rows[i].Cells["SewingQtyrequired"].Value = Convert.ToInt32(sumofactual);
                    dataGridView1.Rows[i].Cells["percentOB"].Value = Convert.ToInt32(prcent);
                  float dolorvalue = Convert.ToInt32(Sumtarget) * (sewingfcm / 12);
                    dataGridView1.Rows[i].Cells["Dollarvalue"].Value = dolorvalue;
                    float Dollorvaluerequired = float.Parse(sumofactual.ToString()) * (sewingfcm / 12);

                //    float finalDollorrequired = Dollorvaluerequired * (finishingfcm / dolorvalue);
                    float finalDollorrequired = Convert.ToInt32(sumofactual) * (finishingfcm / 12);

                    dataGridView1.Rows[i].Cells["Dollorvaluerequired"].Value = Math.Truncate(Dollorvaluerequired);
                    dataGridView1.Rows[i].Cells["FinishingQtyRecieved"].Value = Convert.ToInt32(sumofactual);
                    dataGridView1.Rows[i].Cells["finisheddollorrequired"].Value = Math.Truncate(finalDollorrequired);
                    
                  

                    if (int.Parse(dataGridView1.Rows[i].Cells["percentOB"].Value.ToString()) > int.Parse( Math.Truncate( float.Parse ( dataGridView1.Rows[i].Cells["ObPercentageRequired"].Value.ToString ())).ToString()))
                    {
                        dataGridView1.Rows[i].Cells["Is LOad Plan Qty Accepted"].Value = "Yes";
                        dataGridView1.Rows[i].Cells["sew qty rqd"].Value = dataGridView1.Rows[i].Cells["TotalQty"].Value;
                        dataGridView1.Rows[i].Cells["fin Qty rqd"].Value = dataGridView1.Rows[i].Cells["TotalQty"].Value;
                        dataGridView1.Rows[i].Cells["Eff rqd"].Value =float.Parse ( dataGridView1.Rows[i].Cells["percentOB"].Value.ToString ());
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["Is LOad Plan Qty Accepted"].Value = "No";
                        dataGridView1.Rows[i].Cells["sew qty rqd"].Value = dataGridView1.Rows[i].Cells["SewingQtyrequired"].Value;
                        dataGridView1.Rows[i].Cells["fin Qty rqd"].Value = dataGridView1.Rows[i].Cells["SewingQtyrequired"].Value;
                        dataGridView1.Rows[i].Cells["Eff rqd"].Value = float.Parse(dataGridView1.Rows[i].Cells["ObPercentageRequired"].Value.ToString());
                    }
                   //  0000 AS [Avg OBHelpertoOpr Ratio], 0000 AS [Avg LPHelpertoOpr Ratio], 0000 AS [What is 100% Qty]
                    dataGridView1.Rows[i].Cells["Avg OBHelpertoOpr Ratio"].Value = float.Parse ( OBHelpertoOperatorRatio.ToString ());
                    dataGridView1.Rows[i].Cells["Avg LPHelpertoOpr Ratio"].Value = float.Parse(LPHelpertoOperatorRatio.ToString());
                    dataGridView1.Rows[i].Cells["What is 100% Qty"].Value = float.Parse(sumof100percentforweighetd.ToString());
                  


                    float sewqty = (float.Parse(dataGridView1.Rows[i].Cells["sew qty rqd"].Value.ToString()) / 12) * float.Parse(dataGridView1.Rows[i].Cells["SewingFcm"].Value.ToString());
                    dataGridView1.Rows[i].Cells["Sew Val rqd"].Value = sewqty;
                    float finvalequired = (float.Parse(dataGridView1.Rows[i].Cells["fin Qty rqd"].Value.ToString()) / 12) * float.Parse(dataGridView1.Rows[i].Cells["FinishingFcm"].Value.ToString());
                    dataGridView1.Rows[i].Cells["fin Value rqd"].Value = finvalequired;
                    dataGridView1.Rows[i].Cells["Total CM Value"].Value = finvalequired+sewqty;

                    dataGridView1.Rows[i].Cells["Total Hours Planned"].Value = float.Parse ( sumofhoursworked.ToString ());
                    dataGridView1.Rows[i].Cells["Load  Plan Hours"].Value = float.Parse(sumplanhours.ToString());

                    float operatorsplanned = 0;
                    operatorsplanned = float.Parse(sumofhoursworked.ToString()) / float.Parse(sumplanhours.ToString());
                    dataGridView1.Rows[i].Cells["Operators Planned"].Value = float.Parse(operatorsplanned.ToString());
                      dataGridView1.Rows[i].Cells["Days Planned"].Value = float.Parse(daysplanned.ToString());
                      dataGridView1.Rows[i].Cells["Days in Period"].Value = ((dtp_to.Value.Date - dtp_from .Value.Date).TotalDays+1)-int.Parse (label3.Text );

                    dataGridView1.Rows[i].Cells["Per Machine Revenue"].Value = (finvalequired + sewqty) / (float.Parse(dataGridView1.Rows[i].Cells["Total Hours Planned"].Value.ToString()) / 8);
                     
                }
                catch (Exception ex)
                {
                    dataGridView1.Rows[i].Appearance.BackColor = Color.Green ;
                  
                }
                if (newdata.Rows.Count <= 0)
                {
                    newdata = linedata.Clone();

                }
                foreach (DataRow dr in linedata.Rows)
                {

                    newdata.Rows.Add(dr.ItemArray);
                }
            }
        }


        static int CountDays(DayOfWeek day, DateTime start, DateTime end)
        {
            TimeSpan ts = end - start;                       // Total duration
            int count = (int)Math.Floor(ts.TotalDays / 7);   // Number of whole weeks
            int remainder = (int)(ts.TotalDays % 7);         // Number of remaining days
            int sinceLastDay = (int)(end.DayOfWeek - day);   // Number of days since last [day]
            if (sinceLastDay < 0) sinceLastDay += 7;         // Adjust for negative days since last [day]

            // If the days in excess of an even week are greater than or equal to the number days since the last [day], then count this one, too.
            if (remainder >= sinceLastDay) count++;

            return count;
        }

 public float getnewHundredpercent(float new100percernt, float obhours,float planhours)
        {
            float k1 = 0;
            k1 = (new100percernt / obhours) * planhours;
            return k1;
        }

        public float getpercent(float WhatSholudbe100percent, float target)
        {
            float k1 = 0;
            k1 = (target / WhatSholudbe100percent) * 100;
            return k1;
        }

        public float getHundredpercent(float OBTarget, float OBOperator, float OBOHelper, float PlanOperator, float PlanHelper, float OBhours, float PlanHours)
        {
            float k1 = 0;
            k1 = (((OBTarget / (OBOperator + OBOHelper)) * (PlanOperator + PlanHelper)) / OBhours) * PlanHours;
            return k1;
        }
        public float WhatShouldbeactual(float WhatSholudbe100percentt, float efficencyfcmpercent)
        {
            float k1 = 0;
            k1 = (WhatSholudbe100percentt * efficencyfcmpercent) / 100;
            return k1;
        }


        public String getnormalDayduration(String Hours)
        {

            String[] result;
            char[] commaSeparator = new char[] { '/' };
            result = Hours.Split(commaSeparator, StringSplitOptions.None);

            return result[0].ToString();


        }
        public String geSaturdayDayduration(String Hours)
        {
            String[] result;
            char[] commaSeparator = new char[] { '/' };
            result = Hours.Split(commaSeparator, StringSplitOptions.None);

            return result[1].ToString();
        }

        private void projectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (factorycombo.Text.Trim() != "")
            {

                label3.Text = CountDays(DayOfWeek.Sunday, dtp_from.Value.Date, dtp_to.Value.Date).ToString();
                DataTable dt = rpttran.Projectiondata(dtp_from.Value.Date, dtp_to.Value.Date,int.Parse (factorycombo.SelectedValue.ToString ()));
                //dt = dt.Select("LineID=10189").CopyToDataTable();
                //dt = dt.Select("Atcnum='KO2096'").CopyToDataTable();
                foreach (DataColumn clmn in dt.Columns)
                {
                    clmn.ReadOnly = false;
                }
                foreach (DataColumn clmn1 in newdata.Columns)
                {
                    clmn1.ReadOnly = false;
                }
                //  dt = dt.Select("atcnum='KO2063'").CopyToDataTable();
                newdata.Clear();
                dataGridView1.DataSource = dt;
                dataGridView1.Text = "Projection Data";
                ShipitControls.ControlSetupper.UltraGridNormalSetup(dataGridView1);
                getlinewiseob();
                gridviewsetup();

                label3.Text = CountDays(DayOfWeek.Sunday, dtp_from.Value.Date, dtp_to.Value.Date).ToString();
            }
        }

        public void gridviewsetup()
        {
            UltraGridBand band = dataGridView1.DisplayLayout.Bands[0];
            band.Columns["Atcnum"].Header.Caption = "ATC#";
            band.Columns["SewingFcm"].Header.Caption = "Sewing CM";
            band.Columns["FinishingFcm"].Header.Caption = "Finishing CM";
            band.Columns["PCS/MA"].Header.Caption = "OB PCS/MA";
            band.Columns["BreakEvenFcmEfficiency"].Hidden = true;

            band.Columns["LoadPlanHelpers"].Header.Caption = "LoadPlan HLPR";
            band.Columns["LoadPlanOperator"].Header.Caption = "LoadPlan OPTR";
            band.Columns["Linecapacity"].Header.Caption = "LoadPlan Line CAP";
            band.Columns["percentOB"].Header.Caption = "LoadPlan eff%";
            band.Columns["TotalQty"].Header.Caption = "LoadPlan Total Qty";

               band.Columns["ObPercentageRequired"].Header.Caption = "B/E eff%";
            band.Columns["SewingQtyrequired"].Header.Caption = "B/E Sewing Qty Rqd";
            band.Columns["Dollorvaluerequired"].Header.Caption = "B/E Sewing Value Rqd ";
            band.Columns["FinishingQtyRecieved"].Header.Caption = "B/E Finishing Qty Rqd";
            band.Columns["finisheddollorrequired"].Header.Caption = "B/E Finishing Value Rqd";
            band.Columns["TotalHours"].Header.Caption = "LoadPlan Hours";
            band.Columns["Dollarvalue"].Header.Caption = "LoadPlan Sewing Value";

            band.Columns["Operators Planned"].Hidden = true;
            band.Columns["Load  Plan Hours"].Hidden = true;
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Title = "Save an Excel File";
            saveFileDialog1.Filter = "Excel|*.xls|Excel 2010|*.xlsx";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                this.ultraGridExcelExporter1.Export(this.dataGridView1 , saveFileDialog1.FileName);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int lineid = int.Parse(dataGridView1.Rows[dataGridView1.ActiveRow.Index].Cells["Lineid"].Value.ToString());
            //String atcnum = dataGridView1.Rows[dataGridView1.ActiveRow.Index].Cells["Atcnum"].Value.ToString();
            //DataTable temdat = newdata.Select("atcnum='" + atcnum + "' and  lineid=" + lineid + "").CopyToDataTable();
            String OurStyle = dataGridView1.Rows[dataGridView1.ActiveRow.Index].Cells["OurStyle"].Value.ToString();
            DataTable temdat = newdata.Select("OurStyle='" + OurStyle + "' and  lineid=" + lineid + "").CopyToDataTable();

            CM.Dataform frm = new CM.Dataform(temdat);
            frm.Show();
        }

       

        private void dataGridView1_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            int lineid = int.Parse(dataGridView1.Rows[dataGridView1.ActiveRow.Index].Cells["Lineid"].Value.ToString());
            //String atcnum = dataGridView1.Rows[dataGridView1.ActiveRow.Index].Cells["Atcnum"].Value.ToString();
            //DataTable temdat = newdata.Select("atcnum='" + atcnum + "' and  lineid=" + lineid + "").CopyToDataTable();
            String OurStyle = dataGridView1.Rows[dataGridView1.ActiveRow.Index].Cells["OurStyle"].Value.ToString();
            DataTable temdat = newdata.Select("OurStyle='" + OurStyle + "' and  lineid=" + lineid + "").CopyToDataTable();
            CM.Dataform frm = new CM.Dataform(temdat);
            frm.Show();
        }

        private void dataGridView1_CellChange(object sender, CellEventArgs e)
        {
            UltraGrid ug = sender as UltraGrid;

            ug.ActiveRow.Update();
            ug.PerformAction(UltraGridAction.ExitEditMode);
        }

        private void exportToPDFToolStripMenuItem_Click(object sender, EventArgs e)
        { SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Title = "Save an Excel File";
           // saveFileDialog1.Filter = "Excel|*.xls|Excel 2010|*.xlsx";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                this.ultraGridDocumentExporter1.Export(
                    this.dataGridView1, saveFileDialog1.FileName,
                    Infragistics.Win.UltraWinGrid.DocumentExport.GridExportFileFormat.PDF);

               
            }
           
        }

        private void approveProjectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CM.ApproveProjection appr = new CM.ApproveProjection(dataGridView1,dtp_from.Value.Date,dtp_to.Value.Date,factorycombo.Text.Trim ());
            appr.ShowDialog();
        }
    }
}
