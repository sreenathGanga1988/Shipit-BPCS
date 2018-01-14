using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.Capacity_Booking
{
    public partial class BookingStatusForm : Form
    {
        Transaction.DataTransaction dtrans = null;
        public BookingStatusForm()
        {
            InitializeComponent();
            dtrans = new Transaction.DataTransaction();
        }

        public BookingStatusForm(int year,String Month,String Factoryname)
        {
            InitializeComponent();
            dtrans = new Transaction.DataTransaction();
            DataTable dt = dtrans.Getdetialsofamonth(year, Month, Factoryname);
            dataGridView1.DataSource = dt;
        }

    }
}
