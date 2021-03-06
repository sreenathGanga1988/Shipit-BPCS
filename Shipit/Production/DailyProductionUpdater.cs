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
    public partial class DailyProductionUpdater : Form
    {
        Transaction.DataTransaction dttrans = null;
        
        public DailyProductionUpdater()
        {
            InitializeComponent();
            dttrans = new Transaction.DataTransaction();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_dailydesigner.DataSource = null;
            tbl_dailydesigner.ColumnCount = 1;
            DataTable dt = dttrans.GettargetsofADay(int.Parse(cmb_factory.SelectedValue.ToString()), dtp_datetoday.Value.Date);
            tbl_dailydesigner.DataSource = dt;
            tbl_dailydesigner.Columns.Add("ProducedQty", "ProducedQty");
            tbl_dailydesigner.Columns.Add("PackedQty", "PackedQty");
        }

        private void DailyProductionUpdater_Load(object sender, EventArgs e)
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
        public void insertWeeklyPlan()
        {
            for (int i = 0; i < tbl_dailydesigner .Rows.Count; i++)
            {
                if (Convert.ToBoolean(tbl_dailydesigner.Rows[i].Cells[0].Value) == true)
                {
                    if (tbl_dailydesigner.Rows[i].Cells["ProducedQty"].Value != null)
                    {
                        if (tbl_dailydesigner.Rows[i].Cells["ProducedQty"].Value.ToString().Trim() != null || tbl_dailydesigner.Rows[i].Cells["ProducedQty"].Value.ToString().Trim() != "")
                        {
                            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
                            ActualProduced_tbl actualtaprod = new ActualProduced_tbl();
                            actualtaprod.FctProdID = int.Parse(tbl_dailydesigner.Rows[i].Cells["FctProdID"].Value.ToString());
                            actualtaprod.ProducedQty = int.Parse(tbl_dailydesigner.Rows[i].Cells["ProducedQty"].Value.ToString());
                            actualtaprod.AddedBy = Program.uername;
                            actualtaprod.AddedDate = DateTime.Now;


                            if (tbl_dailydesigner.Rows[i].Cells["PackedQty"].Value != null)
                            {
                                if (tbl_dailydesigner.Rows[i].Cells["PackedQty"].Value.ToString().Trim() != null || tbl_dailydesigner.Rows[i].Cells["PackedQty"].Value.ToString().Trim() != "")
                                {
                                    actualtaprod.PackedQty = int.Parse(tbl_dailydesigner.Rows[i].Cells["PackedQty"].Value.ToString());
                                }
                                else
                                {
                                    actualtaprod.PackedQty = 0;
                                }
                            }
                            else
                            {
                                actualtaprod.PackedQty = 0;
                            }

                            actualtaprod.PackedQty = int.Parse(tbl_dailydesigner.Rows[i].Cells["PackedQty"].Value.ToString());
                            courdatacontext.ActualProduced_tbls.InsertOnSubmit(actualtaprod);
                            courdatacontext.SubmitChanges();
                        }
                    }
                }
            }
        }
        private void tbl_dailydesigner_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_dailydesigner .IsCurrentCellDirty)
            {
                tbl_dailydesigner.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            insertWeeklyPlan();
            MessageBox.Show("Done");
        }

        private void cmb_factory_SelectedIndexChanged(object sender, EventArgs e)
        {
            dttrans.resrictacess(cmb_factory);
        }
    }
}
