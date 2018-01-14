using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shipit.DataModels;
namespace Shipit.Merchandising
{
    public partial class ASQCreator : Form
    {
        public ASQCreator()
        {
            InitializeComponent();

            if (Program.LogType == "Office")
            {
                fillAtc();
            }
            else
            {
                fillonlineAtc();
            }

        }
        public void fillAtc()
        {
            using (ArtEntities enty = new ArtEntities())
            {

                var PoQuery = from atcmst in enty.AtcMasters
                              select new
                              {
                                  name = atcmst.AtcNum,
                                  pk = atcmst.AtcId
                              };
                cmb_atc.DataSource = PoQuery.ToList();
                cmb_atc.DisplayMember = "name";
                cmb_atc.ValueMember = "pk";


            }
        }

        public void fillonlineAtc()
        {
            using (ArtEntities enty = new ArtEntities("D"))
            {

                var PoQuery = from atcmst in enty.AtcMasters
                              select new
                              {
                                  name = atcmst.AtcNum,
                                  pk = atcmst.AtcId
                              };
                cmb_atc.DataSource = PoQuery.ToList();
                cmb_atc.DisplayMember = "name";
                cmb_atc.ValueMember = "pk";


            }
        }


        public void fillOurstyle()
        {
            using (ArtEntities enty = new ArtEntities())
            {
                int atcid=int.Parse (cmb_atc.SelectedValue.ToString ());

                var PoQuery = from atcmst in enty.AtcDetails
                              where atcmst.AtcId == atcid
                              select new
                              {
                                  name = atcmst.OurStyle,
                                  pk = atcmst.OurStyleID
                              };
                cmb_ourstyle.DataSource = PoQuery.ToList();
                cmb_ourstyle.DisplayMember = "name";
                cmb_ourstyle.ValueMember = "pk";


            }
        }
        public void fillonlineOurstyle()
        {
            using (ArtEntities enty = new ArtEntities("D"))
            {
                int atcid = int.Parse(cmb_atc.SelectedValue.ToString());

                var PoQuery = from atcmst in enty.AtcDetails
                              where atcmst.AtcId == atcid
                              select new
                              {
                                  name = atcmst.OurStyle,
                                  pk = atcmst.OurStyleID
                              };
                cmb_ourstyle.DataSource = PoQuery.ToList();
                cmb_ourstyle.DisplayMember = "name";
                cmb_ourstyle.ValueMember = "pk";


            }
        }




        public DataTable createdatatableofatcid(int atcid)
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt.Columns.Add("Color", typeof(String));
            using (ArtEntities enty = new ArtEntities())
            {


                var sizedetails = (from size in enty.StyleSizes
                                   join atcdet in enty.AtcDetails on size.OurStyleID equals atcdet.OurStyleID
                                   where atcdet.AtcId == atcid
                                   select new
                                   {
                                       size.SizeName
                                   }).Distinct();

                foreach (var sizedet in sizedetails)
                {
                    dt.Columns.Add(sizedet.SizeName.Trim(), typeof(String));
                }





                var Colordetails = (from color in enty.StyleColors
                                    join atcdet in enty.AtcDetails on color.OurStyleID equals atcdet.OurStyleID
                                    where atcdet.AtcId == atcid
                                    select new
                                    {
                                        color.GarmentColor
                                    }).Distinct();

                foreach (var colordet in Colordetails)
                {
                    dt.Rows.Add();
                    dt.Rows[i]["Color"] = colordet.GarmentColor;
                    i++;


                }


                if (dt != null)
                {

                    var popackdetail = (from popackdetails in enty.POPackDetails
                                        join pakmstr in enty.PoPackMasters on popackdetails.POPackId equals pakmstr.PoPackId
                                        join atcmstr in enty.AtcDetails  on popackdetails.OurStyleID equals atcmstr.OurStyleID
                                        where atcmstr.AtcId == atcid
                                        group popackdetails by new { popackdetails.ColorName, popackdetails.SizeName } into grp

                                        select new
                                        {
                                            grp.Key.ColorName,
                                            grp.Key.SizeName,


                                            Quantity = grp.Sum(popackdetails => popackdetails.PoQty)

                                        }).ToList();

                    if (dt.Rows.Count >= 1)
                    {


                        for (int rowcount = 0; rowcount < dt.Rows.Count; rowcount++)
                        {
                            String Colorname = dt.Rows[rowcount]["Color"].ToString().Trim();
                            for (int coloumncount = 1; coloumncount < dt.Columns.Count; coloumncount++)
                            {
                                String Sizename = dt.Columns[coloumncount].ColumnName.ToString().Trim();


                                var styleqty = popackdetail.Where(u => u.ColorName == Colorname && u.SizeName == Sizename).Select(u => u.Quantity ?? 0).Sum();
                                dt.Rows[rowcount][coloumncount] = styleqty;

                            }

                        }

                    }

                }



            }



