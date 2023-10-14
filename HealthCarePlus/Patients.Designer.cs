namespace HealthCarePlus
{
    partial class Patients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patients));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PatGenCb = new System.Windows.Forms.ComboBox();
            this.EditBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.AddBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.DelBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.PatHIVCb = new System.Windows.Forms.ComboBox();
            this.PatDOB = new Bunifu.Framework.UI.BunifuDatepicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PatAddTb = new System.Windows.Forms.TextBox();
            this.PatAllergiesTb = new System.Windows.Forms.TextBox();
            this.PatPhoneTb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.ClearBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PatNameTb = new System.Windows.Forms.TextBox();
            this.PatientsDGV = new Guna.UI.WinForms.GunaDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.PrescriptionLbl = new System.Windows.Forms.Label();
            this.HomeLbl = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.NurseLbl = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RepLbl = new System.Windows.Forms.Label();
            this.LabLbl = new System.Windows.Forms.Label();
            this.PatLbl = new System.Windows.Forms.Label();
            this.DocLb = new System.Windows.Forms.Label();
            this.SearchBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.searchTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatientsDGV)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PatGenCb
            // 
            this.PatGenCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatGenCb.FormattingEnabled = true;
            this.PatGenCb.Items.AddRange(new object[] {
            "Male ",
            "Female"});
            this.PatGenCb.Location = new System.Drawing.Point(489, 101);
            this.PatGenCb.Name = "PatGenCb";
            this.PatGenCb.Size = new System.Drawing.Size(93, 28);
            this.PatGenCb.TabIndex = 27;
            this.PatGenCb.Text = "Select";
            this.PatGenCb.SelectedIndexChanged += new System.EventHandler(this.PatGenCb_SelectedIndexChanged);
            this.PatGenCb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PatGenCb_KeyPress);
            // 
            // EditBtn
            // 
            this.EditBtn.ActiveBorderThickness = 1;
            this.EditBtn.ActiveCornerRadius = 20;
            this.EditBtn.ActiveFillColor = System.Drawing.Color.Silver;
            this.EditBtn.ActiveForecolor = System.Drawing.Color.White;
            this.EditBtn.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.EditBtn.BackColor = System.Drawing.Color.White;
            this.EditBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditBtn.BackgroundImage")));
            this.EditBtn.ButtonText = "Edit";
            this.EditBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.EditBtn.IdleBorderThickness = 1;
            this.EditBtn.IdleCornerRadius = 20;
            this.EditBtn.IdleFillColor = System.Drawing.Color.SeaGreen;
            this.EditBtn.IdleForecolor = System.Drawing.Color.White;
            this.EditBtn.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.EditBtn.Location = new System.Drawing.Point(866, 314);
            this.EditBtn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(121, 41);
            this.EditBtn.TabIndex = 30;
            this.EditBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.ActiveBorderThickness = 1;
            this.AddBtn.ActiveCornerRadius = 20;
            this.AddBtn.ActiveFillColor = System.Drawing.Color.Silver;
            this.AddBtn.ActiveForecolor = System.Drawing.Color.White;
            this.AddBtn.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.AddBtn.BackColor = System.Drawing.Color.White;
            this.AddBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddBtn.BackgroundImage")));
            this.AddBtn.ButtonText = "Add";
            this.AddBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.AddBtn.IdleBorderThickness = 1;
            this.AddBtn.IdleCornerRadius = 20;
            this.AddBtn.IdleFillColor = System.Drawing.Color.Black;
            this.AddBtn.IdleForecolor = System.Drawing.Color.White;
            this.AddBtn.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.AddBtn.Location = new System.Drawing.Point(711, 314);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(121, 41);
            this.AddBtn.TabIndex = 29;
            this.AddBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // DelBtn
            // 
            this.DelBtn.ActiveBorderThickness = 1;
            this.DelBtn.ActiveCornerRadius = 20;
            this.DelBtn.ActiveFillColor = System.Drawing.Color.Silver;
            this.DelBtn.ActiveForecolor = System.Drawing.Color.White;
            this.DelBtn.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.DelBtn.BackColor = System.Drawing.Color.White;
            this.DelBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DelBtn.BackgroundImage")));
            this.DelBtn.ButtonText = "Delete";
            this.DelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.DelBtn.IdleBorderThickness = 1;
            this.DelBtn.IdleCornerRadius = 20;
            this.DelBtn.IdleFillColor = System.Drawing.Color.Maroon;
            this.DelBtn.IdleForecolor = System.Drawing.Color.White;
            this.DelBtn.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.DelBtn.Location = new System.Drawing.Point(558, 314);
            this.DelBtn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(121, 41);
            this.DelBtn.TabIndex = 28;
            this.DelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // PatHIVCb
            // 
            this.PatHIVCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatHIVCb.FormattingEnabled = true;
            this.PatHIVCb.Items.AddRange(new object[] {
            "Positive ",
            "Negative"});
            this.PatHIVCb.Location = new System.Drawing.Point(614, 101);
            this.PatHIVCb.Name = "PatHIVCb";
            this.PatHIVCb.Size = new System.Drawing.Size(107, 28);
            this.PatHIVCb.TabIndex = 31;
            this.PatHIVCb.Text = "Select";
            this.PatHIVCb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PatHIVCb_KeyPress);
            // 
            // PatDOB
            // 
            this.PatDOB.BackColor = System.Drawing.Color.White;
            this.PatDOB.BorderRadius = 0;
            this.PatDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatDOB.ForeColor = System.Drawing.Color.Black;
            this.PatDOB.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.PatDOB.FormatCustom = null;
            this.PatDOB.Location = new System.Drawing.Point(259, 202);
            this.PatDOB.Margin = new System.Windows.Forms.Padding(11, 8, 11, 8);
            this.PatDOB.Name = "PatDOB";
            this.PatDOB.Size = new System.Drawing.Size(178, 45);
            this.PatDOB.TabIndex = 35;
            this.PatDOB.Value = new System.DateTime(2023, 8, 27, 20, 53, 45, 751);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(260, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 24);
            this.label9.TabIndex = 34;
            this.label9.Text = "Date Of Birth";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(260, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 24);
            this.label7.TabIndex = 32;
            this.label7.Text = "Patients Name";
            // 
            // PatAddTb
            // 
            this.PatAddTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatAddTb.Location = new System.Drawing.Point(938, 120);
            this.PatAddTb.Multiline = true;
            this.PatAddTb.Name = "PatAddTb";
            this.PatAddTb.Size = new System.Drawing.Size(195, 127);
            this.PatAddTb.TabIndex = 39;
            // 
            // PatAllergiesTb
            // 
            this.PatAllergiesTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatAllergiesTb.Location = new System.Drawing.Point(737, 120);
            this.PatAllergiesTb.Multiline = true;
            this.PatAllergiesTb.Name = "PatAllergiesTb";
            this.PatAllergiesTb.Size = new System.Drawing.Size(195, 127);
            this.PatAllergiesTb.TabIndex = 38;
            // 
            // PatPhoneTb
            // 
            this.PatPhoneTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatPhoneTb.Location = new System.Drawing.Point(489, 217);
            this.PatPhoneTb.Name = "PatPhoneTb";
            this.PatPhoneTb.Size = new System.Drawing.Size(195, 26);
            this.PatPhoneTb.TabIndex = 37;
            this.PatPhoneTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PatPhoneTb_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(485, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 24);
            this.label6.TabIndex = 36;
            this.label6.Text = "Phone";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(962, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 24);
            this.label11.TabIndex = 41;
            this.label11.Text = "Address";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(761, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 24);
            this.label10.TabIndex = 40;
            this.label10.Text = "Allergies";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 35;
            this.bunifuElipse1.TargetControl = this;
            // 
            // ClearBtn
            // 
            this.ClearBtn.ActiveBorderThickness = 1;
            this.ClearBtn.ActiveCornerRadius = 20;
            this.ClearBtn.ActiveFillColor = System.Drawing.Color.Silver;
            this.ClearBtn.ActiveForecolor = System.Drawing.Color.White;
            this.ClearBtn.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.ClearBtn.BackColor = System.Drawing.Color.White;
            this.ClearBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ClearBtn.BackgroundImage")));
            this.ClearBtn.ButtonText = "Clear ";
            this.ClearBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.ClearBtn.IdleBorderThickness = 1;
            this.ClearBtn.IdleCornerRadius = 20;
            this.ClearBtn.IdleFillColor = System.Drawing.Color.DimGray;
            this.ClearBtn.IdleForecolor = System.Drawing.Color.Black;
            this.ClearBtn.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.ClearBtn.Location = new System.Drawing.Point(1020, 314);
            this.ClearBtn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(121, 41);
            this.ClearBtn.TabIndex = 43;
            this.ClearBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(1124, 5);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(32, 30);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 51;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(513, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(242, 33);
            this.label8.TabIndex = 52;
            this.label8.Text = "HealthCare Plus";
            // 
            // PatNameTb
            // 
            this.PatNameTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatNameTb.Location = new System.Drawing.Point(259, 101);
            this.PatNameTb.Name = "PatNameTb";
            this.PatNameTb.Size = new System.Drawing.Size(195, 26);
            this.PatNameTb.TabIndex = 54;
            this.PatNameTb.TextChanged += new System.EventHandler(this.PatNameTb_TextChanged);
            // 
            // PatientsDGV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.PatientsDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.PatientsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PatientsDGV.BackgroundColor = System.Drawing.Color.White;
            this.PatientsDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PatientsDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.PatientsDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PatientsDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.PatientsDGV.ColumnHeadersHeight = 25;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PatientsDGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.PatientsDGV.EnableHeadersVisualStyles = false;
            this.PatientsDGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.PatientsDGV.Location = new System.Drawing.Point(252, 392);
            this.PatientsDGV.Name = "PatientsDGV";
            this.PatientsDGV.ReadOnly = true;
            this.PatientsDGV.RowHeadersVisible = false;
            this.PatientsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PatientsDGV.Size = new System.Drawing.Size(898, 283);
            this.PatientsDGV.TabIndex = 84;
            this.PatientsDGV.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.PatientsDGV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.PatientsDGV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.PatientsDGV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.PatientsDGV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.PatientsDGV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.PatientsDGV.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.PatientsDGV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.PatientsDGV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.DimGray;
            this.PatientsDGV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.PatientsDGV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatientsDGV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.PatientsDGV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.PatientsDGV.ThemeStyle.HeaderStyle.Height = 25;
            this.PatientsDGV.ThemeStyle.ReadOnly = true;
            this.PatientsDGV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.PatientsDGV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.PatientsDGV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatientsDGV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.PatientsDGV.ThemeStyle.RowsStyle.Height = 22;
            this.PatientsDGV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.PatientsDGV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.PatientsDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PatientsDGV_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.pictureBox9);
            this.panel1.Controls.Add(this.PrescriptionLbl);
            this.panel1.Controls.Add(this.HomeLbl);
            this.panel1.Controls.Add(this.pictureBox8);
            this.panel1.Controls.Add(this.pictureBox13);
            this.panel1.Controls.Add(this.NurseLbl);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.RepLbl);
            this.panel1.Controls.Add(this.LabLbl);
            this.panel1.Controls.Add(this.PatLbl);
            this.panel1.Controls.Add(this.DocLb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 687);
            this.panel1.TabIndex = 85;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(23, 177);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(57, 42);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 28;
            this.pictureBox9.TabStop = false;
            // 
            // PrescriptionLbl
            // 
            this.PrescriptionLbl.AutoSize = true;
            this.PrescriptionLbl.BackColor = System.Drawing.Color.Transparent;
            this.PrescriptionLbl.ForeColor = System.Drawing.Color.Black;
            this.PrescriptionLbl.Location = new System.Drawing.Point(89, 189);
            this.PrescriptionLbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.PrescriptionLbl.Name = "PrescriptionLbl";
            this.PrescriptionLbl.Size = new System.Drawing.Size(131, 24);
            this.PrescriptionLbl.TabIndex = 27;
            this.PrescriptionLbl.Text = "Prescriptions";
            this.PrescriptionLbl.Click += new System.EventHandler(this.PrescriptionLbl_Click);
            // 
            // HomeLbl
            // 
            this.HomeLbl.AutoSize = true;
            this.HomeLbl.BackColor = System.Drawing.Color.Transparent;
            this.HomeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeLbl.ForeColor = System.Drawing.Color.Black;
            this.HomeLbl.Location = new System.Drawing.Point(89, 128);
            this.HomeLbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.HomeLbl.Name = "HomeLbl";
            this.HomeLbl.Size = new System.Drawing.Size(66, 24);
            this.HomeLbl.TabIndex = 26;
            this.HomeLbl.Text = "Home";
            this.HomeLbl.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(23, 112);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(57, 42);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 24;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox13.Image")));
            this.pictureBox13.Location = new System.Drawing.Point(23, 388);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(57, 42);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox13.TabIndex = 14;
            this.pictureBox13.TabStop = false;
            // 
            // NurseLbl
            // 
            this.NurseLbl.AutoSize = true;
            this.NurseLbl.BackColor = System.Drawing.Color.Transparent;
            this.NurseLbl.ForeColor = System.Drawing.Color.Black;
            this.NurseLbl.Location = new System.Drawing.Point(89, 400);
            this.NurseLbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NurseLbl.Name = "NurseLbl";
            this.NurseLbl.Size = new System.Drawing.Size(66, 24);
            this.NurseLbl.TabIndex = 13;
            this.NurseLbl.Text = "Nurse";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(37, 12);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(98, 65);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 10;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(46, 620);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(34, 31);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(23, 534);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(57, 42);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(23, 455);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(57, 42);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(23, 321);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 245);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(95, 630);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "LogOut";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // RepLbl
            // 
            this.RepLbl.AutoSize = true;
            this.RepLbl.BackColor = System.Drawing.Color.Transparent;
            this.RepLbl.ForeColor = System.Drawing.Color.Black;
            this.RepLbl.Location = new System.Drawing.Point(89, 546);
            this.RepLbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.RepLbl.Name = "RepLbl";
            this.RepLbl.Size = new System.Drawing.Size(125, 24);
            this.RepLbl.TabIndex = 3;
            this.RepLbl.Text = "Receptionist";
            // 
            // LabLbl
            // 
            this.LabLbl.AutoSize = true;
            this.LabLbl.BackColor = System.Drawing.Color.Transparent;
            this.LabLbl.ForeColor = System.Drawing.Color.Black;
            this.LabLbl.Location = new System.Drawing.Point(89, 467);
            this.LabLbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LabLbl.Name = "LabLbl";
            this.LabLbl.Size = new System.Drawing.Size(95, 24);
            this.LabLbl.TabIndex = 2;
            this.LabLbl.Text = "Laboarty ";
            // 
            // PatLbl
            // 
            this.PatLbl.AutoSize = true;
            this.PatLbl.BackColor = System.Drawing.Color.Transparent;
            this.PatLbl.ForeColor = System.Drawing.Color.Black;
            this.PatLbl.Location = new System.Drawing.Point(89, 257);
            this.PatLbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.PatLbl.Name = "PatLbl";
            this.PatLbl.Size = new System.Drawing.Size(83, 24);
            this.PatLbl.TabIndex = 1;
            this.PatLbl.Text = "Patients";
            // 
            // DocLb
            // 
            this.DocLb.AutoSize = true;
            this.DocLb.BackColor = System.Drawing.Color.Transparent;
            this.DocLb.ForeColor = System.Drawing.Color.Black;
            this.DocLb.Location = new System.Drawing.Point(89, 332);
            this.DocLb.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.DocLb.Name = "DocLb";
            this.DocLb.Size = new System.Drawing.Size(71, 24);
            this.DocLb.TabIndex = 0;
            this.DocLb.Text = "Doctor";
            // 
            // SearchBtn
            // 
            this.SearchBtn.ActiveBorderThickness = 1;
            this.SearchBtn.ActiveCornerRadius = 20;
            this.SearchBtn.ActiveFillColor = System.Drawing.Color.Silver;
            this.SearchBtn.ActiveForecolor = System.Drawing.Color.White;
            this.SearchBtn.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.SearchBtn.BackColor = System.Drawing.Color.White;
            this.SearchBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SearchBtn.BackgroundImage")));
            this.SearchBtn.ButtonText = "Search";
            this.SearchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.SearchBtn.IdleBorderThickness = 1;
            this.SearchBtn.IdleCornerRadius = 20;
            this.SearchBtn.IdleFillColor = System.Drawing.Color.Silver;
            this.SearchBtn.IdleForecolor = System.Drawing.Color.White;
            this.SearchBtn.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.SearchBtn.Location = new System.Drawing.Point(693, 257);
            this.SearchBtn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(83, 41);
            this.SearchBtn.TabIndex = 89;
            this.SearchBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // searchTb
            // 
            this.searchTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTb.Location = new System.Drawing.Point(489, 266);
            this.searchTb.Name = "searchTb";
            this.searchTb.Size = new System.Drawing.Size(195, 26);
            this.searchTb.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(488, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 90;
            this.label1.Text = "Gender";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(616, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 24);
            this.label2.TabIndex = 91;
            this.label2.Text = "HIV";
            // 
            // Patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 687);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.searchTb);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PatientsDGV);
            this.Controls.Add(this.PatNameTb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.PatAddTb);
            this.Controls.Add(this.PatAllergiesTb);
            this.Controls.Add(this.PatPhoneTb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PatDOB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PatHIVCb);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.DelBtn);
            this.Controls.Add(this.PatGenCb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Patients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patients";
            this.Load += new System.EventHandler(this.Patients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatientsDGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox PatGenCb;
        private Bunifu.Framework.UI.BunifuThinButton2 EditBtn;
        private Bunifu.Framework.UI.BunifuThinButton2 AddBtn;
        private Bunifu.Framework.UI.BunifuThinButton2 DelBtn;
        private System.Windows.Forms.ComboBox PatHIVCb;
        private Bunifu.Framework.UI.BunifuDatepicker PatDOB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PatAddTb;
        private System.Windows.Forms.TextBox PatAllergiesTb;
        private System.Windows.Forms.TextBox PatPhoneTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuThinButton2 ClearBtn;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PatNameTb;
        private Guna.UI.WinForms.GunaDataGridView PatientsDGV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label HomeLbl;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.Label NurseLbl;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label RepLbl;
        private System.Windows.Forms.Label LabLbl;
        private System.Windows.Forms.Label PatLbl;
        private System.Windows.Forms.Label DocLb;
        private Bunifu.Framework.UI.BunifuThinButton2 SearchBtn;
        private System.Windows.Forms.TextBox searchTb;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label PrescriptionLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}