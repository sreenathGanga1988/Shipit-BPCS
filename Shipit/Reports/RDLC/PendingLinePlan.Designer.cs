namespace Shipit.Reports.RDLC
{
    partial class PendingLinePlan
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PendingPOAllocation_VWBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.courierDetailsDataSet = new Shipit.CourierDetailsDataSet();
            this.pendingLinePlanVWBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.cmb_year = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ultraSplitter1 = new Infragistics.Win.Misc.UltraSplitter();
            this.pendingLinePlan_VWTableAdapter = new Shipit.CourierDetailsDataSetTableAdapters.PendingLinePlan_VWTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PendingPOAllocation_VWBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courierDetailsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingLinePlanVWBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PendingPOAllocation_VWBindingSource
            // 
            this.PendingPOAllocation_VWBindingSource.DataMember = "PendingPOAllocation_VW";
            this.PendingPOAllocation_VWBindingSource.DataSource = this.courierDetailsDataSet;
            // 
            // courierDetailsDataSet
            // 
            this.courierDetailsDataSet.DataSetName = "CourierDetailsDataSet";
            this.courierDetailsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pendingLinePlanVWBindingSource
            // 
            this.pendingLinePlanVWBindingSource.DataMember = "PendingLinePlan_VW";
            this.pendingLinePlanVWBindingSource.DataSource = this.courierDetailsDataSet;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.cmb_year);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1070, 67);
            this.panel2.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(179, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "S";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            this.cmb_year.Location = new System.Drawing.Point(91, 18);
            this.cmb_year.Name = "cmb_year";
            this.cmb_year.Size = new System.Drawing.Size(73, 21);
            this.cmb_year.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Year : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.reportViewer2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 391);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pending Po Allocation";
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.PendingPOAllocation_VWBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Shipit.Reports.RDLC.PendingPoAllocation.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(3, 16);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(353, 372);
            this.reportViewer2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.reportViewer1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(359, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(711, 391);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pending Line Plan";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.pendingLinePlanVWBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Shipit.Reports.RDLC.PendingLinePlan.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 16);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(705, 372);
            this.reportViewer1.TabIndex = 0;
            // 
            // ultraSplitter1
            // 
            this.ultraSplitter1.Location = new System.Drawing.Point(359, 67);
            this.ultraSplitter1.Name = "ultraSplitter1";
            this.ultraSplitter1.RestoreExtent = 0;
            this.ultraSplitter1.Size = new System.Drawing.Size(6, 391);
            this.ultraSplitter1.TabIndex = 10;
            // 
            // pendingLinePlan_VWTableAdapter
            // 
            this.pendingLinePlan_VWTableAdapter.ClearBeforeFill = true;
            // 
            // PendingLinePlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 458);
            this.Controls.Add(this.ultraSplitter1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Name = "PendingLinePlan";
            this.Text = "PendingLinePlan";
            this.Load += new System.EventHandler(this.PendingLinePlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PendingPOAllocation_VWBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courierDetailsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingLinePlanVWBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cmb_year;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Infragistics.Win.Misc.UltraSplitter ultraSplitter1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private CourierDetailsDataSet courierDetailsDataSet;
        private System.Windows.Forms.BindingSource pendingLinePlanVWBindingSource;
        private CourierDetailsDataSetTableAdapters.PendingLinePlan_VWTableAdapter pendingLinePlan_VWTableAdapter;
        private System.Windows.Forms.BindingSource PendingPOAllocation_VWBindingSource;
    }
}