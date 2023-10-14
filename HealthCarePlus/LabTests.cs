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
    public partial class LabTests : Form
    {
        public LabTests()
        {
            InitializeComponent();
            DisplayTest();
        }

        // Create a SqlConnection object to establish a connection to the database
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\HealthCarePlusDb.mdf;Integrated Security=True;Connect Timeout=30");

        //Method to display receptionist data in the DataGridView
        private void DisplayTest()
        {
            con.Open();
            string Query = "Select * from TestTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            LabTestDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        int Key = 0;


        // Clear method
        private void ClearFields()
        {
            // Clear values in the input fields
            LabCostTb.Text = "";
            LabTestTb.Text = "";
            Key = 0;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Check if any required information is missing in the input fields
            if (LabTestTb.Text == "" || LabCostTb.Text == "")
            {
                // Show a message if any required field is empty
                MessageBox.Show("Missing Information");
            }
            else
            {
                // Show confirmation message before adding the lab test
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to add this lab test?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open(); // Open the database connection

                        // Create a command to insert test data into the database
                        SqlCommand cmd = new SqlCommand("INSERT INTO TestTbl(TestName, TestCost) values (@TN,@TC)", con);

                        // Bind parameters to the values from the input fields
                        cmd.Parameters.AddWithValue("@TN", LabTestTb.Text);
                        cmd.Parameters.AddWithValue("@TC", LabCostTb.Text);

                        // Execute the SQL command to insert the test data
                        cmd.ExecuteNonQuery();

                        // Show a success message
                        MessageBox.Show("Lab Test Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear input fields
                        ClearFields();

                        // Close the database connection
                        con.Close();

                        // Display updated list of tests
                        DisplayTest();
                    }
                    catch (Exception ex)
                    {
                        // Display an error message if an exception occurs
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            {
                //// Confirm application exit with the user
                DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Exit the application
                    this.Close();
                }
            }
        }


        int key = 0;

        private void LabCostTb_TextChanged(object sender, EventArgs e)
        {

        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (LabTestTb.Text == "" || LabCostTb.Text == "")
            {
                // Show a message if any required field is empty
                MessageBox.Show("Missing Information");
            }
            else
            {
                // Show confirmation message before updating the test data
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to update this test?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open(); // Open the database connection

                        // Create a command to update test data in the database
                        SqlCommand cmd = new SqlCommand("Update TestTbl set TestName=@TN, TestCost=@TC where TestNum=@TKey", con);

                        // Bind parameters to the values from the input fields
                        cmd.Parameters.AddWithValue("@TN", LabTestTb.Text);
                        cmd.Parameters.AddWithValue("@TC", LabCostTb.Text);
                        cmd.Parameters.AddWithValue("@TKey", Key);

                        // Execute the SQL command to update the test data
                        cmd.ExecuteNonQuery();

                        // Show a success message
                        MessageBox.Show("Test Updated");

                        // Clear input fields
                        ClearFields();

                        // Close the database connection
                        con.Close();

                        // Display updated list of tests
                        DisplayTest();
                    }
                    catch (Exception ex)
                    {
                        // Display an error message if an exception occurs
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void LabTestDGV_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void LabTestDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            LabTestTb.Text = LabTestDGV.SelectedRows[0].Cells[1].Value.ToString();
            LabCostTb.Text = LabTestDGV.SelectedRows[0].Cells[2].Value.ToString();

            // Check if LabCostTb is empty
            if (LabCostTb.Text == "")
            {
                // If LabCostTb is empty, set Key to 0
                Key = 0;
            }
            else
            {
                // If LabCostTb is not empty, convert the value from the first column of the selected row to an integer and assign it to Key
                Key = Convert.ToInt32(LabTestDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }


        private void LabCostTb_KeyPress(object sender, KeyPressEventArgs e)
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
            Homes obj = new Homes();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
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

        private void DelBtn_Click(object sender, EventArgs e)
        {
            // Check if a lab test has been selected
            if (key == 0)
            {
                // Show a message to select a lab test
                MessageBox.Show("Select the Lab Test");
            }
            else
            {
                // Show confirmation message before deleting the lab test
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this lab test?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        // Create a delete command and execute it
                        SqlCommand cmd = new SqlCommand("DELETE FROM TestTbl WHERE TestNum=@TKey", con);
                        cmd.Parameters.AddWithValue("@TKey", key);
                        cmd.ExecuteNonQuery();

                        // Close the database connection
                        con.Close();

                        // Show a success message
                        MessageBox.Show("Lab Test Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh the displayed lab test list
                        DisplayTest();

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
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to clear the input fields?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                ClearFields();

                // Show a success message after clearing the fields
                MessageBox.Show("Input fields cleared successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    bool isValidId = int.TryParse(searchKeyword, out int TestNum);

                    // Define a SQL query to retrieve data based on the search criteria
                    string query;

                    if (isValidId)
                    {
                        // If it's a valid ID, set the parameter for ID search
                        query = "SELECT * FROM TestTbl WHERE TestNum = @SearchId";
                    }
                    else
                    {
                        // If it's not a valid ID, set the parameter for name search
                        query = "SELECT * FROM TestTbl WHERE TestName LIKE @SearchName";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);

                    if (isValidId)
                    {
                        // If it's a valid ID, set the parameter for ID search
                        cmd.Parameters.AddWithValue("@SearchId", TestNum);
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
                            MessageBox.Show("Invalid Test Name or Invalid ID", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // Bind the data table to a DataGridView 
                        LabTestDGV.DataSource = dataTable;
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
                DisplayTest(); // Create a function to display all data
            }
        }

        private void searchTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void LabTests_Load(object sender, EventArgs e)
        {

        }

        private void LabCostTb_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}