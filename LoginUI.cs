using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace ATM_Simulation__Offline_
{
    public partial class LoginUI : Form
    {
        public LoginUI()
        {
            InitializeComponent(); // Load UI components
            timer1.Start(); // Start live clock timer
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            // Clear placeholder text when textbox is focused
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            // Restore placeholder if textbox is empty
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPin_Enter(object sender, EventArgs e)
        {
            // Clear placeholder and mask text when textbox is focused
            if (txtPin.Text == "Pin")
            {
                txtPin.Text = "";
                txtPin.ForeColor = Color.Black;
                txtPin.UseSystemPasswordChar = true;
            }
        }

        private void txtPin_Leave(object sender, EventArgs e)
        {
            // Restore placeholder and unmask if textbox is empty
            if (txtPin.Text == "")
            {
                txtPin.Text = "Pin";
                txtPin.ForeColor = Color.Gray;
                txtPin.UseSystemPasswordChar = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string pin = txtPin.Text;

            // Validate user credentials
            if (ExcelDataBase.ValidateUser(username, pin))
            {
                MessageBox.Show("Login Successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide(); // Hide login form

                // Open Main Menu with current user
                MainMenuUI mainMenu = new MainMenuUI(username);
                mainMenu.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or PIN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Update live clock label
            Livetime.Text = DateTime.Now.ToString("dddd, hh:mm:ss tt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Open registration form
            this.Hide();
            RegistrationUI regform = new RegistrationUI();
            regform.ShowDialog();
        }
    }
}

// Final for Login UI 15/11/2025 (Venz Jochen Galera)
