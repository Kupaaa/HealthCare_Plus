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
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
            DisplayAppointment();
            GetDocId();
            //GetDocName();

            if (Login.Role == "Receptionist")
            {
                // Disable access to specific sections for a Receptionist role
                RepLbl.Enabled = false;   // Receptionists section
                DocLb.Enabled = false;    // Doctors section
                LabLbl.Enabled = false;   // Lab Tests section
                NurseLbl.Enabled = false;
                PatLbl.Enabled = false;

                // Additional logic specific to the Receptionist role here
            }
            else if (Login.Role == "Doctor")
            {
                // Additional logic specific to the Doctor role here
                RepLbl.Enabled = false;   // Receptionists section
                DocLb.Enabled = false;    // Doctors section
                LabLbl.Enabled = false;   // Lab Tests section
                NurseLbl.Enabled = false;
                //PatLbl.Enabled = false;
                DelBtn.Visible = false;
                AddBtn.Visible = false;
                EditBtn.Visible = false;
                ClearBtn.Visible = false;
            }
            else if (Login.Role == "Admin")

            RepLbl.Enabled = false;   // Receptionists section
            DocLb.Enabled = false;    // Doctors section
            LabLbl.Enabled = false;   // Lab Tests section
            NurseLbl.Enabled = false;
            PatLbl.Enabled =false;


            {


                // Disable access to specific sections for a Receptionist role
                RepLbl.Enabled = false;   // Receptionists section
                DocLb.Enabled = false;    // Doctors section
                LabLbl.Enabled = false;   // Lab Tests section
                NurseLbl.Enabled = false;
                PatLbl.Enabled = false;
            }
        }


        // Create a SqlConnection object to establish a connection to the database
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\HealthCarePlusDb.mdf;Integrated Security=True;Connect Timeout=30");

        //Method to display Prescription data in the DataGridView
        private void DisplayAppointment()
        {
            con.Open();
            string Query = "Select * from Appointment";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            AppointmentDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void ClearAppointmentFields()
        {
            // Clear textboxes
            NameTb.Text = string.Empty;
            GenCb.SelectedIndex = -1;
            DocId.SelectedIndex = -1;
            DocNameTb.Text = string.Empty;
            AddTb.Text = string.Empty;
            PhoneTb.Text = string.Empty;
            AppointmentDateCb.Value = DateTime.Now; // Set to the current date by default
            DOB.Value = DateTime.Now; // Set to the current date by default
        }

        private void Appointment_Load(object sender, EventArgs e)
        {

        }

        // This method retrieves Doctor IDs from the database and populates them into a ComboBox.
        private void GetDocId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select DocId From DoctorTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DocId", typeof(int));
            dt.Load(rdr);
            DocId.ValueMember = "DocId";
            DocId.DataSource = dt;
            con.Close();
        }

        private void GetDocName()
        {
            con.Open();
            string Query = "Select * from DoctorTbl where DocId=" + DocId.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, con);

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            // Loop through each row in the DataTable (usually only one row in this case).
            foreach (DataRow dr in dt.Rows)
            {
                // Set the text of a TextBox control (DocNameTb) to the "DocName" value from the row.
                DocNameTb.Text = dr["DocName"].ToString();
            }
            con.Close();
        }

        private void DocNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || GenCb.SelectedIndex == -1 || DocId.SelectedIndex == -1 || DocNameTb.Text == "" || AddTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information"); // Show an error message if required information is missing.
            }
            else
            {
                // Show confirmation message before adding the appointment
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to add this appointment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        // Create a SQL command to insert appointment data into the database
                        SqlCommand cmd = new SqlCommand("INSERT INTO Appointment(Name, Dob, Gender, AppointmentDate, DocId, DocName, Address, PhoneNo ) VALUES (@N, @DOB, @G, @AD, @DI, @DN, @ADD, @PN)", con);

                        // Bind parameters to the values from the input fields
                        cmd.Parameters.AddWithValue("@N", NameTb.Text);
                        cmd.Parameters.AddWithValue("@DOB", DOB.Value.Date);
                        cmd.Parameters.AddWithValue("@G", GenCb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@AD", AppointmentDateCb.Value.Date);
                        cmd.Parameters.AddWithValue("@DN", DocNameTb.Text);
                        cmd.Parameters.AddWithValue("@ADD", AddTb.Text);
                        cmd.Parameters.AddWithValue("@PN", PhoneTb.Text);
                        cmd.Parameters.AddWithValue("@DI", DocId.SelectedValue.ToString()); // Add DocId
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Appointment Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // Show a success message.
                        con.Close();
                        DisplayAppointment();
                        ClearAppointmentFields();
                    }
                    catch (Exception ex)
                    {
                        // Display an error message if an exception occurs.
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }
        int key = 0;
        private void AppointmentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)

        {
            // Check if a row is selected in the DataGridView
            if (AppointmentDGV.SelectedRows.Count > 0)
            {
                // Populate textboxes with data from the selected row
                NameTb.Text = AppointmentDGV.SelectedRows[0].Cells["Name"].Value.ToString();
                DOB.Value = Convert.ToDateTime(AppointmentDGV.SelectedRows[0].Cells["Dob"].Value);
                GenCb.SelectedItem = AppointmentDGV.SelectedRows[0].Cells["Gender"].Value.ToString();
                AppointmentDateCb.Value = Convert.ToDateTime(AppointmentDGV.SelectedRows[0].Cells["AppointmentDate"].Value);
                DocNameTb.Text = AppointmentDGV.SelectedRows[0].Cells["DocName"].Value.ToString();
                AddTb.Text = AppointmentDGV.SelectedRows[0].Cells["Address"].Value.ToString();
                PhoneTb.Text = AppointmentDGV.SelectedRows[0].Cells["PhoneNo"].Value.ToString();
                DocId.SelectedValue = AppointmentDGV.SelectedRows[0].Cells["DocId"].Value; // Assuming you have a binding source for DocId

                // Check if a row is selected and set the 'key' value
                if (NameTb.Text == "")
                {
                    key = 0; // Reset 'key' if no row is selected
                }
                else
                {
                    key = Convert.ToInt32(AppointmentDGV.SelectedRows[0].Cells["AppointmentId"].Value);
                }
            }
        }



        private void DocId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetDocName();
        }

        private void DocId_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void DocId_SelectedIndexChanged(object sender, EventArgs e)
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
                    bool isValidId = int.TryParse(searchKeyword, out int appointmentId);

                    // Define a SQL query to retrieve data based on the search criteria
                    string query;

                    if (isValidId)
                    {
                        // If it's a valid ID, set the parameter for ID search
                        query = "SELECT * FROM Appointment WHERE AppointmentId = @SearchId";
                    }
                    else
                    {
                        // If it's not a valid ID, set the parameter for name search
                        query = "SELECT * FROM Appointment WHERE Name LIKE @SearchName";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);

                    if (isValidId)
                    {
                        // If it's a valid ID, set the parameter for ID search
                        cmd.Parameters.AddWithValue("@SearchId", appointmentId);
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
                            MessageBox.Show("No results found for the given name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // Bind the data table to a DataGridView 
                        AppointmentDGV.DataSource = dataTable;
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
                DisplayAppointment(); // Create a function to display all data
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (AppointmentDGV.SelectedRows.Count > 0)
            {
                // Show a confirmation message before deleting the appointment
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // Get the AppointmentId of the selected appointment
                        int appointmentId = Convert.ToInt32(AppointmentDGV.SelectedRows[0].Cells["AppointmentId"].Value);

                        // Open the database connection
                        con.Open();

                        // Create a SQL command to delete the appointment by AppointmentId
                        SqlCommand cmd = new SqlCommand("DELETE FROM Appointment WHERE AppointmentId = @AppointmentId", con);

                        // Bind parameters
                        cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);

                        // Execute the delete command
                        cmd.ExecuteNonQuery();

                        // Show a success message
                        MessageBox.Show("Appointment Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Close the database connection
                        con.Close();

                        // Refresh the DataGridView
                        DisplayAppointment();
                        ClearAppointmentFields();
                    }
                    catch (Exception ex)
                    {
                        // Display an error message if an exception occurs
                        MessageBox.Show("Error: " + ex.Message);
                        con.Close(); // Ensure the database connection is closed in case of an error
                    }
                }
            }
            else
            {
                // Show a message if no appointment is selected
                MessageBox.Show("Please select an appointment to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            // Check if any row is selected in the DataGridView
            if (AppointmentDGV.SelectedRows.Count > 0)
            {
                // Show a confirmation message before editing the appointment
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to edit this appointment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open(); // Open the database connection

                        // Get the AppointmentId of the selected appointment
                        int appointmentId = Convert.ToInt32(AppointmentDGV.SelectedRows[0].Cells["AppointmentId"].Value);

                        // Create a SQL command to update the appointment data in the database
                        SqlCommand cmd = new SqlCommand("UPDATE Appointment SET Name = @N, Dob = @DOB, Gender = @G, AppointmentDate = @AD, DocId = @DI, DocName = @DN, Address = @ADD, PhoneNo = @PN WHERE AppointmentId = @AppointmentId", con);

                        // Bind parameters to the values from the input fields
                        cmd.Parameters.AddWithValue("@N", NameTb.Text);
                        cmd.Parameters.AddWithValue("@DOB", DOB.Value.Date);
                        cmd.Parameters.AddWithValue("@G", GenCb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@AD", AppointmentDateCb.Value.Date);
                        cmd.Parameters.AddWithValue("@DN", DocNameTb.Text);
                        cmd.Parameters.AddWithValue("@ADD", AddTb.Text);
                        cmd.Parameters.AddWithValue("@PN", PhoneTb.Text);
                        cmd.Parameters.AddWithValue("@DI", DocId.SelectedValue.ToString()); // Add DocId
                        cmd.Parameters.AddWithValue("@AppointmentId", appointmentId); // Add AppointmentId

                        // Execute the update command
                        cmd.ExecuteNonQuery();

                        // Show a success message
                        MessageBox.Show("Appointment Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Close the database connection
                        con.Close();

                        // Refresh the DataGridView
                        DisplayAppointment();
                        ClearAppointmentFields();
                    }
                    catch (Exception ex)
                    {
                        // Display an error message if an exception occurs
                        MessageBox.Show("Error: " + ex.Message);
                        con.Close(); // Ensure the database connection is closed in case of an error
                    }
                }
            }
            else
            {
                // Show a message if no appointment is selected
                MessageBox.Show("Please select an appointment to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {

            // Show a confirmation message
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to clear the appointment fields?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                // Clear textboxes and reset other input fields
                ClearAppointmentFields();

                // Show a success message
                MessageBox.Show("Appointment fields cleared.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void label1_Click(object sender, EventArgs e)
        {
            Homes obj = new Homes();
            obj.Show();
            this.Hide();
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
    }
}

