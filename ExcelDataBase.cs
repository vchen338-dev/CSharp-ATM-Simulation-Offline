using System;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace ATM_Simulation__Offline_
{
    internal class ExcelDataBase
    {

        public static string filePath = @"C:\Git Repos\bin\Debug\DataBase.xlsx";

        public static string connectionString =
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'";


        public static bool ValidateUser(string username, string pin)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [userdata$] WHERE Username = ? AND Pin = ?";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", username);
                    command.Parameters.AddWithValue("?", pin);

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }


        public static void RegisterUser(string username, string pin)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO [userdata$] (Username, Pin) VALUES (?, ?)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", username);
                    command.Parameters.AddWithValue("?", pin);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}//latest