﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shipit.DataModels;
namespace Shipit.AutoScheduler
{
    public partial class AutoSchedulerFrm : Form
    {
        DateTimePicker oDateTimePicker; 
        Transaction.AtracoCalaender atcclndr = null;
        public AutoSchedulerFrm()
        {
            InitializeComponent();
        }
        public AutoSchedulerFrm(int bookid)
        {
            InitializeComponent();
            getdetailsofabooking(bookid);
            atcclndr = new Transaction.AtracoCalaender();
           
            loadfactorycombo();
            loadATC();
           // loadPOPack();
            txt_po.Focus();
        }
        public void loadfactorycombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from factory in courdatacontext.Factory_Masters
                    select factory;



            cmb_factory.DataSource = q;
            cmb_factory.DisplayMember = "Factory_name";
            cmb_factory.ValueMember = "Factory_ID";
            //   Buyercombo.DataBind();



        }




        public void loadATC()
        {
            using (ArtEntities enty = new ArtEntities())
            {

                var q = from asqmstr in enty.AtcMasters
                        select new
                        {
                            Atcnum = asqmstr.AtcNum,

                            atcid = asqmstr.AtcId
                        };

                cmb_atc.DataSource = q.ToList();
                cmb_atc.DisplayMember = "Atcnum";
                cmb_atc.ValueMember = "atcid";

            }

        }
              public void loadPOPack(int atcid)
        {
            using(ArtEntities enty= new ArtEntities ())
            {

                var q = from asqmstr in enty.PoPackMasters
                        where asqmstr.AtcId == atcid
                        select new
                        {
                            popack = asqmstr.PoPacknum + " /"+ asqmstr.BuyerPO,

                            popackid1=asqmstr.PoPackId
                        };

                cmb_PO.DataSource = q.ToList();
                cmb_PO.DisplayMember = "popack";
                cmb_PO.ValueMember = "PoPackId1";

            }

       

            //cmb_factory.DataSource = q;
            //cmb_factory.DisplayMember = "Factory_name";
            //cmb_factory.ValueMember = "Factory_ID";
            //   Buyercombo.DataBind();



        }



        public void loadPOPackDetails(int popackid)
        {
            using (ArtEntities enty = new ArtEntities())
            {

                var q = from asqmstr in enty.PoPackMasters
                        where asqmstr.PoPackId == popackid
                        select new
                        {
                            psd = asqmstr.Inhousedate,

                            deliverydate = asqmstr.DeliveryDate
                        };

               foreach (var element in q)
               {
                   dtp_delivery.Value = DateTime.Parse (element.deliverydate.ToString ());
                   dtp_psd.Value = DateTime.Parse(element.psd.ToString()).AddDays(7);
               }

            }

        }


