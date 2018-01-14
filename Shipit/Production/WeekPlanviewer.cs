using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shipit.CourierDetailsDataSetTableAdapters;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
namespace Shipit.Production
{
    public partial class WeekPlanviewer : Form
    {
        Transaction.DataTransaction dttrans = null;
        Transaction.AtracoCalaender atcclndr = null;
      //  int weekflag = 0;
        DataTable dateofmonth = new DataTable();
        DataTable Podetails = new DataTable();
        public WeekPlanviewer()
        {
            InitializeComponent();
            dttrans = new Transaction.DataTransaction();
            atcclndr = new Transaction.AtracoCalaender();
            loadfactorycombo();
        }

        private void WeekPlanviewer_Load(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmb_factory.Text != "" && cmb_year.Text != "" && cmb_month.Text!="")
            {
                CourierDetailsDataSetTableAdapters.LineDataPreviewTableAdapter adapt = new LineDataPreviewTableAdapter();
                adapt.Connection.ConnectionString = Program.ConnStr;

                ultraGrid1.DataSource = null;
                DataTable dt = adapt.GetDataByYearMonthfactory(int.Parse(cmb_year.Text.ToString()), int.Parse(cmb_factory.SelectedValue.ToString()),cmb_month.Text.Trim());

                ultraGrid1.DataSource = dt;
                UltraGridBand band = this.ultraGrid1.DisplayLayout.Bands[0];
                band.Override.AllowRowFiltering = DefaultableBoolean.True;
                band.Override.AllowRowSummaries = AllowRowSummaries.BasedOnDataType;
                diplaybalances();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }



        public void diplaybalances()
        {
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void editQtyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int numflag = 0;
            for (int i = 0; i < ultraGrid1.Rows.Count; i++)
            {


                if (Convert.ToBoolean(ultraGrid1.Rows[i].Cells["Selecter"].Value) == true)
                {
                    numflag++;
                }
            }

            if (numflag <= 1)
            {
                int lineplanid = int.Parse(ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["FctProdID"].Value.ToString());
                int qty = int.Parse(ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["TargetQty"].Value.ToString());

                Production.EditLinePlanForm edt = new EditLinePlanForm(lineplanid, qty);
                edt.ShowDialog();
            }
            else
            {
                MessageBox.Show("Multi Selection is Not Allowed in Edit  Qty");
            }
        }

        private void deletePlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ultraGrid1.Rows.Count; i++)
            {


                if (Convert.ToBoolean(ultraGrid1.Rows[i].Cells["Selecter"].Value) == true)
                {

                    int lineplanid = int.Parse(ultraGrid1.Rows[i].Cells["FctProdID"].Value.ToString());
                  
                    CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
                    var q = from lineplan in couriercontext.FactoryWeeklyPlan_tbls
                            where lineplan.FctProdID == lineplanid
                            select lineplan;

                    foreach (var detail in q)
                    {
                        couriercontext.FactoryWeeklyPlan_tbls.DeleteOnSubmit(detail);
                    }

                    try
                    {
                        couriercontext.SubmitChanges();
                    }
                    catch (Exception)
                    {

                        // Provide for exceptions.
                    }
                }
            }
            MessageBox.Show("Done");
        }

        private void changeLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            int lineplanid = int.Parse(ultraGrid1.Rows[ultraGrid1.ActiveRow.Index].Cells["FctProdID"].Value.ToString());
            Production.EditLinePlanForm edt = new EditLinePlanForm(lineplanid, 0, int.Parse(cmb_factory.SelectedValue.ToString()));
            edt.ShowDialog();
        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultraGrid1.DisplayLayout.Bands[0].ResetColumns();
            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add("Selecter", "Selecter");
            checkColumn.DataType = typeof(bool);
            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;
        }

        private void ultraGrid1_CellChange(object sender, CellEventArgs e)
        {
            UltraGrid ug = sender as UltraGrid;

            ug.ActiveRow.Update();
            ug.PerformAction(UltraGridAction.ExitEditMode);
        }

        private void multiLineChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Production.EditLinePlanForm edt = new EditLinePlanForm(int.Parse(cmb_factory.SelectedValue.ToString()));
            edt.ShowDialog();
            String linenum = edt.Linenum;
            int lineid = edt.Lineid;
            for (int i = 0; i < ultraGrid1.Rows.Count; i++)
            {


                if (Convert.ToBoolean(ultraGrid1.Rows[i].Cells["Selecter"].Value) == true)
                {
                    int lineplanid = int.Parse(ultraGrid1.Rows[i].Cells["FctProdID"].Value.ToString());

                    CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr);
                    var q = from lineplan in cntxt.FactoryWeeklyPlan_tbls
                            where lineplan.FctProdID == lineplanid
                            select lineplan;
                    foreach (var v in q)
                    {
                        v.LineID = lineid;
                        v.LineNum = linenum;
                        cntxt.SubmitChanges();
                    }
                }
            }

        }
    
   
    }
}
