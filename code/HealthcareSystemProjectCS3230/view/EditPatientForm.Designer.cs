namespace HealthcareSystemProjectCS3230.view
{
    partial class EditPatientForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            selectPatientLabel = new Label();
            patientComboBox = new ComboBox();
            loggedInLabel = new Label();
            titleLabel = new Label();
            firstNameLabel = new Label();
            firstNameTextBox = new TextBox();
            lastNameLabel = new Label();
            lastNameTextBox = new TextBox();
            birthdateLabel = new Label();
            birthdatePicker = new DateTimePicker();
            phoneLabel = new Label();
            phoneTextBox = new TextBox();
            streetLabel = new Label();
            streetTextBox = new TextBox();
            cityLabel = new Label();
            cityTextBox = new TextBox();
            stateLabel = new Label();
            stateComboBox = new ComboBox();
            zipcodeLabel = new Label();
            zipcodeTextBox = new TextBox();
            isActiveCheckBox = new CheckBox();
            updateButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // selectPatientLabel
            // 
            selectPatientLabel.AutoSize = true;
            selectPatientLabel.Location = new System.Drawing.Point(20, 50);
            selectPatientLabel.Name = "selectPatientLabel";
            selectPatientLabel.Text = "Select patient:";
            // 
            // patientComboBox
            // 
            patientComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            patientComboBox.Location = new System.Drawing.Point(130, 47);
            patientComboBox.Name = "patientComboBox";
            patientComboBox.Size = new System.Drawing.Size(320, 23);
            patientComboBox.TabIndex = 0;
            patientComboBox.SelectedIndexChanged += patientComboBox_SelectedIndexChanged;
            // 
            // loggedInLabel
            // 
            loggedInLabel.AutoSize = true;
            loggedInLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            loggedInLabel.Location = new System.Drawing.Point(20, 15);
            loggedInLabel.Name = "loggedInLabel";
            loggedInLabel.Text = "Logged in as:";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            titleLabel.Location = new System.Drawing.Point(20, 80);
            titleLabel.Name = "titleLabel";
            titleLabel.Text = "Edit Patient";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(20, 115);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Text = "First name:";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new System.Drawing.Point(130, 112);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new System.Drawing.Size(300, 23);
            firstNameTextBox.TabIndex = 1;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(20, 150);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Text = "Last name:";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new System.Drawing.Point(130, 147);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new System.Drawing.Size(300, 23);
            lastNameTextBox.TabIndex = 2;
            // 
            // birthdateLabel
            // 
            birthdateLabel.AutoSize = true;
            birthdateLabel.Location = new System.Drawing.Point(20, 185);
            birthdateLabel.Name = "birthdateLabel";
            birthdateLabel.Text = "Birthdate:";
            // 
            // birthdatePicker
            // 
            birthdatePicker.Format = DateTimePickerFormat.Short;
            birthdatePicker.Location = new System.Drawing.Point(130, 182);
            birthdatePicker.Name = "birthdatePicker";
            birthdatePicker.Size = new System.Drawing.Size(150, 23);
            birthdatePicker.TabIndex = 3;
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new System.Drawing.Point(20, 220);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Text = "Phone (10 digits):";
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new System.Drawing.Point(130, 217);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new System.Drawing.Size(150, 23);
            phoneTextBox.TabIndex = 4;
            // 
            // streetLabel
            // 
            streetLabel.AutoSize = true;
            streetLabel.Location = new System.Drawing.Point(20, 255);
            streetLabel.Name = "streetLabel";
            streetLabel.Text = "Street:";
            // 
            // streetTextBox
            // 
            streetTextBox.Location = new System.Drawing.Point(130, 252);
            streetTextBox.Name = "streetTextBox";
            streetTextBox.Size = new System.Drawing.Size(300, 23);
            streetTextBox.TabIndex = 5;
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new System.Drawing.Point(20, 290);
            cityLabel.Name = "cityLabel";
            cityLabel.Text = "City:";
            // 
            // cityTextBox
            // 
            cityTextBox.Location = new System.Drawing.Point(130, 287);
            cityTextBox.Name = "cityTextBox";
            cityTextBox.Size = new System.Drawing.Size(200, 23);
            cityTextBox.TabIndex = 6;
            // 
            // stateLabel
            // 
            stateLabel.AutoSize = true;
            stateLabel.Location = new System.Drawing.Point(345, 290);
            stateLabel.Name = "stateLabel";
            stateLabel.Text = "State:";
            // 
            // stateComboBox
            // 
            stateComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            stateComboBox.Location = new System.Drawing.Point(390, 287);
            stateComboBox.Name = "stateComboBox";
            stateComboBox.Size = new System.Drawing.Size(80, 23);
            stateComboBox.TabIndex = 7;
            // 
            // zipcodeLabel
            // 
            zipcodeLabel.AutoSize = true;
            zipcodeLabel.Location = new System.Drawing.Point(20, 325);
            zipcodeLabel.Name = "zipcodeLabel";
            zipcodeLabel.Text = "ZIP code:";
            // 
            // zipcodeTextBox
            // 
            zipcodeTextBox.Location = new System.Drawing.Point(130, 322);
            zipcodeTextBox.Name = "zipcodeTextBox";
            zipcodeTextBox.Size = new System.Drawing.Size(100, 23);
            zipcodeTextBox.TabIndex = 8;
            // 
            // isActiveCheckBox
            // 
            isActiveCheckBox.AutoSize = true;
            isActiveCheckBox.Location = new System.Drawing.Point(130, 355);
            isActiveCheckBox.Name = "isActiveCheckBox";
            isActiveCheckBox.Text = "Active";
            isActiveCheckBox.Checked = true;
            // 
            // updateButton
            // 
            updateButton.Location = new System.Drawing.Point(250, 385);
            updateButton.Name = "updateButton";
            updateButton.Size = new System.Drawing.Size(85, 30);
            updateButton.TabIndex = 9;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new System.Drawing.Point(345, 385);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(85, 30);
            cancelButton.TabIndex = 10;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // EditPatientForm
            // 
            AcceptButton = updateButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(520, 430);
            Controls.Add(selectPatientLabel);
            Controls.Add(patientComboBox);
            Controls.Add(loggedInLabel);
            Controls.Add(titleLabel);
            Controls.Add(firstNameLabel);
            Controls.Add(firstNameTextBox);
            Controls.Add(lastNameLabel);
            Controls.Add(lastNameTextBox);
            Controls.Add(birthdateLabel);
            Controls.Add(birthdatePicker);
            Controls.Add(phoneLabel);
            Controls.Add(phoneTextBox);
            Controls.Add(streetLabel);
            Controls.Add(streetTextBox);
            Controls.Add(cityLabel);
            Controls.Add(cityTextBox);
            Controls.Add(stateLabel);
            Controls.Add(stateComboBox);
            Controls.Add(zipcodeLabel);
            Controls.Add(zipcodeTextBox);
            Controls.Add(isActiveCheckBox);
            Controls.Add(updateButton);
            Controls.Add(cancelButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditPatientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Patient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label selectPatientLabel;
        private ComboBox patientComboBox;
        private Label loggedInLabel;
        private Label titleLabel;
        private Label firstNameLabel;
        private TextBox firstNameTextBox;
        private Label lastNameLabel;
        private TextBox lastNameTextBox;
        private Label birthdateLabel;
        private DateTimePicker birthdatePicker;
        private Label phoneLabel;
        private TextBox phoneTextBox;
        private Label streetLabel;
        private TextBox streetTextBox;
        private Label cityLabel;
        private TextBox cityTextBox;
        private Label stateLabel;
        private ComboBox stateComboBox;
        private Label zipcodeLabel;
        private TextBox zipcodeTextBox;
        private CheckBox isActiveCheckBox;
        private Button updateButton;
        private Button cancelButton;
    }
}
