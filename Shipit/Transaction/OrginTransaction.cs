using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Shipit.Transaction
{
    public static class OrginTransaction
    {

        public static float GetPOProducedQty(int lineid, int unitid, String PONUM)
        {
            float poproducedqty = 0;
            DataTable dt = new DataTable();





            using (SqlConnection con = new SqlConnection(Program.ArtConnStr))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(@"", con);


                cmd.Parameters.AddWithValue("@Param1", lineid);
                cmd.Parameters.AddWithValue("@Param1", unitid);
                cmd.Parameters.AddWithValue("@Param1", PONUM);

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);
            }


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        poproducedqty = float.Parse(dt.Rows[i]["POQty"].ToString());

                    }
                }


                
            }


            return poproducedqty;


        }
    }
}
