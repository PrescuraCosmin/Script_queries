using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace YourNamespace
{
    class Program
    {
        private static SqlConnection? connection;
        private static SqlCommand? command;

        private static void CreateCommand(string[] queryFilePaths, string connectionString)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (string queryFilePath in queryFilePaths)
                {
                    string queryString = File.ReadAllText(queryFilePath);
                    command = new SqlCommand(queryString, connection);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine("Query executed successfully. Rows affected: " + rowsAffected);
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error executing query: " + ex.Message);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            string[] queryFilePaths = {
                @"C:\Users\Cosmin\Desktop\SQLQuery1.sql",
                @"C:\Users\Cosmin\Desktop\SQLQuery2.sql"
            };
            string connectionString = @"Data Source=DESKTOP-N8PKN5D\MSSQLSERVER2023;Initial Catalog=Automatic queries;Integrated Security=True";

            CreateCommand(queryFilePaths, connectionString);
        }
    }
}
