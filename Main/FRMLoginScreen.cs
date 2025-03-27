using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using BusinessLayer;

namespace Rakib.Main
{
    public partial class FRMLoginScreen : Form
    {
      
        public FRMLoginScreen()
        {
            InitializeComponent();


        }

        private void FRMLoginScreen_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";
            

            if (clsGlobal.GetStoredCredential(ref Username, ref Password))
            {
                TBUN.Text = Username;
                TBPW.Text = Password;
                CBRemember.Checked = true;
            }
            else
                CBRemember.Checked = false;

            if(!CBRemember.Checked)
            {
                TBUN.Text = "";
                TBPW.Text = "";
            }
        }

        // [[ FEATURE ]]
        static string ComputeHash(string input)
        {
            //SHA is Secured Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string HashPassword = ComputeHash(TBPW.Text);
            clsUsersBLayer User = clsUsersBLayer.GetUserInfoByUNAndPassword(TBUN.Text, HashPassword);
            if (User != null)
            {

                if (CBRemember.Checked)
                {
                    clsGlobal.RememberUserNameAndPassword(TBUN.Text, TBPW.Text);
                }
                else
                {
                    clsGlobal.RememberUserNameAndPassword("", "");

                }

                if (!User.IsActive)
                {
                    MessageBox.Show("Surry!,Your Account Is Not Active,Contact Admen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                clsGlobal.CurrentUser = User;
                this.Hide();
                Form form = new FRMMainScreen(this);
                form.ShowDialog();
                




            }
            else
            {
                TBUN.Focus();
                MessageBox.Show("Surry!,Username/Password Is Not Valid.\n\nPlease Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TBUN_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBUN.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBUN, "This Field Is Required!");
            }
        }

        private void TBPW_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBPW.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBPW, "This Field Is Required!");
            }
        }

        private void TBPW_TextChanged(object sender, EventArgs e)
        {
            TBPW.UseSystemPasswordChar = true;

            TBPW.PasswordChar = '*';
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
