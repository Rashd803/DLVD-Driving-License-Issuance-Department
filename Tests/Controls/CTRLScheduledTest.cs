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
using Rakib.GlobalClasses;
using Rakib.Properties;
using static BusinessLayer.clsTestTypesBLayer;

namespace Rakib.Tests.Controls
{
    public partial class CTRLScheduledTest : UserControl
    {
        private clsTestTypesBLayer.enTestType _TestTypeID;
        private int _TestID = -1;

        private clsLocalDrivingLicenseBLayer _LocalDrivingLicenseApplication;

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
                            PBMain.Image = Resources.eye;
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

        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }

        public int TestID
        {
            get
            {
                return _TestID;
            }
        }

        private int _TestAppointmentID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestAppointmentsBLayer _TestAppointment;

        public void LoadInfo(int TestAppointmentID)
        {

            _TestAppointmentID = TestAppointmentID;


            _TestAppointment = clsTestAppointmentsBLayer.FindByID(_TestAppointmentID);

            //incase we did not find any appointment .
            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }

            _TestID = _TestAppointment.TestID;

            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseBLayer.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LblLDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            LblClassName.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            LblPerson.Text = _LocalDrivingLicenseApplication.PersonFullName;


            //this will show the trials for this test before 
            Lbltrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();



            LblDate.Text = clsFormat.DateToShort(_TestAppointment.AppointmentDate);
            LblFees.Text = _TestAppointment.PaidFees.ToString();
            LblTestID.Text = (_TestAppointment.TestID == -1) ? "Not Taken Yet" : _TestAppointment.TestID.ToString();



        }
        public CTRLScheduledTest()
        {
            InitializeComponent();
        }
    }
}
