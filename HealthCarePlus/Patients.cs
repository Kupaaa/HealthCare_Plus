using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCarePlus
{
    public partial class Patients : Form
    {
        public Patients()
        {
            InitializeComponent();
            DisplayPat();


            if (Login.Role == "Receptionist")
            {
                // Disable access to specific sections for a Receptionist role
                RepLbl.Enabled = false;   // Receptionists section
                DocLb.Enabled = false;    // Doctors section
                LabLbl.Enabled = false;   // Lab Tests section
                NurseLbl.Enabled = false;
                //PatLbl.Enabled = false;
                PrescriptionLbl.Enabled = false;

                // Additional logic specific to the Receptionist role here
            }
            else if (Login.Role == "Doctor")
            {
                
                // Additional logic specific to the Doctor role here
                RepLbl.Enabled = false;   // Receptionists section
                RepLbl.ForeColor = Color.Red;
                DocLb.Enabled = false;    // Doctors section
                LabLbl.Enabled = false;   // Lab Tests section
                NurseLbl.Enabled = false;
                HomeLbl.Enabled = false;
                PatLbl.Enabled = false;
                DelBtn.Visible = false;
                AddBtn.Visible = false;
                EditBtn.Visible = false;
                ClearBtn.Visible = false;
            }
            else if (Login.Role == "Admin")
            {
                RepLbl.Enabled = false;   // Receptionists section
                DocLb.Enabled = false;    // Doctors section
                LabLbl.Enabled = false;   // Lab Tests section
                NurseLbl.Enabled = false;
                PatLbl.Enabled = false;
                PrescriptionLbl.Enabled = false;
            }

        }

        // Create a SqlConnection object to establish a connection to the database
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\HealthCarePlusDb.mdf;Integrated Security=True;Connect Timeout=30");

        // Method to display patient data in the DataGridView
        private void DisplayPat()
        {
            con.Open();

            // Define the SQL query to select patient data
            string Query = "Select * from PatientTbl";

            // Create a data adapter to fetch data from the database
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);

            // Create a SqlCommandBuilder to automatically generate SQL commands
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            PatientsDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        // Initialize a key variable to keep track of selected records
        int key = 0;

        // Method to clear input fields and reset key value
        private void ClearFields()
        {
            // Clear the text in the input fields
            PatNameTb.Text = "";
            PatGenCb.SelectedIndex = -1;
            PatHIVCb.SelectedIndex = -1;
            PatAddTb.Text = "";
            PatPhoneTb.Text = "";
            PatAllergiesTb.Text = "";
            PatDOB.Value = DateTime.Now; // Set to the current date by default


            // Reset the key value
            key = 0;

            // Set the DateTimePicker value to a default date if needed
            // DocDOB.Value = defaultDate;
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            // Check if a patient has been selected
            if (key == 0)
            {
                // Show a message to select a patient
                MessageBox.Show("Select the Patient");
            }
            else
            {
                // Confirm deletion with the user
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this patient?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        // Create a delete command and execute it
                        SqlCommand cmd = new SqlCommand("DELETE FROM PatientTbl WHERE PatId = @PKey", con);
                        cmd.Parameters.AddWithValue("@PKey", key);
                        cmd.ExecuteNonQuery();

                        // Show a success message
                        MessageBox.Show("Patient Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();

                        // Refresh the displayed patient list
                        DisplayPat();

                        // Clear input fields
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }


        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Check if any required information is missing in the input fields
            if (PatNameTb.Text == "" || PatAllergiesTb.Text == "" || PatAddTb.Text == "" || PatPhoneTb.Text == "" || PatGenCb.SelectedIndex == -1 || PatHIVCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                // Show confirmation message before adding the patient
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to add this patient?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        // Create a command to insert patient data into the database
                        SqlCommand cmd = new SqlCommand("INSERT INTO PatientTbl(PatName, PatGen, PatDOB, PatAdd, PatPhone, PatHIV, PatAll) VALUES (@PN, @PG, @PD, @PA, @PP, @PH, @PAL)", con);

                        // Bind parameters to the values from the input fields
                        cmd.Parameters.AddWithValue("@PN", PatNameTb.Text);
                        cmd.Parameters.AddWithValue("@PG", PatGenCb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@PD", PatDOB.Value.Date); // Assuming PatDOB is a DateTimePicker
                        cmd.Parameters.AddWithValue("@PA", PatAddTb.Text);
                        cmd.Parameters.AddWithValue("@PP", PatPhoneTb.Text);
                        cmd.Parameters.AddWithValue("@PH", PatHIVCb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@PAL", PatAllergiesTb.Text);

                        cmd.ExecuteNonQuery();

                        // Show a success message
                        MessageBox.Show("Patient Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();

                        // Close the database connection
                        con.Close();

                        // Display updated list of patients
                        DisplayPat();
                    }
                    catch (Exception ex)
                    {
                        // Display an error message if an exception occurs
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            // Check if any required information is missing in the input fields
            if (PatNameTb.Text == "" || PatAllergiesTb.Text == "" || PatAddTb.Text == "" || PatPhoneTb.Text == "" || PatGenCb.SelectedIndex == -1 || PatHIVCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                // Show confirmation message before updating patient data
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to update this patient?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();

                        // Create a command to update patient data in the database
                        SqlCommand cmd = new SqlCommand("UPDATE PatientTbl SET PatName = @PN, PatGen = @PG, PatDOB = @PD, PatAdd = @PA, PatPhone = @PP, PatHIV = @PH, PatAll = @PAL WHERE PatId = @PKey", con);

                        // Bind parameters to the values from the input fields
                        cmd.Parameters.AddWithValue("@PN", PatNameTb.Text);
                        cmd.Parameters.AddWithValue("@PG", PatGenCb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@PD", PatDOB.Value.Date); // Assuming PatDOB is a DateTimePicker
                        cmd.Parameters.AddWithValue("@PA", PatAddTb.Text);
                        cmd.Parameters.AddWithValue("@PP", PatPhoneTb.Text);
                        cmd.Parameters.AddWithValue("@PH", PatHIVCb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@PAL", PatAllergiesTb.Text);
                        cmd.Parameters.AddWithValue("@PKey", key);

                        cmd.ExecuteNonQuery();

                        // Show a success message
                        MessageBox.Show("Patient Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();

                        // Close the database connection
                        con.Close();

                        // Display updated list of patients
                        DisplayPat();
                    }
                    catch (Exception ex)
                    {
                        // Display an error message if an exception occurs
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            // Confirm application exit with the user
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Exit the application
                Application.Exit();
            }

        }

        private void PatPhoneTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void PatPhoneTb_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is a digit or control key (e.g., Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If the pressed key is not a digit or control key, suppress the key press event
                e.Handled = true;
            }

        }

        private void HomeLbl_Click(object sender, EventArgs e)
        {

        }

        private void LogOutLbl_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }


        private void Patients_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PatientsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Populate textboxes with data from the selected row
            PatNameTb.Text = PatientsDGV.SelectedRows[0].Cells[1].Value.ToString(); // Patient Name
            PatGenCb.Text = PatientsDGV.SelectedRows[0].Cells[2].Value.ToString(); // Patient Gender
            PatDOB.Value = Convert.ToDateTime(PatientsDGV.SelectedRows[0].Cells["PatDOB"].Value); // Patient Date of Birth
            PatAddTb.Text = PatientsDGV.SelectedRows[0].Cells[4].Value.ToString(); // Patient Address
            PatPhoneTb.Text = PatientsDGV.SelectedRows[0].Cells[5].Value.ToString(); // Patient Phone Number
            PatHIVCb.Text = PatientsDGV.SelectedRows[0].Cells[6].Value.ToString(); // Patient HIV Status
            PatAllergiesTb.Text = PatientsDGV.SelectedRows[0].Cells[7].Value.ToString(); // Patient Allergies


            // Check if a row is selected and set the 'key' value
            if (PatNameTb.Text == "")
            {
                key = 0; // Reset 'key' if no row is selected
            }
            else
            {
                key = Convert.ToInt32(PatientsDGV.SelectedRows[0].Cells[0].Value.ToString()); // PatientID (assuming it's in the first column)
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Homes obj = new Homes();
            obj.Show();
            this.Hide();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            // Confirm clearing fields with the user
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to clear all fields?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2); // Use MessageBoxDefaultButton.Button2 to suppress the beep sound.

            if (confirmResult == DialogResult.Yes)
            {
                ClearFields(); // Clear the fields.
            }
        }

        private void PatGenCb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cancel the key press event to prevent typing in the middle of the ComboBox
            e.Handled = true;
        }

        private void PatHIVCb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cancel the key press event to prevent typing in the middle of the ComboBox
            e.Handled = true;
        }

        private void PatNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void PatGenCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

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

        private void SearchBtn_Click(object sender, EventArgs e)

        {
            // Get the search keyword or criteria from a text box
            string searchKeyword = searchTb.Text;

            // Check if the search keyword is not empty
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                try
                {
                    con.Open(); // Open the database connection

                    // First, check if the search keyword is a valid ID
                    bool isValidId = int.TryParse(searchKeyword, out int PatID);

                    // Define a SQL query to retrieve data based on the search criteria
                    string query;

                    if (isValidId)
                    {
                        // If it's a valid ID, set the parameter for ID search
                        query = "SELECT * FROM PatientTbl WHERE PatId = @SearchId";
                    }
                    else
                    {
                        // If it's not a valid ID, set the parameter for name search
                        query = "SELECT * FROM PatientTbl WHERE PatName LIKE @SearchName";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);

                    if (isValidId)
                    {
                        // If it's a valid ID, set the parameter for ID search
                        cmd.Parameters.AddWithValue("@SearchId", PatID);
                    }
                    else
                    {
                        // If it's not a valid ID, set the parameter for name search
                        cmd.Parameters.AddWithValue("@SearchName", "%" + searchKeyword + "%"); // Use '%' for wildcard search
                    }

                    // Create a data adapter and data table to store the results
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        if (isValidId)
                        {
                            // If no results were found for the valid ID, display "Invalid ID"
                            MessageBox.Show("Invalid ID", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // If no results were found for the name, display "Invalid Name"
                            MessageBox.Show("Invalid Name or Invalid ID", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // Bind the data table to a DataGridView 
                        PatientsDGV.DataSource = dataTable;
                    }

                    // Close the database connection
                    con.Close();
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the database operation
                    MessageBox.Show("Error: " + ex.Message);
                    con.Close(); // Ensure the database connection is closed in case of an error
                }
            }
            else
            {
                // If the search keyword is empty, display all data in the DataGridView
                DisplayPat(); // Create a function to display all data
            }
        }

        private void PrescriptionLbl_Click(object sender, EventArgs e)
        {

            Prescriptions obj = new Prescriptions();
            obj.Show();
            this.Hide();
        }
    }
}


