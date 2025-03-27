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
using Rakib.Properties;

namespace Rakib.Tests.Controls
{
    public partial class CTRLScheduleTest : UserControl
    {
        public enum enMode { AddNew = 0,Update = 1 };
        private enMode _Mode = enMode.AddNew;
        
        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 };
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private clsTestTypesBLayer.enTestType _TestTypeID = clsTestTypesBLayer.enTestType.VisionTest;
        private clsLocalDrivingLicenseBLayer _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestAppointmentsBLayer _TestAppointment;
        private int _TestAppointmentID = -1;

        public clsTestTypesBLayer.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case clsTestTypesBLayer.enTestType.VisionTest:
                        {
                            LblMain.Text = "Vision Test";
                            PBMain.Image = Resources.eye__1_;
                            break;
                        }
                    case clsTestTypesBLayer.enTestType.WrittenTest:
                        {
                            LblMain.Text = "Written Test";
                            PBMain.Image = Resources.edit;
                            break;
                        }
                    case clsTestTypesBLayer.enTestType.StreetTest:
                        {
                            LblMain.Text = "Street Test";
                            PBMain.Image = Resources.car;
                            break;
                        }

                }
            }

        }


        public CTRLScheduleTest()
        {
            InitializeComponent();
        }

        public void LoadInfo(int LocalDrivingLicenseApplicationID, int AppointmentID = -1)
        {
            //if no appointment id this means AddNew mode otherwise it's update mode.
            if (AppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseBLayer.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            //decide if the createion mode is retake test or not based if the person attended this test before
            if (_LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID))
                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;


            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                LblRetakeAppFees.Text = clsApplicationTypesBLayer.FindAppByID((int)clsApplicationBLayer.enApplicationTypes.RetakeTest).ApplicationFees.ToString();
                GBRetakeTestInfo.Enabled = true;
                LblMain.Text = "Schedule Retake Test";
                LblRetakeTestAppID.Text = "0";
            }
            else
            {
                GBRetakeTestInfo.Enabled = false;
                LblMain.Text = "Schedule Test";
                LblRetakeAppFees.Text = "0";
                LblRetakeTestAppID.Text = "N/A";
            }

            LblLDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            LblClassName.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            LblPerson.Text = _LocalDrivingLicenseApplication.PersonFullName;

            //this will show the trials for this test before  
            Lbltrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();


            if (_Mode == enMode.AddNew)
            {
                LblFees.Text = clsTestTypesBLayer.FindTestByID(_TestTypeID).TestTypeFees.ToString();
                DTDate.MinDate = DateTime.Now;
                LblRetakeTestAppID.Text = "N/A";

                _TestAppointment = new clsTestAppointmentsBLayer();
            }

            else
            {

                if (!_LoadTestAppointmentData())
                    return;
            }


            LblTotalFees.Text = (Convert.ToSingle(LblFees.Text) + Convert.ToSingle(LblRetakeAppFees.Text)).ToString();


            if (!_HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandleAppointmentLockedConstraint())
                return;

            if (!_HandlePrviousTestConstraint())
                return;



        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if(_Mode == enMode.AddNew && clsLocalDrivingLicenseBLayer.IsThereAnActiveScheduledTest(this._LocalDrivingLicenseApplicationID,this._TestTypeID))
            {
                LblUserMessage.Text = "Person Already Have An Active Pppointment For This Test";
                btnSave.Enabled = false;
                DTDate.Enabled = false;
                return false;   
            }

            return true;
        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointmentsBLayer.FindByID(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            LblFees.Text = _TestAppointment.PaidFees.ToString();

            //we compare the current date with the appointment date to set the min date.
            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                DTDate.MinDate = DateTime.Now;
            else
                DTDate.MinDate = _TestAppointment.AppointmentDate;

            DTDate.Value = _TestAppointment.AppointmentDate;

            if (_TestAppointment.RetakeTestApplicationID == -1)
            {
                LblRetakeAppFees.Text = "0";
                LblRetakeTestAppID.Text = "N/A";
            }
            else
            {
                LblRetakeAppFees.Text = _TestAppointment.RetakeTestAppInfo.PaidFees.ToString();
                GBRetakeTestInfo.Enabled = true;
                LblMain.Text = "Schedule Retake Test";
                LblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();

            }
            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            //if appointment is locked that means the person already sat for this test
            //we cannot update locked appointment
            if (_TestAppointment.IsLocked)
            {
                LblUserMessage.Visible = true;
                LblUserMessage.Text = "Person already sat for the test, appointment loacked.";
                DTDate.Enabled = false;
                btnSave.Enabled = false;
                return false;

            }
            else
                LblUserMessage.Visible = false;

            return true;
        }
        private bool _HandlePrviousTestConstraint()
        {
            //we need to make sure that this person passed the prvious required test before apply to the new test.
            //person cannno apply for written test unless s/he passes the vision test.
            //person cannot apply for street test unless s/he passes the written test.

            switch (TestTypeID)
            {
                case clsTestTypesBLayer.enTestType.VisionTest:
                    //in this case no required prvious test to pass.
                    LblUserMessage.Visible = false;

                    return true;

                case clsTestTypesBLayer.enTestType.WrittenTest:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    //we check if pass visiontest 1.
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypesBLayer.enTestType.VisionTest))
                    {
                        LblUserMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                        LblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        DTDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        LblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        DTDate.Enabled = true;
                    }


                    return true;

                case clsTestTypesBLayer.enTestType.StreetTest:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypesBLayer.enTestType.WrittenTest))
                    {
                        LblUserMessage.Text = "Cannot Sechule, Written Test should be passed first";
                        LblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        DTDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        LblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        DTDate.Enabled = true;
                    }


                    return true;

            }
            return true;

        }
        private bool _HandleRetakeApplication()
        {
            //this will decide to create a seperate application for retake test or not.
            // and will create it if needed , then it will linkit to the appoinment.
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                //incase the mode is add new and creation mode is retake test we should create a seperate application for it.
                //then we linke it with the appointment.

                //First Create Applicaiton 
                clsApplicationBLayer Application = new clsApplicationBLayer();

                Application.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = (int)clsApplicationBLayer.enApplicationTypes.RetakeTest;
                Application.ApplicationStatus = clsApplicationBLayer.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsApplicationTypesBLayer.FindAppByID((int)clsApplicationBLayer.enApplicationTypes.RetakeTest).ApplicationFees;
                Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (!Application.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = Application.ApplicationID;

            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication())
                return;

            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = DTDate.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(LblFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;    
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
