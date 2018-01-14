using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
namespace Shipit.Capacity_Booking
{
    public partial class ApprovedBooking : Form
    {
        Transaction.DataTransaction trans = null;
        Transaction.DataExporter DTPEXPTR = null;
        //String type = "";

        public ApprovedBooking()
        {
            InitializeComponent();
            trans = new Transaction.DataTransaction();
            tbl_showdata.ReadOnly = true;
        }
        public void showalldata()
        {
            if(cmb_year.Text!="")
            {
            DataTable dt = trans.GetAllApprovedBookings (int.Parse (cmb_year.Text ));
            tbl_showdata.DataSource = dt;
            sumofcolumns();

                      
            //for(int i=0;i<datagridview1.Rows.Count ;i++)
            //{
            //    sum = sum + int.Parse(datagridview1.Rows[i].Cells[intex].Value.ToString());
            //}
            
            }

        }
        public void loadbuyercombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from buyer in courdatacontext.Buyer_Masters
                    select buyer;



            Buyercombo.DataSource = q;
            Buyercombo.DisplayMember = "BuyerName";
            Buyercombo.ValueMember = "Buyer_Id";
            //   Buyercombo.DataBind();

           

        }

        public void loadfactorycombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from factory in courdatacontext.Factory_Masters
                    select factory;



