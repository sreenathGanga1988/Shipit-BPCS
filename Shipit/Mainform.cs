using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shipit
{
    public partial class Mainform : Form
    {
        Transaction.DataTransaction dttrans = null;
        String Cmnotmade = "";
        String Linecapacitynotmade = "";
        private Point start;
        public Mainform()
        {
            InitializeComponent();
            dttrans = new Transaction.DataTransaction();
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Ship IT -" + Application.ProductVersion .ToString();
            lbl_loc.Text = Program.LogType;
            lblUsername.Text = Program.uername;
            backgroundWorker1.RunWorkerAsync();
        }
        private bool IsAlreadyOpen(Type formType)
        {

            bool isOpen = false;



            foreach (Form f in Application.OpenForms)
            {

                if (f.GetType() == formType)
                {

                    f.BringToFront();

                    f.WindowState = FormWindowState.Normal;

                    isOpen = true;

                }

            }


            return isOpen;

        }

        private void factoryCapacityToolStripMenuItem_Click(object sender, EventArgs e)
        {            
        }

        private void bookingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OrderBooking ordr = new OrderBooking();
            bool isFormOpen = IsAlreadyOpen(typeof(OrderBooking));
            if (isFormOpen == false)
            {
                ordr = new OrderBooking();
              ordr.MdiParent = this;
                ordr.StartPosition = FormStartPosition.CenterScreen;
                ordr.Show();
            }






        }



        public void getFactories()
        {

        }

        private void bookingConfirmationToolStripMenuItem_Click(object sender, EventArgs e)
        {


            BokkingConfirmation ordr = new BokkingConfirmation();
            bool isFormOpen = IsAlreadyOpen(typeof(BokkingConfirmation));
            if (isFormOpen == false)
            {
                ordr = new BokkingConfirmation();
           ordr.MdiParent = this;
                ordr.StartPosition = FormStartPosition.CenterScreen;
                ordr.Show();
            }




          
        }

        private void newFactoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFactory frm = new NewFactory();
            bool isFormOpen = IsAlreadyOpen(typeof(NewFactory));
            if (isFormOpen == false)
            {
                frm = new NewFactory();
              //  frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }

        }

        private void holidaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FactoryHolidays frm = new FactoryHolidays();
            bool isFormOpen = IsAlreadyOpen(typeof(FactoryHolidays));
            if (isFormOpen == false)
            {
                frm = new FactoryHolidays();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void report1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void report2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllMonthDetails frm = new AllMonthDetails();
            bool isFormOpen = IsAlreadyOpen(typeof(AllMonthDetails));
            if (isFormOpen == false)
            {
                frm = new AllMonthDetails();
                  frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryMaster frm = new CategoryMaster();
            bool isFormOpen = IsAlreadyOpen(typeof(CategoryMaster));
            if (isFormOpen == false)
            {
                frm = new CategoryMaster();
                //  frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }

        }

        private void categoryPercentageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryPercentage frm = new CategoryPercentage();
            bool isFormOpen = IsAlreadyOpen(typeof(CategoryPercentage));
            if (isFormOpen == false)
            {
                frm = new CategoryPercentage();
                //  frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }

        }

        private void bookingsEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllBookingForm frm = new AllBookingForm();
            bool isFormOpen = IsAlreadyOpen(typeof(AllBookingForm));
            if (isFormOpen == false)
            {
                frm = new AllBookingForm();
                 frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void bookingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bookingReportBeforeApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllMonthDetails frm = new AllMonthDetails("Before Approval");
            bool isFormOpen = IsAlreadyOpen(typeof(AllMonthDetails));
            if (isFormOpen == false)
            {
                frm = new AllMonthDetails("Before Approval");
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Application.Exit();
        }

        private void Mainform_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            if (Program.lctnpk == 0)
            {
                Notification frm = new Notification();
                frm.ShowDialog();
            }
            else
            {
                getitems();
            }
           

        }




        
        public   void getitems()

        {
            foreach (ToolStripMenuItem i in menuStrip1.Items)
            {
                GetMenuItems(i);
            }
    }

   public void GetMenuItems(ToolStripMenuItem item)
    {
       
        foreach (ToolStripItem i in item.DropDownItems)
        {
            if (i is ToolStripMenuItem)
            {
                
                if (Get_Menu(Program.userpk , i.Text) == true)
                {
                    i.Visible = true;
                    
                }
                else
                {
                    i.Visible = false;
                }
                GetMenuItems((ToolStripMenuItem)i);

            }
        }
    }
       

 public Boolean Get_Menu(int userid, string fnam)
       {
           Boolean frmnam = false;
           DataSet ds = Transaction.DataTransaction .Get_Data("select access_right from User_Rights where "
           +" user_id="+userid+" and form_name='" + fnam + "'");
           if (ds.Tables[0].Rows.Count > 0)
           {
             frmnam = true;
           }
           return frmnam;
       }

        private void uploadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void weekPlaningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void weeklyProductionEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void weekStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void userRightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrator.UserRights urm = new Administrator.UserRights();
            bool isFormOpen = IsAlreadyOpen(typeof(Administrator.UserRights));
            if (isFormOpen == false)
            {
                urm = new Administrator.UserRights();
                urm.MdiParent = this;
                urm.StartPosition = FormStartPosition.CenterScreen;
                urm.Show();
            }

        }

        private void poWiseProductionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Production.ProductionReport frm = new Production.ProductionReport();
            bool isFormOpen = IsAlreadyOpen(typeof(Production.ProductionReport));
            if (isFormOpen == false)
            {
                frm = new Production.ProductionReport();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void factoryLineMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Production.FactoryLinesMasterFrm frm = new Production.FactoryLinesMasterFrm();
            bool isFormOpen = IsAlreadyOpen(typeof(Production.FactoryLinesMasterFrm));
            if (isFormOpen == false)
            {
                frm = new Production.FactoryLinesMasterFrm();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void lineAssignerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void dailyProductionUpdaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Production.DailyProductionUpdater frm = new Production.DailyProductionUpdater();
            bool isFormOpen = IsAlreadyOpen(typeof(Production.DailyProductionUpdater));
            if (isFormOpen == false)
            {
                frm = new Production.DailyProductionUpdater();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void weekPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Production.WeekPlanviewer frm = new Production.WeekPlanviewer();
            bool isFormOpen = IsAlreadyOpen(typeof(Production.WeekPlanviewer));
            if (isFormOpen == false)
            {
                frm = new Production.WeekPlanviewer();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void dailyPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.AtcLinePlanrReportfrm frm = new Reports.AtcLinePlanrReportfrm();
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.AtcLinePlanrReportfrm));
            if (isFormOpen == false)
            {
                frm = new Reports.AtcLinePlanrReportfrm();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrator.Usermasterfrm frm = new Administrator.Usermasterfrm();
            bool isFormOpen = IsAlreadyOpen(typeof(Administrator.Usermasterfrm));
            if (isFormOpen == false)
            {
                frm = new Administrator.Usermasterfrm();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }

        }

        private void factoryAllocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capacity_Booking.ApprovedBooking frm = new Capacity_Booking.ApprovedBooking();
            bool isFormOpen = IsAlreadyOpen(typeof(Capacity_Booking.ApprovedBooking));
            if (isFormOpen == false)
            {
                frm = new Capacity_Booking.ApprovedBooking();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void newWeekAllocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Production.WeeklyChartform frm = new Production.WeeklyChartform();
            bool isFormOpen = IsAlreadyOpen(typeof(Production.WeeklyChartform));
            if (isFormOpen == false)
            {
                frm = new Production.WeeklyChartform();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void editWeeklyAllocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Production.WeeklyPlanEdit frm = new Production.WeeklyPlanEdit();
            bool isFormOpen = IsAlreadyOpen(typeof(Production.WeeklyPlanEdit));
            if (isFormOpen == false)
            {
                frm = new Production.WeeklyPlanEdit();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void atcMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Masters.AtcMaster frm = new Masters.AtcMaster();
            bool isFormOpen = IsAlreadyOpen(typeof(Masters.AtcMaster));
            if (isFormOpen == false)
            {
                frm = new Masters.AtcMaster();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void factoryWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.RDLC.LineplanReportForm frm = new Reports.RDLC.LineplanReportForm();
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.RDLC.LineplanReportForm));
            if (isFormOpen == false)
            {
                frm = new Reports.RDLC.LineplanReportForm();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void weeklyAllocationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void factoryWiseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reports.RDLC.WeekAllocationReportForm frm = new Reports.RDLC.WeekAllocationReportForm();
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.RDLC.WeekAllocationReportForm));
            if (isFormOpen == false)
            {
                frm = new Reports.RDLC.WeekAllocationReportForm();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void searchAtcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capacity_Booking.BookingReport frm = new Capacity_Booking.BookingReport();
            bool isFormOpen = IsAlreadyOpen(typeof(Capacity_Booking.BookingReport));
            if (isFormOpen == false)
            {
                frm = new Capacity_Booking.BookingReport();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void actionLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void capacityBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.RDLC.CapacityReport frm = new Reports.RDLC.CapacityReport();
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.RDLC.CapacityReport));
            if (isFormOpen == false)
            {
                frm = new Reports.RDLC.CapacityReport();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void orderBookingStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.BookingReport frm = new Reports.BookingReport();
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.BookingReport));
            if (isFormOpen == false)
            {
                frm = new Reports.BookingReport();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void atwWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.Lineplan frm = new Reports.Lineplan();
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.BookingReport));
            if (isFormOpen == false)
            {
                frm = new Reports.Lineplan();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void weekPlanVsLinePlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.Lineplanstatus frm = new Reports.Lineplanstatus();
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.Lineplanstatus));
            if (isFormOpen == false)
            {
                frm = new Reports.Lineplanstatus();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void productionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.Frm_ProductionActual frm = new Reports.Frm_ProductionActual();
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.Frm_ProductionActual));
            if (isFormOpen == false)
            {
                frm = new Reports.Frm_ProductionActual();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }

        }

        private void linePlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planning.PlanningFormDragable frm = new Planning.PlanningFormDragable();
            bool isFormOpen = IsAlreadyOpen(typeof(Planning.PlanningFormDragable));
            if (isFormOpen == false)
            {
                frm = new Planning.PlanningFormDragable();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void atcLineCapacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Production.LineCapacityForm frm = new Production.LineCapacityForm();
            bool isFormOpen = IsAlreadyOpen(typeof(Production.POWiseLineAssigner));
            if (isFormOpen == false)
            {
                frm = new Production.LineCapacityForm();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void atcLinePlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planning.LInePlanning frm = new Planning.LInePlanning();
            bool isFormOpen = IsAlreadyOpen(typeof(Planning.LInePlanning));
            if (isFormOpen == false)
            {
                frm = new Planning.LInePlanning();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void atcReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reports.RDLC.POPending frm = new Reports.RDLC.POPending();
            //bool isFormOpen = IsAlreadyOpen(typeof(Reports.QuickReports));
            //if (isFormOpen == false)
            //{
            //    frm = new Reports.RDLC.POPending();
            //    frm.MdiParent = this;
            //    frm.StartPosition = FormStartPosition.CenterScreen;
            //    frm.Show();
            //}
        }

        private void quickReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.QuickReports frm = new Reports.QuickReports();
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.QuickReports));
            if (isFormOpen == false)
            {
                frm = new Reports.QuickReports();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void pendingLinePlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.RDLC.PendingLinePlan rpt = new Reports.RDLC.PendingLinePlan();
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.RDLC.PendingLinePlan));
            if (isFormOpen == false)
            {
                rpt = new Reports.RDLC.PendingLinePlan();
                rpt.MdiParent = this;
                rpt.StartPosition = FormStartPosition.CenterScreen;
                rpt.Show();
            }
        }

        private void addDailyProductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailyProduction rpt = new DailyProduction();
            bool isFormOpen = IsAlreadyOpen(typeof(DailyProduction));
            if (isFormOpen == false)
            {
                rpt = new DailyProduction();
                rpt.MdiParent = this;
                rpt.StartPosition = FormStartPosition.CenterScreen;
                rpt.Show();
            }
        }

        private void addDailyPackDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailyPacking rpt = new DailyPacking();
            bool isFormOpen = IsAlreadyOpen(typeof(DailyProduction));
            if (isFormOpen == false)
            {
                rpt = new DailyPacking();
                rpt.MdiParent = this;
                rpt.StartPosition = FormStartPosition.CenterScreen;
                rpt.Show();
            }
        }

        private void reportsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Program.UserType.Trim() != "admin")
            {
                 
                MessageBox.Show("You are not management user");
            }
            else
            {
                ProjectionReport rpt = new ProjectionReport();
                bool isFormOpen = IsAlreadyOpen(typeof(ProjectionReport));
                if (isFormOpen == false)
                {
                    rpt = new ProjectionReport();
                    rpt.MdiParent = this;
                    rpt.StartPosition = FormStartPosition.CenterScreen;
                    rpt.Show();
                }

            }
        }

        private void rerport2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.UserType.Trim() != "admin")
            {

                MessageBox.Show("You are not management user");
            }
            else
            {
                

            }
        }

        private void report3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Program.UserType.Trim() != "admin")
            {

                MessageBox.Show("You are not management user");
            }
            else
            {
                DailyEfficiencyReport rpt = new DailyEfficiencyReport();
                bool isFormOpen = IsAlreadyOpen(typeof(DailyEfficiencyReport));
                if (isFormOpen == false)
                {
                    rpt = new DailyEfficiencyReport();
                    rpt.MdiParent = this;
                    rpt.StartPosition = FormStartPosition.CenterScreen;
                    rpt.Show();
                }

            }
        }

        private void oBEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.UserType.Trim() != "admin")
            {

                MessageBox.Show("You are not management user");
            }
            else
            {
                
            }
        }

        private void projeectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.UserType.Trim() != "admin")
            {

                MessageBox.Show("You are not management user");
            }
            else
            {
                CM.CompareProjrection rpt = new CM.CompareProjrection();
                bool isFormOpen = IsAlreadyOpen(typeof(CM.CompareProjrection));
                if (isFormOpen == false)
                {
                    rpt = new CM.CompareProjrection();
                    rpt.MdiParent = this;
                    rpt.StartPosition = FormStartPosition.CenterScreen;
                    rpt.Show();
                }

            }
        }

        private void approveProjectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.UserType.Trim() != "admin")
            {

                MessageBox.Show("You are not management user");
            }
            else
            {
                CM.CrystalForm rpt = new CM.CrystalForm();
                bool isFormOpen = IsAlreadyOpen(typeof(CM.CrystalForm));
                if (isFormOpen == false)
                {
                    rpt = new CM.CrystalForm();
                    rpt.MdiParent = this;
                    rpt.StartPosition = FormStartPosition.CenterScreen;
                    rpt.Show();
                }

            }
        }

        private void closeDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Production.ProductionDayClose frm = new Production.ProductionDayClose();
            bool isFormOpen = IsAlreadyOpen(typeof(Production.ProductionDayClose));
            if (isFormOpen == false)
            {
                frm = new Production.ProductionDayClose();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void projectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.ApprovedReports frm = new Reports.ApprovedReports();
            bool isFormOpen = IsAlreadyOpen(typeof(Reports.ApprovedReports));
            if (isFormOpen == false)
            {
                frm = new Reports.ApprovedReports();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void derToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dERDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DerReport frm = new DerReport();
            bool isFormOpen = IsAlreadyOpen(typeof(DerReport));
            if (isFormOpen == false)
            {
                frm = new DerReport();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void dERCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DER.DerSubReportfrm frm = new DER.DerSubReportfrm();
            bool isFormOpen = IsAlreadyOpen(typeof(DER.DerSubReportfrm));
            if (isFormOpen == false)
            {
                frm = new DER.DerSubReportfrm();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }

        }

        private void projectionGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectionReport rpt = new ProjectionReport();
            bool isFormOpen = IsAlreadyOpen(typeof(ProjectionReport));
            if (isFormOpen == false)
            {
                rpt = new ProjectionReport();
                rpt.MdiParent = this;
                rpt.StartPosition = FormStartPosition.CenterScreen;
                rpt.Show();
            }
        }

        private void dERGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailyEfficiencyReport rpt = new DailyEfficiencyReport();
            bool isFormOpen = IsAlreadyOpen(typeof(DailyEfficiencyReport));
            if (isFormOpen == false)
            {
                rpt = new DailyEfficiencyReport();
                rpt.MdiParent = this;
                rpt.StartPosition = FormStartPosition.CenterScreen;
                rpt.Show();
            }
        }

        private void pOProductionUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActualProduction.PoWiseProductionEntry rpt = new ActualProduction.PoWiseProductionEntry();
            bool isFormOpen = IsAlreadyOpen(typeof(ActualProduction.PoWiseProductionEntry));
            if (isFormOpen == false)
            {
                rpt = new ActualProduction.PoWiseProductionEntry();
                rpt.MdiParent = this;
                rpt.StartPosition = FormStartPosition.CenterScreen;
                rpt.Show();
            }
        }

        private void txt_location_DoubleClick(object sender, EventArgs e)
        {
            if (ifauthunicated())
            {
                Program.lctnpk = int.Parse(txt_location.Text);
                backgroundWorker1.RunWorkerAsync();
            }
        }
        public Boolean ifauthunicated()
        {
            Boolean authenicated = false;

            Try.SuperUserAuthenication spuser = new Try.SuperUserAuthenication();
            spuser.ShowDialog();
            authenicated = spuser.Isauthenicated;

            return authenicated;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CreateNotification();

            backgroundWorker1.ReportProgress(100);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }



        public void CreateNotification()
        {
            Cmnotmade = dttrans.GetAtcProducedWithoutCM(Program.lctnpk);
            Linecapacitynotmade = dttrans.GetProducedWithoutLineCapacity(Program.lctnpk);
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
          
            richTextBox1.Text = Cmnotmade + Environment.NewLine + Linecapacitynotmade;
          
        }

        private void panel3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void richTextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            richTextBox1.Visible = false;
        }

        private void buyerStylesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Masters.Stylemaster frm = new Masters.Stylemaster();
            bool isFormOpen = IsAlreadyOpen(typeof(Masters.Stylemaster));
            if (isFormOpen == false)
            {
                frm = new Masters.Stylemaster();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void aSQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Merchandising.ASQCreator frm = new Merchandising.ASQCreator();
            bool isFormOpen = IsAlreadyOpen(typeof(Merchandising.ASQCreator));
            if (isFormOpen == false)
            {
                frm = new Merchandising.ASQCreator();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }

        }

        private void aTCChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Merchandising.AtcChartForm frm = new Merchandising.AtcChartForm();
            bool isFormOpen = IsAlreadyOpen(typeof(Merchandising.AtcChartForm));
            if (isFormOpen == false)
            {
                frm = new Merchandising.AtcChartForm();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void wIPReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aERGENERATORToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Shipit.DER.AERReportGenerator rpt = new Shipit.DER.AERReportGenerator();
            bool isFormOpen = IsAlreadyOpen(typeof(Shipit.DER.AERReportGenerator));
            if (isFormOpen == false)
            {
                rpt = new Shipit.DER.AERReportGenerator();
                rpt.MdiParent = this;
                rpt.StartPosition = FormStartPosition.CenterScreen;
                rpt.Show();
            }
        }

        private void aERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DER.AERSubReport frm = new DER.AERSubReport();
            bool isFormOpen = IsAlreadyOpen(typeof(DER.AERSubReport));
            if (isFormOpen == false)
            {
                frm = new DER.AERSubReport();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void autoReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void finalCostingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void qualityReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Merchandising.ArtGridReports frm = new Merchandising.ArtGridReports();
            bool isFormOpen = IsAlreadyOpen(typeof(Merchandising.ArtGridReports));
            if (isFormOpen == false)
            {
                frm = new Merchandising.ArtGridReports();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void oBEntryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CM.CmCalculatorForm rpt = new CM.CmCalculatorForm();
            bool isFormOpen = IsAlreadyOpen(typeof(CM.CmCalculatorForm));
            if (isFormOpen == false)
            {
                rpt = new CM.CmCalculatorForm();
                rpt.MdiParent = this;
                rpt.StartPosition = FormStartPosition.CenterScreen;
                rpt.Show();
            }
        }

        private void cMReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CM.CmReports rpt = new CM.CmReports();
            bool isFormOpen = IsAlreadyOpen(typeof(CM.CmReports));
            if (isFormOpen == false)
            {
                rpt = new CM.CmReports();
                rpt.MdiParent = this;
                rpt.StartPosition = FormStartPosition.CenterScreen;
                rpt.Show();
            }
        }

        private void txt_location_TextChanged(object sender, EventArgs e)
        {
            //string[] words;
            //if (txtFromDate.Text.Contains("/"))
            //{
            //    words = txtFromDate.Text.Split("/");
            //}

            //words[2] = (int.Parse(words[2].ToString()) + 2000).ToString();

            //txtFromDate.Text = words[0].ToString() + "/" + words[1].ToString() + "/" + words[2].ToString();
        }
    }
}
