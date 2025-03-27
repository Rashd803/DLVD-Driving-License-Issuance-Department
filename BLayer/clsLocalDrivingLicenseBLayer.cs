using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLayer;
using DALayer;
using static System.Net.Mime.MediaTypeNames;
using static BusinessLayer.clsTestTypesBLayer;

namespace BusinessLayer

{
    public class clsLocalDrivingLicenseBLayer : clsApplicationBLayer
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public static enMode Mode = enMode.AddNew;


        public  int LocalDrivingLicenseApplicationID { get; set; } 
        public  int LicenseClassID { get; set; }
        public clsDrivingClassesBLayer LicenseClassInfo;
        public string PersonFullName
        {
            get
            {
                return clsPeopleBLayer.FindPersonByID(ApplicantPersonID).FullName;
            }

        }





        public clsLocalDrivingLicenseBLayer()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;
            Mode = enMode.AddNew;

        }
        public clsLocalDrivingLicenseBLayer
            (
            int LDLID,int LicenseClassID, int ApplicationID,
            int ApplicantPersonID,DateTime ApplicationDate,
            int ApplicationTypeID, enApplicationStatus ApplicationStatus
            , DateTime LastStatusDate, float PaidFees, int CreatedByUserID
            )
        {

            this.LocalDrivingLicenseApplicationID = LDLID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID= LicenseClassID;
            this.LicenseClassInfo = clsDrivingClassesBLayer.GetClassInfo(LicenseClassID);
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
          
        }

        private bool _AddNewLDLApp()
        {
            //clsLocalDrivingLicenseDALayer.AddNewApp(ref ID,this.PersonID,this.AppFDate,this.AppLDate,this.PaidFees,this.CreationUserID);
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseDALayer.AddNewLDLApp(ApplicationID, this.LicenseClassID);
            return (this.LocalDrivingLicenseApplicationID != -1);
        }
        private bool _UpdateLDLApp()
        {
            return clsLocalDrivingLicenseDALayer.UpdateLDLApp(this.LocalDrivingLicenseApplicationID, this.LicenseClassID);
          

        }

        public static bool DeleteApp(int AppID)
        {
            return clsLocalDrivingLicenseDALayer.DeleteLDLApp(AppID);
        }

        public static DataTable GetAllLDApps()
        {
            return clsLocalDrivingLicenseDALayer.GetAllLDLApps();
        }

        public byte GetPassedTestCount()
        {
            return clsTestBLayer.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }

        public static clsLocalDrivingLicenseBLayer FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseApplicationID)
        {
            // 
            int ApplicationID = -1, LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseDALayer.GetLDLAppInfoByLDLID
                (LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);


            if (IsFound)
            {
                //now we find the base application
                clsApplicationBLayer Application = clsApplicationBLayer.FindBaseApplication(ApplicationID);

                //we return new object of that person with the right data
                return new clsLocalDrivingLicenseBLayer(
                    LocalDrivingLicenseApplicationID, LicenseClassID,
                    Application.ApplicationID,
                    Application.ApplicantPersonID,
                                     Application.ApplicationDate, Application.ApplicationTypeID,
                                    (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                                     Application.PaidFees, Application.CreatedByUserID);
            }
            else
                return null;


        }

        public static clsLocalDrivingLicenseBLayer GetLDLAppInfoByLDLID(int LDLID)
        {
            int AppID = -1, LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseDALayer.GetLDLAppInfoByLDLID(LDLID, ref AppID, ref LicenseClassID);
            if (IsFound)
            {
                clsApplicationBLayer Application = clsApplicationBLayer.FindBaseApplication(AppID);

                return new clsLocalDrivingLicenseBLayer
                    (
                    LDLID, LicenseClassID, Application.ApplicationID, 
                    Application.ApplicantPersonID, Application.ApplicationDate, 
                    Application.ApplicationTypeID, Application.ApplicationStatus,
                    Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID
                    );
            }
            else
                return null;
        }

        public static clsLocalDrivingLicenseBLayer GetLDLAppInfoAppBy(int AppID)
        {
            int LDLID = -1, LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseDALayer.GetLDLAppInfoByAppID(AppID, ref LDLID, ref LicenseClassID);
            if (IsFound)
            {
                clsApplicationBLayer Application = clsApplicationBLayer.FindBaseApplication(AppID);

                return new clsLocalDrivingLicenseBLayer
                    (
                    LDLID, LicenseClassID, Application.ApplicationID,
                    Application.ApplicantPersonID, Application.ApplicationDate,
                    Application.ApplicationTypeID, Application.ApplicationStatus,
                    Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID
                    );
            }
            else
                return null;
        }

     

   
        public  bool Save()
        {
            // Save The Main App.
            base.Mode = (clsApplicationBLayer.enMode)Mode;
            if (!base.Save())
                return false;

            // Save LDL App.
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLDLApp())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                    case enMode.Update:
                    if(_UpdateLDLApp())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
            }

            return false;
        }


         public bool DoesPassTestType(clsTestTypesBLayer.enTestType TestTypeID)

         {
             return clsLocalDrivingLicenseDALayer.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
         }

          public bool DoesPassPreviousTest(clsTestTypesBLayer.enTestType CurrentTestType)
          {

              switch (CurrentTestType)
              {
                  case clsTestTypesBLayer.enTestType.VisionTest:
                      //in this case no required prvious test to pass.
                      return true;

                  case clsTestTypesBLayer.enTestType.WrittenTest:
                      //Written Test, you cannot sechdule it before person passes the vision test.
                      //we check if pass visiontest 1.

                      return this.DoesPassTestType(clsTestTypesBLayer.enTestType.VisionTest);


                  case clsTestTypesBLayer.enTestType.StreetTest:

                      //Street Test, you cannot sechdule it before person passes the written test.
                      //we check if pass Written 2.
                      return this.DoesPassTestType(clsTestTypesBLayer.enTestType.WrittenTest);

                  default:
                      return false;
              }
          }

         public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestTypesBLayer.enTestType TestTypeID)

         {
             return clsLocalDrivingLicenseDALayer.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
         } 

         public bool DoesAttendTestType(clsTestTypesBLayer.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseDALayer.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        } 

         public byte TotalTrialsPerTest(clsTestTypesBLayer.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseDALayer.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        } 

         public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestTypesBLayer.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseDALayer.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        } 

         public static bool AttendedTest(int LocalDrivingLicenseApplicationID, clsTestTypesBLayer.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseDALayer.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID) > 0;
        } 

        public bool AttendedTest(clsTestTypesBLayer.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseDALayer.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID) > 0;
        } 

         public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestTypesBLayer.enTestType TestTypeID)

        {

            return clsLocalDrivingLicenseDALayer.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        } 

         public bool IsThereAnActiveScheduledTest(clsTestTypesBLayer.enTestType TestTypeID)

        {

            return clsLocalDrivingLicenseDALayer.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

         public clsTestBLayer GetLastTestPerTestType(clsTestTypesBLayer.enTestType TestTypeID)
         {
             return clsTestBLayer.FindLastTestPerPersonAndLicenseClass(this.ApplicantPersonID, this.LicenseClassID, TestTypeID);
         }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestBLayer.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public byte GetPassedTestCount(string n = "")
         {
             return clsTestBLayer.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
         }



          public bool PassedAllTests()
          {
              return clsTestBLayer.PassedAllTests(this.LocalDrivingLicenseApplicationID);
          }

         public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
         {
             //if total passed test less than 3 it will return false otherwise will return true
             return clsTestBLayer.PassedAllTests(LocalDrivingLicenseApplicationID);
         }

         public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
         {
             int DriverID = -1;

             clsDriversBLayer Driver = clsDriversBLayer.FindByPersonID(this.ApplicantPersonID);

             if (Driver == null)
             {
                 //we check if the driver already there for this person.
                 Driver = new clsDriversBLayer();

                 Driver.PersonID = this.ApplicantPersonID;
                 Driver.CreatedByUserID = CreatedByUserID;
                 if (Driver.Save())
                 {
                     DriverID = Driver.DriverID;
                 }
                 else
                 {
                     return -1;
                 }
             }
             else
             {
                 DriverID = Driver.DriverID;
             }
             //now we diver is there, so we add new licesnse

             clsLicenseBLayer License = new clsLicenseBLayer();
             License.ApplicationID = this.ApplicationID;
             License.DriverID = DriverID;
             License.LicenseClass = this.LicenseClassID;
             License.IssueDate = DateTime.Now;
             License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
             License.Notes = Notes;
             License.PaidFees = this.LicenseClassInfo.ClassFees;
             License.IsActive = true;
             License.IssueReason = clsLicenseBLayer.enIssueReason.FirstTime;
             License.CreatedByUserID = CreatedByUserID;

             if (License.Save())
             {
                 //now we should set the application status to complete.
                 this.SetComplete();

                 return License.LicenseID;
             }

             else
                 return -1;
         }
        

          public bool IsLicenseIssued()
          {
              return (GetActiveLicenseID() != -1);
          }
          

          public int GetActiveLicenseID()
          {//this will get the license id that belongs to this application
              return clsLicenseBLayer.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
          }




    }
}
