using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit
{
    public partial class DerReport : Form
    {
        Transaction.AtracoCalaender atcclndr = null;
        Transaction.ReportTransaction rpttran = null;
        DataTable dt = null;
        private List<string> MergedRowsInFirstColumn = new List<string>();
        public DerReport()
        {
            InitializeComponent();
            rpttran = new Transaction.ReportTransaction();
            atcclndr = new Transaction.AtracoCalaender();
            loadfactorycombo();
        }
        public void loadfactorycombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from factory in courdatacontext.Factory_Masters
                    select factory;



            cmb_factory.DataSource = q;
            cmb_factory.DisplayMember = "Factory_name";
            cmb_factory.ValueMember = "Factory_ID";
            //   Buyercombo.DataBind();



        }
        private void dailyEfficencyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = rpttran.GetSavedDERReport(dtp_from.Value.Date, dtp_to.Value.Date, cmb_factory.Text.Trim());

            DataTable datesavailable = atcclndr.GetDatesBetweenAPeriod(2005, dtp_from.Value.Date, dtp_to.Value.Date);

            gridviewDatesetup(datesavailable);
            gridviewLinesetup();
            calculateColumndata();
            Addsummary();
        }


        public void gridviewDatesetup(DataTable datedata)
        {
            tbl_derdata.RowCount = 0;
            tbl_derdata.ColumnCount = 3;
            if (datedata != null)
            {
                if (datedata.Rows.Count > 0)
                {
                    tbl_derdata.ColumnCount = tbl_derdata.ColumnCount + datedata.Rows.Count;
                    for (int i = 0; i < datedata.Rows.Count; i++)
                    {
                        tbl_derdata.Columns[i + 3].HeaderText = datedata.Rows[i][0].ToString();
                        tbl_derdata.Columns[i + 3].DefaultCellStyle.NullValue = "0";
                        tbl_derdata.Columns[i + 3].Name = datedata.Rows[i][0].ToString();
                    }
                }


            }
        }


        public void gridviewLinesetup()
        {
            int rowcount = 0;



            DataView lineview = new DataView(dt);
            lineview.Sort = "Linenum ASC";
            DataTable distinctlines = lineview.ToTable(true, "Linenum");

            for (int linecount = 0; linecount < distinctlines.Rows.Count; linecount++)
            {

                DataView lineatcview = new DataView(dt);
                lineatcview.RowFilter = "Linenum='" + distinctlines.Rows[linecount]["Linenum"].ToString().Trim() + "'";
                lineatcview.Sort = "Linenum ASC, Atcnum ASC";
                DataTable distinctValues = lineatcview.ToTable(true, "Linenum", "Atcnum");
                for (int j = 0; j < distinctValues.Rows.Count; j++)
                {
                    for (int m = 0; m < 5; m++)
                    {
                        tbl_derdata.Rows.Add();
                        tbl_derdata.Rows[rowcount].Cells["Line"].Value = distinctValues.Rows[j]["Linenum"].ToString();
                        tbl_derdata.Rows[rowcount].Cells["Atc"].Value = distinctValues.Rows[j]["Atcnum"].ToString();

                        tbl_derdata.Rows[rowcount].Cells["Details"].Value = DetailHeaderStringcreator(m);

                        rowcount++;
                    }

                }
                for (int m = 0; m < 5; m++)
                {
                    tbl_derdata.Rows.Add();
                    tbl_derdata.Rows[rowcount].Cells["Line"].Value = distinctlines.Rows[linecount]["Linenum"].ToString();
                    tbl_derdata.Rows[rowcount].Cells["Atc"].Value = "Total";
                    tbl_derdata.Rows[rowcount].DefaultCellStyle.BackColor = Color.CadetBlue;
                    tbl_derdata.Rows[rowcount].Cells["Details"].Value = DetailHeaderStringcreator(m);
                    rowcount++;
                }


            }





        }



        public String DetailHeaderStringcreator(int atcrownum)
        {
            String columnum = atcrownum.ToString();
            String Header = "";


            switch (columnum.Trim())
            {
                case "0":
                    Header = "PD QTY";
                    break;

                case "1":
                    Header = "PD % OF OB";
                    break;
                case "2":
                    Header = "BE % OF OB";
                    break;

                case "3":
                    Header = "BD BE QTY";
                    break;

                case "4":
                    Header = "BD $";
                    break;




                default:
                    {
                        Header = "";
                        break;
                    }
            }
            return Header;
        }




        public void calculateColumndata()
        {

            for (int j = 3; j < tbl_derdata.ColumnCount; j++)
            {
                DateTime datetoday = DateTime.Parse(tbl_derdata.Columns[j].HeaderText.ToString());
                try
                {
                    filldata(datetoday, j);
                }
                catch (Exception)
                {


                }
            }



        }


        public void filldata(DateTime datetoday, int columnnum)
        {


            DataTable proddata = dt.Select("DateOfProd='" + datetoday + "'").CopyToDataTable();
            for (int i = 0; i < tbl_derdata.Rows.Count; i++)
            {
                String linenum = tbl_derdata.Rows[i].Cells["Line"].Value.ToString().Trim();
                String Atc = tbl_derdata.Rows[i].Cells["Atc"].Value.ToString().Trim();
                String Detailsvalue = tbl_derdata.Rows[i].Cells["Details"].Value.ToString().Trim();
                if (Atc != "Total")
                {
                    try
                    {
                        if (Detailsvalue == "PD QTY")
                        {
                            try
                            {
                                object Sumproduced = proddata.Compute("Sum(TotalQty)", "Linenum ='" + linenum + "' and atcnum= '" + Atc + "'");
                                tbl_derdata.Rows[i].Cells[columnnum].Value = Sumproduced.ToString();
                            }
                            catch (Exception)
                            {
                                tbl_derdata.Rows[i].Cells[columnnum].Value = "0";

                            }
                        }
                        else if (Detailsvalue == "PD % OF OB")
                        {
                            try
                            {

                                object producedpercent = proddata.Compute("AVG(ProducedPercent)", "Linenum ='" + linenum + "' and atcnum= '" + Atc + "' ");
                                tbl_derdata.Rows[i].Cells[columnnum].Value = producedpercent.ToString();
                            }
                            catch (Exception)
                            {
                                tbl_derdata.Rows[i].Cells[columnnum].Value = "0";

                            }
                        }
                        else if (Detailsvalue == "BE % OF OB")
                        {
                            try
                            {

                                object producedpercent = proddata.Compute("AVG(BEPercentOB)", "Linenum ='" + linenum + "' and atcnum= '" + Atc + "' ");
                                if (producedpercent.ToString().Trim() != "")
                                {
                                    float bepercent = float.Parse(producedpercent.ToString());
                                    tbl_derdata.Rows[i].Cells[columnnum].Value = bepercent.ToString("0.00");
                                }
                                else
                                {
                                    tbl_derdata.Rows[i].Cells[columnnum].Value = producedpercent.ToString();
                                }


                            }
                            catch (Exception)
                            {
                                tbl_derdata.Rows[i].Cells[columnnum].Value = "0";

                            }
                        }


                        else if (Detailsvalue == "BD BE QTY")
                        {
                            try
                            {

                                object bdqty = proddata.Compute("Sum(BDqty)", "Linenum ='" + linenum + "' and atcnum= '" + Atc + "' ");
                                tbl_derdata.Rows[i].Cells[columnnum].Value = bdqty.ToString();
                            }
                            catch (Exception)
                            {
                                tbl_derdata.Rows[i].Cells[columnnum].Value = "0";

                            }
                        }
                        else if (Detailsvalue == "BD $")
                        {
                            try
                            {

                                object bddollor = proddata.Compute("Sum(BDDollor)", "Linenum ='" + linenum + "' and atcnum= '" + Atc + "' ");
                                tbl_derdata.Rows[i].Cells[columnnum].Value = bddollor.ToString();
                            }
                            catch (Exception)
                            {
                                tbl_derdata.Rows[i].Cells[columnnum].Value = "0";

                            }
                        }


                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    if (Detailsvalue == "PD QTY")
                    {
                        try
                        {
                            object Sumproduced = proddata.Compute("Sum(TotalQty)", "Linenum ='" + linenum + "' ");
                            tbl_derdata.Rows[i].Cells[columnnum].Value = Sumproduced.ToString();
                        }
                        catch (Exception)
                        {
                            tbl_derdata.Rows[i].Cells[columnnum].Value = "0";

                        }
                    }
                    else if (Detailsvalue == "PD % OF OB")
                    {
                        try
                        {
                            object Sumproduced = proddata.Compute("Sum(TotalQty)", "Linenum ='" + linenum + "' ");
                            object TargetProduction = proddata.Compute("Sum(TargetProduction)", "Linenum ='" + linenum + "' ");

                            if (Sumproduced.ToString().Trim() != "" && TargetProduction.ToString().Trim() != "")
                            {
                                float percent = (float.Parse(Sumproduced.ToString()) / float.Parse(TargetProduction.ToString())) * 100;
                                tbl_derdata.Rows[i].Cells[columnnum].Value = percent.ToString();
                            }
                        }
                        catch (Exception)
                        {
                            tbl_derdata.Rows[i].Cells[columnnum].Value = "0";

                        }
                    }
                    else if (Detailsvalue == "BD BE QTY")
                    {
                        try
                        {
                            object bdqty = proddata.Compute("Sum(BDqty)", "Linenum ='" + linenum + "' ");
                            tbl_derdata.Rows[i].Cells[columnnum].Value = bdqty.ToString();
                        }
                        catch (Exception)
                        {
                            tbl_derdata.Rows[i].Cells[columnnum].Value = "0";

                        }
                    }
                    else if (Detailsvalue == "BD $")
                    {
                        try
                        {
                            object bddollor = proddata.Compute("Sum(BDDollor)", " Linenum= '" + linenum + "' ");
                            tbl_derdata.Rows[i].Cells[columnnum].Value = bddollor.ToString();
                        }
                        catch (Exception)
                        {
                            tbl_derdata.Rows[i].Cells[columnnum].Value = "0";

                        }
                    }
                    else if (Detailsvalue == "BE % OF OB")
                    {
                        try
                        {

                            object producedpercent = proddata.Compute("AVG(BEPercentOB)", "Linenum ='" + linenum + "'  ");
                            if (producedpercent.ToString().Trim() != "")
                            {
                                float bepercent = float.Parse(producedpercent.ToString());
                                tbl_derdata.Rows[i].Cells[columnnum].Value = bepercent.ToString("0.00");
                            }
                            else
                            {
                                tbl_derdata.Rows[i].Cells[columnnum].Value = producedpercent.ToString();
                            }
                        }
                        catch (Exception)
                        {
                            tbl_derdata.Rows[i].Cells[columnnum].Value = "0";

                        }
                    }



                }
            }
        }



        public int addBottomFactorySummary()
        {
            int rowcount = tbl_derdata.Rows.Count;
            for (int m = 0; m < 5; m++)
            {
                tbl_derdata.Rows.Add();
                tbl_derdata.Rows[rowcount].Cells["Line"].Value = "All Lines";
                tbl_derdata.Rows[rowcount].Cells["Atc"].Value = "Total";
                tbl_derdata.Rows[rowcount].DefaultCellStyle.BackColor = Color.CadetBlue;
                tbl_derdata.Rows[rowcount].Cells["Details"].Value = DetailHeaderStringcreator(m);
                tbl_derdata.Rows[rowcount].DefaultCellStyle.BackColor = Color.OrangeRed;
                rowcount++;

            }
            return rowcount;
        }


        public void Addsummary()
        {
            


            //CREATE TOTAL SUMMARY OF FACTORY on bOTTOM

            int rowcount = addBottomFactorySummary();


            // create TOTAL ON RIGHT
            tbl_derdata.Columns.Add("Total", "Total");
            tbl_derdata.Columns["Total"].DefaultCellStyle.BackColor = Color.CadetBlue;

            for (int i = 0; i < tbl_derdata.Rows.Count; i++)
            {
                String linenum = tbl_derdata.Rows[i].Cells["Line"].Value.ToString().Trim();
                String Atc = tbl_derdata.Rows[i].Cells["Atc"].Value.ToString().Trim();
                String Detailsvalue = tbl_derdata.Rows[i].Cells["Details"].Value.ToString().Trim();


                // IF THE ROW TOTAL MEANS TOTAL OF ATC AND LINE

                # region rowsummary
                if (Atc != "Total" && linenum != "All Lines")
                {

                    DataTable proddata = dt.Select("Linenum='" + linenum + "' and Atcnum='" + Atc + "'").CopyToDataTable();

                    if (Detailsvalue == "PD QTY")
                    {
                        try
                        {
                            object Sumproduced = proddata.Compute("Sum(TotalQty)", "Linenum ='" + linenum + "' and atcnum= '" + Atc + "'");
                            tbl_derdata.Rows[i].Cells["Total"].Value = Sumproduced.ToString();
                        }
                        catch (Exception)
                        {
                            tbl_derdata.Rows[i].Cells["Total"].Value = "0";

                        }
                    }
                    else if (Detailsvalue == "BE % OF OB")
                    {
                        try
                        {

                            object producedpercent = proddata.Compute("AVG(BEPercentOB)", "Linenum ='" + linenum + "'  ");
                            if (producedpercent.ToString().Trim() != "")
                            {
                                float bepercent = float.Parse(producedpercent.ToString());
                                tbl_derdata.Rows[i].Cells["Total"].Value = bepercent.ToString("0.00");
                            }
                            else
                            {
                                tbl_derdata.Rows[i].Cells["Total"].Value = producedpercent.ToString();
                            }
                        }
                        catch (Exception)
                        {
                            tbl_derdata.Rows[i].Cells["Total"].Value = "0";

                        }
                    }
                    else if (Detailsvalue == "BD BE QTY")
                    {
                        try
                        {
                            object bdqty = proddata.Compute("Sum(BDqty)", "Linenum ='" + linenum + "' and atcnum= '" + Atc + "'");
                            tbl_derdata.Rows[i].Cells["Total"].Value = bdqty.ToString();
                        }
                        catch (Exception)
                        {
                            tbl_derdata.Rows[i].Cells["Total"].Value = "0";

                        }
                    }
                    else if (Detailsvalue == "BD $")
                    {
                        try
                        {
                            object bddollor = proddata.Compute("Sum(BDDollor)", " Linenum= '" + linenum + "' and atcnum= '" + Atc + "'");
                            tbl_derdata.Rows[i].Cells["Total"].Value = bddollor.ToString();
                        }
                        catch (Exception)
                        {
                            tbl_derdata.Rows[i].Cells["Total"].Value = "0";

                        }
                    }
                    else if (Detailsvalue == "PD % OF OB")
                    {
                        try
                        {
                            object Sumproduced = proddata.Compute("Sum(TotalQty)", "Linenum ='" + linenum + "' ");
                            object TargetProduction = proddata.Compute("Sum(TargetProduction)", "Linenum ='" + linenum + "' ");

                            if (Sumproduced.ToString().Trim() != "" && TargetProduction.ToString().Trim() != "")
                            {
                                float percent = (float.Parse(Sumproduced.ToString()) / float.Parse(TargetProduction.ToString())) * 100;
                                tbl_derdata.Rows[i].Cells["Total"].Value = percent.ToString();
                            }
                        }
                        catch (Exception)
                        {
                            tbl_derdata.Rows[i].Cells["Total"].Value = "0";

                        }
                    }
                }
                #endregion

                # region column summary

                else if (Atc == "Total" && linenum == "All Lines")
                {
                    for (int j = 3; j < tbl_derdata.ColumnCount; j++)
                    {
                    //    #  region start
                        try
                        {
                            DateTime datetoday = DateTime.Parse(tbl_derdata.Columns[j].HeaderText.ToString());
                            DataTable proddata = dt.Select("DateOfProd='" + datetoday + "'").CopyToDataTable();


                            if (Detailsvalue == "PD QTY")
                            {
                                try
                                {
                                    object Sumproduced = proddata.Compute("Sum(TotalQty)", "");
                                    tbl_derdata.Rows[i].Cells[j].Value = Sumproduced.ToString();
                                }
                                catch (Exception)
                                {
                                    tbl_derdata.Rows[i].Cells[j].Value = "0";

                                }
                            }
                            else if (Detailsvalue == "BE % OF OB")
                            {
                                try
                                {

                                    object producedpercent = proddata.Compute("AVG(BEPercentOB)", "");
                                    if (producedpercent.ToString().Trim() != "")
                                    {
                                        float bepercent = float.Parse(producedpercent.ToString());
                                        tbl_derdata.Rows[i].Cells[j].Value = bepercent.ToString("0.00");
                                    }
                                    else
                                    {
                                        tbl_derdata.Rows[i].Cells[j].Value = producedpercent.ToString();
                                    }
                                }
                                catch (Exception)
                                {
                                    tbl_derdata.Rows[i].Cells[j].Value = "0";

                                }
                            }
                            else if (Detailsvalue == "BD BE QTY")
                            {
                                try
                                {
                                    object bdqty = proddata.Compute("Sum(BDqty)", "");
                                    tbl_derdata.Rows[i].Cells[j].Value = bdqty.ToString();
                                }
                                catch (Exception)
                                {
                                    tbl_derdata.Rows[i].Cells[j].Value = "0";

                                }
                            }
                            else if (Detailsvalue == "BD $")
                            {
                                try
                                {
                                    object bddollor = proddata.Compute("Sum(BDDollor)", "");
                                    tbl_derdata.Rows[i].Cells[j].Value = bddollor.ToString();
                                }
                                catch (Exception)
                                {
                                    tbl_derdata.Rows[i].Cells[j].Value = "0";

                                }
                            }
                            else if (Detailsvalue == "PD % OF OB")
                            {
                                try
                                {
                                    object Sumproduced = proddata.Compute("Sum(TotalQty)", "");
                                    object TargetProduction = proddata.Compute("Sum(TargetProduction)", "");

                                    if (Sumproduced.ToString().Trim() != "" && TargetProduction.ToString().Trim() != "")
                                    {
                                        float percent = (float.Parse(Sumproduced.ToString()) / float.Parse(TargetProduction.ToString())) * 100;
                                        tbl_derdata.Rows[i].Cells[j].Value = percent.ToString();
                                    }
                                }
                                catch (Exception)
                                {
                                    tbl_derdata.Rows[i].Cells[j].Value = "0";

                                }
                            }

                        }
                        catch (Exception)
                        {
                            
                            
                        }


                   //end of for loop
                    
                    
                    }

                }

#endregion

               
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {


        }






        private void tbl_derdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex == 0)
            {
                if ((tbl_derdata.Rows[e.RowIndex].Cells[0].Value.ToString() == tbl_derdata.Rows[e.RowIndex + 1].Cells[0].Value.ToString()))
                {
                    if ((e.ColumnIndex == 0))
                    {
                        e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                    }
                }
                if ((tbl_derdata.Rows[e.RowIndex].Cells[1].Value.ToString() == tbl_derdata.Rows[e.RowIndex + 1].Cells[1].Value.ToString()))
                {
                    if ((e.ColumnIndex == 1))
                    {
                        e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                    }
                }

            }

            if (e.RowIndex > 0)
            {
                if (e.RowIndex < tbl_derdata.Rows.Count - 1)
                {
                    if ((tbl_derdata.Rows[e.RowIndex - 1].Cells[0].Value.ToString() == tbl_derdata.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    {
                        if ((e.ColumnIndex == 0))
                        {
                            e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                        }
                    }
                    if ((tbl_derdata.Rows[e.RowIndex].Cells[0].Value.ToString() == tbl_derdata.Rows[e.RowIndex + 1].Cells[0].Value.ToString()))
                    {
                        if ((e.ColumnIndex == 0))
                        {
                            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                        }
                    }
                    if ((tbl_derdata.Rows[e.RowIndex].Cells[1].Value.ToString() == tbl_derdata.Rows[e.RowIndex + 1].Cells[1].Value.ToString()))
                    {
                        if ((e.ColumnIndex == 1))
                        {
                            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                        }
                    }
                }

            }



        }



        private void tbl_derdata_Scroll(object sender, ScrollEventArgs e)
        {


        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Transaction.DataExporter xprtr = new Transaction.DataExporter();
            xprtr.exporttoexcel(tbl_derdata);
        }







    }
}
