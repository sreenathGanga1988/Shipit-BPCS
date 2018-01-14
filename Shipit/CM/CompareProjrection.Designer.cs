namespace Shipit.CM
{
    partial class CompareProjrection
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.menuStrip7 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.projectiontoolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmb_factory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.tbl_allplanned = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.tbl_current = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraSplitter1 = new Infragistics.Win.Misc.UltraSplitter();
            this.panel2.SuspendLayout();
            this.menuStrip7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_allplanned)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_current)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.cmb_factory);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtp_to);
            this.panel2.Controls.Add(this.dtp_from);
            this.panel2.Controls.Add(this.menuStrip7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1264, 79);
            this.panel2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(874, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(594, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "To  : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(324, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "From : ";
            // 
            // dtp_to
            // 
            this.dtp_to.Location = new System.Drawing.Point(632, 19);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(200, 20);
            this.dtp_to.TabIndex = 36;
            // 
            // dtp_from
            // 
            this.dtp_from.Location = new System.Drawing.Point(369, 19);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(200, 20);
            this.dtp_from.TabIndex = 35;
            // 
            // menuStrip7
            // 
            this.menuStrip7.AllowMerge = false;
            this.menuStrip7.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.projectiontoolstrip,
            this.exportToExcelToolStripMenuItem,
            this.exportToPDFToolStripMenuItem});
            this.menuStrip7.Location = new System.Drawing.Point(0, 52);
            this.menuStrip7.Name = "menuStrip7";
            this.menuStrip7.Size = new System.Drawing.Size(1264, 27);
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
            // projectiontoolstrip
            // 
            this.projectiontoolstrip.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.projectiontoolstrip.Name = "projectiontoolstrip";
            this.projectiontoolstrip.Size = new System.Drawing.Size(75, 23);
            this.projectiontoolstrip.Text = "Projection";
            this.projectiontoolstrip.Click += new System.EventHandler(this.projectiontoolstrip_Click);
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(100, 23);
            this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
            // 
            // exportToPDFToolStripMenuItem
            // 
            this.exportToPDFToolStripMenuItem.Name = "exportToPDFToolStripMenuItem";
            this.exportToPDFToolStripMenuItem.Size = new System.Drawing.Size(106, 23);
            this.exportToPDFToolStripMenuItem.Text = "Export to PDF";
            // 
            // cmb_factory
            // 
            this.cmb_factory.FormattingEnabled = true;
            this.cmb_factory.Location = new System.Drawing.Point(103, 15);
            this.cmb_factory.Name = "cmb_factory";
            this.cmb_factory.Size = new System.Drawing.Size(121, 21);
            this.cmb_factory.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 14);
            this.label4.TabIndex = 40;
            this.label4.Text = "Factory :";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center;
            this.ultraGroupBox1.Controls.Add(this.tbl_allplanned);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOnBorder;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 79);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(516, 383);
            this.ultraGroupBox1.TabIndex = 11;
            this.ultraGroupBox1.Text = "Planned Projection";
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // tbl_allplanned
            // 
            this.tbl_allplanned.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.tbl_allplanned.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.SingleSummaryBasedOnDataType;
            this.tbl_allplanned.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.tbl_allplanned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_allplanned.Location = new System.Drawing.Point(3, 16);
            this.tbl_allplanned.Name = "tbl_allplanned";
            this.tbl_allplanned.Size = new System.Drawing.Size(510, 364);
            this.tbl_allplanned.TabIndex = 0;
            this.tbl_allplanned.Text = "Projection";
            this.tbl_allplanned.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center;
            this.ultraGroupBox2.Controls.Add(this.tbl_current);
            this.ultraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox2.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopInsideBorder;
            this.ultraGroupBox2.Location = new System.Drawing.Point(516, 79);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(748, 383);
            this.ultraGroupBox2.TabIndex = 12;
            this.ultraGroupBox2.Text = "Current Projection";
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // tbl_current
            // 
            this.tbl_current.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.tbl_current.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.SingleSummaryBasedOnDataType;
            this.tbl_current.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.tbl_current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_current.Location = new System.Drawing.Point(3, 16);
            this.tbl_current.Name = "tbl_current";
            this.tbl_current.Size = new System.Drawing.Size(742, 364);
            this.tbl_current.TabIndex = 1;
            this.tbl_current.Text = "Projection";
            this.tbl_current.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // ultraSplitter1
            // 
            this.ultraSplitter1.Location = new System.Drawing.Point(516, 79);
            this.ultraSplitter1.Name = "ultraSplitter1";
            this.ultraSplitter1.RestoreExtent = 0;
            this.ultraSplitter1.Size = new System.Drawing.Size(6, 383);
            this.ultraSplitter1.TabIndex = 13;
            // 
            // CompareProjrection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 462);
            this.Controls.Add(this.ultraSplitter1);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.panel2);
            this.Name = "CompareProjrection";
            this.Text = "CompareProjrection";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip7.ResumeLayout(false);
            this.menuStrip7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_allplanned)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_current)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.MenuStrip menuStrip7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem projectiontoolstrip;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToPDFToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmb_factory;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.UltraWinGrid.UltraGrid tbl_allplanned;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.UltraWinGrid.UltraGrid tbl_current;
        private Infragistics.Win.Misc.UltraSplitter ultraSplitter1;
    }
}