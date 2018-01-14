﻿namespace Shipit.Production
{
    partial class WeeklyPlanEdit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmb_month = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_factory = new System.Windows.Forms.ComboBox();
            this.cmb_year = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_lblproduced = new System.Windows.Forms.Label();
            this.lbl_target = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbl_weekrequirement = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.scheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToWeek2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToWeek3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToWeek4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToWeek5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleMonthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.januaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.februaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aprilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.juneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.julyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.augustToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.septemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.octoberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.reduceQtyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeDeliveryDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateStylenumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePONumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeFactoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitWeekPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shedulePOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_weekrequirement)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmb_month);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_factory);
            this.groupBox1.Controls.Add(this.cmb_year);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1051, 82);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Weekly Chart";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(869, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Get Allocations";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmb_month
            // 
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
            this.cmb_month.Location = new System.Drawing.Point(557, 40);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.Size = new System.Drawing.Size(121, 21);
            this.cmb_month.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(481, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Month";
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
            this.cmb_factory.Location = new System.Drawing.Point(90, 40);
            this.cmb_factory.Name = "cmb_factory";
            this.cmb_factory.Size = new System.Drawing.Size(121, 21);
            this.cmb_factory.TabIndex = 5;
            this.cmb_factory.SelectedIndexChanged += new System.EventHandler(this.cmb_factory_SelectedIndexChanged);
            // 
            // cmb_year
            // 
            this.cmb_year.FormattingEnabled = true;
            this.cmb_year.Items.AddRange(new object[] {
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cmb_year.Location = new System.Drawing.Point(299, 40);
            this.cmb_year.Name = "cmb_year";
            this.cmb_year.Size = new System.Drawing.Size(121, 21);
            this.cmb_year.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Year";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Factory : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_lblproduced);
            this.groupBox3.Controls.Add(this.lbl_target);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 515);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1051, 58);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Total";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbl_weekrequirement);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1051, 433);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scheduled";
            // 
            // tbl_weekrequirement
            // 
            this.tbl_weekrequirement.AllowUserToAddRows = false;
            this.tbl_weekrequirement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_weekrequirement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_weekrequirement.ContextMenuStrip = this.contextMenuStrip1;
            this.tbl_weekrequirement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_weekrequirement.Location = new System.Drawing.Point(3, 16);
            this.tbl_weekrequirement.Name = "tbl_weekrequirement";
            this.tbl_weekrequirement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbl_weekrequirement.Size = new System.Drawing.Size(1045, 414);
            this.tbl_weekrequirement.TabIndex = 0;
            this.tbl_weekrequirement.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl_weekrequirement_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleToolStripMenuItem,
            this.scheduleMonthToolStripMenuItem,
            this.updateYearToolStripMenuItem,
            this.reduceQtyToolStripMenuItem,
            this.changeDeliveryDateToolStripMenuItem,
            this.updateStylenumToolStripMenuItem,
            this.updatePONumToolStripMenuItem,
            this.deleteAllocationToolStripMenuItem,
            this.exportToExcelToolStripMenuItem,
            this.changeFactoryToolStripMenuItem,
            this.splitWeekPlanToolStripMenuItem,
            this.shedulePOToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(188, 290);
            // 
            // scheduleToolStripMenuItem
            // 
            this.scheduleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToolStripMenuItem,
            this.moveToWeek2ToolStripMenuItem,
            this.moveToWeek3ToolStripMenuItem,
            this.moveToWeek4ToolStripMenuItem,
            this.moveToWeek5ToolStripMenuItem});
            this.scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            this.scheduleToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.scheduleToolStripMenuItem.Text = "Schedule Week";
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.moveToolStripMenuItem.Text = "Move  To Week1";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // moveToWeek2ToolStripMenuItem
            // 
            this.moveToWeek2ToolStripMenuItem.Name = "moveToWeek2ToolStripMenuItem";
            this.moveToWeek2ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.moveToWeek2ToolStripMenuItem.Text = "Move  To Week2";
            this.moveToWeek2ToolStripMenuItem.Click += new System.EventHandler(this.moveToWeek2ToolStripMenuItem_Click);
            // 
            // moveToWeek3ToolStripMenuItem
            // 
            this.moveToWeek3ToolStripMenuItem.Name = "moveToWeek3ToolStripMenuItem";
            this.moveToWeek3ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.moveToWeek3ToolStripMenuItem.Text = "Move  To Week3";
            this.moveToWeek3ToolStripMenuItem.Click += new System.EventHandler(this.moveToWeek3ToolStripMenuItem_Click);
            // 
            // moveToWeek4ToolStripMenuItem
            // 
            this.moveToWeek4ToolStripMenuItem.Name = "moveToWeek4ToolStripMenuItem";
            this.moveToWeek4ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.moveToWeek4ToolStripMenuItem.Text = "Move  To Week4";
            this.moveToWeek4ToolStripMenuItem.Click += new System.EventHandler(this.moveToWeek4ToolStripMenuItem_Click);
            // 
            // moveToWeek5ToolStripMenuItem
            // 
            this.moveToWeek5ToolStripMenuItem.Name = "moveToWeek5ToolStripMenuItem";
            this.moveToWeek5ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.moveToWeek5ToolStripMenuItem.Text = "Move  To Week5";
            this.moveToWeek5ToolStripMenuItem.Click += new System.EventHandler(this.moveToWeek5ToolStripMenuItem_Click);
            // 
            // scheduleMonthToolStripMenuItem
            // 
            this.scheduleMonthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.januaryToolStripMenuItem,
            this.februaryToolStripMenuItem,
            this.marchToolStripMenuItem,
            this.aprilToolStripMenuItem,
            this.mayToolStripMenuItem,
            this.juneToolStripMenuItem,
            this.julyToolStripMenuItem,
            this.augustToolStripMenuItem,
            this.septemberToolStripMenuItem,
            this.octoberToolStripMenuItem,
            this.novemberToolStripMenuItem,
            this.decemberToolStripMenuItem});
            this.scheduleMonthToolStripMenuItem.Name = "scheduleMonthToolStripMenuItem";
            this.scheduleMonthToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.scheduleMonthToolStripMenuItem.Text = "Schedule Month";
            // 
            // januaryToolStripMenuItem
            // 
            this.januaryToolStripMenuItem.Name = "januaryToolStripMenuItem";
            this.januaryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.januaryToolStripMenuItem.Text = " January";
            this.januaryToolStripMenuItem.Click += new System.EventHandler(this.januaryToolStripMenuItem_Click);
            // 
            // februaryToolStripMenuItem
            // 
            this.februaryToolStripMenuItem.Name = "februaryToolStripMenuItem";
            this.februaryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.februaryToolStripMenuItem.Text = "February";
            this.februaryToolStripMenuItem.Click += new System.EventHandler(this.februaryToolStripMenuItem_Click);
            // 
            // marchToolStripMenuItem
            // 
            this.marchToolStripMenuItem.Name = "marchToolStripMenuItem";
            this.marchToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.marchToolStripMenuItem.Text = "March";
            this.marchToolStripMenuItem.Click += new System.EventHandler(this.marchToolStripMenuItem_Click);
            // 
            // aprilToolStripMenuItem
            // 
            this.aprilToolStripMenuItem.Name = "aprilToolStripMenuItem";
            this.aprilToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aprilToolStripMenuItem.Text = "April";
            this.aprilToolStripMenuItem.Click += new System.EventHandler(this.aprilToolStripMenuItem_Click);
            // 
            // mayToolStripMenuItem
            // 
            this.mayToolStripMenuItem.Name = "mayToolStripMenuItem";
            this.mayToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mayToolStripMenuItem.Text = "May ";
            this.mayToolStripMenuItem.Click += new System.EventHandler(this.mayToolStripMenuItem_Click);
            // 
            // juneToolStripMenuItem
            // 
            this.juneToolStripMenuItem.Name = "juneToolStripMenuItem";
            this.juneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.juneToolStripMenuItem.Text = "June";
            this.juneToolStripMenuItem.Click += new System.EventHandler(this.juneToolStripMenuItem_Click);
            // 
            // julyToolStripMenuItem
            // 
            this.julyToolStripMenuItem.Name = "julyToolStripMenuItem";
            this.julyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.julyToolStripMenuItem.Text = "July";
            this.julyToolStripMenuItem.Click += new System.EventHandler(this.julyToolStripMenuItem_Click);
            // 
            // augustToolStripMenuItem
            // 
            this.augustToolStripMenuItem.Name = "augustToolStripMenuItem";
            this.augustToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.augustToolStripMenuItem.Text = "August";
            this.augustToolStripMenuItem.Click += new System.EventHandler(this.augustToolStripMenuItem_Click);
            // 
            // septemberToolStripMenuItem
            // 
            this.septemberToolStripMenuItem.Name = "septemberToolStripMenuItem";
            this.septemberToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.septemberToolStripMenuItem.Text = "September";
            this.septemberToolStripMenuItem.Click += new System.EventHandler(this.septemberToolStripMenuItem_Click);
            // 
            // octoberToolStripMenuItem
            // 
            this.octoberToolStripMenuItem.Name = "octoberToolStripMenuItem";
            this.octoberToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.octoberToolStripMenuItem.Text = "October";
            this.octoberToolStripMenuItem.Click += new System.EventHandler(this.octoberToolStripMenuItem_Click);
            // 
            // novemberToolStripMenuItem
            // 
            this.novemberToolStripMenuItem.Name = "novemberToolStripMenuItem";
            this.novemberToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.novemberToolStripMenuItem.Text = "November";
            this.novemberToolStripMenuItem.Click += new System.EventHandler(this.novemberToolStripMenuItem_Click);
            // 
            // decemberToolStripMenuItem
            // 
            this.decemberToolStripMenuItem.Name = "decemberToolStripMenuItem";
            this.decemberToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.decemberToolStripMenuItem.Text = "December";
            this.decemberToolStripMenuItem.Click += new System.EventHandler(this.decemberToolStripMenuItem_Click);
            // 
            // updateYearToolStripMenuItem
            // 
            this.updateYearToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.updateYearToolStripMenuItem.Name = "updateYearToolStripMenuItem";
            this.updateYearToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.updateYearToolStripMenuItem.Text = "Update Year";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem2.Text = "2015";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem3.Text = "2016";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem4.Text = "2017";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem5.Text = "2018";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // reduceQtyToolStripMenuItem
            // 
            this.reduceQtyToolStripMenuItem.Name = "reduceQtyToolStripMenuItem";
            this.reduceQtyToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.reduceQtyToolStripMenuItem.Text = "Reduce Qty";
            this.reduceQtyToolStripMenuItem.Click += new System.EventHandler(this.reduceQtyToolStripMenuItem_Click);
            // 
            // changeDeliveryDateToolStripMenuItem
            // 
            this.changeDeliveryDateToolStripMenuItem.Name = "changeDeliveryDateToolStripMenuItem";
            this.changeDeliveryDateToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.changeDeliveryDateToolStripMenuItem.Text = "Change Delivery Date";
            this.changeDeliveryDateToolStripMenuItem.Click += new System.EventHandler(this.changeDeliveryDateToolStripMenuItem_Click);
            // 
            // updateStylenumToolStripMenuItem
            // 
            this.updateStylenumToolStripMenuItem.Name = "updateStylenumToolStripMenuItem";
            this.updateStylenumToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.updateStylenumToolStripMenuItem.Text = "Update Stylenum";
            this.updateStylenumToolStripMenuItem.Click += new System.EventHandler(this.updateStylenumToolStripMenuItem_Click);
            // 
            // updatePONumToolStripMenuItem
            // 
            this.updatePONumToolStripMenuItem.Name = "updatePONumToolStripMenuItem";
            this.updatePONumToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.updatePONumToolStripMenuItem.Text = "Update PO Num";
            this.updatePONumToolStripMenuItem.Click += new System.EventHandler(this.updatePONumToolStripMenuItem_Click);
            // 
            // deleteAllocationToolStripMenuItem
            // 
            this.deleteAllocationToolStripMenuItem.Name = "deleteAllocationToolStripMenuItem";
            this.deleteAllocationToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.deleteAllocationToolStripMenuItem.Text = "Delete Allocation";
            this.deleteAllocationToolStripMenuItem.Click += new System.EventHandler(this.deleteAllocationToolStripMenuItem_Click);
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
            // 
            // changeFactoryToolStripMenuItem
            // 
            this.changeFactoryToolStripMenuItem.Name = "changeFactoryToolStripMenuItem";
            this.changeFactoryToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.changeFactoryToolStripMenuItem.Text = "Change Factory";
            this.changeFactoryToolStripMenuItem.Click += new System.EventHandler(this.changeFactoryToolStripMenuItem_Click);
            // 
            // splitWeekPlanToolStripMenuItem
            // 
            this.splitWeekPlanToolStripMenuItem.Name = "splitWeekPlanToolStripMenuItem";
            this.splitWeekPlanToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.splitWeekPlanToolStripMenuItem.Text = "Split Week Plan";
            this.splitWeekPlanToolStripMenuItem.Click += new System.EventHandler(this.splitWeekPlanToolStripMenuItem_Click);
            // 
            // shedulePOToolStripMenuItem
            // 
            this.shedulePOToolStripMenuItem.Name = "shedulePOToolStripMenuItem";
            this.shedulePOToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.shedulePOToolStripMenuItem.Text = "Shedule PO";
            this.shedulePOToolStripMenuItem.Click += new System.EventHandler(this.shedulePOToolStripMenuItem_Click);
            // 
            // WeeklyPlanEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 573);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "WeeklyPlanEdit";
            this.Text = "WeeklyPlanEdit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_weekrequirement)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmb_month;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_factory;
        private System.Windows.Forms.ComboBox cmb_year;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_lblproduced;
        private System.Windows.Forms.Label lbl_target;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView tbl_weekrequirement;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem scheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToWeek2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToWeek3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToWeek4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToWeek5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleMonthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem januaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem februaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aprilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem juneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem julyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem augustToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem septemberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem octoberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novemberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decemberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reduceQtyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeDeliveryDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateStylenumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatePONumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeFactoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem splitWeekPlanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem shedulePOToolStripMenuItem;
    }
}