namespace Shipit
{
    partial class Notification
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_msgr = new System.Windows.Forms.Label();
            this.tbl_pending = new System.Windows.Forms.DataGridView();
            this.Factory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Style = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_sum = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_pending)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lbl_msgr);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pending Bookings";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(572, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Skip>>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_msgr
            // 
            this.lbl_msgr.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_msgr.Location = new System.Drawing.Point(11, 23);
            this.lbl_msgr.Name = "lbl_msgr";
            this.lbl_msgr.Size = new System.Drawing.Size(560, 24);
            this.lbl_msgr.TabIndex = 0;
            this.lbl_msgr.Text = "label1";
            // 
            // tbl_pending
            // 
            this.tbl_pending.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbl_pending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_pending.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Factory,
            this.Year,
            this.Month,
            this.Buyer,
            this.BookQty,
            this.Style});
            this.tbl_pending.Location = new System.Drawing.Point(0, 67);
            this.tbl_pending.Name = "tbl_pending";
            this.tbl_pending.ReadOnly = true;
            this.tbl_pending.RowHeadersVisible = false;
            this.tbl_pending.Size = new System.Drawing.Size(653, 222);
            this.tbl_pending.TabIndex = 1;
            // 
            // Factory
            // 
            this.Factory.HeaderText = "Factory";
            this.Factory.Name = "Factory";
            // 
            // Year
            // 
            this.Year.HeaderText = "Year";
            this.Year.Name = "Year";
            // 
            // Month
            // 
            this.Month.HeaderText = "Month";
            this.Month.Name = "Month";
            // 
            // Buyer
            // 
            this.Buyer.HeaderText = "Buyer";
            this.Buyer.Name = "Buyer";
            // 
            // BookQty
            // 
            this.BookQty.HeaderText = "BookQty";
            this.BookQty.Name = "BookQty";
            // 
            // Style
            // 
            this.Style.HeaderText = "Style";
            this.Style.Name = "Style";
            // 
            // lbl_sum
            // 
            this.lbl_sum.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_sum.Location = new System.Drawing.Point(28, 312);
            this.lbl_sum.Name = "lbl_sum";
            this.lbl_sum.Size = new System.Drawing.Size(560, 24);
            this.lbl_sum.TabIndex = 2;
            this.lbl_sum.Text = "0";
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(653, 345);
            this.Controls.Add(this.lbl_sum);
            this.Controls.Add(this.tbl_pending);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Notification";
            this.Text = "Notification";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_pending)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_msgr;
        private System.Windows.Forms.DataGridView tbl_pending;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn Buyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Style;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_sum;
    }
}