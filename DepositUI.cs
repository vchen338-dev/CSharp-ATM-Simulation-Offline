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
        public DepositUI()
        {
            InitializeComponent();
        }

        private string username;
        private string excelPath = @"C:\Git Repos\bin\Debug\DataBase.xlsx";

        public DepositUI(string currentUser)
        {
            InitializeComponent();
            username = currentUser;
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if(decimal.TryParse(txtAmount.Text, out decimal depositAmount) && depositAmount > 0)
            {
             string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelPath + ";Extended Properties='Excel 12.0 Xml;HDR=YES;';";
                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    conn.Open();

                    OleDbCommand cmd = new OleDbCommand("SELECT Balance FROM [userdata$] WHERE Username = ?", conn);
                    cmd.Parameters.AddWithValue("?", username);
                    object result = cmd.ExecuteScalar();

                    if (result != null && decimal.TryParse(result.ToString(), out decimal currentBalance))
                    {
                        decimal newBalance = currentBalance + depositAmount;
                        OleDbCommand updateCmd = new OleDbCommand("UPDATE [userdata$] SET Balance = ? WHERE Username = ?", conn);
                        updateCmd.Parameters.AddWithValue("?", newBalance);
                        updateCmd.Parameters.AddWithValue("?", username);
                        updateCmd.ExecuteNonQuery();

                        string historyText = $"+ Deposited {depositAmount} Pesos ({DateTime.Now})";
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
                MessageBox.Show("Please enter a valid amount.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenuUI mainMenu = new MainMenuUI(username);
            mainMenu.Show();
            this.Close();
        }
    }
}
