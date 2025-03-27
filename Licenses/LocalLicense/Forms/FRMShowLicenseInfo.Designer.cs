namespace Rakib.Licenses.LocalLicense.Forms
{
    partial class FRMShowLicenseInfo
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
            this.ctrlShowLicenseInfo1 = new Rakib.Licenses.Controls.CTRLShowLicenseInfo();
            this.LblMain = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlShowLicenseInfo1
            // 
            this.ctrlShowLicenseInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlShowLicenseInfo1.Location = new System.Drawing.Point(-1, 63);
            this.ctrlShowLicenseInfo1.Name = "ctrlShowLicenseInfo1";
            this.ctrlShowLicenseInfo1.Size = new System.Drawing.Size(1052, 324);
            this.ctrlShowLicenseInfo1.TabIndex = 0;
            // 
            // LblMain
            // 
            this.LblMain.AutoSize = true;
            this.LblMain.Font = new System.Drawing.Font("Microsoft YaHei UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMain.ForeColor = System.Drawing.Color.Teal;
            this.LblMain.Location = new System.Drawing.Point(173, 9);
            this.LblMain.Name = "LblMain";
            this.LblMain.Size = new System.Drawing.Size(696, 62);
            this.LblMain.TabIndex = 37;
            this.LblMain.Text = "Local Driving License Details";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = global::Rakib.Properties.Resources.close__2_;
            this.button1.Location = new System.Drawing.Point(1000, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 48);
            this.button1.TabIndex = 38;
            this.button1.Text = "    ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FRMShowLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1063, 399);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LblMain);
            this.Controls.Add(this.ctrlShowLicenseInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FRMShowLicenseInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRMShowLicenseInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Licenses.Controls.CTRLShowLicenseInfo ctrlShowLicenseInfo1;
        private System.Windows.Forms.Label LblMain;
        private System.Windows.Forms.Button button1;
    }
}