using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ATM_Simulation__Offline_
{
    public partial class TransferUI : Form
    {
        private string username;

        public TransferUI(string currentUser)
        {
            InitializeComponent();
            username = currentUser;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            string recipient = txtRecipient.Text.Trim();
            string pin = txtPin.Text.Trim();
            string amountText = txtAmount.Text.Trim();

          
            if (string.IsNullOrWhiteSpace(recipient) || string.IsNullOrWhiteSpace(pin) || string.IsNullOrWhiteSpace(amountText))
            {
                MessageBox.Show("Please fill all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (!decimal.TryParse(amountText, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid amount.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            if (!ExcelDataBase.ValidateUser(username, pin))
            {
                MessageBox.Show("Invalid PIN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

          
            if (recipient.Equals(username, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("You cannot transfer to yourself.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (!ExcelDataBase.UserExists(recipient))
            {
                MessageBox.Show("Recipient does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            decimal senderBalance = ExcelDataBase.GetBalance(username);
            decimal recipientBalance = ExcelDataBase.GetBalance(recipient);

            if (senderBalance < amount)
            {
                MessageBox.Show("Insufficient balance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            ExcelDataBase.UpdateBalance(username, senderBalance - amount);
            ExcelDataBase.UpdateBalance(recipient, recipientBalance + amount);

         
            ExcelDataBase.AddHistory(username, "- Sent " + amount.ToString("C") + " to " + recipient);
            ExcelDataBase.AddHistory(recipient, "+ Received " + amount.ToString("C") + " from " + username);

            MessageBox.Show("Transfer successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtRecipient.Text = "";
            txtPin.Text = "";
            txtAmount.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenuUI mainMenu = new MainMenuUI(username);
            mainMenu.Show();
            this.Hide();
        }
    }
}