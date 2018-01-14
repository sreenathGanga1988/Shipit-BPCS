namespace Shipit.Production
{
    partial class LinePlanEdit
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
            this.cmb_PO = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_week = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmb_month = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_year = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_lblproduced = new System.Windows.Forms.Label();
            this.lbl_target = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbl_weekrequirement = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_weekrequirement)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cmb_PO);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmb_week);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmb_month);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_year);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(975, 75);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Weekly Chart";
            // 
            // cmb_PO
            // 
            this.cmb_PO.FormattingEnabled = true;
            this.cmb_PO.Location = new System.Drawing.Point(620, 29);
            this.cmb_PO.Name = "cmb_PO";
            this.cmb_PO.Size = new System.Drawing.Size(121, 21);
            this.cmb_PO.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(579, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Po#:";
            // 
            // cmb_week
            // 
            this.cmb_week.FormattingEnabled = true;
            this.cmb_week.Items.AddRange(new object[] {
            "Week1",
            "Week2",
            "Week3",
            "Week4",
            "Week5"});
            this.cmb_week.Location = new System.Drawing.Point(434, 28);
            this.cmb_week.Name = "cmb_week";
            this.cmb_week.Size = new System.Drawing.Size(121, 21);
            this.cmb_week.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(386, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Week :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(979, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cmb_month
            // 
            this.cmb_month.FormattingEnabled = true;
            this.cmb_month.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmb_month.Location = new System.Drawing.Point(243, 29);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.Size = new System.Drawing.Size(121, 21);
            this.cmb_month.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Month";
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
            this.cmb_year.Location = new System.Drawing.Point(62, 29);
            this.cmb_year.Name = "cmb_year";
            this.cmb_year.Size = new System.Drawing.Size(121, 21);
            this.cmb_year.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Year";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_lblproduced);
            this.groupBox3.Controls.Add(this.lbl_target);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 518);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(975, 58);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Total";
            // 
            // lbl_lblproduced
            // 
            this.lbl_lblproduced.AutoSize = true;
            this.lbl_lblproduced.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lblproduced.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_lblproduced.Location = new System.Drawing.Point(591, 33);
            this.lbl_lblproduced.Name = "lbl_lblproduced";
            this.lbl_lblproduced.Size = new System.Drawing.Size(16, 16);
            this.lbl_lblproduced.TabIndex = 18;
            this.lbl_lblproduced.Text = "0";
            // 
            // lbl_target
            // 
            this.lbl_target.AutoSize = true;
            this.lbl_target.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_target.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_target.Location = new System.Drawing.Point(193, 32);
            this.lbl_target.Name = "lbl_target";
            this.lbl_target.Size = new System.Drawing.Size(16, 16);
            this.lbl_target.TabIndex = 17;
            this.lbl_target.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbl_weekrequirement);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(975, 443);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Planned";
            // 
            // tbl_weekrequirement
            // 
            this.tbl_weekrequirement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_weekrequirement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_weekrequirement.Location = new System.Drawing.Point(3, 16);
            this.tbl_weekrequirement.Name = "tbl_weekrequirement";
            this.tbl_weekrequirement.Size = new System.Drawing.Size(969, 424);
            this.tbl_weekrequirement.TabIndex = 0;
            // 
            // LinePlanEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 576);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "LinePlanEdit";
            this.Text = "LinePlanEdit";
            this.Load += new System.EventHandler(this.LinePlanEdit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_weekrequirement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_PO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_week;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmb_month;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_year;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_lblproduced;
        private System.Windows.Forms.Label lbl_target;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView tbl_weekrequirement;
    }
}