using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shipit.Properties;

namespace Shipit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
       public static String ConnStr = Settings.Default.CourierDetailsConnectionString ;
       public static String ArtConnStr = Settings.Default.ArtConnectionString;
        public static String OrgConnStr = Settings.Default.OrginconnectionString;
        public static String uername = "asd";
       public static String emailid = "asd@";
        public static String LogType="Office";
        public static String UserType = "User";
        public static String LogLocation = "Atraco";
        public static String OurLogSource = "";
       public static int lctnpk = 0;
       public static int userpk = 0;
         //public string publicip="213.42.33.230"
       public static string publicip = "213.42.60.233";


       public static String OurReportSource = @"\\it-dept\Project\ShipITReports";
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new Loginform      ());
          // Application.Run(new Try.tryform());
        }
    }
}
