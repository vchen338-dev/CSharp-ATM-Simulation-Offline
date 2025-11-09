using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.CompilerServices;

namespace ATM_Simulation__Offline_
{
    public partial class BalanceUI : Form
    {
        private string username;
        public BalanceUI(string currentUser)
        {
            InitializeComponent();
            username = currentUser;
        }

      private void BalanceUI_Load(object sender, EventArgs e)
        {
            lblUser.Text = "Welcome, " + username + "!";

            string path = @"C:\Git Repos\bin\Debug\DataBase.xlsx";
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0 Xml;HDR=YES;';";

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [userdata$] WHERE Username = ?", conn);
                cmd.Parameters.AddWithValue("?", username);

                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblBalance.Text = "Current Balance: " + "₱" + reader["Balance"].ToString();
                }
                else
                {
                    lblBalance.Text = "Balance not found!";
                }

                reader.Close();
            }
        }

        private void txtHistory_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

