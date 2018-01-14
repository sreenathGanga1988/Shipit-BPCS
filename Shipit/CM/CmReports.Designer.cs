namespace Shipit.CM
{
    partial class CmReports
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
            this.cmPendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.croppedDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteCMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.plannedVsActualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.menuStrip7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.menuStrip7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1138, 37);
            this.panel2.TabIndex = 10;
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
            this.cmPendingToolStripMenuItem,
            this.croppedDataToolStripMenuItem,
            this.exportToExcelToolStripMenuItem,
            this.plannedVsActualToolStripMenuItem});
            this.menuStrip7.Location = new System.Drawing.Point(0, 13);
            this.menuStrip7.Name = "menuStrip7";
            this.menuStrip7.Size = new System.Drawing.Size(1138, 24);
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
            this.showLogToolStripMenuItem.Size = new System.Drawing.Size(78, 23);
            this.showLogToolStripMenuItem.Text = "CM Report";
            this.showLogToolStripMenuItem.Click += new System.EventHandler(this.showLogToolStripMenuItem_Click);
            // 
            // cmPendingToolStripMenuItem
            // 
            this.cmPendingToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.cmPendingToolStripMenuItem.Name = "cmPendingToolStripMenuItem";
            this.cmPendingToolStripMenuItem.Size = new System.Drawing.Size(84, 23);
            this.cmPendingToolStripMenuItem.Text = "Cm Pending";
            this.cmPendingToolStripMenuItem.Click += new System.EventHandler(this.cmPendingToolStripMenuItem_Click);
            // 
            // croppedDataToolStripMenuItem
            // 
            this.croppedDataToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.croppedDataToolStripMenuItem.Name = "croppedDataToolStripMenuItem";
            this.croppedDataToolStripMenuItem.Size = new System.Drawing.Size(190, 23);
            this.croppedDataToolStripMenuItem.Text = "CM Not Made But Line Planned";
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
            // ultraGrid1
            // 
            this.ultraGrid1.ContextMenuStrip = this.contextMenuStrip1;
            this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Location = new System.Drawing.Point(0, 37);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(1138, 434);
            this.ultraGrid1.TabIndex = 11;
            this.ultraGrid1.Text = "ultraGrid1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteCMToolStripMenuItem,
            this.editCMToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 48);
            // 
            // deleteCMToolStripMenuItem
            // 
            this.deleteCMToolStripMenuItem.Name = "deleteCMToolStripMenuItem";
            this.deleteCMToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.deleteCMToolStripMenuItem.Text = "Delete CM";
            this.deleteCMToolStripMenuItem.Click += new System.EventHandler(this.deleteCMToolStripMenuItem_Click);
            // 
            // editCMToolStripMenuItem
            // 
            this.editCMToolStripMenuItem.Name = "editCMToolStripMenuItem";
            this.editCMToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.editCMToolStripMenuItem.Text = "Edit CM";
            this.editCMToolStripMenuItem.Click += new System.EventHandler(this.editCMToolStripMenuItem_Click);
            // 
            // plannedVsActualToolStripMenuItem
            // 
            this.plannedVsActualToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.plannedVsActualToolStripMenuItem.Name = "plannedVsActualToolStripMenuItem";
            this.plannedVsActualToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.plannedVsActualToolStripMenuItem.Text = "Planned Vs Actual";
            this.plannedVsActualToolStripMenuItem.Click += new System.EventHandler(this.plannedVsActualToolStripMenuItem_Click);
            // 
            // CmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 471);
            this.Controls.Add(this.ultraGrid1);
            this.Controls.Add(this.panel2);
            this.Name = "CmReports";
            this.Text = "CmReports";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip7.ResumeLayout(false);
            this.menuStrip7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmPendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem croppedDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteCMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCMToolStripMenuItem;
        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
        private System.Windows.Forms.ToolStripMenuItem plannedVsActualToolStripMenuItem;
    }
}