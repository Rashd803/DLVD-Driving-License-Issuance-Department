using System.Data;
using DALayer;

namespace BusinessLayer
{
    public class clsTestTypesBLayer
    {
        public enum enTestType {VisionTest = 1,WrittenTest = 2,StreetTest = 3 };
        public clsTestTypesBLayer.enTestType ID {  get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }

        public int TestTypeFees { get; set; }




        public clsTestTypesBLayer()
        {
            this.ID = 0;
            this.TestTypeTitle = "";
            this.TestTypeFees = -1;
        }
        public clsTestTypesBLayer(clsTestTypesBLayer.enTestType ID , string TestTypeTitle, string TestTypeDescription, int TestTypeFees)
        {
            this.ID = ID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }
        public static DataTable GetTests()
        {
            return clsTestTypesDALayer.GetAllTestTypes();
        }

        public static clsTestTypesBLayer FindTestByID(clsTestTypesBLayer.enTestType TestID)
        {
            string TestTypeTitle = "", TestTypeDescription = "";
            int TestTypeFees = 0;

            if (clsTestTypesDALayer.FindTestTypeByID((int)TestID, ref TestTypeTitle,ref TestTypeDescription, ref TestTypeFees))
                return new clsTestTypesBLayer(TestID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            else
                return null;

        }


   



        private bool _UpdateTests()
        {
            return clsTestTypesDALayer.UpdateTestInfo((int)this.ID, this.TestTypeTitle,this.TestTypeDescription, this.TestTypeFees);
        }


        public bool Save()
        {
            return _UpdateTests();
        }
    }
}
