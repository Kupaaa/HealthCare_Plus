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

namespace HealthCarePlus
{
    public partial class AdminDash : Form
    {
        public AdminDash()
        {

        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\HealthCarePlusDb.mdf;Integrated Security=True;Connect Timeout=30");

        //count Patients



        private void AdminDash_Load(object sender, EventArgs e)
        {
            // Start the timer when the AdminDash form loads
            timer1.Start();
        }



        private void timer1_Tick_1(object sender, EventArgs e)
        {
            progressBar1.Increment(5);
            if (progressBar1.Value == 100 ) 
                timer1.Stop();
        }
    }
}
