using System.Data;
using DALayer;

namespace BusinessLayer
{
    public class clsCountriesBLayer
    {

        public string CountryName { set; get; }
        public int CountryID { set; get; }


        clsCountriesBLayer(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;

        }

        public static  DataTable GetAllCountries()
        {
            return CountriesDALayer.GetAllCountries();

        }

        public static clsCountriesBLayer FindCountryByID(int ID)
        {
            string CountryName = "";


            if (CountriesDALayer.FindCountryByID(ID,ref CountryName))
            {
                return new clsCountriesBLayer(ID,CountryName);
            }
            else
                return null;
        }


        public static clsCountriesBLayer FindCountryByName(string CountryName)
        {

            int ID = -1;



            if (CountriesDALayer.GetCountryInfoByName(CountryName,ref ID))
                return new clsCountriesBLayer(ID, CountryName);
            else
                return null;

        }

    }
}
