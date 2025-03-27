using BLayer;
using BusinessLayer;
using Rakib.Licenses.LocalLicense.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rakib.Applications.Detain_License.Forms
{
    public partial class FRMDetainLicense : Form
    {
        private int _DetainID = -1;
        private int _DetainLicenseID = -1;
        public FRMDetainLicense()
        {
            InitializeComponent();
        }

        private void FRMDetainLicense_Load(object sender, EventArgs e)
        {
            lblCreatedByUser.Text = clsGlobal.CurrentUser.Username;
            LblDetainDate.Text = DateTime.Now.ToShortDateString();
            TBFineFees.Enabled = false;
            btnDetainLicense.Enabled = false;
            btnLicenseHistory.Enabled = false;
            btnShowDetainLicense.Enabled = false;
        }

        private void ctrlShowLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            LblLicenseID.Text = SelectedLicenseID.ToString();
            btnLicenseHistory.Enabled = (SelectedLicenseID != -1);
            TBFineFees.Enabled = true;
            btnDetainLicense.Enabled = true;
            btnLicenseHistory.Enabled = true;
            TBFineFees.Text = "";
            if (!this.ValidateChildren())
            {
                return;
            }

            if (SelectedLicenseID == -1)

            {
                return;
            }

            clsLicenseBLayer DetainLicense = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo;

            if(DetainLicense.IsDetained)
            {
                MessageBox.Show("License Already Detained!", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TBFineFees.Enabled = false;
                btnDetainLicense.Enabled = false;
                return;
            }
            TBFineFees.Focus();
            btnDetainLicense.Enabled =  true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRMShowLicenseInfo Form = new FRMShowLicenseInfo(_DetainLicenseID);
            Form.ShowDialog();
        }

        private void btnLicenseHistory_Click(object sender, EventArgs e)
        {
            FRMLicensesHistory Form = new FRMLicensesHistory(ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            Form.ShowDialog();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }

            if (MessageBox.Show("Are you sure you want to Detain the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

             _DetainID = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.Detain(Convert.ToSingle(TBFineFees.Text), clsGlobal.CurrentUser.UserID);
            

            clsLicenseBLayer DetainedLicense = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo;

            if (_DetainID != -1)
            {
                LblDetainID.Text = _DetainID.ToString();
                _DetainLicenseID = DetainedLicense.LicenseID;
                MessageBox.Show("License Detained Successfully With ID =" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TBFineFees.Enabled = false;
                btnDetainLicense.Enabled = false;
                btnShowDetainLicense.Enabled = true;
            }
            else
                MessageBox.Show("Couldn't Detain The License!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void TBFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TBFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBFineFees, "This Field Is Required!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
