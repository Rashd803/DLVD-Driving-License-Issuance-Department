using System;
using System.Windows.Forms;
using BusinessLayer;
using Rakib.Applications.Detain_License.Forms;
using Rakib.Applications.LocalDrivingApps;
using Rakib.Applications.Release_Detianed_License.Forms;
using Rakib.Applications.Replasement_For_Last_Of_Damaged_License.Forms;
using Rakib.Apps.Manage_Apps_Types;
using Rakib.Driver.Forms;
using Rakib.International_License.Forms;
using Rakib.Licenses;
using Rakib.Licenses.International_License.Forms;
using Rakib.People;
using Rakib.Tests_Types;
using Rakib.Users.Forms;

namespace Rakib.Main
{
    public partial class FRMMainScreen : Form
    {
        FRMLoginScreen logInScreen;

        public delegate void DataBackDelegate(object sender, string Value);
        public DataBackDelegate DataBack;

        public FRMMainScreen(FRMLoginScreen form)
        {
            InitializeComponent();
            logInScreen = form;
        }


        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;

            DataBack?.Invoke(this,"");

            logInScreen.Show();
            this.Close();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FRMPeopleManagement();
            form.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FRMUsersManagement();
            form.ShowDialog();
        }

        private void accountInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FRMShowUserInfo(clsGlobal.CurrentUser.UserID);
            Form.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FRMChangeUserPassword(clsGlobal.CurrentUser.UserID);
            Form.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FRMAppstypes();
            form.ShowDialog();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FRMTestsTypesManagement();
            form.ShowDialog();

        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FRMLDLAppsManagement();
            form.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FRMAddUpdateLDLApps();
            form.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FRMInternationalLicenseManagement();
            form.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FRMDriversManagement();
            form.ShowDialog();
        }

        private void internationalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMIssueInternationalLicense form = new FRMIssueInternationalLicense();
            form.ShowDialog();
        }

        private void reTakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMLDLAppsManagement Form = new FRMLDLAppsManagement();
            Form.ShowDialog();

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Form Form = new FRMRenewLicense();
            Form.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            FRMReplacementLicense Form = new FRMReplacementLicense();
            Form.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMDetainLicense Form = new FRMDetainLicense();
            Form.ShowDialog();
        }

        private void manageDetainLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMDetainedLicensesManagement Form = new FRMDetainedLicensesManagement();
            Form.ShowDialog();
        }

        private void releseDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMReleaseDetainedLicense Form = new FRMReleaseDetainedLicense();
            Form.ShowDialog();
        }
    }
}
