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

namespace Rakib.Tests_Types
{
    public partial class FRMTestsTypesManagement : Form
    {
        public FRMTestsTypesManagement()
        {
            InitializeComponent();
        }

        private void FRMTestsTypesManagement_Load(object sender, EventArgs e)
        {
            DGVTestTypes.DataSource = clsTestTypesBLayer.GetTests();
            LBRecordFound.Text = DGVTestTypes.Rows.Count.ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FRMUpdateTests((clsTestTypesBLayer.enTestType)DGVTestTypes.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            DGVTestTypes.DataSource = clsTestTypesBLayer.GetTests();
            LBRecordFound.Text = DGVTestTypes.Rows.Count.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
