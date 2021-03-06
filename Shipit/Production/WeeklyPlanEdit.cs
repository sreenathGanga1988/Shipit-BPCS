﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shipit.Production
{ 
    public partial class WeeklyPlanEdit : Form
    {
        Transaction.DataExporter DTPEXPTR = null;
        Production.Productiontransaction trans = null;
        Transaction.AtracoCalaender atclndr = null;
        public WeeklyPlanEdit()
        {
            InitializeComponent();
            LoadFactoryCombo();
            trans = new Productiontransaction();
            atclndr = new Transaction.AtracoCalaender();
            DisableControls();
        }


        public void DisableControls()
        {
            if(Program.lctnpk!=0)
            {
                updateStylenumToolStripMenuItem.Enabled=false;
updatePONumToolStripMenuItem.Enabled=false;
deleteAllocationToolStripMenuItem.Enabled=false;
changeFactoryToolStripMenuItem.Enabled = false;
            }
        }
        public void LoadFactoryCombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from fctry in courdatacontext.Factory_Masters
                    select fctry;



            cmb_factory.DataSource = q;
            cmb_factory.DisplayMember = "Factory_name";
            cmb_factory.ValueMember = "Factory_ID";
            //   Buyercombo.DataBind();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            loaddatagrid();
        }


        public void loaddatagrid()
        {
            tbl_weekrequirement.DataSource = null;
            DataTable dt = trans.GetweeklyAllocationofamonth(cmb_month.Text, int.Parse(cmb_year.Text), int.Parse(cmb_factory.SelectedValue.ToString()));
            tbl_weekrequirement.DataSource = dt;
        }

        /// <summary>
        /// update the week of an Weekplan
        /// </summary>
        /// <param name="weekid"></param>
        /// <param name="Weeknum"></param>
        public void updateweek(int weekid,String Weeknum)
        {


            if (IsWeekChangeValid(Weeknum))
            {


                CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
                var updategrp = from factory in couriercontext.WeeklyPlan_Masters
                                where factory.WeekID == weekid
                                select factory;
                foreach (var v in updategrp)
                {
                    v.WeekNo = Weeknum;
                    couriercontext.SubmitChanges();
                }

                MessageBox.Show("Done");
            }else
            {
                MessageBox.Show("Cannot Move to a week outside the Range ");
            }
        }



        public Boolean IsWeekChangeValid(String Weeknum)
        {
            Boolean isvalid = false;
            try
            {
                int year = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["Year"].Value.ToString());
                String Month = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["Month"].Value.ToString();


                DateTime actualdeliverydate = DateTime.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["ActualDelivery_date"].Value.ToString());
                DateTime psd = DateTime.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["PSD"].Value.ToString());

                isvalid = atclndr.isChangeOK(Month, year, Weeknum, psd, actualdeliverydate);
            }
            catch (Exception)
            {
                
               MessageBox.Show("Wrong Details in Allocation");
            }

            return isvalid;
        }


        public Boolean IsMonthChangeValid(String Monthnum)
        {
            Boolean isvalid = false;
            try
            {
                int year = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["Year"].Value.ToString());
                String Weeknum = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["week"].Value.ToString();


                DateTime actualdeliverydate = DateTime.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["ActualDelivery_date"].Value.ToString());
                DateTime psd = DateTime.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["PSD"].Value.ToString());

                isvalid = atclndr.isChangeOK(Monthnum, year, Weeknum, psd, actualdeliverydate);

            }
            catch (Exception)
            {

                MessageBox.Show("Wrong Details in Allocation");
            }
            return isvalid;
        }




        public Boolean IsYearChangeValid(int  year)
        {
            Boolean isvalid = false;
            try
            {
                String Month = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["Month"].Value.ToString();
                String Weeknum = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["week"].Value.ToString();


                DateTime actualdeliverydate = DateTime.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["ActualDelivery_date"].Value.ToString());
                DateTime psd = DateTime.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["PSD"].Value.ToString());

                isvalid = atclndr.isChangeOK(Month, year, Weeknum, psd, actualdeliverydate);

            }
            catch (Exception)
            {

                MessageBox.Show("Wrong Details in Allocation");
            }
            return isvalid;
        }




        /// <summary>
        /// update the month of a weekplan
        /// </summary>
        /// <param name="weekid"></param>
        /// <param name="Month"></param>
        public void UpdatemonthMonth(int weekid, String Month)
        {
            if (IsMonthChangeValid(Month))
            {
                CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
                var updategrp = from factory in couriercontext.WeeklyPlan_Masters
                                where factory.WeekID == weekid
                                select factory;
                foreach (var v in updategrp)
                {
                    v.Month = Month;
                    couriercontext.SubmitChanges();
                }

                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Cannot Move to a Month outside the Range ");
            }
        }

        /// <summary>
        /// update the month of a weekplan
        /// </summary>
        /// <param name="weekid"></param>
        /// <param name="Month"></param>
        public void UpdateYear(int weekid, int year )
        {
            if (IsYearChangeValid(year))
            {
                CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
                var updategrp = from factory in couriercontext.WeeklyPlan_Masters
                                where factory.WeekID == weekid
                                select factory;
                foreach (var v in updategrp)
                {
                    v.Year = year ;
                    couriercontext.SubmitChanges();
                }

                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Cannot Move to a Year outside the Range ");
            }
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            
            updateweek(weekid, "Week1");
        }

        private void moveToWeek2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            updateweek(weekid, "Week2");
        }

        private void moveToWeek3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            updateweek(weekid, "Week3");
        }

        private void moveToWeek4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            updateweek(weekid, "Week4");
        }

        private void moveToWeek5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["WeekID"].Value.ToString());
        
            updateweek(weekid, "Week5");
        }

        private void januaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            UpdatemonthMonth(weekid, "January");
        }

        private void februaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            UpdatemonthMonth(weekid, "February");
        }

        private void marchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            UpdatemonthMonth(weekid, "March");
        }

        private void aprilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            UpdatemonthMonth(weekid, "April");
        }

        private void mayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            UpdatemonthMonth(weekid, "May");
        }

        private void juneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            UpdatemonthMonth(weekid, "June");
        }

        private void julyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            UpdatemonthMonth(weekid, "July");
        }

        private void augustToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            UpdatemonthMonth(weekid, "August");
        }

        private void septemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            UpdatemonthMonth(weekid, "September");
        }

        private void octoberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            UpdatemonthMonth(weekid, "October");
        }

        private void novemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            UpdatemonthMonth(weekid, "November");
        }

        private void decemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            UpdatemonthMonth(weekid, "December");
        }

        private void tbl_weekrequirement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public void weekPlanEditfunction()
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["WeekID"].Value.ToString());
            int qty = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["Qty"].Value.ToString());
            string styenum = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["stylenum"].Value.ToString();
            string ponum = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["PO#"].Value.ToString();
            DateTime actualdelivery = DateTime.Now.Date;
            DateTime psd = DateTime.Now.Date;
            try
            {
                actualdelivery = DateTime.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["ActualDelivery_date"].Value.ToString());
            }
            catch (Exception)
            {


            }
            try
            {
                psd = DateTime.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["PSD"].Value.ToString());
            }
            catch (Exception)
            {


            }
            editdetails(weekid, qty, styenum, ponum, actualdelivery,psd);

        }


        public void weekPlanEditfunctionwithfactory()
        {
            if(cmb_factory.Text.Trim () !="")
            {

                foreach (DataGridViewRow dgv in tbl_weekrequirement.SelectedRows)
                {
                    if ((int.Parse(dgv.Cells["Factory_id"].Value.ToString()) == int.Parse(cmb_factory.SelectedValue.ToString())))
                    {
                        int weekid = int.Parse(dgv.Cells["WeekID"].Value.ToString());
                        int qty = int.Parse(dgv.Cells["Qty"].Value.ToString());
                        string styenum = dgv.Cells["stylenum"].Value.ToString();
                        string ponum = dgv.Cells["PO#"].Value.ToString();
                        String Atcnum = dgv.Cells["Atcno"].Value.ToString();
                        String Weeknum = dgv.Cells["Week"].Value.ToString();
                        String Year = dgv.Cells["year"].Value.ToString();
                        String month = dgv.Cells["Month"].Value.ToString();
                        String factoryname = cmb_factory.Text;
                        DateTime actualdelivery = DateTime.Now.Date;
                        String Action = "Production factory  for Style# " + styenum + " Po # " + ponum + "  Under Atc# " + Atcnum + "  which was allocated for " + factoryname + "  for  " + Year + '-' + month + "-" + Weeknum + " is changed to Factory ";
                        try
                        {
                            actualdelivery = DateTime.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["ActualDelivery_date"].Value.ToString());
                        }
                        catch (Exception)
                        {


                        } 
                        
                        editdetails(weekid, qty, styenum, ponum, actualdelivery, factoryname, Action);
                        Transaction.Actionlog.actiondone("Weekly Production Factory Changed", Action);
                }


            //    if((int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["Factory_id"].Value.ToString())==int.Parse (cmb_factory.SelectedValue.ToString ())))
            //    {
            //int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["WeekID"].Value.ToString());
            //int qty = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["Qty"].Value.ToString());
            //string styenum = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["stylenum"].Value.ToString();
            //string ponum = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["PO#"].Value.ToString();
            //String Atcnum = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["Atcno"].Value.ToString();
            //String Weeknum = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["Week"].Value.ToString();
            //String Year = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["year"].Value.ToString();
            //    String month = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["Month"].Value.ToString();
            //String factoryname = cmb_factory.Text;
            //DateTime actualdelivery = DateTime.Now.Date;
            //        String Action= "Production factory  for Style# "+styenum+" Po # "+ponum +"  Under Atc# "+Atcnum + "  which was allocated for "+factoryname +"  for  "+Year +'-'+month+"-"+Weeknum +" is changed to Factory " ;
            //try
            //{
            //    actualdelivery = DateTime.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["ActualDelivery_date"].Value.ToString());
            //}
            //catch (Exception)
            //{


            //}
           
                }
        }
        }

        public void editdetails(int weekid, int qty, String stylenum, String Ponum, DateTime actualdelivery,DateTime psd)
        {
            Production.WeekPlanEditform frm = new WeekPlanEditform(weekid, qty, stylenum, Ponum, actualdelivery,psd);
            frm.ShowDialog();
        }

        public void editdetails(int weekid, int qty, String stylenum, String Ponum, DateTime actualdelivery,String factoryname,String action)
        {
            Production.WeekPlanEditform frm = new WeekPlanEditform(weekid, qty, stylenum, Ponum, actualdelivery,factoryname ,action);
            frm.ShowDialog();
        }
      
        private void changeDeliveryDateToolStripMenuItem_Click(object sender, EventArgs e)
        {


            weekPlanEditfunction();
        }





      
        private void updateStylenumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            weekPlanEditfunction();
        }

        private void updatePONumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            weekPlanEditfunction();
        }

        private void reduceQtyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            weekPlanEditfunction();
        }

        private void deleteAllocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["WeekID"].Value.ToString());
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var delet =    from details in couriercontext.WeeklyPlan_Masters
    where details.WeekID == weekid
    select details;

            foreach (var detail in delet)
            {
                couriercontext.WeeklyPlan_Masters.DeleteOnSubmit(detail);
            }

            try
            {
                couriercontext.SubmitChanges();
            }
            catch (Exception )
            {
                
                // Provide for exceptions.
            }
            string styenum = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["stylenum"].Value.ToString();
            string ponum = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["PO#"].Value.ToString();
            String Atcnum = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["Atcno"].Value.ToString();
            String Weeknum = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["Week"].Value.ToString();
            String Year = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["year"].Value.ToString();
            String month = tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["Month"].Value.ToString();
            String factoryname = cmb_factory.Text;
            String Action = "Weekly Allocation Deleted for  " + styenum + " Po # " + ponum + "  Under Atc# " + Atcnum + "  which was allocated for " + factoryname + "  for  " + Year + '-' + month + "-" + Weeknum + " is changed to Factory ";
            Transaction.Actionlog.actiondone("Weekly Allocation Deleted", Action);

            MessageBox.Show("Done");
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DTPEXPTR = new Transaction.DataExporter();

            //     DTPEXPTR.exporttoexcel(dataGridView1);
            DTPEXPTR.writeCSV(tbl_weekrequirement);
        }

        private void moveToolStripMenuItem_Click()
        {

        }

        private void changeFactoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            weekPlanEditfunctionwithfactory();
        }

        private void splitWeekPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            weekplansplit();
        }

      
        public void weekplansplit()
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["WeekID"].Value.ToString());

            WeekPlanSplitter spltr = new WeekPlanSplitter(weekid);
            spltr.ShowDialog();
        }

        private void cmb_factory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            UpdateYear(weekid, 2015);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            UpdateYear(weekid, 2016);

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            UpdateYear(weekid, 2017);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells[1].Value.ToString());
            UpdateYear(weekid, 2018);
        }

        private void shedulePOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int weekid = int.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["WeekID"].Value.ToString());
         DateTime   actualdelivery = DateTime.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["ActualDelivery_date"].Value.ToString());
           DateTime  psd = DateTime.Parse(tbl_weekrequirement.Rows[tbl_weekrequirement.CurrentRow.Index].Cells["PSD"].Value.ToString());
            Production.WeekPlanEditform frm = new WeekPlanEditform(weekid,actualdelivery,psd);
            frm.ShowDialog();
        }







    }

      
}
