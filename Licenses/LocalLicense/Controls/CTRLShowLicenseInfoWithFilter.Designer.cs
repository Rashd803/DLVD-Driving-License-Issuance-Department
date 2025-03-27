namespace Rakib.Licenses.LocalLicense.Controls
{
    partial class CTRLShowLicenseInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GBFilter = new System.Windows.Forms.GroupBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.TBFilter = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlShowLicenseInfo1 = new Rakib.Licenses.Controls.CTRLShowLicenseInfo();
            this.GBFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // GBFilter
            // 
            this.GBFilter.Controls.Add(this.btnFind);
            this.GBFilter.Controls.Add(this.TBFilter);
            this.GBFilter.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBFilter.Location = new System.Drawing.Point(247, 0);
            this.GBFilter.Name = "GBFilter";
            this.GBFilter.Size = new System.Drawing.Size(584, 75);
            this.GBFilter.TabIndex = 2;
            this.GBFilter.TabStop = false;
            this.GBFilter.Text = "Filter";
            // 
            // btnFind
            // 
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFind.Image = global::Rakib.Properties.Resources.FindF;
            this.btnFind.Location = new System.Drawing.Point(412, 27);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(50, 38);
            this.btnFind.TabIndex = 2;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // TBFilter
            // 
            this.TBFilter.AccessibleDescription = "Enter A Driver ID";
            this.TBFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBFilter.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBFilter.Location = new System.Drawing.Point(163, 29);
            this.TBFilter.Name = "TBFilter";
            this.TBFilter.Size = new System.Drawing.Size(233, 34);
            this.TBFilter.TabIndex = 1;
            this.TBFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBFilter_KeyPress);
            this.TBFilter.Validating += new System.ComponentModel.CancelEventHandler(this.TBFilter_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlShowLicenseInfo1
            // 
            this.ctrlShowLicenseInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlShowLicenseInfo1.Location = new System.Drawing.Point(2, 66);
            this.ctrlShowLicenseInfo1.Name = "ctrlShowLicenseInfo1";
            this.ctrlShowLicenseInfo1.Size = new System.Drawing.Size(1044, 321);
            this.ctrlShowLicenseInfo1.TabIndex = 0;
            // 
            // CTRLShowLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.GBFilter);
            this.Controls.Add(this.ctrlShowLicenseInfo1);
            this.Name = "CTRLShowLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(1046, 386);
            this.GBFilter.ResumeLayout(false);
            this.GBFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Licenses.Controls.CTRLShowLicenseInfo ctrlShowLicenseInfo1;
        private System.Windows.Forms.GroupBox GBFilter;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox TBFilter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
