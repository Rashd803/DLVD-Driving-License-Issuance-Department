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

namespace Rakib.Licenses
{

    public partial class FRMRenewLicense : Form
    {
        private int _RenewedLicenseID = -1;


        public FRMRenewLicense()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRMRenewLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = "[???]";
            lblFees.Text = clsApplicationTypesBLayer.FindAppByID((int)clsApplicationBLayer.enApplicationTypes.RenewDrivingLicense).ApplicationFees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.Username;
            btnLicenseInfo.Enabled = false;
            btnRenewLicense.Enabled = false;
            btnLicenseHistory.Enabled = false;


        }

       

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicenseBLayer _RenewedLicense;


        _RenewedLicense = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.RenewLicense(txtNotes.Text, clsGlobal.CurrentUser.UserID);

            if(_RenewedLicense != null)
            {
                _RenewedLicenseID =  _RenewedLicense.LicenseID;
                lblApplicationID.Text = _RenewedLicense.ApplicationID.ToString();
                LblRenewedLicenseID.Text = _RenewedLicense.LicenseID.ToString();
                MessageBox.Show("License Renewed Successfully With ID =" + _RenewedLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnRenewLicense.Enabled = false;
                ctrlShowLicenseInfoWithFilter1.FilterEnabled = false;
                btnLicenseInfo.Enabled = true;
            }

        }

        private void btnLicenseHistory_Click(object sender, EventArgs e)
        {
            FRMLicensesHistory Form = new FRMLicensesHistory(ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonInfo.ID);
            Form.ShowDialog();
        }

        private void btnLicenseInfo_Click(object sender, EventArgs e)
        {
            FRMShowLicenseInfo Form = new FRMShowLicenseInfo(_RenewedLicenseID);
            Form.ShowDialog();
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
                int DefaultValidityLength = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassIfo.DefaultValidityLength;
                lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(DefaultValidityLength));
                LBLicenseFees.Text = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.PaidFees.ToString();
                LBLicenseFees.Text = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassIfo.ClassFees.ToString();
                LbTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(LBLicenseFees.Text)).ToString();
                txtNotes.Text = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.Notes;

            }

            //Check If License Didn't Expirat Yet.
            if (!ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("License Didn't Expirat Yet!!\n It Will On:\n" + ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate.ToShortTimeString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLicenseInfo.Enabled = false;
                txtNotes.Enabled = false;
                btnRenewLicense.Enabled = false;
                return;
            }

            //Check If License Is Achtiveted.
            if (!ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("License Already Renewed Or Replaced!", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLicenseInfo.Enabled = false;
                txtNotes.Enabled = false;
                btnRenewLicense.Enabled = false;
                return;
            }



            btnRenewLicense.Enabled = true;

        }
    }
}
