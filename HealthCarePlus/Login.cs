using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCarePlus
{
    public partial class Login : Form
    {
        public Login()
        {

            InitializeComponent();
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        }


        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ResetLbl_Click(object sender, EventArgs e)
        {
            RoleCb.SelectedIndex =-1;
            UserNameTb.Text = "";
            PassTb.Text = "";
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\HealthCarePlusDb.mdf;Integrated Security=True;Connect Timeout=30");

        public static string Role;

        private void LoginBtn_Click(object sender, EventArgs e)
        {
           if(RoleCb.SelectedIndex == -1)
            {
                MessageBox.Show("Select Your Postion");
            }else if (RoleCb.SelectedIndex == 0)
            {
                if (UserNameTb .Text == "" || PassTb.Text == "")
                {
                    MessageBox.Show("Enter Both Admin Name and Password");
                }else if (UserNameTb.Text == "A" && PassTb.Text == "1")
                {
                    Role = "Admin";
                    Homes obj = new Homes();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Admin Name and password");
                }
            }else if (RoleCb.SelectedIndex == 1)
            {
                if (UserNameTb.Text == "" || PassTb.Text == "")
                {
                    MessageBox.Show("Enter Both Doctor Name and Password");
                }
                else /*if (UserNameTb.Text == "Admin" && PassTb.Text == "Password")  */
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM DoctorTbl WHERE DocName='" + UserNameTb.Text + "' AND DocPass ='" + PassTb.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Role = "Doctor";
                        Prescriptions obj = new Prescriptions();
                        obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Doctor Not Found");
                    }
                    con.Close();
                }
            }
            else
            {
                if (UserNameTb.Text == "" || PassTb.Text == "")
                {
                    MessageBox.Show("Enter Both Receptionist Name and Password");
                }
                else
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM ReceptionistTbl WHERE Name='" + UserNameTb.Text + "' AND Password ='" + PassTb.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Role = "Receptionist";
                        Homes obj = new Homes();
                        obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Receptionist Not Found");
                    }
                    con.Close();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            // If user clicks "No", the application will continue running
        }

        private void RoleCb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cancel the key press event to prevent typing in the middle of the ComboBox
            e.Handled = true;
        }


        // Toggle password visibility
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                PassTb.PasswordChar = '\0'; // Show characters
                checkBox1.Text = "Hide";
            }
            else
            {
                PassTb.PasswordChar = '*'; // Hide characters
                checkBox1.Text = "Show";
            }
        }

        private void UserNameTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Move the focus to the password TextBox when Enter is pressed
                PassTb.Focus();

                // Suppress the default sound
                e.SuppressKeyPress = true;
            }
        }

        private void PassTb_KeyDown(object sender, KeyEventArgs e)
        {

            
        }
    }
}
