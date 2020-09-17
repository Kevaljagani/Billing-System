namespace Billing_System
{
    partial class frmDashboard
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
            this.pnlbtm = new System.Windows.Forms.Panel();
            this.lblbuy = new System.Windows.Forms.Label();
            this.lblSell = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlbtm
            // 
            this.pnlbtm.BackColor = System.Drawing.Color.Teal;
            this.pnlbtm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlbtm.Location = new System.Drawing.Point(0, 701);
            this.pnlbtm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlbtm.Name = "pnlbtm";
            this.pnlbtm.Size = new System.Drawing.Size(1379, 47);
            this.pnlbtm.TabIndex = 0;
            // 
            // lblbuy
            // 
            this.lblbuy.AutoSize = true;
            this.lblbuy.BackColor = System.Drawing.Color.Teal;
            this.lblbuy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblbuy.Font = new System.Drawing.Font("Segoe UI Semibold", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbuy.ForeColor = System.Drawing.Color.White;
            this.lblbuy.Location = new System.Drawing.Point(27, 29);
            this.lblbuy.Name = "lblbuy";
            this.lblbuy.Size = new System.Drawing.Size(120, 67);
            this.lblbuy.TabIndex = 1;
            this.lblbuy.Text = "Add";
            this.lblbuy.Click += new System.EventHandler(this.lblbuy_Click);
            // 
            // lblSell
            // 
            this.lblSell.AutoSize = true;
            this.lblSell.BackColor = System.Drawing.Color.Teal;
            this.lblSell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSell.Font = new System.Drawing.Font("Segoe UI Semibold", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSell.ForeColor = System.Drawing.Color.White;
            this.lblSell.Location = new System.Drawing.Point(182, 29);
            this.lblSell.Name = "lblSell";
            this.lblSell.Size = new System.Drawing.Size(108, 67);
            this.lblSell.TabIndex = 2;
            this.lblSell.Text = "Sell";
            this.lblSell.Click += new System.EventHandler(this.lblSell_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(944, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 51);
            this.label1.TabIndex = 3;
            this.label1.Text = "JB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(1002, 436);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 51);
            this.label2.TabIndex = 4;
            this.label2.Text = "Medicals";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Location = new System.Drawing.Point(986, 487);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Billing System";
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1379, 748);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSell);
            this.Controls.Add(this.lblbuy);
            this.Controls.Add(this.pnlbtm);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlbtm;
        private System.Windows.Forms.Label lblbuy;
        private System.Windows.Forms.Label lblSell;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

