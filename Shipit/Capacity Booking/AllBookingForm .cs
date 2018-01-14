using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shipit
{
    
    public partial class AllBookingForm : Form
    {
        Transaction.DataTransaction trans = null;
        Transaction.DataExporter DTPEXPTR = null;
        String type = "";

        public AllBookingForm()
        {
            InitializeComponent();
            type = "normal";
            trans = new Transaction.DataTransaction ();
            tbl_editing.ReadOnly = true;

        }

        public AllBookingForm(DataTable dt)
        {
            InitializeComponent();
            type = "show";
            trans = new Transaction.DataTransaction();

            tbl_showdata.DataSource = dt;
            tabControl1.Enabled = false;
        }

        public void showalldata()
        {
            if (cmb_year.Text.Trim() != "")
            {
                tbl_showdata.DataSource = null;
                DataTable dt = trans.GetAllBookings(int.Parse (cmb_year.Text ));
                tbl_showdata.DataSource = dt;

                UltraGridBand band = this.tbl_showdata.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                showalldata();
            }
            else
            {
                gridviewsetup();
                trans.getallnonapprovedentriesforEditing(tbl_editing);
            }
        }

      

        private void AllBookingForm_Load(object sender, EventArgs e)
        {
            if (type == "normal")
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    showalldata();
                    
                  
                }
            }
        }


      

      

       

        private void button3_Click(object sender, EventArgs e)
        {
            showalldata();
        }

        private void changeFactoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int bookid = int.Parse(tbl_editing.Rows[tbl_editing.CurrentRow.Index].Cells[0].Value.ToString());
            String Currentfactory = tbl_editing.Rows[tbl_editing.CurrentRow.Index].Cells[1].Value.ToString();
            BookingChanges bok = new BookingChanges(bookid, Currentfactory);
            bok.ShowDialog();

            trans.getallnonapprovedentries(tbl_editing);
        }

        private void changeQuantityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int bookid = int.Parse(tbl_editing.Rows[tbl_editing.CurrentRow.Index].Cells[0].Value.ToString());
            String Currentfactory = tbl_editing.Rows[tbl_editing.CurrentRow.Index].Cells[1].Value.ToString();
            String Year = tbl_editing.Rows[tbl_editing.CurrentRow.Index].Cells[2].Value.ToString();
            String Month = tbl_editing.Rows[tbl_editing.CurrentRow.Index].Cells[3].Value.ToString();
            int qty = int.Parse(tbl_editing.Rows[tbl_editing.CurrentRow.Index].Cells[5].Value.ToString());
            BookingChanges bok = new BookingChanges(bookid, Currentfactory, Year, Month, qty);
            bok.ShowDialog();
            trans.getallnonapprovedentries(tbl_editing);
        }

        private void changeStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int bookid = int.Parse(tbl_editing.Rows[tbl_editing.CurrentRow.Index].Cells[0].Value.ToString());
            String Currentstyle = tbl_editing.Rows[tbl_editing.CurrentRow.Index].Cells[6].Value.ToString();
            BookingChanges bok = new BookingChanges(bookid, Currentstyle,0);
            bok.ShowDialog();
            trans.getallnonapprovedentries(tbl_editing);
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DTPEXPTR = new Transaction.DataExporter();

            //     DTPEXPTR.exporttoexcel(dataGridView1);
            DTPEXPTR.writeCSV(tbl_editing);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Title = "Save an Excel File";
            saveFileDialog1.Filter = "Excel|*.xls|Excel 2010|*.xlsx";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                this.ultraGridExcelExporter1.Export(this.tbl_showdata , saveFileDialog1.FileName);

                MessageBox.Show("Done");
            }
        }

       

        private void button6_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt = getdatatable(tbl_editing); ;
            try
            {
                //   DataTable results = dt.Select(Querystring).CopyToDataTable();
                DataTable results = dt.Select("Buyer = '" + cmb_byredit.Text + "'").CopyToDataTable();
                tbl_editing.DataSource = null;
                tbl_editing.ColumnCount = 0;
                tbl_editing.DataSource = results;
            }
            catch (Exception)
            {

                MessageBox.Show("No Pending Booking for Approval on this Search Criteria");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = getdatatable(tbl_editing); ;
            try
            {
                //   DataTable results = dt.Select(Querystring).CopyToDataTable();
                DataTable results = dt.Select("Factory = '" + cmb_fctredt .Text + "'").CopyToDataTable();
                tbl_editing.DataSource = null;
                tbl_editing.ColumnCount = 0;
                tbl_editing.DataSource  = results;
            }
            catch (Exception)
            {

                MessageBox.Show("No Pending Booking for Approval on this Search Criteria");
            }
        }



        public void gridviewsetup()
        {
            tbl_editing .DataSource = null;
            tbl_editing .ColumnCount = 0;

            tbl_editing.Columns.Add("BookID", "BookID");
            tbl_editing.Columns.Add("Factory", "Factory");
            tbl_editing.Columns.Add("Year", "Year");
            tbl_editing.Columns.Add("Month", "Month");
            tbl_editing.Columns.Add("Buyer", "Buyer");
            tbl_editing.Columns.Add("BookQty", "BookQty");

            tbl_editing.Columns.Add("Style", "Style");
           
        }


        public DataTable getdatatable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            DataColumn[] dcs = new DataColumn[] { };

            foreach (DataGridViewColumn c in dgv.Columns)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = c.Name;
                dt.Columns.Add(dc);

            }

            foreach (DataGridViewRow r in dgv.Rows)
            {
                DataRow drow = dt.NewRow();

                foreach (DataGridViewCell cell in r.Cells)
                {
                    drow[cell.OwningColumn.Name] = cell.Value;
                }

                dt.Rows.Add(drow);
            }
            return dt;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            gridviewsetup();
            trans.getallnonapprovedentriesforEditing(tbl_editing);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = getdatatable(tbl_editing); ;
            try
            {
                //   DataTable results = dt.Select(Querystring).CopyToDataTable();
                DataTable results = dt.Select("year = '" + cmb_yredit.Text + "' and  month='" + cmb_mnthedit.Text + "'").CopyToDataTable();
                tbl_editing.DataSource = null;
                tbl_editing.ColumnCount = 0;
                tbl_editing.DataSource = results;
            }
            catch (Exception)
            {

                MessageBox.Show("No Pending Booking for Approval on this Search Criteria");
            }
            
        }



        public void changestyleofApproved()
        {
             if (tbl_showdata.Rows[tbl_showdata.ActiveRow .Index].Cells[10].Value.ToString().Trim() == "A" || tbl_showdata.Rows[tbl_showdata.ActiveRow .Index].Cells[10].Value.ToString().Trim() == "N")
                {
                    int bookid = int.Parse(tbl_showdata.Rows[tbl_showdata.ActiveRow.Index].Cells[0].Value.ToString());
                    String Currentstyle = tbl_showdata.Rows[tbl_showdata.ActiveRow.Index].Cells[9].Value.ToString();
                    BookingChanges bok = new BookingChanges(bookid, Currentstyle, 0);
                    bok.ShowDialog();
                    showalldata();
                }
                else
                {
                    MessageBox.Show("You are not Allowed to Change the Style of Rejected Booking ");

                }
        }
        private void changeStyleApprovedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (Program.uername == "zohair")
            //{
            if (tbl_showdata.Rows[tbl_showdata.ActiveRow.Index].Cells[10].Value.ToString().Trim() == "A" || tbl_showdata.Rows[tbl_showdata.ActiveRow.Index].Cells[10].Value.ToString().Trim() == "N")
                {
                    int bookid = int.Parse(tbl_showdata.Rows[tbl_showdata.ActiveRow .Index].Cells[0].Value.ToString());
                    String Currentstyle = tbl_showdata.Rows[tbl_showdata.ActiveRow.Index].Cells[9].Value.ToString();
                    BookingChanges bok = new BookingChanges(bookid, Currentstyle, 0);
                    bok.ShowDialog();
                    showalldata();
                }
                else
                {
                    MessageBox.Show("You are not Allowed to Change the Style of Rejected Booking ");

                }
            //}
            //else
            //{
            //    MessageBox.Show("You are not Allowed for this Action");

            //}
        }




        private void splitBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int bookid = int.Parse(tbl_editing.Rows[tbl_editing.CurrentRow.Index].Cells[0].Value.ToString());
            Capacity_Booking.SplitBookingFrm frm = new Capacity_Booking.SplitBookingFrm(bookid);
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showallApproveddata();
        }


        public void showallApproveddata()
        {
            if (cmb_approvedyear.Text != "")
            {
                DataTable dt = trans.GetAllApprovedBookings(int.Parse(cmb_approvedyear.Text));
                tbl_approvedbooking.DataSource = dt;
               


                //for(int i=0;i<datagridview1.Rows.Count ;i++)
                //{
                //    sum = sum + int.Parse(datagridview1.Rows[i].Cells[intex].Value.ToString());
                //}

            }

        }

         //dgv is the name of your data grid view.

       

    }
}
