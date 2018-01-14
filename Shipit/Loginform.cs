﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Shipit.Properties;
using System.Net.NetworkInformation;
namespace Shipit
{
    public partial class Loginform : Form
    {
        public Loginform()
        {
            InitializeComponent();
            isinlan();
        }




        public void getuserlocation(String username, String password)
        { int  lctnpk =0;
        int userid = 0;
            CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr);


            var q = from user in cntxt.UserMasters
                    where user.Username == username
                    select new
                    {
                        username = user.Username,

                        usertype = user.UserType,

                        userid = user.userID,
                    };
            foreach (var element in q)
            {
                Program.userpk = int.Parse(element.userid.ToString());
                Program.uername = element.username.ToString();
                Program.UserType = element.usertype.ToString().Trim();
            }


            var q1 = from user in cntxt.UserMasters
                     join fc in cntxt.Factory_Masters on user.LctnPK equals fc.Factory_ID
                     where user.Username == username
                      select new
                               {
                                   
                                   factoryname = fc.Factory_name,
                               
                                   locationpk = fc.Factory_ID ,
                                   
                                  
                               };

              foreach (var element in q1)
            {
                Program.lctnpk = int.Parse ( element.locationpk.ToString());
               
            Program.LogLocation = element.factoryname.ToString();
           
              }

            //var q=  from user in cntxt.UserMasters 
            //        where user.Username==username && user.Password ==password 
            //        select user;
            //foreach (var item in q)
            //{
            //    username = item.Username;
            //    lctnpk = int.Parse ( item.LctnPK .ToString());
            //    userid = int.Parse(item.userID .ToString());
            //}

           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (cmb_usertype.Text.Trim() != "")
            {
                if (cmb_usertype.Text.Trim() == "Remote")
                {
                    Program.ConnStr = Settings.Default.webstring;
                    Program.OurLogSource = Settings.Default.Remotelog;
                    Program.ArtConnStr = Settings.Default.WebARTConnectionString;
                    Program.OrgConnStr = Settings.Default.WebOrginconnectionString;
                }
                else if (cmb_usertype.Text.Trim() == "Training")
                {
                    Program.ConnStr = Settings.Default.teststring;
                    Program.OurLogSource = Settings.Default.Remotelog;
                }
                else
                {
                    Program.ConnStr = Settings.Default.CourierDetailsConnectionString;
                    Program.OurLogSource = Settings.Default.Officelog;
                    Program.ArtConnStr = Settings.Default.ArtConnectionString;
                    Program.OrgConnStr = Settings.Default.OrginconnectionString;
                }

                String username = txt_name.Text.Trim();
                String password = txt_password.Text.Trim();
                try
                {
                    if (isuserpresent(username, password))
                    {
                        this.Hide();
                        Program.uername = username;
                        Program.LogType = cmb_usertype.Text.Trim();
                        getuserlocation(username, password);
                        Mainform frm = new Mainform();


                        frm.Show();
                        frm.WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        MessageBox.Show(" You are not Authorised ", " Check the credential");
                    }
                }
                catch (Exception )
                {
                    
                   MessageBox.Show(" Please check your usage type Or Contact IT ", " NO Database connection");
                }
            }
            else
            {
                MessageBox.Show(" Select Office if you are in Atraco Dubai "," Select the usage Type ");
            }
        }



        public Boolean isuserpresent(String username, String password)
        {
            Boolean present = true;

            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                con.Open();

                String qry1 = " SELECT       Count(userID) FROM UserMaster WHERE        (Username = @Param1) AND (Password = @Param2)";
                SqlCommand cmd1 = new SqlCommand(qry1, con);
                cmd1.Parameters.AddWithValue("@Param1", username);
                cmd1.Parameters.AddWithValue("@Param2", password);

                int result = int.Parse(cmd1.ExecuteScalar().ToString());

                if (result == 0)
                {
                    present = false;
                }
                else
                {
                    present = true;
                }

                con.Close();
                
            }
            return present;
        }










        public void isinlan()
        {
            var ping = new Ping();
            var options = new PingOptions { DontFragment = true };

            //just need some data. this sends 10 bytes.
            var buffer = Encoding.ASCII.GetBytes(new string('z', 10));
            var host = "192.168.1.8";

            try
            {
                var reply = ping.Send(host, 60, buffer, options);
                if (reply == null)
                {
                    MessageBox.Show("Reply was null");
                   
                }

                if (reply.Status == IPStatus.Success)
                {
                    cmb_usertype.SelectedIndex = cmb_usertype.FindString("Office");
                  
                }
                else
                {
                    cmb_usertype.SelectedIndex = cmb_usertype.FindString("Remote");
                }
            }
            catch (Exception )
            {
                MessageBox.Show(" Please check your usage type Or Contact IT ", " NO Database connection");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}