using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.Try
{
    public partial class SuperUserAuthenication : Form
    {
        public SuperUserAuthenication()
        {
            InitializeComponent();
            // set this.FormBorderStyle to None here if needed
            // if set to none, make sure you have a way to close the form!
        }
      


        Boolean isauthenicated = false;

        public Boolean Isauthenicated
        {
            get { return isauthenicated; }
            set { isauthenicated = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String[] SuperUser = { "boss","sanboss","atradmin" };
            if (SuperUser.Contains(txt_user.Text.Trim ()))
            {
                isauthenicated = true;
                this.Close();
            }
            else
            {
                isauthenicated = false;
                MessageBox.Show("Not Authenicated User");
            }
        }
    }
}
