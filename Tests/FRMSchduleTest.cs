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

namespace Rakib.Tests
{
    public partial class FRMSchduleTest : Form
    {
        private int _LocalDrivingLicenseID = -1;
        private clsTestTypesBLayer.enTestType _TestTypeID = clsTestTypesBLayer.enTestType.VisionTest;

        private int _TestAppointmentID = -1;

        public FRMSchduleTest(int LocalDrivingLicenseID,clsTestTypesBLayer.enTestType TestTypeID,int TestAppointmentID = -1)
        {
            InitializeComponent();
            _LocalDrivingLicenseID = LocalDrivingLicenseID;
            _TestTypeID = TestTypeID;
            _TestAppointmentID = TestAppointmentID;
        }

      

 

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlScheduleTest1_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _TestTypeID;
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseID, _TestAppointmentID);
        }
    }
}
