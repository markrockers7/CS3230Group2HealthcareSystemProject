using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HealthcareSystemProjectCS3230.model;
using HealthcareSystemProjectCS3230.controler;

namespace HealthcareSystemProjectCS3230.view
{
    public partial class RegisterPatientForm : Form
    {
        private ComboBox genderComboBox = null!;
        private ComboBox stateComboBox = null!;
        private TextBox firstNameTextBox = null!;
        private TextBox lastNameTextBox = null!;
        private DateTimePicker birthdatePicker = null!;
        private TextBox phoneTextBox = null!;
        private TextBox streetTextBox = null!;
        private TextBox cityTextBox = null!;
        private TextBox zipcodeTextBox = null!;

        private Label firstNameErrorLabel = null!;
        private Label lastNameErrorLabel = null!;
        private Label birthdateErrorLabel = null!;
        private Label phoneErrorLabel = null!;
        private Label genderErrorLabel = null!;
        private Label streetErrorLabel = null!;
        private Label cityErrorLabel = null!;
        private Label stateErrorLabel = null!;
        private Label zipcodeErrorLabel = null!;

        private Label errorLabel = null!;
        private Button saveButton = null!;
        private Button cancelButton = null!;
        private Label loggedInLabel = null!;

        private readonly PatientController _controller = new PatientController();

        public RegisterPatientForm(LoginSession loginSession)
        {
            InitializeComponent();

            loggedInLabel.Text =
                $"Hello, {loginSession.FullName}!" +
                $"{Environment.NewLine}Username: {loginSession.Username}" +
                $"{Environment.NewLine}ID: {loginSession.id}";

            PopulateGender();
            PopulateStates();

            clearErrorLabels();
        }

        private void PopulateGender()
        {
            genderComboBox.Items.Clear();
            genderComboBox.Items.AddRange(
                new[] { "Male", "Female", "Unknown" });

            genderComboBox.SelectedIndex = -1;
        }

        private void PopulateStates()
        {
            var states = new[]
            {
                "AL","AK","AZ","AR","CA","CO","CT","DE","FL","GA",
                "HI","ID","IL","IN","IA","KS","KY","LA","ME","MD",
                "MA","MI","MN","MS","MO","MT","NE","NV","NH","NJ",
                "NM","NY","NC","ND","OH","OK","OR","PA","RI","SC",
                "SD","TN","TX","UT","VT","VA","WA","WV","WI","WY"
            };

            stateComboBox.Items.Clear();
            stateComboBox.Items.AddRange(states);
            stateComboBox.SelectedIndex = -1;
        }

        private void cancelButton_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void InitializeComponent()
        {
            genderComboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill
            };

            stateComboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill
            };

            firstNameTextBox = new TextBox { Dock = DockStyle.Fill };
            lastNameTextBox = new TextBox { Dock = DockStyle.Fill };

