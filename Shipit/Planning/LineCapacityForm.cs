using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.Production
{
    public partial class LineCapacityForm : Form
    {
        Transaction.DataTransaction dttrans = null;
        Transaction.PlanTransaction plntrans = null;
        public LineCapacityForm()
        {
            InitializeComponent();
            dttrans = new Transaction.DataTransaction();
            plntrans = new Transaction.PlanTransaction();
            loadAtc();
        }

        public void loadAtc()
        {
            try
            {
                DataTable atcnum = dttrans.getAtcnumbers();

                if (atcnum != null)
                {
                    if (atcnum.Rows.Count > 0)
                    {
                        cmb_Atc.DataSource = atcnum;
                        cmb_Atc.DisplayMember = "Atcnum";
                        cmb_Atc.ValueMember = "AtcId";
                    }
                }




            }
            catch (Exception)
            {

                throw;
            }
            //     cmb_factory.ValueMember = "atcmaster";
            //   Buyercombo.DataBind();



        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = plntrans.GetLinesForEnteringCapacity();
            foreach (DataColumn clm in dt.Columns)
            {
                clm.ReadOnly = false;
            }
            tbl_atclines.DataSource = null;
            tbl_atclines.ColumnCount = 1;
            tbl_atclines .DataSource = dt;
            DataGridViewComboBoxColumn comboBoxColumn =
        new DataGridViewComboBoxColumn();
//            comboBoxColumn.Items.AddRange("8/5",
//"8/8",
//"10/5",
//"10/8",
//"10/10");

            comboBoxColumn.Items.AddRange("8/5");

          //  comboBoxColumn.ValueType = typeof(Color);
            comboBoxColumn.HeaderText = "Line Hours";
            tbl_atclines.Columns.Add(comboBoxColumn);
          //  tbl_atclines.Columns.Add(Hours);
        //  tbl_atclines.Columns["Hours"].
         //   int colIndex = grid.Columns.Add(col);
        }
        public void insertAtcLines()
        {
            for (int i = 0; i < tbl_atclines.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_atclines.Rows[i].Cells[0].Value) == true)
                {
                    CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
                    LineAtcCapacity_tbl linecpcty = new LineAtcCapacity_tbl();
                    linecpcty.Factid = Program.lctnpk;
                    linecpcty.Atcnum = cmb_Atc.Text.Trim(); 
                    linecpcty.Atc_id = int.Parse(cmb_Atc.SelectedValue.ToString());
                    linecpcty.LineID  = int.Parse(tbl_atclines.Rows[i].Cells["LineID"].Value.ToString());
                    linecpcty.LineNum = tbl_atclines.Rows[i].Cells["LineNum"].Value.ToString();
                    linecpcty.OurStyleNum = cmb_ourStyle.Text.Trim();
                    linecpcty.OurStyleID= int.Parse(cmb_ourStyle.SelectedValue.ToString());
                    linecpcty.DailyCaspacity = int.Parse(tbl_atclines.Rows[i].Cells["DailyCapacity"].Value.ToString());
                    linecpcty.NoOFMachines  = int.Parse(tbl_atclines.Rows[i].Cells["No Of Machines"].Value.ToString());
                    linecpcty.NoOfOperators  = int.Parse(tbl_atclines.Rows[i].Cells["No Of Operators"].Value.ToString());
                    linecpcty.NoOfHelper = int.Parse(tbl_atclines.Rows[i].Cells["No Of Helpers"].Value.ToString());
                  //  linecpcty.TotalHours = int.Parse(tbl_atclines.Rows[i].Cells["Hours"].Value.ToString());
                    linecpcty.TotalHours = Convert.ToString((tbl_atclines.Rows[i].Cells[8] as DataGridViewComboBoxCell).FormattedValue.ToString());
                    linecpcty.AddedBy = Program.uername;
                    linecpcty.AddedDate = DateTime.Now.Date;
                    courdatacontext.LineAtcCapacity_tbls.InsertOnSubmit(linecpcty);
                    courdatacontext.SubmitChanges();

                }
            }

        }

       

        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            insertAtcLines();
           
            tbl_atclines.DataSource = null;
            tbl_atclines.ColumnCount = 1;
            MessageBox.Show("Done");
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_atclines.IsCurrentCellDirty)
            {
                tbl_atclines.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void cmb_Atc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bindOurstylecombo();

            }
            catch (Exception)
            {


            }
        }
        public void bindOurstylecombo()
        {
            int atcid = int.Parse(cmb_Atc.SelectedValue.ToString());
            CourierDataDataContext cntxt = new CourierDataDataContext(Program.ArtConnStr);
            var q = from atcname in cntxt.AtcDetails
                    where atcname.AtcId == atcid

                    select atcname;

            cmb_ourStyle.DataSource = q;
            cmb_ourStyle.DisplayMember = "OurStyle";
            cmb_ourStyle.ValueMember = "OurStyleID";


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
