using AirlineProjet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rajae\OneDrive\Documents\AirlineDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void lblexit_Click(object sender, EventArgs e)
        {
            Application .Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UidTb.Text = "";
            PassTb.Text = "";
        }
        private void Log()
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (UidTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Enter a Username and a Password to continue");
            }
            else if (UidTb.Text == "Admin" && PassTb.Text == "Password")
            {
                Home home = new Home();
                home.Show();
                this.Hide();
            }
            else
            {
                try
                {
                    // Use parameterized query to prevent SQL injection
                    Con.Open();
                    string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@Username", UidTb.Text);
                    cmd.Parameters.AddWithValue("@Password", PassTb.Text);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // User authenticated successfully
                        MessageBox.Show("Login successful!");
                        Home home = new Home();
                        home.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Invalid username or password
                        MessageBox.Show("Wrong Username and Password. Please try again");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    Con.Close();
                }
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Customer_or_Admin log = new Customer_or_Admin();
            log.Show();
            this.Hide();
        }

        private void UidTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void PassTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Show();

          
        }
    }
}
