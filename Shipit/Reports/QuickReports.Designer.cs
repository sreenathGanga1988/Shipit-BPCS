namespace Shipit.Reports
{
    partial class QuickReports
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip7 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.showLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalAttendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.croppedDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualCapacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packingReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmb_factory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_year = new System.Windows.Forms.ComboBox();
            this.cmb_month = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.projectionOfPODeliveryDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            this.menuStrip7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dtp_to);
            this.panel2.Controls.Add(this.dtp_from);
            this.panel2.Controls.Add(this.menuStrip7);
            this.panel2.Controls.Add(this.cmb_factory);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmb_year);
            this.panel2.Controls.Add(this.cmb_month);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1047, 161);
            this.panel2.TabIndex = 8;
            // 
            // menuStrip7
            // 
            this.menuStrip7.AllowMerge = false;
            this.menuStrip7.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.showLogToolStripMenuItem,
            this.finalAttendanceToolStripMenuItem,
            this.croppedDataToolStripMenuItem,
            this.exportToExcelToolStripMenuItem,
            this.actualCapacityToolStripMenuItem,
            this.productionReportToolStripMenuItem,
            this.packingReportToolStripMenuItem,
            this.projectionOfPODeliveryDateToolStripMenuItem});
            this.menuStrip7.Location = new System.Drawing.Point(0, 134);
            this.menuStrip7.Name = "menuStrip7";
            this.menuStrip7.Size = new System.Drawing.Size(1047, 27);
            this.menuStrip7.TabIndex = 34;
            this.menuStrip7.Text = "menuStrip7";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(54, 23);
            this.toolStripMenuItem2.Text = "Cancel";
            // 
            // showLogToolStripMenuItem
            // 
            this.showLogToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.showLogToolStripMenuItem.Name = "showLogToolStripMenuItem";
            this.showLogToolStripMenuItem.Size = new System.Drawing.Size(69, 23);
            this.showLogToolStripMenuItem.Text = "POStatus";
            this.showLogToolStripMenuItem.Click += new System.EventHandler(this.showLogToolStripMenuItem_Click);
            // 
            // finalAttendanceToolStripMenuItem
            // 
            this.finalAttendanceToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.finalAttendanceToolStripMenuItem.Name = "finalAttendanceToolStripMenuItem";
            this.finalAttendanceToolStripMenuItem.Size = new System.Drawing.Size(102, 23);
            this.finalAttendanceToolStripMenuItem.Text = "Monthly Status";
            this.finalAttendanceToolStripMenuItem.Click += new System.EventHandler(this.finalAttendanceToolStripMenuItem_Click);
            // 
            // croppedDataToolStripMenuItem
            // 
            this.croppedDataToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.croppedDataToolStripMenuItem.Name = "croppedDataToolStripMenuItem";
            this.croppedDataToolStripMenuItem.Size = new System.Drawing.Size(110, 23);
            this.croppedDataToolStripMenuItem.Text = "Atc Line Capacity";
            this.croppedDataToolStripMenuItem.Click += new System.EventHandler(this.croppedDataToolStripMenuItem_Click);
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(100, 23);
            this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
            // 
            // actualCapacityToolStripMenuItem
            // 
            this.actualCapacityToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.actualCapacityToolStripMenuItem.Name = "actualCapacityToolStripMenuItem";
            this.actualCapacityToolStripMenuItem.Size = new System.Drawing.Size(101, 23);
            this.actualCapacityToolStripMenuItem.Text = "Actual Capacity";
            this.actualCapacityToolStripMenuItem.Click += new System.EventHandler(this.actualCapacityToolStripMenuItem_Click);
            // 
            // productionReportToolStripMenuItem
            // 
            this.productionReportToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.productionReportToolStripMenuItem.Name = "productionReportToolStripMenuItem";
            this.productionReportToolStripMenuItem.Size = new System.Drawing.Size(120, 23);
            this.productionReportToolStripMenuItem.Text = "Production Report";
            this.productionReportToolStripMenuItem.Click += new System.EventHandler(this.productionReportToolStripMenuItem_Click);
            // 
            // packingReportToolStripMenuItem
            // 
            this.packingReportToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.packingReportToolStripMenuItem.Name = "packingReportToolStripMenuItem";
            this.packingReportToolStripMenuItem.Size = new System.Drawing.Size(100, 23);
            this.packingReportToolStripMenuItem.Text = "Packing Report";
            this.packingReportToolStripMenuItem.Click += new System.EventHandler(this.packingReportToolStripMenuItem_Click);
            // 
            // cmb_factory
            // 
            this.cmb_factory.FormattingEnabled = true;
            this.cmb_factory.Location = new System.Drawing.Point(69, 65);
            this.cmb_factory.Name = "cmb_factory";
            this.cmb_factory.Size = new System.Drawing.Size(242, 21);
            this.cmb_factory.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Factory : ";
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
            this.cmb_year.Location = new System.Drawing.Point(69, 19);
            this.cmb_year.Name = "cmb_year";
            this.cmb_year.Size = new System.Drawing.Size(73, 21);
            this.cmb_year.TabIndex = 6;
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
            this.cmb_month.Location = new System.Drawing.Point(263, 16);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.Size = new System.Drawing.Size(104, 21);
            this.cmb_month.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Year : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Month : ";
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Location = new System.Drawing.Point(0, 161);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(1047, 324);
            this.ultraGrid1.TabIndex = 9;
            this.ultraGrid1.Text = "ultraGrid1";
            // 
            // projectionOfPODeliveryDateToolStripMenuItem
            // 
            this.projectionOfPODeliveryDateToolStripMenuItem.Name = "projectionOfPODeliveryDateToolStripMenuItem";
            this.projectionOfPODeliveryDateToolStripMenuItem.Size = new System.Drawing.Size(215, 23);
            this.projectionOfPODeliveryDateToolStripMenuItem.Text = "Projection of PO(Delivery  Date)";
            this.projectionOfPODeliveryDateToolStripMenuItem.Click += new System.EventHandler(this.projectionOfPODeliveryDateToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "To  : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "From : ";
            // 
            // dtp_to
            // 
            this.dtp_to.Location = new System.Drawing.Point(332, 104);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(200, 20);
            this.dtp_to.TabIndex = 40;
            // 
            // dtp_from
            // 
            this.dtp_from.Location = new System.Drawing.Point(69, 104);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(200, 20);
            this.dtp_from.TabIndex = 39;
            // 
            // QuickReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 485);
            this.Controls.Add(this.ultraGrid1);
            this.Controls.Add(this.panel2);
            this.Name = "QuickReports";
            this.Text = "QuickReports";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip7.ResumeLayout(false);
            this.menuStrip7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmb_factory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_year;
        private System.Windows.Forms.ComboBox cmb_month;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finalAttendanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem croppedDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
        private System.Windows.Forms.ToolStripMenuItem actualCapacityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productionReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packingReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectionOfPODeliveryDateToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
    }
}