            dt = CalculateRowsum(dt);
            dt = CalculateColumnsum(dt);
            return dt;
        }



        public DataTable createdatatableodourstyleid(int ourstyleidd)
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt.Columns.Add("Color", typeof(String));
            using (ArtEntities enty = new ArtEntities())
            {


                var sizedetails = (from size in enty.StyleSizes
                                   join atcdet in enty.AtcDetails on size.OurStyleID equals atcdet.OurStyleID
                                   where atcdet.OurStyleID == ourstyleidd
                                   select new
                                   {
                                       size.SizeName
                                   }).Distinct();

                foreach (var sizedet in sizedetails)
                {
                    dt.Columns.Add(sizedet.SizeName.Trim(), typeof(String));
                }





                var Colordetails = (from color in enty.StyleColors
                                    join atcdet in enty.AtcDetails on color.OurStyleID equals atcdet.OurStyleID
                                    where atcdet.OurStyleID == ourstyleidd
                                    select new
                                    {
                                        color.GarmentColor
                                    }).Distinct();

                foreach (var colordet in Colordetails)
                {
                    dt.Rows.Add();
                    dt.Rows[i]["Color"] = colordet.GarmentColor;
                    i++;


                }


                if (dt != null)
                {

                    var popackdetail = (from popackdetails in enty.POPackDetails
                                        join pakmstr in enty.PoPackMasters on popackdetails.POPackId equals pakmstr.PoPackId
                                        join atcmstr in enty.AtcDetails on popackdetails.OurStyleID equals atcmstr.OurStyleID
                                        where atcmstr.OurStyleID == ourstyleidd
                                        group popackdetails by new { popackdetails.ColorName, popackdetails.SizeName } into grp

                                        select new
                                        {
                                            grp.Key.ColorName,
                                            grp.Key.SizeName,


                                            Quantity = grp.Sum(popackdetails => popackdetails.PoQty)

                                        }).ToList();

                    if (dt.Rows.Count >= 1)
                    {


                        for (int rowcount = 0; rowcount < dt.Rows.Count; rowcount++)
                        {
                            String Colorname = dt.Rows[rowcount]["Color"].ToString().Trim();
                            for (int coloumncount = 1; coloumncount < dt.Columns.Count; coloumncount++)
                            {
                                String Sizename = dt.Columns[coloumncount].ColumnName.ToString().Trim();


                                var styleqty = popackdetail.Where(u => u.ColorName == Colorname && u.SizeName == Sizename).Select(u => u.Quantity ?? 0).Sum();
                                dt.Rows[rowcount][coloumncount] = styleqty;

                            }

                        }

                    }

                }



            }



