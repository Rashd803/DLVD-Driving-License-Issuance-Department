using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer;

namespace BusinessLayer
{
    public class clsApplicationTypesBLayer
    {


        public int ApplicationTypeID {  get; set; }
        public string ApplicationTypeTitle { get; set; }

        public int ApplicationFees { get; set; }


        public clsApplicationTypesBLayer()
        {
            this.ApplicationTypeID = 0;
            this.ApplicationTypeTitle = "";
            this.ApplicationFees = -1;
        }
       public clsApplicationTypesBLayer(int ApplicationTypeID, string ApplicationTypeTitle, int ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;
        }
        public static DataTable GetApps()
        {
            return clsApplicationTypesDALayer.GetAllApps();
        }

        public static clsApplicationTypesBLayer FindAppByID(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            int ApplicationFees = 0;

            if (clsApplicationTypesDALayer.FindAppByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))
                return new clsApplicationTypesBLayer(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
            else
                return null;

        }

        private bool _UpdateApps()
        {
            return clsApplicationTypesDALayer.UpdateAppInfo(this.ApplicationTypeID,this.ApplicationTypeTitle,this.ApplicationFees);
        }


        public  bool Save()
        {
            return _UpdateApps();
        }


    }
}
