using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ATM_Simulation__Offline_
{
    public partial class DepositUI : Form
    {
        // Stores the current logged-in username
        private string username;

        // Path to the Excel database file (update if cloning/pulling repo)
        private string excelPath = @"C:\Git Repos\bin\Debug\DataBase.xlsx";

        public DepositUI()
        {
            InitializeComponent(); // Load UI components
        }

        public DepositUI(string currentUser)
        {
            InitializeComponent();
            username = currentUser; // Save logged-in username
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            // Check if the deposit amount is valid
            if (decimal.TryParse(txtAmount.Text, out decimal depositAmount) && depositAmount > 0)
            {
                // Connection string for Excel database
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelPath + ";Extended Properties='Excel 12.0 Xml;HDR=YES;';";

                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    conn.Open();

                    // Get current balance of the user
                    OleDbCommand cmd = new OleDbCommand("SELECT Balance FROM [userdata$] WHERE Username = ?", conn);
                    cmd.Parameters.AddWithValue("?", username);
                    object result = cmd.ExecuteScalar();

                    if (result != null && decimal.TryParse(result.ToString(), out decimal currentBalance))
                    {
                        // Update balance
                        decimal newBalance = currentBalance + depositAmount;
                        OleDbCommand updateCmd = new OleDbCommand("UPDATE [userdata$] SET Balance = ? WHERE Username = ?", conn);
                        updateCmd.Parameters.AddWithValue("?", newBalance);
                        updateCmd.Parameters.AddWithValue("?", username);
                        updateCmd.ExecuteNonQuery();

                        // Add deposit record to history
                        string historyText = "+ Deposited " + depositAmount + " Pesos (" + DateTime.Now + ")";
                        OleDbCommand historyCmd = new OleDbCommand("INSERT INTO [datahistory$] (Username, Record) VALUES (?, ?)", conn);
                        historyCmd.Parameters.AddWithValue("?", username);
                        historyCmd.Parameters.AddWithValue("?", historyText);
                        historyCmd.ExecuteNonQuery();

                        MessageBox.Show("Deposit Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("User not found!");
                    }
                }
            }
            else
            {
                // Notify invalid amount input
                MessageBox.Show("Please enter a valid amount.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Return to Main Menu
            MainMenuUI mainMenu = new MainMenuUI(username);
            mainMenu.Show();
            this.Close(); // Close deposit window
        }
    }
}

// Final for Deposit UI 15/11/2025 (Venz Jochen Galera)
