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
using System.Text.RegularExpressions;
using AirlineProjet;


namespace AirlineProject
{
    public partial class AddPassanger : Form
    {
        private readonly SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rajae\OneDrive\Documents\AirlineDb.mdf;Integrated Security=True;Connect Timeout=30");
        private object UserId;

        public AddPassanger()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Your code here
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Your code here
        }

        private void lblexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string PassengerId = PassId.Text;

            // Check if passenger ID is empty
            if (string.IsNullOrEmpty(PassengerId))
            {
                MessageBox.Show("Passenger ID is Required");
                return;
            }

            // Only allow Numbers!
            if (!Regex.IsMatch(PassengerId, "^[0-9]+$"))
            {
                MessageBox.Show("Only Numbers are Allowed to be entered in this field; it has to be 0-9");
                return;
            }

            if (PassId.Text == "" || PassAd.Text == "" || PassName.Text == "" || PassportTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into PassangerTb values(" + PassId.Text + ",'" + PassName.Text + "','" + PassportTb.Text + "','" + PassAd.Text + "','" + NationalityCb.SelectedItem.ToString() + "','" + GenderCb.SelectedItem.ToString() + "','" + PhoneTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger Recorded Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Con.Close();
                }
            }
        }

        private void AddPasnger_Load(object sender, EventArgs e)
        {
            // Your code here
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PassId.Text = "";
            PassName.Text = "";
            PassportTb.Text = "";
            PassAd.Text = "";
            NationalityCb.SelectedItem = "";
            GenderCb.SelectedItem = "";
            PhoneTb.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewPassanger viewpass = new ViewPassanger();
            viewpass.Show();
            Hide();
        }

        private void PassId_TextChanged(object sender, EventArgs e)
        {
            // Your code here
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            Hide();
        }
    }
}