using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Simulation__Offline_
{
    public partial class AccountSettings : Form
    {
        // Stores the current logged-in user's username
        public string username;

        public AccountSettings(string currentUser)
        {
            InitializeComponent(); // Load UI components
            username = currentUser; // Save logged-in username
        }

        private void btnChangePin_Click(object sender, EventArgs e)
        {
            // Get PIN inputs
            string currentPin = txtCurrentPin.Text.Trim();
            string newPin = txtNewPin.Text.Trim();
            string confirmPin = txtConfirmPin.Text.Trim();

            // Check if any field is empty
            if (string.IsNullOrWhiteSpace(currentPin) || string.IsNullOrWhiteSpace(newPin) || string.IsNullOrWhiteSpace(confirmPin))
            {
                MessageBox.Show("Please fill all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate current PIN
            if (!ExcelDataBase.ValidateUser(username, currentPin))
            {
                MessageBox.Show("Current PIN is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if new PIN matches confirm PIN
            if (newPin != confirmPin)
            {
                MessageBox.Show("New PIN and Confirm PIN do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update PIN in database
            ExcelDataBase.UpdatePin(username, newPin);

            // Add change to history
            ExcelDataBase.AddHistory(username, "PIN changed on " + DateTime.Now);

            MessageBox.Show("PIN changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Return to Main Menu
            MainMenuUI mainMenu = new MainMenuUI(username);
            mainMenu.Show();
            this.Hide();
        }
    }
}

// Final for Account Settings UI 15/11/2025 (Venz Jochen Galera)
