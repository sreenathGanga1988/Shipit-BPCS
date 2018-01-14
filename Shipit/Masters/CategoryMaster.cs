using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shipit
{
    public partial class CategoryMaster : Form
    {
        public CategoryMaster()
        {
            InitializeComponent();
            showcategory();
            LoadFactoryCombo();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (validationcontrol())
            {
                addcategory();
                showcategory();
                clearcontrol();
            }
        }



        public void showcategory()
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);

            var q = from cust in couriercontext.Category_Masters
                    select cust;
            dataGridView1.DataSource = q;
            
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
        public void clearcontrol()
        {

            txt_categoryName.Text = "";
            txt_pcsNum.Text = "";
        }

        public Boolean validationcontrol()
        {
            Boolean sucess = false;

            if (txt_categoryName.Text == null || txt_categoryName.Text.Trim() == "")
            {
                MessageBox.Show("Enter Category Name");

                txt_categoryName.Focus();


            }


            else if (txt_pcsNum.Text == null || txt_pcsNum.Text.Trim() == "")
            {
                MessageBox.Show("Enter Monthly caapacity");

                txt_pcsNum.Focus();


            }
            else if (!isnumber(txt_pcsNum ))
            {
                MessageBox.Show("Enter Pcs PerlIne");

                txt_pcsNum.Focus();
            }

            else
            {
                sucess = true;
            }


            return sucess;
        }
        public void addcategory()
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
           Category_Master cmstr=new Category_Master ();
           cmstr.CategoryName  = txt_categoryName .Text.Trim();
           cmstr.PcsPerline  = int.Parse(txt_pcsNum .Text);

           couriercontext.Category_Masters.InsertOnSubmit(cmstr);

            couriercontext.SubmitChanges();

        }



        public void ADDcategoryPercentage()
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            for (int i = 0; i < tbl_percentage.Rows.Count-1; i++)
            {
                FactoryPercentage fctper = new FactoryPercentage();
                fctper.FactoryID = int.Parse(cmb_factory.SelectedValue.ToString());
                fctper.CategoryID = int.Parse(tbl_percentage.Rows[i].Cells[1].Value.ToString());
                fctper.Percentage = int.Parse(tbl_percentage.Rows[i].Cells[3].Value.ToString());
                fctper.Is_Active = "Y";
                fctper.AddedDate = DateTime.Now;
                couriercontext.FactoryPercentages.InsertOnSubmit(fctper);

                couriercontext.SubmitChanges();

            }

        }
        public void ShowCategoryPercentage()
        {
            //          var query= from cust in couriercontext.Category_Masters
            //        select new { cust.CategoryIID, cust.CategoryName, cust.PcsPerline};

            // tbl_percentage.DataSource = query;
            //tbl_percentage.Columns.Add("manualcolumn", "Percentage");
           // tbl_percentage.DataSource = Getpercentagedata(int.Parse(cmb_factory.SelectedValue.ToString ()));
            DataTable dt = Getpercentagedata(int.Parse(cmb_factory.SelectedValue.ToString()));
            tbl_percentage.RowCount = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tbl_percentage.Rows.Add();

                tbl_percentage.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                tbl_percentage.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                tbl_percentage.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                tbl_percentage.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
            }

        }
        public void LoadFactoryCombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from fctry in courdatacontext.Factory_Masters
                    select fctry;



            cmb_factory.DataSource = q;
            cmb_factory.DisplayMember = "Factory_name";
            cmb_factory.ValueMember = "Factory_ID";
            //   Buyercombo.DataBind();



        }
        private void button2_Click(object sender, EventArgs e)
        {
            ShowCategoryPercentage();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (tbl_percentage.Rows.Count != 0)
            {
                if (cmb_factory.Text.Trim() != "")
                {
                    ADDcategoryPercentage();
                    ShowCategoryPercentage();
                    MessageBox.Show("Done");
                }



            }

            
        }






        public DataTable Getpercentagedata(int factoryid)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@" SELECT        Factory_Master.Factory_ID, Category_Master.CategoryIID, Category_Master.CategoryName, FactoryPercentage.Percentage
FROM            FactoryPercentage INNER JOIN
                         Category_Master ON FactoryPercentage.CategoryID = Category_Master.CategoryIID INNER JOIN
                         Factory_Master ON FactoryPercentage.FactoryID = Factory_Master.Factory_ID
WHERE        (Factory_Master.Factory_ID = @factoryid)", con);



                cmd.Parameters.AddWithValue("@factoryid", factoryid);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);


                if (dt.Rows.Count < 1)
                {

                    SqlCommand cmd1 = new SqlCommand(@"SELECT     '0' as factoryline,   CategoryIID, CategoryName,'0' as Percentage
FROM            Category_Master", con);

                    cmd1.Parameters.AddWithValue("@factoryid", factoryid);
                    SqlDataReader rdr1 = cmd1.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(rdr1);
                }




            }
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }


    
    
    }
}
