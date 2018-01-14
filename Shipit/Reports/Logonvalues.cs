using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shipit.Reports
{
    static class Logonvalues
    {
     
        public static String OurReportSource = @"\\it-dept\Project\ShipITReports";
        
        public static String database = "CourierDetails";
        public static String Server = @"192.168.1.4";
        public static String dbUsername = "sa";
        public static String dbPassword = "Sreenath@123";
        public static  ReportDocument getpeport(String ReportLocation)
        {
            ConnectionInfo crconnectioninfo = new ConnectionInfo();
            ReportDocument cryrpt = new ReportDocument();
            TableLogOnInfos crtablelogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtablelogoninfo = new TableLogOnInfo();

            Tables CrTables;

           
            cryrpt.Load(ReportLocation);
            cryrpt.DataSourceConnections.Clear();
            //crconnectioninfo.ServerName = "SREENATH-IT\\SQLEXPRESS";
            //crconnectioninfo.DatabaseName = "ATCHRM";
            //crconnectioninfo.UserID = "sa";
            //crconnectioninfo.Password = "sreenath";

            if (Program.LogType == "Office")
            {
                crconnectioninfo.ServerName = Server;
            }else
            {
                crconnectioninfo.ServerName = Program.publicip;
            }
           
            crconnectioninfo.DatabaseName = database;
            crconnectioninfo.UserID = dbUsername;
            crconnectioninfo.Password = dbPassword;



            CrTables = cryrpt.Database.Tables;

            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtablelogoninfo = CrTable.LogOnInfo;
                crtablelogoninfo.ConnectionInfo = crconnectioninfo;
                CrTable.ApplyLogOnInfo(crtablelogoninfo);
            }

            return cryrpt;
        }
    }


    static class ARTLogonvalues
    {

        public static String OurReportSource = @"\\it-dept\Project\ShipITReports";

        public static String database = "Art";
        public static String Server = @"192.168.1.4";
        public static String dbUsername = "sa";
        public static String dbPassword = "Sreenath@123";
        public static ReportDocument getpeport(String ReportLocation)
        {
            ConnectionInfo crconnectioninfo = new ConnectionInfo();
            ReportDocument cryrpt = new ReportDocument();
            TableLogOnInfos crtablelogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtablelogoninfo = new TableLogOnInfo();

            Tables CrTables;


            cryrpt.Load(ReportLocation);
            cryrpt.DataSourceConnections.Clear();
            //crconnectioninfo.ServerName = "SREENATH-IT\\SQLEXPRESS";
            //crconnectioninfo.DatabaseName = "ATCHRM";
            //crconnectioninfo.UserID = "sa";
            //crconnectioninfo.Password = "sreenath";

            if (Program.LogType == "Office")
            {
                crconnectioninfo.ServerName = Server;
            }
            else
            {

                crconnectioninfo.ServerName = Program.publicip;
            }

            crconnectioninfo.DatabaseName = database;
            crconnectioninfo.UserID = dbUsername;
            crconnectioninfo.Password = dbPassword;



            CrTables = cryrpt.Database.Tables;

            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtablelogoninfo = CrTable.LogOnInfo;
                crtablelogoninfo.ConnectionInfo = crconnectioninfo;
                CrTable.ApplyLogOnInfo(crtablelogoninfo);
            }

            return cryrpt;
        }
    }

}
