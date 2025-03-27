namespace Rakib.Applications.Release_Detianed_License.Forms
{
    partial class FRMReleaseDetainedLicense
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
            this.ctrlShowLicenseInfoWithFilter1 = new Rakib.Licenses.LocalLicense.Controls.CTRLShowLicenseInfoWithFilter();
            this.LblMain = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnShowReleasedLicense = new System.Windows.Forms.Button();
            this.btnLicenseHistory = new System.Windows.Forms.Button();
            this.btnReleaseLicense = new System.Windows.Forms.Button();
            this.gpApplicationInfo = new System.Windows.Forms.GroupBox();
            this.LblApplicationID = new System.Windows.Forms.Label();
            this.lll = new System.Windows.Forms.Label();
            this.LbltotalFees = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblApplcationFees = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblFineFees = new System.Windows.Forms.Label();
            this.LblLicenseID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblDetainDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblDetainID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gpApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlShowLicenseInfoWithFilter1
            // 
            this.ctrlShowLicenseInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlShowLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrlShowLicenseInfoWithFilter1.Location = new System.Drawing.Point(3, 95);
            this.ctrlShowLicenseInfoWithFilter1.Name = "ctrlShowLicenseInfoWithFilter1";
            this.ctrlShowLicenseInfoWithFilter1.Size = new System.Drawing.Size(1046, 386);
            this.ctrlShowLicenseInfoWithFilter1.TabIndex = 0;
            this.ctrlShowLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlShowLicenseInfoWithFilter1_OnLicenseSelected);
            // 
            // LblMain
            // 
            this.LblMain.AutoSize = true;
            this.LblMain.Font = new System.Drawing.Font("Microsoft YaHei UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMain.ForeColor = System.Drawing.Color.Teal;
            this.LblMain.Location = new System.Drawing.Point(250, 30);
            this.LblMain.Name = "LblMain";
            this.LblMain.Size = new System.Drawing.Size(616, 62);
            this.LblMain.TabIndex = 201;
            this.LblMain.Text = "Release Detained License";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = global::Rakib.Properties.Resources.close__2_;
            this.button1.Location = new System.Drawing.Point(988, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 48);
            this.button1.TabIndex = 200;
            this.button1.Text = "    ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnShowReleasedLicense
            // 
            this.btnShowReleasedLicense.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowReleasedLicense.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowReleasedLicense.Location = new System.Drawing.Point(340, 661);
            this.btnShowReleasedLicense.Name = "btnShowReleasedLicense";
            this.btnShowReleasedLicense.Size = new System.Drawing.Size(287, 45);
            this.btnShowReleasedLicense.TabIndex = 204;
            this.btnShowReleasedLicense.Text = "Show Released License";
            this.btnShowReleasedLicense.UseVisualStyleBackColor = true;
            this.btnShowReleasedLicense.Click += new System.EventHandler(this.btnShowDetainLicense_Click);
            // 
            // btnLicenseHistory
            // 
            this.btnLicenseHistory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLicenseHistory.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLicenseHistory.Location = new System.Drawing.Point(58, 661);
            this.btnLicenseHistory.Name = "btnLicenseHistory";
            this.btnLicenseHistory.Size = new System.Drawing.Size(276, 45);
            this.btnLicenseHistory.TabIndex = 203;
            this.btnLicenseHistory.Text = "Show License History";
            this.btnLicenseHistory.UseVisualStyleBackColor = true;
            this.btnLicenseHistory.Click += new System.EventHandler(this.btnLicenseHistory_Click);
            // 
            // btnReleaseLicense
            // 
            this.btnReleaseLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReleaseLicense.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReleaseLicense.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReleaseLicense.Image = global::Rakib.Properties.Resources.RL;
            this.btnReleaseLicense.Location = new System.Drawing.Point(926, 661);
            this.btnReleaseLicense.Name = "btnReleaseLicense";
            this.btnReleaseLicense.Size = new System.Drawing.Size(112, 89);
            this.btnReleaseLicense.TabIndex = 202;
            this.btnReleaseLicense.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReleaseLicense.UseVisualStyleBackColor = true;
            this.btnReleaseLicense.Click += new System.EventHandler(this.btnReleaseLicense_Click);
            // 
            // gpApplicationInfo
            // 
            this.gpApplicationInfo.Controls.Add(this.LblApplicationID);
            this.gpApplicationInfo.Controls.Add(this.lll);
            this.gpApplicationInfo.Controls.Add(this.LbltotalFees);
            this.gpApplicationInfo.Controls.Add(this.label7);
            this.gpApplicationInfo.Controls.Add(this.LblApplcationFees);
            this.gpApplicationInfo.Controls.Add(this.label6);
            this.gpApplicationInfo.Controls.Add(this.LblFineFees);
            this.gpApplicationInfo.Controls.Add(this.LblLicenseID);
            this.gpApplicationInfo.Controls.Add(this.label10);
            this.gpApplicationInfo.Controls.Add(this.label1);
            this.gpApplicationInfo.Controls.Add(this.lblCreatedByUser);
            this.gpApplicationInfo.Controls.Add(this.label2);
            this.gpApplicationInfo.Controls.Add(this.LblDetainDate);
            this.gpApplicationInfo.Controls.Add(this.label5);
            this.gpApplicationInfo.Controls.Add(this.LblDetainID);
            this.gpApplicationInfo.Controls.Add(this.label4);
            this.gpApplicationInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gpApplicationInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpApplicationInfo.Location = new System.Drawing.Point(58, 477);
            this.gpApplicationInfo.Name = "gpApplicationInfo";
            this.gpApplicationInfo.Size = new System.Drawing.Size(922, 178);
            this.gpApplicationInfo.TabIndex = 205;
            this.gpApplicationInfo.TabStop = false;
            this.gpApplicationInfo.Text = "Application Info";
            // 
            // LblApplicationID
            // 
            this.LblApplicationID.AutoSize = true;
            this.LblApplicationID.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblApplicationID.ForeColor = System.Drawing.Color.Teal;
            this.LblApplicationID.Location = new System.Drawing.Point(665, 139);
            this.LblApplicationID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblApplicationID.Name = "LblApplicationID";
            this.LblApplicationID.Size = new System.Drawing.Size(55, 27);
            this.LblApplicationID.TabIndex = 198;
            this.LblApplicationID.Text = "[???]";
            // 
            // lll
            // 
            this.lll.AutoSize = true;
            this.lll.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lll.Location = new System.Drawing.Point(489, 138);
            this.lll.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lll.Name = "lll";
            this.lll.Size = new System.Drawing.Size(168, 27);
            this.lll.TabIndex = 197;
            this.lll.Text = "Application ID :";
            // 
            // LbltotalFees
            // 
            this.LbltotalFees.AutoSize = true;
            this.LbltotalFees.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbltotalFees.ForeColor = System.Drawing.Color.Teal;
            this.LbltotalFees.Location = new System.Drawing.Point(212, 138);
            this.LbltotalFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbltotalFees.Name = "LbltotalFees";
            this.LbltotalFees.Size = new System.Drawing.Size(64, 27);
            this.LbltotalFees.TabIndex = 196;
            this.LbltotalFees.Text = "[$$$]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 138);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 27);
            this.label7.TabIndex = 195;
            this.label7.Text = "Total Fees :";
            // 
            // LblApplcationFees
            // 
            this.LblApplcationFees.AutoSize = true;
            this.LblApplcationFees.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblApplcationFees.ForeColor = System.Drawing.Color.Teal;
            this.LblApplcationFees.Location = new System.Drawing.Point(212, 105);
            this.LblApplcationFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblApplcationFees.Name = "LblApplcationFees";
            this.LblApplcationFees.Size = new System.Drawing.Size(64, 27);
            this.LblApplcationFees.TabIndex = 194;
            this.LblApplcationFees.Text = "[$$$]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 105);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 27);
            this.label6.TabIndex = 193;
            this.label6.Text = "Application Fees :";
            // 
            // LblFineFees
            // 
            this.LblFineFees.AutoSize = true;
            this.LblFineFees.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFineFees.ForeColor = System.Drawing.Color.Teal;
            this.LblFineFees.Location = new System.Drawing.Point(212, 72);
            this.LblFineFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblFineFees.Name = "LblFineFees";
            this.LblFineFees.Size = new System.Drawing.Size(64, 27);
            this.LblFineFees.TabIndex = 192;
            this.LblFineFees.Text = "[$$$]";
            // 
            // LblLicenseID
            // 
            this.LblLicenseID.AutoSize = true;
            this.LblLicenseID.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLicenseID.ForeColor = System.Drawing.Color.Teal;
            this.LblLicenseID.Location = new System.Drawing.Point(665, 40);
            this.LblLicenseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblLicenseID.Name = "LblLicenseID";
            this.LblLicenseID.Size = new System.Drawing.Size(55, 27);
            this.LblLicenseID.TabIndex = 191;
            this.LblLicenseID.Text = "[???]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(489, 39);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 27);
            this.label10.TabIndex = 190;
            this.label10.Text = "License ID :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(489, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 27);
            this.label1.TabIndex = 181;
            this.label1.Text = "Created By :";
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.AutoSize = true;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUser.ForeColor = System.Drawing.Color.Teal;
            this.lblCreatedByUser.Location = new System.Drawing.Point(665, 105);
            this.lblCreatedByUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(64, 27);
            this.lblCreatedByUser.TabIndex = 180;
            this.lblCreatedByUser.Text = "[????]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 27);
            this.label2.TabIndex = 177;
            this.label2.Text = "Fine Fees :";
            // 
            // LblDetainDate
            // 
            this.LblDetainDate.AutoSize = true;
            this.LblDetainDate.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDetainDate.ForeColor = System.Drawing.Color.Teal;
            this.LblDetainDate.Location = new System.Drawing.Point(665, 73);
            this.LblDetainDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblDetainDate.Name = "LblDetainDate";
            this.LblDetainDate.Size = new System.Drawing.Size(118, 27);
            this.LblDetainDate.TabIndex = 176;
            this.LblDetainDate.Text = "[??/??/????]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(489, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 27);
            this.label5.TabIndex = 174;
            this.label5.Text = "Detain Date :";
            // 
            // LblDetainID
            // 
            this.LblDetainID.AutoSize = true;
            this.LblDetainID.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDetainID.ForeColor = System.Drawing.Color.Teal;
            this.LblDetainID.Location = new System.Drawing.Point(212, 40);
            this.LblDetainID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblDetainID.Name = "LblDetainID";
            this.LblDetainID.Size = new System.Drawing.Size(55, 27);
            this.LblDetainID.TabIndex = 173;
            this.LblDetainID.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 27);
            this.label4.TabIndex = 172;
            this.label4.Text = "Detain ID :";
            // 
            // FRMReleaseDetainedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1051, 753);
            this.ControlBox = false;
            this.Controls.Add(this.gpApplicationInfo);
            this.Controls.Add(this.btnShowReleasedLicense);
            this.Controls.Add(this.btnLicenseHistory);
            this.Controls.Add(this.btnReleaseLicense);
            this.Controls.Add(this.LblMain);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlShowLicenseInfoWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRMReleaseDetainedLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRMReleaseDetainedLicense_Load);
            this.gpApplicationInfo.ResumeLayout(false);
            this.gpApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Licenses.LocalLicense.Controls.CTRLShowLicenseInfoWithFilter ctrlShowLicenseInfoWithFilter1;
        private System.Windows.Forms.Label LblMain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnShowReleasedLicense;
        private System.Windows.Forms.Button btnLicenseHistory;
        private System.Windows.Forms.Button btnReleaseLicense;
        private System.Windows.Forms.GroupBox gpApplicationInfo;
        private System.Windows.Forms.Label LblLicenseID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblDetainDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblDetainID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblFineFees;
        private System.Windows.Forms.Label LblApplcationFees;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LbltotalFees;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblApplicationID;
        private System.Windows.Forms.Label lll;
    }
}