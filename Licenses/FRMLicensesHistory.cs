using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rakib.Licenses.LocalLicense.Forms
{
    public partial class FRMLicensesHistory : Form
    {
        private int _PersonID = -1;
        public FRMLicensesHistory(int  PersonID)
        {
            InitializeComponent();
            //this.NationalNo = NationalNo;
            this._PersonID = PersonID;
        }

      
        private void FRMLicensesHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                ctrlShowPersonInfo1.LoadPersonInfo(_PersonID);
                ctrlDrivingLicense1.LoadInfoByPersonID(_PersonID);
            }
            else
            {
            }
        }

        private void ctrlShowPersonInfo1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
