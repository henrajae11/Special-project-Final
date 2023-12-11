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
    public partial class Customer_or_Admin : Form
    {
        public Customer_or_Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginPassanger loginPassanger = new LoginPassanger();
            loginPassanger.Show();
            this.Dispose();
           
        }
    }
}
