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
using AirlineProjet;
using System.Text.RegularExpressions;

namespace AirlineProject
{
    public partial class FlightTbl : Form
    {
        public FlightTbl()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rajae\OneDrive\Documents\AirlineDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            if (FcodeTb.Text == "" || Fsrc.Text == "" || FDest.Text == "" || FDate.Text == "" || SeatNum.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                // Validate Flight Code
                if (!Regex.IsMatch(FcodeTb.Text, @"^[A-Z0-9]+$"))
                {
                    MessageBox.Show("Flight Code can only contain capital letters and numbers (0-9).");
                    return;
                }

                try
                {
                    Con.Open();
                    string query = "insert into FlightTbl values('" + FcodeTb.Text + "','" + Fsrc.SelectedItem.ToString() + "','" + FDest.SelectedItem.ToString() + "','" + FDate.Value.ToString() + "','" + SeatNum.Text + "')";

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Flight Recorded Successfully");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    Con.Close();
                }
            }
        }






        private void button2_Click(object sender, EventArgs e)
        {
            FcodeTb.Text = "";
            SeatNum.Text = "";
            Fsrc.Text = "";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewFlights viewflt = new ViewFlights();
            viewflt.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
