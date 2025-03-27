using System;
using System.ComponentModel;
using System.Windows.Forms;
using BusinessLayer;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Rakib.Users.Forms
{
    public partial class FRMChangeUserPassword : Form
    {
        clsUsersBLayer _User;
        int _UserID = -1;
        public FRMChangeUserPassword(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRMChangeUserPassword_Load(object sender, EventArgs e)
        {
            _User = clsUsersBLayer.GetUserInfoByID(_UserID);
            if (_User == null)
            {
                MessageBox.Show("The _User Is Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlShowUserInfo1.LoadUserInfo(_UserID);
        }

        private void TBCurrentPW_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBCurrentPW.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBCurrentPW, "This Field Is Required");
                return;
            }
            else
            {
                errorProvider1.SetError(TBCurrentPW, null);

            }
            if (TBCurrentPW.Text != _User.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(TBCurrentPW, "Wrong Password!");
                return;
            }
            else
            {
                errorProvider1.SetError(TBCurrentPW, null);

            }
        }

        private void TBNPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBNPW.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBNPW, "This Field Is Required");
                return;
            }
            else
            {
                errorProvider1.SetError(TBNPW, null);

            }
        }

        private void TBCNPW_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBCNPW.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBCNPW, "This Field Is Required");
                return;
            }
            else
            {
                errorProvider1.SetError(TBCNPW, null);

            }

            if (TBCNPW.Text.Trim() != TBNPW.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(TBCNPW, "The Password Is Not Matched!");
                return;
            }
            else
            {
                errorProvider1.SetError(TBCNPW, null);

            }
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

            clsUsersBLayer.Mode = clsUsersBLayer.enMode.Update;

            string HashedPassword = ComputeHash(TBCNPW.Text);

            _User.Password = HashedPassword;

            if (_User.Save())
            {
                clsGlobal.RememberUserNameAndPassword(clsGlobal.CurrentUser.Username, TBCNPW.Text);

                clsGlobal.CurrentUser.Password = TBCNPW.Text;

                MessageBox.Show("Data Saved Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlShowUserInfo1.LoadUserInfo(_User.UserID);

            }
            else
                MessageBox.Show("Data Have Not Saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void TBCurrentPW_TextChanged(object sender, EventArgs e)
        {
            TBCurrentPW.UseSystemPasswordChar = true;

            TBCurrentPW.PasswordChar = '*';
        }

        private void TBNPW_TextChanged(object sender, EventArgs e)
        {
            TBNPW.UseSystemPasswordChar = true;

            TBNPW.PasswordChar = '*';
        }

        private void TBCNPW_TextChanged(object sender, EventArgs e)
        {
            TBCNPW.UseSystemPasswordChar = true;

            TBCNPW.PasswordChar = '*';
        }
    }
}
