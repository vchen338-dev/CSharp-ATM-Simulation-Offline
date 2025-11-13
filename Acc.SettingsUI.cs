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
        public string username;
        public AccountSettings(string currentUser)
        {
            InitializeComponent();
            username = currentUser;
        }

        private void btnChangePin_Click(object sender, EventArgs e)
        {
            string currentPin = txtCurrentPin.Text.Trim();
            string newPin = txtNewPin.Text.Trim();
            string confirmPin = txtConfirmPin.Text.Trim();

            if(string.IsNullOrWhiteSpace(currentPin) || string.IsNullOrWhiteSpace(newPin) || string.IsNullOrWhiteSpace(confirmPin))
            {
                MessageBox.Show("Please fill all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ExcelDataBase.ValidateUser(username, currentPin))
            {
                MessageBox.Show("Current PIN is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPin != confirmPin)
            {
                MessageBox.Show("New PIN and Confirm PIN do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ExcelDataBase.UpdatePin (username, newPin);

            ExcelDataBase.AddHistory(username, $"PIN changed on {DateTime.Now}");

            MessageBox.Show ("PIN changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenuUI mainMenu = new MainMenuUI(username);
            mainMenu.Show();
            this.Hide();
        }
    }
}
