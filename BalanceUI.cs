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
using System.Runtime.CompilerServices;

namespace ATM_Simulation__Offline_
{
    public partial class BalanceUI : Form
    {
        // Stores the current logged-in user's username
        private string username;

        public BalanceUI(string currentUser)
        {
            InitializeComponent(); // Load UI components
            username = currentUser; // Save logged-in username
        }

        private void BalanceUI_Load(object sender, EventArgs e)
        {
            // Display welcome message
            lblUser.Text = "Welcome, " + username + "!";

            // Path to Excel database (update if cloned/pulled repo)
            string path = @"C:\Git Repos\bin\Debug\DataBase.xlsx";
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path +
                             ";Extended Properties='Excel 12.0 Xml;HDR=YES;'";

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                // Fetch current balance
                using (OleDbCommand cmd = new OleDbCommand("SELECT Balance FROM [userdata$] WHERE Username = ?", conn))
                {
                    cmd.Parameters.AddWithValue("?", username);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblBalance.Text = "Current Balance: ₱" + reader["Balance"].ToString();
                    }
                    else
                    {
                        lblBalance.Text = "Balance not found!";
                    }
                    reader.Close();
                }

                // Fetch transaction history
                using (OleDbCommand historyCmd = new OleDbCommand("SELECT Record FROM [datahistory$] WHERE Username = ?", conn))
                {
                    historyCmd.Parameters.AddWithValue("?", username);
                    OleDbDataReader historyReader = historyCmd.ExecuteReader();

                    txtHistoryrec.Clear(); // Clear existing text
                    while (historyReader.Read())
                    {
                        // Append each record to the multiline textbox
                        txtHistoryrec.AppendText(historyReader["Record"].ToString() + Environment.NewLine);
                    }
                    historyReader.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Go back to Main Menu
            MainMenuUI back = new MainMenuUI(username);
            back.Show();
            this.Hide();
        }
    }
}

// Final for Balance UI 15/11/2025 (Venz Jochen Galera)

