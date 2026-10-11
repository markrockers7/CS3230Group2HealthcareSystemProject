namespace HealthcareSystemProjectCS3230.view
{
    partial class RegisterPatientForm
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
            genderLabel = new Label();
            genderComboBox = new ComboBox();
            streetLabel = new Label();
            streetTextBox = new TextBox();
            cityLabel = new Label();
            cityTextBox = new TextBox();
            stateLabel = new Label();
            stateComboBox = new ComboBox();
            zipcodeLabel = new Label();
            zipcodeTextBox = new TextBox();
            saveButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
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
            titleLabel.Location = new System.Drawing.Point(20, 45);
            titleLabel.Name = "titleLabel";
            titleLabel.Text = "Register Patient";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(20, 90);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Text = "First name:";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new System.Drawing.Point(130, 87);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new System.Drawing.Size(300, 23);
            firstNameTextBox.TabIndex = 0;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(20, 125);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Text = "Last name:";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new System.Drawing.Point(130, 122);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new System.Drawing.Size(300, 23);
            lastNameTextBox.TabIndex = 1;
            // 
            // birthdateLabel
            // 
            birthdateLabel.AutoSize = true;
            birthdateLabel.Location = new System.Drawing.Point(20, 160);
            birthdateLabel.Name = "birthdateLabel";
            birthdateLabel.Text = "Birthdate:";
            // 
            // birthdatePicker
            // 
            birthdatePicker.Format = DateTimePickerFormat.Short;
            birthdatePicker.Location = new System.Drawing.Point(130, 156);
            birthdatePicker.Name = "birthdatePicker";
            birthdatePicker.Size = new System.Drawing.Size(150, 23);
            birthdatePicker.TabIndex = 2;
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new System.Drawing.Point(20, 195);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Text = "Phone (10 digits):";
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new System.Drawing.Point(130, 192);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new System.Drawing.Size(150, 23);
            phoneTextBox.TabIndex = 3;
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Location = new System.Drawing.Point(300, 160);
            genderLabel.Name = "genderLabel";
            genderLabel.Text = "Gender:";
            // 
            // genderComboBox
            // 
            genderComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            genderComboBox.Location = new System.Drawing.Point(350, 156);
            genderComboBox.Name = "genderComboBox";
            genderComboBox.Size = new System.Drawing.Size(80, 23);
            genderComboBox.TabIndex = 4;
            // 
            // streetLabel
            // 
            streetLabel.AutoSize = true;
            streetLabel.Location = new System.Drawing.Point(20, 235);
            streetLabel.Name = "streetLabel";
            streetLabel.Text = "Street:";
            // 
            // streetTextBox
            // 
            streetTextBox.Location = new System.Drawing.Point(130, 232);
            streetTextBox.Name = "streetTextBox";
            streetTextBox.Size = new System.Drawing.Size(300, 23);
            streetTextBox.TabIndex = 5;
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new System.Drawing.Point(20, 270);
            cityLabel.Name = "cityLabel";
            cityLabel.Text = "City:";
            // 
            // cityTextBox
            // 
            cityTextBox.Location = new System.Drawing.Point(130, 267);
            cityTextBox.Name = "cityTextBox";
            cityTextBox.Size = new System.Drawing.Size(200, 23);
            cityTextBox.TabIndex = 6;
            // 
            // stateLabel
            // 
            stateLabel.AutoSize = true;
            stateLabel.Location = new System.Drawing.Point(345, 270);
            stateLabel.Name = "stateLabel";
            stateLabel.Text = "State:";
            // 
            // stateComboBox
            // 
            stateComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            stateComboBox.Location = new System.Drawing.Point(390, 267);
            stateComboBox.Name = "stateComboBox";
            stateComboBox.Size = new System.Drawing.Size(80, 23);
            stateComboBox.TabIndex = 7;
            // 
            // zipcodeLabel
            // 
            zipcodeLabel.AutoSize = true;
            zipcodeLabel.Location = new System.Drawing.Point(20, 305);
            zipcodeLabel.Name = "zipcodeLabel";
            zipcodeLabel.Text = "ZIP code:";
            // 
            // zipcodeTextBox
            // 
            zipcodeTextBox.Location = new System.Drawing.Point(130, 302);
            zipcodeTextBox.Name = "zipcodeTextBox";
            zipcodeTextBox.Size = new System.Drawing.Size(100, 23);
            zipcodeTextBox.TabIndex = 8;
            // 
            // saveButton
            // 
            saveButton.Location = new System.Drawing.Point(250, 345);
            saveButton.Name = "saveButton";
            saveButton.Size = new System.Drawing.Size(85, 30);
            saveButton.TabIndex = 9;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new System.Drawing.Point(345, 345);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(85, 30);
            cancelButton.TabIndex = 10;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // RegisterPatientForm
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(500, 400);
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
            Controls.Add(genderLabel);
            Controls.Add(genderComboBox);
            Controls.Add(streetLabel);
            Controls.Add(streetTextBox);
            Controls.Add(cityLabel);
            Controls.Add(cityTextBox);
            Controls.Add(stateLabel);
            Controls.Add(stateComboBox);
            Controls.Add(zipcodeLabel);
            Controls.Add(zipcodeTextBox);
            Controls.Add(saveButton);
            Controls.Add(cancelButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegisterPatientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register Patient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
        private Label genderLabel;
        private ComboBox genderComboBox;
        private Label streetLabel;
        private TextBox streetTextBox;
        private Label cityLabel;
        private TextBox cityTextBox;
        private Label stateLabel;
        private ComboBox stateComboBox;
        private Label zipcodeLabel;
        private TextBox zipcodeTextBox;
        private Button saveButton;
        private Button cancelButton;
    }
}
