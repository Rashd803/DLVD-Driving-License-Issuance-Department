namespace Rakib.Licenses.LocalLicense.Forms
{
    partial class FRMShowLicenseInfoWithFilter
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
            this.ctrlShowLicenseInfoWithControl1 = new Rakib.Licenses.LocalLicense.Controls.CTRLShowLicenseInfoWithControl();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlShowLicenseInfoWithControl1
            // 
            this.ctrlShowLicenseInfoWithControl1.BackColor = System.Drawing.Color.White;
            this.ctrlShowLicenseInfoWithControl1.Location = new System.Drawing.Point(0, 0);
            this.ctrlShowLicenseInfoWithControl1.Name = "ctrlShowLicenseInfoWithControl1";
            this.ctrlShowLicenseInfoWithControl1.Size = new System.Drawing.Size(1066, 404);
            this.ctrlShowLicenseInfoWithControl1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = global::Rakib.Properties.Resources.close__2_;
            this.button1.Location = new System.Drawing.Point(1010, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 48);
            this.button1.TabIndex = 33;
            this.button1.Text = "    ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FRMShowLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1073, 392);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlShowLicenseInfoWithControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FRMShowLicenseInfoWithFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CTRLShowLicenseInfoWithControl ctrlShowLicenseInfoWithControl1;
        private System.Windows.Forms.Button button1;
    }
}