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
    public partial class Doctors : Form
    {
        public Doctors()
        {
            InitializeComponent();
            DisplayDoc();

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
                NurseLbl.Enabled = false;   // Lab Tests section
                NurseLbl.Enabled = false;
                label3.Enabled = false;
                label4.Enabled = false;
            }

        }

        // Create a SqlConnection object to establish a connection to the database
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\HealthCarePlusDb.mdf;Integrated Security=True;Connect Timeout=30");

        //Method to display receptionist data in the DataGridView
        private void DisplayDoc()
        {
            con.Open();
            string Query = "Select * from DoctorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            DoctorDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Check if any required information is missing in the input fields
            if (DNameTb.Text == "" || DocPassTb.Text == "" || DocPhoneTb.Text == "" || DocAddTb.Text == "" || DocGenCb.SelectedIndex == -1 || DocSpecCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                // Confirm addition with the user
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to add this doctor?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        // Create a command to insert doctor data into the database
                        SqlCommand cmd = new SqlCommand("INSERT INTO DoctorTbl(DOcName, DocPhone, DOCAddress, DOCPass, DocDOB, DocGen, DocSpec, DocExp) VALUES (@DN, @DP, @DA, @DPA, @DDOB, @DG, @DS, @DE)", con);

                        // Bind parameters to the values from the input fields
                        cmd.Parameters.AddWithValue("@Dn", DNameTb.Text);
                        cmd.Parameters.AddWithValue("@Dp", DocPhoneTb.Text);
                        cmd.Parameters.AddWithValue("@DA", DocAddTb.Text);
                        cmd.Parameters.AddWithValue("@DPA", DocPassTb.Text);
                        cmd.Parameters.AddWithValue("@DDOB", DocDOB.Value.Date);
                        cmd.Parameters.AddWithValue("@DG", DocGenCb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@DS", DocSpecCb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@DE", DocexpTb.Text);
                        cmd.ExecuteNonQuery();

                        // Close the database connection
                        con.Close();

                        // Display a success message
                        MessageBox.Show("Doctor Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear input fields
                        ClearFields();

                        // Display updated list of doctors
                        DisplayDoc();
                    }
                    catch (Exception ex)
                    {
                        // Display an error message if an exception occurs
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void ClearFields()
        {
            // Clear the text in the input fields
            DNameTb.Text = "";
            DocPhoneTb.Text = "";
            DocAddTb.Text = "";
            DocPassTb.Text = "";
            DocexpTb.Text = "";
            DocDOB.Value = DateTime.Now; // Set to the current date by default
            DocGenCb.SelectedIndex = -1;
            DocSpecCb.SelectedIndex = -1;

            // Reset the selected index for ComboBoxes
            DocGenCb.SelectedIndex = 0;    // Assuming 0 is the default index
            DocSpecCb.SelectedIndex = 0;   // Assuming 0 is the default index

            // Set the DateTimePicker value to a default date if needed
            // DocDOB.Value = defaultDate;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            // Show a confirmation message before clearing fields without sound
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to clear all fields?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                ClearFields();
                // Display a success message
                MessageBox.Show("Fields Cleared Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        int key = 0;

        private void EditBtn_Click(object sender, EventArgs e)
        {
            // Check if all required information is filled
            if (DNameTb.Text == "" || DocPassTb.Text == "" || DocPhoneTb.Text == "" || DocAddTb.Text == "" || DocGenCb.SelectedIndex == -1 || DocSpecCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                // Show confirmation message before updating doctor data
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to update this doctor?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // Open the database connection
                        con.Open();

                        // Create and execute an update command
                        SqlCommand cmd = new SqlCommand("UPDATE DoctorTbl SET DOcName=@DN, DocPhone=@DP, DOCAddress=@DA, DOCPass=@DPA, DocDOB=@DDOB, DocGen=@DG, DocSpec=@DS, DocExp=@DE WHERE DocId=@DKey", con);
                        cmd.Parameters.AddWithValue("@Dn", DNameTb.Text);
                        cmd.Parameters.AddWithValue("@Dp", DocPhoneTb.Text);
                        cmd.Parameters.AddWithValue("@DA", DocAddTb.Text);
                        cmd.Parameters.AddWithValue("@DPA", DocPassTb.Text);
                        cmd.Parameters.AddWithValue("@DDOB", DocDOB.Value.Date);
                        cmd.Parameters.AddWithValue("@DG", DocGenCb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@DS", DocSpecCb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@DE", DocexpTb.Text);
                        cmd.Parameters.AddWithValue("@DKey", key); // Key of the selected doctor's row
                        cmd.ExecuteNonQuery();

                        // Display a success message
                        MessageBox.Show("Doctor Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear input fields
                        ClearFields();

                        // Close the database connection
                        con.Close();

                        // Display updated list of doctors
                        DisplayDoc();
                    }
                    catch (Exception ex)
                    {
                        // Display an error message if an exception occurs
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }


        private void DelBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                // Show a message to select a doctor
                MessageBox.Show("Select the Doctor");
            }
            else
            {
                // Confirm deletion with the user
                DialogResult result = MessageBox.Show("Are you sure you want to delete this doctor?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        // Create a delete command and execute it
                        SqlCommand cmd = new SqlCommand("DELETE FROM DoctorTbl WHERE DocId = @DKey", con);
                        cmd.Parameters.AddWithValue("@DKey", key);
                        cmd.ExecuteNonQuery();

                        con.Close();

                        // Refresh the displayed doctor list
                        DisplayDoc();

                        // Clear input fields
                        ClearFields();

                        // Show a success message
                        MessageBox.Show("Doctor Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
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

        private void DocSpecCb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cancel the key press event to prevent typing in the middle of the ComboBox
            e.Handled = true;
        }

        private void DocGenCb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cancel the key press event to prevent typing in the middle of the ComboBox
            e.Handled = true;
        }

        private void DoctorDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)

        {
            // Check if any row is selected
            if (DoctorDGV.SelectedRows.Count > 0)
            {
                // Populate textboxes with data from the selected row
                DNameTb.Text = DoctorDGV.SelectedRows[0].Cells[1].Value.ToString();
                DocGenCb.Text = DoctorDGV.SelectedRows[0].Cells[3].Value.ToString();
                DocSpecCb.Text = DoctorDGV.SelectedRows[0].Cells[4].Value.ToString();
                DocexpTb.Text = DoctorDGV.SelectedRows[0].Cells[5].Value.ToString();
                DocPhoneTb.Text = DoctorDGV.SelectedRows[0].Cells[6].Value.ToString();
                DocAddTb.Text = DoctorDGV.SelectedRows[0].Cells[8].Value.ToString();
                DocPassTb.Text = DoctorDGV.SelectedRows[0].Cells[7].Value.ToString();

                // Check if the "Dob" cell is not null and contains a valid date string
                if (DoctorDGV.SelectedRows[0].Cells[2].Value != null)
                {
                    string dobString = DoctorDGV.SelectedRows[0].Cells[2].Value.ToString();
                    if (DateTime.TryParse(dobString, out DateTime dobDate))
                    {
                        DocDOB.Value = dobDate;
                    }
                }

                // Set the 'key' value
                key = Convert.ToInt32(DoctorDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
            else
            {
                // No row is selected, reset 'key' and clear fields
                key = 0;
                DNameTb.Text = string.Empty;
                // Clear other fields as needed
            }
        }



        private void DocPhoneTb_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is a digit or control key (e.g., Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If the pressed key is not a digit or control key, suppress the key press event
                e.Handled = true;
            }

        }

        private void DocLb_Click(object sender, EventArgs e)
        {

        }

        // Click event handler for label3
        private void label3_Click(object sender, EventArgs e)
        {
            //LabTests obj = new LabTests();
            //obj.Show();
            //this.Hide();
        }


        // Click event handler for label4
        private void label4_Click(object sender, EventArgs e)
        {

        }


        // Click event handler for label5
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //Homes obj = new Homes();
            //obj.Show();
            //this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Homes obj = new Homes();
            obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void DocSpecCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            // Get the search keyword or criteria from a text box (e.g., searchTb)
            string searchKeyword = searchTb.Text;

            // Check if the search keyword is not empty
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                try
                {
                    con.Open(); // Open the database connection

                    // First, check if the search keyword is a valid ID
                    bool isValidId = int.TryParse(searchKeyword, out int doctorId);

                    // Define a SQL query to retrieve data based on the search criteria
                    string query;

                    if (isValidId)
                    {
                        query = "SELECT * FROM DoctorTbl WHERE DocId = @SearchId";
                    }
                    else
                    {
                        query = "SELECT * FROM DoctorTbl WHERE DocName LIKE @SearchName";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);

                    if (isValidId)
                    {
                        // If it's a valid ID, set the parameter for ID search
                        cmd.Parameters.AddWithValue("@SearchId", doctorId);
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
                        DoctorDGV.DataSource = dataTable;
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
                DisplayDoc(); // Create a function to display all data
            }
        }

        private void Doctors_Load(object sender, EventArgs e)
        {

        }
    }
}
