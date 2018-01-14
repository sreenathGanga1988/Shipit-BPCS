using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.DER
{
    public partial class AERSubReport : Form
    {
        Transaction.AtracoCalaender atcclndr = null;
        Transaction.ReportTransaction rpttran = null;
        DataTable dt = null;
        public AERSubReport()
        {
            InitializeComponent();
            rpttran = new Transaction.ReportTransaction();
            atcclndr = new Transaction.AtracoCalaender();
        }

        private void dailyEfficencyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = rpttran.GetSavedAERReport(dtp_from.Value.Date, dtp_to.Value.Date);
            //  dt = dt.Select(" Linenum= 'Line 19B' and Factory_name= 'MA3'").CopyToDataTable();
            DataTable datesavailable = atcclndr.GetDatesBetweenAPeriod(2005, dtp_from.Value.Date, dtp_to.Value.Date);

            gridviewDatesetup(datesavailable);
            gridviewLinesetup();
            calculateColumndata();
            Addsummary();
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction.DataExporter xprtr = new Transaction.DataExporter();
            //   xprtr.exporttoexcel(tbl_derdata);
            // xprtr.exportrep(tbl_derdata);
            xprtr.exportexcelbysreenath(tbl_derdata);
            MessageBox.Show("Report Exported");
        }

        private void derCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbl_derdata.Rows.Count != 0)
            {
                for (int i = 0; i < tbl_derdata.Rows.Count; i++)
                {
                    String factoryname = tbl_derdata.Rows[i].Cells["Factory"].Value.ToString().Trim();
                    String linenum = tbl_derdata.Rows[i].Cells["Line"].Value.ToString().Trim();
                    String Atc = tbl_derdata.Rows[i].Cells["Atc"].Value.ToString().Trim();
                    if (factoryname != "All factories" && linenum != "All Lines" && Atc == "All Atc")
                    {
                    }
                    else
                    {
                        tbl_derdata.Rows[i].Visible = false;


                    }

                }
            }
        }

        private void dERBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbl_derdata.Rows.Count != 0)
            {
                ArrayList rowstodelete = new ArrayList();
                for (int i = 0; i < tbl_derdata.Rows.Count; i++)
                {
                    String factoryname = tbl_derdata.Rows[i].Cells["Factory"].Value.ToString().Trim();
                    String linenum = tbl_derdata.Rows[i].Cells["Line"].Value.ToString().Trim();
                    String Atc = tbl_derdata.Rows[i].Cells["Atc"].Value.ToString().Trim();
                    if (factoryname != "All factories" && linenum == "All Lines" && Atc == "All Atc")
                    {
                    }
                    else
                    {
                        tbl_derdata.Rows[i].Visible = false;

                    }

                }



            }
        }

        private void dERAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbl_derdata.Rows.Count != 0)
            {
                for (int i = 0; i < tbl_derdata.Rows.Count; i++)
                {
                    String factoryname = tbl_derdata.Rows[i].Cells["Factory"].Value.ToString().Trim();
                    String linenum = tbl_derdata.Rows[i].Cells["Line"].Value.ToString().Trim();
                    String Atc = tbl_derdata.Rows[i].Cells["Atc"].Value.ToString().Trim();
                    if (factoryname == "All factories" && linenum == "All Lines" && Atc == "All Atc")
                    {
                    }
                    else
                    {
                        tbl_derdata.Rows[i].Visible = false;
                    }

                }
            }
        }





        public void Addsummary()
        {



            tbl_derdata.Columns["Total"].DefaultCellStyle.BackColor = Color.CadetBlue;

            for (int i = 0; i < tbl_derdata.Rows.Count; i++)
            {
                String factoryname = tbl_derdata.Rows[i].Cells["Factory"].Value.ToString().Trim();
                String linenum = tbl_derdata.Rows[i].Cells["Line"].Value.ToString().Trim();
                String Atc = tbl_derdata.Rows[i].Cells["Atc"].Value.ToString().Trim();
                String Detailsvalue = tbl_derdata.Rows[i].Cells["Details"].Value.ToString().Trim();
                # region rowsummary
                if (factoryname != "All factories" && linenum != "All Lines" && Atc != "All Atc")
                {
                    // IF THE ROW TOTAL MEANS TOTAL OF ATC AND LINE
                    # region Atc Line summary
                    try
                    {
                        if (Atc != "All Atc" && linenum != "All Lines")
                        {

                            DataTable proddata = dt.Select("Linenum='" + linenum + "' and Atcnum='" + Atc + "' and factory_name= '" + factoryname + "' ").CopyToDataTable();

                            if (Detailsvalue == "PD QTY")
                            {
                                try
                                {
                                    object Sumproduced = proddata.Compute("Sum(TotalQty)", "Linenum ='" + linenum + "' and atcnum= '" + Atc + "'and factory_name= '" + factoryname + "' ");
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

                                    object producedpercent = proddata.Compute("AVG(BEPercentOB)", "Linenum ='" + linenum + "'  and factory_name= '" + factoryname + "' ");
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
                                    object bdqty = proddata.Compute("Sum(BDqty)", "Linenum ='" + linenum + "' and atcnum= '" + Atc + "' and factory_name= '" + factoryname + "' ");
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
                                    object bddollor = proddata.Compute("Sum(BDDollor)", " Linenum= '" + linenum + "' and atcnum= '" + Atc + "' and factory_name= '" + factoryname + "' ");
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
                                    object Sumproduced = proddata.Compute("Sum(TotalQty)", "Linenum ='" + linenum + "' and factory_name= '" + factoryname + "'");
                                    object TargetProduction = proddata.Compute("Sum(TargetProduction)", "Linenum ='" + linenum + "' and factory_name= '" + factoryname + "' ");

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
                    }
                    catch (Exception)
                    {


                    }
                    #endregion
                }
                else if (factoryname != "All factories" && linenum != "All Lines" && Atc == "All Atc")
                {
                    # region All Atc

                    DataTable proddata = dt.Select("Linenum='" + linenum + "'  and factory_name= '" + factoryname + "' ").CopyToDataTable();

                    if (Detailsvalue == "PD QTY")
                    {
                        try
                        {
                            object Sumproduced = proddata.Compute("Sum(TotalQty)", "Linenum ='" + linenum + "' and factory_name= '" + factoryname + "' ");
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

                            object producedpercent = proddata.Compute("AVG(BEPercentOB)", "Linenum ='" + linenum + "'  and factory_name= '" + factoryname + "' ");
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
                            object bdqty = proddata.Compute("Sum(BDqty)", "Linenum ='" + linenum + "'  and factory_name= '" + factoryname + "' ");
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
                            object bddollor = proddata.Compute("Sum(BDDollor)", " Linenum= '" + linenum + "' and factory_name= '" + factoryname + "' ");
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
                            object Sumproduced = proddata.Compute("Sum(TotalQty)", "Linenum ='" + linenum + "' and factory_name= '" + factoryname + "'");
                            object TargetProduction = proddata.Compute("Sum(TargetProduction)", "Linenum ='" + linenum + "' and factory_name= '" + factoryname + "' ");

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
                    # endregion
                }
                else if (factoryname != "All factories" && linenum == "All Lines" && Atc == "All Atc")
                {
                    # region factory total

                    DataTable proddata = dt.Select("factory_name= '" + factoryname + "' ").CopyToDataTable();

                    if (Detailsvalue == "PD QTY")
                    {
                        try
                        {
                            object Sumproduced = proddata.Compute("Sum(TotalQty)", "factory_name= '" + factoryname + "' ");
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

                            object producedpercent = proddata.Compute("AVG(BEPercentOB)", " factory_name= '" + factoryname + "' ");
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
                            object bdqty = proddata.Compute("Sum(BDqty)", "factory_name= '" + factoryname + "' ");
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
                            object bddollor = proddata.Compute("Sum(BDDollor)", " factory_name= '" + factoryname + "' ");
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
                            object Sumproduced = proddata.Compute("Sum(TotalQty)", "factory_name= '" + factoryname + "'");
                            object TargetProduction = proddata.Compute("Sum(TargetProduction)", "factory_name= '" + factoryname + "' ");

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



                    #endregion
                }
                if (factoryname == "All factories" && linenum == "All Lines" && Atc == "All Atc")
                {
                    try
                    {
                        # region total group Summary
                        DataTable proddata = dt.Select(" ").CopyToDataTable();

                        if (Detailsvalue == "PD QTY")
                        {
                            try
                            {
                                object Sumproduced = proddata.Compute("Sum(TotalQty)", "");
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

                                object producedpercent = proddata.Compute("AVG(BEPercentOB)", "");
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
                                object bdqty = proddata.Compute("Sum(BDqty)", "");
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
                                object bddollor = proddata.Compute("Sum(BDDollor)", "");
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
                                object Sumproduced = proddata.Compute("Sum(TotalQty)", "");
                                object TargetProduction = proddata.Compute("Sum(TargetProduction)", "");

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
                        #endregion
                    }
                    catch (Exception)
                    {


                    }
                }
                #endregion




            }
        }
        public void gridviewDatesetup(DataTable datedata)
        {
            tbl_derdata.RowCount = 0;
            tbl_derdata.ColumnCount = 4;
            if (datedata != null)
            {
                if (datedata.Rows.Count > 0)
                {
                    tbl_derdata.ColumnCount = tbl_derdata.ColumnCount + datedata.Rows.Count;
                    for (int i = 0; i < datedata.Rows.Count; i++)
                    {
                        tbl_derdata.Columns[i + 4].HeaderText = datedata.Rows[i][0].ToString();
                        tbl_derdata.Columns[i + 4].DefaultCellStyle.NullValue = "0";
                        tbl_derdata.Columns[i + 4].Name = datedata.Rows[i][0].ToString();
                    }
                }


            }
        }

        public void gridviewLinesetup()
        {
            int rowcount = 0;

            DataView factoryview = new DataView(dt);
            factoryview.Sort = "factory_name ASC";
            DataTable disticnctfactory = factoryview.ToTable(true, "factory_name");

            for (int factcount = 0; factcount < disticnctfactory.Rows.Count; factcount++)
            {


                DataView lineview = new DataView(dt);
                lineview.Sort = "Linenum ASC";
                lineview.RowFilter = "factory_name='" + disticnctfactory.Rows[factcount]["factory_name"].ToString().Trim() + "'";
                DataTable distinctlines = lineview.ToTable(true, "Linenum");

                for (int linecount = 0; linecount < distinctlines.Rows.Count; linecount++)
                {

                    DataView lineatcview = new DataView(dt);
                    lineatcview.RowFilter = "Linenum='" + distinctlines.Rows[linecount]["Linenum"].ToString().Trim() + "' and factory_name='" + disticnctfactory.Rows[factcount]["factory_name"].ToString().Trim() + "' ";
                    lineatcview.Sort = "Linenum ASC, Atcnum ASC";
                    DataTable distinctValues = lineatcview.ToTable(true, "Linenum", "Atcnum");
                    for (int j = 0; j < distinctValues.Rows.Count; j++)
                    { //column details
                        for (int m = 0; m < 5; m++)
                        {
                            tbl_derdata.Rows.Add();
                            tbl_derdata.Rows[rowcount].Cells["Factory"].Value = disticnctfactory.Rows[factcount]["Factory_name"].ToString();
                            tbl_derdata.Rows[rowcount].Cells["Line"].Value = distinctValues.Rows[j]["Linenum"].ToString();
                            tbl_derdata.Rows[rowcount].Cells["Atc"].Value = distinctValues.Rows[j]["Atcnum"].ToString();
                            tbl_derdata.Rows[rowcount].DefaultCellStyle.BackColor = Color.White;
                            tbl_derdata.Rows[rowcount].Cells["Details"].Value = DetailHeaderStringcreator(m);

                            rowcount++;
                        }

                    }
                    //column line summary
                    for (int m = 0; m < 5; m++)
                    {
                        tbl_derdata.Rows.Add();
                        tbl_derdata.Rows[rowcount].Cells["Line"].Value = distinctlines.Rows[linecount]["Linenum"].ToString();
                        tbl_derdata.Rows[rowcount].Cells["Factory"].Value = disticnctfactory.Rows[factcount]["Factory_name"].ToString();
                        tbl_derdata.Rows[rowcount].Cells["Atc"].Value = "All Atc";
                        tbl_derdata.Rows[rowcount].DefaultCellStyle.BackColor = Color.CadetBlue;
                        tbl_derdata.Rows[rowcount].Cells["Details"].Value = DetailHeaderStringcreator(m);
                        rowcount++;
                    }


                }

                for (int m = 0; m < 5; m++)
                {
                    tbl_derdata.Rows.Add();
                    tbl_derdata.Rows[rowcount].Cells["Line"].Value = "All Lines";
                    tbl_derdata.Rows[rowcount].Cells["Factory"].Value = disticnctfactory.Rows[factcount]["Factory_name"].ToString();
                    tbl_derdata.Rows[rowcount].Cells["Atc"].Value = "All Atc";
                    tbl_derdata.Rows[rowcount].DefaultCellStyle.BackColor = Color.ForestGreen;
                    tbl_derdata.Rows[rowcount].Cells["Details"].Value = DetailHeaderStringcreator(m);
                    rowcount++;
                }



            }

            //Add Company Total
            for (int m = 0; m < 5; m++)
            {
                tbl_derdata.Rows.Add();
                tbl_derdata.Rows[rowcount].Cells["Factory"].Value = "All factories";
                tbl_derdata.Rows[rowcount].Cells["Line"].Value = "All Lines";
                tbl_derdata.Rows[rowcount].Cells["Atc"].Value = "All Atc";

                tbl_derdata.Rows[rowcount].Cells["Details"].Value = DetailHeaderStringcreator(m);
                tbl_derdata.Rows[rowcount].DefaultCellStyle.BackColor = Color.DarkRed;
                rowcount++;
            }

            // create TOTAL ON RIGHT
            tbl_derdata.Columns.Add("Total", "Total");
            tbl_derdata.Columns["Total"].DefaultCellStyle.BackColor = Color.DarkBlue;




        }


        public void calculateColumndata()
        {

            for (int j = 4; j < tbl_derdata.ColumnCount - 1; j++)
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
                String factoryname = tbl_derdata.Rows[i].Cells["Factory"].Value.ToString().Trim();
                String linenum = tbl_derdata.Rows[i].Cells["Line"].Value.ToString().Trim();
                String Atc = tbl_derdata.Rows[i].Cells["Atc"].Value.ToString().Trim();
                String Detailsvalue = tbl_derdata.Rows[i].Cells["Details"].Value.ToString().Trim();
                if (factoryname == "All factories" && linenum == "All Lines" && Atc == "All Atc")
                {
                    # region total group Summary
                    try
                    {
                        if (Detailsvalue == "PD QTY")
                        {
                            try
                            {
                                object Sumproduced = proddata.Compute("Sum(TotalQty)", "");
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

                                object producedpercent = proddata.Compute("AVG(ProducedPercent)", "");
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

                                object producedpercent = proddata.Compute("AVG(BEPercentOB)", "");
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

                                object bdqty = proddata.Compute("Sum(BDqty)", "");
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

                                object bddollor = proddata.Compute("Sum(BDDollor)", "");
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
                    #endregion
                }
                else if (factoryname != "All factories" && linenum == "All Lines" && Atc == "All Atc")
                {
                    # region factory total

                    if (Detailsvalue == "PD QTY")
                    {
                        try
                        {
                            object Sumproduced = proddata.Compute("Sum(TotalQty)", " factory_name= '" + factoryname + "' ");
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
                            object Sumproduced = proddata.Compute("Sum(TotalQty)", " factory_name= '" + factoryname + "'  ");
                            object TargetProduction = proddata.Compute("Sum(TargetProduction)", " factory_name= '" + factoryname + "'  ");

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
                            object bdqty = proddata.Compute("Sum(BDqty)", "factory_name= '" + factoryname + "'  ");
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
                            object bddollor = proddata.Compute("Sum(BDDollor)", "factory_name= '" + factoryname + "'  ");
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

                            object producedpercent = proddata.Compute("AVG(BEPercentOB)", " factory_name= '" + factoryname + "'  ");
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


                    # endregion
                }
                else if (factoryname != "All factories" && linenum != "All Lines" && Atc == "All Atc")
                {
                    # region line total
                    if (Detailsvalue == "PD QTY")
                    {
                        try
                        {
                            object Sumproduced = proddata.Compute("Sum(TotalQty)", " Linenum ='" + linenum + "' and factory_name= '" + factoryname + "'  ");
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
                            object Sumproduced = proddata.Compute("Sum(TotalQty)", " Linenum ='" + linenum + "' and  factory_name= '" + factoryname + "'   ");
                            object TargetProduction = proddata.Compute("Sum(TargetProduction)", " Linenum ='" + linenum + "' and  factory_name= '" + factoryname + "' ");

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
                            object bdqty = proddata.Compute("Sum(BDqty)", " Linenum ='" + linenum + "' and factory_name= '" + factoryname + "'  ");
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
                            object bddollor = proddata.Compute("Sum(BDDollor)", " Linenum ='" + linenum + "' and factory_name= '" + factoryname + "'  ");
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

                            object producedpercent = proddata.Compute("AVG(BEPercentOB)", "  Linenum ='" + linenum + "' and factory_name= '" + factoryname + "'  ");
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

                    # endregion
                }
                else if (factoryname != "All factories" && linenum != "All Lines" && Atc != "All Atc")
                {
                    # region Atc total
                    if (Detailsvalue == "PD QTY")
                    {
                        try
                        {
                            object Sumproduced = proddata.Compute("Sum(TotalQty)", " Linenum ='" + linenum + "' and factory_name= '" + factoryname + "' and atcnum= '" + Atc + "' ");
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
                            object Sumproduced = proddata.Compute("Sum(TotalQty)", " Linenum ='" + linenum + "' and  factory_name= '" + factoryname + "' and atcnum= '" + Atc + "'  ");
                            object TargetProduction = proddata.Compute("Sum(TargetProduction)", " Linenum ='" + linenum + "' and  factory_name= '" + factoryname + "' and atcnum= '" + Atc + "'  ");

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
                            object bdqty = proddata.Compute("Sum(BDqty)", " Linenum ='" + linenum + "' and factory_name= '" + factoryname + "' and atcnum= '" + Atc + "' ");
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
                            object bddollor = proddata.Compute("Sum(BDDollor)", " Linenum ='" + linenum + "' and factory_name= '" + factoryname + "' and atcnum= '" + Atc + "' ");
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

                            object producedpercent = proddata.Compute("AVG(BEPercentOB)", "  Linenum ='" + linenum + "' and factory_name= '" + factoryname + "' and atcnum= '" + Atc + "' ");
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

                    # endregion
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






    }
}
