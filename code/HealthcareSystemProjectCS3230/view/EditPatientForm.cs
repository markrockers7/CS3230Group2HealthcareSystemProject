using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HealthcareSystemProjectCS3230.model;
using HealthcareSystemProjectCS3230.controler;

namespace HealthcareSystemProjectCS3230.view
{
    public partial class EditPatientForm : Form
    {
        private List<Patient> _patients = new List<Patient>();
        private readonly PatientController _controller = new PatientController();

        public EditPatientForm(LoginSession loginSession)
        {
            InitializeComponent();
            loggedInLabel.Text = $"Hello, {loginSession.FullName}!{Environment.NewLine}Username: {loginSession.Username}{Environment.NewLine}ID: {loginSession.id}";
            PopulateStates();
            PopulateGender();
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

        private void PopulateGender()
        {
            var genders = new[] { 'U', 'M', 'F' };
            genderComboBox.Items.Clear();
            genderComboBox.Items.AddRange(genders);
            genderComboBox.SelectedItem = 'U';
        }

        private void LoadPatients()
        {
            _patients = _controller.GetAllPatients();
            patientComboBox.Items.Clear();
            foreach (var p in _patients)
            {
                var name = $"{p.FirstName} {p.LastName}";
                patientComboBox.Items.Add(name);
            }
            if (patientComboBox.Items.Count > 0) patientComboBox.SelectedIndex = 0;
        }

        private void patientComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (patientComboBox.SelectedIndex < 0) return;
            var sel = _patients[patientComboBox.SelectedIndex];
            var loaded = _controller.GetPatientById(sel.Id);
            if (loaded == null) return;

            // populate fields
            firstNameTextBox.Text = loaded.FirstName;
            lastNameTextBox.Text = loaded.LastName;
            birthdatePicker.Value = loaded.Birthdate;
            genderComboBox.SelectedItem = genderComboBox.Items.Contains(loaded.Gender) ? loaded.Gender : 'U';
            phoneTextBox.Text = loaded.PhoneNumber;
            streetTextBox.Text = loaded.Address.Street;
            cityTextBox.Text = loaded.Address.City;
            zipcodeTextBox.Text = loaded.Address.Zipcode;
            isActiveCheckBox.Checked = loaded.IsActive;
            // select state in combobox if present
            var idx = stateComboBox.Items.IndexOf(loaded.Address.State);
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

            existing.FirstName = firstNameTextBox.Text.Trim();
            existing.LastName = lastNameTextBox.Text.Trim();
            existing.Birthdate = birthdatePicker.Value.Date;
            existing.Gender = genderComboBox.SelectedItem?.ToString().ToCharArray()[0] ?? 'U';
            existing.PhoneNumber = phoneTextBox.Text.Trim();
            existing.Address.Street = streetTextBox.Text.Trim();
            existing.Address.City = cityTextBox.Text.Trim();
            existing.Address.State = stateComboBox.SelectedItem?.ToString() ?? string.Empty;
            existing.Address.Zipcode = zipcodeTextBox.Text.Trim();
            existing.IsActive = isActiveCheckBox.Checked;

            try
            {
                _controller.UpdatePatient(existing);
                MessageBox.Show("Patient updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPatients();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
