using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rakib.Users.Controls
{
    public partial class CTRLAddUpdateUser : UserControl
    {
        public CTRLAddUpdateUser()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            TCAddUser.SelectedTab = tpLoginInfo;

        }

        private void TBPassword_TextChanged(object sender, EventArgs e)
        {
            TBPassword.UseSystemPasswordChar = true;

            TBPassword.PasswordChar = '*';
        }

        private void TBConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            TBConfirmPassword.UseSystemPasswordChar = true;

            TBConfirmPassword.PasswordChar = '*';
        }
    }
}
