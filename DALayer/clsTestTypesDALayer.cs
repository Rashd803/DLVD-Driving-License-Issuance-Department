using System;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;


namespace DALayer
{
    public class clsTestTypesDALayer
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable DT = new DataTable();
            SqlConnection Connectoin = new SqlConnection(DASettings.Connection);

            string Query = @"SELECT * FROM TestTypes";

            SqlCommand Command = new SqlCommand(Query, Connectoin);

            try
            {
                Connectoin.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    DT.Load(Reader);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                string sourceName = "RAKIB";


                // Create the event source if it does not exist
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                    Console.WriteLine("Event source created.");
                }


                // Log an information event
                EventLog.WriteEntry(sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                Connectoin.Close();
            }
            return DT;

        }

        public static bool UpdateTestInfo(int TestTypeID, string TestTypeTitle, string TestTypeDescription, int TestTypeFees)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DASettings.Connection);

            decimal TestTypeFeesDecimal = (decimal)TestTypeFees;
            string query = @"UPDATE TestTypes  
                 SET TestTypeTitle = @TestTypeTitle,
                     TestTypeFees = @TestTypeFeesDecimal,
                     TestTypeDescription = @TestTypeDescription
                 WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeFeesDecimal", TestTypeFeesDecimal);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string sourceName = "RAKIB";


                // Create the event source if it does not exist
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                    Console.WriteLine("Event source created.");
                }


                // Log an information event
                EventLog.WriteEntry(sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);

        }


        public static bool FindTestTypeByID(int TestTypeID,ref string TestTypeTitle,ref string TestTypeDescription,ref int TestTypeFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DASettings.Connection);

            string query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    TestTypeID = (int)reader["TestTypeID"];
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    decimal TestTypeFeesDecimal = (decimal)reader["TestTypeFees"];
                    TestTypeFees = Convert.ToInt32(TestTypeFeesDecimal);
                    TestTypeDescription = (string)reader["TestTypeDescription"];



                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                string sourceName = "RAKIB";


                // Create the event source if it does not exist
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                    Console.WriteLine("Event source created.");
                }


                // Log an information event
                EventLog.WriteEntry(sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewTestType(string Title, string Description, float Fees)
        {
            int TestTypeID = -1;

            SqlConnection connection = new SqlConnection(DASettings.Connection);

            string query = @"Insert Into TestTypes (TestTypeTitle,TestTypeTitle,TestTypeFees)
                            Values (@TestTypeTitle,@TestTypeDescription,@ApplicationFees)
                            where TestTypeID = @TestTypeID;
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", Title);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestTypeID = insertedID;
                }
            }

            catch (Exception ex)
            {
                string sourceName = "RAKIB";


                // Create the event source if it does not exist
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                    Console.WriteLine("Event source created.");
                }


                // Log an information event
                EventLog.WriteEntry(sourceName, "Error: " + ex.Message, EventLogEntryType.Error);

            }

            finally
            {
                connection.Close();
            }


            return TestTypeID;

        }



    }
}
