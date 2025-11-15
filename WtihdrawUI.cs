using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Simulation__Offline_
{

    public partial class WithdrawUI : Form
    {
        private string username; // Stores the current logged-in user's username

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=atmdb.accdb");
        // Connection to Access Database (not directly used here but available)

        public WithdrawUI(string currentUser)
        {
            InitializeComponent();
            username = currentUser; // Save the logged-in user for later balance checks
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            string pin = txtPin.Text; // Get PIN input
            string amountText = txtAmount.Text; // Get amount input

            // Check if fields are empty
            if (string.IsNullOrWhiteSpace(pin) || string.IsNullOrWhiteSpace(amountText))
            {
                MessageBox.Show("Please fill all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate amount if it's a number and greater than 0
            if (!decimal.TryParse(amountText, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid amount.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate PIN using ExcelDataBase helper
            if (!ExcelDataBase.ValidateUser(username, pin))
            {
                MessageBox.Show("Invalid PIN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get current balance of the user
            decimal currentBalance = ExcelDataBase.GetBalance(username);

            // Check if user has enough money to withdraw
            if (currentBalance < amount)
            {
                MessageBox.Show("Insufficient funds.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Compute updated balance
            decimal newBalance = currentBalance - amount;

            // Store new balance back to the database
            ExcelDataBase.UpdateBalance(username, newBalance);

            // Log the withdrawal in transaction history
            ExcelDataBase.AddHistory(username, "- Withdraw ₱" + amount.ToString("N2"));

            // Notify user
            MessageBox.Show("Withdrawal successful! New Balance: ₱" + newBalance.ToString("N2"), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenuUI mainMenu = new MainMenuUI(username); // Return to main menu
            mainMenu.Show();
            this.Hide(); // Hide current window
        }
    }
}

// Final for MainMenu UI 15/11/2025 (Venz Jochen Galera)
