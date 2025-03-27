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
    public partial class FRMTakeTest : Form
    {
        private int _AppointmentID = -1;
        private clsTestTypesBLayer.enTestType _TestType;

        private int _TestID = -1;
        private clsTestBLayer _Test;
        public FRMTakeTest(int AppointmentID,clsTestTypesBLayer.enTestType TestType)
        {
            InitializeComponent();
          this._AppointmentID = AppointmentID;
           this._TestType = TestType;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRMScheduledTest_Load(object sender, EventArgs e)
        {
            ctrlScheduledTest1.TestTypeID = _TestType;
            ctrlScheduledTest1.LoadInfo(_AppointmentID);

            if(ctrlScheduledTest1.TestAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;

            int TestID = ctrlScheduledTest1.TestID;

            if (TestID != -1)
            {
                _Test = clsTestBLayer.Find(TestID);

                if (_Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;

                txtNotes.Text = _Test.Notes;

                LblUserMessage.Visible = true;
                btnSave.Enabled = false;
                txtNotes.Enabled = false;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
            }
            else
            {
                _Test = new clsTestBLayer();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                     "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
            )
            {
                return;
            }

            _Test.TestAppointmentID = _AppointmentID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                txtNotes.Enabled = false;
                rbFail.Enabled = false;
                rbPass.Enabled = false;

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
