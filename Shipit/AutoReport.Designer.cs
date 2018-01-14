namespace Shipit
{
    partial class AutoReport
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ATC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SIZE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LINE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INPUTQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OUTPUTQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ATC,
            this.PO,
            this.COLOR,
            this.SIZE,
            this.LINE,
            this.INPUTQTY,
            this.OUTPUTQTY});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1446, 802);
            this.dataGridView1.TabIndex = 0;
            // 
            // ATC
            // 
            this.ATC.HeaderText = "ATC#";
            this.ATC.Name = "ATC";
            // 
            // PO
            // 
            this.PO.HeaderText = "PO#";
            this.PO.Name = "PO";
            // 
            // COLOR
            // 
            this.COLOR.HeaderText = "COLOR";
            this.COLOR.Name = "COLOR";
            // 
            // SIZE
            // 
            this.SIZE.HeaderText = "SIZE";
            this.SIZE.Name = "SIZE";
            // 
            // LINE
            // 
            this.LINE.HeaderText = "LINE";
            this.LINE.Name = "LINE";
            // 
            // INPUTQTY
            // 
            this.INPUTQTY.HeaderText = "INPUT QTY";
            this.INPUTQTY.Name = "INPUTQTY";
            // 
            // OUTPUTQTY
            // 
            this.OUTPUTQTY.HeaderText = "OUTPUT QTY";
            this.OUTPUTQTY.Name = "OUTPUTQTY";
            // 
            // AutoReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 802);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AutoReport";
            this.Text = "AutoReport";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATC;
        private System.Windows.Forms.DataGridViewTextBoxColumn PO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn SIZE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LINE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPUTQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn OUTPUTQTY;
    }
}