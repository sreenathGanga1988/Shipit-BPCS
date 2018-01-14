using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Shipit.Transaction
{
    class Datatransaction
    {

        Transaction.DataTransaction DATTRAN = null;
        int k = 0;



        //public void getallnonapprovedentries()
        //{
        //    CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);

        //    var orderdetails = from c in couriercontext.OrderBooking_tbls
        //                       join b in couriercontext.Buyer_Masters on c.Buyer_ID equals b.Buyer_Id
        //                       join f in couriercontext.Factory_Masters on c.Factory_Id equals f.Factory_ID
        //                       where c.ISApproved != "Y" && c.UserId == Program.uername
        //                       select new
        //                       {
        //                           bookid = c.Order_id,
        //                           factoryname = f.Factory_name,
        //                           year = c.Year,
        //                           month = c.Month,
        //                           buyer = b.BuyerName,
        //                           style = c.Style,
        //                           qty = c.BookQty,

        //                       };
        //    int i = 0;
        //    foreach (var element in orderdetails)
        //    {

        //        int monthnum = DATTRAN.getmonthname(element.month);
        //        DateTime startdate = new DateTime(int.Parse((element.year).ToString()), monthnum, 1);
        //        DateTime datetoday = DateTime.Now.Date;

        //        if ((startdate - datetoday).TotalDays < 150)
        //        {
        //            //tbl_pending.Rows.Add();
        //            //tbl_pending.Rows[i].Cells[0].Value = element.factoryname;
        //            //tbl_pending.Rows[i].Cells[1].Value = element.year;
        //            //tbl_pending.Rows[i].Cells[2].Value = element.month;
        //            //tbl_pending.Rows[i].Cells[3].Value = element.buyer;
        //            //tbl_pending.Rows[i].Cells[4].Value = element.qty;
        //            //tbl_pending.Rows[i].Cells[5].Value = element.style;




        //            ++i;
        //        }
        //    }
          
        //}


      
        


    }
}
