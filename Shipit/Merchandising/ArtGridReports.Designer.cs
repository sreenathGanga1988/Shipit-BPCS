namespace Shipit.Merchandising
{
    partial class ArtGridReports
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
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.drp_asn = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip7 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.showLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalAttendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectionOfPODeliveryDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupingCompletedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel2.SuspendLayout();
            this.menuStrip7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.drp_asn);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.menuStrip7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1360, 123);
            this.panel2.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(276, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // drp_asn
            // 
            this.drp_asn.FormattingEnabled = true;
            this.drp_asn.Location = new System.Drawing.Point(84, 29);
            this.drp_asn.Name = "drp_asn";
            this.drp_asn.Size = new System.Drawing.Size(186, 21);
            this.drp_asn.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "ASN # : ";
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
            this.exportToExcelToolStripMenuItem,
            this.projectionOfPODeliveryDateToolStripMenuItem,
            this.groupingCompletedToolStripMenuItem});
            this.menuStrip7.Location = new System.Drawing.Point(0, 99);
            this.menuStrip7.Name = "menuStrip7";
            this.menuStrip7.Size = new System.Drawing.Size(1360, 24);
            this.menuStrip7.TabIndex = 35;
            this.menuStrip7.Text = "menuStrip7";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(54, 20);
            this.toolStripMenuItem2.Text = "Cancel";
            // 
            // showLogToolStripMenuItem
            // 
            this.showLogToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.showLogToolStripMenuItem.Name = "showLogToolStripMenuItem";
            this.showLogToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.showLogToolStripMenuItem.Text = "Pending Validation";
            this.showLogToolStripMenuItem.Click += new System.EventHandler(this.showLogToolStripMenuItem_Click);
            // 
            // finalAttendanceToolStripMenuItem
            // 
            this.finalAttendanceToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.finalAttendanceToolStripMenuItem.Name = "finalAttendanceToolStripMenuItem";
            this.finalAttendanceToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.finalAttendanceToolStripMenuItem.Text = "Pending Inspection";
            this.finalAttendanceToolStripMenuItem.Click += new System.EventHandler(this.finalAttendanceToolStripMenuItem_Click);
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
            // 
            // projectionOfPODeliveryDateToolStripMenuItem
            // 
            this.projectionOfPODeliveryDateToolStripMenuItem.Checked = true;
            this.projectionOfPODeliveryDateToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.projectionOfPODeliveryDateToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.projectionOfPODeliveryDateToolStripMenuItem.Name = "projectionOfPODeliveryDateToolStripMenuItem";
            this.projectionOfPODeliveryDateToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.projectionOfPODeliveryDateToolStripMenuItem.Text = "Pending Grouping";
            this.projectionOfPODeliveryDateToolStripMenuItem.Click += new System.EventHandler(this.projectionOfPODeliveryDateToolStripMenuItem_Click);
            // 
            // groupingCompletedToolStripMenuItem
            // 
            this.groupingCompletedToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupingCompletedToolStripMenuItem.Name = "groupingCompletedToolStripMenuItem";
            this.groupingCompletedToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.groupingCompletedToolStripMenuItem.Text = "Grouping Completed";
            this.groupingCompletedToolStripMenuItem.Click += new System.EventHandler(this.groupingCompletedToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.dataGridView1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.BasedOnDataType;
            this.dataGridView1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.Location = new System.Drawing.Point(0, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1360, 607);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.Text = "ultraGrid1";
            // 
            // ArtGridReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 730);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Name = "ArtGridReports";
            this.Text = "ArtGridReports";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip7.ResumeLayout(false);
            this.menuStrip7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finalAttendanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectionOfPODeliveryDateToolStripMenuItem;
        private Infragistics.Win.UltraWinGrid.UltraGrid dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox drp_asn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem groupingCompletedToolStripMenuItem;
    }
}