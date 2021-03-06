﻿using System;
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
    public partial class AllMonthDetails : Form
    {
       Transaction.DataExporter DTPEXPTR = null;
        Transaction.DataTransaction dtrans = null;
        String selecxtedMonth = "";
        public AllMonthDetails()
        {
            InitializeComponent();
            dtrans = new Transaction.DataTransaction();
        }


        public AllMonthDetails(String reportype)
        {
            InitializeComponent();

            if (reportype == "Before Approval")
            {
                btn_getavailability.Visible = false;
                btn_getCapacity.Visible = false;
                btn_enquiry.Visible = true;
                btn_enquryCapacity.Visible = true;
                dtrans = new Transaction.DataTransaction();
            }

        }

        public DataTable GetBookings(int year)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"Select Factory_name,Factory_Master.Factory_ID,isnull(core.Year ,@year)as Year,
isnull(core.January,0) as January,
isnull(core.February,0) as February,
isnull(core.March,0) as March,
isnull(core.April,0) as April,
isnull(core.May,0) as May,
isnull(core.June,0) as June,
isnull(core.July,0) as July,
isnull(core.August,0) as August,
isnull(core.September,0) as September,
isnull(core.October,0) as October,
isnull(core.November,0) as November,
isnull(core.December,0) as December,
(isnull(core.January,0)+isnull(core.February,0)+isnull(core.March,0)+isnull(core.April,0)+isnull(core.May ,0) +isnull(core.June,0) +isnull(core.July,0) 
+isnull(core.August ,0) +isnull(core.September  ,0) +isnull(core.October ,0)+isnull(core.November ,0) +isnull(core.December ,0) ) as Total
  From (
Select * from (
Select Factory_id,Month,Year,ConsumptionQty from [FinalBooking_master] where Year=@year)SRC PIVOT 
(SUM(ConsumptionQty)for Month in ([January],[February],[March],[April],[May],[June],[July],[August],[September],[October],[November],[December]))xx)Core
right Join [dbo].[Factory_Master] on Factory_Master.Factory_ID=Core.Factory_id", con);



                cmd.Parameters.AddWithValue("@year", year);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }










        private void btn_getavailability_Click(object sender, EventArgs e)
        {
            if (cmb_year.Text.Trim() != "")
            {
                DataTable dt = GetBookings(int.Parse(cmb_year.Text));
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].Visible = false;
                lbl_jan.Text = "Jan: " + findtotal(dt, "January").ToString();
                lbl_feb.Text = "Feb: " + findtotal(dt, "February").ToString();
                lbl_march.Text = "Mar: " + findtotal(dt, "March").ToString();
                lbl_april.Text = "Apr: " + findtotal(dt, "April").ToString();
                lbl_may.Text = "May: " + findtotal(dt, "May").ToString();
                lbl_june.Text = "Jun: " + findtotal(dt, "June").ToString();
                lbl_july.Text = "Jul: " + findtotal(dt, "July").ToString();
                lbl_august.Text = "Aug: " + findtotal(dt, "August").ToString();
                lbl_sept.Text = "Sept: " + findtotal(dt, "September").ToString();
                lbl_oct.Text = "Oct: " + findtotal(dt, "October").ToString();
                lbl_nov.Text = "Nov: " + findtotal(dt, "November").ToString();
                lbl_dec.Text = "Dec: " + findtotal(dt, "December").ToString();
                lbl_motham.Text = "Total: " + findtotal(dt, "Total").ToString();
            }
            lbl_message.Text = "Approved Booking for  " + cmb_year.Text;
            tsm_stylewisebrk.Enabled = false;
        }


        public DataTable getavailability(int year)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"select Factory_name,Factory_Master.Factory_ID, Factory_Master.MonthlyCapacity, isnull(core.Year ,@year)as Year,
