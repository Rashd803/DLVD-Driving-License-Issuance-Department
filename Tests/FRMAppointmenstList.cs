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

namespace Rakib.Tests
{
    public partial class FRMAppointmentsList : Form
    {
        private int _LDLID = -1;
        private clsTestTypesBLayer.enTestType _TestType = clsTestTypesBLayer.enTestType.VisionTest;
        private DataTable _DataTable;
        public FRMAppointmentsList(int LDLID, clsTestTypesBLayer.enTestType TestType)
        {
            InitializeComponent();
            this._LDLID = LDLID;
            _TestType = TestType;
        }

        private void _RefreshData()
        {
            _DataTable = clsTestAppointmentsBLayer.GetApplicationTestAppointmentsPerTestType(_LDLID,_TestType);
            DGVLDLAppointmentsManagement.DataSource = _DataTable;
            ctrlShowLDLAppInfo1.LoadLDLAppInfoByLDLID(_LDLID);
            LBRecordFound.Text = DGVLDLAppointmentsManagement.Rows.Count.ToString();
        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {

                case clsTestTypesBLayer.enTestType.VisionTest:
                    {
                        LblMain.Text = "Vision Test Appointments";
                        break;
                    }

                case clsTestTypesBLayer.enTestType.WrittenTest:
                    {
                        LblMain.Text = "Written Test Appointments";
                      
                        break;
                    }
                case clsTestTypesBLayer.enTestType.StreetTest:
                    {
                        LblMain.Text = "Street Test Appointments";
                       
                        break;
                    }
            }
        }


        private void FRMAppointmenstList_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();
             
            _DataTable = clsTestAppointmentsBLayer.GetApplicationTestAppointmentsPerTestType(_LDLID,_TestType);
            DGVLDLAppointmentsManagement.DataSource = _DataTable;
            ctrlShowLDLAppInfo1.LoadLDLAppInfoByLDLID(_LDLID);
            LBRecordFound.Text = DGVLDLAppointmentsManagement.Rows.Count.ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseBLayer LocalDrivingLicense = clsLocalDrivingLicenseBLayer.FindByLocalDrivingAppLicenseID(_LDLID);

            if( LocalDrivingLicense.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTestBLayer LastTest = LocalDrivingLicense.GetLastTestPerTestType(_TestType);

            if (LastTest == null)
            {
                FRMSchduleTest frm1 = new FRMSchduleTest(_LDLID, _TestType);
                frm1.ShowDialog();
                _RefreshData();
                return;
            }

            //if person already passed the test s/he cannot retak it.
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form form = new FRMSchduleTest(_LDLID, _TestType);
            form.ShowDialog();
            _RefreshData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)DGVLDLAppointmentsManagement.CurrentRow.Cells[0].Value;

            FRMSchduleTest Form = new FRMSchduleTest(_LDLID,_TestType,TestAppointmentID);
            Form.ShowDialog();
            _RefreshData();
        }

        private void takeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FRMTakeTest((int)DGVLDLAppointmentsManagement.CurrentRow.Cells[0].Value,_TestType);
            form.ShowDialog();
            _RefreshData();

        }
    }
}
