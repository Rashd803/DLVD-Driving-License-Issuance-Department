namespace Rakib.Applications.Detain_License.Forms
{
    partial class FRMDetainLicense
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
            this.components = new System.ComponentModel.Container();
            this.LblLicenseID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblMain = new System.Windows.Forms.Label();
            this.btnLicenseHistory = new System.Windows.Forms.Button();
            this.btnDetainLicense = new System.Windows.Forms.Button();
            this.LblDetainDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblDetainID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gpApplicationInfo = new System.Windows.Forms.GroupBox();
            this.TBFineFees = new System.Windows.Forms.TextBox();
            this.ctrlShowLicenseInfoWithFilter1 = new Rakib.Licenses.LocalLicense.Controls.CTRLShowLicenseInfoWithFilter();
            this.btnShowDetainLicense = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gpApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblLicenseID
            // 
            this.LblLicenseID.AutoSize = true;
            this.LblLicenseID.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLicenseID.ForeColor = System.Drawing.Color.Teal;
            this.LblLicenseID.Location = new System.Drawing.Point(646, 40);
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
            this.label10.Location = new System.Drawing.Point(506, 40);
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
            this.label1.Location = new System.Drawing.Point(506, 72);
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
            this.lblCreatedByUser.Location = new System.Drawing.Point(646, 72);
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
            this.label2.Location = new System.Drawing.Point(16, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 27);
            this.label2.TabIndex = 177;
            this.label2.Text = "Fine Fees :";
            // 
            // LblMain
            // 
            this.LblMain.AutoSize = true;
            this.LblMain.Font = new System.Drawing.Font("Microsoft YaHei UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMain.ForeColor = System.Drawing.Color.Teal;
            this.LblMain.Location = new System.Drawing.Point(350, 18);
            this.LblMain.Name = "LblMain";
            this.LblMain.Size = new System.Drawing.Size(366, 62);
            this.LblMain.TabIndex = 199;
            this.LblMain.Text = "Detain License";
            // 
            // btnLicenseHistory
            // 
            this.btnLicenseHistory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLicenseHistory.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLicenseHistory.Location = new System.Drawing.Point(58, 624);
            this.btnLicenseHistory.Name = "btnLicenseHistory";
            this.btnLicenseHistory.Size = new System.Drawing.Size(276, 45);
            this.btnLicenseHistory.TabIndex = 197;
            this.btnLicenseHistory.Text = "Show License History";
            this.btnLicenseHistory.UseVisualStyleBackColor = true;
            this.btnLicenseHistory.Click += new System.EventHandler(this.btnLicenseHistory_Click);
            // 
            // btnReleaseLicense
            // 
            this.btnDetainLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetainLicense.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDetainLicense.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetainLicense.Image = global::Rakib.Properties.Resources.id__2_;
            this.btnDetainLicense.Location = new System.Drawing.Point(868, 631);
            this.btnDetainLicense.Name = "btnReleaseLicense";
            this.btnDetainLicense.Size = new System.Drawing.Size(112, 89);
            this.btnDetainLicense.TabIndex = 196;
            this.btnDetainLicense.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetainLicense.UseVisualStyleBackColor = true;
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // LblDetainDate
            // 
            this.LblDetainDate.AutoSize = true;
            this.LblDetainDate.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDetainDate.ForeColor = System.Drawing.Color.Teal;
            this.LblDetainDate.Location = new System.Drawing.Point(177, 72);
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
            this.label5.Location = new System.Drawing.Point(16, 72);
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
            this.LblDetainID.Location = new System.Drawing.Point(177, 40);
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
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = global::Rakib.Properties.Resources.close__2_;
            this.button1.Location = new System.Drawing.Point(991, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 48);
            this.button1.TabIndex = 195;
            this.button1.Text = "    ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gpApplicationInfo
            // 
            this.gpApplicationInfo.Controls.Add(this.TBFineFees);
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
            this.gpApplicationInfo.Location = new System.Drawing.Point(58, 463);
            this.gpApplicationInfo.Name = "gpApplicationInfo";
            this.gpApplicationInfo.Size = new System.Drawing.Size(922, 147);
            this.gpApplicationInfo.TabIndex = 194;
            this.gpApplicationInfo.TabStop = false;
            this.gpApplicationInfo.Text = "Application Info";
            // 
            // TBFineFees
            // 
            this.TBFineFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBFineFees.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBFineFees.Location = new System.Drawing.Point(182, 108);
            this.TBFineFees.Name = "TBFineFees";
            this.TBFineFees.Size = new System.Drawing.Size(113, 29);
            this.TBFineFees.TabIndex = 192;
            this.TBFineFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBFineFees_KeyPress);
            this.TBFineFees.Validating += new System.ComponentModel.CancelEventHandler(this.TBFineFees_Validating);
            // 
            // ctrlShowLicenseInfoWithFilter1
            // 
            this.ctrlShowLicenseInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlShowLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrlShowLicenseInfoWithFilter1.Location = new System.Drawing.Point(3, 83);
            this.ctrlShowLicenseInfoWithFilter1.Name = "ctrlShowLicenseInfoWithFilter1";
            this.ctrlShowLicenseInfoWithFilter1.Size = new System.Drawing.Size(1046, 404);
            this.ctrlShowLicenseInfoWithFilter1.TabIndex = 193;
            this.ctrlShowLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlShowLicenseInfoWithFilter1_OnLicenseSelected);
            // 
            // btnShowReleasedLicense
            // 
            this.btnShowDetainLicense.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowDetainLicense.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowDetainLicense.Location = new System.Drawing.Point(340, 624);
            this.btnShowDetainLicense.Name = "btnShowReleasedLicense";
            this.btnShowDetainLicense.Size = new System.Drawing.Size(287, 45);
            this.btnShowDetainLicense.TabIndex = 200;
            this.btnShowDetainLicense.Text = "Show Detained License";
            this.btnShowDetainLicense.UseVisualStyleBackColor = true;
            this.btnShowDetainLicense.Click += new System.EventHandler(this.button2_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FRMDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1054, 732);
            this.ControlBox = false;
            this.Controls.Add(this.btnShowDetainLicense);
            this.Controls.Add(this.LblMain);
            this.Controls.Add(this.btnLicenseHistory);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gpApplicationInfo);
            this.Controls.Add(this.ctrlShowLicenseInfoWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FRMDetainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRMDetainLicense_Load);
            this.gpApplicationInfo.ResumeLayout(false);
            this.gpApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblLicenseID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblMain;
        private System.Windows.Forms.Button btnLicenseHistory;
        private System.Windows.Forms.Button btnDetainLicense;
        private System.Windows.Forms.Label LblDetainDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblDetainID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gpApplicationInfo;
        private Licenses.LocalLicense.Controls.CTRLShowLicenseInfoWithFilter ctrlShowLicenseInfoWithFilter1;
        private System.Windows.Forms.Button btnShowDetainLicense;
        private System.Windows.Forms.TextBox TBFineFees;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}