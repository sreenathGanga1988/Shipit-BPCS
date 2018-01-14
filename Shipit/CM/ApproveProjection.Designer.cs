namespace Shipit.CM
{
    partial class ApproveProjection
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
            this.menuStrip7 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.approveProjectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.menuStrip7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip7
            // 
            this.menuStrip7.AllowMerge = false;
            this.menuStrip7.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.approveProjectionToolStripMenuItem});
            this.menuStrip7.Location = new System.Drawing.Point(0, 549);
            this.menuStrip7.Name = "menuStrip7";
            this.menuStrip7.Size = new System.Drawing.Size(1095, 24);
            this.menuStrip7.TabIndex = 35;
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
            // approveProjectionToolStripMenuItem
            // 
            this.approveProjectionToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.approveProjectionToolStripMenuItem.Name = "approveProjectionToolStripMenuItem";
            this.approveProjectionToolStripMenuItem.Size = new System.Drawing.Size(125, 23);
            this.approveProjectionToolStripMenuItem.Text = "Approve Projection";
            this.approveProjectionToolStripMenuItem.Click += new System.EventHandler(this.approveProjectionToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1095, 549);
            this.dataGridView1.TabIndex = 36;
            this.dataGridView1.Text = "ultraGrid1";
            // 
            // ApproveProjection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 573);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip7);
            this.Name = "ApproveProjection";
            this.Text = "ApproveProjection";
            this.menuStrip7.ResumeLayout(false);
            this.menuStrip7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem approveProjectionToolStripMenuItem;
        private Infragistics.Win.UltraWinGrid.UltraGrid dataGridView1;
    }
}