(Factory_Master.MonthlyCapacity - isnull(core.January,0)) as January,
(Factory_Master.MonthlyCapacity -isnull(core.February,0)) as February,
(Factory_Master.MonthlyCapacity -isnull(core.March,0)) as March,
(Factory_Master.MonthlyCapacity -isnull(core.April,0)) as April,
(Factory_Master.MonthlyCapacity -isnull(core.May,0)) as May,
(Factory_Master.MonthlyCapacity -isnull(core.June,0)) as June,
(Factory_Master.MonthlyCapacity -isnull(core.July,0)) as July,
(Factory_Master.MonthlyCapacity -isnull(core.August,0)) as August,
(Factory_Master.MonthlyCapacity -isnull(core.September,0)) as September,
(Factory_Master.MonthlyCapacity -isnull(core.October,0)) as October,
(Factory_Master.MonthlyCapacity -isnull(core.November,0) )as November,
(Factory_Master.MonthlyCapacity -isnull(core.December,0)) as December,
(isnull((Factory_Master.MonthlyCapacity - isnull(core.January,0)),0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.February,0)),0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.March,0)),0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.April,0)),0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.May,0)) ,0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.June,0)),0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.July,0)),0) 
+isnull((Factory_Master.MonthlyCapacity -isnull(core.August,0)) ,0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.September,0))  ,0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.October,0)) ,0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.November,0) ) ,0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.December,0)) ,0) ) as Total
  From (
Select * from (
Select Factory_id,Month,Year,ConsumptionQty from [FinalBooking_master] where Year=@year)SRC PIVOT 
(SUM(ConsumptionQty)for Month in ([January],[February],[March],[April],[May],[June],[July],[August],[September],[October],[November],[December]))xx)Core
right Join [dbo].[Factory_Master] on Factory_Master.Factory_ID=Core.Factory_id", con);



                cmd.Parameters.AddWithValue("@year", year);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }


        public void fillsum()
        {
            
        }


        public decimal  findtotal(DataTable dt,string Cname)
        {
            return Convert.ToDecimal(dt.AsEnumerable().Sum(x => x.Field<decimal>(Cname)));
        }
        public decimal findApprovedQtytotal(DataTable dt, string Month)
        {int returnvalue=0;
        try
        {
            object sumObject = dt.Compute("Sum(ApprovedQty)", "Month ='" + Month + "' ");
            returnvalue = int.Parse(sumObject.ToString());
        }
        catch (Exception)
        {
            
            
        }
            return returnvalue;
        }
        public decimal FindApprovedConsumption(DataTable dt, string Month)
        {
           

            int returnvalue=0;
        try
        {
            object sumObject = dt.Compute("Sum(ConsumptionQty)", "Month ='" + Month + "' ");
            returnvalue = int.Parse(sumObject.ToString());
        }
        catch (Exception)
        {
            
            
        }
            return returnvalue;
        }
        public decimal FindPendingApprovedQtytotal(DataTable dt, string Month)
        {
            int returnvalue = 0;
            try
            {
                object sumObject = dt.Compute("Sum(BookedQty)", "Month ='" + Month + "' ");
                returnvalue = int.Parse(sumObject.ToString());
            }
            catch (Exception)
            {


            }
            return returnvalue;
        }
    

        
        private void lbl_april_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmb_year.Text.Trim() != "")
            {
                DataTable dt = getavailability(int.Parse(cmb_year.Text));
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].Visible = false;
                lbl_jan.Text = "Jan: " + findtotal(dt, "January").ToString();
                lbl_feb.Text = "Feb: " + findtotal(dt, "February").ToString();
                lbl_march.Text = "Mar: " + findtotal(dt, "March").ToString();
                lbl_april.Text = "Apr: " + findtotal(dt, "April").ToString();
                lbl_may.Text = "May: " + findtotal(dt, "May").ToString();
                lbl_june.Text = "Jun: " + findtotal(dt, "June").ToString();
                lbl_july.Text = "Jul: " + findtotal(dt, "July").ToString();
                lbl_august.Text = "Aug: " + findtotal(dt, "August").ToString();
                lbl_sept.Text = "Sept: " + findtotal(dt, "September").ToString();
                lbl_oct.Text = "Oct: " + findtotal(dt, "October").ToString();
                lbl_nov.Text = "Nov: " + findtotal(dt, "November").ToString();
                lbl_dec.Text = "Dec: " + findtotal(dt, "December").ToString();
                lbl_motham.Text = "Total: " + findtotal(dt, "Total").ToString();
            }
            lbl_message.Text = "Capacity Available after Approved Booking for  " + cmb_year.Text;
        }





