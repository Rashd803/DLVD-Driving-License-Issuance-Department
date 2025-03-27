namespace Rakib.People.Controls
{
    partial class CTRLFilterShowInfo
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
            this.TBFilter = new System.Windows.Forms.TextBox();
            this.CBFilter = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.ctrlShowPersonInfo1 = new Rakib.People.CTRLShowPersonInfo();
            this.GBFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // GBFilter
            // 
            this.GBFilter.Controls.Add(this.pictureBox2);
            this.GBFilter.Controls.Add(this.btnAdd);
            this.GBFilter.Controls.Add(this.btnFind);
            this.GBFilter.Controls.Add(this.TBFilter);
            this.GBFilter.Controls.Add(this.CBFilter);
            this.GBFilter.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBFilter.Location = new System.Drawing.Point(103, 13);
            this.GBFilter.Name = "GBFilter";
            this.GBFilter.Size = new System.Drawing.Size(950, 75);
            this.GBFilter.TabIndex = 1;
            this.GBFilter.TabStop = false;
            this.GBFilter.Text = "Filter";
            // 
            // TBFilter
            // 
            this.TBFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBFilter.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBFilter.Location = new System.Drawing.Point(407, 29);
            this.TBFilter.Name = "TBFilter";
            this.TBFilter.Size = new System.Drawing.Size(233, 34);
            this.TBFilter.TabIndex = 1;
            this.TBFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBFilter_KeyPress);
            this.TBFilter.Validating += new System.ComponentModel.CancelEventHandler(this.TBFilter_Validating);
            // 
            // CBFilter
            // 
            this.CBFilter.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBFilter.FormattingEnabled = true;
            this.CBFilter.Items.AddRange(new object[] {
            "Person ID",
            "National No"});
            this.CBFilter.Location = new System.Drawing.Point(215, 29);
            this.CBFilter.Name = "CBFilter";
            this.CBFilter.Size = new System.Drawing.Size(186, 35);
            this.CBFilter.TabIndex = 0;
            this.CBFilter.SelectedIndexChanged += new System.EventHandler(this.CBFilter_SelectedIndexChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Rakib.Properties.Resources.filter__3_;
            this.pictureBox2.Location = new System.Drawing.Point(188, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Image = global::Rakib.Properties.Resources.AddF;
            this.btnAdd.Location = new System.Drawing.Point(803, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 38);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnFind
            // 
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFind.Image = global::Rakib.Properties.Resources.FindF;
            this.btnFind.Location = new System.Drawing.Point(737, 25);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(50, 38);
            this.btnFind.TabIndex = 2;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // ctrlShowPersonInfo1
            // 
            this.ctrlShowPersonInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlShowPersonInfo1.Location = new System.Drawing.Point(0, 94);
            this.ctrlShowPersonInfo1.Name = "ctrlShowPersonInfo1";
            this.ctrlShowPersonInfo1.Size = new System.Drawing.Size(1204, 365);
            this.ctrlShowPersonInfo1.TabIndex = 0;
            // 
            // CTRLFilterShowInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.GBFilter);
            this.Controls.Add(this.ctrlShowPersonInfo1);
            this.Name = "CTRLFilterShowInfo";
            this.Size = new System.Drawing.Size(1178, 498);
            this.Load += new System.EventHandler(this.CTRLFilterShowInfo_Load);
            this.GBFilter.ResumeLayout(false);
            this.GBFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox GBFilter;
        private System.Windows.Forms.ComboBox CBFilter;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox TBFilter;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private CTRLShowPersonInfo ctrlShowPersonInfo1;
    }
}
