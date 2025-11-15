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
    public partial class MainMenuUI : Form
    {
        // Stores the username of the currently logged-in user
        private string currentUser;

        public MainMenuUI(string username)
        {
            InitializeComponent();   // Initialize UI components
            timer1.Start();          // Start the live time display timer
            currentUser = username;  // Save logged-in username
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Updates the welcome label when clicked
            label1.Text = "Welcome " + currentUser + "!";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Updates the current time every second
            LivetimeMAinForm.Text = DateTime.Now.ToString("dddd, hh:mm:ss tt");
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            // Set welcome message on form load
            label1.Text = "Welcome " + currentUser + "!";
        }

        private void LivetimeMAinForm_Click(object sender, EventArgs e)
        {
            // No action when clicking the live time label
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Open Balance UI and hide current form
            BalanceUI balanceUI = new BalanceUI(currentUser);
            balanceUI.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Log out and return to Login UI
            LoginUI lgout = new LoginUI();
            lgout.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open Deposit UI and hide current form
            DepositUI depositUI = new DepositUI(currentUser);
            depositUI.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Open Transfer UI and hide current form
            TransferUI transferUI = new TransferUI(currentUser);
            transferUI.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Open Withdraw UI and hide current form
            WithdrawUI witdrawUI = new WithdrawUI(currentUser);
            witdrawUI.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Open Account Settings UI and hide current form
            AccountSettings accset = new AccountSettings(currentUser);
            accset.Show();
            this.Hide();
        }
    }
}

// Final for MainMenu UI 15/11/2025 (Venz Jochen Galera)
