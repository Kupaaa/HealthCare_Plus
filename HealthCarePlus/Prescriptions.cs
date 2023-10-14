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
using static System.Net.Mime.MediaTypeNames;

namespace HealthCarePlus
{
    public partial class Prescriptions : Form
    {
        public Prescriptions()
        {
            InitializeComponent();

            if (Login.Role == "Receptionist")
            {
                // Disable access to specific sections for a Receptionist role
                //RepLbl.Enabled = false;   // Receptionists section
                //DocLb.Enabled = false;    // Doctors section
                //LabLbl.Enabled = false;   // Lab Tests section
                //NurseLbl.Enabled = false;
                //PatLbl.Enabled = false;

                // Additional logic specific to the Receptionist role here
            }
            else if (Login.Role == "Doctor")
            {

                // Additional logic specific to the Doctor role here
                HomeLbl.Enabled = false;   // Receptionists section
                DocLbl.Enabled = false;    // Doctors section
                NurseLbl.Enabled = false;   // Lab Tests section
                NurseLbl.Enabled = false;
                LabLbl.Enabled = false;
                RecLbl.Enabled=false;
                //PatLbl.Enabled = false;
                //    DelBtn.Visible = false;
                //    AddBtn.Visible = false;
                //    EditBtn.Visible = false;
                //    ClearBtn.Visible = false;
            }
            else
            {
                // Logic for other roles here
            }

            // Call the method to display prescriptions
            DisplayPrescriptions();

            // Call methods to retrieve specific IDs
            GetDocId();
            GetTestId();
            GetPatientId();


        }


        // Create a SqlConnection object to establish a connection to the database
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\HealthCarePlusDb.mdf;Integrated Security=True;Connect Timeout=30");

        //Method to display Prescription data in the DataGridView
        private void DisplayPrescriptions()
        {
            con.Open();
            string Query = "Select * from PrescriptionTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            PrescriptionsDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        //int Key = 0;



        // This method retrieves the name of a doctor based on the selected DocId from the combobox.
        private void GetDocName()
        {
            con.Open();
            string Query = "Select * from DoctorTbl where DocId=" + DocIdCb.SelectedValue.ToString() + "";
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


        // This method retrieves the name of a patient based on the selected PatId from the combobox.
        private void GetPatName()
        {

            con.Open();
            string Query = "Select * from PatientTbl where PatId=" + PatIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, con);

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            // Loop through each row in the DataTable (usually only one row in this case).
            foreach (DataRow dr in dt.Rows)
            {
                // Set the text of a TextBox control (PatNameTb) to the "PatName" value from the row.
                PatNameTb.Text = dr["PatName"].ToString();
            }
            con.Close();
        }


        // This method retrieves test information based on the selected TestNum and updates UI fields.
        private void GetTest()
        {
            con.Open();

            // Construct a SQL query to select all fields from TestTbl where TestNum matches the selected value.
            string Query = "Select * from TestTbl where TestNum=" + TestIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, con); // Create a SQL command with the query and connection.

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            // Loop through each row in the DataTable (usually only one row in this case).
            foreach (DataRow dr in dt.Rows)
            {
                // Set the text of TextBox controls (TestTb and CostTb) with values from the row.
                TestTb.Text = dr["TestName"].ToString(); // Set the test name.
                CostTb.Text = dr["TestCost"].ToString(); // Set the test cost.
            }
            con.Close();
        }



        // Clear method
        private void ClearFields()
        {
            //Clear values in the input fields
            DocIdCb.SelectedIndex = 0;
            PatIdCb.SelectedItem = 0;
            TestIdCb.SelectedItem = 0;
            CostTb.Text = "";
            MedTb.Text = "";
            DocNameTb.Text = "";
            PatNameTb.Text = "";
            PatNameTb.Text = "";


            //Key = 0;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is a digit or control key (e.g., Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If the pressed key is not a digit or control key, suppress the key press event
                e.Handled = true;
            }

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            // Confirm application exit with the user
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check if the user clicked "Yes" in the confirmation dialog
            if (result == DialogResult.Yes)
            {
                // Exit the application
                System.Windows.Forms.Application.Exit();
            }
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
            DocIdCb.ValueMember = "DocId";
            DocIdCb.DataSource = dt;
            con.Close();
        }


