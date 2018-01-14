namespace Shipit.ActualProduction
{
    partial class ProductionPOSplitter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionPOSplitter));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_factid = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_linenum = new System.Windows.Forms.Label();
            this.lbl_dateofprod = new System.Windows.Forms.Label();
            this.lbl_ponum = new System.Windows.Forms.Label();
            this.lbl_atcid = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tbl_dataentry = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraPanel2 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraSplitter1 = new Infragistics.Win.Misc.UltraSplitter();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.POnum = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.POQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Qty = new System.Windows.Forms.Label();
            this.lbl_qty = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_lineid = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_dataentry)).BeginInit();
            this.panel1.SuspendLayout();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            this.ultraPanel2.ClientArea.SuspendLayout();
            this.ultraPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lbl_lineid);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbl_qty);
            this.groupBox1.Controls.Add(this.Qty);
            this.groupBox1.Controls.Add(this.lbl_atcid);
            this.groupBox1.Controls.Add(this.lbl_ponum);
            this.groupBox1.Controls.Add(this.lbl_dateofprod);
            this.groupBox1.Controls.Add(this.lbl_linenum);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbl_factid);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1007, 104);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Factory : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(211, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Po#";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(211, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Line# : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Atc# : ";
            // 
            // lbl_factid
            // 
            this.lbl_factid.AutoSize = true;
            this.lbl_factid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_factid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_factid.Location = new System.Drawing.Point(84, 16);
            this.lbl_factid.Name = "lbl_factid";
            this.lbl_factid.Size = new System.Drawing.Size(44, 17);
            this.lbl_factid.TabIndex = 4;
            this.lbl_factid.Text = "******";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(464, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Date : ";
            // 
            // lbl_linenum
            // 
            this.lbl_linenum.AutoSize = true;
            this.lbl_linenum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_linenum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_linenum.Location = new System.Drawing.Point(311, 33);
            this.lbl_linenum.Name = "lbl_linenum";
            this.lbl_linenum.Size = new System.Drawing.Size(44, 17);
            this.lbl_linenum.TabIndex = 6;
            this.lbl_linenum.Text = "******";
            // 
            // lbl_dateofprod
            // 
            this.lbl_dateofprod.AutoSize = true;
            this.lbl_dateofprod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dateofprod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_dateofprod.Location = new System.Drawing.Point(551, 33);
            this.lbl_dateofprod.Name = "lbl_dateofprod";
            this.lbl_dateofprod.Size = new System.Drawing.Size(44, 17);
            this.lbl_dateofprod.TabIndex = 7;
            this.lbl_dateofprod.Text = "******";
            // 
            // lbl_ponum
            // 
            this.lbl_ponum.AutoSize = true;
            this.lbl_ponum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ponum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_ponum.Location = new System.Drawing.Point(298, 71);
            this.lbl_ponum.Name = "lbl_ponum";
            this.lbl_ponum.Size = new System.Drawing.Size(44, 17);
            this.lbl_ponum.TabIndex = 8;
            this.lbl_ponum.Text = "******";
            // 
            // lbl_atcid
            // 
            this.lbl_atcid.AutoSize = true;
            this.lbl_atcid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_atcid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_atcid.Location = new System.Drawing.Point(84, 71);
            this.lbl_atcid.Name = "lbl_atcid";
            this.lbl_atcid.Size = new System.Drawing.Size(44, 17);
            this.lbl_atcid.TabIndex = 9;
            this.lbl_atcid.Text = "******";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 337);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1007, 25);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(63, 22);
            this.toolStripButton2.Text = "Cancel";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 22);
            this.toolStripButton1.Text = "Submit";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tbl_dataentry
            // 
            this.tbl_dataentry.AllowUserToAddRows = false;
            this.tbl_dataentry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_dataentry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_dataentry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.POnum,
            this.POQty,
            this.Add});
            this.tbl_dataentry.ContextMenuStrip = this.contextMenuStrip1;
            this.tbl_dataentry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_dataentry.Location = new System.Drawing.Point(0, 0);
            this.tbl_dataentry.Name = "tbl_dataentry";
            this.tbl_dataentry.Size = new System.Drawing.Size(403, 233);
            this.tbl_dataentry.TabIndex = 10;
            this.tbl_dataentry.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_dataentry_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ultraSplitter1);
            this.panel1.Controls.Add(this.ultraPanel2);
            this.panel1.Controls.Add(this.ultraPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1007, 233);
            this.panel1.TabIndex = 22;
            // 
            // ultraPanel1
            // 
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.ultraGrid1);
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.ultraPanel1.Location = new System.Drawing.Point(421, 0);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(586, 233);
            this.ultraPanel1.TabIndex = 0;
            // 
            // ultraPanel2
            // 
            // 
            // ultraPanel2.ClientArea
            // 
            this.ultraPanel2.ClientArea.Controls.Add(this.tbl_dataentry);
            this.ultraPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraPanel2.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel2.Name = "ultraPanel2";
            this.ultraPanel2.Size = new System.Drawing.Size(403, 233);
            this.ultraPanel2.TabIndex = 1;
            // 
            // ultraSplitter1
            // 
            this.ultraSplitter1.Location = new System.Drawing.Point(403, 0);
            this.ultraSplitter1.Name = "ultraSplitter1";
            this.ultraSplitter1.RestoreExtent = 0;
            this.ultraSplitter1.Size = new System.Drawing.Size(12, 233);
            this.ultraSplitter1.TabIndex = 2;
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Location = new System.Drawing.Point(0, 0);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(586, 233);
            this.ultraGrid1.TabIndex = 0;
            this.ultraGrid1.Text = "ultraGrid1";
            // 
            // POnum
            // 
            this.POnum.HeaderText = "PONum";
            this.POnum.Name = "POnum";
            this.POnum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.POnum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // POQty
            // 
            this.POQty.HeaderText = "POQty";
            this.POQty.Name = "POQty";
            // 
            // Add
            // 
            this.Add.HeaderText = "Add Row";
            this.Add.Name = "Add";
            this.Add.Text = "Add Row";
            this.Add.ToolTipText = "Click to Add row";
            // 
            // Qty
            // 
            this.Qty.AutoSize = true;
            this.Qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Qty.Location = new System.Drawing.Point(464, 71);
            this.Qty.Name = "Qty";
            this.Qty.Size = new System.Drawing.Size(30, 17);
            this.Qty.TabIndex = 10;
            this.Qty.Text = "Qty";
            // 
            // lbl_qty
            // 
            this.lbl_qty.AutoSize = true;
            this.lbl_qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_qty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_qty.Location = new System.Drawing.Point(520, 71);
            this.lbl_qty.Name = "lbl_qty";
            this.lbl_qty.Size = new System.Drawing.Size(44, 17);
            this.lbl_qty.TabIndex = 11;
            this.lbl_qty.Text = "******";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Line# : ";
            // 
            // lbl_lineid
            // 
            this.lbl_lineid.AutoSize = true;
            this.lbl_lineid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lineid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_lineid.Location = new System.Drawing.Point(88, 45);
            this.lbl_lineid.Name = "lbl_lineid";
            this.lbl_lineid.Size = new System.Drawing.Size(44, 17);
            this.lbl_lineid.TabIndex = 13;
            this.lbl_lineid.Text = "******";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "Remove Row";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // ProductionPOSplitter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 362);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProductionPOSplitter";
            this.Text = "ProductionPOSplitter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_dataentry)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ResumeLayout(false);
            this.ultraPanel2.ClientArea.ResumeLayout(false);
            this.ultraPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_atcid;
        private System.Windows.Forms.Label lbl_ponum;
        private System.Windows.Forms.Label lbl_dateofprod;
        private System.Windows.Forms.Label lbl_linenum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_factid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView tbl_dataentry;
        private System.Windows.Forms.Panel panel1;
        private Infragistics.Win.Misc.UltraSplitter ultraSplitter1;
        private Infragistics.Win.Misc.UltraPanel ultraPanel2;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private System.Windows.Forms.DataGridViewComboBoxColumn POnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn POQty;
        private System.Windows.Forms.DataGridViewButtonColumn Add;
        private System.Windows.Forms.Label lbl_lineid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_qty;
        private System.Windows.Forms.Label Qty;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
    }
}