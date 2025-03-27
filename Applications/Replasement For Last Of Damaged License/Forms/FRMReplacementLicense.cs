using BLayer;
using BusinessLayer;
using Rakib.GlobalClasses;
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
using static BLayer.clsLicenseBLayer;

namespace Rakib.Applications.Replasement_For_Last_Of_Damaged_License.Forms
{
    public partial class FRMReplacementLicense : Form
    {
        private int _ReplacedLicenseID = -1;
        public FRMReplacementLicense()
        {
            InitializeComponent();
        }

        private int _GetApplicationTypeID()
        {
            //this will decide which application type to use accirding 
            // to user selection.

            if (rbDamagedLicense.Checked)

                return (int)clsApplicationBLayer.enApplicationTypes.ReplaceDamagedDrivingLicense;
            else
                return (int)clsApplicationBLayer.enApplicationTypes.ReplaceLostDrivingLicense;
        }

        private enIssueReason _GetIssueReason()
        {
            //this will decide which reason to issue a replacement for

            if (rbDamagedLicense.Checked)

                return enIssueReason.DamagedReplacement;
            else
                return enIssueReason.LostReplacement;
        }

        private void FRMReplacementLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.Username.ToString();
            rbLostLicense.Checked = true;
            btnLicenseInfo.Enabled = false;
            btnLicenseHistory.Enabled = false;

        }

        private void ctrlShowLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();

            btnLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)

            {
                return;
            }


            if (ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo != null)
            {
                lblOldLicenseID.Text = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();
                btnLicenseHistory.Enabled = true;
                gbReplacementFor.Enabled = true;
                LblReplacedLicenseID.Text = "[???]";
                lblApplicationID.Text = "[???]";
            }


            //Check If License Is Achtiveted.
            if (!ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("License Already Renewed Of Replaced!", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLicenseInfo.Enabled = false;
                btnRepalcLicense.Enabled = false;
                return;
            }




            btnRepalcLicense.Enabled = true;

        }

        private void btnLicenseHistory_Click(object sender, EventArgs e)
        {
            FRMLicensesHistory Form = new FRMLicensesHistory(ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            Form.ShowDialog();
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Replace the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicenseBLayer _ReplacedLicense;

           
        _ReplacedLicense = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.Replace(_GetIssueReason(), clsGlobal.CurrentUser.UserID);

        if(_ReplacedLicense != null)
        {
            _ReplacedLicenseID = _ReplacedLicense.LicenseID;
            lblApplicationID.Text = _ReplacedLicense.ApplicationID.ToString();
            LblReplacedLicenseID.Text = _ReplacedLicense.LicenseID.ToString();
            MessageBox.Show("License Replaced Successfully With ID =" + _ReplacedLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gbReplacementFor.Enabled = false;
            btnRepalcLicense.Enabled = false;
            btnLicenseInfo.Enabled = true;
        }
        else
                MessageBox.Show("Couldn't Replace The License!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }




        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            LblMain.Text = "Replace Damaged License";
            lblFees.Text = clsApplicationTypesBLayer.FindAppByID(_GetApplicationTypeID()).ApplicationFees.ToString();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            LblMain.Text = "Replace Lost License";
            lblFees.Text = clsApplicationTypesBLayer.FindAppByID(_GetApplicationTypeID()).ApplicationFees.ToString();
        }

        private void btnLicenseInfo_Click(object sender, EventArgs e)
        {
            FRMShowLicenseInfo Form = new FRMShowLicenseInfo(_ReplacedLicenseID);
            Form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
