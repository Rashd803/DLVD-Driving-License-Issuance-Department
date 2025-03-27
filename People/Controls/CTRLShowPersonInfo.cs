using System;
using System.Windows.Forms;
using System.IO;
using BusinessLayer;
using Rakib.Properties;

namespace Rakib.People
{
    public partial class CTRLShowPersonInfo : UserControl
    {
        private clsPeopleBLayer _person;

        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPeopleBLayer SelectedPersonInfo
        {
            get { return _person; }

        }
        public CTRLShowPersonInfo()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            if (_person.Gendor == 0)
                PBPhoto.Image = Resources.person_man3;
            else
                PBPhoto.Image = Resources.Woman;

            string ImagePath = _person.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    PBPhoto.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Couldn't Found This Image: " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void _FillPersonInfo()
        {
            _PersonID = _person.ID;
            RLblPersonID.Text = _PersonID.ToString();
            RLblNationalNo.Text = _person.NationalNo.ToString();
            RLblName.Text = _person.FullName;
            RLblGender.Text = _person.Gendor == 0 ? "Male" : "FeMale";
            RLblEmail.Text = _person.Email;
            RLblPhone.Text = _person.Phone;
            RLblDateOfBirth.Text = _person.DateOfBirth.ToShortDateString();
            RLblCountry.Text = clsCountriesBLayer.FindCountryByID(_person.NationalityCountryID).CountryName;
            RLblAddress.Text = _person.Address;
            _LoadPersonImage();
        }


        public void LoadPersonInfo(int PersonID)
        {
            _person = clsPeopleBLayer.FindPersonByID(PersonID);

            if (_person == null)
            {
                MessageBox.Show("The PersonInfo With ID: " + PersonID.ToString() + "Is Not Esist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();

        }

        public void LoadPersonInfo(string NationalNo)
        {
            _person = clsPeopleBLayer.FindPersonByNNo(NationalNo);

            if (_person == null)
            {
                MessageBox.Show("The Person With National Number: " + NationalNo.ToString() + " Is Not Esist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();

        }

        private void CTRLShowPersonInfo_Load(object sender, EventArgs e)
        {

        }

        private void LLBlEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsPeopleBLayer.Mode = clsPeopleBLayer.enMode.Update;
            Form form = new FRMAddEditPerson(_PersonID);
            form.ShowDialog();
            LoadPersonInfo(_PersonID);

        }
    }
}
