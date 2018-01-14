namespace Shipit.Reports
{
    partial class Lineplanstatus
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PendingLinePlan", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("WeekID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Month");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Year");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("WeekNo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Factory_name");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AtcNO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PO#");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("stylenum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HOPlanQty");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ComplexityLevel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PODeliveryDate");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PCD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AllocatedDate");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AddedBy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FactoryPlanQty");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BalanceToPlan");
            this.panel2 = new System.Windows.Forms.Panel();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.button1 = new System.Windows.Forms.Button();
            this.cmb_year = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.pendingLinePlanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.courierDetailsDataSet = new Shipit.CourierDetailsDataSet();
            this.pendingLinePlanTableAdapter = new Shipit.CourierDetailsDataSetTableAdapters.PendingLinePlanTableAdapter();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingLinePlanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courierDetailsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.ultraButton2);
            this.panel2.Controls.Add(this.ultraButton1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.cmb_year);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1070, 65);
            this.panel2.TabIndex = 9;
            // 
            // ultraButton2
            // 
            this.ultraButton2.Location = new System.Drawing.Point(579, 10);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(152, 23);
            this.ultraButton2.TabIndex = 14;
            this.ultraButton2.Text = "Export to Excel";
            this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(439, 12);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(124, 23);
            this.ultraButton1.TabIndex = 13;
            this.ultraButton1.Text = "Reset";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "S";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Year : ";
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.DataSource = this.pendingLinePlanBindingSource;
            ultraGridColumn17.Header.VisiblePosition = 0;
            ultraGridColumn18.Header.VisiblePosition = 1;
            ultraGridColumn19.Header.VisiblePosition = 2;
            ultraGridColumn20.Header.VisiblePosition = 3;
            ultraGridColumn21.Header.VisiblePosition = 4;
            ultraGridColumn22.Header.VisiblePosition = 5;
            ultraGridColumn23.Header.VisiblePosition = 6;
            ultraGridColumn24.Header.VisiblePosition = 7;
            ultraGridColumn25.Header.VisiblePosition = 8;
            ultraGridColumn26.Header.VisiblePosition = 9;
            ultraGridColumn27.Header.VisiblePosition = 10;
            ultraGridColumn28.Header.VisiblePosition = 11;
            ultraGridColumn29.Header.VisiblePosition = 12;
            ultraGridColumn30.Header.VisiblePosition = 13;
            ultraGridColumn31.Header.VisiblePosition = 14;
            ultraGridColumn32.Header.VisiblePosition = 15;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32});
            this.ultraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraGrid1.Location = new System.Drawing.Point(0, 65);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(1070, 377);
            this.ultraGrid1.TabIndex = 10;
            this.ultraGrid1.Text = "Line Plan";
            // 
            // pendingLinePlanBindingSource
            // 
            this.pendingLinePlanBindingSource.DataMember = "PendingLinePlan";
            this.pendingLinePlanBindingSource.DataSource = this.courierDetailsDataSet;
            // 
            // courierDetailsDataSet
            // 
            this.courierDetailsDataSet.DataSetName = "CourierDetailsDataSet";
            this.courierDetailsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pendingLinePlanTableAdapter
            // 
            this.pendingLinePlanTableAdapter.ClearBeforeFill = true;
            // 
            // Lineplanstatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 442);
            this.Controls.Add(this.ultraGrid1);
            this.Controls.Add(this.panel2);
            this.Name = "Lineplanstatus";
            this.Text = "Lineplanstatus";
            this.Load += new System.EventHandler(this.Lineplanstatus_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingLinePlanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courierDetailsDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Infragistics.Win.Misc.UltraButton ultraButton2;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmb_year;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private CourierDetailsDataSet courierDetailsDataSet;
        private System.Windows.Forms.BindingSource pendingLinePlanBindingSource;
        private CourierDetailsDataSetTableAdapters.PendingLinePlanTableAdapter pendingLinePlanTableAdapter;
        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;

    }
}