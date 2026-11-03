namespace HealthcareSystemProjectCS3230.view
{
    partial class PatientSearchControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle birthdateCellStyle = new DataGridViewCellStyle();
            firstNameLabel = new Label();
            firstNameTextBox = new TextBox();
            lastNameLabel = new Label();
            lastNameTextBox = new TextBox();
            searchButton = new Button();
            clearButton = new Button();
            birthdateLabel = new Label();
            birthdatePicker = new DateTimePicker();
            errorLabel = new Label();
            patientResultsGrid = new DataGridView();
            firstNameColumn = new DataGridViewTextBoxColumn();
            lastNameColumn = new DataGridViewTextBoxColumn();
            birthdateColumn = new DataGridViewTextBoxColumn();
            genderColumn = new DataGridViewTextBoxColumn();
            phoneNumberColumn = new DataGridViewTextBoxColumn();
            addressColumn = new DataGridViewTextBoxColumn();
            isActiveColumn = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)patientResultsGrid).BeginInit();
            SuspendLayout();
            //
            // firstNameLabel
            //
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(10, 13);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Text = "First name:";
            //
            // firstNameTextBox
            //
            firstNameTextBox.Location = new Point(90, 10);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(220, 23);
            firstNameTextBox.TabIndex = 0;
            //
            // lastNameLabel
            //
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(325, 13);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Text = "Last name:";
            //
            // lastNameTextBox
            //
            lastNameTextBox.Location = new Point(400, 10);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(180, 23);
            lastNameTextBox.TabIndex = 1;
            //
            // searchButton
            //
            searchButton.Location = new Point(595, 9);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 25);
            searchButton.TabIndex = 3;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            //
            // clearButton
            //
            clearButton.Location = new Point(675, 9);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(75, 25);
            clearButton.TabIndex = 4;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            //
            // birthdateLabel
            //
            birthdateLabel.AutoSize = true;
            birthdateLabel.Location = new Point(10, 48);
            birthdateLabel.Name = "birthdateLabel";
            birthdateLabel.Text = "Birthdate:";
            //
            // birthdatePicker
            //
            birthdatePicker.Checked = false;
            birthdatePicker.Format = DateTimePickerFormat.Short;
            birthdatePicker.Location = new Point(90, 45);
            birthdatePicker.Name = "birthdatePicker";
            birthdatePicker.ShowCheckBox = true;
            birthdatePicker.Size = new Size(220, 23);
            birthdatePicker.TabIndex = 2;
            //
            // errorLabel
            //
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Firebrick;
            errorLabel.Location = new Point(325, 48);
            errorLabel.MaximumSize = new Size(425, 0);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 15);
            //
            // patientResultsGrid
            //
            patientResultsGrid.AllowUserToAddRows = false;
            patientResultsGrid.AllowUserToDeleteRows = false;
            patientResultsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            patientResultsGrid.AutoGenerateColumns = false;
            patientResultsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            patientResultsGrid.Columns.AddRange(new DataGridViewColumn[] { firstNameColumn, lastNameColumn, birthdateColumn, genderColumn, phoneNumberColumn, addressColumn, isActiveColumn });
            patientResultsGrid.Location = new Point(10, 80);
            patientResultsGrid.MultiSelect = false;
            patientResultsGrid.Name = "patientResultsGrid";
            patientResultsGrid.ReadOnly = true;
            patientResultsGrid.ScrollBars = ScrollBars.Both;
            patientResultsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            patientResultsGrid.Size = new Size(740, 210);
            patientResultsGrid.TabIndex = 5;
            patientResultsGrid.CellDoubleClick += patientResultsGrid_CellDoubleClick;
            patientResultsGrid.CellFormatting += patientResultsGrid_CellFormatting;
            patientResultsGrid.DataBindingComplete += patientResultsGrid_DataBindingComplete;
            patientResultsGrid.SelectionChanged += patientResultsGrid_SelectionChanged;
            //
            // firstNameColumn
            //
            firstNameColumn.DataPropertyName = "FirstName";
            firstNameColumn.HeaderText = "First Name";
            firstNameColumn.MinimumWidth = 120;
            firstNameColumn.Name = "firstNameColumn";
            firstNameColumn.ReadOnly = true;
            //
            // lastNameColumn
            //
            lastNameColumn.DataPropertyName = "LastName";
            lastNameColumn.HeaderText = "Last Name";
            lastNameColumn.MinimumWidth = 120;
            lastNameColumn.Name = "lastNameColumn";
            lastNameColumn.ReadOnly = true;
            //
            // birthdateColumn
            //
            birthdateCellStyle.Format = "d";
            birthdateColumn.DataPropertyName = "Birthdate";
            birthdateColumn.DefaultCellStyle = birthdateCellStyle;
            birthdateColumn.HeaderText = "Birthdate";
            birthdateColumn.MinimumWidth = 90;
            birthdateColumn.Name = "birthdateColumn";
            birthdateColumn.ReadOnly = true;
            //
            // genderColumn
            //
            genderColumn.DataPropertyName = "Gender";
            genderColumn.FillWeight = 60F;
            genderColumn.HeaderText = "Gender";
            genderColumn.MinimumWidth = 70;
            genderColumn.Name = "genderColumn";
            genderColumn.ReadOnly = true;
            //
            // phoneNumberColumn
            //
            phoneNumberColumn.DataPropertyName = "PhoneNumber";
            phoneNumberColumn.HeaderText = "Phone Number";
            phoneNumberColumn.MinimumWidth = 110;
            phoneNumberColumn.Name = "phoneNumberColumn";
            phoneNumberColumn.ReadOnly = true;
            //
            // addressColumn
            //
            addressColumn.DataPropertyName = "Address";
            addressColumn.HeaderText = "Address";
            addressColumn.MinimumWidth = 250;
            addressColumn.Name = "addressColumn";
            addressColumn.ReadOnly = true;
            //
            // isActiveColumn
            //
            isActiveColumn.DataPropertyName = "IsActive";
            isActiveColumn.FillWeight = 55F;
            isActiveColumn.HeaderText = "Active";
            isActiveColumn.MinimumWidth = 55;
            isActiveColumn.Name = "isActiveColumn";
            isActiveColumn.ReadOnly = true;
            //
            // PatientSearchControl
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(firstNameLabel);
            Controls.Add(firstNameTextBox);
            Controls.Add(lastNameLabel);
            Controls.Add(lastNameTextBox);
            Controls.Add(searchButton);
            Controls.Add(clearButton);
            Controls.Add(birthdateLabel);
            Controls.Add(birthdatePicker);
            Controls.Add(errorLabel);
            Controls.Add(patientResultsGrid);
            Name = "PatientSearchControl";
            Size = new Size(760, 300);
            ((System.ComponentModel.ISupportInitialize)patientResultsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label firstNameLabel;
        private TextBox firstNameTextBox;
        private Label lastNameLabel;
        private TextBox lastNameTextBox;
        private Button searchButton;
        private Button clearButton;
        private Label birthdateLabel;
        private DateTimePicker birthdatePicker;
        private Label errorLabel;
        private DataGridView patientResultsGrid;
        private DataGridViewTextBoxColumn firstNameColumn;
        private DataGridViewTextBoxColumn lastNameColumn;
        private DataGridViewTextBoxColumn birthdateColumn;
        private DataGridViewTextBoxColumn genderColumn;
        private DataGridViewTextBoxColumn phoneNumberColumn;
        private DataGridViewTextBoxColumn addressColumn;
        private DataGridViewCheckBoxColumn isActiveColumn;
    }
}