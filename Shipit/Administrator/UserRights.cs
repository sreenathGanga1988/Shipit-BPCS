using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shipit.Administrator
{
    public partial class UserRights : Form
    {
        DataTable Allowedmodule = null;
        Transaction.DataTransaction dtrans = null;
        public UserRights()
        {
            InitializeComponent();

            dtrans = new Transaction.DataTransaction();
        }

        private void UserRights_Load(object sender, EventArgs e)
        {
            loadbuyercombo();
            loadtreeview();
            //AllowedModule();
        }


        public void loadbuyercombo()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from users in courdatacontext.UserMasters
                    select users;



            cmb_User.DataSource = q;
            cmb_User.DisplayMember = "Username";
            cmb_User.ValueMember = "userID";
            //   Buyercombo.DataBind();



        }


        public void AllowedModule()
        {
            CourierDataDataContext courdatacontext = new CourierDataDataContext(Program.ConnStr);
            var q = from module in courdatacontext.User_Rights
                    where module.User_Id==Program.userpk
                    select module;
            foreach(var element in q)
            {
                
                    for (int x = 0; x < treeView1.Nodes.Count; x++)
                    {
                        if (treeView1.Nodes[x].Text.ToString().Trim () == element.Form_name.Trim ())
                        {
                           // treeView1.Nodes[x].Remove();
                        }
                        else
                        {
                            
                        }

                    }

               
            }


        }


        public void loadtreeview()
        {
            //creates the instance of MDI parent
            Mainform frm = new Mainform();
            //for each menusdtrip items
            foreach (ToolStripMenuItem tsmi in frm.menuStrip1.Items)
            {
                
                    // create a new treenode with the menitem string as name
                    TreeNode tn = new TreeNode(tsmi.Text);
                    //try to get the  child nodes
                    getChildNodes(tsmi, tn);
                    treeView1.Nodes.Add(tn);
                
            }
        }


        private void RemoveChildNodes(TreeNode aNode )
        {

            if (aNode.Nodes.Count > 0)
            {
                for (int i = aNode.Nodes.Count - 1; i >= 0; i--)
                {
                    aNode.Nodes[i].Remove();
                }
            }

        }



        private void getChildNodes(ToolStripDropDownItem mi, TreeNode tn)
        {
            foreach (object item in mi.DropDownItems)
            {
              
                    // if toolstrip item is  spearator leave it
                    if (item.GetType() == typeof(ToolStripSeparator))
                    {
                        continue;
                    }

                    //else create a new node of same name
                    TreeNode node = new TreeNode(((ToolStripDropDownItem)item).Text);
                    //add it to node

                    tn.Nodes.Add(node);
                    //try to check foir more child node for the node
                    getChildNodes(((ToolStripDropDownItem)item), node);
                }
            
        }

        private void CheckTreeViewNode(TreeNode node, Boolean isChecked)
        {
            foreach (TreeNode item in node.Nodes)
            {
                item.Checked = isChecked;

                if (item.Nodes.Count > 0)
                {
                    this.CheckTreeViewNode(item, isChecked);
                }
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckTreeViewNode(e.Node, e.Node.Checked);
        }




        /// <summary>
        /// function to insert userright process
        /// </summary>
        public void insertRights()
        {
            if (cmb_User.Text != "")
            {

                //deletes the existing rights
                deleteright();

                CallNodesSelector();
            }

           MessageBox .Show("Done");
           

        }



        /// <summary>
        /// function to get the child nodes of treeview
        /// </summary>
        private void CallNodesSelector()
        {
            TreeNodeCollection nodes = this.treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                GetNodeRecursive(n);
            }
        }
        private void GetNodeRecursive(TreeNode treeNode)
        {
            //select only the checked nodes
            if (treeNode.Checked == true)
            {

                string checkedValue = treeNode.Text.ToString();
                //insert into the database
                addright(checkedValue);
            }
            foreach (TreeNode tn in treeNode.Nodes)
            {


                //get the childnode again
                GetNodeRecursive(tn);

            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {    
            insertRights();
        }

        /// <summary>
        /// add user rights
        /// </summary>
        /// <param name="formname"></param>
        public void addright(String formname)
        {
            
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            User_Right  usrright = new User_Right ();
            usrright.User_Id = int.Parse(cmb_User.SelectedValue.ToString ());

            usrright.Form_name = formname;
            usrright.Access_Right = "Y";
            couriercontext.User_Rights.InsertOnSubmit(usrright);

            couriercontext.SubmitChanges();

        }




        /// <summary>
        /// deletes user right of user for reentry
        /// </summary>
        public void deleteright()
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var deleteOrderDetails =
    from details in couriercontext.User_Rights 
    where details.User_Id == int.Parse (cmb_User.SelectedValue.ToString ())
    select details;

            foreach (var detail in deleteOrderDetails)
            {
                couriercontext.User_Rights.DeleteOnSubmit(detail);
            }

            try
            {
                couriercontext.SubmitChanges();
            }
            catch (Exception )
            {
                
                // Provide for exceptions.
            }
        }

        private void cmb_User_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtrans.getexistingprivillege(int.Parse(cmb_User.SelectedValue.ToString()), treeView1);
        }



        public void insertMasterRights()
        {
            if (cmb_User.Text != "")
            {

                //deletes the existing rights
                deleteMasterright();

                CallNodesSelectorMaster();
            }

            MessageBox.Show("Done");


        }
        public void deleteMasterright()
        {
            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            var deleteOrderDetails =
    from details in couriercontext.UserRightMaster_tbls
    where details.User_Id == int.Parse(cmb_User.SelectedValue.ToString())
    select details;

            foreach (var detail in deleteOrderDetails)
            {
                couriercontext.UserRightMaster_tbls.DeleteOnSubmit(detail);
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

        /// <summary>
        /// function to get the child nodes of treeview
        /// </summary>
        private void CallNodesSelectorMaster()
        {
            TreeNodeCollection nodes = this.treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                GetNodeRecursive(n);
            }
        }
        private void GetNodeRecursiveMaster(TreeNode treeNode)
        {
            //select only the checked nodes
            if (treeNode.Checked == true)
            {

                string checkedValue = treeNode.Text.ToString();
                //insert into the database
                addrightMaster(checkedValue);
            }
            foreach (TreeNode tn in treeNode.Nodes)
            {


                //get the childnode again
                GetNodeRecursiveMaster(tn);

            }

        }
        public void addrightMaster(String formname)
        {

            CourierDataDataContext couriercontext = new CourierDataDataContext(Program.ConnStr);
            UserRightMaster_tbl usrright = new UserRightMaster_tbl();
            usrright.User_Id = int.Parse(cmb_User.SelectedValue.ToString());

            usrright.Form_name = formname;
            usrright.Access_Right = "Y";
            couriercontext.UserRightMaster_tbls.InsertOnSubmit(usrright);

            couriercontext.SubmitChanges();

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            insertMasterRights();
        }
    }
}
