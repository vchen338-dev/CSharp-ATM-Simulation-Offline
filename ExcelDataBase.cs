using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ATM_Simulation__Offline_
{
    public static class ExcelDataBase
    {
        // ⚠ IMPORTANT REMINDER:
        // If this project is cloned or pulled from the repository,
        // ALWAYS UPDATE this database path to your local machine's correct directory.
        private static string path = @"C:\Github338\vchen338-dev\CSharp-ATM-Simulation-Offline\bin\Debug\DataBase.xlsx";

        // Connection string for accessing the Excel file using OleDB
        private static string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0 Xml;HDR=YES;';";


        public static void RegisterUser(string username, string pin)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                // Check if username already exists
                OleDbCommand checkCmd = new OleDbCommand("SELECT * FROM [userdata$] WHERE Username = ?", conn);
                checkCmd.Parameters.AddWithValue("?", username);
                OleDbDataReader reader = checkCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    MessageBox.Show("Username already exists! Please choose another one.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    reader.Close();
                    return;
                }

                reader.Close();

                // Insert new user with default balance of 0
                OleDbCommand cmd = new OleDbCommand("INSERT INTO [userdata$] (Username, Pin, Balance) VALUES (?, ?, ?)", conn);
                cmd.Parameters.AddWithValue("?", username);
                cmd.Parameters.AddWithValue("?", pin);
                cmd.Parameters.AddWithValue("?", 0);
                cmd.ExecuteNonQuery();

                // Add history record for account creation
                OleDbCommand historyCmd = new OleDbCommand("INSERT INTO [datahistory$] (Username, Record) VALUES (?, ?)", conn);
                historyCmd.Parameters.AddWithValue("?", username);
                historyCmd.Parameters.AddWithValue("?", "Account created with ₱0 balance ("
                    + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + ")");
                historyCmd.ExecuteNonQuery();
            }
        }


        public static bool ValidateUser(string username, string pin)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                // Check if username + PIN matches a record in userdata sheet
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [userdata$] WHERE Username = ? AND Pin = ?", conn);
                cmd.Parameters.AddWithValue("?", username);
                cmd.Parameters.AddWithValue("?", pin);

                OleDbDataReader reader = cmd.ExecuteReader();
                return reader.HasRows; // Returns true if login is valid
            }
        }


        public static decimal GetBalance(string username)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                // Get current balance of the user
                OleDbCommand cmd = new OleDbCommand("SELECT Balance FROM [userdata$] WHERE Username = ?", conn);
                cmd.Parameters.AddWithValue("?", username);

                object result = cmd.ExecuteScalar();

                // Convert balance to decimal safely
                if (result != null && decimal.TryParse(result.ToString(), out decimal balance))
                {
                    return balance;
                }
                else
                {
                    return 0; // Return 0 if something goes wrong
                }
            }
        }


        public static void UpdateBalance(string username, decimal newBalance)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                // Update user balance in the Excel database
                OleDbCommand cmd = new OleDbCommand("UPDATE [userdata$] SET Balance = ? WHERE Username = ?", conn);
                cmd.Parameters.AddWithValue("?", newBalance);
                cmd.Parameters.AddWithValue("?", username);
                cmd.ExecuteNonQuery();
            }
        }


        public static void AddHistory(string username, string record)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                // Insert a new transaction history record
                OleDbCommand cmd = new OleDbCommand("INSERT INTO [datahistory$] (Username, Record) VALUES (?, ?)", conn);
                cmd.Parameters.AddWithValue("?", username);
                cmd.Parameters.AddWithValue("?", record + " (" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + ")");
                cmd.ExecuteNonQuery();
            }
        }

        // Check if a username exists in the system
        public static bool UserExists(string username)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [userdata$] WHERE Username = ?", conn);
                cmd.Parameters.AddWithValue("?", username);

                OleDbDataReader reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
        }

        // Update user PIN
        public static void UpdatePin(string username, string newPin)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                OleDbCommand cmd = new OleDbCommand("UPDATE [userdata$] SET Pin = ? WHERE Username = ?", conn);
                cmd.Parameters.AddWithValue("?", newPin);
                cmd.Parameters.AddWithValue("?", username);
                cmd.ExecuteNonQuery();
            }
        }

    }
}

// Final for ExcelDataBase 15/11/2025 (Venz Jochen Galera)