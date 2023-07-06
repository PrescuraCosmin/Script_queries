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

        private static void CreateCommand(string queryFilePath, string connectionString)
{
    string queryString = File.ReadAllText(queryFilePath);

    using (connection = new SqlConnection(connectionString))
    {
        command  = new SqlCommand(queryString, connection);
        connection.Open();
         try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("Query executed successfully. Rows affected: " + rowsAffected);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error executing query: " + ex.Message );
                }
    }
}
    static void Main(string[] args) {

        // Insert the path here

        string queryFilePath = @"C:\Users\Cosmin\Desktop\SQLQuery.sql";

        // Insert the connection string here

        string connectionString = @"Data Source=DESKTOP-N8PKN5D\MSSQLSERVER2023;Initial Catalog=Automatic queries;Integrated Security=True";
        CreateCommand(queryFilePath, connectionString);
    }
}
}