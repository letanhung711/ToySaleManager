﻿namespace ToySalesManager.GUI
{
    partial class frmCrysHD
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
            this.crysHD = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crysHD
            // 
            this.crysHD.ActiveViewIndex = -1;
            this.crysHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crysHD.Cursor = System.Windows.Forms.Cursors.Default;
            this.crysHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crysHD.Location = new System.Drawing.Point(0, 0);
            this.crysHD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.crysHD.Name = "crysHD";
            this.crysHD.Size = new System.Drawing.Size(998, 558);
            this.crysHD.TabIndex = 0;
            this.crysHD.ToolPanelWidth = 233;
            // 
            // frmCrysHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 558);
            this.Controls.Add(this.crysHD);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCrysHD";
            this.Text = "frmCrysHD";
            this.Load += new System.EventHandler(this.frmCrysHD_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crysHD;
    }
}