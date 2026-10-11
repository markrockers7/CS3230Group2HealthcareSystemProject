using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HealthcareSystemProjectCS3230.model;
using HealthcareSystemProjectCS3230.DAL;

namespace HealthcareSystemProjectCS3230.view
{
    public partial class RegisterPatientForm : Form
    {
        public RegisterPatientForm()
        {
            InitializeComponent();
            PopulateGender();
            PopulateStates();
        }

        private void PopulateGender()
        {
            genderComboBox.Items.Clear();
            genderComboBox.Items.AddRange(new[] { "Male", "Female" });
            genderComboBox.SelectedIndex = 0;
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
            stateComboBox.SelectedIndex = 0;
        }

        private void cancelButton_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text) || string.IsNullOrWhiteSpace(lastNameTextBox.Text))
            {
                MessageBox.Show("First and last name are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(phoneTextBox.Text ?? string.Empty, "^[0-9]{10}$"))
            {
                MessageBox.Show("Phone number must be 10 digits (numbers only).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(zipcodeTextBox.Text ?? string.Empty, "^[0-9]{5}$"))
            {
                MessageBox.Show("ZIP code must be 5 digits.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (birthdatePicker.Value.Date >= DateTime.Now.Date)
            {
                MessageBox.Show("Birthdate must be in the past.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var patient = new Patient
            {
                FirstName = firstNameTextBox.Text.Trim(),
                LastName = lastNameTextBox.Text.Trim(),
                Birthdate = birthdatePicker.Value.Date,
                PhoneNumber = phoneTextBox.Text.Trim(),
                Street = streetTextBox.Text.Trim(),
                City = cityTextBox.Text.Trim(),
                State = stateComboBox.SelectedItem?.ToString() ?? string.Empty,
                Zipcode = zipcodeTextBox.Text.Trim(),
                IsActive = true
            };

            var success = PatientsDAL.AddPatient(patient);
            if (success)
            {
                MessageBox.Show("Patient successfully registered.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occurred while saving the patient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
