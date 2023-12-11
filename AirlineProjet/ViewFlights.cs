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

namespace AirlineProject
{
    public partial class ViewFlights : Form
    {
        public ViewFlights()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rajae\OneDrive\Documents\AirlineDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "SELECT * FROM FlightTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            FlightDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void ViewFlights_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Fcode.Text) || string.IsNullOrEmpty(Seatnum.Text) || SrcCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    // UPDATE NEEDS TO BE FOR ALL THE FIELDS 
                    string query = "UPDATE FlightTbl SET Fsrc = '" + SrcCb.SelectedItem.ToString() + "', FDest = '" + DstCb.SelectedItem.ToString() + "', FDate = '" + FDate1.Value.Date.ToString("yyyy-MM-dd") + "', FCap = " + Seatnum.Text + " WHERE Fcode = '" + Fcode.Text + "'";

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Flight updated Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }
        // DELETE NEED TO BE FIXED
        private void button2_Click(object sender, EventArgs e)
        {
            if (Fcode.Text == "")
            {
                MessageBox.Show("Enter The Flight to Delete");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Delete From FlightTbl Where Fcode ='" + Fcode.Text + "';";
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
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fcode.Text = "";
            Seatnum.Text="";
            SrcCb.SelectedItem.ToString();
            DstCb.SelectedItem.ToString();
            FDate1.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FlightTbl Addf1 = new FlightTbl();
            Addf1.Show();
            this.Hide();
        }

        private void FlightDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Fcode.Text = FlightDGV.SelectedRows[0].Cells[0].Value.ToString();
            //SrcCb.Text = FlightDGV.SelectedRows[0].Cells[1].Value.ToString();
            //DstCb.Text = FlightDGV.SelectedRows[0].Cells[2].Value.ToString();
            //Seatnum.Text = FlightDGV.SelectedRows[0].Cells[4].Value.ToString();





            if (e.RowIndex >= 0) // Check if a valid row is clicked
            {
                DataGridViewRow selectedRow = FlightDGV.Rows[e.RowIndex];

                Fcode.Text = selectedRow.Cells[0].Value.ToString();
                SrcCb.SelectedItem = selectedRow.Cells[1].Value.ToString();
                DstCb.SelectedItem = selectedRow.Cells[2].Value.ToString();
                FDate1.Text = selectedRow.Cells[3].Value.ToString();
                Seatnum.Text = selectedRow.Cells[4].Value.ToString();

            }
        }
    }
}