            dt = CalculateRowsum(dt);
            dt = CalculateColumnsum(dt);
            return dt;
        }



        public DataTable createdatatableofatcidONLine(int atcid)
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt.Columns.Add("Color", typeof(String));
            using (ArtEntities enty = new ArtEntities("D"))
            {


                var sizedetails = (from size in enty.StyleSizes
                                   join atcdet in enty.AtcDetails on size.OurStyleID equals atcdet.OurStyleID
                                   where atcdet.AtcId == atcid
                                   select new
                                   {
                                       size.SizeName
                                   }).Distinct();

                foreach (var sizedet in sizedetails)
                {
                    dt.Columns.Add(sizedet.SizeName.Trim(), typeof(String));
                }





                var Colordetails = (from color in enty.StyleColors
                                    join atcdet in enty.AtcDetails on color.OurStyleID equals atcdet.OurStyleID
                                    where atcdet.AtcId == atcid
                                    select new
                                    {
                                        color.GarmentColor
                                    }).Distinct();

                foreach (var colordet in Colordetails)
                {
                    dt.Rows.Add();
                    dt.Rows[i]["Color"] = colordet.GarmentColor;
                    i++;


                }


                if (dt != null)
                {

                    var popackdetail = (from popackdetails in enty.POPackDetails
                                        join pakmstr in enty.PoPackMasters on popackdetails.POPackId equals pakmstr.PoPackId
                                        join atcmstr in enty.AtcDetails on popackdetails.OurStyleID equals atcmstr.OurStyleID
                                        where atcmstr.AtcId == atcid
                                        group popackdetails by new { popackdetails.ColorName, popackdetails.SizeName } into grp

                                        select new
                                        {
                                            grp.Key.ColorName,
                                            grp.Key.SizeName,


                                            Quantity = grp.Sum(popackdetails => popackdetails.PoQty)

                                        }).ToList();

                    if (dt.Rows.Count >= 1)
                    {


                        for (int rowcount = 0; rowcount < dt.Rows.Count; rowcount++)
                        {
                            String Colorname = dt.Rows[rowcount]["Color"].ToString().Trim();
                            for (int coloumncount = 1; coloumncount < dt.Columns.Count; coloumncount++)
                            {
                                String Sizename = dt.Columns[coloumncount].ColumnName.ToString().Trim();


                                var styleqty = popackdetail.Where(u => u.ColorName == Colorname && u.SizeName == Sizename).Select(u => u.Quantity ?? 0).Sum();
                                dt.Rows[rowcount][coloumncount] = styleqty;

                            }

                        }

                    }

                }



            }



            dt = CalculateRowsum(dt);
            dt = CalculateColumnsum(dt);
            return dt;
        }



        public DataTable createdatatableodourstyleidonline(int ourstyleidd)
        {
            DataTable dt = new DataTable();
            int i = 0;
            dt.Columns.Add("Color", typeof(String));
            using (ArtEntities enty = new ArtEntities("D"))
            {


                var sizedetails = (from size in enty.StyleSizes
                                   join atcdet in enty.AtcDetails on size.OurStyleID equals atcdet.OurStyleID
                                   where atcdet.OurStyleID == ourstyleidd
                                   select new
                                   {
                                       size.SizeName
                                   }).Distinct();

                foreach (var sizedet in sizedetails)
                {
                    dt.Columns.Add(sizedet.SizeName.Trim(), typeof(String));
                }





                var Colordetails = (from color in enty.StyleColors
                                    join atcdet in enty.AtcDetails on color.OurStyleID equals atcdet.OurStyleID
                                    where atcdet.OurStyleID == ourstyleidd
                                    select new
                                    {
                                        color.GarmentColor
                                    }).Distinct();

                foreach (var colordet in Colordetails)
                {
                    dt.Rows.Add();
                    dt.Rows[i]["Color"] = colordet.GarmentColor;
                    i++;


                }


                if (dt != null)
                {

                    var popackdetail = (from popackdetails in enty.POPackDetails
                                        join pakmstr in enty.PoPackMasters on popackdetails.POPackId equals pakmstr.PoPackId
                                        join atcmstr in enty.AtcDetails on popackdetails.OurStyleID equals atcmstr.OurStyleID
                                        where atcmstr.OurStyleID == ourstyleidd
                                        group popackdetails by new { popackdetails.ColorName, popackdetails.SizeName } into grp

                                        select new
                                        {
                                            grp.Key.ColorName,
                                            grp.Key.SizeName,


                                            Quantity = grp.Sum(popackdetails => popackdetails.PoQty)

                                        }).ToList();

                    if (dt.Rows.Count >= 1)
                    {


                        for (int rowcount = 0; rowcount < dt.Rows.Count; rowcount++)
                        {
                            String Colorname = dt.Rows[rowcount]["Color"].ToString().Trim();
                            for (int coloumncount = 1; coloumncount < dt.Columns.Count; coloumncount++)
                            {
                                String Sizename = dt.Columns[coloumncount].ColumnName.ToString().Trim();


                                var styleqty = popackdetail.Where(u => u.ColorName == Colorname && u.SizeName == Sizename).Select(u => u.Quantity ?? 0).Sum();
                                dt.Rows[rowcount][coloumncount] = styleqty;

                            }

                        }

                    }

                }



            }



            dt = CalculateRowsum(dt);
            dt = CalculateColumnsum(dt);
            return dt;
        }



        public DataTable CalculateRowsum(DataTable dt)
        {
            dt.Columns.Add("ColorTotal", typeof(float));
             for (int i = 0; i < dt.Rows.Count; i++)
            { float sumofcolor=0;
           
             for (int j = 1; j < dt.Columns.Count-1; j++)
             {
                 sumofcolor = sumofcolor + float.Parse(dt.Rows[i][j].ToString());

             }
             dt.Rows[i]["ColorTotal"] = sumofcolor;
             }
            return dt;
        }




        public DataTable CalculateColumnsum(DataTable dt)
        {
           


            dt.Rows.Add();

            int lastrow = dt.Rows.Count - 1;
            dt.Rows[lastrow][0] = "SIZE TOTAL";
            for (int j = 1; j < dt.Columns.Count ; j++)
            {
                float sumofcolor = 0;
                for (int i = 0; i < lastrow; i++)
            {
                

                
                    sumofcolor = sumofcolor + float.Parse(dt.Rows[i][j].ToString());

            }
               dt.Rows [lastrow][j]=sumofcolor;
            }



            return dt;
        }







        private void button3_Click(object sender, EventArgs e)
        {
            if (Program.LogType == "Office")
            {
                fillOurstyle();
                dataGridView1.DataSource = null;
                DataTable dt = createdatatableofatcid(int.Parse(cmb_atc.SelectedValue.ToString()));
                dataGridView1.DataSource = dt;
            }
            else
            {
                fillonlineOurstyle();
                dataGridView1.DataSource = null;
                DataTable dt = createdatatableofatcidONLine(int.Parse(cmb_atc.SelectedValue.ToString()));
                dataGridView1.DataSource = dt;
            }
           
           

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Program.LogType == "Office")
            {
                dataGridView1.DataSource = null;
                DataTable dt = createdatatableodourstyleid(int.Parse(cmb_ourstyle.SelectedValue.ToString()));
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = null;
                DataTable dt = createdatatableodourstyleidonline(int.Parse(cmb_ourstyle.SelectedValue.ToString()));
                dataGridView1.DataSource = dt;
            }
           
        }

        private void btn_showatcasq_Click(object sender, EventArgs e)
        {
            Merchandisingreport rpt = new Merchandisingreport(int.Parse(cmb_atc.SelectedValue.ToString()),"atc");

            rpt.Show ();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Merchandisingreport rpt = new Merchandisingreport(int.Parse(cmb_ourstyle.SelectedValue.ToString()), "ourstyle");

            rpt.Show();
        }

    }
}
