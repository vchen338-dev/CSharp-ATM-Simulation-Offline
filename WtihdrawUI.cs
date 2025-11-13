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
    { private string username;
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=atmdb.accdb");

        public WithdrawUI(string currentUser)
        {
            InitializeComponent();
            username = currentUser;

        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
           string pin = txtPin.Text;
            string amountText = txtAmount.Text;
            if (string.IsNullOrWhiteSpace(pin) || string.IsNullOrWhiteSpace(amountText))
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
            decimal currentBalance = ExcelDataBase.GetBalance(username);
            if (currentBalance < amount)
            {
                MessageBox.Show("Insufficient funds.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            decimal newBalance = currentBalance - amount;
            ExcelDataBase.UpdateBalance(username, newBalance);
            ExcelDataBase.AddHistory(username, "- Withdraw ₱" + amount.ToString("N2"));

            MessageBox.Show("Withdrawal successful! New Balance: ₱" + newBalance.ToString("N2"), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenuUI mainMenu = new MainMenuUI(username);
            mainMenu.Show();
            this.Hide();
        }
    }
}