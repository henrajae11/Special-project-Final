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
using System.Security.Cryptography;
using AirlineProjet;

namespace AirlineProject
{
    public partial class CancellationTbl : Form
    {
        public CancellationTbl()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rajae\OneDrive\Documents\AirlineDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            string query = "SELECT * FROM CancelTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CancelDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void fillTicketId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Tid from TicketTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Tid", typeof(string));
            dt.Load(rdr);
            TidCb.ValueMember = "Tid";
            TidCb.DataSource = dt;
            Con.Close();
        }

        private void fetchfcode()
        {
            Con.Open();
            string query = "SELECT * FROM TicketTbl WHERE Tid= " + TidCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                FcodeTb.Text = dr["Fcode"].ToString();

            }
            Con.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void TicketDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CancellationTbl_Load(object sender, EventArgs e)
        {
            fillTicketId();
            populate();

        }

        private void TidCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchfcode();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CanId.Text = "";
            FcodeTb.Text = "";
        }
        private void deleteTicket()
        {
           
                try
                {
                    Con.Open();
                    string query = "Delete From TicketTbl Where Tid ='" + TidCb.SelectedValue.ToString() + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Flight Deleted Successfully");

                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            Con.Close();
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (CanId.Text == "" || FcodeTb.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    try
                    {
                        Con.Open();
                        string query = $"INSERT INTO CancelTbl VALUES ('{CanId.Text}', '{TidCb.SelectedValue}', '{FcodeTb.Text}', '{CancDate.Value.Date}')";

                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        Con.Close();
                        MessageBox.Show("Ticket Cancelled Successfully");
                        
                        populate();
                        deleteTicket();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Con.Close();
                }
                Con.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Customer_or_Admin customer = new Customer_or_Admin();
            customer.Show();
            this.Hide();
            
            
            FlightTbl flight = new FlightTbl();
            flight.Show();
            this.Hide();
        }
    }
}
