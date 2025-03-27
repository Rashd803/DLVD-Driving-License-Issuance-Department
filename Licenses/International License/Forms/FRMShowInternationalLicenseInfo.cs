using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rakib.Licenses.International_License.Forms
{
    public partial class FRMShowInternationalLicenseInfo : Form
    {
        private int _InternationalID = -1;
        public FRMShowInternationalLicenseInfo(int InternationalID)
        {
            InitializeComponent();
            _InternationalID = InternationalID;
        }

      
        private void FRMShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlShowIntLicenseInfo1.LoadInfo(_InternationalID);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
