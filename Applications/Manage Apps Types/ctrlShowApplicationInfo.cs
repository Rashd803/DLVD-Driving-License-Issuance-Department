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
using Rakib.GlobalClasses;
using Rakib.People;
using static System.Net.Mime.MediaTypeNames;

namespace Rakib.Applications.Manage_Apps_Types
{
    public partial class ctrlShowApplicationInfo : UserControl
    {
        private clsApplicationBLayer _Application;
        private int _ApplicaitonID = -1;

        public int ApplicaitonID
        {
            get
            {
                return _ApplicaitonID;
            }
        }
        public ctrlShowApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplicationBLayer.FindBaseApplication(ApplicationID);
            if (_Application == null)
            {
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationInfo();
        }

        private void _FillApplicationInfo()
        {
            _ApplicaitonID = _Application.ApplicationID;
            LblAppID.Text = _ApplicaitonID.ToString();
            LblDate.Text = clsFormat.DateToShort(_Application.ApplicationDate);
            LblSDate.Text = clsFormat.DateToShort(_Application.LastStatusDate);
            LblType.Text = _Application.ApplicationTypeInfo.ApplicationTypeTitle;
            LblFees.Text = _Application.PaidFees.ToString();
            LblPerson.Text = _Application.ApplicantFullName;
            LblUser.Text = _Application.CreatedByUSerInfo.Username;
            LblStatus.Text = _Application.StatusText;
        }


   

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new FRMShowPersonInfo(_Application.ApplicantPersonID);
            form.ShowDialog();

            //Refresh
            LoadApplicationInfo(_ApplicaitonID);
        }
    }
}
