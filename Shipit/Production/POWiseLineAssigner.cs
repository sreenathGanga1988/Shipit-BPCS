﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shipit.Production
{
    public partial class POWiseLineAssigner : Form
    {
        Transaction.DataTransaction dttrans = null;
        Transaction.AtracoCalaender atcclndr = null;
        int weekflag = 0;
        int poflag = 0;
        DataTable dateofmonth = new DataTable();
        DataTable Podetails = new DataTable();
        DataTable previouslineplan = new DataTable();
        Transaction.DataExporter DTPEXPTR = null;
        public POWiseLineAssigner()
        {
            InitializeComponent();
            dttrans = new Transaction.DataTransaction();
            atcclndr = new Transaction.AtracoCalaender();
            loadfactorycombo();
        }

        /// <summary>
        /// load factory combo
        /// </summary>
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

        private void cmb_factory_SelectedIndexChanged(object sender, EventArgs e)
        {
            dttrans.resrictacess(cmb_factory);
        }

        private void cmb_week_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(weekflag>0)
           {if (dttrans.IsComboboxemptyorNull(cmb_factory) && dttrans.IsComboboxemptyorNull(cmb_year) && dttrans.IsComboboxemptyorNull(cmb_month) && dttrans.IsComboboxemptyorNull(cmb_week))
            {
                Podetails  = dttrans.GetPosOfaMonth(cmb_month.Text.Trim(), int.Parse(cmb_year.Text), int.Parse(cmb_factory.SelectedValue.ToString()), cmb_week.Text.Trim());

                if (Podetails.Rows.Count > 0)
                   {
                       cmb_PO.DataSource = Podetails;
                       cmb_PO.DisplayMember = "PO#";
            cmb_PO.ValueMember = "WeekID";
        
                   }

         
           }}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (dttrans.IsComboboxemptyorNull(cmb_factory) && dttrans.IsComboboxemptyorNull(cmb_year) && dttrans.IsComboboxemptyorNull(cmb_month) && dttrans.IsComboboxemptyorNull(cmb_week))
            {
                dateofmonth = atcclndr.getdatesof(cmb_month.Text.Trim(), int.Parse(cmb_year.Text), cmb_week.Text);
            }

            if (dttrans.IsComboboxemptyorNull(cmb_week))
            {
                try
                {
                    DataTable results = dateofmonth.Select("Weeknumber = '" + cmb_week.Text + "'").CopyToDataTable();
                   
                    datagridviewSetup(results);
                }
                catch (Exception)
                {
                }

                if (dttrans.IsComboboxemptyorNull(cmb_PO ))
                {

                    if(Podetails.Rows.Count>0)
                    {
                        DataTable dt = Podetails.Select("WeekID= '" + int.Parse(cmb_PO.SelectedValue.ToString()) + "'").CopyToDataTable();
                        if (dt.Rows.Count >=1)
                        {
                            String sum = dt.Rows[0][2].ToString();
                       
                            String Atc = dttrans .GetAtcByPOnum(cmb_PO.Text);
                            previouslineplan = dttrans.GettPreviousLineplanOfPO(cmb_PO.Text);
                            object  sumObject;
                            try
                            {
                                sumObject = previouslineplan.Compute("Sum(TargetQty)", "POnum = '" + cmb_PO.Text.Trim() + "'");
                                linkLabel1.Text = "Already Planned  for "+ cmb_PO.Text.Trim () + "  is : " + sumObject.ToString();
                            }
                            catch (Exception)
                            {
                                
                                
                            }
                            
                            lbl_message.Text =Atc+" - PO# "+ cmb_PO.Text+" Weekly Allocation Requirement is " + sum;
                        }
                    }

                }

               }
        }

        private void POWiseLineAssigner_Load(object sender, EventArgs e)
        {

        }

        private void cmb_month_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





        public void datagridviewSetup(DataTable datedatatable)
        {
            tbl_weekAssigner.ColumnCount = 1;
            tbl_weekAssigner.ColumnCount = datedatatable.Rows.Count+3;
            tbl_weekAssigner.Columns[1].Name = "LineID";
            tbl_weekAssigner.Columns[2].Name = "LineNum";
            for (int i = 0; i < datedatatable.Rows.Count; i++)
            {
                tbl_weekAssigner.Columns[i+3].Name = datedatatable.Rows[i][0].ToString ();
            }



            CourierDataDataContext curdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from lnmstr in curdatacontext.LineMasters
                    where lnmstr.FactoryID == int.Parse(cmb_factory.SelectedValue.ToString()) && lnmstr.IsWorking == "Y"
                     select new
                               {
                                   
                                   linename = lnmstr.LineNum,
                                   linenum=lnmstr.Lineid
                                   
                               };

            int count = q.Count();
            int k = 0;
            tbl_weekAssigner.DataSource = null;
            tbl_weekAssigner.RowCount = count;
     foreach (var element in q)
            {
                tbl_weekAssigner.Rows[k].Cells[1].Value = element.linenum;

                tbl_weekAssigner.Rows[k].Cells[2].Value = element.linename;
                k++;
            }
    
        }

        private void cmb_week_MouseClick(object sender, MouseEventArgs e)
        {
            weekflag++;
        }


        public void insertWeeklyPlan()
        {
            for (int i = 0; i < tbl_weekAssigner.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_weekAssigner.Rows[i].Cells[0].Value) == true)
                {
                    for (int j = 3; j < tbl_weekAssigner.ColumnCount; j++)
                    {

                        if (tbl_weekAssigner.Rows[i].Cells[j].Value != null)
                        {
                            if (tbl_weekAssigner.Rows[i].Cells[j].Value.ToString().Trim() != null || tbl_weekAssigner.Rows[i].Cells[j].Value.ToString().Trim() != "")
                            {
                                CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
                                FactoryWeeklyPlan_tbl wkplanmstr = new FactoryWeeklyPlan_tbl();
                                wkplanmstr.Factid = int.Parse(cmb_factory.SelectedValue.ToString());
                                wkplanmstr.Year = int.Parse(cmb_year.Text);
                                wkplanmstr.Month = cmb_month.Text;
                                wkplanmstr.Weeknum = cmb_week.Text;
                                wkplanmstr.Ponum = cmb_PO.Text;
                                wkplanmstr.WeekID = int.Parse(cmb_PO.SelectedValue.ToString());
                                wkplanmstr.LineID = int.Parse(tbl_weekAssigner.Rows[i].Cells[1].Value.ToString());
                                wkplanmstr.LineNum = tbl_weekAssigner.Rows[i].Cells[2].Value.ToString();
                                wkplanmstr.DateofProd = DateTime.Parse(tbl_weekAssigner.Columns[j].Name);
                                wkplanmstr.AddedBy = Program.uername;
                                wkplanmstr.AddedDate = DateTime.Now;

                                wkplanmstr.TargetQty = int.Parse(tbl_weekAssigner.Rows[i].Cells[j].Value.ToString());
                                courdatacontext.FactoryWeeklyPlan_tbls.InsertOnSubmit(wkplanmstr);
                                courdatacontext.SubmitChanges();
                            }
                        }
                    }


                }
            }

        }

        private void tbl_weekAssigner_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_weekAssigner.IsCurrentCellDirty)
            {
                tbl_weekAssigner.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            insertWeeklyPlan();
            MessageBox.Show("Done");
             

           
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DTPEXPTR = new Transaction.DataExporter();

            //     DTPEXPTR.exporttoexcel(dataGridView1);
            DTPEXPTR.writeCSV(tbl_weekAssigner );
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Production.LinePlanEdit edt = new LinePlanEdit(previouslineplan);
            edt.MdiParent = this.MdiParent;
            edt.Show();
            
        }

        private void cmb_PO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (poflag != 0)
                {
                    if (cmb_PO.Text.Trim() != "")
                    {
                        DataTable dt = dttrans.GetAtcAndStyleByPOnum(int.Parse(cmb_PO.SelectedValue.ToString()));

                        cmb_style.DataSource = dt;
                        cmb_style.DisplayMember = "stylenum";
                        cmb_style.ValueMember = "AtcNO";
                    }

                }

            }
            catch (Exception)
            {
                
               
            }
        }

        private void cmb_PO_MouseClick(object sender, MouseEventArgs e)
        {
            poflag++;
        }






    }
}