/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        
        
        
        
        
        
        
        public DataTable getenquiryavailability(int year)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


//                SqlCommand cmd = new SqlCommand(@"select Factory_name,Factory_Master.Factory_ID, Factory_Master.MonthlyCapacity, isnull(core.Year ,@year)as Year,
//(Factory_Master.MonthlyCapacity - isnull(core.January,0)) as January,
//(Factory_Master.MonthlyCapacity -isnull(core.February,0)) as February,
//(Factory_Master.MonthlyCapacity -isnull(core.March,0)) as March,
//(Factory_Master.MonthlyCapacity -isnull(core.April,0)) as April,
//(Factory_Master.MonthlyCapacity -isnull(core.May,0)) as May,
//(Factory_Master.MonthlyCapacity -isnull(core.June,0)) as June,
//(Factory_Master.MonthlyCapacity -isnull(core.July,0)) as July,
//(Factory_Master.MonthlyCapacity -isnull(core.August,0)) as August,
//(Factory_Master.MonthlyCapacity -isnull(core.September,0)) as September,
//(Factory_Master.MonthlyCapacity -isnull(core.October,0)) as October,
//(Factory_Master.MonthlyCapacity -isnull(core.November,0) )as November,
//(Factory_Master.MonthlyCapacity -isnull(core.December,0)) as December,
//(isnull((Factory_Master.MonthlyCapacity - isnull(core.January,0)),0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.February,0)),0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.March,0)),0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.April,0)),0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.May,0)) ,0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.June,0)),0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.July,0)),0) 
//+isnull((Factory_Master.MonthlyCapacity -isnull(core.August,0)) ,0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.September,0))  ,0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.October,0)) ,0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.November,0) ) ,0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.December,0)) ,0) ) as Total
//  From (
//Select * from (
//Select Factory_id,Month,Year,BookQty from [OrderBooking_tbl]  where Year=@year and isApproved!='R')SRC PIVOT 
//(SUM(BookQty)for Month in ([January],[February],[March],[April],[May],[June],[July],[August],[September],[October],[November],[December]))xx)Core
//right Join [dbo].[Factory_Master] on Factory_Master.Factory_ID=Core.Factory_id", con);


                SqlCommand cmd = new SqlCommand(@"select Factory_name,Factory_Master.Factory_ID, Factory_Master.MonthlyCapacity, isnull(core.Year ,@year)as Year,
(Factory_Master.MonthlyCapacity - isnull(core.January,0)) as January,
(Factory_Master.MonthlyCapacity -isnull(core.February,0)) as February,
(Factory_Master.MonthlyCapacity -isnull(core.March,0)) as March,
(Factory_Master.MonthlyCapacity -isnull(core.April,0)) as April,
(Factory_Master.MonthlyCapacity -isnull(core.May,0)) as May,
(Factory_Master.MonthlyCapacity -isnull(core.June,0)) as June,
(Factory_Master.MonthlyCapacity -isnull(core.July,0)) as July,
(Factory_Master.MonthlyCapacity -isnull(core.August,0)) as August,
(Factory_Master.MonthlyCapacity -isnull(core.September,0)) as September,
(Factory_Master.MonthlyCapacity -isnull(core.October,0)) as October,
(Factory_Master.MonthlyCapacity -isnull(core.November,0) )as November,
(Factory_Master.MonthlyCapacity -isnull(core.December,0)) as December,
(isnull((Factory_Master.MonthlyCapacity - isnull(core.January,0)),0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.February,0)),0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.March,0)),0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.April,0)),0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.May,0)) ,0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.June,0)),0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.July,0)),0) 
+isnull((Factory_Master.MonthlyCapacity -isnull(core.August,0)) ,0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.September,0))  ,0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.October,0)) ,0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.November,0) ) ,0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.December,0)) ,0) ) as Total
  From (
Select * from (
Select [OrderBooking_tbl].Factory_id,[OrderBooking_tbl].Month,[OrderBooking_tbl].Year,case when ISApproved='A'  then FinalBooking_master.ConsumptionQty else  [OrderBooking_tbl].BookQty end as BookQty 
from ([OrderBooking_tbl]left join FinalBooking_master on FinalBooking_master.Order_Id=OrderBooking_tbl.Order_Id  )  where OrderBooking_tbl.Year=@year and isApproved!='R')SRC PIVOT 
(SUM(BookQty)for Month in ([January],[February],[March],[April],[May],[June],[July],[August],[September],[October],[November],[December]))xx)Core
right Join [dbo].[Factory_Master] on Factory_Master.Factory_ID=Core.Factory_id", con);

                cmd.Parameters.AddWithValue("@year", year);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }

        private void btn_enquryCapacity_Click(object sender, EventArgs e)
        {
            tsm_stylewisebrk.Enabled = false;
            if (cmb_year.Text.Trim() != "")
            {
                DataTable dt = getenquiryavailability(int.Parse(cmb_year.Text));
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].Visible = false;
                lbl_jan.Text = "Jan: " + findtotal(dt, "January").ToString();
                lbl_feb.Text = "Feb: " + findtotal(dt, "February").ToString();
                lbl_march.Text = "Mar: " + findtotal(dt, "March").ToString();
                lbl_april.Text = "Apr: " + findtotal(dt, "April").ToString();
                lbl_may.Text = "May: " + findtotal(dt, "May").ToString();
                lbl_june.Text = "Jun: " + findtotal(dt, "June").ToString();
                lbl_july.Text = "Jul: " + findtotal(dt, "July").ToString();
                lbl_august.Text = "Aug: " + findtotal(dt, "August").ToString();
                lbl_sept.Text = "Sept: " + findtotal(dt, "September").ToString();
                lbl_oct.Text = "Oct: " + findtotal(dt, "October").ToString();
                lbl_nov.Text = "Nov: " + findtotal(dt, "November").ToString();
                lbl_dec.Text = "Dec: " + findtotal(dt, "December").ToString();
                lbl_motham.Text = "Total: " + findtotal(dt, "Total").ToString();
            }
            lbl_message.Text = " Capacity Available for " + cmb_year.Text;
        }

        private void btn_enquiry_Click(object sender, EventArgs e)
        {
            tsm_stylewisebrk.Enabled = false;
            if (cmb_year.Text.Trim() != "")
            {
                DataTable dt = GetenquiryBookings(int.Parse(cmb_year.Text));
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].Visible = false;
                lbl_jan.Text = "Jan: " + findtotal(dt, "January").ToString();
                lbl_feb.Text = "Feb: " + findtotal(dt, "February").ToString();
                lbl_march.Text = "Mar: " + findtotal(dt, "March").ToString();
                lbl_april.Text = "Apr: " + findtotal(dt, "April").ToString();
                lbl_may.Text = "May: " + findtotal(dt, "May").ToString();
                lbl_june.Text = "Jun: " + findtotal(dt, "June").ToString();
                lbl_july.Text = "Jul: " + findtotal(dt, "July").ToString();
                lbl_august.Text = "Aug: " + findtotal(dt, "August").ToString();
                lbl_sept.Text = "Sept: " + findtotal(dt, "September").ToString();
                lbl_oct.Text = "Oct: " + findtotal(dt, "October").ToString();
                lbl_nov.Text = "Nov: " + findtotal(dt, "November").ToString();
                lbl_dec.Text = "Dec: " + findtotal(dt, "December").ToString();
                lbl_motham.Text = "Total: " + findtotal(dt, "Total").ToString();
            }
            lbl_message.Text = "Total  Booking for " + cmb_year.Text;
            tsm_stylewisebrk.Enabled = false;
            CalculateApproveData();
        }


        public void CalculateApproveData()
        {
            DataTable dt = dtrans.OrderDetailsofYear(cmb_year.Text);
            DataTable nonapproveddata = new DataTable();
            try
            {

                nonapproveddata = dt.Select("ISApproved='N'").CopyToDataTable();
            }
            catch (Exception)
            {
                
               
            }

            lbl_appjan.Text = "Jan: " + findApprovedQtytotal(dt, "January").ToString();
            lbl_appfeb.Text = "Feb: " + findApprovedQtytotal(dt, "February").ToString();
            llbl_appmar.Text = "Mar: " + findApprovedQtytotal(dt, "March").ToString();
            lbl_appapril.Text = "Apr: " + findApprovedQtytotal(dt, "April").ToString();
            lbl_appmay.Text = "May: " + findApprovedQtytotal(dt, "May").ToString();
            lbl_appjun.Text = "Jun: " + findApprovedQtytotal(dt, "June").ToString();
            lbl_appjuly.Text = "Jul: " + findApprovedQtytotal(dt, "July").ToString();
            lbl_appaug.Text = "Aug: " + findApprovedQtytotal(dt, "August").ToString();
            lbl_appsept.Text = "Sept: " + findApprovedQtytotal(dt, "September").ToString();
            lblbl_appoct.Text = "Oct: " + findApprovedQtytotal(dt, "October").ToString();
            lbl_appnov.Text = "Nov: " + findApprovedQtytotal(dt, "November").ToString();
            lbl_appdec.Text = "Dec: " + findApprovedQtytotal(dt, "December").ToString();

            lblConsJan.Text = "Jan: " + FindApprovedConsumption(dt, "January").ToString();
            lblConsfeb.Text = "Feb: " + FindApprovedConsumption(dt, "February").ToString();
            lblConsMarch.Text = "Mar: " + FindApprovedConsumption(dt, "March").ToString();
            lblConsApril.Text = "Apr: " + FindApprovedConsumption(dt, "April").ToString();
            lblConsMay.Text = "May: " + FindApprovedConsumption(dt, "May").ToString();
            lblConsJun.Text = "Jun: " + FindApprovedConsumption(dt, "June").ToString();
            lblConsJuly.Text = "Jul: " + FindApprovedConsumption(dt, "July").ToString();
            lblConsAugust.Text = "Aug: " + FindApprovedConsumption(dt, "August").ToString();
            lblConsSept.Text = "Sept: " + FindApprovedConsumption(dt, "September").ToString();
            lblConsOct.Text = "Oct: " + FindApprovedConsumption(dt, "October").ToString();
            lblConsNov.Text = "Nov: " + FindApprovedConsumption(dt, "November").ToString();
            lblConsdec.Text = "Dec: " + FindApprovedConsumption(dt, "December").ToString();


            lbl_pendingjan.Text = "Jan: " + FindPendingApprovedQtytotal(nonapproveddata, "January").ToString();
            lbl_pendingFeb.Text = "Feb: " + FindPendingApprovedQtytotal(nonapproveddata, "February").ToString();
            lbl_pendingMar.Text = "Mar: " + FindPendingApprovedQtytotal(nonapproveddata, "March").ToString();
            lbl_pendingApril.Text = "Apr: " + FindPendingApprovedQtytotal(nonapproveddata, "April").ToString();
            lbl_pendingjMay.Text = "May: " + FindPendingApprovedQtytotal(nonapproveddata, "May").ToString();
            lbl_pendingJun.Text = "Jun: " + FindPendingApprovedQtytotal(nonapproveddata, "June").ToString();
            lbl_pendingjuly.Text = "Jul: " + FindPendingApprovedQtytotal(nonapproveddata, "July").ToString();
            lbl_pendingAugust.Text = "Aug: " + FindPendingApprovedQtytotal(nonapproveddata, "August").ToString();
            lbl_pendingsept.Text = "Sept: " + FindPendingApprovedQtytotal(nonapproveddata, "September").ToString();
            lbl_pendingoct.Text = "Oct: " + FindPendingApprovedQtytotal(nonapproveddata, "October").ToString();
            lbl_pendingnov.Text = "Nov: " + FindPendingApprovedQtytotal(nonapproveddata, "November").ToString();
            lbl_pendingdec.Text = "Dec: " + FindPendingApprovedQtytotal(nonapproveddata, "December").ToString();

         
        }


        public DataTable GetrejectedEnquiry(int year)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"Select Factory_name,Factory_Master.Factory_ID,isnull(core.Year ,@year)as Year,
