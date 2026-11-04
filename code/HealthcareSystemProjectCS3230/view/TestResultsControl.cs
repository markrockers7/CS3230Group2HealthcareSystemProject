using System.ComponentModel;
using HealthcareSystemProjectCS3230.controler;
using HealthcareSystemProjectCS3230.model;

namespace HealthcareSystemProjectCS3230.view
{
    /*
     * Lets a nurse enter results for tests ordered during a visit.
     * Results are read-only once the visit has a final diagnosis.
     */
    public partial class TestResultsControl : UserControl
    {
        private readonly AppointmentController _appointmentController = new AppointmentController();
        private Patient? _selectedPatient;

        public TestResultsControl()
        {
            InitializeComponent();
            errorLabel.Text = string.Empty;
            patientInfoLabel.Text = string.Empty;
            ClearSelectedTest();
        }

        private VisitSummary? SelectedVisit =>
            visitGrid.SelectedRows.Count == 0 ? null : visitGrid.SelectedRows[0].DataBoundItem as VisitSummary;

        private VisitTestResult? SelectedTest =>
            testsGrid.SelectedRows.Count == 0 ? null : testsGrid.SelectedRows[0].DataBoundItem as VisitTestResult;

        private void patientSearchControl_PatientSelected(object? sender, EventArgs e)
        {
            _selectedPatient = patientSearchControl.SelectedPatient;
            errorLabel.Text = string.Empty;
            visitGrid.DataSource = null;
            testsGrid.DataSource = null;
            ClearSelectedTest();

            if (_selectedPatient == null)
            {
                patientInfoLabel.Text = string.Empty;
                return;
            }

            patientInfoLabel.Text = $"Patient: {_selectedPatient.FirstName} {_selectedPatient.LastName}   |   DOB: {_selectedPatient.Birthdate:d}";
            LoadVisits();
        }

        private void LoadVisits()
        {
            if (_selectedPatient == null) return;

            try
            {
                var visits = _appointmentController.GetVisitsWithTestsForPatient(_selectedPatient.Id);
                visitGrid.DataSource = new BindingList<VisitSummary>(visits);

                if (visits.Count == 0)
                {
                    errorLabel.Text = "This patient has no visits with ordered tests.";
                }
            }
            catch (Exception ex)
            {
                errorLabel.Text = "Visits could not be loaded: " + ex.Message;
            }
        }

        private void LoadTests()
        {
            testsGrid.DataSource = null;
            ClearSelectedTest();

            var visit = SelectedVisit;
            if (visit == null) return;

            try
            {
                var tests = _appointmentController.GetVisitTestResults(visit.AppointmentId);
                testsGrid.DataSource = new BindingList<VisitTestResult>(tests);

                errorLabel.Text = visit.IsLocked
                    ? "This visit has a final diagnosis, so its test results are read-only."
                    : string.Empty;
            }
            catch (Exception ex)
            {
                errorLabel.Text = "Tests could not be loaded: " + ex.Message;
            }
        }

        private void visitGrid_SelectionChanged(object? sender, EventArgs e)
        {
            LoadTests();
        }

        private void testsGrid_SelectionChanged(object? sender, EventArgs e)
        {
            ShowSelectedTest();
        }

        // Stops the grids from auto-selecting the first row
        private void visitGrid_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            visitGrid.ClearSelection();
        }

        private void testsGrid_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            testsGrid.ClearSelection();
        }

        private void ShowSelectedTest()
        {
            var visit = SelectedVisit;
            var test = SelectedTest;

            if (visit == null || test == null)
            {
                ClearSelectedTest();
                return;
            }

            selectedTestLabel.Text = $"Test: {test.TestName}   |   Normal range: {test.NormalRange}   |   Doctor: {visit.DoctorName}";
            datePerformedPicker.Value = test.DatePerformed ?? DateTime.Now;
            resultTextBox.Text = test.Result ?? string.Empty;

            bool canEdit = !visit.IsLocked;
            datePerformedPicker.Enabled = canEdit;
            resultTextBox.Enabled = canEdit;
            saveResultButton.Enabled = canEdit;

            if (test.HasNormalRange)
            {
                // Abnormal is calculated from the range, so the nurse can't change it
                abnormalCheckBox.Enabled = false;
                UpdateAbnormalPreview();
            }
            else
            {
                abnormalCheckBox.Enabled = canEdit;
                abnormalCheckBox.Checked = test.IsAbnormal ?? false;
            }
        }

        private void ClearSelectedTest()
        {
            selectedTestLabel.Text = "Select a visit and a test to enter its result.";
            datePerformedPicker.Value = DateTime.Now;
            resultTextBox.Clear();
            abnormalCheckBox.Checked = false;
            datePerformedPicker.Enabled = false;
            resultTextBox.Enabled = false;
            abnormalCheckBox.Enabled = false;
            saveResultButton.Enabled = false;
        }

        private void resultTextBox_TextChanged(object? sender, EventArgs e)
        {
            UpdateAbnormalPreview();
        }

        // For tests with a range, checks the Abnormal box as the nurse types a number
        private void UpdateAbnormalPreview()
        {
            var test = SelectedTest;
            if (test == null || !test.HasNormalRange) return;

            try
            {
                abnormalCheckBox.Checked = _appointmentController.DetermineIsAbnormal(test, resultTextBox.Text, false);
            }
            catch (ArgumentException)
            {
                // Not a number yet; leave unchecked until it is
                abnormalCheckBox.Checked = false;
            }
        }

        private void saveResultButton_Click(object? sender, EventArgs e)
        {
            errorLabel.Text = string.Empty;

            var visit = SelectedVisit;
            var test = SelectedTest;

            if (visit == null || test == null)
            {
                errorLabel.Text = "Please select a visit and a test.";
                return;
            }

            try
            {
                _appointmentController.SaveTestResult(
                    visit,
                    test,
                    datePerformedPicker.Value,
                    resultTextBox.Text,
                    abnormalCheckBox.Checked);

                MessageBox.Show($"Result saved for {test.TestName}.", "Saved");
                LoadTests();
            }
            catch (ArgumentException ex)
            {
                errorLabel.Text = ex.Message;
            }
            catch (Exception ex)
            {
                errorLabel.Text = "The result could not be saved: " + ex.Message;
            }
        }
    }
}