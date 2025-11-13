using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ATM_Simulation__Offline_
{
    public static class ExcelDataBase
    {
        private static string path = @"C:\Git Repos\bin\Debug\DataBase.xlsx";
        private static string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0 Xml;HDR=YES;';";

        
        public static void RegisterUser(string username, string pin)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                
                OleDbCommand checkCmd = new OleDbCommand("SELECT * FROM [userdata$] WHERE Username = ?", conn);
                checkCmd.Parameters.AddWithValue("?", username);
                OleDbDataReader reader = checkCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    MessageBox.Show("Username already exists! Please choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    reader.Close();
                    return;
                }

                reader.Close();

                
                OleDbCommand cmd = new OleDbCommand("INSERT INTO [userdata$] (Username, Pin, Balance) VALUES (?, ?, ?)", conn);
                cmd.Parameters.AddWithValue("?", username);
                cmd.Parameters.AddWithValue("?", pin);
                cmd.Parameters.AddWithValue("?", 0); 
                cmd.ExecuteNonQuery();

                
                OleDbCommand historyCmd = new OleDbCommand("INSERT INTO [datahistory$] (Username, Record) VALUES (?, ?)", conn);
                historyCmd.Parameters.AddWithValue("?", username);
                historyCmd.Parameters.AddWithValue("?", "Account created with ₱0 balance (" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + ")");
                historyCmd.ExecuteNonQuery();
            }
        }

        
        public static bool ValidateUser(string username, string pin)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [userdata$] WHERE Username = ? AND Pin = ?", conn);
                cmd.Parameters.AddWithValue("?", username);
                cmd.Parameters.AddWithValue("?", pin);

                OleDbDataReader reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
        }

        
        public static decimal GetBalance(string username)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT Balance FROM [userdata$] WHERE Username = ?", conn);
                cmd.Parameters.AddWithValue("?", username);

                object result = cmd.ExecuteScalar();
                if (result != null && decimal.TryParse(result.ToString(), out decimal balance))
                {
                    return balance;
                }
                else
                {
                    return 0;
                }
            }
        }

       
        public static void UpdateBalance(string username, decimal newBalance)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
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
                OleDbCommand cmd = new OleDbCommand("INSERT INTO [datahistory$] (Username, Record) VALUES (?, ?)", conn);
                cmd.Parameters.AddWithValue("?", username);
                cmd.Parameters.AddWithValue("?", record + " (" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + ")");
                cmd.ExecuteNonQuery();
            }
        }
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
