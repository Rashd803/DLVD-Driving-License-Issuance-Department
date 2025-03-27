using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using System.Diagnostics;

namespace DALayer
{
    public class clsLocalDrivingLicenseDALayer
    {
        public static DataTable GetAllLDLApps()
        {
            DataTable DT = new DataTable();
            SqlConnection Connectoin = new SqlConnection(DASettings.Connection);

            string Query = @"SELECT * FROM LocalDrivingLicenseApplications_View
                             ORDER BY ApplicationDate DESC";

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

   

        
        public static int AddNewLDLApp(int AppID, int ClassID)
        {
            SqlConnection Connection = new SqlConnection(DASettings.Connection);

            string Query = @"INSERT INTO LocalDrivingLicenseApplications(ApplicationID,LicenseClassID)
                             VALUES (@LDLID,@ClassID)
                             SELECT SCOPE_IDENTITY();";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LDLID", AppID);
            Command.Parameters.AddWithValue("@ClassID", ClassID);


            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    return insertedID;
                }
                else
                {
                    return -1;
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
                Connection.Close();
            }

            return -1;
        }
        public static bool UpdateLDLApp(int LDLID, int ClassID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DASettings.Connection);

            string query = @"UPDATE LocalDrivingLicenseApplications
                             SET LicenseClassID = @ClassID
                             WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDLID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLID", LDLID);
            command.Parameters.AddWithValue("@ClassID", ClassID);

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
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteLDLApp(int ApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DASettings.Connection);

            string query = @"DELETE FROM LocalDrivingLicenseApplications
                             WHERE LocalDrivingLicenseApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static bool GetLDLAppInfoByAppID(int AppID,ref int LDLID,ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DASettings.Connection);

            string query = @"SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID = @LDLID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LDLID", AppID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    LDLID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                 



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
        public static bool GetLDLAppInfoByLDLID(int LDLID, ref int AppID, ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DASettings.Connection);

            string query = @"SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID =@LDLID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LDLID", LDLID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    AppID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];

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

        

        public static bool DoesPassTestType(int LDLID,int TestTypeID)
        {
            bool Result = false;

            SqlConnection Connection = new SqlConnection(DASettings.Connection);

            string Query = @"SELECT TOP 1 
                            Tests.TestResult
                        FROM 
                            LocalDrivingLicenseApplications 
                        INNER JOIN 
                            TestAppointments 
                            ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                        INNER JOIN 
                            Tests 
                            ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                        WHERE 
                            LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDLID
                            AND TestAppointments.TestTypeID = @TestTypeID
                        ORDER BY 
                            TestAppointments.TestAppointmentID DESC;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LDLID", LDLID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null && bool.TryParse(result.ToString(), out bool ReturnedResult))
                {
                    Result = ReturnedResult;
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
                Connection.Close(); 
            }

            return Result;
        }

        public static bool DoesAttendTestType(int LDLID, int TestTypeID)

        {


            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DASettings.Connection);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDLID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LDLID", LDLID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsFound = true;
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

            return IsFound;

        }

        public static byte TotalTrialsPerTest(int LDLID, int TestTypeID)

        {


            byte TotalTrialsPerTest = 0;

            SqlConnection connection = new SqlConnection(DASettings.Connection);

            string query = @" SELECT TotalTrialsPerTest = count(TestID)
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LDLID = TestAppointments.LDLID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LDLID = @LDLID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                       ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LDLID", LDLID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                {
                    TotalTrialsPerTest = Trials;
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

            return TotalTrialsPerTest;

        }

        public static bool IsThereAnActiveScheduledTest(int LDLID, int TestTypeID)

        {

            bool Result = false;

            SqlConnection connection = new SqlConnection(DASettings.Connection);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDLID)  
                            AND(TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LDLID", LDLID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null)
                {
                    Result = true;
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

            return Result;

        }

        public static bool FindLDLAppByNNoAndClassName(ref int AppID, string NationalNo, string ClassName, ref string FullName, ref DateTime AppDate, ref int Status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DASettings.Connection);


            string query = @"SELECT DISTINCT 
                             LocalDrivingLicenseApplications.LDLID, 
                             LicenseClasses.ClassName, 
                             People.NationalNo,
                             People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName AS FullName,
                             Applications.ApplicationDate, 
                             TestAppointments.TestTypeID,
                             Applications.ApplicationStatus,
                             CASE
                                 WHEN TestAppointments.TestTypeID = 1 THEN 0
                                 WHEN TestAppointments.TestTypeID = 2 THEN 1
                         		WHEN TestAppointments.TestTypeID = 3 THEN 2
                                 WHEN Applications.ApplicationStatus = 3 THEN 3  
                                 ELSE 0
                             END AS PassedTests,
                             CASE
                                 WHEN Applications.ApplicationStatus = 1 THEN 'New'
                                 WHEN Applications.ApplicationStatus = 2 THEN 'Canceled'
                                 ELSE 'Completed'
                             END AS StatusOfApp,
                             Applications.CreatedByUserID
                         FROM 
                             Applications 
                             INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                             INNER JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID 
                             INNER JOIN People ON Applications.ApplicantPersonID = People.PersonID
                             INNER JOIN TestAppointments ON Applications.ApplicationStatus = TestAppointments.TestTypeID
                             WHERE NationalNo = @NationalNo AND ClassName = @ClassName";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    AppID = (int)reader["LDLID"];
                    NationalNo = (string)reader["NationalNo"];
                    ClassName = (string)reader["ClassName"];
                    FullName = (string)reader["FullName"];
                    AppDate = (DateTime)reader["ApplicationDate"];
                    byte Statusf = (byte)reader["ApplicationStatus"];
                    Status = Statusf;


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


        public static bool CancelLDLApp(int AppID,string ClassName)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DASettings.Connection);

            string query = @"UPDATE Applications
                             SET ApplicationStatus = 2
                             FROM Applications
                             INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                             INNER JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID 
                             INNER JOIN People ON Applications.ApplicantPersonID = People.PersonID
                             INNER JOIN TestAppointments ON Applications.ApplicationStatus = TestAppointments.TestTypeID
                             WHERE LocalDrivingLicenseApplications.LDLID = @LDLID AND LicenseClasses.ClassName = @ClassName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLID", AppID);
            command.Parameters.AddWithValue("@ClassName", ClassName);

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
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

      

        


    }
}
