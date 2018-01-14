using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using System.Data;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;


namespace Shipit.Transaction
{
    public class DataExporter
    {
        const int WORKSHEETSTARTROW = 1;
        const int WORKSHEETSTARTCOL = 1;
        public void exporttoexcel(System.Windows.Forms.DataGridView dataGridView1)
        {

            try
            {
                // creating Excel Application
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();


                // creating new WorkBook within Excel application
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);


                // creating new Excelsheet in workbook
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                // see the excel sheet behind the program
                app.Visible = true;

                // get the reference of first sheet. By default its name is Sheet1.
                // store its reference to worksheet
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;

                // changing the name of active sheet
                worksheet.Name = "Exported from gridview";


                // storing header part in Excel
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }



                // storing Each row and column value to excel sheet
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value == null)
                        {
                            worksheet.Cells[i + 2, j + 1] = 0;
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }

                    }
                }


                // save the application
                //   workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                // Exit from the application
                app.Quit();
            }
            catch (Exception)
            {


            }

        }


        public void exporttoexcelVisibleRows(System.Windows.Forms.DataGridView dataGridView1)
        {

            try
            {
                // creating Excel Application
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();


                // creating new WorkBook within Excel application
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);


                // creating new Excelsheet in workbook
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                // see the excel sheet behind the program
                app.Visible = true;

                // get the reference of first sheet. By default its name is Sheet1.
                // store its reference to worksheet
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;

                // changing the name of active sheet
                worksheet.Name = "Exported from gridview";


                // storing header part in Excel
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }



                // storing Each row and column value to excel sheet
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value == null)
                        {
                            worksheet.Cells[i + 2, j + 1] = 0;
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }

                    }
                }


                // save the application
                //   workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                // Exit from the application
                app.Quit();
            }
            catch (Exception)
            {


            }

        }

        public void writeCSV(System.Windows.Forms.DataGridView gridIn)
        {
            try
            {
                gridIn.AllowUserToAddRows = false;
                using (var dlg = new SaveFileDialog())
                {
                    dlg.Filter = "Csv Format|*.csv";
                    dlg.ShowDialog();

                    String outputFile = dlg.FileName;


                    //test to see if the DataGridView has any rows
                    if (gridIn.RowCount > 0)
                    {
                        string value = "";
                        DataGridViewRow dr = new DataGridViewRow();
                        using (StreamWriter swOut = new StreamWriter(outputFile))
                        {

                            //write header rows to csv
                            for (int i = 0; i < gridIn.Columns.Count; i++)
                            {
                                if (i > 0)
                                {
                                    swOut.Write(",");
                                }
                                swOut.Write(gridIn.Columns[i].HeaderText);
                            }

                            swOut.WriteLine();

                            //write DataGridView rows to csv
                            for (int j = 0; j < gridIn.Rows.Count; j++)
                            {

                                if (j > 0)
                                {
                                    swOut.WriteLine();
                                }

                                dr = gridIn.Rows[j];

                                for (int i = 0; i < gridIn.Columns.Count; i++)
                                {
                                    if (i > 0)
                                    {
                                        swOut.Write(",");
                                    }

                                    value = dr.Cells[i].Value.ToString();
                                    //replace comma's with spaces
                                    value = value.Replace(',', ' ');
                                    //replace embedded newlines with spaces
                                    value = value.Replace(Environment.NewLine, " ");

                                    swOut.Write(value);
                                }
                            }
                            swOut.Close();
                            if (DialogResult.Yes == MessageBox.Show("Do You Want to Open The Exported File ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                            {
                                try
                                {

                                    Process.Start("Excel.exe", outputFile);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                gridIn.AllowUserToAddRows = true;
            }

        }


        //public void exportrep(System.Windows.Forms.DataGridView dataGridView1)
        //{
        //    var excelApp = new Excel.Application();
        //    excelApp.Visible = true;
        //    Excel.Workbook excelbk = excelApp.Workbooks.Add(Type.Missing);
        //    Excel.Worksheet xlWorkSheet1 = (Excel.Worksheet)excelbk.Worksheets["Sheet1"];
        //    int worksheetRow = WORKSHEETSTARTROW;
        //    for (int rowCount = 0; rowCount < dataGridView1.Rows.Count - 1; rowCount++)
        //    {
        //        int worksheetcol = WORKSHEETSTARTCOL;
        //        for (int colCount = 0; colCount < dataGridView1.Columns.Count; colCount++)
        //        {
        //            Excel.Range xlRange = (Excel.Range)xlWorkSheet1.Cells[worksheetRow, worksheetcol];
        //            try
        //            {
        //                xlRange.Value2 = dataGridView1.Rows[rowCount].Cells[colCount].Value.ToString();
        //            }
        //            catch (Exception)
        //            {

        //                xlRange.Value2 = "";
        //            }
        //            xlRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(dataGridView1.Rows[rowCount] .DefaultCellStyle.BackColor);
        //            xlRange.Font.Color = dataGridView1.Rows[rowCount].Cells[colCount].Style.ForeColor.ToArgb();
        //            if (dataGridView1.Rows[rowCount].Cells[colCount].Style.Font != null)
        //            {
        //                xlRange.Font.Bold = dataGridView1.Rows[rowCount].Cells[colCount].Style.Font.Bold;
        //                xlRange.Font.Italic = dataGridView1.Rows[rowCount].Cells[colCount].Style.Font.Italic;
        //                xlRange.Font.Underline = dataGridView1.Rows[rowCount].Cells[colCount].Style.Font.Underline;
        //                xlRange.Font.FontStyle = dataGridView1.Rows[rowCount].Cells[colCount].Style.Font.FontFamily;
        //            }
        //            worksheetcol += 1;
        //        }
        //        worksheetRow += 1;
        //    }
        //}


        public void try2(System.Windows.Forms.DataGridView dataGridView1)
        {
            var excelApp = new Excel.Application();
            excelApp.Visible = true;
            Excel.Workbook excelbk = excelApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet xlWorkSheet1 = (Excel.Worksheet)excelbk.Worksheets["Sheet1"];
            int worksheetRow = WORKSHEETSTARTROW;
            for (int rowCount = 0; rowCount < dataGridView1.Rows.Count - 1; rowCount++)
            {
                int worksheetcol = WORKSHEETSTARTCOL;
                for (int colCount = 0; colCount < dataGridView1.Columns.Count; colCount++)
                {
                    Excel.Range xlRange = (Excel.Range)xlWorkSheet1.Cells[WORKSHEETSTARTROW, worksheetcol];
                    xlRange.Value2 = dataGridView1.Columns[colCount].Name;
                    worksheetcol += 1;
                }
                worksheetRow += 1;
                for (int colCount = 0; colCount < dataGridView1.Columns.Count - 1; colCount++)
                {
                    Excel.Range xlRange = (Excel.Range)xlWorkSheet1.Cells[worksheetRow, worksheetcol];
                    try
                    {
                        xlRange.Value2 = dataGridView1.Rows[rowCount].Cells[colCount].Value.ToString();
                    }
                    catch (Exception)
                    {
                        xlRange.Value2 = "";

                    }
                    xlRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(dataGridView1.Rows[rowCount].DefaultCellStyle.BackColor);
                    xlRange.Font.Color = dataGridView1.Rows[rowCount].Cells[colCount].Style.ForeColor.ToArgb();
                    if (dataGridView1.Rows[rowCount].Cells[colCount].Style.Font != null)
                    {
                        xlRange.Font.Bold = dataGridView1.Rows[rowCount].Cells[colCount].Style.Font.Bold;
                        xlRange.Font.Italic = dataGridView1.Rows[rowCount].Cells[colCount].Style.Font.Italic;
                        xlRange.Font.Underline = dataGridView1.Rows[rowCount].Cells[colCount].Style.Font.Underline;
                        xlRange.Font.FontStyle = dataGridView1.Rows[rowCount].Cells[colCount].Style.Font.FontFamily;
                    }
                    worksheetcol += 1;
                }
                worksheetRow += 1;
            }
        }






        public void exportexcelbysreenath(System.Windows.Forms.DataGridView dataGridView1)
        {
            int rownum = 1;
            // intialize excel application
            var excelApp = new Excel.Application();
            excelApp.Visible = true;
            // creates a workbook
            Excel.Workbook excelbk = excelApp.Workbooks.Add(Type.Missing);
            //Add a Workseet named sheet1 to above workbook
            Excel.Worksheet xlWorkSheet1 = (Excel.Worksheet)excelbk.Worksheets["Sheet1"];

            //Add each column name of datagridview to the first row of the Excel this will be the header text
            for (int colCount = 0; colCount < dataGridView1.Columns.Count; colCount++)
            {
                Excel.Range xlRange = (Excel.Range)xlWorkSheet1.Cells[rownum, colCount + 1];
                xlRange.Value2 = dataGridView1.Columns[colCount].Name;
            }
            // for each row in the datagridview 
            for (int rowCount = 0; rowCount < dataGridView1.Rows.Count ; rowCount++)
            {

                //if the row is visible
                if (dataGridView1.Rows[rowCount].Visible == true)
                {
                    //increment the row number for excel 
                    rownum = rownum + 1;
                    for (int colCount = 0; colCount < dataGridView1.Columns.Count; colCount++)
                    {
                        //create a excel range for the rownum and the columncount
                        Excel.Range xlRange = (Excel.Range)xlWorkSheet1.Cells[rownum, colCount + 1];
                        try
                        {
                            //add the gridview cell value to the cellrange
                            xlRange.Value2 = dataGridView1.Rows[rowCount].Cells[colCount].Value.ToString();
                        }
                        catch (Exception)
                        {
                            try
                            {
                                xlRange.Value2 = "";
                            }
                            catch (Exception)
                            {


                            }

                        }
                        //set the interior range of the xlrange to the defaultcell style of row  
                        xlRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(dataGridView1.Rows[rowCount].DefaultCellStyle.BackColor);
                        //set the font color  of the xlrange to the styletyle.ForeColor of row  
                        xlRange.Font.Color = dataGridView1.Rows[rowCount].Cells[colCount].Style.ForeColor.ToArgb();
                        if (dataGridView1.Rows[rowCount].Cells[colCount].Style.Font != null)
                        {
                            xlRange.Font.Bold = dataGridView1.Rows[rowCount].Cells[colCount].Style.Font.Bold;
                            xlRange.Font.Italic = dataGridView1.Rows[rowCount].Cells[colCount].Style.Font.Italic;
                            xlRange.Font.Underline = dataGridView1.Rows[rowCount].Cells[colCount].Style.Font.Underline;
                            xlRange.Font.FontStyle = dataGridView1.Rows[rowCount].Cells[colCount].Style.Font.FontFamily;
                        }
                    }
                }
            }

        }








    }
}