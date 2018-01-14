using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.Masters
{
    public partial class Stylemaster : Form
    {
        public Stylemaster()
        {
            InitializeComponent();
            loadgrid();
            loadbuyercombo();
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


        public void loadgrid()
        {

            using (CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr))
            {
                var q = from buyerstyle in cntxt.BuyerStyleMasters
                        join buyermstr in cntxt.Buyer_Masters
                        on buyerstyle.BuyerID equals buyermstr.Buyer_Id
                        select new
                        {

                            buyerstyle.BuyerStyle,
                            buyermstr.BuyerName,
                            buyerstyle.Addeddate,
                            buyerstyle.AddedBy
                        };

                ultraGrid1.DataSource = q;

            }

        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            addnewStyle();
            loadgrid();

        }
        public void addnewStyle()
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            BuyerStyleMaster buyerstyle = new BuyerStyleMaster();

            buyerstyle.BuyerStyle = txt_buyerstyle.Text.Trim();
            buyerstyle.BuyerID = int.Parse(Buyercombo.SelectedValue.ToString());
            buyerstyle.Addeddate = DateTime.Now;
            buyerstyle.AddedBy= Program.uername;
            couriercontext.BuyerStyleMasters.InsertOnSubmit(buyerstyle);
            couriercontext.SubmitChanges();

        }



       

    }
}
