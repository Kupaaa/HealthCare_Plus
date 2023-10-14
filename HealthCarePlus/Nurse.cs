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
    public partial class Nurse : Form
    {
        public Nurse()
        {
            InitializeComponent();
            DisplayNurse();

            if (Login.Role == "Receptionist")
            {
                //// Disable access to specific sections for a Receptionist role
                //RepLbl.Enabled = false;   // Receptionists section
                //DocLb.Enabled = false;    // Doctors section
                //LabLbl.Enabled = false;   // Lab Tests section
                //NurseLbl.Enabled = false;
                ////PatLbl.Enabled = false;

                // Additional logic specific to the Receptionist role here
            }
            else if (Login.Role == "Doctor")
            {

                //// Additional logic specific to the Doctor role here
                //RepLbl.Enabled = false;   // Receptionists section
                //RepLbl.ForeColor = Color.Red;
                //DocLb.Enabled = false;    // Doctors section
                //LabLbl.Enabled = false;   // Lab Tests section
                //NurseLbl.Enabled = false;
                //HomeLbl.Enabled = false;
                //PatLbl.Enabled = false;
                //DelBtn.Visible = false;
                //AddBtn.Visible = false;
                //EditBtn.Visible = false;
                //ClearBtn.Visible = false;
            }
            else if (Login.Role == "Admin")
            {
                label2.Enabled = false;   // Receptionists section
                DocLb.Enabled = false;    // Doctors section
                label2.Enabled = false;   // Lab Tests section
                //NurseLbl.Enabled = false;
                label3.Enabled = false;
                label4.Enabled = false;
            }
        }

        int key = 0;

        // Create a SqlConnection object to establish a connection to the database
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\HealthCarePlusDb.mdf;Integrated Security=True;Connect Timeout=30");

        //Method to display receptionist data in the DataGridView
        private void DisplayNurse()
        {
            con.Open();
            string Query = "Select * from NurseTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            NurseDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void ClearFields()
        {
            // Clear the text in the input fields
            NNameTb.Text = "";
            NursePhoneTb.Text = "";
            NurseAddTb.Text = "";
            NurseDOB.Value = DateTime.Now; // Set to the current date by default
            NurseGenCb.SelectedIndex = -1;

            // Reset the selected index for ComboBoxes
            NurseGenCb.SelectedIndex = 0;    // Assuming 0 is the default index
            //DocSpecCb.SelectedIndex = 0;   // Assuming 0 is the default index

            // Set the DateTimePicker value to a default date if needed
            // DocDOB.Value = defaultDate;
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        // Event handler for the "Add" button click
        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Check if any required information is missing in the input fields
            if (NNameTb.Text == "" || NurseGenCb.SelectedIndex == -1 || NurseAddTb.Text == "" || NursePhoneTb.Text == "")
            {
                // Show an error message if required information is missing.
                MessageBox.Show("Missing Information");
            }
            else
            {
                // Show confirmation message before adding the Nurse
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to add this Nurse?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open(); // Open a connection to the database.

                        // Create a SQL command to insert nurse data into the database
                        SqlCommand cmd = new SqlCommand("INSERT INTO NurseTbl(NurseName, NurseDOB, Gender, Adress, PhoneNo) VALUES (@NN, @NDOB, @NG, @NA, @NP)", con);

                        // Bind parameters to the values from the input fields
                        cmd.Parameters.AddWithValue("@NN", NNameTb.Text); // Nurse Name
                        cmd.Parameters.AddWithValue("@NDOB", NurseDOB.Value.Date); // Nurse Date of Birth
                        cmd.Parameters.AddWithValue("@NG", NurseGenCb.SelectedItem.ToString()); // Nurse Gender
                        cmd.Parameters.AddWithValue("@NA", NurseAddTb.Text); // Nurse Address
                        cmd.Parameters.AddWithValue("@NP", NursePhoneTb.Text); // Nurse Phone Number
                        cmd.ExecuteNonQuery(); // Execute the SQL command to insert the data.

                        // Show a success message.
                        MessageBox.Show("Nurse Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // ClearFields(); // Uncomment this line if you want to clear the input fields.

                        con.Close(); // Close the database connection.

                        // Display the updated list of nurses.
                        DisplayNurse();
                        // ClearFields(); // Uncomment this line if you want to clear the input fields again.
                    }
                    catch (Exception ex)
                    {
                        // Display an error message if an exception occurs.
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void NurseDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Populate textboxes with data from the selected row
            NNameTb.Text = NurseDGV.SelectedRows[0].Cells[1].Value.ToString();
            NurseDOB.Text = NurseDGV.SelectedRows[0].Cells[2].Value.ToString();
            NurseGenCb.Text = NurseDGV.SelectedRows[0].Cells[3].Value.ToString();
            NurseAddTb.Text = NurseDGV.SelectedRows[0].Cells[4].Value.ToString();
            NursePhoneTb.Text = NurseDGV.SelectedRows[0].Cells[5].Value.ToString();
            NurseDOB.Value = Convert.ToDateTime(NurseDGV.SelectedRows[0].Cells["NurseDOB"].Value);

            // Check if a row is selected and set the 'key' value
            if (NNameTb.Text == "")
            {
                key = 0; // Reset 'key' if no row is selected
            }
            else
            {
                key = Convert.ToInt32(NurseDGV.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            // Check if a Nurse has been selected
            if (key == 0)
            {
                // Show a message to select a doctor
                MessageBox.Show("Select the Nurse");
            }
            else
            {
                // Show confirmation message before deleting the Nurse
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this Nurse?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        // Create a delete command and execute it
                        SqlCommand cmd = new SqlCommand("DELETE FROM NurseTbl WHERE NurseId = @NKey", con);
                        cmd.Parameters.AddWithValue("@NKey", key);
                        cmd.ExecuteNonQuery();

                        // Close the database connection
                        con.Close();

                        // Show a success message
                        MessageBox.Show("Nurse Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh the displayed nurse list
                        DisplayNurse();

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

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            // Show a confirmation message before clearing the fields
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to clear the fields?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                // Call the ClearFields method to clear the input fields
                ClearFields();

                // Show a success message after clearing the fields
                MessageBox.Show("Fields Cleared", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Event handler for the "Edit" button click
        private void EditBtn_Click(object sender, EventArgs e)
        {
            // Check if any required information is missing in the input fields
            if (NNameTb.Text == "" || NurseGenCb.SelectedIndex == -1 || NurseAddTb.Text == "" || NursePhoneTb.Text == "")
            {
                // Show an error message if required information is missing.
                MessageBox.Show("Missing Information");
            }
            else
            {
                // Show confirmation message before updating the Nurse
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to update this Nurse?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open(); // Open a connection to the database.

                        // Create a SQL command to update nurse data in the database
                        SqlCommand cmd = new SqlCommand("UPDATE NurseTbl SET NurseName = @NN, NurseDOB = @NDOB, Gender = @NG, Adress = @NA, PhoneNo = @NP WHERE NurseID = @NurseID", con);

                        // Bind parameters to the values from the input fields
                        cmd.Parameters.AddWithValue("@NurseID", key); // Provide the NurseID of the nurse you want to update
                        cmd.Parameters.AddWithValue("@NN", NNameTb.Text); // Nurse Name
                        cmd.Parameters.AddWithValue("@NDOB", NurseDOB.Value.Date); // Nurse Date of Birth
                        cmd.Parameters.AddWithValue("@NG", NurseGenCb.SelectedItem.ToString()); // Nurse Gender
                        cmd.Parameters.AddWithValue("@NA", NurseAddTb.Text); // Nurse Address
                        cmd.Parameters.AddWithValue("@NP", NursePhoneTb.Text); // Nurse Phone Number
                        cmd.ExecuteNonQuery(); // Execute the SQL command to update the data.

                        // Show a success message.
                        MessageBox.Show("Nurse Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // ClearFields(); // Uncomment this line if you want to clear the input fields.

                        con.Close(); // Close the database connection.

                        // Display the updated list of nurses.
                        DisplayNurse();
                        // ClearFields(); // Uncomment this line if you want to clear the input fields again.
                    }
                    catch (Exception ex)
                    {
                        // Display an error message if an exception occurs.
                        MessageBox.Show(ex.Message);
                    }
                }
            }
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

        private void label4_Click(object sender, EventArgs e)
        {
            // Create an instance of the Receptionists form
            Receptionists obj = new Receptionists();

            // Show the Receptionists form
            obj.Show();

            // Hide the current form
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Homes obj = new Homes();
            obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
                    bool isValidId = int.TryParse(searchKeyword, out int NurseID);

                    // Define a SQL query to retrieve data based on the search criteria
                    string query;

                    if (isValidId)
                    {
                        // If it's a valid ID, set the parameter for ID search
                        query = "SELECT * FROM NurseTbl WHERE NurseID = @SearchId";
                    }
                    else
                    {
                        // If it's not a valid ID, set the parameter for name search
                        query = "SELECT * FROM NurseTbl WHERE NurseName LIKE @SearchName";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);

                    if (isValidId)
                    {
                        // If it's a valid ID, set the parameter for ID search
                        cmd.Parameters.AddWithValue("@SearchId", NurseID);
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
                        NurseDGV.DataSource = dataTable;
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
                DisplayNurse(); // Create a function to display all data
            }
        }

        private void Nurse_Load(object sender, EventArgs e)
        {

        }

        private void searchTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}





