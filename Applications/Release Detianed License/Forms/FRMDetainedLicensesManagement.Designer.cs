namespace Rakib.Applications.Detain_License.Forms
{
    partial class FRMDetainedLicensesManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGVDDetainedLicenseManagement = new System.Windows.Forms.DataGridView();
            this.CMOparations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CBFilter = new System.Windows.Forms.ComboBox();
            this.TBFilter = new System.Windows.Forms.TextBox();
            this.LblMain = new System.Windows.Forms.Label();
            this.LBRecordFound = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cbIsReleased = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDDetainedLicenseManagement)).BeginInit();
            this.CMOparations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVDDetainedLicenseManagement
            // 
            this.DGVDDetainedLicenseManagement.AllowUserToAddRows = false;
            this.DGVDDetainedLicenseManagement.AllowUserToDeleteRows = false;
            this.DGVDDetainedLicenseManagement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVDDetainedLicenseManagement.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVDDetainedLicenseManagement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVDDetainedLicenseManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDDetainedLicenseManagement.ContextMenuStrip = this.CMOparations;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVDDetainedLicenseManagement.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVDDetainedLicenseManagement.Location = new System.Drawing.Point(11, 286);
            this.DGVDDetainedLicenseManagement.Margin = new System.Windows.Forms.Padding(2);
            this.DGVDDetainedLicenseManagement.Name = "DGVDDetainedLicenseManagement";
            this.DGVDDetainedLicenseManagement.ReadOnly = true;
            this.DGVDDetainedLicenseManagement.RowHeadersWidth = 51;
            this.DGVDDetainedLicenseManagement.RowTemplate.Height = 24;
            this.DGVDDetainedLicenseManagement.Size = new System.Drawing.Size(1320, 248);
            this.DGVDDetainedLicenseManagement.TabIndex = 50;
            // 
            // CMOparations
            // 
            this.CMOparations.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMOparations.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMOparations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.showLicenseHistoryToolStripMenuItem,
            this.releaseLicenseToolStripMenuItem});
            this.CMOparations.Name = "contextMenuStrip1";
            this.CMOparations.Size = new System.Drawing.Size(265, 144);
            this.CMOparations.Opening += new System.ComponentModel.CancelEventHandler(this.CMOparations_Opening);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::Rakib.Properties.Resources.view_details;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(264, 28);
            this.showDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Image = global::Rakib.Properties.Resources.id;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(264, 28);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Show License Details";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.issueDrivingLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // showLicenseHistoryToolStripMenuItem
            // 
            this.showLicenseHistoryToolStripMenuItem.Image = global::Rakib.Properties.Resources.calendar_year__1_;
            this.showLicenseHistoryToolStripMenuItem.Name = "showLicenseHistoryToolStripMenuItem";
            this.showLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(264, 28);
            this.showLicenseHistoryToolStripMenuItem.Text = "Show License History";
            this.showLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showLicenseHistoryToolStripMenuItem_Click);
            // 
            // releaseLicenseToolStripMenuItem
            // 
            this.releaseLicenseToolStripMenuItem.Image = global::Rakib.Properties.Resources.RL;
            this.releaseLicenseToolStripMenuItem.Name = "releaseLicenseToolStripMenuItem";
            this.releaseLicenseToolStripMenuItem.Size = new System.Drawing.Size(264, 28);
            this.releaseLicenseToolStripMenuItem.Text = "Release License";
            this.releaseLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseLicenseToolStripMenuItem_Click);
            // 
            // CBFilter
            // 
            this.CBFilter.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBFilter.FormattingEnabled = true;
            this.CBFilter.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "Is Released",
            "National No.",
            "Full Name",
            "Release Application ID"});
            this.CBFilter.Location = new System.Drawing.Point(489, 249);
            this.CBFilter.Name = "CBFilter";
            this.CBFilter.Size = new System.Drawing.Size(141, 32);
            this.CBFilter.TabIndex = 56;
            this.CBFilter.SelectedIndexChanged += new System.EventHandler(this.CBFilter_SelectedIndexChanged);
            // 
            // TBFilter
            // 
            this.TBFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBFilter.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBFilter.Location = new System.Drawing.Point(636, 248);
            this.TBFilter.Name = "TBFilter";
            this.TBFilter.Size = new System.Drawing.Size(232, 33);
            this.TBFilter.TabIndex = 55;
            this.TBFilter.TextChanged += new System.EventHandler(this.TBFilter_TextChanged);
            // 
            // LblMain
            // 
            this.LblMain.AutoSize = true;
            this.LblMain.Font = new System.Drawing.Font("Microsoft YaHei UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMain.ForeColor = System.Drawing.Color.Teal;
            this.LblMain.Location = new System.Drawing.Point(289, 109);
            this.LblMain.Name = "LblMain";
            this.LblMain.Size = new System.Drawing.Size(773, 62);
            this.LblMain.TabIndex = 54;
            this.LblMain.Text = "Detained Licenses Management";
            // 
            // LBRecordFound
            // 
            this.LBRecordFound.AutoSize = true;
            this.LBRecordFound.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBRecordFound.ForeColor = System.Drawing.Color.Teal;
            this.LBRecordFound.Location = new System.Drawing.Point(101, 536);
            this.LBRecordFound.Name = "LBRecordFound";
            this.LBRecordFound.Size = new System.Drawing.Size(48, 24);
            this.LBRecordFound.TabIndex = 53;
            this.LBRecordFound.Text = "[???]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 536);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 24);
            this.label1.TabIndex = 57;
            this.label1.Text = "Records :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Rakib.Properties.Resources.filter__3_;
            this.pictureBox2.Location = new System.Drawing.Point(462, 248);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 58;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = global::Rakib.Properties.Resources.close__2_;
            this.button1.Location = new System.Drawing.Point(1278, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 48);
            this.button1.TabIndex = 51;
            this.button1.Text = "    ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Image = global::Rakib.Properties.Resources.id__2_;
            this.button3.Location = new System.Drawing.Point(1213, 178);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 102);
            this.button3.TabIndex = 60;
            this.button3.Text = "    ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Image = global::Rakib.Properties.Resources.RL;
            this.button4.Location = new System.Drawing.Point(1091, 178);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 102);
            this.button4.TabIndex = 59;
            this.button4.Text = "    ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cbIsReleased
            // 
            this.cbIsReleased.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsReleased.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsReleased.FormattingEnabled = true;
            this.cbIsReleased.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsReleased.Location = new System.Drawing.Point(636, 248);
            this.cbIsReleased.Name = "cbIsReleased";
            this.cbIsReleased.Size = new System.Drawing.Size(121, 32);
            this.cbIsReleased.TabIndex = 160;
            this.cbIsReleased.Visible = false;
            this.cbIsReleased.SelectedIndexChanged += new System.EventHandler(this.cbIsReleased_SelectedIndexChanged);
            // 
            // FRMDetainedLicensesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1341, 567);
            this.ControlBox = false;
            this.Controls.Add(this.cbIsReleased);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DGVDDetainedLicenseManagement);
            this.Controls.Add(this.CBFilter);
            this.Controls.Add(this.TBFilter);
            this.Controls.Add(this.LblMain);
            this.Controls.Add(this.LBRecordFound);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FRMDetainedLicensesManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRMDetainedLicensesManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDDetainedLicenseManagement)).EndInit();
            this.CMOparations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DGVDDetainedLicenseManagement;
        private System.Windows.Forms.ContextMenuStrip CMOparations;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ComboBox CBFilter;
        private System.Windows.Forms.TextBox TBFilter;
        private System.Windows.Forms.Label LblMain;
        private System.Windows.Forms.Label LBRecordFound;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem releaseLicenseToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbIsReleased;
    }
}