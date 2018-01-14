using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipit.Transaction
{
    class AtracoCalaender
    {

        public int getmonthname(string month)
        {
            int monthnum = 0;


            switch (month.Trim())
            {
                case "January":
                    monthnum = 1;
                    break;

                case "February":
                    monthnum = 2;
                    break;
                case "March":
                    monthnum = 3;
                    break;

                case "April":
                    monthnum = 4;
                    break;

                case "May":
                    monthnum = 5;
                    break;

                case "June":
                    monthnum = 6;
                    break;
                case "July":
                    monthnum = 7;
                    break;
                case "August":
                    monthnum = 8;
                    break;

                case "September":
                    monthnum = 9;
                    break;

                case "October":
                    monthnum = 10;
                    break;
                case "November":
                    monthnum = 11;
                    break;
                case "December":
                    monthnum = 12;
                    break;

                default:
                    {
                        monthnum = 0;
                        break;
                    }




            }
            return monthnum;
        }



        public String getweeknumber(int i)
        {
            String Weeekno = "";

            if (i <= 7)
            {
                Weeekno = "Week1";

            }
            else if ((7 < i) && (i <= 14))
            {
                Weeekno = "Week2";

            }
            else if ((14 < i) && (i <= 21))
            {
                Weeekno = "Week3";

            }
            else if ((21 < i) && (i <= 28))
            {
                Weeekno = "Week4";

            }
            else if ((28 < i) && (i <= 32))
            {
                Weeekno = "Week5";

            }


            return Weeekno;
        }




        public DataTable correctweekday(DataTable dt)
        {
            int j = 0;
            if (dt.Rows[0][1].ToString().Trim() == "Sunday")
            {
                j = 0;
            }
            else
            {
                j = 1;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].ToString().Trim() == "Sunday")
                {
                    j = j + 1;

                }
                dt.Rows[i][3] = j;
                if (j == 1)
                {
                    dt.Rows[i][2] = "Week1";
                }
                else if (j == 2)
                {
                    dt.Rows[i][2] = "Week2";
                }
                else if (j == 3)
                {
                    dt.Rows[i][2] = "Week3";
                }
                else if (j == 4)
                {
                    dt.Rows[i][2] = "Week4";

                }
                else if (j == 5)
                {
                    dt.Rows[i][2] = "Week5";
                }
            }

            return dt;
        }






        public DataTable getdatesof(String Month, int Year, String Weeknumber)
        {
            int monthnum = getmonthname(Month);
            DateTime firstDayOfTheMonth = new DateTime(Year, monthnum, 1);
            DateTime endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

            DataTable calendertable = new DataTable();
            calendertable.Columns.Add("DateofWeek", typeof(string));
            calendertable.Columns.Add("DayofWeek", typeof(string));
            calendertable.Columns.Add("Weeknumber", typeof(string));

            calendertable.Columns.Add("Weeknumber1", typeof(string));

            var dates = new List<DateTime>();
            int i = 1;
            for (var dt = firstDayOfTheMonth; dt <= endDate; dt = dt.AddDays(1))
            {


                calendertable.Rows.Add(dt.ToString("dddd, dd MMMM yyyy"), dt.ToString("dddd"), 0);
                dates.Add(dt);
                i++;
            }
            calendertable = correctweekday(calendertable);
            return calendertable;
        }



        public DataTable GetDatesBetweenAPeriod(int Year, DateTime startdate, DateTime enddate)
        {


            DataTable calendertable = new DataTable();
            calendertable.Columns.Add("DateofWeek", typeof(string));
            calendertable.Columns.Add("DayofWeek", typeof(string));
            calendertable.Columns.Add("Weeknumber", typeof(string));
            calendertable.Columns.Add("Month", typeof(string));
            calendertable.Columns.Add("Year", typeof(string));
            var dates = new List<DateTime>();
            int i = 1;
            for (var dt = startdate; dt <= enddate; dt = dt.AddDays(1))
            {


                calendertable.Rows.Add(dt.ToString("dddd, dd MMMM yyyy"), dt.ToString("dddd"), 0);
                dates.Add(dt);
                i++;
            }
            calendertable = GetWeekNumberOfMonth(calendertable);
            return calendertable;
        }
        public DataTable GetWeekNumberOfMonth(DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DateTime date = DateTime.Parse(dt.Rows[i][0].ToString());
                //DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);
                //DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
                //if (firstMonthMonday > date)
                //{
                //    firstMonthDay = firstMonthDay.AddMonths(-1);
                //    firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
                //}
                //int k= (date - firstMonthMonday).Days / 7 + 1;


                int k = ExtensionClassforCalender.GetWeekOfMonth(date);

                dt.Rows[i][2] = "Week" + k.ToString();
                dt.Rows[i][3] = date.ToString("MMMM");
                dt.Rows[i][4] = date.Year.ToString();
            }

            return dt;
        }

        public Boolean isChangeOK(String Month, int Year, String Weeknumber, DateTime PSD, DateTime Actualdeliverydate)
        {
            Boolean isChangeOK = false;

            DataTable dt = GetDatesBetweenAPeriod(Year, PSD, Actualdeliverydate);

            if (dt.Rows.Count > 0)
            {
                DataRow[] result = dt.Select("Year = " + Year + " AND Month= '" + Month + "'and Weeknumber='"+Weeknumber +"'");
                if(result.Length>0)
                {
                    isChangeOK = true;
                }

            }
            return isChangeOK;
        }




    }

    static class ExtensionClassforCalender
    {
        // public static int GetWeekNumber(this DateTime date)
        //{
        //    return GetWeekNumber(date, CultureInfo.CurrentCulture);
        //}

        // public static int GetWeekNumber(this DateTime date, CultureInfo culture)
        //{
        //    return culture.Calendar.GetWeekOfYear(date,
        //        culture.DateTimeFormat.CalendarWeekRule,
        //        culture.DateTimeFormat.FirstDayOfWeek);
        //}



        static GregorianCalendar _gc = new GregorianCalendar();
        public static int GetWeekOfMonth(this DateTime time)
        {
            DateTime first = new DateTime(time.Year, time.Month, 1);
            return time.GetWeekOfYear() - first.GetWeekOfYear() + 1;
        }

        static int GetWeekOfYear(this DateTime time)
        {
            return _gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }




    }








}
