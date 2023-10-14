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
    public partial class Rooms : Form
    {
        public Rooms()
        {
            InitializeComponent();
            DisplayRoom();

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
                Patlbl.Enabled = false;    // Doctors section
                label2.Enabled = false;   // Lab Tests section
                NurseLbl.Enabled = false;
                //label3.Enabled = false;
                DoctorLbl.Enabled = false;
                RoomLbl.Enabled = false;
                LabLab.Enabled = false;
                RecepLbl.Enabled = false;   
            }
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\HealthCarePlusDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplayRoom()
        {
            con.Open();
            string Query = "Select * from RoomTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            RoomDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void ClearFields()
        {
            // Clear the text in the input fields
            RNameTb.Text = "";
            PriceTb.Text = "";
            TypeCb.SelectedIndex = -1;


            // Reset the selected index for ComboBoxes
            TypeCb.SelectedIndex = 0;    // Assuming 0 is the default index

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Check if any required information is missing in the input fields
            if (RNameTb.Text == "" || TypeCb.SelectedIndex == -1 || PriceTb.Text == "")
            {
                MessageBox.Show("Missing Information"); // Show an error message if required information is missing.
            }
            else
            {
                // Show confirmation message before adding the room
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to add this room?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open(); // Open a connection to the database.

                        // Create a SQL command to insert room data into the database
                        SqlCommand cmd = new SqlCommand("INSERT INTO RoomTbl(RoomNumber, RoomType, Price) VALUES (@RN, @RT, @RP)", con);

                        // Bind parameters to the values from the input fields
                        cmd.Parameters.AddWithValue("@RN", RNameTb.Text); // Room Number
                        cmd.Parameters.AddWithValue("@RT", TypeCb.SelectedItem.ToString()); // Room Type
                        cmd.Parameters.AddWithValue("@RP", PriceTb.Text); // Room Price
                        cmd.ExecuteNonQuery(); // Execute the SQL command to insert the data.

                        MessageBox.Show("Room Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // Show a success message.
                        ClearFields(); // Clear input fields to prepare for the next entry.

                        con.Close(); // Close the database connection.

                        DisplayRoom(); // Display the updated list of rooms.
                    }
                    catch (Exception ex)
                    {
                        // Display an error message if an exception occurs during database operations.
                        MessageBox.Show(ex.Message);
                        ClearFields();
                    }
                }
            }
        }

        int key = 0;
        private void EditBtn_Click(object sender, EventArgs e)
        {
            // Check if any required information is missing in the input fields
            if (RNameTb.Text == "" || TypeCb.SelectedIndex == -1 || PriceTb.Text == "")
            {
                MessageBox.Show("Missing Information"); // Show an error message if required information is missing.
            }
            else
            {
                // Show confirmation message before updating the room
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to update this room?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open(); // Open a connection to the database.

                        // Create a SQL command to update room data in the database
                        SqlCommand cmd = new SqlCommand("UPDATE RoomTbl SET RoomType = @RT, Price = @RP WHERE RoomNumber = @RN", con);

                        // Bind parameters to the values from the input fields
                        cmd.Parameters.AddWithValue("@RT", TypeCb.SelectedItem.ToString()); // Updated Room Type
                        cmd.Parameters.AddWithValue("@RP", PriceTb.Text); // Updated Room Price
                        cmd.Parameters.AddWithValue("@RN", RNameTb.Text); // Room Number to identify the room to be updated
                        cmd.ExecuteNonQuery(); // Execute the SQL command to update the data.

                        MessageBox.Show("Room Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // Show a success message.
                        ClearFields(); // Clear input fields to prepare for the next action.

                        con.Close(); // Close the database connection.

                        DisplayRoom(); // Display the updated list of rooms.
                    }
                    catch (Exception ex)
                    {
                        // Display an error message if an exception occurs during database operations.
                        MessageBox.Show(ex.Message);
                        ClearFields();
                    }
                }
            }
        }

        private void RoomDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a row is clicked
            if (e.RowIndex >= 0 && e.RowIndex < RoomDGV.Rows.Count)
            {
                // Populate textboxes with data from the selected row
                RNameTb.Text = RoomDGV.SelectedRows[0].Cells[1].Value.ToString(); // Room Name
                TypeCb.Text = RoomDGV.SelectedRows[0].Cells[2].Value.ToString(); // Room Type
                PriceTb.Text = RoomDGV.SelectedRows[0].Cells[3].Value.ToString(); // Room Price

                // Check if a row is selected and set the 'key' value
                if (RNameTb.Text == "")
                {
                    key = 0; // Reset 'key' if no row is selected
                }
                else
                {
                    key = Convert.ToInt32(RoomDGV.SelectedRows[0].Cells[0].Value.ToString()); // Room ID
                }
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            // Check if a room has been selected
            if (key == 0)
            {
                // Show a message to select a room
                MessageBox.Show("Select the Room");
            }
            else
            {
                // Confirm deletion with the user
                DialogResult result = MessageBox.Show("Are you sure you want to delete this room?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        // Create a delete command and execute it
                        SqlCommand cmd = new SqlCommand("DELETE FROM RoomTbl WHERE RoomID = @DKey", con);
                        cmd.Parameters.AddWithValue("@DKey", key);
                        cmd.ExecuteNonQuery();

                        // Show a success message
                        MessageBox.Show("Room Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        con.Close();

                        // Refresh the displayed room list
                        DisplayRoom();

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Homes obj = new Homes();
            obj.Show();
            this.Hide();
        }

        private void TypeCb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cancel the key press event to prevent typing in the middle of the ComboBox
            e.Handled = true;
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

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            // Confirm clearing fields with the user
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to clear all fields?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                ClearFields(); // Call the ClearFields method to clear the input fields.
                MessageBox.Show("Fields Cleared", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // Show a success message.
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
                    bool isValidId = int.TryParse(searchKeyword, out int RoomID);

                    // Define a SQL query to retrieve data based on the search criteria
                    string query;

                    if (isValidId)
                    {
                        // If it's a valid ID, set the parameter for ID search
                        query = "SELECT * FROM RoomTbl WHERE ROOMID = @SearchId";
                    }
                    else
                    {
                        // If it's not a valid ID, set the parameter for name search
                        query = "SELECT * FROM RoomTbl WHERE RoomNumber LIKE @SearchName";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);

                    if (isValidId)
                    {
                        // If it's a valid ID, set the parameter for ID search
                        cmd.Parameters.AddWithValue("@SearchId", RoomID);
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
                            MessageBox.Show("Invalid Number or Invalid Room ID", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // Bind the data table to a DataGridView 
                        RoomDGV.DataSource = dataTable;
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
                DisplayRoom(); // Create a function to display all data
            }
        }

        private void searchTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Rooms_Load(object sender, EventArgs e)
        {

        }
    }
}





