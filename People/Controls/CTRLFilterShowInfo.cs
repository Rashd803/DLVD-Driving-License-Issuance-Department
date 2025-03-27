using System;
using System.ComponentModel;
using System.Windows.Forms;
using BusinessLayer;

namespace Rakib.People.Controls
{
    public partial class CTRLFilterShowInfo : UserControl
    {
        public delegate void DataBackDelegate(object sender, int id);
        public DataBackDelegate DataBack;
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> Handler = OnPersonSelected;
            if (Handler != null)
                Handler(PersonID);
        }

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnAdd.Visible = _ShowAddPerson;
            }
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
        public CTRLFilterShowInfo()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            get
            { return ctrlShowPersonInfo1.PersonID; }
        }



        public clsPeopleBLayer SelectedPersonInfo
        {
            get { return ctrlShowPersonInfo1.SelectedPersonInfo; }
        }

        public void LoadPersonINfo(int PersonID)
        {
            CBFilter.SelectedIndex = 0;
            TBFilter.Text = PersonID.ToString();
            _FindNow();
        }

        private void _FindNow()
        {
            switch (CBFilter.Text)
            {
                case "Person ID":
                    ctrlShowPersonInfo1.LoadPersonInfo(int.Parse(TBFilter.Text));
                    break;

                case "National No":
                    ctrlShowPersonInfo1.LoadPersonInfo(TBFilter.Text);
                    break;
                default:
                    break;

            }

            if (OnPersonSelected != null && FilterEnabled)
                OnPersonSelected(ctrlShowPersonInfo1.PersonID);

        }

        private void CTRLFilterShowInfo_Load(object sender, EventArgs e)
        {
            CBFilter.SelectedIndex = 0;
            TBFilter.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields are not valid!, put the mouse on the red icon.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FindNow();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FRMAddEditPerson form = new FRMAddEditPerson();
            form.DataBack += DataBackEvent;
            form.ShowDialog();
        }

        private void DataBackEvent(object sender, int PersonID)
        {
            CBFilter.SelectedIndex = 1;
            TBFilter.Text = PersonID.ToString();
            ctrlShowPersonInfo1.LoadPersonInfo(PersonID);
        }

        private void CBFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBFilter.Text = "";
            TBFilter.Focus();
        }

        public void FiterFocus()
        {
            TBFilter.Focus();
        }

        private void TBFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }

            if (CBFilter.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void TBFilter_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBFilter.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBFilter, "This Field Is Requierd!");

            }



            else
            {
                errorProvider1.SetError(TBFilter, null);

            }
        }
    }
}
