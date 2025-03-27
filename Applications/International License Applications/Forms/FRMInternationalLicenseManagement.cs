using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLayer;
using Rakib.Licenses.International_License.Forms;
using Rakib.Licenses.LocalLicense.Forms;
using Rakib.People;

namespace Rakib.International_License.Forms
{
    public partial class FRMInternationalLicenseManagement : Form
    {
        public FRMInternationalLicenseManagement()
        {
            InitializeComponent();
        }
    private DataTable _DTAllIntLicense = clsInternationalLicenseBLayer.GetAllInternationalLicenses();




        private void FRMInternationalLicenseManagement_Load(object sender, EventArgs e)
        {
            DGVDIntAppsManagement.DataSource = _DTAllIntLicense;
            LBRecordFound.Text = DGVDIntAppsManagement.Rows.Count.ToString();
            CBFilter.SelectedIndex = 0;
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsDriversBLayer.FindByDriverID((int)DGVDIntAppsManagement.CurrentRow.Cells[2].Value).PersonID;
            FRMShowPersonInfo Form = new FRMShowPersonInfo(PersonID);
            Form.ShowDialog();
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMShowInternationalLicenseInfo Form = new FRMShowInternationalLicenseInfo((int)DGVDIntAppsManagement.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsDriversBLayer.FindByDriverID((int)DGVDIntAppsManagement.CurrentRow.Cells[2].Value).PersonID;
            FRMLicensesHistory Form = new FRMLicensesHistory(PersonID);
            Form.ShowDialog();
        }

        private void CBFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBFilter.Visible = (CBFilter.Text != "None");
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
