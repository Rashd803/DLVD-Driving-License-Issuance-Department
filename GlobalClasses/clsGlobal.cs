using Microsoft.Win32;
using System;
using System.IO;


namespace BusinessLayer
{
    public class clsGlobal
    {
       public static clsUsersBLayer CurrentUser;
        public static bool RememberUserNameAndPassword(string Username,string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\Rakib";
            string valueName1 = "Username";
            string valueName2 = "Password";

            if (Username != "" && Password != "")
            {
                Registry.SetValue(keyPath, valueName1, Username, RegistryValueKind.String);
                Registry.SetValue(keyPath, valueName2, Password, RegistryValueKind.String);
                return true;
            }
            else
            {
                Registry.SetValue(keyPath, valueName1, string.Empty, RegistryValueKind.String);
                Registry.SetValue(keyPath, valueName2, string.Empty, RegistryValueKind.String);
                return false;
            }
            
           
        }

        public static bool GetStoredCredential(ref string UserName,ref string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\Rakib";
            string valueName1 = "Username";
            string valueName2 = "Password";

            // Read the value from the Registry
            string StoredUsername = Registry.GetValue(keyPath, valueName1, null) as string;
            string StoredPassword = Registry.GetValue(keyPath, valueName2, null) as string;
            
            
            if (StoredPassword != null && StoredUsername != null)
            {
                Password = StoredPassword;
                UserName = StoredUsername;
                return true;
            }
            
            return false;
        }

        public static bool IsNumber(string input) 
        {
            int number;

            return int.TryParse(input, out number);
        
        }
    }
}
