namespace Shipit.Merchandising
{
    partial class FinalCosting
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_showourstyle = new System.Windows.Forms.Button();
            this.cmb_atc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1411, 77);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel2.Controls.Add(this.btn_showourstyle);
            this.panel2.Controls.Add(this.cmb_atc);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1405, 58);
            this.panel2.TabIndex = 5;
            // 
            // btn_showourstyle
            // 
            this.btn_showourstyle.Location = new System.Drawing.Point(388, 13);
            this.btn_showourstyle.Name = "btn_showourstyle";
            this.btn_showourstyle.Size = new System.Drawing.Size(163, 23);
            this.btn_showourstyle.TabIndex = 8;
            this.btn_showourstyle.Text = "Show Final Costing";
            this.btn_showourstyle.UseVisualStyleBackColor = true;
            // 
            // cmb_atc
            // 
            this.cmb_atc.FormattingEnabled = true;
            this.cmb_atc.Location = new System.Drawing.Point(86, 12);
            this.cmb_atc.Name = "cmb_atc";
            this.cmb_atc.Size = new System.Drawing.Size(264, 21);
            this.cmb_atc.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Atc  : ";
            // 
            // FinalCosting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 785);
            this.Controls.Add(this.groupBox1);
            this.Name = "FinalCosting";
            this.Text = "FinalCosting";
            this.Load += new System.EventHandler(this.FinalCosting_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_showourstyle;
        private System.Windows.Forms.ComboBox cmb_atc;
        private System.Windows.Forms.Label label3;
    }
}