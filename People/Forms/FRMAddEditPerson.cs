using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using BusinessLayer;
using Rakib.Properties;
using static System.Net.Mime.MediaTypeNames;

namespace Rakib.People
{
    public partial class FRMAddEditPerson : Form
    {
        public delegate void DataBackDelegate(object sender, int id);
        public DataBackDelegate DataBack;

        public enum enMode { AddNew = 0, Update = 1 }
        private enum enGender { Male = 0, FeMale = 1 }
        public enMode Mode;
        private int _ID;
        private clsPeopleBLayer _Person;

        public FRMAddEditPerson()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }

        public FRMAddEditPerson(int ID)
        {
            InitializeComponent();
            _ID = ID;
            Mode = enMode.Update;
        }

        private void _LoadData()
        {
            _FillCountriesInComboBox();

            LblMain.Text = "Update Person";


            _Person = clsPeopleBLayer.FindPersonByID(_ID);
            if (_Person == null)
            {
                MessageBox.Show("No Person With ID [ " + _ID + " ] Person Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            LPersonID.Text = _Person.ID.ToString();
            txtNationalNo.Text = _Person.NationalNo;
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            if (_Person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
            txtEmail.Text = _Person.Email;
            rtxtAddress.Text = _Person.Address;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            txtPhone.Text = _Person.Phone;
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName);

            if (_Person.ImagePath != "")
                PBImage.ImageLocation = _Person.ImagePath;
            else
            {

                if (rbMale.Checked)
                {
                    PBImage.ImageLocation = @"C:\Users\srash\Desktop\Programming\19th Cource\Icons\man.png";
                }
                else
                {
                    PBImage.ImageLocation = @"C:\Users\srash\Desktop\Programming\19th Cource\Icons\Woman.png";

                }
            }
            btnRemove.Visible = (_Person.ImagePath != "");


        }

        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountriesBLayer.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        private void _ReSetDifultValues()
        {
            _FillCountriesInComboBox();

            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
            dtpDateOfBirth.Value = DateTime.Today.AddYears(-18);

            
               LblMain.Text = "Add Person";
                _Person = new clsPeopleBLayer();
            

            

            if(rbMale.Checked)
            {
                PBImage.Image = Resources.man;
            }
            else
                PBImage.Image = Resources.Woman;


            rbMale.Checked = true;
            btnRemove.Visible = (_Person.ImagePath == "" && _Person.ImagePath == @"C:\Users\srash\Desktop\Programming\19th Cource\Icons\man.png" && _Person.ImagePath == @"C:\Users\srash\Desktop\Programming\19th Cource\Icons\Woman.png");

            cbCountry.SelectedIndex = cbCountry.FindString("Canada");
        }
        private void FRMAddEditPerson_Load(object sender, EventArgs e)
        {
            if(Mode == enMode.AddNew)
            _ReSetDifultValues();
            if (Mode == enMode.Update)
                _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _HandleImage()
        {

            if (_Person.ImagePath != PBImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {


                    }
                }
            }

            if (PBImage.ImageLocation != null)
            {
                string SourceFile = PBImage.ImageLocation.ToString();

                if (clsUtil.CopyImageToProjectImagesFolder(ref SourceFile))
                {
                    PBImage.ImageLocation = SourceFile;
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Are Not Valid!,Put The Mouse On The Red Icon.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Mode == enMode.Update)
            {
                if (!_HandleImage())
                {
                    return;
                }
            }


            int NationalityID = clsCountriesBLayer.FindCountryByName(cbCountry.Text).CountryID;

            _Person.ID = _ID;

            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.NationalNo = txtNationalNo.Text;
            _Person.Email = txtEmail.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Address = rtxtAddress.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;

            if (rbMale.Checked)
                _Person.Gendor = (short)enGender.Male;
            else
                _Person.Gendor = (short)enGender.FeMale;
            _Person.NationalityCountryID = NationalityID;

            if (PBImage.ImageLocation != null)
                _Person.ImagePath = PBImage.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                LPersonID.Text = _Person.ID.ToString();
                Mode = enMode.Update;

                LblMain.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _Person.ID);
            }
            else
                MessageBox.Show("Error: Data Have Not Saved Successfuly!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void BtAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\srash\Desktop\Programming\Road Map\19th Cource\Icons",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select an Image"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PBImage.ImageLocation = openFileDialog.FileName;
                PBImage.SizeMode = PictureBoxSizeMode.Zoom;
                btnRemove.Visible = true;
            }
        }

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFirstName, "This Field Is Required!");
            }
        }

        private void txtSecondName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSecondName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSecondName, "This Field Is Required!");
            }
        }

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLastName, "This Field Is Required!");
            }
        }

        private void txtNationalNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This Field Is Required!");
            }
            else
            {
                ValidateEmptyTB.SetError(txtNationalNo, null);
            }

            bool ishe = clsPeopleBLayer.IsPersonEsistByNNO(txtNationalNo.Text.Trim());

            if (ishe && txtNationalNo.Text != _Person.NationalNo)
            {
                e.Cancel = true;
                ValidateEmptyTB.SetError(txtNationalNo, "National Nomber Is Used!\n Please Choose Another One.");

            }
            else
            {
                ValidateEmptyTB.SetError(txtNationalNo, null);

            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;


            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                ValidateEmptyTB.SetError(txtEmail, "Invalid Email Address Format!");

            }



            else
            {
                ValidateEmptyTB.SetError(txtEmail, null);

            }
        }

        private void rtxtAddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(rtxtAddress.Text.Trim()))
            {
                e.Cancel = true;
                ValidateEmptyTB.SetError(rtxtAddress, "This Field Is Required!");
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            PBImage.ImageLocation = null;
            PBImage.ImageLocation = "";
            if (rbMale.Checked)
            {
                PBImage.Image = Resources.man;
            }
            else
            {
                PBImage.Image = Resources.Woman;

            }

            btnRemove.Visible = false;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            PBImage.ImageLocation = null;
            PBImage.ImageLocation = "";

            if (PBImage.Image == null || PBImage.ImageLocation == "")
            {

                PBImage.Image = Resources.Woman;
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            PBImage.ImageLocation = null;
            PBImage.ImageLocation = "";

            if (PBImage.Image == null || PBImage.ImageLocation == "")
            {
                PBImage.Image = Resources.man;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
