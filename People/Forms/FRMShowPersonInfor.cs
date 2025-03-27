using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rakib.People
{
    public partial class FRMShowPersonInfo : Form
    {
        public FRMShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            ctrlShowPersonInfo1.LoadPersonInfo(PersonID);
        }

        public FRMShowPersonInfo(string NationalNo)
        {
            InitializeComponent();
            ctrlShowPersonInfo1.LoadPersonInfo(NationalNo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
