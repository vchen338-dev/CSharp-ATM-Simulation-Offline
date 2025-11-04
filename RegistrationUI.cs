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
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string pin = txtPin.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(pin))
            {
                MessageBox.Show("Please enter both username and pin.");
                return;
            }
            ExcelDataBase.RegisterUser(username, pin);
            MessageBox.Show("Registration Successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            LoginUI loginform = new LoginUI();
            loginform.Show();
            this.Hide();
        }
    }
}
