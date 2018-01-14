﻿namespace Shipit.Production
{
    partial class WeekPlanviewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeekPlanviewer));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_message = new System.Windows.Forms.Label();
            this.cmb_factory = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmb_month = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_year = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_motham = new System.Windows.Forms.Label();
            this.lbl_dec = new System.Windows.Forms.Label();
            this.lbl_feb = new System.Windows.Forms.Label();
            this.lbl_jan = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editQtyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.multiLineChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lbl_message);
            this.groupBox1.Controls.Add(this.cmb_factory);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmb_month);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_year);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1038, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Weekly Chart";
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_message.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_message.Location = new System.Drawing.Point(259, 82);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(13, 15);
            this.lbl_message.TabIndex = 14;
            this.lbl_message.Text = "*";
            // 
            // cmb_factory
            // 
            this.cmb_factory.FormattingEnabled = true;
            this.cmb_factory.Location = new System.Drawing.Point(78, 40);
            this.cmb_factory.Name = "cmb_factory";
            this.cmb_factory.Size = new System.Drawing.Size(121, 21);
            this.cmb_factory.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(587, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Show";
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
            this.cmb_month.Location = new System.Drawing.Point(443, 40);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.Size = new System.Drawing.Size(121, 21);
            this.cmb_month.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Month";
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
            this.cmb_year.Location = new System.Drawing.Point(262, 40);
            this.cmb_year.Name = "cmb_year";
            this.cmb_year.Size = new System.Drawing.Size(121, 21);
            this.cmb_year.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 43);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 477);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1038, 90);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "***";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 4);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1032, 25);
            this.toolStrip1.TabIndex = 16;
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
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Controls.Add(this.lbl_motham);
            this.groupBox3.Controls.Add(this.lbl_dec);
            this.groupBox3.Controls.Add(this.lbl_feb);
            this.groupBox3.Controls.Add(this.lbl_jan);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1032, 58);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Total";
            // 
            // lbl_motham
            // 
            this.lbl_motham.AutoSize = true;
            this.lbl_motham.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_motham.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_motham.Location = new System.Drawing.Point(1406, 27);
            this.lbl_motham.Name = "lbl_motham";
            this.lbl_motham.Size = new System.Drawing.Size(16, 16);
            this.lbl_motham.TabIndex = 16;
            this.lbl_motham.Text = "0";
            // 
            // lbl_dec
            // 
            this.lbl_dec.AutoSize = true;
            this.lbl_dec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dec.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_dec.Location = new System.Drawing.Point(1291, 27);
            this.lbl_dec.Name = "lbl_dec";
            this.lbl_dec.Size = new System.Drawing.Size(16, 16);
            this.lbl_dec.TabIndex = 15;
            this.lbl_dec.Text = "0";
            // 
            // lbl_feb
            // 
            this.lbl_feb.AutoSize = true;
            this.lbl_feb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_feb.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_feb.Location = new System.Drawing.Point(141, 27);
            this.lbl_feb.Name = "lbl_feb";
            this.lbl_feb.Size = new System.Drawing.Size(16, 16);
            this.lbl_feb.TabIndex = 5;
            this.lbl_feb.Text = "0";
            // 
            // lbl_jan
            // 
            this.lbl_jan.AutoSize = true;
            this.lbl_jan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_jan.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_jan.Location = new System.Drawing.Point(26, 27);
            this.lbl_jan.Name = "lbl_jan";
            this.lbl_jan.Size = new System.Drawing.Size(16, 16);
            this.lbl_jan.TabIndex = 0;
            this.lbl_jan.Text = "0";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editQtyToolStripMenuItem,
            this.deletePlanToolStripMenuItem,
            this.changeLineToolStripMenuItem,
            this.multiLineChangeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(175, 114);
            // 
            // editQtyToolStripMenuItem
            // 
            this.editQtyToolStripMenuItem.Name = "editQtyToolStripMenuItem";
            this.editQtyToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.editQtyToolStripMenuItem.Text = "Edit Qty";
            this.editQtyToolStripMenuItem.Click += new System.EventHandler(this.editQtyToolStripMenuItem_Click);
            // 
            // deletePlanToolStripMenuItem
            // 
            this.deletePlanToolStripMenuItem.Name = "deletePlanToolStripMenuItem";
            this.deletePlanToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.deletePlanToolStripMenuItem.Text = "Delete Plan";
            this.deletePlanToolStripMenuItem.Click += new System.EventHandler(this.deletePlanToolStripMenuItem_Click);
            // 
            // changeLineToolStripMenuItem
            // 
            this.changeLineToolStripMenuItem.Name = "changeLineToolStripMenuItem";
            this.changeLineToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.changeLineToolStripMenuItem.Text = "Change Line";
            this.changeLineToolStripMenuItem.Click += new System.EventHandler(this.changeLineToolStripMenuItem_Click);
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.ContextMenuStrip = this.contextMenuStrip1;
            this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Location = new System.Drawing.Point(0, 100);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(1038, 377);
            this.ultraGrid1.TabIndex = 6;
            this.ultraGrid1.Text = "Line Plan";
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            this.ultraGrid1.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.ultraGrid1_CellChange);
            // 
            // multiLineChangeToolStripMenuItem
            // 
            this.multiLineChangeToolStripMenuItem.Name = "multiLineChangeToolStripMenuItem";
            this.multiLineChangeToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.multiLineChangeToolStripMenuItem.Text = "Multi Line Change ";
            this.multiLineChangeToolStripMenuItem.Click += new System.EventHandler(this.multiLineChangeToolStripMenuItem_Click);
            // 
            // WeekPlanviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 567);
            this.Controls.Add(this.ultraGrid1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "WeekPlanviewer";
            this.Text = "WeekPlanviewer";
            this.Load += new System.EventHandler(this.WeekPlanviewer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_message;
        private System.Windows.Forms.ComboBox cmb_factory;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmb_month;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_year;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_motham;
        private System.Windows.Forms.Label lbl_dec;
        private System.Windows.Forms.Label lbl_feb;
        private System.Windows.Forms.Label lbl_jan;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editQtyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePlanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeLineToolStripMenuItem;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private System.Windows.Forms.ToolStripMenuItem multiLineChangeToolStripMenuItem;
    }
}