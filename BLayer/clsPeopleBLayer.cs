using System;
using System.Data;
using DALayer;

namespace BusinessLayer
{
    public class clsPeopleBLayer
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public static enMode Mode = enMode.AddNew;
        public int ID { get; set; }
       
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {SecondName} {ThirdName} {LastName}"; } }

        public DateTime DateOfBirth { set; get; }
        public int Gendor { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public string NationalNo { set; get; }
        public int NationalityCountryID { set; get; }

        public clsCountriesBLayer CountryInfo;

        private string _ImagPath;
        public string ImagePath
        {
            get { return _ImagPath; }
            set { _ImagPath = value; }

        }
        public clsPeopleBLayer()
        {

        }

        clsPeopleBLayer(int ID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
             DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.ID = ID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.CountryInfo = clsCountriesBLayer.FindCountryByID(NationalityCountryID);
            this.ImagePath = ImagePath;



        }

        private bool _AddNewPerson()
        { this.ID = clsPeopleDALayer.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
              this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.ID != -1);
        }

        private bool _UpdatePersonInfo()
        {


            return clsPeopleDALayer.UpdatePersonInfo(this.ID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
              this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

        }

        public static bool IsPersonEsistByNNO(string NationalNo)
        {
            return clsPeopleDALayer.IsPersonEsist(NationalNo);
        }
        public static DataTable GetPeopleInfo()
        {
            return clsPeopleDALayer.GetAllPeople();
        }

    

        public static clsPeopleBLayer FindPersonByID(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int Gendor = -1, NationalityCountryID = -1;
            if (clsPeopleDALayer.FindPersonByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPeopleBLayer(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
                return null;
        }

        public static clsPeopleBLayer FindPersonByNNo(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int PersonID = -1, Gendor = -1, NationalityCountryID = -1;
            if (clsPeopleDALayer.FindPersonByNNo(ref PersonID,  NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPeopleBLayer(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
                return null;
        }

        public static bool DeletePerson(int ID)
        {
            return clsPeopleDALayer.DeletePerson(ID);
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    if(_UpdatePersonInfo())
                    {
                        Mode = enMode.AddNew;
                        return true;

                    }
                    else
                    {
                        return false;
                    }

            }




            return false;
        }

    }
}
