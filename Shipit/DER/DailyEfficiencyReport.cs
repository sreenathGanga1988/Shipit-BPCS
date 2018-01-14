using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit
{
    public partial class DailyEfficiencyReport : Form
    {
        Transaction.ReportTransaction rpttran = null;
        Transaction.DataExporter DTPEXPTR = null;
        DataTable newdata = new DataTable();
        public DailyEfficiencyReport()
        {
            InitializeComponent();
            rpttran = new Transaction.ReportTransaction();
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Title = "Save an Excel File";
            saveFileDialog1.Filter = "Excel|*.xls|Excel 2010|*.xlsx";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                this.ultraGridExcelExporter1.Export(this.dataGridView1, saveFileDialog1.FileName);
            }
        }

        private void dailyEfficencyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = rpttran.GetDERData(dtp_from.Value.Date, dtp_to.Value.Date);
            foreach (DataColumn clmn in dt.Columns)
            {
                clmn.ReadOnly = false;
            }
            //  dt = dt.Select("atcnum='KO2063'").CopyToDataTable();
            dataGridView1.DataSource = dt;
            dataGridView1.Text = "Daily Efficiency Report";
            ShipitControls.ControlSetupper.UltraGridNormalSetup(dataGridView1);
            getlinewiseob();
            //  gridviewsetup();
        }

        public void getlinewiseob()
        {


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                try
                {


                    if (dataGridView1.Rows[i].Cells["DayofWeek"].Value.ToString().Trim() == "Saturday")
                    {
                        dataGridView1.Rows[i].Cells["ObHours"].Value = 5;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["ObHours"].Value = 8;
                    }



                    float totaloboperator = float.Parse(dataGridView1.Rows[i].Cells["OBOperators"].Value.ToString()) + float.Parse(dataGridView1.Rows[i].Cells["OBHelpers"].Value.ToString());
                    float ActualOperatorsAndHelper = float.Parse(dataGridView1.Rows[i].Cells["ActualOperator"].Value.ToString()) + float.Parse(dataGridView1.Rows[i].Cells["ActualHelpers"].Value.ToString());

                    float obtarget = float.Parse(dataGridView1.Rows[i].Cells["OBTarget"].Value.ToString());

                    float OBhelperOperatorratio = (float.Parse(dataGridView1.Rows[i].Cells["OBHelpers"].Value.ToString()) / float.Parse(dataGridView1.Rows[i].Cells["OBOperators"].Value.ToString())) * 100;

                    float ActulPlanhelperOperatorratio = (float.Parse(dataGridView1.Rows[i].Cells["ActualHelpers"].Value.ToString()) / float.Parse(dataGridView1.Rows[i].Cells["ActualOperator"].Value.ToString()) * 100);
                    if (ActulPlanhelperOperatorratio > 0)
                    {

                    }
                    else
                    {
                        ActulPlanhelperOperatorratio = 0;
                    }
                    dataGridView1.Rows[i].Cells["OB Helper Ratio"].Value = OBhelperOperatorratio;
                    dataGridView1.Rows[i].Cells["Actual Helper Ratio"].Value = ActulPlanhelperOperatorratio;
                    float expectedSumm = 0;
                    float expectedhroperator = 0;
                    if (OBhelperOperatorratio >= ActulPlanhelperOperatorratio)
                    {
                        expectedSumm = float.Parse(dataGridView1.Rows[i].Cells["ActualOperator"].Value.ToString()) * float.Parse(dataGridView1.Rows[i].Cells["PCS/MA"].Value.ToString());
                        expectedhroperator = float.Parse(dataGridView1.Rows[i].Cells["ActualOperator"].Value.ToString());
                        dataGridView1.Rows[i].Cells["IsPlannedRatioGreater"].Value = "False";
                    }
                    else
                    {
                        float partialexpected = float.Parse(dataGridView1.Rows[i].Cells["ActualOperator"].Value.ToString()) * float.Parse(dataGridView1.Rows[i].Cells["PCS/MA"].Value.ToString());

                        float expectedhlpr = (float.Parse(dataGridView1.Rows[i].Cells["ActualOperator"].Value.ToString()) * OBhelperOperatorratio) / 100;

                        float extrahlpr = float.Parse(dataGridView1.Rows[i].Cells["ActualOperator"].Value.ToString()) + expectedhlpr;
                        expectedhroperator = extrahlpr;
                        expectedSumm = extrahlpr * float.Parse(dataGridView1.Rows[i].Cells["PCS/MA"].Value.ToString());
                        expectedSumm = (partialexpected / expectedhroperator) * (float.Parse(dataGridView1.Rows[i].Cells["ActualOperator"].Value.ToString()) + float.Parse(dataGridView1.Rows[i].Cells["ActualHelpers"].Value.ToString()));
                        dataGridView1.Rows[i].Cells["IsPlannedRatioGreater"].Value = "True";
                        dataGridView1.Rows[i].Appearance.BackColor = Color.Yellow;

                    }
                    try
                    {
                        if (ActualOperatorsAndHelper > 0)
                        {
                            dataGridView1.Rows[i].Cells["TargetBasedon8by5"].Value = expectedSumm;
                            dataGridView1.Rows[i].Cells["Expected Hr"].Value = expectedhroperator;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells["TargetBasedon8by5"].Value = 0;
                            dataGridView1.Rows[i].Cells["Expected Hr"].Value = 0;
                        }
                    }
                    catch (Exception)
                    {

                        dataGridView1.Rows[i].Cells["TargetBasedon8by5"].Value = 0;
                        dataGridView1.Rows[i].Cells["Expected Hr"].Value = 0;
                    }

                    float get100percent = getnewHundredpercent(float.Parse(dataGridView1.Rows[i].Cells["TargetBasedon8by5"].Value.ToString()), float.Parse(dataGridView1.Rows[i].Cells["ObHours"].Value.ToString()), float.Parse(dataGridView1.Rows[i].Cells["OTHOurs"].Value.ToString()), ActualOperatorsAndHelper);


                    //  dataGridView1.Rows[i].Cells["actual100"].Value = get100percent;
                    float ifnormalhourtotalexpected = (obtarget / totaloboperator) * ActualOperatorsAndHelper;
                    //  float actual100 = (ifnormalhourtotalexpected / float.Parse(dataGridView1.Rows[i].Cells["Obhours"].Value.ToString())) * (float.Parse(dataGridView1.Rows[i].Cells["Obhours"].Value.ToString()) + float.Parse(dataGridView1.Rows[i].Cells["OTHOurs"].Value.ToString()));

                    if (get100percent >= 0)
                    {
                        dataGridView1.Rows[i].Cells["actual100"].Value = get100percent;
                        dataGridView1.Rows[i].Cells["Expected100"].Value = get100percent;
                        dataGridView1.Rows[i].Cells["ProducedPercent"].Value = (float.Parse(dataGridView1.Rows[i].Cells["TotalQty"].Value.ToString()) / get100percent) * 100;
                        //dataGridView1.Rows[i].Cells["BDqty"].Value = get100percent - float.Parse(dataGridView1.Rows[i].Cells["TotalQty"].Value.ToString());

                        dataGridView1.Rows[i].Cells["BEPercentOB"].Value = float.Parse(dataGridView1.Rows[i].Cells["BreakEvenFcmEfficiency"].Value.ToString());

                        dataGridView1.Rows[i].Cells["BETarget"].Value = (get100percent / 100) * float.Parse(dataGridView1.Rows[i].Cells["BreakEvenFcmEfficiency"].Value.ToString());

                        //dataGridView1.Rows[i].Cells["BDqty"].Value = float.Parse(dataGridView1.Rows[i].Cells["BreakEvenFcmTarget"].Value.ToString()) - float.Parse(dataGridView1.Rows[i].Cells["TotalQty"].Value.ToString());

                        dataGridView1.Rows[i].Cells["BDqty"].Value = float.Parse(dataGridView1.Rows[i].Cells["BETarget"].Value.ToString()) - float.Parse(dataGridView1.Rows[i].Cells["TotalQty"].Value.ToString());

                        dataGridView1.Rows[i].Cells["BDDollor"].Value = (float.Parse(dataGridView1.Rows[i].Cells["BDqty"].Value.ToString()) / 12) * float.Parse(dataGridView1.Rows[i].Cells["SewingFcm"].Value.ToString());


                        dataGridView1.Rows[i].Cells["BDPercent"].Value = (float.Parse(dataGridView1.Rows[i].Cells["BDqty"].Value.ToString()) / get100percent) * 100;

                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["BEPercentOB"].Value = 0;
                        dataGridView1.Rows[i].Cells["actual100"].Value = 0;
                        dataGridView1.Rows[i].Cells["Expected100"].Value = 0;
                        dataGridView1.Rows[i].Cells["ProducedPercent"].Value = 0;
                        dataGridView1.Rows[i].Cells["BDqty"].Value = 0;
                        dataGridView1.Rows[i].Cells["BDDollor"].Value = 0;
                    }
                }
                catch (Exception)
                {
                    dataGridView1.Rows[i].Appearance.BackColor = Color.Green;

                }
            }


        }


        public float getnewHundredpercent(float new100percernt, float obhours, float Othours, float actualoperator)
        {
            float k1 = 0;
            k1 = (new100percernt / (actualoperator * obhours)) * ((actualoperator * obhours) + Othours);
            return k1;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataTable dt = (DataTable)dataGridView1.DataSource;
            DataView dw = new DataView(dt);
            DataTable temp = dw.ToTable(true, "Atcnum", "OurStyle", "Linenum", "Factory_name", "DateOfProd", "TotalQty", "ProducedPercent", "BDqty", "BDDollor", "BDPercent", "Expected100", "BEPercentOB");

            rpttran.DeleteDER();

            using (CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr))
            {



                for (int i = 0; i < temp.Rows.Count; i++)
                {

                    DER_TEMP mstr = new DER_TEMP();
                    mstr.Atcnum = dt.Rows[i]["Atcnum"].ToString();
                    mstr.OurStyle = dt.Rows[i]["OurStyle"].ToString();
                    mstr.Linenum = dt.Rows[i]["Linenum"].ToString();
                    mstr.Factory_name = dt.Rows[i]["Factory_name"].ToString();
                    mstr.DateOfProd = DateTime.Parse(dt.Rows[i]["DateOfProd"].ToString());
                    mstr.TotalQty = float.Parse(dt.Rows[i]["TotalQty"].ToString());
                    mstr.ProducedPercent = float.Parse(dt.Rows[i]["ProducedPercent"].ToString());
                    mstr.BDqty = float.Parse(dt.Rows[i]["BDqty"].ToString());
                    mstr.BDDollor = float.Parse(dt.Rows[i]["BDDollor"].ToString());
                    mstr.BDPercent = float.Parse(dt.Rows[i]["BDPercent"].ToString());
                    mstr.TargetProduction = float.Parse(dt.Rows[i]["Expected100"].ToString());
                    mstr.BEpercentOB = float.Parse(dt.Rows[i]["BEPercentOB"].ToString());
                    courdatacontext.DER_TEMPs.InsertOnSubmit(mstr);



                }
                courdatacontext.SubmitChanges();
            }
            CM.Rdlcreport.DerReportform frm = new CM.Rdlcreport.DerReportform(temp);
            frm.Show();


        }

        private void exportToPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showDERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = rpttran.getSavedDerwithvalue(dtp_from.Value.Date, dtp_to.Value.Date);
            foreach (DataColumn clmn in dt.Columns)
            {
                clmn.ReadOnly = false;
            }
            //  dt = dt.Select("atcnum='KO2063'").CopyToDataTable();
            dataGridView1.DataSource = dt;
            dataGridView1.Text = "Daily Efficiency Report";
            ShipitControls.ControlSetupper.UltraGridNormalSetup(dataGridView1);
            
        }
    }
}
