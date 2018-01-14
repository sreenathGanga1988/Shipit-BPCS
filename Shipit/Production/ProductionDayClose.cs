using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shipit.Production
{
    public partial class ProductionDayClose : Form
    {
       
        public ProductionDayClose()
        {
            InitializeComponent();
            LoadFactoryCombo();
        }
        public void LoadFactoryCombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from fctry in courdatacontext.Factory_Masters
                    select fctry;



            factorycombo .DataSource = q;
            factorycombo.DisplayMember = "Factory_name";
            factorycombo.ValueMember = "Factory_ID";
            //   Buyercombo.DataBind();



        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr))
            {
                var q = from daydetail in cntxt.ProductionDayClose_tbls
                        join factdetails in cntxt.Factory_Masters
                        on daydetail.factid equals factdetails.Factory_ID
                        where factdetails.Factory_ID == int.Parse(factorycombo.SelectedValue.ToString ())
                        select daydetail;

                ultraGrid1.DataSource = q;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
             using(   CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr))
             {
                 ProductionDayClose_tbl prdtbl= new ProductionDayClose_tbl ();
                 prdtbl.DateofProd = dtp_date.Value.Date;
                 prdtbl.factid = int.Parse(factorycombo.SelectedValue.ToString());
                 prdtbl.AddedBy = Program.uername;
                 prdtbl.AddedDate = DateTime.Now;
                  courdatacontext.ProductionDayClose_tbls.InsertOnSubmit(prdtbl);
                 courdatacontext.SubmitChanges();

                 sendnotification();
             }
                

            
        }


        public void sendnotification()
        {
            String FactoryName =factorycombo.Text.Trim();
            String Factid = factorycombo.SelectedValue.ToString ();
            String ClosedDate =dtp_date.Value.Date.ToString ();
           
            
            Transaction.ClsEmailer.DayClosedMail(FactoryName,Factid,ClosedDate);

        }

        private void openTheDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Program.uername=="admin")
            {
                DayCloseDeleter();
                MessageBox.Show("Day Opened");
            }
            else
            {
                MessageBox.Show("You are not Authorised :Contact ShipitDesk Dubai");
            }
        }

        public void DayCloseDeleter()
        {
            int dayid = int.Parse(ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["DayID"].Value.ToString());
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var q = from pa in couriercontext.ProductionDayClose_tbls
                    where pa.DayID == dayid
                    select pa;

            foreach (var detail in q)
            {
                couriercontext.ProductionDayClose_tbls.DeleteOnSubmit(detail);
            }

            try
            {
                couriercontext.SubmitChanges();
            }
            catch (Exception)
            {


            }

            MessageBox.Show("Done");

        }

    }
}