        //This method retrieves Patient IDs from the database and populates them into a ComboBox.
        private void GetPatientId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select PatId From PatientTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PatId", typeof(int));
            dt.Load(rdr);
            PatIdCb.ValueMember = "PatId";
            PatIdCb.DataSource = dt;
            con.Close();
        }

        //This method retrieves Test IDs from the database and populates them into a ComboBox.
        private void GetTestId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select TestNum From TestTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TestNum", typeof(int));
            dt.Load(rdr);
            TestIdCb.ValueMember = "TestNum";
            TestIdCb.DataSource = dt;
            con.Close();
        }


        // Event handler for the "Add" button click
        private void AddBtbn_Click(object sender, EventArgs e)
        {
            // Check if any required information is missing in the input fields
            if (PatNameTb.Text == "" || DocNameTb.Text == "" || TestTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                // Show confirmation message before adding the prescription
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to add this prescription?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    // Check if CostTb.Text can be parsed to an integer
                    if (int.TryParse(CostTb.Text, out int cost))
                    {
                        try
                        {
                            con.Open();
                            // Create a SQL command to insert prescription data into the database
                            SqlCommand cmd = new SqlCommand("INSERT INTO PrescriptionTbl(DocId, DocName, PatId, PatName, LabTestId, LabTestName, Medicines, Cost) VALUES (@DI, @DN, @PI, @PN, @TI, @TN, @Med, @Co)", con);

                            // Bind parameters to the values from the input fields
                            cmd.Parameters.AddWithValue("@DI", DocIdCb.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@DN", DocNameTb.Text);
                            cmd.Parameters.AddWithValue("@PI", PatIdCb.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@PN", PatNameTb.Text);
                            cmd.Parameters.AddWithValue("@TI", TestIdCb.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@TN", TestTb.Text);
                            cmd.Parameters.AddWithValue("@Med", MedTb.Text);
                            cmd.Parameters.AddWithValue("@Co", cost); // Use the parsed integer value

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Prescription Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            con.Close();
                            DisplayPrescriptions();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid cost value. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void DocIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetDocName();

        }

        private void PatIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetPatName();
        }

        private void TestIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetTest();

        }

        private void PrescriptionsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the text box
            PrescSumTxt.Clear();

            // Set text box properties for a nicer appearance
            PrescSumTxt.Font = new Font("Arial", 12);
            PrescSumTxt.BackColor = Color.White;
            PrescSumTxt.ForeColor = Color.Black;
            PrescSumTxt.Multiline = true;

            // Construct the prescription summary text with formatting
            string summaryText = $@"
HealthCare Plus

PRESCRIPTION
*********************************************

Date: {DateTime.Today.Date}

Doctor: {PrescriptionsDGV.SelectedRows[0].Cells[2].Value}
Patient: {PrescriptionsDGV.SelectedRows[0].Cells[4].Value}
Test: {PrescriptionsDGV.SelectedRows[0].Cells[5].Value}
Medicines: {PrescriptionsDGV.SelectedRows[0].Cells[6].Value}
Cost: {PrescriptionsDGV.SelectedRows[0].Cells[7].Value}

HealthCarePlus
   ";

            // Add spacing
            string formattedText = AddSpacing(summaryText);

            // Set the alignment of the text within the RichTextBox
            PrescSumTxt.SelectionAlignment = HorizontalAlignment.Center;
            PrescSumTxt.AppendText(formattedText);

            // Format specific lines as bold 
            FormatLinesAsBold(PrescSumTxt, "Doctor:");
            FormatLinesAsBold(PrescSumTxt, "Patient:");
            FormatLinesAsBold(PrescSumTxt, "Test");
            FormatLinesAsBold(PrescSumTxt, "Medicines:");
            FormatLinesAsBold(PrescSumTxt, "Cost:");
        }

        private string AddSpacing(string inputText)
        {
            // Split the input text by lines and add spacing
            string[] lines = inputText.Split('\n');
            return string.Join("\n\n", lines);
        }

        private void FormatLinesAsBold(RichTextBox richTextBox, string targetLine)
        {
            // Find all occurrences of the target line
            int index = 0;
            while (index < richTextBox.TextLength)
            {
                int targetStart = richTextBox.Find(targetLine, index, RichTextBoxFinds.WholeWord);
                if (targetStart == -1)
                    break;

                // Apply bold formatting
                richTextBox.Select(targetStart, targetLine.Length);
                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);

                // Move to the next occurrence
                index = targetStart + targetLine.Length;
            }
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            // Show a confirmation dialog before initiating the printing process
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to print?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                // Show the print preview dialog
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Initiate the printing process
                    printDocument1.Print();
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Define fonts
            Font titleFont = new Font("Averia", 18, FontStyle.Regular);
            Font footerFont = new Font("Averia", 15, FontStyle.Bold);

            // Define brushes
            Brush titleBrush = Brushes.Black;
            Brush footerBrush = Brushes.Red;

            // Define positions
            Point titlePosition = new Point(95, 80);
            Point footerPosition = new Point(200, 300);

            // Print prescription summary text
            e.Graphics.DrawString(PrescSumTxt.Text + "\n", titleFont, titleBrush, titlePosition);

            // Print "Thanks" message
            //e.Graphics.DrawString("\n\t" + "Thanks", footerFont, footerBrush, footerPosition);
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Patients obj = new Patients();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void DocLbl_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DocIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DocNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Prescriptions_Load(object sender, EventArgs e)
        {

        }

        private void PrescSumTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
