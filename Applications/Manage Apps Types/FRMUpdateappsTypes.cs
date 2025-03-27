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

namespace Rakib.Apps.LocalDrivingApps
{
    public partial class FRMUpdateappsTypes : Form
    {
        private clsApplicationTypesBLayer _App;
        private int AppID = -1;

        public FRMUpdateappsTypes(int AppID)
        {
            InitializeComponent();
            this.AppID = AppID;
        }

        private void FRMAddUpdateLDApps_Load(object sender, EventArgs e)
        {
            LblAppID.Text = AppID.ToString();

            _App = clsApplicationTypesBLayer.FindAppByID(AppID);


            if (_App != null)
            {
                TBAppName.Text = _App.ApplicationTypeTitle;
                TBAppFee.Text = _App.ApplicationFees.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Are Not Valid!,Put The Mouse On The Red Icon.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _App.ApplicationTypeTitle = TBAppName.Text;
            _App.ApplicationFees = Convert.ToInt32(TBAppFee.Text.Trim());

            if (_App.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could Not Save Data!.", "Erroe", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TBAppName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBAppName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBAppName, "This Field Is Required!");
            }
            else
                errorProvider1.SetError(TBAppName, null);
        }

        private void TBAppFee_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TBAppFee.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBAppFee, "This Field Is Required!");
            }
            else
                errorProvider1.SetError(TBAppFee, null);

            if (!clsGlobal.IsNumber(TBAppFee.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBAppFee, "The Input Should Be Number!");
            }
            else
                errorProvider1.SetError(TBAppFee, null);
        }
    }
}
