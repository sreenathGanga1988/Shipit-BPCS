namespace Shipit.Production
{
    partial class WeekPlanEditform
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_factory = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_currentfactory = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_style = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txt_pono = new System.Windows.Forms.TextBox();
            this.txt_newQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_weekid = new System.Windows.Forms.Label();
            this.lbl_text = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbl_psd = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl_deliverydate = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cmb_year = new System.Windows.Forms.ComboBox();
            this.cmb_month = new System.Windows.Forms.ComboBox();
            this.cmb_newweek = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_weekidforYearchange = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(386, 432);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dateTimePicker2);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.cmb_factory);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txt_currentfactory);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txt_style);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.txt_pono);
            this.tabPage1.Controls.Add(this.txt_newQty);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lbl_weekid);
            this.tabPage1.Controls.Add(this.lbl_text);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(378, 406);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Week Plan Edit";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(142, 229);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(124, 20);
            this.dateTimePicker2.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "PSD  : ";
            // 
            // cmb_factory
            // 
            this.cmb_factory.Enabled = false;
            this.cmb_factory.FormattingEnabled = true;
            this.cmb_factory.Items.AddRange(new object[] {
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cmb_factory.Location = new System.Drawing.Point(142, 320);
            this.cmb_factory.Name = "cmb_factory";
            this.cmb_factory.Size = new System.Drawing.Size(121, 21);
            this.cmb_factory.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "New  Factory: ";
            // 
            // txt_currentfactory
            // 
            this.txt_currentfactory.Enabled = false;
            this.txt_currentfactory.Location = new System.Drawing.Point(142, 274);
            this.txt_currentfactory.Name = "txt_currentfactory";
            this.txt_currentfactory.Size = new System.Drawing.Size(100, 20);
            this.txt_currentfactory.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = " Current Factory: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Actual Delivery Date : ";
            // 
            // txt_style
            // 
            this.txt_style.Location = new System.Drawing.Point(142, 93);
            this.txt_style.Name = "txt_style";
            this.txt_style.Size = new System.Drawing.Size(100, 20);
            this.txt_style.TabIndex = 20;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(142, 183);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(124, 20);
            this.dateTimePicker1.TabIndex = 19;
            // 
            // txt_pono
            // 
            this.txt_pono.Location = new System.Drawing.Point(142, 54);
            this.txt_pono.Name = "txt_pono";
            this.txt_pono.Size = new System.Drawing.Size(100, 20);
            this.txt_pono.TabIndex = 18;
            // 
            // txt_newQty
            // 
            this.txt_newQty.Location = new System.Drawing.Point(142, 137);
            this.txt_newQty.Name = "txt_newQty";
            this.txt_newQty.Size = new System.Drawing.Size(100, 20);
            this.txt_newQty.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Qty : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Style #:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "PO # :";
            // 
            // lbl_weekid
            // 
            this.lbl_weekid.AutoSize = true;
            this.lbl_weekid.Location = new System.Drawing.Point(127, 29);
            this.lbl_weekid.Name = "lbl_weekid";
            this.lbl_weekid.Size = new System.Drawing.Size(55, 13);
            this.lbl_weekid.TabIndex = 11;
            this.lbl_weekid.Text = "lbl_orderid";
            // 
            // lbl_text
            // 
            this.lbl_text.AutoSize = true;
            this.lbl_text.Location = new System.Drawing.Point(34, 29);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(59, 13);
            this.lbl_text.TabIndex = 10;
            this.lbl_text.Text = "Week ID : ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbl_psd);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.lbl_deliverydate);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.cmb_year);
            this.tabPage2.Controls.Add(this.cmb_month);
            this.tabPage2.Controls.Add(this.cmb_newweek);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.lbl_weekidforYearchange);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(378, 406);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chsange Duration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbl_psd
            // 
            this.lbl_psd.AutoSize = true;
            this.lbl_psd.Location = new System.Drawing.Point(138, 64);
            this.lbl_psd.Name = "lbl_psd";
            this.lbl_psd.Size = new System.Drawing.Size(40, 13);
            this.lbl_psd.TabIndex = 41;
            this.lbl_psd.Text = "lbl_psd";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(45, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "PSD : ";
            // 
            // lbl_deliverydate
            // 
            this.lbl_deliverydate.AutoSize = true;
            this.lbl_deliverydate.Location = new System.Drawing.Point(178, 98);
            this.lbl_deliverydate.Name = "lbl_deliverydate";
            this.lbl_deliverydate.Size = new System.Drawing.Size(80, 13);
            this.lbl_deliverydate.TabIndex = 39;
            this.lbl_deliverydate.Text = "lbl_deliverydate";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(45, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Actual Delivery Date :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(141, 328);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 37;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.cmb_year.Location = new System.Drawing.Point(141, 141);
            this.cmb_year.Name = "cmb_year";
            this.cmb_year.Size = new System.Drawing.Size(121, 21);
            this.cmb_year.TabIndex = 36;
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
            this.cmb_month.Location = new System.Drawing.Point(141, 191);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.Size = new System.Drawing.Size(121, 21);
            this.cmb_month.TabIndex = 35;
            // 
            // cmb_newweek
            // 
            this.cmb_newweek.FormattingEnabled = true;
            this.cmb_newweek.Items.AddRange(new object[] {
            "Week1",
            "Week2",
            "Week3",
            "Week4",
            "Week5",
            "Week6"});
            this.cmb_newweek.Location = new System.Drawing.Point(141, 259);
            this.cmb_newweek.Name = "cmb_newweek";
            this.cmb_newweek.Size = new System.Drawing.Size(121, 21);
            this.cmb_newweek.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(45, 259);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "New  Week : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(45, 194);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "New  Month: ";
            // 
            // lbl_weekidforYearchange
            // 
            this.lbl_weekidforYearchange.AutoSize = true;
            this.lbl_weekidforYearchange.Location = new System.Drawing.Point(138, 39);
            this.lbl_weekidforYearchange.Name = "lbl_weekidforYearchange";
            this.lbl_weekidforYearchange.Size = new System.Drawing.Size(55, 13);
            this.lbl_weekidforYearchange.TabIndex = 30;
            this.lbl_weekidforYearchange.Text = "lbl_orderid";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Week ID : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "New  Year: ";
            // 
            // WeekPlanEditform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(386, 432);
            this.Controls.Add(this.tabControl1);
            this.Name = "WeekPlanEditform";
            this.Text = "WeekPlanEditform";
            this.Load += new System.EventHandler(this.WeekPlanEditform_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_weekid;
        private System.Windows.Forms.Label lbl_text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_style;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txt_pono;
        private System.Windows.Forms.TextBox txt_newQty;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_currentfactory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_factory;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_weekidforYearchange;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_newweek;
        private System.Windows.Forms.ComboBox cmb_month;
        private System.Windows.Forms.ComboBox cmb_year;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_psd;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbl_deliverydate;
        private System.Windows.Forms.Label label13;
    }
}