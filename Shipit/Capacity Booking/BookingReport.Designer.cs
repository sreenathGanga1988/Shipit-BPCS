﻿namespace Shipit.Capacity_Booking
{
    partial class BookingReport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbl_shownonApproved = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbl_sshowApproved = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_atc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_lblApproved = new System.Windows.Forms.Label();
            this.lbl_Pending = new System.Windows.Forms.Label();
            this.lbl_motham = new System.Windows.Forms.Label();
            this.lbl_dec = new System.Windows.Forms.Label();
            this.lbl_nov = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl_planned = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_shownonApproved)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_sshowApproved)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1096, 397);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1088, 371);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Waiting Approval";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbl_shownonApproved);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 365);
            this.panel1.TabIndex = 1;
            // 
            // tbl_shownonApproved
            // 
            this.tbl_shownonApproved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_shownonApproved.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_shownonApproved.Location = new System.Drawing.Point(0, 0);
            this.tbl_shownonApproved.Name = "tbl_shownonApproved";
            this.tbl_shownonApproved.RowHeadersVisible = false;
            this.tbl_shownonApproved.Size = new System.Drawing.Size(1082, 365);
            this.tbl_shownonApproved.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbl_sshowApproved);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1088, 371);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Approved";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbl_sshowApproved
            // 
            this.tbl_sshowApproved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_sshowApproved.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_sshowApproved.Location = new System.Drawing.Point(3, 3);
            this.tbl_sshowApproved.Name = "tbl_sshowApproved";
            this.tbl_sshowApproved.RowHeadersVisible = false;
            this.tbl_sshowApproved.Size = new System.Drawing.Size(1082, 365);
            this.tbl_sshowApproved.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txt_atc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1102, 74);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(462, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_atc
            // 
            this.txt_atc.Location = new System.Drawing.Point(121, 31);
            this.txt_atc.Name = "txt_atc";
            this.txt_atc.Size = new System.Drawing.Size(334, 20);
            this.txt_atc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Atc#/Style#  : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1102, 416);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Result";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_planned);
            this.groupBox3.Controls.Add(this.lbl_lblApproved);
            this.groupBox3.Controls.Add(this.lbl_Pending);
            this.groupBox3.Controls.Add(this.lbl_motham);
            this.groupBox3.Controls.Add(this.lbl_dec);
            this.groupBox3.Controls.Add(this.lbl_nov);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 437);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1102, 53);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Total";
            // 
            // lbl_lblApproved
            // 
            this.lbl_lblApproved.AutoSize = true;
            this.lbl_lblApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lblApproved.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_lblApproved.Location = new System.Drawing.Point(521, 34);
            this.lbl_lblApproved.Name = "lbl_lblApproved";
            this.lbl_lblApproved.Size = new System.Drawing.Size(16, 16);
            this.lbl_lblApproved.TabIndex = 18;
            this.lbl_lblApproved.Text = "0";
            // 
            // lbl_Pending
            // 
            this.lbl_Pending.AutoSize = true;
            this.lbl_Pending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Pending.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_Pending.Location = new System.Drawing.Point(193, 32);
            this.lbl_Pending.Name = "lbl_Pending";
            this.lbl_Pending.Size = new System.Drawing.Size(16, 16);
            this.lbl_Pending.TabIndex = 17;
            this.lbl_Pending.Text = "0";
            // 
            // lbl_motham
            // 
            this.lbl_motham.AutoSize = true;
            this.lbl_motham.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_motham.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_motham.Location = new System.Drawing.Point(1406, 27);
            this.lbl_motham.Name = "lbl_motham";
            this.lbl_motham.Size = new System.Drawing.Size(16, 16);
            this.lbl_motham.TabIndex = 16;
            this.lbl_motham.Text = "0";
            // 
            // lbl_dec
            // 
            this.lbl_dec.AutoSize = true;
            this.lbl_dec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dec.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_dec.Location = new System.Drawing.Point(1291, 27);
            this.lbl_dec.Name = "lbl_dec";
            this.lbl_dec.Size = new System.Drawing.Size(16, 16);
            this.lbl_dec.TabIndex = 15;
            this.lbl_dec.Text = "0";
            // 
            // lbl_nov
            // 
            this.lbl_nov.AutoSize = true;
            this.lbl_nov.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nov.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_nov.Location = new System.Drawing.Point(1176, 27);
            this.lbl_nov.Name = "lbl_nov";
            this.lbl_nov.Size = new System.Drawing.Size(16, 16);
            this.lbl_nov.TabIndex = 14;
            this.lbl_nov.Text = "0";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1088, 371);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "WeekPlan";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1082, 365);
            this.dataGridView1.TabIndex = 0;
            // 
            // lbl_planned
            // 
            this.lbl_planned.AutoSize = true;
            this.lbl_planned.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_planned.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_planned.Location = new System.Drawing.Point(793, 30);
            this.lbl_planned.Name = "lbl_planned";
            this.lbl_planned.Size = new System.Drawing.Size(16, 16);
            this.lbl_planned.TabIndex = 19;
            this.lbl_planned.Text = "0";
            // 
            // BookingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 490);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BookingReport";
            this.Text = "BookingReport";
            this.Load += new System.EventHandler(this.BookingReport_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_shownonApproved)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_sshowApproved)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView tbl_shownonApproved;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_atc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_motham;
        private System.Windows.Forms.Label lbl_dec;
        private System.Windows.Forms.Label lbl_nov;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView tbl_sshowApproved;
        private System.Windows.Forms.Label lbl_lblApproved;
        private System.Windows.Forms.Label lbl_Pending;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_planned;
    }
}