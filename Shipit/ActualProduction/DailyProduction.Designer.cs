namespace Shipit
{
    partial class DailyProduction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyProduction));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_ourStyle = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmb_PO = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_Atc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_line = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tbl_dataentry = new System.Windows.Forms.DataGridView();
            this.PO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProducedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operators = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Writer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Feeder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BundleMover = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supervisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Helper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Helpers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_dataentry)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_ourStyle);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmb_PO);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmb_Atc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_line);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(998, 222);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter Production";
            // 
            // cmb_ourStyle
            // 
            this.cmb_ourStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ourStyle.FormattingEnabled = true;
            this.cmb_ourStyle.Location = new System.Drawing.Point(111, 146);
            this.cmb_ourStyle.Name = "cmb_ourStyle";
            this.cmb_ourStyle.Size = new System.Drawing.Size(200, 21);
            this.cmb_ourStyle.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "OurStyle : ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(317, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "S";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmb_PO
            // 
            this.cmb_PO.FormattingEnabled = true;
            this.cmb_PO.Location = new System.Drawing.Point(111, 183);
            this.cmb_PO.Name = "cmb_PO";
            this.cmb_PO.Size = new System.Drawing.Size(200, 21);
            this.cmb_PO.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "PO # : ";
            // 
            // cmb_Atc
            // 
            this.cmb_Atc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Atc.FormattingEnabled = true;
            this.cmb_Atc.Location = new System.Drawing.Point(111, 116);
            this.cmb_Atc.Name = "cmb_Atc";
            this.cmb_Atc.Size = new System.Drawing.Size(200, 21);
            this.cmb_Atc.TabIndex = 5;
            this.cmb_Atc.SelectedIndexChanged += new System.EventHandler(this.cmb_Atc_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Atc : ";
            // 
            // cmb_line
            // 
            this.cmb_line.FormattingEnabled = true;
            this.cmb_line.Location = new System.Drawing.Point(111, 78);
            this.cmb_line.Name = "cmb_line";
            this.cmb_line.Size = new System.Drawing.Size(200, 21);
            this.cmb_line.TabIndex = 3;
            this.cmb_line.SelectedIndexChanged += new System.EventHandler(this.cmb_line_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Line  : ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(111, 31);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // tbl_dataentry
            // 
            this.tbl_dataentry.AllowUserToAddRows = false;
            this.tbl_dataentry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_dataentry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_dataentry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PO,
            this.ProducedQty,
            this.Operators,
            this.Writer,
            this.Feeder,
            this.BundleMover,
            this.Supervisor,
            this.PE,
            this.Helper,
            this.Helpers,
            this.Hours});
            this.tbl_dataentry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_dataentry.Location = new System.Drawing.Point(0, 0);
            this.tbl_dataentry.Name = "tbl_dataentry";
            this.tbl_dataentry.Size = new System.Drawing.Size(998, 206);
            this.tbl_dataentry.TabIndex = 1;
            this.tbl_dataentry.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_dataentry_CellValueChanged);
            this.tbl_dataentry.CurrentCellDirtyStateChanged += new System.EventHandler(this.tbl_dataentry_CurrentCellDirtyStateChanged);
            this.tbl_dataentry.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.tbl_dataentry_EditingControlShowing);
            this.tbl_dataentry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbl_dataentry_KeyPress);
            // 
            // PO
            // 
            this.PO.HeaderText = "PO";
            this.PO.Name = "PO";
            // 
            // ProducedQty
            // 
            this.ProducedQty.HeaderText = "ProducedQty";
            this.ProducedQty.Name = "ProducedQty";
            // 
            // Operators
            // 
            this.Operators.HeaderText = "Operators";
            this.Operators.Name = "Operators";
            // 
            // Writer
            // 
            this.Writer.HeaderText = "Writer";
            this.Writer.Name = "Writer";
            // 
            // Feeder
            // 
            this.Feeder.HeaderText = "Feeder";
            this.Feeder.Name = "Feeder";
            // 
            // BundleMover
            // 
            this.BundleMover.HeaderText = "BundleMover";
            this.BundleMover.Name = "BundleMover";
            // 
            // Supervisor
            // 
            this.Supervisor.HeaderText = "Supervisor";
            this.Supervisor.Name = "Supervisor";
            // 
            // PE
            // 
            this.PE.HeaderText = "PE";
            this.PE.Name = "PE";
            // 
            // Helper
            // 
            this.Helper.HeaderText = "Helper";
            this.Helper.Name = "Helper";
            // 
            // Helpers
            // 
            this.Helpers.HeaderText = " Total Helpers";
            this.Helpers.Name = "Helpers";
            this.Helpers.ReadOnly = true;
            // 
            // Hours
            // 
            this.Hours.HeaderText = "OT Hours";
            this.Hours.Name = "Hours";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tbl_dataentry);
            this.panel1.Location = new System.Drawing.Point(0, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 206);
            this.panel1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 437);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(998, 25);
            this.toolStrip1.TabIndex = 19;
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
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
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
            // DailyProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 462);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "DailyProduction";
            this.Text = "DailyProduction";
            this.Load += new System.EventHandler(this.DailyProduction_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_dataentry)).EndInit();
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_Atc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_line;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_PO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView tbl_dataentry;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProducedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operators;
        private System.Windows.Forms.DataGridViewTextBoxColumn Writer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Feeder;
        private System.Windows.Forms.DataGridViewTextBoxColumn BundleMover;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supervisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn PE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Helper;
        private System.Windows.Forms.DataGridViewTextBoxColumn Helpers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hours;
        private System.Windows.Forms.ComboBox cmb_ourStyle;
        private System.Windows.Forms.Label label5;
    }
}