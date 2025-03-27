using System;
using System.Windows.Forms;
using BusinessLayer;

namespace Rakib.Users.Controls
{
    public partial class CTRLShowUserInfo : UserControl
    {

        clsUsersBLayer _User;
        private int _UserID = -1;

        public int UserID
        {
            get { return _UserID; }
        }
        public CTRLShowUserInfo()
        {
            InitializeComponent();
        }

        private void _FillUserData()
        {
            ctrlShowPersonInfo1.LoadPersonInfo(_User.PersonID);
            LblUserID.Text = _User.UserID.ToString();
            LblUserName.Text = _User.Username;
            if (_User.IsActive)
                LblIsAvtive.Text = "YES";
            else
                LblIsAvtive.Text = "NO";


        }

        public void LoadUserInfo(int UserID)
        {

            _UserID = UserID;
            _User = clsUsersBLayer.GetUserInfoByID(UserID);
            if (_User == null)
            {
                MessageBox.Show("User Is Not Exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserData();

        }

        
    }
}
