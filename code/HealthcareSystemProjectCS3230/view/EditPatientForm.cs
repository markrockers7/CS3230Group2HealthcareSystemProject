using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HealthcareSystemProjectCS3230.model;
using HealthcareSystemProjectCS3230.controler;

namespace HealthcareSystemProjectCS3230.view
{
    public partial class EditPatientForm : Form
    {
        private readonly PatientController _controller = new PatientController();
        private readonly PatientSearchControl patientSearchControl;

        public EditPatientForm(LoginSession loginSession)
        {
            InitializeComponent();

            loggedInLabel.Text =
                $"Hello, {loginSession.FullName}!" +
                $"{Environment.NewLine}Username: {loginSession.Username}" +
                $"{Environment.NewLine}ID: {loginSession.id}";

            PopulateStates();
            PopulateGender();

            patientSearchControl = new PatientSearchControl
            {
                Dock = DockStyle.Fill,
                Height = 320
            };

            patientSearchControl.PatientSelected +=
                PatientSearchControl_PatientSelected;

            if (Controls[0] is TableLayoutPanel mainLayout)
            {
                mainLayout.Controls.Add(patientSearchControl, 0, 1);
                mainLayout.SetColumnSpan(patientSearchControl, 2);
            }

            ClearEditFields();
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
        }

        private void PopulateGender()
        {
            genderComboBox.Items.Clear();
            genderComboBox.Items.AddRange(new object[] { 'U', 'M', 'F' });
            genderComboBox.SelectedItem = 'U';
        }

        private void PatientSearchControl_PatientSelected(
            object? sender, EventArgs e)
        {
            var selectedPatient = patientSearchControl.SelectedPatient;

            if (selectedPatient == null)
            {
                ClearEditFields();
                return;
            }

            ClearErrorLabels();

            LoadPatientData(selectedPatient);
            EnableEditFields(true);

            Tag = selectedPatient;
        }

        private void LoadPatientData(Patient patient)
        {
            firstNameTextBox.Text = patient.FirstName;
            lastNameTextBox.Text = patient.LastName;
            birthdatePicker.Value = patient.Birthdate;

            genderComboBox.SelectedItem =
                genderComboBox.Items.Contains(patient.Gender)
                    ? patient.Gender
                    : 'U';

            phoneTextBox.Text = patient.PhoneNumber;
            streetTextBox.Text = patient.Address.Street;
            cityTextBox.Text = patient.Address.City;
            zipcodeTextBox.Text = patient.Address.Zipcode;

            isActiveCheckBox.Checked = patient.IsActive;

            var idx = stateComboBox.Items.IndexOf(
                patient.Address.State);

            stateComboBox.SelectedIndex = idx;
        }

        private void ClearEditFields()
        {
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();

            birthdatePicker.Value = DateTime.Today;
            genderComboBox.SelectedItem = 'U';

            phoneTextBox.Clear();
            streetTextBox.Clear();
            cityTextBox.Clear();
            zipcodeTextBox.Clear();

            isActiveCheckBox.Checked = true;
            stateComboBox.SelectedIndex = -1;

            ClearErrorLabels();
            EnableEditFields(false);

            Tag = null;
        }

        private void EnableEditFields(bool enabled)
        {
            firstNameTextBox.Enabled = enabled;
            lastNameTextBox.Enabled = enabled;
            birthdatePicker.Enabled = enabled;
            genderComboBox.Enabled = enabled;
            phoneTextBox.Enabled = enabled;
            streetTextBox.Enabled = enabled;
            cityTextBox.Enabled = enabled;
            stateComboBox.Enabled = enabled;
            zipcodeTextBox.Enabled = enabled;
            isActiveCheckBox.Enabled = enabled;
            updateButton.Enabled = enabled;
        }

        private void cancelButton_Click(object? sender, EventArgs e)
        {
            Close();
        }

        // Clear all validation errors
        private void ClearErrorLabels()
        {
            firstNameErrorLabel.Text = "";
            lastNameErrorLabel.Text = "";
            birthdateErrorLabel.Text = "";
            genderErrorLabel.Text = "";
            phoneErrorLabel.Text = "";
            streetErrorLabel.Text = "";
            cityErrorLabel.Text = "";
            stateErrorLabel.Text = "";
            zipcodeErrorLabel.Text = "";
            errorLabel.Text = "";
        }

        // Validate all fields at once
        private bool ValidateInput()
        {
            ClearErrorLabels();

            bool isValid = true;

            // First Name
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text))
            {
                firstNameErrorLabel.Text =
                    "First name is required.";

                isValid = false;
            }

            // Last Name
            if (string.IsNullOrWhiteSpace(lastNameTextBox.Text))
            {
                lastNameErrorLabel.Text =
                    "Last name is required.";

                isValid = false;
            }

            // Birthdate
            if (birthdatePicker.Value.Date >= DateTime.Today)
            {
                birthdateErrorLabel.Text =
                    "Birthdate must be in the past.";

                isValid = false;
            }

            // Gender
            if (genderComboBox.SelectedItem == null)
            {
                genderErrorLabel.Text =
                    "Gender must be selected.";

                isValid = false;
            }

            // Phone Number
            if (!Regex.IsMatch(
                phoneTextBox.Text.Trim(), @"^\d{10}$"))
            {
                phoneErrorLabel.Text =
                    "Phone number must be 10 digits (numbers only).";

                isValid = false;
            }

            // Street
            if (string.IsNullOrWhiteSpace(streetTextBox.Text)
                || streetTextBox.Text.Trim().Length > 100)
            {
                streetErrorLabel.Text =
                    "Street address must be 100 or less characters and cannot be empty.";

                isValid = false;
            }

            // City
            if (string.IsNullOrWhiteSpace(cityTextBox.Text)
                || cityTextBox.Text.Trim().Length > 50)
            {
                cityErrorLabel.Text =
                    "City must be 50 or less characters and cannot be empty.";

                isValid = false;
            }

            // State
            if (stateComboBox.SelectedItem == null)
            {
                stateErrorLabel.Text =
                    "State must be selected.";

                isValid = false;
            }

            // ZIP Code
            if (!Regex.IsMatch(
                zipcodeTextBox.Text.Trim(), @"^\d{5}$"))
            {
                zipcodeErrorLabel.Text =
                    "ZIP code must be 5 digits.";

                isValid = false;
            }

            return isValid;
        }

        private void updateButton_Click(object? sender, EventArgs e)
        {
            ClearErrorLabels();

            if (Tag is not Patient existing)
                return;

            // Validate every field before updating
            if (!ValidateInput())
            {
                return;
            }

            existing.FirstName = firstNameTextBox.Text.Trim();
            existing.LastName = lastNameTextBox.Text.Trim();
            existing.Birthdate = birthdatePicker.Value.Date;

            existing.Gender =
                genderComboBox.SelectedItem is char gender
                    ? gender
                    : 'U';

            existing.PhoneNumber = phoneTextBox.Text.Trim();

            existing.Address.Street = streetTextBox.Text.Trim();
            existing.Address.City = cityTextBox.Text.Trim();

            existing.Address.State =
                stateComboBox.SelectedItem?.ToString()
                ?? string.Empty;

            existing.Address.Zipcode = zipcodeTextBox.Text.Trim();

            existing.IsActive = isActiveCheckBox.Checked;

            try
            {
                _controller.UpdatePatient(existing);

                MessageBox.Show(
                    "Patient updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                patientSearchControl.Clear();
                ClearEditFields();
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