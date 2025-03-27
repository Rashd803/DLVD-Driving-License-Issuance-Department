using BLayer;
using BusinessLayer;
using Rakib.Licenses.LocalLicense.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rakib.Applications.Release_Detianed_License.Forms
{
    public partial class FRMReleaseDetainedLicense : Form
    {
        private int _ReleasedLicenseID = -1;
        public FRMReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        public FRMReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            ctrlShowLicenseInfoWithFilter1.LoadLicenseInfo(LicenseID);
            ctrlShowLicenseInfoWithFilter1.FilterEnabled = false;
        }



        private void btnShowDetainLicense_Click(object sender, EventArgs e)
        {
            FRMShowLicenseInfo Form = new FRMShowLicenseInfo(_ReleasedLicenseID);
            Form.ShowDialog();
        }

        private void btnLicenseHistory_Click(object sender, EventArgs e)
        {
            FRMLicensesHistory Form = new FRMLicensesHistory(ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            Form.ShowDialog();
        }

        

        private void ctrlShowLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;


            btnLicenseHistory.Enabled = (SelectedLicenseID != -1);
            clsDetainLicenseBLayer DetainedLicense = clsDetainLicenseBLayer.FindByLicenseID(SelectedLicenseID);
            LblFineFees.Text = DetainedLicense.FineFees.ToString();
            
            if (SelectedLicenseID == -1)

            {
                return;
            }


            if (!ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("License Is Not Detained!", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnReleaseLicense.Enabled = false;
                return;
            }
            lblCreatedByUser.Text = clsGlobal.CurrentUser.Username;

            LblDetainID.Text = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            LblLicenseID.Text = SelectedLicenseID.ToString();

            lblCreatedByUser.Text = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.CreatedByUserInfo.Username;
            LblDetainDate.Text = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainDate.ToShortDateString();

            LblFineFees.Text = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees.ToString();
            LblApplcationFees.Text = clsApplicationTypesBLayer.FindAppByID((int)clsApplicationBLayer.enApplicationTypes.ReleaseDetainDrivingLicense).ApplicationFees.ToString();

            LbltotalFees.Text = (Convert.ToSingle(LblApplcationFees.Text) + Convert.ToSingle(LblFineFees.Text)).ToString();


            btnReleaseLicense.Enabled = true;
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Detain the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            int ApplicationID = -1;

            bool IsReleased = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID, ref ApplicationID);


            if (IsReleased)
            {
                LblApplicationID.Text = ApplicationID.ToString();
                _ReleasedLicenseID = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID;
                MessageBox.Show("License Released Successfully", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReleaseLicense.Enabled = false;
                btnShowReleasedLicense.Enabled = true;
            }
            else
                MessageBox.Show("Couldn't Release The License!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRMReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            btnShowReleasedLicense.Enabled = false;

        }
    }
}
