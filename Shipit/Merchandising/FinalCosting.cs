using Shipit.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shipit.Merchandising
{
    public partial class FinalCosting : Form
    {
        public FinalCosting()
        {
            InitializeComponent();
            fillAtc();
        }
        public void fillAtc()
        {
            using (DataModels.ArtEntities enty = new ArtEntities())
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

        private void FinalCosting_Load(object sender, EventArgs e)
        {

        }
    }
}
