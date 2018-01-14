using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.CM
{
    public partial class ApproveProjection : Form
    {
        DateTime projfromdate = DateTime.Now;
        DateTime projtodate = DateTime.Now;
        String projFactory = "";
        public ApproveProjection(UltraGrid ultraGrid1, DateTime fromdate, DateTime todate,String factory)
        {
            InitializeComponent();
            DataTable DT = (DataTable)(ultraGrid1.DataSource);

            updategrid(DT);
            projfromdate = fromdate;
            projtodate = todate;
            projFactory = factory;
        }

        public void updategrid(DataTable dt)
        {
            dataGridView1.DataSource = dt;
            dataGridView1.Text = "Approved Projection";
        }





        public String  createProjcode()
        {
            String mm = projtodate.ToString("MMMM");
            string year = projtodate.Year.ToString();
            mm = "Proj-" + projFactory +"-"+mm + "-" + year;


            using (CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr))
            {
                var q = from proj in cntxt.ApprovedProj_tbls
                        where proj.Projnum == mm 
                        select proj;
                foreach (var detail in q)
                {
                    cntxt.ApprovedProj_tbls.DeleteOnSubmit(detail);
                }

                try
                {
                    cntxt.SubmitChanges();
                }
                catch (Exception)
                {


                }
            }



            return mm;
        }



        private void approveProjectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String asd = createProjcode();
            for(int i=0;i<dataGridView1.Rows.Count ;i++)
            {
                using (CourierDataDataContext cntxt= new CourierDataDataContext (Program.ConnStr ))
                {
                    ApprovedProj_tbl apptbl = new ApprovedProj_tbl();
                    apptbl.LineID= int.Parse (dataGridView1.Rows[i].Cells[0].Value.ToString ());
                      apptbl.Factoryname= dataGridView1.Rows[i].Cells[1].Value.ToString ();
                      apptbl.Projnum = asd;
                    
                      apptbl.Linenum= dataGridView1.Rows[i].Cells[2].Value.ToString ();
                      apptbl.Atcnum= dataGridView1.Rows[i].Cells[3].Value.ToString ();
                    apptbl.OurStyle= dataGridView1.Rows[i].Cells[4].Value.ToString();
                    apptbl.SewingFcm = float.Parse (dataGridView1.Rows[i].Cells[5].Value.ToString ());
                      apptbl.FinishingFcm = float.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                      apptbl.BreakEvenFcmEfficiency = float.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                      apptbl.ObOperator = float.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                      apptbl.ObHelper = float.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
                      apptbl.ObTarget = float.Parse(dataGridView1.Rows[i].Cells[10].Value.ToString());
                      apptbl.PcPermac = float.Parse(dataGridView1.Rows[i].Cells[11].Value.ToString());
                      apptbl.LoadPlanOperator = float.Parse(dataGridView1.Rows[i].Cells[12].Value.ToString());
                      apptbl.LoadfPlanHelper = float.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
                      apptbl.AvgObHlprtoOprRatio = float.Parse(dataGridView1.Rows[i].Cells[14].Value.ToString());
                      apptbl.AvgLphlprtohlprratio = float.Parse(dataGridView1.Rows[i].Cells[15].Value.ToString());
                      apptbl.Expected100percent = float.Parse(dataGridView1.Rows[i].Cells[16].Value.ToString());
                      apptbl.LineCapacity = float.Parse(dataGridView1.Rows[i].Cells[17].Value.ToString());
                      apptbl.TotalQty = float.Parse(dataGridView1.Rows[i].Cells[18].Value.ToString());
                      apptbl.PercentOB = float.Parse(dataGridView1.Rows[i].Cells[19].Value.ToString());
                      apptbl.DolorValue = float.Parse(dataGridView1.Rows[i].Cells[20].Value.ToString());

                      apptbl.SewingQtyrequired = float.Parse(dataGridView1.Rows[i].Cells[21].Value.ToString());
                      apptbl.OBPercentageRequired = float.Parse(dataGridView1.Rows[i].Cells[22].Value.ToString());
                      apptbl.Dollorvaluereqd = float.Parse(dataGridView1.Rows[i].Cells[23].Value.ToString());
                      apptbl.finishingQtyrecieved = float.Parse(dataGridView1.Rows[i].Cells[24].Value.ToString());
                      apptbl.FinishingDollorRequired = float.Parse(dataGridView1.Rows[i].Cells[25].Value.ToString());
                      apptbl.TotalHours = dataGridView1.Rows[i].Cells[26].Value.ToString();
                      apptbl.IsLoadPlanQtyAccepted= dataGridView1.Rows[i].Cells[27].Value.ToString ();
                      apptbl.SewingQtyReqd = float.Parse(dataGridView1.Rows[i].Cells[28].Value.ToString());
                      apptbl.EffRqd = float.Parse(dataGridView1.Rows[i].Cells[29].Value.ToString());

                      apptbl.SewingValRqd = float.Parse(dataGridView1.Rows[i].Cells[30].Value.ToString());
                      apptbl.FinishingQtyrequired = float.Parse(dataGridView1.Rows[i].Cells[31].Value.ToString());
                      apptbl.FinishingValueRequired = float.Parse(dataGridView1.Rows[i].Cells[32].Value.ToString());
                      apptbl.TotalCMvalue = float.Parse(dataGridView1.Rows[i].Cells[33].Value.ToString());

                      apptbl.LoadPlanHours = float.Parse(dataGridView1.Rows[i].Cells[34].Value.ToString());
                      apptbl.DayPlanned = float.Parse(dataGridView1.Rows[i].Cells[35].Value.ToString());
                      apptbl.DaysinPeriod = float.Parse(dataGridView1.Rows[i].Cells[36].Value.ToString());
                      apptbl.TotalHoursPlanned = float.Parse(dataGridView1.Rows[i].Cells[37].Value.ToString());
                      apptbl.AddedBy = Program.uername;
                      apptbl.AddedDate = DateTime.Now.Date;
                      apptbl.IsActive = "Y";
                      apptbl.Fromdate = projfromdate;
                      apptbl.Todate = projfromdate;
                      apptbl.OperatorpPlanned = float.Parse(dataGridView1.Rows[i].Cells[38].Value.ToString());
                      apptbl.Permachinerevenue = float.Parse(dataGridView1.Rows[i].Cells[39].Value.ToString());
                   
                      cntxt.ApprovedProj_tbls.InsertOnSubmit(apptbl);
                      cntxt.SubmitChanges();
                }
              
            }
            MessageBox.Show("Approved Projection is " + asd + "");
        }

        private void exportToPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
