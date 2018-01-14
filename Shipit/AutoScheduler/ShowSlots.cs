using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.AutoScheduler
{ 
    public partial class ShowSlots : Form
    {
        Transaction.DataTransaction dtrans = null;
        Transaction.AtracoCalaender atcclndr = null;
        int  factid=0;
        int stylecapacity = 0;
        float totalqty = 0;
        Boolean issucess = true;


        public DataTable SlotSet { get; set; }
   


        public ShowSlots()
        {
            InitializeComponent();
        }
        public ShowSlots(DataTable dt ,int factoryid,int capacitystyle,int qty)
        {
            InitializeComponent();
            dataGridView1.DataSource = dt;
            atcclndr = new Transaction.AtracoCalaender();
            dtrans=new Transaction.DataTransaction ();
            DataTable  filteredData = dt.Select("DayofWeek <>'Sunday'").CopyToDataTable();
            totalqty = qty;
            factid=factoryid;
            stylecapacity = capacitystyle;
            DataView view = new DataView(filteredData);

            
            DataTable distinctValues = view.ToTable(true, "Month", "Year","Weeknumber" );
distinctValues.Columns.Add("NoofDaysinWeek", typeof(string));
distinctValues.Columns.Add("NoOfDaysOfMonth", typeof(string));
distinctValues.Columns.Add("WeeklyCapacity", typeof(string));
distinctValues.Columns.Add("AlreadyBooked", typeof(string));
 distinctValues.Columns.Add("CapacityAvailbale", typeof(string));
 distinctValues.Columns.Add("Stylecapacity", typeof(string));
 distinctValues.Columns.Add("Productiontarget", typeof(string));
 distinctValues.Columns.Add("Bookvalue", typeof(string));
 distinctValues.Columns.Add("factid", typeof(string));
            for(int i=0;i<distinctValues .Rows.Count;i++)
            {

                object sumObject = filteredData.Compute("Count(dateofWeek)", "Month='" + distinctValues.Rows[i]["Month"].ToString() + "' and year='" + distinctValues.Rows[i]["Year"].ToString() + "' and Weeknumber='" + distinctValues.Rows[i]["Weeknumber"].ToString() + "' ");
               
                float  noofdays = float .Parse(sumObject.ToString());
                float saturdayinweek = 0;

                 object saturdayobject = filteredData.Compute("Count(dateofWeek)", "Month='" + distinctValues.Rows[i]["Month"].ToString() + "' and year='" + distinctValues.Rows[i]["Year"].ToString() + "' and Weeknumber='" + distinctValues.Rows[i]["Weeknumber"].ToString() + "'  and DayofWeek='Saturday'");
                 saturdayinweek = float.Parse(saturdayobject.ToString());

                int year=int.Parse(distinctValues.Rows[i]["Year"].ToString());
                String month=distinctValues.Rows[i]["Month"].ToString();
                String weekunm=distinctValues.Rows[i]["Weeknumber"].ToString();
                distinctValues.Rows[i]["NoofDaysinWeek"] = (noofdays -(saturdayinweek/2)).ToString();
                distinctValues.Rows[i]["NoOfDaysOfMonth"] = DateTime.DaysInMonth(year, atcclndr.getmonthname(month));
                distinctValues.Rows[i]["Stylecapacity"] =stylecapacity.ToString ();
                distinctValues.Rows[i]["Productiontarget"] = (stylecapacity * (noofdays - (saturdayinweek / 2))).ToString();
                distinctValues.Rows[i]["factid"] = factoryid.ToString();
                DataTable factorydetail = dtrans.GetAvailabilityofAWeek(year, month, weekunm, factoryid, float.Parse(distinctValues.Rows[i]["NoofDaysinWeek"].ToString()), int.Parse(distinctValues.Rows[i]["NoOfDaysOfMonth"].ToString()));
            
                if(factorydetail.Rows.Count>0)
                {
                    distinctValues.Rows[i]["WeeklyCapacity"]=factorydetail.Rows[0]["WeeklyCapacity"].ToString ();
                        distinctValues.Rows[i]["AlreadyBooked"]=factorydetail.Rows[0]["AlreadyAllocated"].ToString ();
                        float p = float.Parse(factorydetail.Rows[0]["WeeklyCapacity"].ToString()) - float.Parse(factorydetail.Rows[0]["AlreadyAllocated"].ToString());

                      distinctValues.Rows[i]["CapacityAvailbale"] = p.ToString();


                      float capacityavailable = float.Parse(distinctValues.Rows[i]["CapacityAvailbale"].ToString());
                      float prodtarget = float.Parse(distinctValues.Rows[i]["Productiontarget"].ToString());

                      if (totalqty > 0)
                      {
                          if (capacityavailable > 0)
                          {
                              if (capacityavailable > prodtarget)
                              {

                                  if (prodtarget < totalqty)
                                  {
                                      distinctValues.Rows[i]["Bookvalue"] = prodtarget.ToString();
                                      totalqty = totalqty - prodtarget;
                                  }
                                  else
                                  {
                                      distinctValues.Rows[i]["Bookvalue"] = totalqty.ToString();
                                      totalqty = totalqty - totalqty;
                                  }
                              }
                              else
                              {
                                  if (capacityavailable < totalqty)
                                  {
                                      distinctValues.Rows[i]["Bookvalue"] = capacityavailable.ToString();
                                      totalqty = totalqty - capacityavailable;
                                  }
                                  else
                                  {
                                      distinctValues.Rows[i]["Bookvalue"] = totalqty.ToString();
                                      totalqty = totalqty - totalqty;
                                  }

                              }
                          }
                      }

                }
                else
                {

                }
                

            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = distinctValues;

            if(totalqty >0)
            {
                issucess = false;
                MessageBox.Show("No Slot for available for "+totalqty.ToString ());
            }


       foreach (DataGridViewColumn dtc in dataGridView1.Columns)
            {
                dataGridView1.RowTemplate.Height = dtc.Width; 
            }

          
        }
   
   
        



      

        private void ShowSlots_ResizeEnd(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn dtc in dataGridView1.Columns)
            {
                dataGridView1.RowTemplate.Height = dtc.Width;
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.SlotSet = (DataTable)(dataGridView1.DataSource );

            if(issucess==true )
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
            
            this.Close();
        }



    
    }
}
