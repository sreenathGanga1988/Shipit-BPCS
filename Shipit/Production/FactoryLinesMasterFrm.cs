using System;
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
    public partial class FactoryLinesMasterFrm : Form
    {
        Transaction.DataExporter DTPEXPTR = null;
        Transaction.DataTransaction dttrans = null;
        public FactoryLinesMasterFrm()
        {
            InitializeComponent();
            dttrans = new Transaction.DataTransaction();
        }

        private void FactoryLinesMasterFrm_Load(object sender, EventArgs e)
        {
            LoadFactoryCombo();
        }
        public void LoadFactoryCombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from fctry in courdatacontext.Factory_Masters
                    select fctry;



            cmb_factory.DataSource = q;
            cmb_factory.DisplayMember = "Factory_name";
            cmb_factory.ValueMember = "Factory_ID";
            cmb_factory.SelectedValue = Program.lctnpk;
            //   Buyercombo.DataBind();



        }

        private void cmb_year_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_factory_SelectedIndexChanged(object sender, EventArgs e)
        {
            dttrans.resrictacess(cmb_factory);
        }



        public void addrow()
        {
            if(!dttrans.IsComboboxemptyorNull (cmb_factory ))
            {
                MessageBox.Show("Select Factory");

            }
            else if (!dttrans.IsTextboxemptyorNull(txt_lineno))
            {
                MessageBox.Show("Enter Number of Lines");
            }
            else if(!dttrans.Isnumbericentry(txt_lineno.Text) )
            {
                MessageBox.Show("Number of Lines Must be Numeric");
            }
            else
            {
                tbl_linedata.DataSource = null;
                tbl_linedata.Columns[0].Visible = true; ;
                tbl_linedata.Columns[1].Visible = true;
                tbl_linedata.RowCount = int.Parse(txt_lineno.Text);
                for (int i = 0; i < tbl_linedata.RowCount; i++)
                {
                    tbl_linedata.Rows[i].Cells[0].Value = i.ToString();
                    tbl_linedata.Rows[i].Cells[1].Value = "Line " + i.ToString();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addrow();
        }








        public Boolean validationcontrol()
        {
            Boolean sucess = false;
            if(!dttrans.IsComboboxemptyorNull(cmb_factory))
            {
                sucess=false;
            }
            else if (!isgridempty())
            {
                MessageBox.Show("Enter Name of All the Lines");

            }
            else
            {
                sucess = true;
            }
            return sucess;
        }


        public Boolean  isgridempty()
        {
            Boolean sucess = true;
            for (int i = 0; i < tbl_linedata.Rows.Count; i++)
            {
                if (tbl_linedata.Rows[i].Cells[1].Value.ToString() == "")
                {
                    sucess = false;
                }
            }
            return sucess;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (validationcontrol())
            {
             
                for (int i = 0; i < tbl_linedata.Rows.Count; i++)
                {
                    CourierDataDataContext curdatacontext = new CourierDataDataContext(Program.ConnStr);
                    LineMaster linemstr = new LineMaster();
                    linemstr.LineNum = tbl_linedata.Rows[i].Cells[1].Value.ToString();
                    linemstr.AddedBy = Program.uername;
                    linemstr.FactoryID = int.Parse(cmb_factory.SelectedValue.ToString());
                    linemstr.AddedDate = DateTime.Now.Date;
                    linemstr.IsWorking = "Y";
                    curdatacontext.LineMasters.InsertOnSubmit(linemstr);
                    curdatacontext.SubmitChanges(); 
                }
                MessageBox.Show("Done");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dttrans.IsComboboxemptyorNull(cmb_factory))
            {
                CourierDataDataContext curdatacontext = new CourierDataDataContext(Program.ConnStr);
                var q = from lnmstr in curdatacontext.LineMasters
                        where lnmstr.FactoryID == int.Parse(cmb_factory.SelectedValue.ToString())
                        select lnmstr;
                tbl_linedata.DataSource = q;
                tbl_linedata.Columns[0].Visible = false;
                tbl_linedata.Columns[1].Visible = false;
                tbl_linedata.Columns[3].Visible = false;

            }
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DTPEXPTR = new Transaction.DataExporter();

            //     DTPEXPTR.exporttoexcel(dataGridView1);
            DTPEXPTR.writeCSV(tbl_linedata);
        }

        private void editLineNumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Update LineNum";
            btnColumn.Text = "Update LineNum";
            btnColumn.UseColumnTextForButtonValue = true;
            tbl_linedata.Columns.Add(btnColumn);

            tbl_linedata.Columns[0].ReadOnly = true;
        }

        private void tbl_linedata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
if (tbl_linedata .Rows.Count >= 0)
            {

                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 9)
                    {
                        if (validationcontrol(tbl_linedata.CurrentRow.Index))
                        {
                            updateLineNum();
                            //sendnotification("Approved");
                            //Showdata();

                        }
                    }
                }
            }
        }

        public Boolean validationcontrol(int i)
        {



            Boolean sucess = false;

            if (tbl_linedata.Rows[i].Cells[2].Value == null || tbl_linedata.Rows[i].Cells[2].Value.ToString().Trim() == "")
            {
                MessageBox.Show("Line ID is Empty");



            }


            else if (tbl_linedata.Rows[i].Cells[4].Value == null || tbl_linedata.Rows[i].Cells[4].Value.ToString().Trim() == "")
            {
                MessageBox.Show("Line Number not entered");



            }



            else
            {
                sucess = true;
            }


            return sucess;

        }


        /// <summary>
        /// update the line name
        /// </summary>
        public void updateLineNum()
        {
            int linenum = int.Parse(tbl_linedata.Rows[tbl_linedata.CurrentRow.Index].Cells[2].Value.ToString());
            CourierDataDataContext countxt = new CourierDataDataContext(Program.ConnStr);
            var q = from linedata in countxt.LineMasters
                    where linedata.Lineid == linenum
                    select linedata;
            foreach (var line in q)
            {
                line.LineNum = tbl_linedata.Rows[tbl_linedata.CurrentRow.Index].Cells[4].Value.ToString();
                countxt.SubmitChanges();
                MessageBox.Show("Done");
            }
        }
    
    
    
    }
}
