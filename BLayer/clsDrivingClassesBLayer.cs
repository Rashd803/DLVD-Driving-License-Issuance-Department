using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer;


namespace BusinessLayer
{
    public class clsDrivingClassesBLayer
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode = enMode.AddNew;
        
        public int ClassID { get; set; } 
        public string ClassName { get; set; } 
        public string ClassDescription { get; set; } 
        public byte DefaultValidityLength { get; set; }
        public byte MinimumAllowedAge { set; get; }

        public float ClassFees { get; set; } 

        clsDrivingClassesBLayer()
        {
            this.ClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 18;
            this.DefaultValidityLength = 10;
            this.ClassFees = -1;
        }

        

        clsDrivingClassesBLayer( int ClassID, string ClassName,byte DefaultValidityLength,byte MinimumAllowedAge,  string ClassDescription, float ClassFees)
        {
            this.ClassID = ClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.DefaultValidityLength = DefaultValidityLength;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.ClassFees = ClassFees;
            this.ClassFees = ClassFees;
        }
        public static DataTable GetAllClasses ()
        {
            return clsDrivingClassesDALayer.GetAllLDApps ();
        }


        

        public static clsDrivingClassesBLayer GetClassInfo(string Name)
        {

            int ID = -1;
            byte MinimumAllowedAge = 18,  DefaultValidityLength = 10;
            float ClassFees = 0;
            string Description = "";

            if(clsDrivingClassesDALayer.GetClassInfoByName(ref ID,Name,ref Description, ref MinimumAllowedAge,ref DefaultValidityLength, ref ClassFees))
                return new clsDrivingClassesBLayer(ID,Name, DefaultValidityLength, MinimumAllowedAge,Description, ClassFees);
            else
                return null;

        }

        public static clsDrivingClassesBLayer GetClassInfo(int ID)
        {

            byte MinimumAllowedAge = 18, DefaultValidityLength = 10;
            float ClassFees = 0;
            string Description = "",Name = "";

            if (clsDrivingClassesDALayer.GetClassInfoByID( ID,ref Name, ref Description, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
                return new clsDrivingClassesBLayer(ID, Name, DefaultValidityLength, MinimumAllowedAge,Description, ClassFees);
            else
                return null;

        }
    }
}
