﻿using System;
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
    public partial class NewFactory : Form
    {
        public NewFactory()
        {
            InitializeComponent();
            showexistinguser();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 1)
                {
                    int sl = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());

                    deletefactory(sl);
                    showexistinguser();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (validationcontrol())
            {
                if (btn_save.Text == "Save")
                {
                    addnewfactory();
                    showexistinguser();
                    clearcontrol();
                }
                else
                {
                    updatefactory(int.Parse(lbl_pk.Text));
                    showexistinguser();
                    clearcontrol();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }




        public void getsum()
        {
            int sum = 0;
            for(int i=0;i<dataGridView1.Rows.Count-1;i++)
            {

                sum += int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());

            }

            lbl_totalcap.Text = sum.ToString();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 1)
                {

                    int sl = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());

                    txt_factoryName.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                    txt_monthlycapacity.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                    lbl_pk.Text = sl.ToString();
                    btn_save.Text = "Update";
                }
            }
            catch (Exception)
            {

                throw;
            }

        }




        public Boolean validationcontrol()
        {
            Boolean sucess = false;

            if (txt_factoryName.Text == null || txt_factoryName.Text.Trim() == "")
            {
                MessageBox.Show("Enter Valid Factory Name");

                txt_factoryName.Focus();


            }


            else if (txt_monthlycapacity.Text == null || txt_monthlycapacity.Text.Trim() == "")
            {
                MessageBox.Show("Enter Monthly caapacity");

                txt_monthlycapacity.Focus();


            }
            else if (!isnumber(txt_monthlycapacity))
            {
                MessageBox.Show("Enter Monthly caapacity as Number Only");

                txt_monthlycapacity.Focus();
            }

            else
            {
                sucess = true;
            }


            return sucess;
        }



        public Boolean isnumber(TextBox txtbox)
        {
            Boolean sucess = false;
            try
            {

                float ppt = float.Parse(txtbox.Text);
                sucess = true;
            }
            catch
            {
                sucess = true;
            }

            return sucess;
        }

        public void addnewfactory()
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            Factory_Master fctrymaster = new Factory_Master();
            fctrymaster.Factory_name = txt_factoryName.Text.Trim();
            fctrymaster.MonthlyCapacity = int.Parse(txt_monthlycapacity.Text);
            fctrymaster.IsActive = "Y";
            couriercontext.Factory_Masters.InsertOnSubmit(fctrymaster);

            couriercontext.SubmitChanges();

        }

        public void showexistinguser()
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);

            var q = from cust in couriercontext.Factory_Masters
                    select cust;
            dataGridView1.DataSource = q;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            getsum();
        }



        public void clearcontrol()
        {

            txt_factoryName.Text = "";
            txt_monthlycapacity.Text = "";
            btn_save.Text = "Save";
            lbl_pk.Text = "0";

        }


        public void deletefactory(int factoryid)
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var removegroup = from factory in couriercontext.Factory_Masters
                              where factory.Factory_ID == factoryid
                              select factory;
            couriercontext.Factory_Masters.DeleteAllOnSubmit(removegroup);
            couriercontext.SubmitChanges();
        }


        public void updatefactory(int factoryid)
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var updategrp = from factory in couriercontext.Factory_Masters
                            where factory.Factory_ID == factoryid
                            select factory;
            foreach (var v in updategrp)
            {
                v.Factory_name = txt_factoryName.Text;
                v.MonthlyCapacity = int.Parse(txt_monthlycapacity.Text);
                couriercontext.SubmitChanges();
            }


        }
    
    
    
    
    
    
    }
}
