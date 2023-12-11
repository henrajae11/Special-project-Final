using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AirlineProject;

namespace AirlineProjet
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rajae\OneDrive\Documents\AirlineDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void btnsignup_Click(object sender, EventArgs e)
        {
            string Username = UidTb.Text;
            string UserId = txtuserid.Text;
            string Password = PassTb.Text;

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Username and Password are required!");
                return;
            }

            // Validate username length
            if (Username.Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters long.");
                return;
            }

            // Validate password length
            if (Password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
                return;
            }

            

            try
            {
                Con.Open();
                string query = "insert into Users values('" + UserId + "','" + Username + "','" + Password + "',0)";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Account Created");
                Con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            Con.Close();
        }


        private void button4_Click(object sender, EventArgs e)
        {

            Login log = new Login();
            log.Show();
            this.Hide();
            
        }

        private void lblexit_Click(object sender, EventArgs e)
 
      {

            Application.Exit();
        }
    }
}
