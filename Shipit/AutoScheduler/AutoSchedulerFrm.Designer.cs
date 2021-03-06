﻿namespace Shipit.AutoScheduler
{
    partial class AutoSchedulerFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoSchedulerFrm));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmb_month = new System.Windows.Forms.ComboBox();
            this.cmb_year = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmb_week = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_factory_id = new System.Windows.Forms.Label();
            this.txt_balanceCapacity = new System.Windows.Forms.TextBox();
            this.txt_weeklycapacity = new System.Windows.Forms.TextBox();
            this.txt_scheduledCapacity = new System.Windows.Forms.TextBox();
            this.txt_factoryname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_totalqty = new System.Windows.Forms.TextBox();
            this.txt_scheduledQty = new System.Windows.Forms.TextBox();
            this.txt_consumptionQty = new System.Windows.Forms.TextBox();
            this.txt_bookID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbl_lblproduced = new System.Windows.Forms.Label();
            this.lbl_target = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_atc = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmb_PO = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmb_factory = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dtp_psd = new System.Windows.Forms.DateTimePicker();
            this.dtp_delivery = new System.Windows.Forms.DateTimePicker();
            this.txt_style = new System.Windows.Forms.TextBox();
            this.txt_po = new System.Windows.Forms.TextBox();
            this.txt_qty = new System.Windows.Forms.TextBox();
            this.txt_capperday = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbl_Weekdata = new System.Windows.Forms.DataGridView();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weeknum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PONum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StyleNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualDelivery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Consumption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Factid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmb_ourStyle = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Weekdata)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmb_month);
            this.groupBox4.Controls.Add(this.cmb_year);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.cmb_week);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(6, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(504, 82);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Week Details";
            // 
            // cmb_month
            // 
            this.cmb_month.Enabled = false;
            this.cmb_month.FormattingEnabled = true;
            this.cmb_month.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmb_month.Location = new System.Drawing.Point(352, 16);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.Size = new System.Drawing.Size(121, 21);
            this.cmb_month.TabIndex = 23;
            // 
            // cmb_year
            // 
            this.cmb_year.Enabled = false;
            this.cmb_year.FormattingEnabled = true;
            this.cmb_year.Items.AddRange(new object[] {
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cmb_year.Location = new System.Drawing.Point(84, 16);
            this.cmb_year.Name = "cmb_year";
            this.cmb_year.Size = new System.Drawing.Size(121, 21);
            this.cmb_year.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(291, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Month :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Year :";
            // 
            // cmb_week
            // 
            this.cmb_week.Enabled = false;
            this.cmb_week.FormattingEnabled = true;
            this.cmb_week.Items.AddRange(new object[] {
            "Week1",
            "Week2",
            "Week3",
            "Week4",
            "Week5"});
            this.cmb_week.Location = new System.Drawing.Point(83, 46);
            this.cmb_week.Name = "cmb_week";
            this.cmb_week.Size = new System.Drawing.Size(121, 21);
            this.cmb_week.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Week :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1048, 104);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_factory_id);
            this.groupBox2.Controls.Add(this.txt_balanceCapacity);
            this.groupBox2.Controls.Add(this.txt_weeklycapacity);
            this.groupBox2.Controls.Add(this.txt_scheduledCapacity);
            this.groupBox2.Controls.Add(this.txt_factoryname);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(538, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 82);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Factory Details";
            // 
            // lbl_factory_id
            // 
            this.lbl_factory_id.AutoSize = true;
            this.lbl_factory_id.Location = new System.Drawing.Point(246, 24);
            this.lbl_factory_id.Name = "lbl_factory_id";
            this.lbl_factory_id.Size = new System.Drawing.Size(16, 13);
            this.lbl_factory_id.TabIndex = 13;
            this.lbl_factory_id.Text = "0 ";
            // 
            // txt_balanceCapacity
            // 
            this.txt_balanceCapacity.Enabled = false;
            this.txt_balanceCapacity.Location = new System.Drawing.Point(395, 60);
            this.txt_balanceCapacity.Name = "txt_balanceCapacity";
            this.txt_balanceCapacity.Size = new System.Drawing.Size(100, 20);
            this.txt_balanceCapacity.TabIndex = 12;
            // 
            // txt_weeklycapacity
            // 
            this.txt_weeklycapacity.Enabled = false;
            this.txt_weeklycapacity.Location = new System.Drawing.Point(395, 24);
            this.txt_weeklycapacity.Name = "txt_weeklycapacity";
            this.txt_weeklycapacity.Size = new System.Drawing.Size(100, 20);
            this.txt_weeklycapacity.TabIndex = 11;
            // 
            // txt_scheduledCapacity
            // 
            this.txt_scheduledCapacity.Enabled = false;
            this.txt_scheduledCapacity.Location = new System.Drawing.Point(125, 54);
            this.txt_scheduledCapacity.Name = "txt_scheduledCapacity";
            this.txt_scheduledCapacity.Size = new System.Drawing.Size(100, 20);
            this.txt_scheduledCapacity.TabIndex = 10;
            // 
            // txt_factoryname
            // 
            this.txt_factoryname.Enabled = false;
            this.txt_factoryname.Location = new System.Drawing.Point(125, 21);
            this.txt_factoryname.Name = "txt_factoryname";
            this.txt_factoryname.Size = new System.Drawing.Size(100, 20);
            this.txt_factoryname.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Factory :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Balance Capacity:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Weekly Capacity :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Scheduled capacity :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_totalqty);
            this.groupBox3.Controls.Add(this.txt_scheduledQty);
            this.groupBox3.Controls.Add(this.txt_consumptionQty);
            this.groupBox3.Controls.Add(this.txt_bookID);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(6, 109);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(504, 100);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Booking Details";
            // 
            // txt_totalqty
            // 
            this.txt_totalqty.Enabled = false;
            this.txt_totalqty.Location = new System.Drawing.Point(395, 30);
            this.txt_totalqty.Name = "txt_totalqty";
            this.txt_totalqty.Size = new System.Drawing.Size(100, 20);
            this.txt_totalqty.TabIndex = 12;
            // 
            // txt_scheduledQty
            // 
            this.txt_scheduledQty.Enabled = false;
            this.txt_scheduledQty.Location = new System.Drawing.Point(395, 73);
            this.txt_scheduledQty.Name = "txt_scheduledQty";
            this.txt_scheduledQty.Size = new System.Drawing.Size(100, 20);
            this.txt_scheduledQty.TabIndex = 13;
            // 
            // txt_consumptionQty
            // 
            this.txt_consumptionQty.Enabled = false;
            this.txt_consumptionQty.Location = new System.Drawing.Point(125, 73);
            this.txt_consumptionQty.Name = "txt_consumptionQty";
            this.txt_consumptionQty.Size = new System.Drawing.Size(100, 20);
            this.txt_consumptionQty.TabIndex = 14;
            // 
            // txt_bookID
            // 
            this.txt_bookID.Enabled = false;
            this.txt_bookID.Location = new System.Drawing.Point(125, 26);
            this.txt_bookID.Name = "txt_bookID";
            this.txt_bookID.Size = new System.Drawing.Size(100, 20);
            this.txt_bookID.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Book ID :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(246, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Already Scheduled Qty :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(291, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Total  Quantity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Consumption Qty :";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Location = new System.Drawing.Point(529, 110);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(504, 99);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "New Scheduling";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Capacity Per 8 Hours :";
            this.label9.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(278, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "S";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lbl_lblproduced);
            this.groupBox6.Controls.Add(this.lbl_target);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(0, 567);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1048, 58);
            this.groupBox6.TabIndex = 18;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Total";
            // 
            // lbl_lblproduced
            // 
            this.lbl_lblproduced.AutoSize = true;
            this.lbl_lblproduced.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lblproduced.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_lblproduced.Location = new System.Drawing.Point(591, 33);
            this.lbl_lblproduced.Name = "lbl_lblproduced";
            this.lbl_lblproduced.Size = new System.Drawing.Size(16, 16);
            this.lbl_lblproduced.TabIndex = 18;
            this.lbl_lblproduced.Text = "0";
            // 
            // lbl_target
            // 
            this.lbl_target.AutoSize = true;
            this.lbl_target.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_target.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_target.Location = new System.Drawing.Point(193, 32);
            this.lbl_target.Name = "lbl_target";
            this.lbl_target.Size = new System.Drawing.Size(16, 16);
            this.lbl_target.TabIndex = 17;
            this.lbl_target.Text = "0";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 542);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1048, 25);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmb_ourStyle);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.cmb_atc);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.cmb_PO);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cmb_factory);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.dtp_psd);
            this.panel1.Controls.Add(this.dtp_delivery);
            this.panel1.Controls.Add(this.txt_style);
            this.panel1.Controls.Add(this.txt_po);
            this.panel1.Controls.Add(this.txt_qty);
            this.panel1.Controls.Add(this.txt_capperday);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(0, 215);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 155);
            this.panel1.TabIndex = 21;
            // 
            // cmb_atc
            // 
            this.cmb_atc.FormattingEnabled = true;
            this.cmb_atc.Location = new System.Drawing.Point(121, 8);
            this.cmb_atc.Name = "cmb_atc";
            this.cmb_atc.Size = new System.Drawing.Size(132, 21);
            this.cmb_atc.TabIndex = 27;
            this.cmb_atc.SelectedIndexChanged += new System.EventHandler(this.cmb_atc_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(31, 14);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(26, 13);
            this.label21.TabIndex = 26;
            this.label21.Text = "Art :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(27, 75);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 13);
            this.label20.TabIndex = 25;
            this.label20.Text = "ASQ/Buyer PO : ";
            // 
            // cmb_PO
            // 
            this.cmb_PO.FormattingEnabled = true;
            this.cmb_PO.Location = new System.Drawing.Point(121, 72);
            this.cmb_PO.Name = "cmb_PO";
            this.cmb_PO.Size = new System.Drawing.Size(444, 21);
            this.cmb_PO.TabIndex = 24;
            this.cmb_PO.SelectedIndexChanged += new System.EventHandler(this.cmb_PO_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(834, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Factory : ";
            // 
            // cmb_factory
            // 
            this.cmb_factory.FormattingEnabled = true;
            this.cmb_factory.Items.AddRange(new object[] {
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cmb_factory.Location = new System.Drawing.Point(790, 127);
            this.cmb_factory.Name = "cmb_factory";
            this.cmb_factory.Size = new System.Drawing.Size(160, 21);
            this.cmb_factory.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(961, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Show Slots";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // dtp_psd
            // 
            this.dtp_psd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_psd.Location = new System.Drawing.Point(403, 128);
            this.dtp_psd.Name = "dtp_psd";
            this.dtp_psd.Size = new System.Drawing.Size(105, 20);
            this.dtp_psd.TabIndex = 4;
            // 
            // dtp_delivery
            // 
            this.dtp_delivery.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_delivery.Location = new System.Drawing.Point(254, 128);
            this.dtp_delivery.Name = "dtp_delivery";
            this.dtp_delivery.Size = new System.Drawing.Size(105, 20);
            this.dtp_delivery.TabIndex = 3;
            // 
            // txt_style
            // 
            this.txt_style.Location = new System.Drawing.Point(134, 128);
            this.txt_style.Name = "txt_style";
            this.txt_style.Size = new System.Drawing.Size(100, 20);
            this.txt_style.TabIndex = 2;
            // 
            // txt_po
            // 
            this.txt_po.Location = new System.Drawing.Point(9, 128);
            this.txt_po.Name = "txt_po";
            this.txt_po.Size = new System.Drawing.Size(103, 20);
            this.txt_po.TabIndex = 1;
            // 
            // txt_qty
            // 
            this.txt_qty.Location = new System.Drawing.Point(666, 128);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.Size = new System.Drawing.Size(100, 20);
            this.txt_qty.TabIndex = 6;
            // 
            // txt_capperday
            // 
            this.txt_capperday.Location = new System.Drawing.Point(532, 128);
            this.txt_capperday.Name = "txt_capperday";
            this.txt_capperday.Size = new System.Drawing.Size(100, 20);
            this.txt_capperday.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(529, 99);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(113, 13);
            this.label19.TabIndex = 13;
            this.label19.Text = "Capacity Per 8 Hours :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(692, 99);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "Qty : ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(430, 99);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 11;
            this.label17.Text = "PSD : ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(35, 99);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Po # ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(159, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Style # : ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(266, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "PO Delivery";
            // 
            // tbl_Weekdata
            // 
            this.tbl_Weekdata.AllowUserToAddRows = false;
            this.tbl_Weekdata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbl_Weekdata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_Weekdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_Weekdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Year,
            this.Month,
            this.Weeknum,
            this.PONum,
            this.StyleNum,
            this.Qty,
            this.ActualDelivery,
            this.CSD,
            this.Consumption,
            this.Factid});
            this.tbl_Weekdata.Location = new System.Drawing.Point(0, 376);
            this.tbl_Weekdata.Name = "tbl_Weekdata";
            this.tbl_Weekdata.Size = new System.Drawing.Size(1042, 152);
            this.tbl_Weekdata.TabIndex = 20;
            this.tbl_Weekdata.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.tbl_Weekdata.CurrentCellDirtyStateChanged += new System.EventHandler(this.tbl_Weekdata_CurrentCellDirtyStateChanged);
            // 
            // Year
            // 
            this.Year.HeaderText = "Year";
            this.Year.Name = "Year";
            // 
            // Month
            // 
            this.Month.HeaderText = "Month";
            this.Month.Name = "Month";
            // 
            // Weeknum
            // 
            this.Weeknum.HeaderText = "Weeknum";
            this.Weeknum.Name = "Weeknum";
            // 
            // PONum
            // 
            this.PONum.HeaderText = "PO#";
            this.PONum.Name = "PONum";
            // 
            // StyleNum
            // 
            this.StyleNum.HeaderText = "StyleNum";
            this.StyleNum.Name = "StyleNum";
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            // 
            // ActualDelivery
            // 
            this.ActualDelivery.HeaderText = "ActualDelivery";
            this.ActualDelivery.Name = "ActualDelivery";
            // 
            // CSD
            // 
            this.CSD.HeaderText = "CSD";
            this.CSD.Name = "CSD";
            // 
            // Consumption
            // 
            this.Consumption.HeaderText = "Consumption";
            this.Consumption.Name = "Consumption";
            // 
            // Factid
            // 
            this.Factid.HeaderText = "Factid";
            this.Factid.Name = "Factid";
            // 
            // cmb_ourStyle
            // 
            this.cmb_ourStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ourStyle.FormattingEnabled = true;
            this.cmb_ourStyle.Location = new System.Drawing.Point(120, 41);
            this.cmb_ourStyle.Name = "cmb_ourStyle";
            this.cmb_ourStyle.Size = new System.Drawing.Size(200, 21);
            this.cmb_ourStyle.TabIndex = 29;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(31, 41);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 13);
            this.label22.TabIndex = 28;
            this.label22.Text = "OurStyle : ";
            // 
            // AutoSchedulerFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 625);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbl_Weekdata);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "AutoSchedulerFrm";
            this.Text = "AutoScheduler";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Weekdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmb_month;
        private System.Windows.Forms.ComboBox cmb_year;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmb_week;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_factory_id;
        private System.Windows.Forms.TextBox txt_balanceCapacity;
        private System.Windows.Forms.TextBox txt_weeklycapacity;
        private System.Windows.Forms.TextBox txt_scheduledCapacity;
        private System.Windows.Forms.TextBox txt_factoryname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_totalqty;
        private System.Windows.Forms.TextBox txt_scheduledQty;
        private System.Windows.Forms.TextBox txt_consumptionQty;
        private System.Windows.Forms.TextBox txt_bookID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lbl_lblproduced;
        private System.Windows.Forms.Label lbl_target;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dtp_psd;
        private System.Windows.Forms.DateTimePicker dtp_delivery;
        private System.Windows.Forms.TextBox txt_style;
        private System.Windows.Forms.TextBox txt_po;
        private System.Windows.Forms.TextBox txt_qty;
        private System.Windows.Forms.TextBox txt_capperday;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView tbl_Weekdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weeknum;
        private System.Windows.Forms.DataGridViewTextBoxColumn PONum;
        private System.Windows.Forms.DataGridViewTextBoxColumn StyleNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualDelivery;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Consumption;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factid;
        private System.Windows.Forms.ComboBox cmb_factory;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmb_PO;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmb_atc;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmb_ourStyle;
        private System.Windows.Forms.Label label22;
    }
}