isnull(core.January,0) as January,
isnull(core.February,0) as February,
isnull(core.March,0) as March,
isnull(core.April,0) as April,
isnull(core.May,0) as May,
isnull(core.June,0) as June,
isnull(core.July,0) as July,
isnull(core.August,0) as August,
isnull(core.September,0) as September,
isnull(core.October,0) as October,
isnull(core.November,0) as November,
isnull(core.December,0) as December,
(isnull(core.January,0)+isnull(core.February,0)+isnull(core.March,0)+isnull(core.April,0)+isnull(core.May ,0) +isnull(core.June,0) +isnull(core.July,0) 
+isnull(core.August ,0) +isnull(core.September  ,0) +isnull(core.October ,0)+isnull(core.November ,0) +isnull(core.December ,0) ) as Total
  From (
Select * from (
Select Factory_id,Month,Year,BookQty from OrderBooking_tbl where Year=@year and IsApproved='R')SRC PIVOT 
(SUM(BookQty)for Month in ([January],[February],[March],[April],[May],[June],[July],[August],[September],[October],[November],[December]))xx)Core
right Join [dbo].[Factory_Master] on Factory_Master.Factory_ID=Core.Factory_id", con);



                cmd.Parameters.AddWithValue("@year", year);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }
        public DataTable GetAvailabilityAfterRejection(int year)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"select Factory_name,Factory_Master.Factory_ID, Factory_Master.MonthlyCapacity, isnull(core.Year ,@year)as Year,
