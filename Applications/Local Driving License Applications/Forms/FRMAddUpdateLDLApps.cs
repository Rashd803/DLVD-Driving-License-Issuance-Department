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

namespace Rakib.Applications.LocalDrivingApps
{
    public partial class FRMAddUpdateLDLApps : Form
    {
        private clsLocalDrivingLicenseBLayer _LDLApp;
        private int _LDLAppID;
        private int _SelectedPersonID = -1;

        private enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode = enMode.AddNew;
        public FRMAddUpdateLDLApps()
        {
            InitializeComponent();
            Mode = enMode.AddNew;

        }

        public FRMAddUpdateLDLApps(int AppID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            _LDLAppID = AppID;

        }

        private void _FillClassesInComboBox()
        {
            DataTable DT = clsDrivingClassesBLayer.GetAllClasses();
            foreach (DataRow Row in DT.Rows)
            {
                CBClasses.Items.Add(Row["ClassName"]);
            }

        }

        private void _ReSetDefultValues()
        {
            _FillClassesInComboBox();

            if (Mode == enMode.AddNew)
            {

                _LDLApp = new clsLocalDrivingLicenseBLayer();

                LblMain.Text = "Add Local Driving License Application";
                ctrlFilterShowInfo2.FiterFocus();
                tpAppInfo.Enabled = false;
                LblDate.Text = DateTime.Now.ToShortDateString();
                CBClasses.SelectedIndex = 2;
                LblFees.Text = clsApplicationTypesBLayer.FindAppByID((int) clsApplicationBLayer.enApplicationTypes.NewDrivingLicense).ApplicationFees.ToString();
                LblCreaterUser.Text = clsGlobal.CurrentUser.Username;
            }
            else
            {
                LblMain.Text = "Update Local Driving License App";
                tpAppInfo.Enabled = true;
                btnSave.Enabled = true ;

            }
        }

        private void _LoadData()
        {
            ctrlFilterShowInfo2.FilterEnabled = false;
            _LDLApp = clsLocalDrivingLicenseBLayer.GetLDLAppInfoByLDLID(_LDLAppID);

            if(_LDLApp  == null)
            {
                MessageBox.Show("No Application With ID : " +  _LDLAppID ,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlFilterShowInfo2.LoadPersonINfo(_LDLApp.ApplicantPersonID);

            clsApplicationTypesBLayer App = clsApplicationTypesBLayer.FindAppByID(1);

           
            LblID.Text  = _LDLApp.LocalDrivingLicenseApplicationID.ToString();
            LblDate.Text = clsFormat.DateToShort(_LDLApp.ApplicationDate);
            CBClasses.SelectedIndex = CBClasses.FindString(clsDrivingClassesBLayer.GetClassInfo(_LDLApp.LicenseClassID).ClassName);
            LblFees.Text = _LDLApp.PaidFees.ToString();
            LblCreaterUser.Text = clsUsersBLayer.GetUserInfoByID(_LDLApp.CreatedByUserID).Username;
            

        }

        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received
            _SelectedPersonID = PersonID;
            ctrlFilterShowInfo2.LoadPersonINfo(PersonID);


        }

        private void FRMAddUpdateLDLApps_Load(object sender, EventArgs e)
        {

            _ReSetDefultValues();
            if (Mode == enMode.Update)
                _LoadData();
        }

       

        private void btnNext_Click(object sender, EventArgs e)
        {



            if (Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpAppInfo.Enabled = true;
                TCAddApp.SelectedTab = TCAddApp.TabPages["tpAppInfo"];
                return;
            }

            //incase of add new mode.
            if (ctrlFilterShowInfo2.PersonID != -1)
            {

                btnSave.Enabled = true;
                tpAppInfo.Enabled = true;
                TCAddApp.SelectedTab = TCAddApp.TabPages["tpAppInfo"];

            }
            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlFilterShowInfo2.FiterFocus();
            }




        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int LicenseClassID = clsDrivingClassesBLayer.GetClassInfo(CBClasses.Text).ClassID;

            int ActiveApplicationID = clsApplicationBLayer.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplicationBLayer.enApplicationTypes.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CBClasses.Focus();
                return;
            }

            if (clsLicenseBLayer.IsLicenseExistByPersonID(ctrlFilterShowInfo2.PersonID, LicenseClassID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LDLApp.ApplicantPersonID = ctrlFilterShowInfo2.PersonID;
            _LDLApp.ApplicationDate = DateTime.Now;
            _LDLApp.ApplicationTypeID = 1;
            _LDLApp.ApplicationStatus = clsApplicationBLayer.enApplicationStatus.New;
            _LDLApp.LastStatusDate = DateTime.Now;
            _LDLApp.PaidFees = Convert.ToSingle(LblFees.Text);
            _LDLApp.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LDLApp.LicenseClassID = LicenseClassID;


          

            if(_LDLApp.Save())
            {
                LblID.Text = _LDLApp.LocalDrivingLicenseApplicationID.ToString();
                //Change Mode To Update
                Mode = enMode.Update;
                LblMain.Text = "Update Local Driving License App";
                MessageBox.Show("Data Saved Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Data Have Not Saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlFilterShowInfo2_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void FRMAddUpdateLDLApps_Activated(object sender, EventArgs e)
        {
            ctrlFilterShowInfo2.FiterFocus();
        }
    }
}
