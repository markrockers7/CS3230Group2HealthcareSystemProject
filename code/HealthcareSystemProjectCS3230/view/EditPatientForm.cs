using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HealthcareSystemProjectCS3230.model;
using HealthcareSystemProjectCS3230.DAL;

namespace HealthcareSystemProjectCS3230.view
{
    public partial class EditPatientForm : Form
    {
        private List<Patient> _patients = new List<Patient>();

        public EditPatientForm()
        {
            InitializeComponent();
            PopulateStates();
            LoadPatients();
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

        private void LoadPatients()
        {
            _patients = PatientsDAL.GetAllPatients();
            patientComboBox.Items.Clear();
            foreach (var p in _patients)
            {
                patientComboBox.Items.Add($"{p.FirstName} {p.LastName}");
            }
            if (patientComboBox.Items.Count > 0) patientComboBox.SelectedIndex = 0;
        }

        private void patientComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (patientComboBox.SelectedIndex < 0) return;
            var sel = _patients[patientComboBox.SelectedIndex];
            var loaded = PatientsDAL.GetPatientByPatientId(sel.Id);
            if (loaded == null) return;

            // populate fields
            firstNameTextBox.Text = loaded.FirstName;
            lastNameTextBox.Text = loaded.LastName;
            birthdatePicker.Value = loaded.Birthdate;
            phoneTextBox.Text = loaded.PhoneNumber;
            streetTextBox.Text = loaded.Street;
            cityTextBox.Text = loaded.City;
            zipcodeTextBox.Text = loaded.Zipcode;
            isActiveCheckBox.Checked = loaded.IsActive;
            // select state in combobox if present
            var idx = stateComboBox.Items.IndexOf(loaded.State);
            if (idx >= 0) stateComboBox.SelectedIndex = idx;
            else if (stateComboBox.Items.Count > 0) stateComboBox.SelectedIndex = 0;

            // store ids in Tag for update
            this.Tag = loaded;
        }

        private void cancelButton_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void updateButton_Click(object? sender, EventArgs e)
        {
            if (this.Tag is not Patient existing) return;

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

            existing.FirstName = firstNameTextBox.Text.Trim();
            existing.LastName = lastNameTextBox.Text.Trim();
            existing.Birthdate = birthdatePicker.Value.Date;
            existing.PhoneNumber = phoneTextBox.Text.Trim();
            existing.Street = streetTextBox.Text.Trim();
            existing.City = cityTextBox.Text.Trim();
            existing.State = stateComboBox.SelectedItem?.ToString() ?? string.Empty;
            existing.Zipcode = zipcodeTextBox.Text.Trim();
            existing.IsActive = isActiveCheckBox.Checked;

            var ok = PatientsDAL.UpdatePatient(existing);
            if (ok)
            {
                MessageBox.Show("Patient updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPatients();
            }
            else
            {
                MessageBox.Show("Failed to update patient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