(Factory_Master.MonthlyCapacity - isnull(core.January,0)) as January,
(Factory_Master.MonthlyCapacity -isnull(core.February,0)) as February,
(Factory_Master.MonthlyCapacity -isnull(core.March,0)) as March,
(Factory_Master.MonthlyCapacity -isnull(core.April,0)) as April,
(Factory_Master.MonthlyCapacity -isnull(core.May,0)) as May,
(Factory_Master.MonthlyCapacity -isnull(core.June,0)) as June,
(Factory_Master.MonthlyCapacity -isnull(core.July,0)) as July,
(Factory_Master.MonthlyCapacity -isnull(core.August,0)) as August,
(Factory_Master.MonthlyCapacity -isnull(core.September,0)) as September,
(Factory_Master.MonthlyCapacity -isnull(core.October,0)) as October,
(Factory_Master.MonthlyCapacity -isnull(core.November,0) )as November,
(Factory_Master.MonthlyCapacity -isnull(core.December,0)) as December,
(isnull((Factory_Master.MonthlyCapacity - isnull(core.January,0)),0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.February,0)),0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.March,0)),0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.April,0)),0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.May,0)) ,0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.June,0)),0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.July,0)),0) 
+isnull((Factory_Master.MonthlyCapacity -isnull(core.August,0)) ,0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.September,0))  ,0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.October,0)) ,0)+isnull((Factory_Master.MonthlyCapacity -isnull(core.November,0) ) ,0) +isnull((Factory_Master.MonthlyCapacity -isnull(core.December,0)) ,0) ) as Total
  From (
Select * from (
Select Factory_id,Month,Year,BookQty from [OrderBooking_tbl]  where Year=@year)SRC PIVOT 
(SUM(BookQty)for Month in ([January],[February],[March],[April],[May],[June],[July],[August],[September],[October],[November],[December]))xx)Core
right Join [dbo].[Factory_Master] on Factory_Master.Factory_ID=Core.Factory_id", con);



                cmd.Parameters.AddWithValue("@year", year);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }
        public DataTable GetenquiryBookings(int year)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"Select Factory_name,Factory_Master.Factory_ID,isnull(core.Year ,@year)as Year,
