using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using Rakib.People.Controls;

namespace Rakib.Users.Forms
{
    public partial class FRMAddUpdateUser : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        public static enMode Mode = enMode.AddNew;
        private clsUsersBLayer _User;
        private int _UserID;

        public FRMAddUpdateUser()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }

        public FRMAddUpdateUser(int UserID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            _UserID = UserID;
        }

        private void _LoadData()
        {
            _User = clsUsersBLayer.GetUserInfoByID(_UserID);
            ctrlFilterShowInfo2.FilterEnabled = false;
            if (_User == null)
            {
                MessageBox.Show("No User With ID [ " + _UserID + " ] PersonInfo Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            LblUserID.Text = _User.UserID.ToString();
            TBUSername.Text = _User.Username;
            TBPassword.Text = _User.Password;
            TBConfirmPassword.Text = _User.Password;
            CBIsActive.Checked = _User.IsActive;
            ctrlFilterShowInfo2.LoadPersonINfo(_User.PersonID);

        }

        private void _ReSetData()
        {
            if (Mode == enMode.AddNew)
            {
                LblMain.Text = "Add User";
                _User = new clsUsersBLayer();
                tpLoginInfo.Enabled = false;
                ctrlFilterShowInfo2.FiterFocus();
            }

            else
            {
                LblMain.Text = "Update User";
                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
            }

            TBUSername.Text = "";
            TBPassword.Text = "";
            TBConfirmPassword.Text = "";
            CBIsActive.Checked = true;
        }


        private void FRMAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ReSetData();
            if (Mode == enMode.Update)
                _LoadData();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                TCAddUser.SelectedTab = TCAddUser.TabPages["tpLoginInfo"];
                return;
            }
            if (ctrlFilterShowInfo2.SelectedPersonInfo.ID != -1)
            {
                if (clsUsersBLayer.IsUserExistPI(ctrlFilterShowInfo2.PersonID))
                {
                    MessageBox.Show("Selected Person Is Already A User,Choose Another One.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlFilterShowInfo2.FiterFocus();
                }
                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    TCAddUser.SelectedTab = TCAddUser.TabPages["tpLoginInfo"];

                }

            }
            else
            {
                MessageBox.Show("Please Select A Person.", "Select Person", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ctrlFilterShowInfo2.FiterFocus();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            DataBack?.Invoke(this, ctrlFilterShowInfo2.PersonID);
        }

        static string ComputeHash(string input)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Are Not Valid!,Put The Mouse On The Red Icon.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.UserID = _UserID;
            _User.PersonID = ctrlFilterShowInfo2.PersonID;
            _User.Username = TBUSername.Text;

            string HashedPassword = ComputeHash(TBConfirmPassword.Text);
            _User.Password = HashedPassword;

            _User.IsActive = (CBIsActive.Checked);

            if (_User.Save())
            {
                LblUserID.Text = _User.UserID.ToString();
                Mode = enMode.Update;
                LblMain.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _User.UserID);

            }
            else
            {
                MessageBox.Show("Data Have Not Saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void TBConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBConfirmPassword, "This Field Is Required!.");
            }
            if (TBConfirmPassword.Text != TBPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(TBConfirmPassword, "The Password Is Not Matched!!");
            }
        }

        private void TBConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            TBConfirmPassword.UseSystemPasswordChar = true;
            TBConfirmPassword.PasswordChar = '*';
        }

        private void TBPassword_TextChanged(object sender, EventArgs e)
        {
            TBPassword.UseSystemPasswordChar = true;
            TBPassword.PasswordChar = '*';
        }

        private void TBPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TBPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBPassword, "This Field Is Required!.");
            }
           
        }
    }
}
