using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Shipit
{
    public class QuantityCalcuulater
    {

        public int  calculatedata(int categoryid, int factoryid, int ordrqty)
        {

            float   avgqty = getaverageQty(factoryid);
            float  pcsperline = getPcperline(categoryid);

            float  consumpumtionqty = ordrqty;

            consumpumtionqty = (ordrqty * avgqty) / pcsperline;

            int myIntconsumption = (int)Math.Ceiling(consumpumtionqty);


            return myIntconsumption;
        }




        public float getaverageQty(int factoryid)
        {
            float  averageqty = 0;


            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(@"SELECT      (SUM(FactoryPercentage.Percentage * Category_Master.PcsPerline)/100) AS categoryproduction
FROM            FactoryPercentage INNER JOIN
                         Category_Master ON FactoryPercentage.CategoryID = Category_Master.CategoryIID
where    FactoryPercentage.FactoryID = @factoryid", con))
                    {
                        cmd.Parameters.AddWithValue("@factoryid", factoryid);
                        averageqty = float.Parse (cmd.ExecuteScalar().ToString ());
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }



            return averageqty;

        }

        public float getPcperline(int categoryid)
        {
            float  pcsperline = 0;


            using (SqlConnection con = new SqlConnection(Program.ConnStr))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(@"SELECT       ISNULL ( PcsPerline,0) FROM  Category_Master WHERE        (CategoryIID = @categoryid)", con))
                    {
                        cmd.Parameters.AddWithValue("@categoryid", categoryid);
                        pcsperline = float.Parse ( cmd.ExecuteScalar().ToString ());
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }



            return pcsperline;

        }
    
    
    }
}
