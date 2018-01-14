namespace Shipit.Merchandising
{
    partial class AtcChartForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_showourstyle = new System.Windows.Forms.Button();
            this.cmb_atc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbl_atcchart = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_atcchart)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1041, 77);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btn_showourstyle);
            this.panel2.Controls.Add(this.cmb_atc);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(3, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1038, 53);
            this.panel2.TabIndex = 4;
            // 
            // btn_showourstyle
            // 
            this.btn_showourstyle.Location = new System.Drawing.Point(388, 13);
            this.btn_showourstyle.Name = "btn_showourstyle";
            this.btn_showourstyle.Size = new System.Drawing.Size(163, 23);
            this.btn_showourstyle.TabIndex = 8;
            this.btn_showourstyle.Text = "Show Atc Chart";
            this.btn_showourstyle.UseVisualStyleBackColor = true;
            this.btn_showourstyle.Click += new System.EventHandler(this.btn_showourstyle_Click);
            // 
            // cmb_atc
            // 
            this.cmb_atc.FormattingEnabled = true;
            this.cmb_atc.Location = new System.Drawing.Point(86, 12);
            this.cmb_atc.Name = "cmb_atc";
            this.cmb_atc.Size = new System.Drawing.Size(264, 21);
            this.cmb_atc.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Atc  : ";
            // 
            // tbl_atcchart
            // 
            this.tbl_atcchart.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.tbl_atcchart.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.BasedOnDataType;
            this.tbl_atcchart.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCellsAlwaysBelowDescription;
            this.tbl_atcchart.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            this.tbl_atcchart.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.tbl_atcchart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_atcchart.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbl_atcchart.Location = new System.Drawing.Point(0, 77);
            this.tbl_atcchart.Name = "tbl_atcchart";
            this.tbl_atcchart.Size = new System.Drawing.Size(1041, 404);
            this.tbl_atcchart.TabIndex = 11;
            this.tbl_atcchart.Text = "ultraGrid1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(768, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Export to Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AtcChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 481);
            this.Controls.Add(this.tbl_atcchart);
            this.Controls.Add(this.groupBox1);
            this.Name = "AtcChartForm";
            this.Text = "AtcChartForm";
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_atcchart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_showourstyle;
        private System.Windows.Forms.ComboBox cmb_atc;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinGrid.UltraGrid tbl_atcchart;
        private System.Windows.Forms.Button button1;
        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
    }
}