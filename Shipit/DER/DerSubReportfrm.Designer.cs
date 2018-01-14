namespace Shipit.DER
{
    partial class DerSubReportfrm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.menuStrip7 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyEfficencyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.derCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dERBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dERAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbl_derdata = new System.Windows.Forms.DataGridView();
            this.Factory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Atc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.menuStrip7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_derdata)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtp_to);
            this.panel2.Controls.Add(this.dtp_from);
            this.panel2.Controls.Add(this.menuStrip7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(968, 79);
            this.panel2.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "To  : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "From : ";
            // 
            // dtp_to
            // 
            this.dtp_to.Location = new System.Drawing.Point(325, 18);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(200, 20);
            this.dtp_to.TabIndex = 36;
            // 
            // dtp_from
            // 
            this.dtp_from.Location = new System.Drawing.Point(62, 18);
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
            this.dailyEfficencyReportToolStripMenuItem,
            this.exportToExcelToolStripMenuItem,
            this.derCToolStripMenuItem,
            this.dERBToolStripMenuItem,
            this.dERAToolStripMenuItem});
            this.menuStrip7.Location = new System.Drawing.Point(0, 52);
            this.menuStrip7.Name = "menuStrip7";
            this.menuStrip7.Size = new System.Drawing.Size(968, 27);
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
            // dailyEfficencyReportToolStripMenuItem
            // 
            this.dailyEfficencyReportToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.dailyEfficencyReportToolStripMenuItem.Name = "dailyEfficencyReportToolStripMenuItem";
            this.dailyEfficencyReportToolStripMenuItem.ShowShortcutKeys = false;
            this.dailyEfficencyReportToolStripMenuItem.Size = new System.Drawing.Size(213, 23);
            this.dailyEfficencyReportToolStripMenuItem.Text = "Daily Efficency Report(D-Approved) ";
            this.dailyEfficencyReportToolStripMenuItem.Click += new System.EventHandler(this.dailyEfficencyReportToolStripMenuItem_Click);
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(110, 23);
            this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
            // 
            // derCToolStripMenuItem
            // 
            this.derCToolStripMenuItem.Name = "derCToolStripMenuItem";
            this.derCToolStripMenuItem.Size = new System.Drawing.Size(61, 23);
            this.derCToolStripMenuItem.Text = "DER-C";
            this.derCToolStripMenuItem.Click += new System.EventHandler(this.derCToolStripMenuItem_Click);
            // 
            // dERBToolStripMenuItem
            // 
            this.dERBToolStripMenuItem.Name = "dERBToolStripMenuItem";
            this.dERBToolStripMenuItem.Size = new System.Drawing.Size(60, 23);
            this.dERBToolStripMenuItem.Text = "DER-B";
            this.dERBToolStripMenuItem.Click += new System.EventHandler(this.dERBToolStripMenuItem_Click);
            // 
            // dERAToolStripMenuItem
            // 
            this.dERAToolStripMenuItem.Name = "dERAToolStripMenuItem";
            this.dERAToolStripMenuItem.Size = new System.Drawing.Size(61, 23);
            this.dERAToolStripMenuItem.Text = "DER-A";
            this.dERAToolStripMenuItem.Click += new System.EventHandler(this.dERAToolStripMenuItem_Click);
            // 
            // tbl_derdata
            // 
            this.tbl_derdata.AllowUserToAddRows = false;
            this.tbl_derdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_derdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Factory,
            this.Line,
            this.Atc,
            this.Details});
            this.tbl_derdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_derdata.Location = new System.Drawing.Point(0, 79);
            this.tbl_derdata.Name = "tbl_derdata";
            this.tbl_derdata.Size = new System.Drawing.Size(968, 182);
            this.tbl_derdata.TabIndex = 13;
            // 
            // Factory
            // 
            this.Factory.HeaderText = "Factory";
            this.Factory.Name = "Factory";
            // 
            // Line
            // 
            this.Line.HeaderText = "Line";
            this.Line.Name = "Line";
            // 
            // Atc
            // 
            this.Atc.HeaderText = "Atc";
            this.Atc.Name = "Atc";
            // 
            // Details
            // 
            this.Details.HeaderText = "Details";
            this.Details.Name = "Details";
            // 
            // DerSubReportfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 261);
            this.Controls.Add(this.tbl_derdata);
            this.Controls.Add(this.panel2);
            this.Name = "DerSubReportfrm";
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip7.ResumeLayout(false);
            this.menuStrip7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_derdata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.MenuStrip menuStrip7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem dailyEfficencyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tbl_derdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn Atc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Details;
        private System.Windows.Forms.ToolStripMenuItem derCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dERBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dERAToolStripMenuItem;
    }
}