        public void getdetailsofabooking(int bookid)
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);

            var orderdetails = from fb in couriercontext.FinalBooking_masters
                               join fc in couriercontext.Factory_Masters on fb.Factory_id equals fc.Factory_ID
                               where fb.Book_Id == bookid
                               select new
                               {
                                   bookid = fb.Book_Id,
                                   factoryname = fc.Factory_name,
                                   year = fb.Year,
                                   month = fb.Month,
                                   consumption = fb.ConsumptionQty,
                                   qty = fb.BookQty,
                                   capacity = fc.MonthlyCapacity,
                                   factory_id = fc.Factory_ID,
                                   stylenum = fb.Style,
                               };
            foreach (var element in orderdetails)
            {


                txt_bookID.Text = element.bookid.ToString();
                txt_factoryname.Text = element.factoryname;
                txt_consumptionQty.Text = element.consumption.ToString();
                txt_weeklycapacity.Text = (int.Parse(element.capacity.ToString()) / 4).ToString();
                cmb_month.Text = element.month;
                cmb_year.Text = element.year.ToString();
                lbl_factory_id.Text = element.factory_id.ToString();
                txt_totalqty.Text = element.qty.ToString();
               // txt_style.Text = element.stylenum;

            }

            var qtySum = (from ord in couriercontext.WeeklyPlan_Masters
                          where ord.Book_Id == bookid

                          select ord.Qty).Sum();
            if (qtySum == null)
            {
                txt_scheduledQty.Text = "0";
            }

            else if (qtySum.ToString().Trim() != "")
            {
                txt_scheduledQty.Text = qtySum.ToString();
            }
            else
            {
                txt_scheduledQty.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  tbl_Weekdata.RowCount = int.Parse(txt_noofpo.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                oDateTimePicker = new DateTimePicker();
                tbl_Weekdata.Controls.Add(oDateTimePicker);
                oDateTimePicker.Visible = false;
                oDateTimePicker.Format = DateTimePickerFormat.Short;
                oDateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);
                oDateTimePicker.Visible = true;
                Rectangle oRectangle = tbl_Weekdata.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);
                oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);
                oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);
            }
            else if(e.ColumnIndex == 5)
            {
                getdatafilled();
            }
        }




        public Boolean validationcontrol()
        {
            Boolean isSucess = false;
           
            if(txt_po .Text .Trim()=="")
            {
                MessageBox.Show("Enter Qty");
            }
            if (txt_style .Text.Trim() == "")
            {
                MessageBox.Show("Enter Style");
            }
            if (txt_capperday .Text.Trim() == "")
            {
                MessageBox.Show("Enter Capacity");
            }
            if (txt_qty.Text.Trim() == "")
            {
                MessageBox.Show("Enter PO Qty");
            }
            else
            {
                isSucess = true;
            }
            return isSucess;
        }


        public Boolean  isdatetime()
        { 
            Boolean isok=true;
            int rowindex = tbl_Weekdata.CurrentRow.Index;

        try 
	{	        
		    DateTime actualdelivery= DateTime.Parse(tbl_Weekdata.Rows[rowindex].Cells[3].Value.ToString ());
             DateTime csd= DateTime.Parse(tbl_Weekdata.Rows[rowindex].Cells[4].Value.ToString ());

	}
	catch (Exception)
	{
		
		isok=false;
	}
            return isok;
        }
        public void getdatafilled()
        {
            if (validationcontrol())
            {
                int rowindex = tbl_Weekdata.CurrentRow.Index;
                string PONUM = tbl_Weekdata.Rows[rowindex].Cells["PONum"].Value.ToString();
                string stylenum=tbl_Weekdata.Rows[rowindex].Cells["Stylenum"].Value.ToString();
                DataTable dt = atcclndr.GetDatesBetweenAPeriod(int.Parse(cmb_year.Text), DateTime.Parse(tbl_Weekdata.Rows[rowindex].Cells[4].Value.ToString()), DateTime.Parse(tbl_Weekdata.Rows[rowindex].Cells[3].Value.ToString()));

                if (dt != null)
                {
                    if (dt.Rows.Count >1)
                    {
                        using (var form = new ShowSlots(dt, int.Parse(lbl_factory_id.Text), int.Parse(textBox1.Text), int.Parse(tbl_Weekdata.Rows[rowindex].Cells[2].Value.ToString())))
                        {
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                DataTable dataslots = form.SlotSet;
                                tbl_Weekdata.Rows.Insert(rowindex , dataslots.Rows.Count);

                                for (int i = rowindex; i < tbl_Weekdata.Rows.Count-1; i++)
                                {
                                    tbl_Weekdata.Rows[i].Cells["PONum"].Value =PONUM;
                                    tbl_Weekdata.Rows[i].Cells["Stylenum"].Value = stylenum;
                                }
                            }
                        }
                       
            }
                    }
            }
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            tbl_Weekdata.CurrentCell.Value = oDateTimePicker.Text.ToString();
        }
        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            oDateTimePicker.Visible = false;
        }

        private void tbl_Weekdata_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            if (tbl_Weekdata.IsCurrentCellDirty)
                {
                    tbl_Weekdata.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (validationcontrol())
                {
                    DataTable dt = atcclndr.GetDatesBetweenAPeriod(int.Parse(cmb_year.Text), dtp_psd.Value.Date, dtp_delivery.Value.Date.AddDays(-7));

                    if (dt != null)
                    {
                        if (dt.Rows.Count > 1)
                        {
                            using (var form = new ShowSlots(dt, int.Parse(cmb_factory.SelectedValue .ToString()), int.Parse(txt_capperday.Text), int.Parse(txt_qty.Text)))
                            {
                                var result = form.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    DataTable dataslots = form.SlotSet;


                                    int loopstart = 0;
                                    int rowstart = tbl_Weekdata.Rows.Count;
                                    if (rowstart == 0)
                                    {
                                        loopstart = 0;
                                    }
                                    else
                                    {
                                        loopstart = rowstart;
                                    }
                                    int j = 0;
                                    for (int i = dataslots.Rows.Count - 1; i >= 0; i--)
      {
          if (dataslots.Rows[i]["Bookvalue"].ToString() == null || dataslots.Rows[i]["Bookvalue"].ToString() == "")
           dataslots.Rows[i].Delete();
      }
                                   
                                    for (int i = loopstart; i < rowstart + dataslots.Rows.Count; i++)
                                    {

                                        if (dataslots.Rows[j]["Bookvalue"] != null && (dataslots.Rows[j]["Bookvalue"].ToString().Trim() != ""))
                                        {

                                            tbl_Weekdata.Rows.Add();


                                            tbl_Weekdata.Rows[i].Cells["Year"].Value = dataslots.Rows[j]["Year"].ToString();
                                            tbl_Weekdata.Rows[i].Cells["Month"].Value = dataslots.Rows[j]["Month"].ToString();
                                            tbl_Weekdata.Rows[i].Cells["Weeknum"].Value = dataslots.Rows[j]["Weeknumber"].ToString();
                                            tbl_Weekdata.Rows[i].Cells["Qty"].Value = dataslots.Rows[j]["Bookvalue"].ToString();
                                            tbl_Weekdata.Rows[i].Cells["POnum"].Value = txt_po.Text.Trim();
                                            tbl_Weekdata.Rows[i].Cells["Stylenum"].Value = txt_style.Text.Trim();

                                            tbl_Weekdata.Rows[i].Cells["ActualDelivery"].Value = dtp_delivery.Value.Date.ToString();
                                            tbl_Weekdata.Rows[i].Cells["CSD"].Value = dtp_psd.Value.Date.ToString();
                                            tbl_Weekdata.Rows[i].Cells["Consumption"].Value = getconsumbtionqty(float.Parse(tbl_Weekdata.Rows[i].Cells["Qty"].Value.ToString()));

                                            tbl_Weekdata.Rows[i].Cells["Factid"].Value = dataslots.Rows[j]["factid"].ToString();
                                        }

                                        ++j;

                                    }
                                }
                            }

                        }
                    }

                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public float  getconsumbtionqty(float  newvalue)
        {
            float k = 0;
            try
            {
                 k = consumptionqty(float.Parse(txt_totalqty.Text), float.Parse(txt_consumptionQty.Text),newvalue );


                if (k > 0)
                {
                   
                }
                else
                {
                    k = newvalue;
                }
            }
            catch (Exception)
            {


            }
            return k;
        }
        public float consumptionqty(float totalqty, float consumptionqty, float enterqty)
        {
            float newconsumption = 0;
            float enteredcomsumption = consumptionqty / totalqty;
            newconsumption = enteredcomsumption * enterqty;
            return newconsumption;


        }





        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbl_Weekdata.Rows.Count; i++)
            {
                CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
                WeeklyPlan_Master mstr = new WeeklyPlan_Master();


                mstr.Book_Id = int.Parse(txt_bookID.Text);
                mstr.Factory_Id = int.Parse(tbl_Weekdata.Rows[i].Cells["factid"].Value.ToString());
                mstr.Month = tbl_Weekdata.Rows[i].Cells["Month"].Value.ToString();
                mstr.Year =int.Parse( tbl_Weekdata.Rows[i].Cells["Year"].Value.ToString());
                mstr.WeekNo = tbl_Weekdata.Rows[i].Cells["Weeknum"].Value.ToString();
                mstr.ActualDelivery_date = DateTime .Parse ( tbl_Weekdata.Rows[i].Cells["ActualDelivery"].Value.ToString ());
                mstr.InhouseDate = DateTime.Parse(tbl_Weekdata.Rows[i].Cells["CSD"].Value.ToString());
                mstr.Qty = (int)float.Parse(tbl_Weekdata.Rows[i].Cells["Qty"].Value.ToString());
                mstr.PO_ = tbl_Weekdata.Rows[i].Cells["POnum"].Value.ToString().Trim  ().ToString();
                mstr.stylenum = tbl_Weekdata.Rows[i].Cells["Stylenum"].Value.ToString().Trim().ToString();
                mstr.ConsumptionQty = (int)float.Parse (tbl_Weekdata.Rows[i].Cells["Consumption"].Value .ToString());
                mstr.OurStyle = cmb_ourStyle.Text;
                mstr.AtcNum = cmb_atc.Text;
                mstr.AtcID = int.Parse(cmb_atc.SelectedValue.ToString());
                mstr.OurStyleID = int.Parse(cmb_ourStyle.SelectedValue.ToString());
                mstr.AddedBy = Program.uername;
                mstr.AddedDate = DateTime.Now;
               
                
                courdatacontext.WeeklyPlan_Masters.InsertOnSubmit(mstr);

                courdatacontext.SubmitChanges();
                
            }
            MessageBox.Show("Done");
            this.Close();
        }

        private void cmb_PO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_po.Text = cmb_PO.Text.ToString();

                loadPOPackDetails(int.Parse(cmb_PO.SelectedValue.ToString()));
            }
            catch (Exception)
            {
                
               
            }
        }
        public void bindOurstylecombo()
        {
            int atcid = int.Parse(cmb_atc.SelectedValue.ToString());
            CourierDataDataContext cntxt = new CourierDataDataContext(Program.ArtConnStr);
            var q = from atcname in cntxt.AtcDetails
                    where atcname.AtcId == atcid

                    select atcname;

            cmb_ourStyle.DataSource = q;
            cmb_ourStyle.DisplayMember = "OurStyle";
            cmb_ourStyle.ValueMember = "OurStyleID";


        }
        private void cmb_atc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    bindOurstylecombo();

                }
                catch (Exception)
                {


                }

                loadPOPack(int.Parse(cmb_atc.SelectedValue.ToString()));
            }
            catch (Exception)
            {


            }
        }
    }
}
