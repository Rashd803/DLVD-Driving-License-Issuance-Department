using System.Data;
using DALayer;

namespace BusinessLayer
{
    public class clsUsersBLayer 
    {
        public enum enMode { AddNew = 0,Update = 1 }
        public static enMode Mode  = enMode.AddNew;
        public int UserID { get; set; }
        public clsPeopleBLayer PersonInfo;
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

       public clsUsersBLayer()
        {
            this.UserID = -1;
            this.Username = "";
            this.Password = "";
            this.IsActive = true;
            Mode = enMode.AddNew;
        }




        clsUsersBLayer(int UserID,int  PersonID,string Username,string Password,bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPeopleBLayer.FindPersonByID(PersonID);
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;
            Mode = enMode.Update;
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersDALayer.GetAllUsers();
        }


        public static clsUsersBLayer GetUserInfoByID(int UserID)
        {
            int PersonID = -1;
            string Username = "", Password = "";
            bool IsActive = false;

            if(clsUsersDALayer.GetUserInfoByID(UserID,ref PersonID,ref Username,ref Password,ref IsActive))
                return new clsUsersBLayer(UserID,PersonID,Username,Password,IsActive);
            else
                return null;
            
        }

        public static clsUsersBLayer GetUserInfoByPI(int PersonID)
        {
            int UserID = -1;
            string Username = "", Password = "";
            bool IsActive = false;

            if (clsUsersDALayer.GetUserInfoByPI(ref UserID,  PersonID, ref Username, ref Password, ref IsActive))
                return new clsUsersBLayer(UserID, PersonID, Username, Password, IsActive);
            else
                return null;
        }


        public static clsUsersBLayer GetUserInfoByUNAndPassword(string UserName,string Password)
        {
            int PersonID = -1,UserID = -1;
            bool IsActive = false;

            if (clsUsersDALayer.FindUserByUNAndPW(ref UserID, ref PersonID, UserName,  Password, ref IsActive))
                return new clsUsersBLayer(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;

        }


        private bool _AddUser()
        {
           this.UserID =  clsUsersDALayer.AddNewUser(this.Username,this.PersonID,this.Password,this.IsActive);

            return (this.UserID != -1);
         
        }

        private bool _UpdateUserInfo ()
        {
            

            if(clsUsersDALayer.UpdateUserInfo(this.UserID,this.PersonID,this.Username,this.Password,this.IsActive))
            {
                return true;
            }
            else
                return  false;

        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if (_AddUser())
                    {
                        Mode = enMode.AddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                if (_UpdateUserInfo())
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


        public static bool DeleteUser(int UserID)
        {
            if (clsUsersDALayer.DeleteUser(UserID))
                return true;
            else
                return false;
        }

        public static bool IsUserExist(int UserID)
        {
            return clsUsersDALayer.IsUserEsist(UserID);
        }

        public static bool IsUserExist(string UserName)
        {
            return clsUsersDALayer.IsUserEsist(UserName);
        }

        public static bool IsUserExistPI(int PersonID)
        {
            return clsUsersDALayer.IsUserEsistPI(PersonID);
        }

    }
}
