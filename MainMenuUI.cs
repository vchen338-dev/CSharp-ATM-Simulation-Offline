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
        public MainMenuUI()
        {
            InitializeComponent();
            timer1.Start();
            

        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "Welcome ";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LivetimeMAinForm.Text = DateTime.Now.ToString("dddd, hh:mm:ss tt");
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome " ;
        }

        private void LivetimeMAinForm_Click(object sender, EventArgs e)
        {

        }
    }
}
