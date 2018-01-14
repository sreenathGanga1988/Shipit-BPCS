using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shipit.Administrator
{
    public partial class Usermasterfrm : Form
    {
        public Usermasterfrm()
        {
            InitializeComponent();
            LoadFactoryCombo();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void LoadFactoryCombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from fctry in courdatacontext.Factory_Masters
                    select fctry;



            txt_factory.DataSource = q;
            txt_factory.DisplayMember = "Factory_name";
            txt_factory.ValueMember = "Factory_ID";
          //  cmb_factory.SelectedValue = Program.lctnpk;
            //   Buyercombo.DataBind();



        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
              CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            UserMaster  ustmstr = new UserMaster ();
            ustmstr.Username = txt_username.Text.Trim();
            ustmstr.Password = txt_password.Text;
            ustmstr.EmailID = txt_email .Text.Trim();
            ustmstr.UserType  =txt_usertype .Text;

            ustmstr.LctnPK = int.Parse(txt_factory.SelectedValue.ToString());
            couriercontext.UserMasters .InsertOnSubmit(ustmstr);

            couriercontext.SubmitChanges();
            MessageBox.Show("Sucess");

        }
    }
}
