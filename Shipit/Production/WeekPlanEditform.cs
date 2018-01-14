using System;
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
    public partial class WeekPlanEditform : Form
    {
        int factflag=0;
        public WeekPlanEditform()
        {
            InitializeComponent();
        }

        public WeekPlanEditform(int weekid, DateTime actualdelivery, DateTime psd)
        {
            InitializeComponent();
            lbl_weekidforYearchange.Text = weekid.ToString();
            lbl_deliverydate.Text = actualdelivery.ToString();
            lbl_psd.Text = psd.ToString();
            tabControl1.SelectedTab = tabPage2;

        }

        public WeekPlanEditform(int weekid, int qty, String stylenum, String Ponum, DateTime actualdelivery,DateTime psd)
        {
            InitializeComponent();
            txt_newQty.Text = qty.ToString ();
            txt_pono.Text = Ponum;
            lbl_weekid.Text = weekid.ToString();
            txt_style.Text = stylenum;
           
            try
            {
                dateTimePicker1.Value = actualdelivery;
                dateTimePicker2.Value = psd;
            }
            catch (Exception)
            {
                
                
            }
        }


        public WeekPlanEditform(int weekid, int qty, String stylenum, String Ponum, DateTime actualdelivery,String currentfactory,String changefactoryaction)
        {
            InitializeComponent();
            txt_newQty.Text = qty.ToString();
            txt_pono.Text = Ponum;
            lbl_weekid.Text = weekid.ToString();
            txt_style.Text = stylenum;
            txt_currentfactory.Text = currentfactory;
            LoadFactoryCombo();

            txt_currentfactory.ReadOnly = true;
            txt_newQty.ReadOnly = true;
            txt_pono.ReadOnly = true;
            txt_style.ReadOnly = true;
            txt_currentfactory.Enabled  = false;
            txt_newQty.Enabled = false;
            txt_pono.Enabled = false;
            txt_style.Enabled = false;
            cmb_factory.Enabled = true;
            factflag = 1;

            try
            {
                dateTimePicker1.Value = actualdelivery;
                dateTimePicker2.Enabled = false;
            }
            catch (Exception)
            {


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
        private void txt_newQty_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

           
                CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
                var updategrp = from factory in couriercontext.WeeklyPlan_Masters
                                where factory.WeekID == int.Parse(lbl_weekid.Text)
                                select factory;
                foreach (var v in updategrp)
                {
                     if (factflag == 0)
                    {
                    v.ActualDelivery_date = dateTimePicker1.Value.Date;
                    v.InhouseDate = dateTimePicker2.Value.Date;
                    v.PO_ = txt_pono.Text;
                    v.stylenum = txt_style.Text;
                    v.Qty = int.Parse(txt_newQty.Text);


                     }
                    else
                     {
                        if(cmb_factory.Text.Trim ()!="")
                        {
                            v.Factory_Id = int.Parse(cmb_factory.SelectedValue.ToString());
                        }

                     }

                    couriercontext.SubmitChanges();
                }
            if(factflag !=0)
            {

            }

                MessageBox.Show("Done");

           
                this.Close();
            
            
        }

        private void WeekPlanEditform_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateYear(int.Parse(lbl_weekidforYearchange.Text), int.Parse(cmb_year.Text), cmb_month.Text.Trim(), cmb_newweek.Text.Trim());
            MessageBox.Show("Done");
        }



        /// <summary>
        /// update the month of a weekplan
        /// </summary>
        /// <param name="weekid"></param>
        /// <param name="Month"></param>
        public void UpdateYear(int weekid, int year,String Month, String Weeknum )
        {
            if (IsYearChangeValid(year, Month, Weeknum,DateTime.Parse (lbl_psd.Text),DateTime.Parse (lbl_deliverydate.Text)))
            {
                CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
                var updategrp = from factory in couriercontext.WeeklyPlan_Masters
                                where factory.WeekID == weekid
                                select factory;
                foreach (var v in updategrp)
                {
                    v.Year = year;
                    v.Month = Month;
                    v.WeekNo = Weeknum;
                    couriercontext.SubmitChanges();
                }

                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Cannot Move to a Year outside the Range ");
            }
        }

        public Boolean IsYearChangeValid(int year, String Month, String Weeknum, DateTime psd, DateTime actualdeliverydate)
        {
            Boolean isvalid = false;
            try
            {



                Transaction.AtracoCalaender atclndr = new Transaction.AtracoCalaender();

                isvalid = atclndr.isChangeOK(Month, year, Weeknum, psd, actualdeliverydate);

            }
            catch (Exception)
            {

                MessageBox.Show("Wrong Details in Allocation");
            }
            return isvalid;
        }
    }
}
