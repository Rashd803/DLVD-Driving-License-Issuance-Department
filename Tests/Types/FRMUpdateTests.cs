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

namespace Rakib.Tests_Types
{

    public partial class FRMUpdateTests : Form
    {
        private clsTestTypesBLayer _Test;
        private clsTestTypesBLayer.enTestType TestID = clsTestTypesBLayer.enTestType.VisionTest;
        public FRMUpdateTests(clsTestTypesBLayer.enTestType TestID)
        {
            InitializeComponent();
            this.TestID = TestID;

        }

        private void FRMUpdateTests_Load(object sender, EventArgs e)
        {
            _Test = clsTestTypesBLayer.FindTestByID(TestID);

            if (_Test != null)
            {
                LblTestID.Text = ((int)_Test.ID).ToString();
                TBTestName.Text = _Test.TestTypeTitle;
                RTBDescription.Text = _Test.TestTypeDescription;
                TBTestFee.Text = _Test.TestTypeFees.ToString();
            }
            else
            {
                MessageBox.Show("Could Not Find Test Type With ID: " + _Test.ID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Are Not Valid!,Put The Mouse On The Red Icon.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Test.TestTypeTitle = TBTestName.Text;
            _Test.TestTypeDescription = RTBDescription.Text;
            _Test.TestTypeFees = Convert.ToInt32(TBTestFee.Text.Trim());

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could Not Save Data!.", "Erroe", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TBTestName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBTestName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBTestName, "This Field Is Required!");
            }
            else
                errorProvider1.SetError(TBTestName, null);
        }

        private void RTBDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(RTBDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(RTBDescription, "This Field Is Required!");
            }
            else
                errorProvider1.SetError(RTBDescription, null);
        }

        private void TBTestFee_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBTestFee.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBTestFee, "This Field Is Required!");
            }
            else
                errorProvider1.SetError(TBTestFee, null);

            if (!clsGlobal.IsNumber(TBTestFee.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBTestFee, "The Input Should Be Number!");
            }
            else
                errorProvider1.SetError(TBTestFee, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
