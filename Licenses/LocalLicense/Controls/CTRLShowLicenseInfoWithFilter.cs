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

namespace Rakib.Licenses.LocalLicense.Controls
{
    public partial class CTRLShowLicenseInfoWithFilter : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnLicenseSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }

        public CTRLShowLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                GBFilter.Enabled = _FilterEnabled;
            }
        }

        private int _LicenseID = -1;

        public int LicenseID
        {
            get { return ctrlShowLicenseInfo1.LicenseID; }
        }

        public clsLicenseBLayer SelectedLicenseInfo
        { get { return ctrlShowLicenseInfo1.SelectedLicenseInfo; } }

        public void LoadLicenseInfo(int LicenseID)
        {


            TBFilter.Text = LicenseID.ToString();
            ctrlShowLicenseInfo1.LoadInfo(LicenseID);
            _LicenseID = ctrlShowLicenseInfo1.LicenseID;
            if (OnLicenseSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnLicenseSelected(_LicenseID);


        }




        private void TBFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some Fileds Are Not Valide!, Put The Mouse Over The Red Icon(s) To See The Erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TBFilter.Focus();
                return;

            }
            _LicenseID= int.Parse(TBFilter.Text);
            LoadLicenseInfo(_LicenseID);
        }

        public void txtLicenseIDFocus()
        {
            TBFilter.Focus();
        }

        private void TBFilter_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(TBFilter.Text))
            {
                e.Cancel = true;

                errorProvider1.SetError(TBFilter,"This Field Is Requiered!");
            }
            else
                errorProvider1.SetError(TBFilter, null);


        }
    }
}
