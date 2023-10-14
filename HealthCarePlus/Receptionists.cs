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
using System.Xml.Linq;


namespace HealthCarePlus
{
    public partial class Receptionists : Form
    {
        public Receptionists()
        {
            InitializeComponent();
            DisplayRec();

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
                PatLbl.Enabled = false;   // Receptionists section
                DocLbl.Enabled = false;    // Doctors section
                NurseLbl.Enabled = false;   // Lab Tests section
                //NurseLbl.Enabled = false;
                RoomLbl.Enabled = false;
                LabLbl.Enabled = false;
                RoomLbl.Enabled = false;
                //LabLab.Enabled = false;
                ReceLbl.Enabled = false;
            }

        }
        // Create a SqlConnection object to establish a connection to the database
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\HealthCarePlusDb.mdf;Integrated Security=True;Connect Timeout=30");

        //Method to display receptionist data in the DataGridView
        private void DisplayRec()
        {
            con.Open();
            string Query = "Select * from ReceptionistTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            ReceptionistDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        // Check if any required information is missing in the input fields
        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Check if any required information is missing in the input fields
            if (RNameTb.Text == "" || RPasswordTb.Text == "" || RPhoneTb.Text == "" || RAddressTb.Text == "" || ReGenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                // Show confirmation message before adding the receptionist
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to add this receptionist?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // Open a connection to the database
                        con.Open();

                        // Create a command to insert receptionist data into the database
                        SqlCommand cmd = new SqlCommand("INSERT INTO ReceptionistTbl(Name, PhoneNo, Address, Password, Gender, DOB) VALUES (@Rn, @Rp, @RA, @RPA, @RG, @RD)", con);

                        // Bind parameters to the values from the input fields
                        cmd.Parameters.AddWithValue("@Rn", RNameTb.Text);
                        cmd.Parameters.AddWithValue("@Rp", RPhoneTb.Text);
                        cmd.Parameters.AddWithValue("@RA", RAddressTb.Text);
                        cmd.Parameters.AddWithValue("@RPA", RPasswordTb.Text);
                        cmd.Parameters.AddWithValue("@RG", ReGenCb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@RD", ReDOB.Value.Date);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Receptionist Added");

                        // Close the database connection
                        con.Close();

                        // Display updated list of receptionists
                        DisplayRec();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        // Display an error message if an exception occurs
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        //delete receptionist
        private void DelBtn_Click(object sender, EventArgs e)
        {
            // Check if a receptionist has been selected
            if (key == 0)
            {
                // If no receptionist is selected, show a message to the user
                MessageBox.Show("Select the Receptionist");
            }
            else
            {
                // Confirm with the user before deleting
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this receptionist?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM ReceptionistTbl WHERE ID = @RKey", con);
                        cmd.Parameters.AddWithValue("@RKey", key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Receptionist Deleted");
                        con.Close();
                        DisplayRec();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        // Declare and initialize a variable to store the selected row's key
        int key = 0;

        // Event handler for clicking on a cell within the DataGridView
        private void ReceptionistDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in a valid row
            if (e.RowIndex >= 0 && e.RowIndex < ReceptionistDGV.RowCount)
            {
                // Populate textboxes with data from the selected row
                RNameTb.Text = ReceptionistDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                RPhoneTb.Text = ReceptionistDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                RAddressTb.Text = ReceptionistDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                RPasswordTb.Text = ReceptionistDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
                ReDOB.Value = Convert.ToDateTime(ReceptionistDGV.Rows[e.RowIndex].Cells["DOB"].Value); // Patient Date of Birth
                ReGenCb.Text = ReceptionistDGV.Rows[e.RowIndex].Cells[6].Value.ToString();

                // Set the 'key' value based on the selected row
                key = Convert.ToInt32(ReceptionistDGV.Rows[e.RowIndex].Cells[0].Value);
            }
            else
            {
                // Handle the case where the clicked cell is not in a valid row
                // You can add code here to clear the textboxes or perform other actions as needed.
            }
        }

        // Edit receptionist
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (RNameTb.Text == "" || RPasswordTb.Text == "" || RPhoneTb.Text == "" || RAddressTb.Text == "" || ReGenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                // Show confirmation message before updating receptionist data
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to update this receptionist?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE ReceptionistTbl SET Name = @Rn, PhoneNo = @Rp, Address = @RA, Password = @RPA, Gender=@RG, DOB =@RD WHERE ID = @RKey", con);
                        cmd.Parameters.AddWithValue("@Rn", RNameTb.Text);
                        cmd.Parameters.AddWithValue("@Rp", RPhoneTb.Text);
                        cmd.Parameters.AddWithValue("@RA", RAddressTb.Text);
                        cmd.Parameters.AddWithValue("@RPA", RPasswordTb.Text);
                        cmd.Parameters.AddWithValue("@RG", ReGenCb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@RD", ReDOB.Value.Date);

                        cmd.Parameters.AddWithValue("@RKey", key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Receptionist Updated");
                        con.Close();
                        DisplayRec();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }


        // Clear method
        private void ClearFields()
        {
            // Clear values in the input fields
            RNameTb.Text = "";
            RPhoneTb.Text = "";
            RPasswordTb.Text = "";
            RAddressTb.Text = "";
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            // Show a confirmation message before clearing the fields
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to clear the fields?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                // Call the ClearFields() method to clear the input fields
                ClearFields();

                // Show a success message
                MessageBox.Show("Fields Cleared", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void RPhoneTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit or control key (e.g., Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If the pressed key is not a digit or control key, suppress the key press event
                e.Handled = true;
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


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Create an instance of the Receptionists form
            ////////////Receptionists obj = new Receptionists();

            ////////////// Show the Receptionists form
            ////////////obj.Show();

            ////////////// Hide the current form
            ////////////this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //Homes obj = new Homes();
            //obj.Show();
            //this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Homes obj = new Homes();
            obj.Show();
            this.Hide();
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
                    bool isValidId = int.TryParse(searchKeyword, out int ReceptionistsID);

                    // Define a SQL query to retrieve data based on the search criteria
                    string query;

                    if (isValidId)
                    {
                        // If it's a valid ID, set the parameter for ID search
                        query = "SELECT * FROM ReceptionistTbl WHERE ID = @SearchId";
                    }
                    else
                    {
                        // If it's not a valid ID, set the parameter for name search
                        query = "SELECT * FROM ReceptionistTbl WHERE Name LIKE @SearchName";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);

                    if (isValidId)
                    {
                        // If it's a valid ID, set the parameter for ID search
                        cmd.Parameters.AddWithValue("@SearchId", ReceptionistsID);
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
                        ReceptionistDGV.DataSource = dataTable;
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
                DisplayRec(); // Create a function to display all data
            }
        }


        private void searchTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Receptionists_Load(object sender, EventArgs e)
        {

        }

        private void ReGenCb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cancel the key press event to prevent typing in the middle of the ComboBox
            e.Handled = true;
        }
    }
}

