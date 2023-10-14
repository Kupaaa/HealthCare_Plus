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
    public partial class Homes : Form
    {
        public Homes()
        {
            InitializeComponent();


            //Check if the user's role is "Receptionist"
            if (Login.Role == "Receptionist")
            {
                if (Login.Role == "Receptionist")
                {
                    // Disable access to specific sections for a Receptionist role
                    RecepLbl.Enabled = false;   // Receptionists section
                    DoctorLbl.Enabled = false;  // Doctors section
                    LabLab.Enabled = false;     // Lab Tests section
                    NurseLbl.Enabled = false;
                    RoomsLbl.Enabled = false;
                    //AppLbl.Enabled = false;
                }


            }


            CountPatients();
            CountDoctors();
            CountTest();
            CountHiV();
            CountNurse();
            CountRooms();
        }


        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\HealthCarePlusDb.mdf;Integrated Security=True;Connect Timeout=30");

        //count Patients
        private void CountPatients()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count (*) From PatientTbl", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            PatNumLbl.Text = dt.Rows[0][0].ToString();
            con.Close();

        }

        //count Doctors
        private void CountDoctors()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count (*) From DoctorTbl", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DocNumLbl.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        //count Test
        private void CountTest()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count (*) From TestTbl", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            LAbTestLbl.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        //count HIV Patients
        private void CountHiV()
        {
            String Status = "Positive";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count (*) From PatientTbl Where PatHiv ='" + Status + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            HiVLbl.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {

            // Confirm application exit with the user
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Exit the application
                Application.Exit();
            }

        }

        // Click event handler for the "Patients" label
        private void Patlbl_Click(object sender, EventArgs e)
        {
            Patients obj = new Patients();
            obj.Show();
            this.Hide();
        }

        // Click event handler for the "Doctors" label
        private void DoctorLbl_Click(object sender, EventArgs e)
        {
            Doctors obj = new Doctors();
            obj.Show();
            this.Hide();

        }



        // Click event handler for the "Logout" label
        private void LogOutLbl_Click(object sender, EventArgs e)
        {
            // Create an instance of the Login form
            Login obj = new Login();

            // Show the Login form
            obj.Show();

            // Hide the current form
            this.Hide();
        }


        // Click event handler for label5 (seems to be the same as the Logout label)
        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Create an instance of the Login form
                Login obj1 = new Login();

                // Show the Login form
                obj1.Show();

                // Hide the current form
                this.Hide();
            }
        }

        private void LabLab_Click_1(object sender, EventArgs e)
        {
            LabTests obj = new LabTests();
            obj.Show();
            this.Hide();
        }

        private void NurseNumLbl_Click(object sender, EventArgs e)
        {

        }

        private void CountNurse()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count (*) From NurseTbl", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            NurseNumLbl.Text = dt.Rows[0][0].ToString();
            con.Close();

        }

        private void CountRooms()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count (*) From RoomTbl", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            RoomNumLbl.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void HiVLbl_Click(object sender, EventArgs e)
        {

        }

        private void NurseLbl_Click(object sender, EventArgs e)
        {
            Nurse obj = new Nurse();
            obj.Show();
            this.Hide();
        }

        private void DoctorBtn_Click(object sender, EventArgs e)
        {

        }

        private void RecepLbl_Click_1(object sender, EventArgs e)
        {
            Receptionists obj = new Receptionists();
            obj.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void RoomNumLbl_Click(object sender, EventArgs e)
        {

        }

        private void RoomsLbl_Click(object sender, EventArgs e)
        {
            Rooms obj = new Rooms();
            obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Homes_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Appointment obj = new Appointment();
            obj.Show();
            this.Hide();
        }
    }
}