            birthdatePicker = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Dock = DockStyle.Fill
            };

            phoneTextBox = new TextBox { Dock = DockStyle.Fill };
            streetTextBox = new TextBox { Dock = DockStyle.Fill };
            cityTextBox = new TextBox { Dock = DockStyle.Fill };
            zipcodeTextBox = new TextBox { Dock = DockStyle.Fill };

            // Initialize error labels
            firstNameErrorLabel = CreateErrorLabel();
            lastNameErrorLabel = CreateErrorLabel();
            birthdateErrorLabel = CreateErrorLabel();
            phoneErrorLabel = CreateErrorLabel();
            genderErrorLabel = CreateErrorLabel();
            streetErrorLabel = CreateErrorLabel();
            cityErrorLabel = CreateErrorLabel();
            stateErrorLabel = CreateErrorLabel();
            zipcodeErrorLabel = CreateErrorLabel();

            errorLabel = CreateErrorLabel();

            saveButton = new Button
            {
                Text = "Save",
                AutoSize = true
            };

            cancelButton = new Button
            {
                Text = "Cancel",
                AutoSize = true
            };

            loggedInLabel = new Label
            {
                AutoSize = true,
                Anchor = AnchorStyles.Left
            };

            saveButton.Click += saveButton_Click;
            cancelButton.Click += cancelButton_Click;

            var layout = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 12,
                Dock = DockStyle.Top,
                Padding = new Padding(12),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            layout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 120));

            layout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            layout.Controls.Add(loggedInLabel, 0, 0);
            layout.SetColumnSpan(loggedInLabel, 2);

            layout.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            AddField(layout, "First name",
                firstNameTextBox, firstNameErrorLabel, 1);

            AddField(layout, "Last name",
                lastNameTextBox, lastNameErrorLabel, 2);

            AddField(layout, "Birthdate",
                birthdatePicker, birthdateErrorLabel, 3);

            AddField(layout, "Phone",
                phoneTextBox, phoneErrorLabel, 4);

            AddField(layout, "Gender",
                genderComboBox, genderErrorLabel, 5);

            AddField(layout, "Street",
                streetTextBox, streetErrorLabel, 6);

            AddField(layout, "City",
                cityTextBox, cityErrorLabel, 7);

            AddField(layout, "State",
                stateComboBox, stateErrorLabel, 8);

            AddField(layout, "ZIP code",
                zipcodeTextBox, zipcodeErrorLabel, 9);

            layout.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            layout.Controls.Add(errorLabel, 1, 10);

            var buttons = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            buttons.Controls.Add(cancelButton);
            buttons.Controls.Add(saveButton);

            layout.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            layout.Controls.Add(buttons, 1, 11);

            Controls.Add(layout);

            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(460, 550);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register Patient";
        }

        private static Label CreateErrorLabel()
        {
            return new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                MaximumSize = new Size(260, 0),
                Text = string.Empty
            };
        }

        private static void AddField(
            TableLayoutPanel layout,
            string labelText,
            Control control,
            Label validationLabel,
            int row)
        {
            layout.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            layout.Controls.Add(
                new Label
                {
                    Text = labelText,
                    AutoSize = true,
                    Anchor = AnchorStyles.Left
                },
                0, row);

            // Container for input and its error label
            var fieldPanel = new TableLayoutPanel
            {
                ColumnCount = 1,
                RowCount = 2,
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            fieldPanel.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            fieldPanel.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            fieldPanel.Controls.Add(control, 0, 0);
            fieldPanel.Controls.Add(validationLabel, 0, 1);

            layout.Controls.Add(fieldPanel, 1, row);
        }

        // Clear all validation errors
        private void clearErrorLabels()
        {
            firstNameErrorLabel.Text = "";
            lastNameErrorLabel.Text = "";
            birthdateErrorLabel.Text = "";
            phoneErrorLabel.Text = "";
            genderErrorLabel.Text = "";
            streetErrorLabel.Text = "";
            cityErrorLabel.Text = "";
            stateErrorLabel.Text = "";
            zipcodeErrorLabel.Text = "";
            errorLabel.Text = "";
        }

        // Validate all patient fields
        private bool validateInput(Patient patient)
        {
            clearErrorLabels();

            bool isValid = true;

            // First Name
            if (string.IsNullOrWhiteSpace(patient.FirstName))
            {
                firstNameErrorLabel.Text =
                    "First name is required.";

                isValid = false;
            }

            // Last Name
            if (string.IsNullOrWhiteSpace(patient.LastName))
            {
                lastNameErrorLabel.Text =
                    "Last name is required.";

                isValid = false;
            }

            // Birthdate
            if (patient.Birthdate >= DateTime.Now.Date)
            {
                birthdateErrorLabel.Text =
                    "Birthdate must be in the past.";

                isValid = false;
            }

            // Phone Number
            if (!Regex.IsMatch(
                patient.PhoneNumber, @"^\d{10}$"))
            {
                phoneErrorLabel.Text =
                    "Phone number must be 10 digits (numbers only).";

                isValid = false;
            }

            // Street
            if (string.IsNullOrWhiteSpace(patient.Address.Street)
                || patient.Address.Street.Length > 100)
            {
                streetErrorLabel.Text =
                    "Street address must be 100 or less characters and cannot be empty.";

                isValid = false;
            }

            // City
            if (string.IsNullOrWhiteSpace(patient.Address.City)
                || patient.Address.City.Length > 50)
            {
                cityErrorLabel.Text =
                    "City must be 50 or less characters and cannot be empty.";

                isValid = false;
            }

            // State
            if (string.IsNullOrWhiteSpace(patient.Address.State))
            {
                stateErrorLabel.Text =
                    "State must be selected.";

                isValid = false;
            }

            // ZIP Code
            if (!Regex.IsMatch(
                patient.Address.Zipcode, @"^\d{5}$"))
            {
                zipcodeErrorLabel.Text =
                    "ZIP code must be 5 digits.";

                isValid = false;
            }

            // Gender
            if (patient.Gender == '\0')
            {
                genderErrorLabel.Text =
                    "Gender must be selected.";

                isValid = false;
            }

            return isValid;
        }

        private void saveButton_Click(object? sender, EventArgs e)
        {
            clearErrorLabels();

            var patient = new Patient
            {
                FirstName = firstNameTextBox.Text.Trim(),
                LastName = lastNameTextBox.Text.Trim(),
                Birthdate = birthdatePicker.Value.Date,
                PhoneNumber = phoneTextBox.Text.Trim(),

                Address = new Address
                {
                    Street = streetTextBox.Text.Trim(),
                    City = cityTextBox.Text.Trim(),
                    State = stateComboBox.SelectedItem?.ToString()
                        ?? string.Empty,
                    Zipcode = zipcodeTextBox.Text.Trim()
                },

                IsActive = true,

                Gender = genderComboBox.SelectedItem?
                    .ToString()?.FirstOrDefault() ?? '\0'
            };

            // Validate all inputs before saving
            if (!validateInput(patient))
            {
                return;
            }

            try
            {
                _controller.AddPatient(patient);

                MessageBox.Show(
                    "Patient successfully registered.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                errorLabel.Text = ex.Message;
            }
            catch (Exception ex)
            {
                errorLabel.Text =
                    "An unexpected error occurred: " + ex.Message;
            }
        }
    }
}