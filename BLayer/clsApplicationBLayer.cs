using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DALayer;

namespace BusinessLayer
{
    public class clsApplicationBLayer
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public  enMode Mode = enMode.AddNew;
        public enum enApplicationTypes { NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
                                        ReplaceDamagedDrivingLicense = 4, ReleaseDetainDrivingLicense = 5,NewInternational = 6,RetakeTest= 7};
        public enum enApplicationStatus { New = 1,Cancelled = 2,Completed = 3};

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public clsPeopleBLayer PersonInfo { get; set; }
        public string ApplicantFullName
        {
            get
            {
                return clsPeopleBLayer.FindPersonByID(ApplicantPersonID).FullName;  
            }
        }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationTypesBLayer ApplicationTypeInfo { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }
        public string StatusText
        {
            get {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";

                }

            }
        }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees   { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUsersBLayer CreatedByUSerInfo;

        public clsApplicationBLayer()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;


        }


        public clsApplicationBLayer
            (
            int ApplicationID,int ApplicantPersonID,
            DateTime ApplicationDate,int ApplicationTypeID,enApplicationStatus ApplicationStatus
            ,DateTime LastStatusDate,float PaidFees,int CreatedByUserID
            )
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.PersonInfo = clsPeopleBLayer.FindPersonByID(ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationTypesBLayer.FindAppByID(ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUSerInfo = clsUsersBLayer.GetUserInfoByID(CreatedByUserID);
            Mode = enMode.Update;


        }


        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationsDALayer.AddNewApplication(
                this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            return clsApplicationsDALayer.UpdateApplicationInfo(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

        }

        public static clsApplicationBLayer FindBaseApplication(int ApplicationID)
        {
            int ApplicationPersonID = -1,CreatedByUserID = -1,ApplicationTypeID = -1;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            byte ApplicationStatus = 1;
            float PaidFees = 0;

            bool IsFound = clsApplicationsDALayer.GetApplicationInfoByID
                (

                ApplicationID, ref ApplicationPersonID,
                ref ApplicationDate, ref ApplicationTypeID,
                ref ApplicationStatus, ref LastStatusDate,
                ref PaidFees, ref CreatedByUserID

                ) ;

            if (IsFound)
                return new clsApplicationBLayer
                    (
                    ApplicationID, ApplicationPersonID,
                    ApplicationDate, ApplicationTypeID,
                    (enApplicationStatus) ApplicationStatus, LastStatusDate,
                    PaidFees, CreatedByUserID
                    );
            else
                return null;


        }

        public bool Cancel()
        {
            return clsApplicationsDALayer.UpdateStatus(ApplicationID, 2);
        }

        public bool SetComplete()
        {
            return clsApplicationsDALayer.UpdateStatus (ApplicationID, 3);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    _AddNewApplication();
                    return true;
                    break;
                case enMode.Update:
                    _UpdateApplication();
                    return true;
                    break;
            }

            return false; 

        }

        public bool Delete()
        {
            return clsApplicationsDALayer.DeleteApplication(this.ApplicationID);
        }

        public static bool IsApplicaationExist(int ApplicationID)
        {
            return clsApplicationsDALayer.IsApplicationEsist(ApplicationID);
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID,int ApplicationTypeID)
        {
            return clsApplicationsDALayer.DoesPersonHaveAhtiveApplication(PersonID, ApplicationTypeID);
        }

        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return clsApplicationsDALayer.DoesPersonHaveAhtiveApplication(this.ApplicantPersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int PersonID, clsApplicationBLayer.enApplicationTypes ApplicationTypeID)
        {
            return clsApplicationsDALayer.GetActiveApplicationID(PersonID,(int) ApplicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplicationBLayer.enApplicationTypes ApplicationTypeID,int LicenseClassID)
        {
            return clsApplicationsDALayer.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

        public int GetActiveApplicationID(clsApplicationBLayer.enApplicationTypes ApplicationTypeID)
        {
            return GetActiveApplicationID(ApplicationTypeID);
        }
    }
}
