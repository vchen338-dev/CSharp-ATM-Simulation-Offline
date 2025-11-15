using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ATM_Simulation__Offline_
{
    public partial class TransferUI : Form
    {
        // Stores currently logged-in user
        private string username;

        public TransferUI(string currentUser)
        {
            InitializeComponent();      // Load UI components
            username = currentUser;     // Save logged-in username
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            // Get inputs
            string recipient = txtRecipient.Text.Trim();
            string pin = txtPin.Text.Trim();
            string amountText = txtAmount.Text.Trim();

            // Check if any field is empty
            if (string.IsNullOrWhiteSpace(recipient) || string.IsNullOrWhiteSpace(pin) || string.IsNullOrWhiteSpace(amountText))
            {
                MessageBox.Show("Please fill all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate number amount
            if (!decimal.TryParse(amountText, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid amount.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if PIN matches current user
            if (!ExcelDataBase.ValidateUser(username, pin))
            {
                MessageBox.Show("Invalid PIN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Prevent transferring to self
            if (recipient.Equals(username, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("You cannot transfer to yourself.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if recipient exists
            if (!ExcelDataBase.UserExists(recipient))
            {
                MessageBox.Show("Recipient does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get sender + recipient balances
            decimal senderBalance = ExcelDataBase.GetBalance(username);
            decimal recipientBalance = ExcelDataBase.GetBalance(recipient);

            // Check if sender has enough money
            if (senderBalance < amount)
            {
                MessageBox.Show("Insufficient balance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Deduct from sender, add to recipient
            ExcelDataBase.UpdateBalance(username, senderBalance - amount);
            ExcelDataBase.UpdateBalance(recipient, recipientBalance + amount);

            // Add history logs
            ExcelDataBase.AddHistory(username, "- Sent " + amount.ToString("C") + " to " + recipient);
            ExcelDataBase.AddHistory(recipient, "+ Received " + amount.ToString("C") + " from " + username);

            MessageBox.Show("Transfer successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset fields
            txtRecipient.Text = "";
            txtPin.Text = "";
            txtAmount.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Go back to Main Menu
            MainMenuUI mainMenu = new MainMenuUI(username);
            mainMenu.Show();
            this.Hide();
        }
    }
}

// Final for Transfer UI 15/11/2025 (Venz Jochen Galera)