isnull(core.January,0) as January,
isnull(core.February,0) as February,
isnull(core.March,0) as March,
isnull(core.April,0) as April,
isnull(core.May,0) as May,
isnull(core.June,0) as June,
isnull(core.July,0) as July,
isnull(core.August,0) as August,
isnull(core.September,0) as September,
isnull(core.October,0) as October,
isnull(core.November,0) as November,
isnull(core.December,0) as December,
(isnull(core.January,0)+isnull(core.February,0)+isnull(core.March,0)+isnull(core.April,0)+isnull(core.May ,0) +isnull(core.June,0) +isnull(core.July,0) 
+isnull(core.August ,0) +isnull(core.September  ,0) +isnull(core.October ,0)+isnull(core.November ,0) +isnull(core.December ,0) ) as Total
  From (
Select * from (
Select Factory_id,Month,Year,BookQty from OrderBooking_tbl where Year=@year and( isApproved='A' or isApproved='N'))SRC PIVOT 
(SUM(BookQty)for Month in ([January],[February],[March],[April],[May],[June],[July],[August],[September],[October],[November],[December]))xx)Core
right Join [dbo].[Factory_Master] on Factory_Master.Factory_ID=Core.Factory_id", con);



                cmd.Parameters.AddWithValue("@year", year);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);



            }
            return dt;
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
//PrintDialog printDialog = new PrintDialog();            
//    printDialog.Document = printDocument1;
//    printDialog.UseEXDialog = true;    
//    //Get the document
//    if (DialogResult.OK == printDialog.ShowDialog())
//    {
//        printDocument1.DocumentName = "Test Page Print";                
//        printDocument1.Print();
//    }
    /*
    Note: In case you want to show the Print Preview Dialog instead of 
    Print Dialog then comment the above code and uncomment the following code
    */

    //Open the print preview dialog
    //PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
    //objPPdialog.Document = printDocument1;
    //objPPdialog.ShowDialog();
            DTPEXPTR = new Transaction.DataExporter();

       //     DTPEXPTR.exporttoexcel(dataGridView1);
            DTPEXPTR.writeCSV(dataGridView1);
}
            
        




        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void showBreakUpOfMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String Month = this.dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText;
            String Year=dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString ();
            selecxtedMonth = Month;
            DataTable buyertable = dtrans.GetBuyer();
            DataTable factorytable = dtrans.getfactory();
            using (DataTable table = new DataTable())
            {
                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("Factory", typeof(String));
                for (int i = 0; i < buyertable.Rows.Count; i++)
                {
                    table.Columns.Add(buyertable.Rows[i][1].ToString(), typeof(String));
                    
                
                }
                for (int i = 0; i < factorytable.Rows.Count; i++)
                {
                    DataRow dr = table.NewRow();
                    dr[0] = int.Parse(factorytable.Rows[i][0].ToString());
                    dr[1] = factorytable.Rows[i][1].ToString();
                     table.Rows.Add(dr);
                   
                   
                }

                dataGridView1.DataSource = table;
                getbreakupvalues(Year, Month );
            }
            tsm_stylewisebrk.Enabled = true;
        }



        public void getbreakupvalues(String year, string month)
        {


            DataTable consoltable = dtrans.getAllConsolidatedBookingfactory(int.Parse ( year), month);
            
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
 for(int j=0;j< dataGridView1.Columns .Count;j++)
 {
     float orderrqty = 0;
                string Factoryname = dataGridView1.Rows[i].Cells[1].Value.ToString();
                 string buyername = dataGridView1.Columns[j].HeaderText;
                 var results = from myRow in consoltable.AsEnumerable()
                               where myRow.Field<string>("BuyerName") == buyername && myRow.Field<string>("Factory_name") == Factoryname 
                               select myRow;

                 foreach (var item in results)
                 {
                     string amount = item["Expr1"].ToString();
                     try
                     {
                         orderrqty = orderrqty + float.Parse(amount.ToString());
                     }
                     catch (Exception)
                     {
                         
                       
                     }
                     dataGridView1.Rows[i].Cells[j].Value = orderrqty.ToString();
                     //changed by sreenath on 06/05/2015
                     //dataGridView1.Rows[i].Cells[j].Value = amount;
                 }
 }
            }

          lbl_message.Text="Monthly BuyerWise BreakUp for "+year+ "-"+month ;
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
             Bitmap bm = new Bitmap(this.dataGridView1 .Width, this.dataGridView1.Height);

           

            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void tsm_stylewisebrk_Click(object sender, EventArgs e)
        {
            if (lbl_message.Text.Substring(0, 25) == "Monthly BuyerWise BreakUp")
            {

                if (selecxtedMonth != "")
                {
                    String Year = cmb_year.Text;
                    String Buyer = this.dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText;
                    String factoryid = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();

                    DataTable dt = dtrans.getBookingbyfilter(int.Parse ( factoryid), Buyer, int.Parse(Year), selecxtedMonth);
                    AllBookingForm abf = new AllBookingForm(dt);
                    abf.ShowDialog();
                }
              
                
            }
            else
            {
                MessageBox.Show(lbl_message.Text.Substring(0, 29));
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tsm_stylewisebrk.Enabled = false;
            if (cmb_year.Text.Trim() != "")
            {
                DataTable dt = GetrejectedEnquiry (int.Parse(cmb_year.Text));
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].Visible = false;
                lbl_jan.Text = "Jan: " + findtotal(dt, "January").ToString();
                lbl_feb.Text = "Feb: " + findtotal(dt, "February").ToString();
                lbl_march.Text = "Mar: " + findtotal(dt, "March").ToString();
                lbl_april.Text = "Apr: " + findtotal(dt, "April").ToString();
                lbl_may.Text = "May: " + findtotal(dt, "May").ToString();
                lbl_june.Text = "Jun: " + findtotal(dt, "June").ToString();
                lbl_july.Text = "Jul: " + findtotal(dt, "July").ToString();
                lbl_august.Text = "Aug: " + findtotal(dt, "August").ToString();
                lbl_sept.Text = "Sept: " + findtotal(dt, "September").ToString();
                lbl_oct.Text = "Oct: " + findtotal(dt, "October").ToString();
                lbl_nov.Text = "Nov: " + findtotal(dt, "November").ToString();
                lbl_dec.Text = "Dec: " + findtotal(dt, "December").ToString();
                lbl_motham.Text = "Total: " + findtotal(dt, "Total").ToString();
            }
            lbl_message.Text = "Rejected Order for " + cmb_year.Text;
        }

        private void statusOfBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String Month = this.dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText;
            String Year = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            String Factory = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            Capacity_Booking.BookingStatusForm FRM = new Capacity_Booking.BookingStatusForm(int.Parse(Year), Month, Factory);
            FRM.ShowDialog();
            
        }



    }


}
