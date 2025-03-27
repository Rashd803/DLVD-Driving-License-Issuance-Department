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

namespace Rakib.People
{
    public partial class FRMPeopleManagement : Form
    {
        
        public FRMPeopleManagement()
        {
            InitializeComponent();
        }


       private static DataTable _dtAllPeople = clsPeopleBLayer.GetPeopleInfo();


        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                                          "FirstName", "SecondName", "ThirdName", "LastName", "DateOfBirth",
                                 "GenderCaption", "CountryName", "Phone", "Email");

        private void _ReFreshData()
        {
            _dtAllPeople = clsPeopleBLayer.GetPeopleInfo();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                                          "FirstName", "SecondName", "ThirdName", "LastName", "DateOfBirth",
                                 "GenderCaption", "CountryName", "Phone", "Email");
            DGVPeopleManagement.DataSource = _dtPeople;

            LBRecordFound.Text = DGVPeopleManagement.Rows.Count.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRMPeopleManagement_Load(object sender, EventArgs e)
        {


            DGVPeopleManagement.DataSource = _dtPeople;


            CBFilter.SelectedIndex = 0;
            LBRecordFound.Text = DGVPeopleManagement.Rows.Count.ToString();
            TBFilter.Visible = (CBFilter.Text != "None");

            if (DGVPeopleManagement.Rows.Count > 0)
            {
                DGVPeopleManagement.Columns[0].HeaderText = "ID";
                DGVPeopleManagement.Columns[1].HeaderText = "National No";
                DGVPeopleManagement.Columns[2].HeaderText = "First Name";
                DGVPeopleManagement.Columns[3].HeaderText = "Second Name";
                DGVPeopleManagement.Columns[4].HeaderText = "Third Name";
                DGVPeopleManagement.Columns[5].HeaderText = "Last Name";
                DGVPeopleManagement.Columns[6].HeaderText = "Date Of Birth";
                DGVPeopleManagement.Columns[7].HeaderText = "Gender";
                DGVPeopleManagement.Columns[8].HeaderText = "Nationality";
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FRMShowPersonInfo((int)DGVPeopleManagement.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            _ReFreshData();

        



        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FRMAddEditPerson();
            form.ShowDialog();



            _ReFreshData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new FRMAddEditPerson();
            form.ShowDialog();



            _ReFreshData();

        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPeopleBLayer.Mode = clsPeopleBLayer.enMode.Update;
            Form form = new FRMAddEditPerson((int)DGVPeopleManagement.CurrentRow.Cells[0].Value);
            form.ShowDialog();



            _ReFreshData();


        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Delete the Person With ID [" + DGVPeopleManagement.CurrentRow.Cells[0].Value + "?", "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsPeopleBLayer.DeletePerson((int)DGVPeopleManagement.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("The Person Deleted Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    _ReFreshData();

                }
                else
                {
                    MessageBox.Show("Couldn't Delete The Person!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

        }

        private void TBFilter_TextChanged(object sender, EventArgs e)
        {

        


            string FilterColumn = "";

            switch (CBFilter.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gender":
                    FilterColumn = "GenderCaption";
                    break;


                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }



            if (TBFilter.Text.Trim() == "" || FilterColumn == "None")
            {
              _dtPeople.DefaultView.RowFilter = "";
                LBRecordFound.Text = DGVPeopleManagement.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "_LicenseID")

                  _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, TBFilter.Text.Trim());
            else
                        _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, TBFilter.Text.Trim());
                LBRecordFound.Text = DGVPeopleManagement.Rows.Count.ToString();


        }

        private void CBFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBFilter.Visible = (TBFilter.Text != "None");

            if (TBFilter.Visible)
            {
                TBFilter.Text = "";
                TBFilter.Focus();
            }
        }

        private void TBFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CBFilter.Text == "Person ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
