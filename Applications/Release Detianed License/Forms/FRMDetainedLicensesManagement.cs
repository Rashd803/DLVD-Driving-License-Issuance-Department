using BLayer;
using Rakib.Applications.Release_Detianed_License.Forms;
using Rakib.Licenses.LocalLicense.Forms;
using Rakib.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rakib.Applications.Detain_License.Forms
{
    public partial class FRMDetainedLicensesManagement : Form
    {
        public FRMDetainedLicensesManagement()
        {
            InitializeComponent();
        }
        
        private DataTable _DTDetainedLicense = clsDetainLicenseBLayer.GetAllDetainedLicenses();

        private void _RefreshData()
        {
            _DTDetainedLicense = clsDetainLicenseBLayer.GetAllDetainedLicenses();
            DGVDDetainedLicenseManagement.DataSource = _DTDetainedLicense;
            LBRecordFound.Text = DGVDDetainedLicenseManagement.Rows.Count.ToString();
        }
        private void FRMDetainedLicensesManagement_Load(object sender, EventArgs e)
        {
            DGVDDetainedLicenseManagement.DataSource = _DTDetainedLicense;
            LBRecordFound.Text = DGVDDetainedLicenseManagement.Rows.Count.ToString();
            CBFilter.SelectedIndex = 0;

            if( DGVDDetainedLicenseManagement.Rows.Count > 0 )
            {
                DGVDDetainedLicenseManagement.Columns[0].HeaderText = "Detain ID";

                DGVDDetainedLicenseManagement.Columns[1].HeaderText = "License ID";

                DGVDDetainedLicenseManagement.Columns[2].HeaderText = "Detain Date";

                DGVDDetainedLicenseManagement.Columns[3].HeaderText = "Is Released";

                DGVDDetainedLicenseManagement.Columns[4].HeaderText = "Fine Fees";

                DGVDDetainedLicenseManagement.Columns[5].HeaderText = "Release Date";

                DGVDDetainedLicenseManagement.Columns[6].HeaderText = "National No";

                DGVDDetainedLicenseManagement.Columns[7].HeaderText = "Full Name";

                DGVDDetainedLicenseManagement.Columns[8].HeaderText = "Release App.ID";

            }
        }

        private void CBFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBFilter.Text == "Is Released")
            {
                TBFilter.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }

            else

            {

                TBFilter.Visible = (CBFilter.Text != "None");
                cbIsReleased.Visible = false;

                if (CBFilter.Text == "None")
                {
                    TBFilter.Enabled = false;
                    //_dtDetainedLicenses.DefaultView.RowFilter = "";
                    //lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

                }
                else
                    TBFilter.Enabled = true;

                TBFilter.Text = "";
                TBFilter.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FRMDetainLicense Form = new FRMDetainLicense();
            Form.ShowDialog();
            _RefreshData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FRMReleaseDetainedLicense Form = new FRMReleaseDetainedLicense();
            Form.ShowDialog();
            _RefreshData();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMReleaseDetainedLicense Form = new FRMReleaseDetainedLicense((int)DGVDDetainedLicenseManagement.CurrentRow.Cells[1].Value);
            Form.ShowDialog();
            _RefreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TBFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (CBFilter.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "Is Released":
                    {
                        FilterColumn = "IsReleased";
                        break;
                    };

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (TBFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _DTDetainedLicense.DefaultView.RowFilter = "";
                LBRecordFound.Text = _DTDetainedLicense.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                //in this case we deal with numbers not string.
                _DTDetainedLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, TBFilter.Text.Trim());
            else
                _DTDetainedLicense.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, TBFilter.Text.Trim());

            LBRecordFound.Text = _DTDetainedLicense.Rows.Count.ToString();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
            string FilterValue = cbIsReleased.Text;

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
                _DTDetainedLicense.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _DTDetainedLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            LBRecordFound.Text = _DTDetainedLicense.Rows.Count.ToString();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMShowPersonInfo Form = new FRMShowPersonInfo((string)DGVDDetainedLicenseManagement.CurrentRow.Cells[6].Value);
            Form.ShowDialog();
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMShowLicenseInfo Form = new FRMShowLicenseInfo((int)DGVDDetainedLicenseManagement.CurrentRow.Cells[1].Value);
            Form.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsLicenseBLayer.Find((int)DGVDDetainedLicenseManagement.CurrentRow.Cells[1].Value).DriverInfo.PersonID;
            FRMLicensesHistory Form = new FRMLicensesHistory(PersonID);
            Form.ShowDialog();
        }

        private void CMOparations_Opening(object sender, CancelEventArgs e)
        {
            
          releaseLicenseToolStripMenuItem.Enabled = !(bool)DGVDDetainedLicenseManagement.CurrentRow.Cells[3].Value;
        }
    }
}
