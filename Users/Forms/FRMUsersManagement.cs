using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace Rakib.Users.Forms
{
    public partial class FRMUsersManagement : Form
    {
        private static DataTable _dtAllUsers = clsUsersBLayer.GetAllUsers();


        private DataTable _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID", "PersonID",
                                                                        "FullName", "UserName", "IsActive");
        public FRMUsersManagement()
        {
            InitializeComponent();
        }

        private void _ReFreshData()
        {
              _dtAllUsers = clsUsersBLayer.GetAllUsers();


          _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID", "PersonID" +
              "",
                                                                        "FullName", "UserName", "IsActive");
            TBFilter_TextChanged(null, null);
            CBIsActive_SelectedIndexChanged(null,null);
            DGVUsersManagement.DataSource = _dtUsers;
        }

        private void FRMUsersManagement_Load(object sender, EventArgs e)
        {
            DGVUsersManagement.DataSource = _dtUsers;
            LBRecordFound.Text = DGVUsersManagement.Rows.Count.ToString();
            CBFilter.SelectedIndex = 0;
            TBFilter.Visible = (CBFilter.Text != "None");


            if ( DGVUsersManagement.Rows.Count > 0)
            {
                DGVUsersManagement.Columns[0].HeaderText = "User ID";

                DGVUsersManagement.Columns[1].HeaderText = "Person ID";

                DGVUsersManagement.Columns[2].HeaderText = "Full Name";

                DGVUsersManagement.Columns[3].HeaderText = "User Name";

                DGVUsersManagement.Columns[4].HeaderText = "Is Active";



            }


        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Delete the User With ID [" + DGVUsersManagement.CurrentRow.Cells[0].Value + "?", "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsUsersBLayer.DeleteUser((int)DGVUsersManagement.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("The User Deleted Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ReFreshData();
                }
                else
                {
                    MessageBox.Show("Couldn't Delete The User!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FRMAddUpdateUser Form = new FRMAddUpdateUser();
            Form.ShowDialog();
            _ReFreshData();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMAddUpdateUser Form = new FRMAddUpdateUser();
            Form.ShowDialog();
            _ReFreshData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMAddUpdateUser Form = new FRMAddUpdateUser((int)DGVUsersManagement.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            _ReFreshData();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FRMShowUserInfo((int)DGVUsersManagement.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
        }

        private void TBFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (CBFilter.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "Person ID":
                    FilterColumn = "_LicenseID";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "User Name":
                    FilterColumn = "UserName";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            if (TBFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                LBRecordFound.Text = DGVUsersManagement.Rows.Count.ToString();
                return;
            }

            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, TBFilter.Text.Trim());
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, TBFilter.Text.Trim());
            LBRecordFound.Text = DGVUsersManagement.Rows.Count.ToString();


        }

        private void CBFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBFilter.Text == "Is Active")
            {
                TBFilter.Visible = false;
                CBIsActive.Visible = true;
                CBIsActive.Focus();
                CBIsActive.SelectedIndex = 0;
            }
            else
            {
                TBFilter.Visible = (CBFilter.Text != "None");
                CBIsActive.Visible = false;
                TBFilter.Text = "";
                TBFilter.Focus();
            }

        }

   

        private void CBIsActive_KeyPress(object sender, KeyPressEventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = CBIsActive.Text.Trim();

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;


            }

            if (FilterValue == "All")
                _dtUsers.DefaultView.RowFilter = "";
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            LBRecordFound.Text = _dtUsers.Rows.Count.ToString();
        }

        private void TBFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CBFilter.Text == "User ID" || CBFilter.Text == "Person ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void CBIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = CBIsActive.Text.Trim();

            switch (FilterValue)
            {
                case "All":
                    _dtUsers.DefaultView.RowFilter = "";
                    break;
                case "Yes":
                    _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = true", FilterColumn);
                    break;
                case "No":
                    _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = false", FilterColumn);
                    break;
            }

            LBRecordFound.Text = _dtUsers.Rows.Count.ToString();



          
        }
    }
}
