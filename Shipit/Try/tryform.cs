using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Shipit.Try
{
    public partial class tryform : Form
    {
         static String Consolidatedmssg = "";
         static String ConnStr = "Data Source=IT-DEPT\\MSSQLSERVERRAJ;Initial Catalog=CourierDetails;Persist Security Info=True;User ID=sa;Password=sreenath";
        public tryform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LastCloseDateofFactory();
        }

        public static void LastCloseDateofFactory()
        {
            DateTime today = DateTime.Now.Date;
            DataTable dt = new DataTable();
          
            String Datepend = "";
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                String q3 = @"SELECT        MAX(ProductionDayClose_tbl.DateofProd) AS Closedate, Factory_Master.Factory_name
FROM            ProductionDayClose_tbl INNER JOIN
                         Factory_Master ON ProductionDayClose_tbl.factid = Factory_Master.Factory_ID
GROUP BY ProductionDayClose_tbl.factid, Factory_Master.Factory_name";



                //  cmd.CommandText = Query1;
                cmd.CommandText = q3;

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Datepend = "";
                            DateTime closeddate = DateTime.Parse(dt.Rows[i]["Closedate"].ToString()).Date;

                            double daysUntilChristmas = today.Subtract(closeddate).TotalDays;

                            if (daysUntilChristmas > 1)
                            {
                                String factoryname = dt.Rows[i]["Factory_name"].ToString();
                                for (DateTime j = closeddate.AddDays(1); j < today; j = j.AddDays(1))
                                {
                                    if (Datepend == "")
                                    {
                                        Datepend = Datepend + j.ToString("dd/MM/yyyy");
                                    }
                                    else
                                    {
                                        Datepend = Datepend + " ****** " + j.ToString("dd/MM/yyyy");
                                    }

                                }

                                Dayspendingtoclose(factoryname, Datepend, closeddate.ToString("dd/MM/yyyy"));
                            }
                        }


                        DataTable dt1 = GetEmailAdress("ATR", "A", "Pending Report");
                       email23("Production Day Close Status", Consolidatedmssg, "ram_santhosh@atraco.ae", "User", "Production Notification", dt1);

                    }
                }

            }

        }


        public static DataTable  GetEmailAdress(String Factory,String Userlevel,String Reporttype)
        {
              
            DateTime today = DateTime.Now.Date;
            DataTable dt = new DataTable();
          
           
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                String q3 = @"SELECT        Factory_Name, Userlevel, ReportType, EmailGroup
FROM            EmailGroup_tbl
WHERE        (Factory_Name = @Param1) AND (Userlevel = @Param2) AND (ReportType = @Param3)";



               
                cmd.CommandText = q3;
                cmd.Parameters.AddWithValue("@Param1",Factory);
                cmd.Parameters.AddWithValue("@Param2", Userlevel);
                cmd.Parameters.AddWithValue("@Param3", Reporttype);
                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);
            }
            return dt;
        }
        public static void Dayspendingtoclose(String factoryname, String DateforClosing, String DayClosed)
        {
            String subject = "Production Entry Day Close Pending For " + factoryname + "  for Date " + DateforClosing;

            String body = "Production Entry Day Close Pending For " + factoryname + "  for Date " + DateforClosing + "  Last day Closed was " + DayClosed;


            if (factoryname == "AA2")
            {
           
            }
            else if (factoryname == "MA2")
            {

            }
            else if (factoryname == "MA3")
            {

            }
            else if (factoryname == "MA1")
            {

            }
            DataTable dt = GetEmailAdress(factoryname, "U", "Pending Report");

        //    email23(subject, body, "ram_santhosh@atraco.ae", "User", "Production Notification",dt);

          
            Consolidatedmssg = Consolidatedmssg + Environment.NewLine + body;
           
        }
        public static void email23(String subject, String body, String toadress, String toname, String Displayname,DataTable dt)
        {
            var fromAddress = new MailAddress("atracogen@gmail.com", Displayname);
            var toAddress = new MailAddress(toadress, toname);
           
            const string fromPassword = "8812686ba";


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress){Subject = subject, Body = body}
                
                
                
                
                )
            {
                for (int i = 0; i < dt.Rows.Count;i++ )
                {
                    message.CC.Add(dt.Rows[i]["EmailGroup"].ToString());
                }


                    
                


                smtp.Send(message);

            }
        }
    }
}
