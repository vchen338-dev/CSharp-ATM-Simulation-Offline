using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ATM_Simulation__Offline_
{


    public partial class LoginUI : Form
    {
        public LoginUI()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPin_Enter(object sender, EventArgs e)
        {
            if (txtPin.Text == "Pin")
            {
                txtPin.Text = "";
                txtPin.ForeColor = Color.Black;
                txtPin.UseSystemPasswordChar = true;
            }
        }

        private void txtPin_Leave(object sender, EventArgs e)
        {
            if (txtPin.Text == "")
            {
                txtPin.Text = "Pin";
                txtPin.ForeColor = Color.Gray;
                txtPin.UseSystemPasswordChar = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == BankData.Name && txtPin.Text == BankData.Pin)
            {
                MessageBox.Show("Login Successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

                MainMenuUI mainMenu = new MainMenuUI();
                mainMenu.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or PIN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Livetime.Text = DateTime.Now.ToString("dddd, hh:mm:ss tt");
        }
    }
}