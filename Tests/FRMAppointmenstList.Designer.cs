namespace Rakib.Tests
{
    partial class FRMAppointmentsList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblMain = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.DGVLDLAppointmentsManagement = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LBRecordFound = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlShowLDLAppInfo1 = new Rakib.Applications.LocalDrivingApps.Controls.CTRLShowLDLAppInfo();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLDLAppointmentsManagement)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblMain
            // 
            this.LblMain.AutoSize = true;
            this.LblMain.Font = new System.Drawing.Font("Microsoft YaHei UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMain.ForeColor = System.Drawing.Color.Teal;
            this.LblMain.Location = new System.Drawing.Point(92, 63);
            this.LblMain.Name = "LblMain";
            this.LblMain.Size = new System.Drawing.Size(961, 62);
            this.LblMain.TabIndex = 38;
            this.LblMain.Text = "Vision Test Appointments Management";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = global::Rakib.Properties.Resources.close__2_;
            this.button1.Location = new System.Drawing.Point(1237, -106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 48);
            this.button1.TabIndex = 37;
            this.button1.Text = "    ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Image = global::Rakib.Properties.Resources.close__2_;
            this.button2.Location = new System.Drawing.Point(1080, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 58);
            this.button2.TabIndex = 39;
            this.button2.Text = "    ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DGVLDLAppointmentsManagement
            // 
            this.DGVLDLAppointmentsManagement.AllowUserToAddRows = false;
            this.DGVLDLAppointmentsManagement.AllowUserToDeleteRows = false;
            this.DGVLDLAppointmentsManagement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVLDLAppointmentsManagement.BackgroundColor = System.Drawing.Color.White;
            this.DGVLDLAppointmentsManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVLDLAppointmentsManagement.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVLDLAppointmentsManagement.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVLDLAppointmentsManagement.Location = new System.Drawing.Point(11, 621);
            this.DGVLDLAppointmentsManagement.Margin = new System.Windows.Forms.Padding(2);
            this.DGVLDLAppointmentsManagement.Name = "DGVLDLAppointmentsManagement";
            this.DGVLDLAppointmentsManagement.ReadOnly = true;
            this.DGVLDLAppointmentsManagement.RowHeadersWidth = 51;
            this.DGVLDLAppointmentsManagement.RowTemplate.Height = 24;
            this.DGVLDLAppointmentsManagement.Size = new System.Drawing.Size(1135, 167);
            this.DGVLDLAppointmentsManagement.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(453, 557);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 50);
            this.label1.TabIndex = 41;
            this.label1.Text = "Appointments";
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Image = global::Rakib.Properties.Resources.calendar_year__1_;
            this.button3.Location = new System.Drawing.Point(1035, 524);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 92);
            this.button3.TabIndex = 42;
            this.button3.Text = "    ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 790);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 24);
            this.label2.TabIndex = 44;
            this.label2.Text = "Records :";
            // 
            // LBRecordFound
            // 
            this.LBRecordFound.AutoSize = true;
            this.LBRecordFound.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBRecordFound.ForeColor = System.Drawing.Color.Teal;
            this.LBRecordFound.Location = new System.Drawing.Point(113, 790);
            this.LBRecordFound.Name = "LBRecordFound";
            this.LBRecordFound.Size = new System.Drawing.Size(48, 24);
            this.LBRecordFound.TabIndex = 43;
            this.LBRecordFound.Text = "[???]";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 68);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editToolStripMenuItem.Image = global::Rakib.Properties.Resources.edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(186, 32);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeToolStripMenuItem
            // 
            this.takeToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takeToolStripMenuItem.Image = global::Rakib.Properties.Resources.papers;
            this.takeToolStripMenuItem.Name = "takeToolStripMenuItem";
            this.takeToolStripMenuItem.Size = new System.Drawing.Size(186, 32);
            this.takeToolStripMenuItem.Text = "Take Test";
            this.takeToolStripMenuItem.Click += new System.EventHandler(this.takeToolStripMenuItem_Click);
            // 
            // ctrlShowLDLAppInfo1
            // 
            this.ctrlShowLDLAppInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlShowLDLAppInfo1.Location = new System.Drawing.Point(-1, 139);
            this.ctrlShowLDLAppInfo1.Name = "ctrlShowLDLAppInfo1";
            this.ctrlShowLDLAppInfo1.Size = new System.Drawing.Size(1156, 392);
            this.ctrlShowLDLAppInfo1.TabIndex = 0;
            // 
            // FRMAppointmentsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1159, 843);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LBRecordFound);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVLDLAppointmentsManagement);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.LblMain);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlShowLDLAppInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FRMAppointmentsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FRMAppointmenstList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVLDLAppointmentsManagement)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Applications.LocalDrivingApps.Controls.CTRLShowLDLAppInfo ctrlShowLDLAppInfo1;
        private System.Windows.Forms.Label LblMain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView DGVLDLAppointmentsManagement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LBRecordFound;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeToolStripMenuItem;
    }
}