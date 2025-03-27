using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using Rakib.Apps.LocalDrivingApps;

namespace Rakib.Apps.Manage_Apps_Types
{
    public partial class FRMAppstypes : Form
    {
        public FRMAppstypes()
        {
            InitializeComponent();
        }


        private void FRMAppstypes_Load(object sender, EventArgs e)
        {
            DGVAppTypes.DataSource = clsApplicationTypesBLayer.GetApps();
            LBRecordFound.Text = DGVAppTypes.Rows.Count.ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FRMUpdateappsTypes((int)DGVAppTypes.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            DGVAppTypes.DataSource = clsApplicationTypesBLayer.GetApps();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
