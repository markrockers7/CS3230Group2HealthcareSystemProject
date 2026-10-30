using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HealthcareSystemProjectCS3230.controler;
using HealthcareSystemProjectCS3230.model;

namespace HealthcareSystemProjectCS3230.view
{
    public partial class PatientSearchControl : UserControl
    {
        private readonly PatientController patientController = new PatientController();

        public DataGridView PatientResultsGrid => patientResultsGrid;

        public string FirstNameFilter => firstNameTextBox.Text.Trim();
        public string LastNameFilter => lastNameTextBox.Text.Trim();
        public DateTime? BirthdateFilter => birthdatePicker.Checked ? birthdatePicker.Value.Date : null;
        public Patient? SelectedPatient => GetSelectedPatient();

        public event EventHandler? SearchRequested;
        public event EventHandler? PatientSelected;

        public PatientSearchControl()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            RunSearch();
            SearchRequested?.Invoke(this, EventArgs.Empty);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void RunSearch()
        {
            try
            {
                var patients = patientController.FindPatients(FirstNameFilter, LastNameFilter, BirthdateFilter);
                SetPatients(patients);

                if (patients.Count == 0)
                {
                    MessageBox.Show(
                        "No patients matched your search.",
                        "No Results",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    $"Patients could not be searched. {exception.Message}",
                    "Search Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public void SetPatients(IEnumerable<Patient> patients)
        {
            patientResultsGrid.DataSource = new BindingList<Patient>(patients.ToList());
        }

        public void Clear()
        {
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            birthdatePicker.Checked = false;
            patientResultsGrid.DataSource = null;
            patientResultsGrid.ClearSelection();
        }

        private Patient? GetSelectedPatient()
        {
            if (patientResultsGrid.SelectedRows.Count <= 0) return null;
            var row = patientResultsGrid.SelectedRows[0];
            var dataSource = patientResultsGrid.DataSource as BindingList<Patient>;
            return dataSource?[row.Index];
        }

        private void patientResultsGrid_SelectionChanged(object sender, EventArgs e)
        {
            PatientSelected?.Invoke(this, EventArgs.Empty);
        }

        private void patientResultsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PatientSelected?.Invoke(this, EventArgs.Empty);
        }

        // Stops the grid from auto-selecting the first row after a search
        private void patientResultsGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            patientResultsGrid.ClearSelection();
        }

        private void patientResultsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (patientResultsGrid.Columns[e.ColumnIndex].DataPropertyName == nameof(Patient.Address) && e.Value is Address address)
            {
                e.Value = $"{address.Street}, {address.City}, {address.State} {address.Zipcode}";
                e.FormattingApplied = true;
            }
        }
    }
}