            factorycombo.DataSource = q;
            factorycombo.DisplayMember = "Factory_name";
            factorycombo.ValueMember = "Factory_ID";
            //   Buyercombo.DataBind();

          

        }
        private void button4_Click(object sender, EventArgs e)
        {
            showalldata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                (tbl_showdata.DataSource as DataTable).DefaultView.RowFilter = string.Format("BuyerName = '{0}'", Buyercombo.Text);
                sumofcolumns();
            }
            catch (Exception)
            {
                
                
            }
        }

        private void tbl_showdata_DataSourceChanged(object sender, EventArgs e)
        {
           
        }



        public void sumofcolumns()
        {
            decimal sum1 = tbl_showdata.Rows.OfType<DataGridViewRow>().Sum(rows => Convert.ToDecimal(rows.Cells["BookQty"].Value));
            decimal sum2 = tbl_showdata.Rows.OfType<DataGridViewRow>().Sum(rows => Convert.ToDecimal(rows.Cells["ConsumptionQty"].Value));
            lbl_target.Text = "Booked Qty : "+sum1.ToString();
            lbl_lblproduced.Text = "Capacity Consumed : " + sum2.ToString();
        }


        private void ApprovedBooking_Load(object sender, EventArgs e)
        {
            loadbuyercombo();
            loadfactorycombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           try 
	{	        
		 (tbl_showdata.DataSource as DataTable).DefaultView.RowFilter = string.Format("BuyerName = '{0}' and Factory_name='{1}'", Buyercombo.Text,factorycombo.Text );
         sumofcolumns();
	}
	catch (Exception)
	{
		
		
	};
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                (tbl_showdata.DataSource as DataTable).DefaultView.RowFilter = string.Format("BuyerName = '{0}' and Factory_name='{1}' and month='{2}'", Buyercombo.Text, factorycombo.Text, cmb_month.Text);
                sumofcolumns();
            }
            catch (Exception)
            {
                
               
            }
        }

        private void editQuantityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Order_id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Order_id"].Value.ToString());
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            int qty = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["BookQty"].Value.ToString());
            int qtyconsumption = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["ConsumptionQty"].Value.ToString());
            BookingChanges bok = new BookingChanges(Book_Id, Order_id, qty, qtyconsumption);
            bok.ShowDialog();
        }

        private void changeFactoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrayList array = new ArrayList();
            array.Add(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["AtcNO"].Value.ToString());
            array.Add(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Factory_name"].Value.ToString());
            array.Add(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Year"].Value.ToString());
            array.Add(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Month"].Value.ToString());
            array.Add(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Style"].Value.ToString());
           


            int Order_id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Order_id"].Value.ToString());
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            String currentfact = tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Factory_name"].Value.ToString();
            BookingChanges bok = new BookingChanges(Book_Id, Order_id, currentfact, array);
            bok.ShowDialog();
        }








        public void changefactory()
        {

            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            int Order_id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Order_id"].Value.ToString());
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var delet = from details in couriercontext.FinalBooking_masters
                        where details.Book_Id == Book_Id
                        select details;
            foreach (var detail in delet)
            {
                detail.Factory_id = 0;
            }

            try
            {
                couriercontext.SubmitChanges();
            }
            catch (Exception)
            {
            }


            var delet1 = from details1 in couriercontext.OrderBooking_tbls
                         where details1.Order_id == Order_id
                         select details1;

            foreach (var detail in delet1)
            {
                detail.Factory_Id = 0;
            }

            try
            {
                couriercontext.SubmitChanges();
            }
            catch (Exception)
            {
            }

        }




        private void deleteBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteApprovedBooking();
           
            MessageBox.Show("Done");
        }

        public void deleteApprovedBooking()
        {
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            int Order_id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Order_id"].Value.ToString());
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var delet = from details in couriercontext.FinalBooking_masters
                        where details.Book_Id == Book_Id
                        select details;
            foreach (var detail in delet)
            {
                couriercontext.FinalBooking_masters.DeleteOnSubmit(detail);
            }

            try
            {
                couriercontext.SubmitChanges();
            }
            catch (Exception)
            {                
            }


            var delet1 = from details1 in couriercontext.OrderBooking_tbls
                         where details1.Order_id == Order_id
                         select details1;

            foreach (var detail in delet1)
            {
                couriercontext.OrderBooking_tbls.DeleteOnSubmit(detail);
            }

            try
            {
                couriercontext.SubmitChanges();
            }
            catch (Exception)
            {
            }


            Transaction.Actionlog.actiondone("Delete", "Deleted Approved BookID" + Book_Id.ToString());
        }

        private void changeCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            int Orderqty = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            int Factid = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            String Complexity = tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["ComplexityLevel"].Value.ToString();
            BookingChanges bok = new BookingChanges(Book_Id, Complexity,0,DateTime.Now.Date );
            bok.ShowDialog();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// 
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (cmb_yeartwo.Text.Trim()!="")
            {
                
                ultraGrid1.DataSource = trans.PendingOrderDetailForWeekPlan(cmb_yeartwo.Text.Trim());
                ultraGrid1.Rows.ColumnFilters.ClearAllFilters();
                UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            }
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DTPEXPTR = new Transaction.DataExporter();

            //     DTPEXPTR.exporttoexcel(dataGridView1);
            DTPEXPTR.writeCSV(tbl_showdata );
        }

        private void exportToExcelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Title = "Save an Excel File";
            saveFileDialog1.Filter = "Excel|*.xls|Excel 2010|*.xlsx";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                this.ultraGridExcelExporter1.Export(this.ultraGrid1, saveFileDialog1.FileName);
            }
        }

        private void changeAtcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            BookingChanges bok = new BookingChanges(Book_Id);
            bok.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string filename = Program.OurLogSource + "Actions.xmllog";
            try
            {
                
                ReadLogfileXml(filename);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
        }


        private void ReadLogfileXml(string filename)
        {
            using ( XmlLogfileStream logfileStream = new XmlLogfileStream(filename))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(logfileStream);
               ultraGrid2 .DataSource = ds;
               ultraGrid2.DataMember = ds.Tables[0].TableName;
               UltraGridBand band = this.ultraGrid2.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            }
        }

        private void splitBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            ApprovedBookingSplit bok = new ApprovedBookingSplit(Book_Id);
            bok.ShowDialog();
        }

        private void changeStyleMerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
                String Currentstyle = tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells[9].Value.ToString();
                BookingChanges bok = new BookingChanges(Book_Id, Currentstyle, 0);
                bok.ShowDialog();
               
          
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ultraGrid1.DataSource = trans.PendingPOWithlessthan120days();
                ultraGrid1.Rows.ColumnFilters.ClearAllFilters();
                UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            
        }

        private void januaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            int Order_id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Order_id"].Value.ToString());

            String month="January";

            ChangeMonth(month, Book_Id, Order_id);
        
        }




        public void ChangeMonth(String Month, int Book_Id, int Order_id)
        {
           
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var delet = from details in couriercontext.FinalBooking_masters
                        where details.Book_Id == Book_Id
                        select details;
            foreach (var detail in delet)
            {
                detail.Month = Month;
            }

            try
            {
                couriercontext.SubmitChanges();
            }
            catch (Exception)
            {
            }


            var delet1 = from details1 in couriercontext.OrderBooking_tbls
                         where details1.Order_id == Order_id
                         select details1;

            foreach (var detail in delet1)
            {
                detail.Month = Month;
            }

            try
            {
                couriercontext.SubmitChanges();
            }
            catch (Exception)
            {
            }


            Transaction.Actionlog.actiondone("Changed", "Deleted Approved BookID" + Book_Id.ToString());
        }

        private void februaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            int Order_id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Order_id"].Value.ToString());

            String month = "February";

            ChangeMonth(month, Book_Id, Order_id);
        }

        private void marchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            int Order_id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Order_id"].Value.ToString());

            String month = "March";

            ChangeMonth(month, Book_Id, Order_id);
        }

        private void aprilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            int Order_id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Order_id"].Value.ToString());

            String month = "April";

            ChangeMonth(month, Book_Id, Order_id);
        }

        private void mayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            int Order_id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Order_id"].Value.ToString());

            String month = "May";

            ChangeMonth(month, Book_Id, Order_id);
        }

        private void juneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            int Order_id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Order_id"].Value.ToString());

            String month = "June";

            ChangeMonth(month, Book_Id, Order_id);
        }

        private void julyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            int Order_id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Order_id"].Value.ToString());

            String month = "July";

            ChangeMonth(month, Book_Id, Order_id);
        }

        private void augustToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            int Order_id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Order_id"].Value.ToString());

            String month = "August";

            ChangeMonth(month, Book_Id, Order_id);
        }

        private void septemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            int Order_id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Order_id"].Value.ToString());

            String month = "September";

            ChangeMonth(month, Book_Id, Order_id);
        }

        private void octoberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            int Order_id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Order_id"].Value.ToString());

            String month = "October";

            ChangeMonth(month, Book_Id, Order_id);
        }

        private void novemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            int Order_id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Order_id"].Value.ToString());

            String month = "November";

            ChangeMonth(month, Book_Id, Order_id);
        }

        private void decemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Book_Id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Book_Id"].Value.ToString());
            int Order_id = int.Parse(tbl_showdata.Rows[tbl_showdata.CurrentRow.Index].Cells["Order_id"].Value.ToString());

            String month = "December";

            ChangeMonth(month, Book_Id, Order_id);
        }
     
    }
}
