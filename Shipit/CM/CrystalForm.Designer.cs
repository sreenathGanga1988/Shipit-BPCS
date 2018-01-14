namespace Shipit.CM
{
    partial class CrystalForm
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
            this.menuStrip7 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyEfficencyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_proj = new System.Windows.Forms.ComboBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel2.SuspendLayout();
            this.menuStrip7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.cmb_proj);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.menuStrip7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(815, 79);
            this.panel2.TabIndex = 11;
            // 
            // menuStrip7
            // 
            this.menuStrip7.AllowMerge = false;
            this.menuStrip7.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.exportToExcelToolStripMenuItem,
            this.exportToPDFToolStripMenuItem,
            this.dailyEfficencyReportToolStripMenuItem,
            this.printToolStripMenuItem});
            this.menuStrip7.Location = new System.Drawing.Point(0, 55);
            this.menuStrip7.Name = "menuStrip7";
            this.menuStrip7.Size = new System.Drawing.Size(815, 24);
            this.menuStrip7.TabIndex = 34;
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
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.exportToExcelToolStripMenuItem.Text = "Delete Projection";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
            // 
            // exportToPDFToolStripMenuItem
            // 
            this.exportToPDFToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.exportToPDFToolStripMenuItem.Name = "exportToPDFToolStripMenuItem";
            this.exportToPDFToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.exportToPDFToolStripMenuItem.Text = "Approve Projection";
            this.exportToPDFToolStripMenuItem.Click += new System.EventHandler(this.exportToPDFToolStripMenuItem_Click);
            // 
            // dailyEfficencyReportToolStripMenuItem
            // 
            this.dailyEfficencyReportToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.dailyEfficencyReportToolStripMenuItem.Name = "dailyEfficencyReportToolStripMenuItem";
            this.dailyEfficencyReportToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.dailyEfficencyReportToolStripMenuItem.Text = "Show Report";
            this.dailyEfficencyReportToolStripMenuItem.Click += new System.EventHandler(this.dailyEfficencyReportToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.printToolStripMenuItem.Text = "Print";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Proj Num :";
            // 
            // cmb_proj
            // 
            this.cmb_proj.FormattingEnabled = true;
            this.cmb_proj.Location = new System.Drawing.Point(75, 23);
            this.cmb_proj.Name = "cmb_proj";
            this.cmb_proj.Size = new System.Drawing.Size(306, 21);
            this.cmb_proj.TabIndex = 36;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 79);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(815, 257);
            this.crystalReportViewer1.TabIndex = 12;
            // 
            // CrystalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 336);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel2);
            this.Name = "CrystalForm";
            this.Text = "CrystalForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip7.ResumeLayout(false);
            this.menuStrip7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyEfficencyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmb_proj;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}