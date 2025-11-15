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
    public partial class RegistrationUI : Form
    {
        public RegistrationUI()
        {
            InitializeComponent();  // Load all UI components
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the username and PIN from textboxes
            string username = txtUsername.Text;
            string pin = txtPin.Text;

            // Basic validation to prevent empty registration fields
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(pin))
            {
                MessageBox.Show("Please enter both username and pin.");
                return; // Stop registration
            }

            // Save new user data to Excel database
            ExcelDataBase.RegisterUser(username, pin);

            // Notify the user of successful registration
            MessageBox.Show("Registration Successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Go back to Login UI
            LoginUI loginform = new LoginUI();
            loginform.Show();
            this.Hide();  // Hide registration form
        }
    }
}

// Final for Registration UI 15/11/2025 (Venz Jochen Galera)
