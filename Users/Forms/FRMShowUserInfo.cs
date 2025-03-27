using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rakib.Users.Controls;

namespace Rakib.Users.Forms
{
    public partial class FRMShowUserInfo : Form
    {
        private int _UserID = -1;

        public FRMShowUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FRMShowUserInfo_Load(object sender, EventArgs e)
        {
            ctrlShowUserInfo1.LoadUserInfo(_UserID);

        }
    }
}
