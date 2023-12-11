using AirlineProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineProjet
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           FlightTbl flight = new FlightTbl();
            flight.Show();
            this.Hide();
        }

        private void btnpassa_Click(object sender, EventArgs e)
        {
            AddPassanger pass = new AddPassanger();
            pass.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
             Ticket tick = new Ticket();
              tick.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CancellationTbl cancellation = new CancellationTbl();
            cancellation.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Login log = new Login();
            log .Show();
            this.Hide();
            
        }
    }
}
