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
        private string currentUser;

        public MainMenuUI(string username)
        {
            InitializeComponent();
            timer1.Start();
            currentUser = username;
        }
   


        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "Welcome " + currentUser + "!";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LivetimeMAinForm.Text = DateTime.Now.ToString("dddd, hh:mm:ss tt");
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome " + currentUser + "!";
        }

        private void LivetimeMAinForm_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            BalanceUI balanceUI = new BalanceUI(currentUser);  
            balanceUI.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoginUI lgout = new LoginUI();
            lgout.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DepositUI depositUI = new DepositUI(currentUser);
            depositUI.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TransferUI transferUI = new TransferUI(currentUser);
            transferUI.Show();
            this.Hide();
        }
    }
}//latest
