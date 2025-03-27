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
using Rakib.Licenses.LocalLicense.Forms;
using Rakib.People;

namespace Rakib.Applications.LocalDrivingApps.Controls
{
    public partial class CTRLShowLDLAppInfo : UserControl
    {
        clsLocalDrivingLicenseBLayer _LDLApp;

        private int _LDLAppID = -1;

        private int License = -1;

        public int LDLAppID
        {
            get { return _LDLAppID; }
        }
        public CTRLShowLDLAppInfo()
        {
            InitializeComponent();
        }


        public void LoadLDLAppInfoByLDLID(int LDLID)
        {
            _LDLApp = clsLocalDrivingLicenseBLayer.GetLDLAppInfoByLDLID(LDLID);

            if (_LDLApp == null)
            {
                MessageBox.Show("No Application With ID: " + LDLID, "Errpr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLDLAppInfo();

        }



        public void LoadLDLAppInfoByAppID(int AppID)
        {
            _LDLApp = clsLocalDrivingLicenseBLayer.GetLDLAppInfoByLDLID(AppID);

            if (_LDLApp == null)
            {
                MessageBox.Show("No Application With ID: " + AppID, "Errpr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLDLAppInfo();
        }

        private void _FillLDLAppInfo()
        {
            LblLDLAppID.Text = _LDLApp.LocalDrivingLicenseApplicationID.ToString();
            LblClassName.Text = clsDrivingClassesBLayer.GetClassInfo(_LDLApp.LicenseClassID).ClassName;
            LblPassedTests.Text = _LDLApp.GetPassedTestCount().ToString() + "/3";
            ctrlShowApplicationInfo1.LoadApplicationInfo(_LDLApp.ApplicationID);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            int LicenseID = clsLocalDrivingLicenseBLayer.FindByLocalDrivingAppLicenseID(_LDLApp.LocalDrivingLicenseApplicationID).GetActiveLicenseID();

            if (LicenseID != -1)
            {
                Form form = new FRMShowLicenseInfo(LicenseID);
                form.ShowDialog();


            }
            else
                MessageBox.Show("Couldn't Find The Person!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
