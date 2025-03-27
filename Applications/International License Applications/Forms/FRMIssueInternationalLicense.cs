using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLayer;
using BusinessLayer;
using Rakib.GlobalClasses;
using Rakib.Licenses.LocalLicense.Forms;

namespace Rakib.Licenses.International_License.Forms
{
    public partial class FRMIssueInternationalLicense : Form
    {
        private int _InternationalLicenseID = -1;
        public FRMIssueInternationalLicense()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            FRMLicensesHistory Form = new FRMLicensesHistory(ctrlShowLicenseInfoWithControl1.SelectedLicenseInfo.DriverInfo.PersonID);
            Form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int IntLiceseID = clsInternationalLicenseBLayer.GetActiveInternationalLicenseIDByDriverID(ctrlShowLicenseInfoWithControl1.SelectedLicenseInfo.DriverID);
            if (IntLiceseID == -1)
                return;

            FRMShowInternationalLicenseInfo Form = new FRMShowInternationalLicenseInfo(IntLiceseID);
            Form.ShowDialog();
        }

        private void FRMIssueInternationalLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(1));//add one year.
            lblFees.Text = clsApplicationTypesBLayer.FindAppByID((int)clsApplicationBLayer.enApplicationTypes.NewInternational).ApplicationFees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.Username;
        }

     

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
           
            clsInternationalLicenseBLayer InternationalLicense = new clsInternationalLicenseBLayer();
            //those are the information for the base application, because it inhirts from application, they are part of the sub class.

            InternationalLicense.ApplicantPersonID = ctrlShowLicenseInfoWithControl1.SelectedLicenseInfo.DriverInfo.PersonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationStatus = clsApplicationBLayer.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationTypesBLayer.FindAppByID((int)clsApplicationBLayer.enApplicationTypes.NewInternational).ApplicationFees;
            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;


            InternationalLicense.DriverID= ctrlShowLicenseInfoWithControl1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ctrlShowLicenseInfoWithControl1.SelectedLicenseInfo.LicenseID;
            InternationalLicense.IssueDate= DateTime.Now;
            InternationalLicense.ExpirationDate= DateTime.Now.AddYears(1);

            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssueLicense.Enabled = false;
            ctrlShowLicenseInfoWithControl1.FilterEnabled = false;
            btnLicenseInfo.Enabled = true;
        }

        private void ctrlShowLicenseInfoWithControl1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblLocalLicenseID.Text = SelectedLicenseID.ToString();

            btnLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)

            {
                return;
            }




            //check the license class, person could not issue international license without having
            //normal license of class 3.

            if (ctrlShowLicenseInfoWithControl1.SelectedLicenseInfo.LicenseClass != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueLicense.Enabled = false;
                return;
            }

            //check if person already have an active international license
            int ActiveInternaionalLicenseID = clsInternationalLicenseBLayer.GetActiveInternationalLicenseIDByDriverID(ctrlShowLicenseInfoWithControl1.SelectedLicenseInfo.DriverID);

            if (ActiveInternaionalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternaionalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLicenseInfo.Enabled = true;
                _InternationalLicenseID = ActiveInternaionalLicenseID;
                btnIssueLicense.Enabled = false;
                return;
            }
            btnIssueLicense.Enabled = true;
        }
    }
}
