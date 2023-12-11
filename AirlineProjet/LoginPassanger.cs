using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineProjet
{
    public partial class LoginPassanger : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rajae\OneDrive\Documents\AirlineDb.mdf;Integrated Security=True;Connect Timeout=30");

        public LoginPassanger()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
{

    try
    {
        Con.Open();
        var passportNumber = tbPassportNumber.Text;

        // Check if passport number is empty
        if (string.IsNullOrEmpty(passportNumber))
        {
            MessageBox.Show("Please enter a passport number.");
            return; // Exit the method if the passport number is empty
        }

        var query = "SELECT ticket.Tid, ticket.Fcode, ticket.Pid, ticket.PName, ticket.PPass, " +
            "ticket.PNatation, ticket.Amt,ft.Fsrc, ft.FDest, ft.FDate, ft.FCap " +
            "FROM TicketTbl ticket Inner Join FlightTbl ft on ticket.Fcode = ft.Fcode where ticket.PPass = @passportNumber ";
        SqlCommand cmd = new SqlCommand(query, Con);
        cmd.Parameters.AddWithValue("@passportNumber", passportNumber);

        DataTable dataTable = new DataTable();
        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                dataAdapter.Fill(dataTable);
                //LoginGd.Columns["Ticket Id"].HeaderText = "Ticket Id";

                if (dataTable.Rows.Count > 0)
        {
            // Passport number exists
            LoginGd.DataSource = dataTable;
            MessageBox.Show("Passport number exists.");
        }
        else
        {
            // Passport number does not exist
            MessageBox.Show("Passport number does not exist.");
        }
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


        private void button1_Click(object sender, EventArgs e)
        {
            tbPassportNumber.Text = "";
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Customer_or_Admin customer_Or_Admin = new Customer_or_Admin();
            customer_Or_Admin.Show();
            this.Hide();
        }

        private void LoginGd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoginGd.Columns["Ticket Id"].HeaderText = "Ticket Id";

        }
    }
}
