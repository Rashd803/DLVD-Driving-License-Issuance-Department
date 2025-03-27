namespace Rakib.Licenses.International_License.Forms
{
    partial class FRMShowInternationalLicenseInfo
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
            this.ctrlShowIntLicenseInfo1 = new Rakib.Licenses.International_License.Controls.CTRLShowIntLicenseInfo();
            this.LblMain = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlShowIntLicenseInfo1
            // 
            this.ctrlShowIntLicenseInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlShowIntLicenseInfo1.Location = new System.Drawing.Point(2, 93);
            this.ctrlShowIntLicenseInfo1.Name = "ctrlShowIntLicenseInfo1";
            this.ctrlShowIntLicenseInfo1.Size = new System.Drawing.Size(944, 260);
            this.ctrlShowIntLicenseInfo1.TabIndex = 39;
            // 
            // LblMain
            // 
            this.LblMain.AutoSize = true;
            this.LblMain.Font = new System.Drawing.Font("Microsoft YaHei UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMain.ForeColor = System.Drawing.Color.Teal;
            this.LblMain.Location = new System.Drawing.Point(133, 37);
            this.LblMain.Name = "LblMain";
            this.LblMain.Size = new System.Drawing.Size(691, 62);
            this.LblMain.TabIndex = 40;
            this.LblMain.Text = "International License Details";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = global::Rakib.Properties.Resources.close__2_;
            this.button1.Location = new System.Drawing.Point(883, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 48);
            this.button1.TabIndex = 41;
            this.button1.Text = "    ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FRMShowInternationalLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(946, 360);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LblMain);
            this.Controls.Add(this.ctrlShowIntLicenseInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FRMShowInternationalLicenseInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRMShowInternationalLicenseInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.CTRLShowIntLicenseInfo ctrlShowIntLicenseInfo1;
        private System.Windows.Forms.Label LblMain;
        private System.Windows.Forms.Button button1;
    }
}