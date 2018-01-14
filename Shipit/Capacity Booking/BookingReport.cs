﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shipit.Capacity_Booking
{
    public partial class BookingReport : Form
    {
        Transaction.DataTransaction trans = null;
      //  Transaction.DataExporter DTPEXPTR = null;
        String type = "";
        public BookingReport()
        {
            InitializeComponent();
            type = "normal";
            trans = new Transaction.DataTransaction();

        }

        private void BookingReport_Load(object sender, EventArgs e)
        {
           
        }
        public void showalldata()
        {
            DataTable dt = trans.GetAllBookings(txt_atc.Text);
            
            tbl_shownonApproved.DataSource = dt;
            
            tbl_shownonApproved.Columns["Factory_id"].Visible = false;
            tbl_shownonApproved.Columns["Buyer_id"].Visible = false;
            tbl_shownonApproved.Columns["MonthlyCapacity"].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            showdata();
            showsum();
        }

        public void showsum()
        {
            int Approved = 0;
            int nonApproved=0;
           // int booked=0;
            if (tbl_sshowApproved.Rows.Count > 0)
            {
                for (int i = 0; i < tbl_sshowApproved.Rows.Count-1; i++)
                {
                    Approved = Approved + int.Parse(tbl_sshowApproved.Rows[i].Cells[8].Value.ToString());
                }
            }
            if (tbl_shownonApproved.Rows.Count > 0)
            {
                for (int i = 0; i < tbl_shownonApproved.Rows.Count-1; i++)
                {
                    nonApproved = nonApproved + int.Parse(tbl_shownonApproved.Rows[i].Cells[8].Value.ToString());
                }
            }

            lbl_Pending.Text="Approval Pending Qty is "+nonApproved.ToString ();
            lbl_lblApproved .Text="Approved Qty is "+ Approved.ToString ();
            decimal sum1 = dataGridView1.Rows.OfType<DataGridViewRow>().Sum(rows => Convert.ToDecimal(rows.Cells["Qty"].Value));
            lbl_planned.Text = "Planned Qty : " + sum1.ToString();
        }

        
        public void showdata( )
        {
            DataTable dt1 = trans.GetAllWeekPlanForAtc(txt_atc.Text.Trim());
            dataGridView1.DataSource = dt1;
            DataTable alldata = trans.GetAllBookings(txt_atc.Text);
            DataTable results = new DataTable ();
            DataTable Approved = new DataTable();
            try
            {
                results = alldata.Select("ISApproved='N'").CopyToDataTable();
            }
            catch (Exception)
            {
                
                
            }

            try
            {
                Approved = alldata.Select("ISApproved='A'").CopyToDataTable();
            }
            catch (Exception)
            {
                
              
            }
            tbl_shownonApproved.DataSource = results;
            tbl_sshowApproved.DataSource = Approved;

           

        }
    }
}
