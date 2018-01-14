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
    public partial class FactoryHolidays : Form
    {
        public FactoryHolidays()
        {
            InitializeComponent();
            loadbuyercombo();
        }


        public void loadbuyercombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from factory in courdatacontext.Factory_Masters
                    select factory;



            cmb_factory.DataSource = q;
            cmb_factory.DisplayMember = "Factory_name";
            cmb_factory.ValueMember = "Factory_ID";
            //   Buyercombo.DataBind();



        }


        public Boolean validationcontrol()
        {
            Boolean sucess = false;


            if (cmb_month.Text == null || cmb_month.Text.Trim() == "")
            {
                MessageBox.Show("Enter Month");

                txt_num.Focus();


            }

            else if (cmb_year.Text == null || cmb_year.Text.Trim() == "")
            {
                MessageBox.Show("Enter Year");

                cmb_year.Focus();


            }
            else   if (txt_num.Text == null || txt_num.Text.Trim() == "")
            {
                MessageBox.Show("Enter Number of Holidays");

                txt_num.Focus();


            }



            else if (!isnumber(txt_num))
            {
                MessageBox.Show("Enter Monthly Holiday as Number Only");

                txt_num.Focus();
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
        public void addnewholiday()
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            Factory_Holiday fctryhlday = new Factory_Holiday();
            fctryhlday.Year =int.Parse ( cmb_year.Text);
            fctryhlday.Month = cmb_month.Text;
            fctryhlday.Factory_ID = int.Parse(cmb_factory.SelectedValue.ToString());
            fctryhlday.LeaveNum = int.Parse(txt_num.Text);
            couriercontext.Factory_Holidays.InsertOnSubmit(fctryhlday);

            couriercontext.SubmitChanges();

        }



        public void showleaves()
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);


            var query = from e in couriercontext.Factory_Masters 
                        join d in couriercontext.Factory_Holidays  on e.Factory_ID equals d.Factory_ID
                        select new { e.Factory_ID, e.Factory_name, d.Month, d.Year, d.LeaveNum };
            dataGridView1.DataSource = query;
        }




        public void clearcontrol()
        {

            txt_num.Text = "";
            cmb_month .Text = "";
            cmb_year .Text = "Save";
          //  lbl_pk.Text = "0";

        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            if (validationcontrol())
            {
                if (btn_save.Text == "Save")
                {
                    addnewholiday();
                    showleaves();
                    clearcontrol();
                }
                else
                {
                   // updatefactory(int.Parse(lbl_pk.Text));
                    showleaves();
                    clearcontrol();
                }
            }
        }

        private void FactoryHolidays_Load(object sender, EventArgs e)
        {
            showleaves();
        }
    }
}
