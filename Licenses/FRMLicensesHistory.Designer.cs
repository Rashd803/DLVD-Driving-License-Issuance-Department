namespace Rakib.Licenses.LocalLicense.Forms
{
    partial class FRMLicensesHistory
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
            this.LblMain = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrlDrivingLicense1 = new Rakib.Licenses.Controls.CTRLDrivingLicense();
            this.ctrlShowPersonInfo1 = new Rakib.People.CTRLShowPersonInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblMain
            // 
            this.LblMain.AutoSize = true;
            this.LblMain.Font = new System.Drawing.Font("Microsoft YaHei UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMain.ForeColor = System.Drawing.Color.Teal;
            this.LblMain.Location = new System.Drawing.Point(381, 104);
            this.LblMain.Name = "LblMain";
            this.LblMain.Size = new System.Drawing.Size(385, 62);
            this.LblMain.TabIndex = 37;
            this.LblMain.Text = "License History";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = global::Rakib.Properties.Resources.close__2_;
            this.button1.Location = new System.Drawing.Point(1107, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 48);
            this.button1.TabIndex = 180;
            this.button1.Text = "    ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rakib.Properties.Resources.id__1_;
            this.pictureBox1.Location = new System.Drawing.Point(481, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(154, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // ctrlDrivingLicense1
            // 
            this.ctrlDrivingLicense1.BackColor = System.Drawing.Color.White;
            this.ctrlDrivingLicense1.Location = new System.Drawing.Point(24, 519);
            this.ctrlDrivingLicense1.Name = "ctrlDrivingLicense1";
            this.ctrlDrivingLicense1.Size = new System.Drawing.Size(1123, 295);
            this.ctrlDrivingLicense1.TabIndex = 181;
            // 
            // ctrlShowPersonInfo1
            // 
            this.ctrlShowPersonInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlShowPersonInfo1.Location = new System.Drawing.Point(2, 158);
            this.ctrlShowPersonInfo1.Name = "ctrlShowPersonInfo1";
            this.ctrlShowPersonInfo1.Size = new System.Drawing.Size(1171, 373);
            this.ctrlShowPersonInfo1.TabIndex = 0;
            // 
            // FRMLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1170, 826);
            this.ControlBox = false;
            this.Controls.Add(this.ctrlDrivingLicense1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LblMain);
            this.Controls.Add(this.ctrlShowPersonInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FRMLicensesHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRMLicensesHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private People.CTRLShowPersonInfo ctrlShowPersonInfo1;
        private System.Windows.Forms.Label LblMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private Licenses.Controls.CTRLDrivingLicense ctrlDrivingLicense1;
    }
}