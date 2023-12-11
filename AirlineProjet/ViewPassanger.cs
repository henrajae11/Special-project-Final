using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace AirlineProject
{
    public partial class ViewPassanger : Form
    {
        public ViewPassanger()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rajae\OneDrive\Documents\AirlineDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "SELECT * FROM PassangerTb";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PassangerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
  
        private void Vi_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddPassanger addpas = new AddPassanger();
            addpas.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(PidTb.Text == "")
            {
                MessageBox.Show("Enter The Passenger to Delete");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from PassangerTb where PassId=" + PidTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger Deleted Successfully");
                    Con.Close();
                    populate();
                }catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);    
                }
            }
        }

        private void PassangerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // When a cell within the DataGridView is clicked, this code is executed, and it appears to be populating various TextBoxes
            // and ComboBoxes with data from the selected row of the DataGridView.
              
            if (e.RowIndex >= 0) // Check if a valid row is clicked
            {
                DataGridViewRow selectedRow = PassangerDGV.Rows[e.RowIndex];

                PidTb.Text = selectedRow.Cells[0].Value.ToString();
                PnameTb.Text = selectedRow.Cells[1].Value.ToString();
                PpassTb.Text = selectedRow.Cells[2].Value.ToString();
                PaddTb.Text = selectedRow.Cells[3].Value.ToString();
                natcb.SelectedItem = selectedRow.Cells[4].Value.ToString();
                GendCb.SelectedItem = selectedRow.Cells[5].Value.ToString();
            }
        }
        //ISSUE I CAN ONLY SELECT ROW ONE WHY
        private void button3_Click(object sender, EventArgs e)
        {
            PidTb.Text = "";
            PnameTb.Text = "";
            PpassTb.Text = "";
            PaddTb.Text = "";
            natcb.SelectedItem = "";
            GendCb.SelectedItem = "";


                
        }
// this is the part that i have problems with 
        private void button1_Click(object sender, EventArgs e)
        {

            string PassangerID = PidTb.Text; 

            if (PidTb.Text == "" || PnameTb.Text == "" || PpassTb.Text == "" || PaddTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                 // UPDATE NEED TO BE FOR ALL THE FIELDS 
                    string query = "UPDATE PassangerTb SET PassName = '" + PnameTb.Text + "', Passport = '" + PpassTb.Text + "' WHERE PassId = '" + PassangerID + "'";


                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger updates Successfully");
                    Con.Close();
                    populate();

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
