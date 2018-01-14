using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.Production
{
    public partial class WeekPlanSplitter : Form
    {
        int weekid = 0;
        String Month = "";
        int year = 0;
        String WeekNo = "";
        int fact_id = 0;
        int Book_id = 0;
        int oldQty = 0;
        String Ponum = "";
        string stylenum = "";
        int consqty = 0;
        DateTime addeddate = DateTime.Now.Date;
        String addedby = "";
        DateTime Actualdeliverydate = DateTime.Now.Date;
        DateTime inhousedate=DateTime.Now.Date;
        float conrate = 0;
        int TotalSum = 0;
        public WeekPlanSplitter()
        {
            InitializeComponent();
        }
        public WeekPlanSplitter(int Weekid)
        {
            InitializeComponent();
            weekid = Weekid ;
            gettweekdetails();
        }



        public void gettweekdetails()
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var q = from details in couriercontext.WeeklyPlan_Masters
                    where details.WeekID ==weekid
                    select details;
            foreach (var detail in q)
            {
                Month = detail.Month;
                year = int.Parse (detail.Year.ToString ());
                WeekNo = detail.WeekNo;
                fact_id = Convert.ToInt32 (detail.Factory_Id.ToString ());
                Book_id = int.Parse(detail.Book_Id.ToString());
                oldQty = int.Parse(detail.Qty.ToString());
                 TotalSum = int.Parse(detail.Qty.ToString());
                 Ponum = detail.PO_;
                 stylenum = detail.stylenum;
                 consqty = int.Parse(detail.ConsumptionQty.ToString());
                 addedby = detail.AddedBy;
                 addeddate =DateTime.Parse ( detail.AddedDate.ToString ());
                 Actualdeliverydate = DateTime.Parse (  detail.ActualDelivery_date.ToString ());
                 inhousedate = DateTime.Parse(detail.InhouseDate.ToString());
                 conrate = float.Parse(consqty.ToString()) / float.Parse(TotalSum.ToString());
                }
            }
        private void button1_Click(object sender, EventArgs e)
        {
            tbl_neworder.RowCount = int.Parse(txt_num.Text);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(tbl_neworder.Rows.Count !=0)
            {
                if(validationcontrol ())
                {
                    insetweekplan();
                    Updateoldplan();

                }


            }
        }





        public void insetweekplan()
        {
            for (int i = 0; i < tbl_neworder.Rows.Count; i++)
            {
                CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
                WeeklyPlan_Master mstr = new WeeklyPlan_Master();


                mstr.Book_Id = Book_id ;
                mstr.Factory_Id =fact_id;
                mstr.Month = Month;
                mstr.Year = year ;
                mstr.WeekNo = WeekNo ;              
                mstr.PO_ = Ponum;
                mstr.AddedBy = Program.uername;
                mstr.AddedDate = DateTime.Now;
                mstr.stylenum = stylenum ;
                mstr.ActualDelivery_date = Actualdeliverydate;
                mstr.InhouseDate = inhousedate ;
                courdatacontext.WeeklyPlan_Masters.InsertOnSubmit(mstr);


                mstr.Qty = int.Parse (tbl_neworder.Rows[i].Cells["Qty"].Value.ToString ());
                float  consumption = conrate * float .Parse(tbl_neworder.Rows[i].Cells["Qty"].Value.ToString());
                mstr.ConsumptionQty = (int)consumption ;


                oldQty = oldQty - int.Parse(tbl_neworder.Rows[i].Cells["Qty"].Value.ToString());
                courdatacontext.SubmitChanges();
            }
        }

        public void Updateoldplan()
        {
             CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var q = from details in couriercontext.WeeklyPlan_Masters
                    where details.WeekID ==weekid
                    select details;
            foreach (var detail in q)
            {
                detail.Qty = oldQty;
                float consumption = conrate * float.Parse(oldQty.ToString());
                detail.ConsumptionQty = (int)consumption;
                couriercontext.SubmitChanges();
                MessageBox.Show("Done");
                this.Close();
            }
        }

        public Boolean  validationcontrol()
        {
            Boolean  sucess = false;
            if(Isfullnotnull())
            {
                MessageBox.Show("Enter Qty in Blank Column");
            }
            else if (isextraentered())
            {
                MessageBox.Show("Enter Qty iis Greater than Orginal Allocation Qty");
            }else
            {
                sucess = true;
            }

            return sucess;
        }

        public Boolean Isfullnotnull()
        {

            Boolean ISNULLENTERED = false;
            for (int i = 0; i < tbl_neworder.Rows.Count; i++)
            {
                if(tbl_neworder.Rows[i].Cells["Qty"].Value.ToString().Trim ()=="")
                {
                    ISNULLENTERED = true;
                }

            }

            return ISNULLENTERED;
        }


        public Boolean isextraentered()
        {

            Boolean isextraentered = false;

            int sum = 0;
            for (int i = 0; i < tbl_neworder.Rows.Count;i++ )
            {
                sum = sum + int.Parse(tbl_neworder.Rows[i].Cells["Qty"].Value.ToString());
            }


            if(sum>TotalSum )
            {
                isextraentered = true;
            }
            else
            {
                isextraentered = false;
            }

                return isextraentered;
        }
    }
}
