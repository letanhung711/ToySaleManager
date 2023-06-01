namespace ToySalesManager.GUI
{
    partial class frmCrysTK
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
            this.crysTK = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crysTK
            // 
            this.crysTK.ActiveViewIndex = -1;
            this.crysTK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crysTK.Cursor = System.Windows.Forms.Cursors.Default;
            this.crysTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crysTK.Location = new System.Drawing.Point(0, 0);
            this.crysTK.Name = "crysTK";
            this.crysTK.Size = new System.Drawing.Size(998, 558);
            this.crysTK.TabIndex = 0;
            // 
            // frmCrysTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 558);
            this.Controls.Add(this.crysTK);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCrysTK";
            this.Text = "frmCrysTK";
            this.Load += new System.EventHandler(this.frmCrysTK_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crysTK;
    }
}