﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.Production
{
    public partial class EditLinePlanForm : Form
    {
        String Action = "Normal";

        int factid = 0;
        public EditLinePlanForm()
        {
            InitializeComponent();
        }
        public EditLinePlanForm(int factoryid, int qty)
        {
            InitializeComponent();
            lbl_factprodid.Text = factoryid.ToString();
            txt_newqty.Text = qty.ToString();
        }
         public EditLinePlanForm(int Lineplanid,int qty,int factidno)
        {
            InitializeComponent();
            lbl_factprodid.Text = Lineplanid.ToString();
            txt_newqty.Enabled = false;
            lbl_factprodid.Enabled = false;
            Action = "Linenum";
            factid = factidno;
            loadlinenum(comboBox1);
        }

         public EditLinePlanForm( int factidno)
         {
             InitializeComponent();
             factid = factidno;
             tabControl1.SelectedTab = tabPage2;
             loadlinenum(comboBox2);
         }


        public void  loadlinenum(ComboBox cmb)
        {
             CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr);
                var q =from  fm in cntxt.LineMasters
                            where fm.FactoryID==factid
                              select fm;


                cmb.DataSource = q;
                cmb.DisplayMember = "LineNum";
                cmb.ValueMember = "Lineid"; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Action == "Linenum")
            {
                CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr);
                var q = from lineplan in cntxt.FactoryWeeklyPlan_tbls
                        where lineplan.FctProdID == int.Parse(lbl_factprodid.Text)
                        select lineplan;
                foreach (var v in q)
                {
                    v.LineID = int.Parse(comboBox1 .SelectedValue .ToString ());
                    v.LineNum = comboBox1.Text;
                    cntxt.SubmitChanges();
                }
                MessageBox.Show("Done");
            }
            else
            {
                CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr);
                var q = from lineplan in cntxt.FactoryWeeklyPlan_tbls
                        where lineplan.FctProdID == int.Parse(lbl_factprodid.Text)
                        select lineplan;
                foreach (var v in q)
                {
                    v.TargetQty = int.Parse(txt_newqty.Text);

                    cntxt.SubmitChanges();
                }
                MessageBox.Show("Done");
            }
            

        }

        private void EditLinePlanForm_Load(object sender, EventArgs e)
        {

        }
        public string Linenum
        {
            get;
            private set;
        }
        public int Lineid
        {
            get;
            private set;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Linenum = comboBox2.Text;
            Lineid = int.Parse(comboBox2.SelectedValue.ToString());

            this.Close();
        }
    }
}
