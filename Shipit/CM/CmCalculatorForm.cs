using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Shipit.CM
{
    public partial class CmCalculatorForm : Form
    {
        int costofmachine = 26;
        int cmOrderid = 0;
        public CmCalculatorForm()
        {
            InitializeComponent();
            bindatccombo();
            bindfactcombo();
            btnUpdate.Enabled = false;
            tbl_HelperData.RowCount = 1;
        }
        public CmCalculatorForm(int cmid)
        {
            InitializeComponent();
            bindatccombo();
            bindfactcombo();
            fillcontrol(cmid);
            btnUpdate.Enabled = true;
            btnSubmit.Enabled = false;
            cmOrderid = cmid;
        }

        public void fillcontrol(int cmid)
        {
            CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr);
            var q = from cmdetail in cntxt.CmMasters
                    where cmdetail.CmId == cmid
                    select cmdetail;

            foreach (var element  in q )
            {
                cmb_factory.SelectedValue = element.Factory_id;
                costofmachine = costofmachinecal();
                cmb_atc.SelectedValue = element.Atc_id;
                cmb_ourstyle.SelectedValue = element.OurStyleID;
                txt_acm.Text = element.AcmQty.ToString ();
                txt_fcm.Text = element.FcmQty.ToString();
                txt_ob_machine.Text = element.OBmachines.ToString();
                txt_oboperators.Text = element.OBOperators.ToString();
                txt_obhelpers.Text = element.ObHelpers.ToString();
                txt_obtarget.Text = element.OBTarget.ToString();
              
                txt_pcpermachine.Text = element.PcsPermachine.ToString();
                txt_breakeventargetacm.Text = element.BreakEvenAcmTarget.ToString();
                txt_breakevenefficencyacm.Text = element.BreakEvenAcmEfficency.ToString();
                txt_breakeventargetfcm.Text = element.BreakEvenFcmTarget.ToString();
                btxt_breakevenefficiencyfcm.Text = element.BreakEvenFcmEfficiency.ToString();

                tbl_HelperData.RowCount = 1;
                tbl_HelperData.Rows[0].Cells[0].Value = element.Writer.ToString();
                tbl_HelperData.Rows[0].Cells[1].Value = element.Feeder.ToString();
                tbl_HelperData.Rows[0].Cells[2].Value = element.Bundlemover.ToString();
                tbl_HelperData.Rows[0].Cells[3].Value = element.Supervisor.ToString();
                tbl_HelperData.Rows[0].Cells[4].Value = element.PE.ToString();
                tbl_HelperData.Rows[0].Cells[5].Value = element.Helper.ToString();


            }
        }
        





        public void validatecm(float cmvalue)
        {

        }



        public Boolean validationControl()
        {
            Boolean sucess = false;
            if (cmb_atc.Text.Trim() == "")
            {
                cmb_atc.Focus();
            }
            else if (cmb_factory.Text.Trim() == "")
            {
                cmb_factory.Focus();
            }
            else if (!isNumeric(txt_acm))
            {
                txt_acm.Focus();
            }
            else if (!isNumeric(txt_fcm))
            {
                txt_fcm.Focus();
            }
           
            else if (!isNumeric(txt_obtarget))
            {
                txt_obtarget.Focus();
            }
            else if (!isNumeric(txt_ob_machine))
            {
                txt_ob_machine.Focus();
            }
            else if (!isNumeric(txt_oboperators))
            {
                txt_oboperators.Focus();
            }
            else if (!isNumeric(txt_obhelpers))
            {
                txt_obhelpers.Focus();
            }
            else if (!isNumeric(txt_pcpermachine))
            {
                txt_pcpermachine.Focus();
            }
            else if (!isNumeric(txt_breakeventargetacm))
            {
                txt_breakeventargetacm.Focus();
            }
            else if (!isNumeric(txt_breakevenefficencyacm))
            {
                txt_breakevenefficencyacm.Focus();
            }
            else if (!isNumeric(txt_breakeventargetfcm))
            {
                txt_breakeventargetfcm.Focus();
            }
            else if (!isNumeric(btxt_breakevenefficiencyfcm))
            {
                btxt_breakevenefficiencyfcm.Focus();
            }
            else
            {
                sucess = true;
            }
            return sucess;
        }

        public int costofmachinecal()
        {
            int costofmac = 0;


            CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr);
            var q = from fact in cntxt.Factory_Masters
                    where fact.Factory_ID == int.Parse(cmb_factory.SelectedValue.ToString())
                    select fact;
            foreach (var v in q)
            {
                costofmac = int.Parse(v.CPM.ToString());
            }


            return costofmac;
        }
        public static bool onlyNumeric(string text)
        {
            Regex regex = new Regex("[^0-9.-]"); ; //regex that allows numeric input only
            return !regex.IsMatch(text); //
        }
        public Boolean isNumeric(TextBox txt)
        {
            Boolean isnumber = true;
            try
            {
                float p = float.Parse(txt.Text);
            }
            catch (Exception)
            {

                isnumber = false;
            }

            return isnumber;
        }
        public void bindatccombo()
        {
            ArtDataDataContext cntxt = new ArtDataDataContext(Program.ArtConnStr);
            var q = from atcname in cntxt.AtcMasters
                    select atcname;

            cmb_atc.DataSource  = q;
            cmb_atc.DisplayMember = "AtcNum";
            cmb_atc.ValueMember  = "AtcId";

            
        }
        public void bindOurstylecombo()
        {
            int atcid = int.Parse(cmb_atc.SelectedValue.ToString());
            CourierDataDataContext cntxt = new CourierDataDataContext(Program.ArtConnStr);
            var q = from atcname in cntxt.AtcDetails
                    where atcname.AtcId==atcid

                    select atcname;

            cmb_ourstyle.DataSource = q;
            cmb_ourstyle.DisplayMember = "OurStyle";
            cmb_ourstyle.ValueMember = "OurStyleID";


        }
        public void bindfactcombo()
        {
            CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr );
            var q = from factname in cntxt.Factory_Masters
                    select factname;

            cmb_factory.DataSource = q;
            cmb_factory.DisplayMember = "Factory_name";
            cmb_factory.ValueMember = "Factory_ID";
        }


        public void getBreakEvenAcmTarget(float noofmachine, float costpermachine, float acm)
        {
            float breakeventargetacm = ((noofmachine * costpermachine) / acm) * 12;
            txt_breakeventargetacm.Text = breakeventargetacm.ToString();
            try
            {
                float test = float.Parse(txt_breakeventargetacm.Text);

                efficencyacm(float.Parse(txt_breakeventargetacm.Text), float.Parse(txt_obtarget.Text));
            }
            catch (Exception)
            {
                
                
            }

        }
        public void getBreakEvenFcmTarget(float noofmachine, float costpermachine, float fcm)
        {
            float breakeventargetfcm = ((noofmachine * costpermachine) / fcm) * 12;
            txt_breakeventargetfcm.Text = breakeventargetfcm.ToString();
            efficencyfcm(float.Parse(txt_breakeventargetfcm.Text), float.Parse(txt_obtarget.Text));

        }
        public void pcsPerMacine(float obtarget, float noofmachine)
        {
            float pcsperline = obtarget / noofmachine;
            txt_pcpermachine.Text = pcsperline.ToString();
        }


        public void efficencyacm(float breakeventargetacm, float obtarget)
        {
            float efficiencyacm = (breakeventargetacm / obtarget) * 100;
            txt_breakevenefficencyacm.Text = efficiencyacm.ToString();
        }
        public void efficencyfcm(float breakeventargetfcm, float obtarget)
        {
            float efficiencyfcm = (breakeventargetfcm / obtarget) * 100;
            btxt_breakevenefficiencyfcm.Text = efficiencyfcm.ToString();
        }


        public void INSERTDATA()
        {
            if (validationControl())
            {
                CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr );
                 if (!cntxt.CmMasters.Any(f => f.Factory_id == int.Parse(cmb_factory.SelectedValue.ToString()) && f.Atc_id == int.Parse(cmb_atc.SelectedValue.ToString()) && f.OurStyleID== int.Parse(cmb_ourstyle.SelectedValue.ToString())))
            {
                    CmMaster cmmstr = new CmMaster();
                cmmstr.Atc_id = int.Parse(cmb_atc.SelectedValue.ToString());
                cmmstr.Factory_id = int.Parse(cmb_factory.SelectedValue.ToString());
                cmmstr.CPM = costofmachinecal();
                    cmmstr.OurStyleID = int.Parse(cmb_ourstyle.SelectedValue.ToString());

                    cmmstr.AcmQty = decimal.Parse(txt_acm.Text);
                cmmstr.FcmQty = decimal.Parse(txt_fcm.Text);
                cmmstr.OBTarget = decimal.Parse(txt_obtarget.Text);
                cmmstr.OBmachines = decimal.Parse(txt_ob_machine.Text);
                cmmstr.OBOperators = decimal.Parse(txt_oboperators.Text);
                cmmstr.ObHelpers = decimal.Parse(txt_obhelpers.Text);
                cmmstr.PcsPermachine = decimal.Parse(txt_pcpermachine.Text);
                cmmstr.BreakEvenAcmTarget = decimal.Parse(txt_breakeventargetacm.Text);
                cmmstr.BreakEvenAcmEfficency = decimal.Parse(txt_breakevenefficencyacm.Text);
                cmmstr.BreakEvenFcmTarget = decimal.Parse(txt_breakeventargetfcm.Text);
                cmmstr.BreakEvenFcmEfficiency = decimal.Parse(btxt_breakevenefficiencyfcm.Text);
                cmmstr.AddedDate = DateTime.Now.Date;

                    cmmstr.Writer = decimal.Parse(tbl_HelperData.Rows[0].Cells[0].Value.ToString());
                    cmmstr.Feeder = decimal.Parse(tbl_HelperData.Rows[0].Cells[1].Value.ToString());
                    cmmstr.Bundlemover = decimal.Parse(tbl_HelperData.Rows[0].Cells[2].Value.ToString());
                    cmmstr.Supervisor = decimal.Parse(tbl_HelperData.Rows[0].Cells[3].Value.ToString());
                    cmmstr.PE = decimal.Parse(tbl_HelperData.Rows[0].Cells[4].Value.ToString());
                    cmmstr.Helper = decimal.Parse(tbl_HelperData.Rows[0].Cells[5].Value.ToString());
                    cmmstr.Trimmer = decimal.Parse(tbl_HelperData.Rows[0].Cells[6].Value.ToString());
                    cmmstr.Addedvia = "Shipit";
                    cmmstr.ActionType="Insert";
                    cmmstr.AddedBy = Program.userpk.ToString(); ;
                
                cntxt.CmMasters.InsertOnSubmit(cmmstr);
                cntxt.SubmitChanges();
                MessageBox.Show("Done");
            }
            }
            else
            {
                MessageBox.Show("CM Entry Already Exist");
            }
        }

        private void txt_orderQty_KeyDown(object sender, KeyEventArgs e)
        {
         
        }

        private void txt_orderQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !onlyNumeric(e.KeyChar.ToString ());
        }

        private void txt_acm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !onlyNumeric(e.KeyChar.ToString());
        }

        private void txt_oboperators_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !onlyNumeric(e.KeyChar.ToString());
        }

        private void txt_obhelpers_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !onlyNumeric(e.KeyChar.ToString());
        }

        private void txt_ob_machine_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !onlyNumeric(e.KeyChar.ToString());
        }

        private void txt_fcm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !onlyNumeric(e.KeyChar.ToString());
        }

        private void txt_acm_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                getBreakEvenAcmTarget(float.Parse(txt_ob_machine.Text), costofmachine, float.Parse(txt_acm.Text));
            }
            catch (Exception)
            {


            }
        }

        private void txt_fcm_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                getBreakEvenFcmTarget(float.Parse(txt_ob_machine.Text), costofmachine, float.Parse(txt_fcm.Text));
            }
            catch (Exception)
            {


            }
        }

        private void txt_obtarget_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                pcsPerMacine(float.Parse(txt_obtarget.Text), float.Parse(txt_ob_machine.Text));
                efficencyacm(float.Parse(txt_breakeventargetacm.Text), float.Parse(txt_obtarget.Text));
                efficencyfcm(float.Parse(txt_breakeventargetfcm.Text), float.Parse(txt_obtarget.Text));
            }
            catch (Exception)
            {


            }
        }

        private void txt_ob_machine_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                getBreakEvenAcmTarget(float.Parse(txt_ob_machine.Text), costofmachine, float.Parse(txt_acm.Text));
                getBreakEvenFcmTarget(float.Parse(txt_ob_machine.Text), costofmachine, float.Parse(txt_fcm.Text));
                pcsPerMacine(float.Parse(txt_obtarget.Text), float.Parse(txt_ob_machine.Text));
            }
            catch (Exception)
            {


            }
        }

        private void submitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            INSERTDATA();
        }

        private void cmb_factory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_factory.Text.Trim() != "")
                {
                    costofmachine = costofmachinecal();
                    txt_cpm.Text = costofmachine.ToString();
                }
            }
            catch (Exception)
            {
                
               
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validationControl())
            {
                CourierDataDataContext cntxt = new CourierDataDataContext(Program.ConnStr);
                var q = from cmdetail in cntxt.CmMasters
                        where cmdetail.CmId == cmOrderid
                        select cmdetail;

                foreach (var cmmstr in q)
                {
                    cmmstr.Atc_id = int.Parse(cmb_atc.SelectedValue.ToString());
                    cmmstr.Factory_id = int.Parse(cmb_factory.SelectedValue.ToString());
                    cmmstr.CPM = costofmachinecal();

                    cmmstr.Order_qty = 0;
                    cmmstr.AcmQty = decimal.Parse(txt_acm.Text);
                    cmmstr.FcmQty = decimal.Parse(txt_fcm.Text);
                    cmmstr.OBTarget = decimal.Parse(txt_obtarget.Text);
                    cmmstr.OBmachines = decimal.Parse(txt_ob_machine.Text);
                    cmmstr.OBOperators = decimal.Parse(txt_oboperators.Text);
                    cmmstr.ObHelpers = decimal.Parse(txt_obhelpers.Text);
                    cmmstr.PcsPermachine = decimal.Parse(txt_pcpermachine.Text);
                    cmmstr.BreakEvenAcmTarget = decimal.Parse(txt_breakeventargetacm.Text);
                    cmmstr.BreakEvenAcmEfficency = decimal.Parse(txt_breakevenefficencyacm.Text);
                    cmmstr.BreakEvenFcmTarget = decimal.Parse(txt_breakeventargetfcm.Text);
                    cmmstr.BreakEvenFcmEfficiency = decimal.Parse(btxt_breakevenefficiencyfcm.Text);
                    cmmstr.OurStyleID= int.Parse(cmb_ourstyle.SelectedValue.ToString());
                    cmmstr.AddedDate = DateTime.Now.Date;
                    cmmstr.Addedvia = "Shipit";
                    cmmstr.ActionType = "Update";
                    cmmstr.AddedBy = Program.userpk.ToString();

                    cntxt.SubmitChanges();
                    MessageBox.Show("Updated");
                }
            }
        }

        private void txt_acm_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_fcm.Text = txt_acm.Text;
                getBreakEvenAcmTarget(float.Parse(txt_ob_machine.Text), costofmachine, float.Parse(txt_acm.Text));
               
            }
            catch (Exception)
            {


            }
        }

        private void txt_fcm_TextChanged(object sender, EventArgs e)
        {
            try
            {
                getBreakEvenFcmTarget(float.Parse(txt_ob_machine.Text), costofmachine, float.Parse(txt_fcm.Text));
            }
            catch (Exception)
            {


            }
        }

        private void txt_obtarget_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pcsPerMacine(float.Parse(txt_obtarget.Text), float.Parse(txt_ob_machine.Text));
                efficencyacm(float.Parse(txt_breakeventargetacm.Text), float.Parse(txt_obtarget.Text));
                efficencyfcm(float.Parse(txt_breakeventargetfcm.Text), float.Parse(txt_obtarget.Text));
            }
            catch (Exception)
            {


            }
        }

        private void txt_ob_machine_TextChanged(object sender, EventArgs e)
        {
            try
            {
                getBreakEvenAcmTarget(float.Parse(txt_ob_machine.Text), costofmachine, float.Parse(txt_acm.Text));
                getBreakEvenFcmTarget(float.Parse(txt_ob_machine.Text), costofmachine, float.Parse(txt_fcm.Text));
                pcsPerMacine(float.Parse(txt_obtarget.Text), float.Parse(txt_ob_machine.Text));
            }
            catch (Exception)
            {


            }
        }

       


        public void recalculate()
        {
            getBreakEvenAcmTarget(float.Parse(txt_ob_machine.Text), costofmachine, float.Parse(txt_acm.Text));
            getBreakEvenFcmTarget(float.Parse(txt_ob_machine.Text), costofmachine, float.Parse(txt_fcm.Text));
            pcsPerMacine(float.Parse(txt_obtarget.Text), float.Parse(txt_ob_machine.Text));
        }

        private void recalculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recalculate();
        }

        private void txt_breakeventargetfcm_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                float helpersum = float.Parse(tbl_HelperData.Rows[0].Cells[0].Value.ToString()) + float.Parse(tbl_HelperData.Rows[0].Cells[1].Value.ToString()) + float.Parse(tbl_HelperData.Rows[0].Cells[2].Value.ToString()) + float.Parse(tbl_HelperData.Rows[0].Cells[3].Value.ToString()) + float.Parse(tbl_HelperData.Rows[0].Cells[4].Value.ToString())+ float.Parse(tbl_HelperData.Rows[0].Cells[5].Value.ToString())+ float.Parse(tbl_HelperData.Rows[0].Cells[6].Value.ToString());

                txt_obhelpers.Text = helpersum.ToString();
            }
            catch (Exception)
            {

                
            }
        }

        private void txt_obhelpers_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmb_atc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bindOurstylecombo();

            }
            catch (Exception)
            {


            }
        }

        private void txt_oboperators_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_ob_machine.Text = txt_oboperators.Text;
                getBreakEvenAcmTarget(float.Parse(txt_ob_machine.Text), costofmachine, float.Parse(txt_acm.Text));
                getBreakEvenFcmTarget(float.Parse(txt_ob_machine.Text), costofmachine, float.Parse(txt_fcm.Text));
                pcsPerMacine(float.Parse(txt_obtarget.Text), float.Parse(txt_ob_machine.Text));
            }
            catch (Exception)
            {


            }
        }
    }
}
