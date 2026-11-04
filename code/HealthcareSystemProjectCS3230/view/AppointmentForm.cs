using HealthcareSystemProjectCS3230.controler;
using HealthcareSystemProjectCS3230.model;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.ComponentModel;

namespace HealthcareSystemProjectCS3230.view
{
    public partial class AppointmentForm : Form
    {
        private readonly AppointmentController _appointmentController = new AppointmentController();
        private readonly int? _appointmentId;
        private LoginSession? _loginSession;
        private bool _isEditMode;
        private bool _isReadOnlyEdit;
        private TimeSpan? _currentSlot;
        private int? _selectedPatientId;

        // Create mode
        public AppointmentForm()
        {
            InitializeComponent();
            ConfigureForm();
            LoadDoctors();
            EnableAppointmentFields(false);
            ConfigureVisitAndOrderTestForm();
            ConfigureFinalDiagnosisForm();
            ConfigureTestResultsForm();
            ConfigureViewVisitsForm();
        }

        // Edit mode
        public AppointmentForm(int appointmentId)
        {
            InitializeComponent();
            _appointmentId = appointmentId;
            _isEditMode = true;
            ConfigureForm();
            LoadDoctors();
            ConfigureVisitAndOrderTestForm();
            ConfigureFinalDiagnosisForm();
            LoadExistingAppointment();
            ConfigureTestResultsForm();
            ConfigureViewVisitsForm();
        }

        // Edit mode, opened from Find Appointment with the patient already known
        public AppointmentForm(int appointmentId, Patient patient) : this(appointmentId)
        {
            patientNameTextBox.Text = patient.FirstName + " " + patient.LastName;
            patientDobTextBox.Text = patient.Birthdate.ToString("d");
            patientSearchControl.Visible = false;
        }

        public void setLoginSession(LoginSession session)
        {
            _loginSession = session;
            loggedInLabel.Text = @"Logged in as: " + session.FullName + @" | " + session.Username + @" | " + session.id;
        }

        private void ConfigureForm()
        {
            // Past dates are only blocked when creating; an old appointment may be opened to view
            if (!_isEditMode)
            {
                appointmentDatePicker.MinDate = DateTime.Today;
            }

            appointmentDatePicker.Value = DateTime.Today;
            appointmentTimeComboBox.Format += appointmentTimeComboBox_Format;
            availabilityStatusLabel.Text = string.Empty;
            inactivePatientLabel.Text = string.Empty;
            errorLabel.Text = string.Empty;
        }

        private void LoadDoctors()
        {
            try
            {
                // Set Display/Value members first so SelectedValue is the doctor id right away
                doctorComboBox.DisplayMember = nameof(DoctorView.FullName);
                doctorComboBox.ValueMember = nameof(DoctorView.DoctorId);
                doctorComboBox.DataSource = _appointmentController.GetDoctorsWithNames();
            }
            catch (Exception ex)
            {
                errorLabel.Text = "Could not load doctors: " + ex.Message;
            }

            RefreshAvailableSlots();
        }

        private void LoadExistingAppointment()
        {
            if (!_appointmentId.HasValue)
            {
                return;
            }

            titleLabel.Text = "Edit Appointment";
            Text = "Edit Appointment";
            bookButton.Text = "Save";

            Appointment? appointment;
            try
            {
                appointment = _appointmentController.GetAppointmentById(_appointmentId.Value);
            }
            catch (Exception ex)
            {
                LockForm("Could not load the appointment: " + ex.Message);
                return;
            }

            if (appointment == null)
            {
                LockForm("The appointment could not be found.");
                return;
            }

            // Keep the appointment's current patient unless the nurse searches and picks a different one
            _selectedPatientId = appointment.PatientId;
            patientNameTextBox.Text = "Patient ID " + appointment.PatientId;

            doctorComboBox.SelectedValue = appointment.DoctorId;
            appointmentDatePicker.Value = appointment.DateTime.Date;
            reasonTextBox.Text = appointment.Reason;
            _currentSlot = appointment.DateTime.TimeOfDay;

            RefreshAvailableSlots();
            SelectSlot(_currentSlot.Value);

            if (!_appointmentController.CanEditAppointment(appointment.DateTime))
            {
                _isReadOnlyEdit = true;
                patientSearchControl.Enabled = false;
                EnableAppointmentFields(false);
                availabilityStatusLabel.Text = "This appointment cannot be edited on or after its date.";
                return;
            }

            EnableAppointmentFields(true);
        }

        // Shows an error and makes the whole form read-only
        private void LockForm(string message)
        {
            _isReadOnlyEdit = true;
            patientSearchControl.Enabled = false;
            EnableAppointmentFields(false);
            errorLabel.Text = message;
        }

        private void patientSearchControl_PatientSelected(object? sender, EventArgs e)
        {
            Patient? patient = patientSearchControl.SelectedPatient;
            errorLabel.Text = string.Empty;

            if (patient == null)
            {
                // In edit mode, keep the appointment's current patient
                if (!_isEditMode)
                {
                    ClearSelectedPatient();
                }
                return;
            }

            patientNameTextBox.Text = patient.FirstName + " " + patient.LastName;
            patientDobTextBox.Text = patient.Birthdate.ToString("d");

            if (!patient.IsActive)
            {
                _selectedPatientId = null;
                inactivePatientLabel.Text = "This patient is inactive and cannot be booked.";
                EnableAppointmentFields(false);
                return;
            }

            _selectedPatientId = patient.Id;
            inactivePatientLabel.Text = string.Empty;
            EnableAppointmentFields(!_isReadOnlyEdit);
        }

        private void ClearSelectedPatient()
        {
            _selectedPatientId = null;
            patientNameTextBox.Clear();
            patientDobTextBox.Clear();
            inactivePatientLabel.Text = string.Empty;
            EnableAppointmentFields(false);
        }

        private void EnableAppointmentFields(bool enabled)
        {
            doctorComboBox.Enabled = enabled;
            appointmentDatePicker.Enabled = enabled;
            reasonTextBox.Enabled = enabled;
            bookButton.Enabled = enabled;
            appointmentTimeComboBox.Enabled = enabled && appointmentTimeComboBox.Items.Count > 0;
        }

        private bool CanEditFields => _selectedPatientId.HasValue && !_isReadOnlyEdit;

        private void RefreshAvailableSlots()
        {
            if (!TryGetSelectedDoctorId(out int doctorId))
            {
                appointmentTimeComboBox.DataSource = null;
                appointmentTimeComboBox.Enabled = false;
                return;
            }

            List<TimeSpan> availableSlots;
            try
            {
                int? excludeAppointmentId = _isEditMode ? _appointmentId : null;
                availableSlots = _appointmentController.GetAvailableSlots(doctorId, appointmentDatePicker.Value.Date, excludeAppointmentId);
            }
            catch (Exception ex)
            {
                appointmentTimeComboBox.DataSource = null;
                appointmentTimeComboBox.Enabled = false;
                errorLabel.Text = "Could not load available times: " + ex.Message;
                return;
            }

            appointmentTimeComboBox.DataSource = null;
            appointmentTimeComboBox.Items.Clear();
            appointmentTimeComboBox.DataSource = availableSlots;

            if (availableSlots.Count == 0)
            {
                appointmentTimeComboBox.Enabled = false;
                availabilityStatusLabel.Text = "No available times for this doctor on this date.";
                return;
            }

            appointmentTimeComboBox.Enabled = CanEditFields;
            availabilityStatusLabel.Text = string.Empty;

            if (_isEditMode && _currentSlot.HasValue)
            {
                SelectSlot(_currentSlot.Value);
            }
        }

        private void SelectSlot(TimeSpan slot)
        {
            for (int i = 0; i < appointmentTimeComboBox.Items.Count; i++)
            {
                if ((TimeSpan)appointmentTimeComboBox.Items[i] == slot)
                {
                    appointmentTimeComboBox.SelectedIndex = i;
                    return;
                }
            }

            if (appointmentTimeComboBox.Items.Count > 0)
            {
                appointmentTimeComboBox.SelectedIndex = 0;
            }
        }

        private bool TryGetSelectedDoctorId(out int doctorId)
        {
            doctorId = 0;
            return doctorComboBox.SelectedValue is int selectedDoctorId && (doctorId = selectedDoctorId) > 0;
        }

        private DateTime GetSelectedAppointmentDateTime()
        {
            if (appointmentTimeComboBox.SelectedItem is not TimeSpan selectedTime)
            {
                throw new ArgumentException("Please select an available time slot.");
            }

            return appointmentDatePicker.Value.Date.Add(selectedTime);
        }

        private void bookButton_Click(object sender, EventArgs e)
        {
            errorLabel.Text = string.Empty;

            try
            {
                if (!_selectedPatientId.HasValue)
                {
                    throw new ArgumentException("Please search for and select an active patient.");
                }

                int patientId = _selectedPatientId.Value;

                if (!TryGetSelectedDoctorId(out int doctorId))
                {
                    throw new ArgumentException("Please select a doctor.");
                }

                DateTime when = GetSelectedAppointmentDateTime();

                if (_isEditMode && _appointmentId.HasValue)
                {
                    _appointmentController.UpdateAppointment(_appointmentId.Value, patientId, doctorId, when, reasonTextBox.Text);
                    MessageBox.Show("Appointment updated.");
                }
                else
                {
                    _appointmentController.BookAppointment(patientId, doctorId, when, reasonTextBox.Text);
                    MessageBox.Show("Appointment booked.");
                    ResetCreateAppointmentTab();
                }

            }
            catch (ArgumentException ex)
            {
                RefreshAvailableSlots();
                errorLabel.Text = ex.Message;
            }
            catch (MySqlException ex)
            {
                HandleSqlSaveError(ex);
            }
            catch (Exception ex)
            {
                RefreshAvailableSlots();
                errorLabel.Text = "Something went wrong: " + ex.Message;
            }
        }

        private void ResetCreateAppointmentTab()
        {
            patientSearchControl.Clear();
            ClearSelectedPatient();
            reasonTextBox.Clear();
            appointmentDatePicker.Value = DateTime.Today;
            errorLabel.Text = string.Empty;
            availabilityStatusLabel.Text = string.Empty;
            RefreshAvailableSlots();
        }

        private void HandleSqlSaveError(MySqlException ex)
        {
            RefreshAvailableSlots();

            if (ex.Number == 1062)
            {
                errorLabel.Text = "That time slot was just booked. Please choose another available time.";
                return;
            }

            if (ex.Number == 3819 || ex.Number == 4025)
            {
                errorLabel.Text = "The selected date/time is outside allowed clinic time slots. Please choose a valid slot.";
                return;
            }

            errorLabel.Text = "Something went wrong: " + ex.Message;
        }

        private void SetVisitAndOrderTextWarning(string message)
        {
            visitAndOrderTestErrorLabel.Text = message;
        }

        private void doctorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAvailableSlots();
        }

        private void appointmentDatePicker_ValueChanged(object sender, EventArgs e)
        {
            RefreshAvailableSlots();
        }

        private void appointmentTimeComboBox_Format(object? sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is TimeSpan slot)
            {
                e.Value = DateTime.Today.Add(slot).ToString("hh:mm tt");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfigureVisitAndOrderTestForm()
        {
            ClearVisitAndOrderTestError();
            testCheckedListBox.DataSource = null;
            testCheckedListBox.Items.Clear();

            try
            {
                List<Test> tests = _appointmentController.GetTests();

                testCheckedListBox.DisplayMember = nameof(Test.Name);
                testCheckedListBox.ValueMember = nameof(Test.TestCode);
                testCheckedListBox.DataSource = tests;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load tests: " + ex.Message, "Error");
            }
        }

        private void ClearVisitAndOrderTestError()
        {
            visitAndOrderTestErrorLabel.Text = "";
        }

        private void orderTestPatientSearch_PatientSelected(object sender, EventArgs e)
        {
            appointmentDataGridView.Rows.Clear();
            ClearVisitAndOrderTestError();
            Patient? patient = orderTestPatientSearchControl.SelectedPatient;
            if (patient != null)
            {
                try
                {
                    var appointments = _appointmentController.GetAppointmentsByPatientId(patient.Id);
                    if (appointments.Count == 0)
                    {
                        SetVisitAndOrderTextWarning("No appointments found for this patient.");
                        return;
                    }
                    foreach (var appt in appointments)
                    {
                        appointmentDataGridView.Rows.Add(appt.AppointmentId, appt.DoctorName, appt.DateTime, appt.Reason);
                    }
                }
                catch (ArgumentException ex)
                {
                    SetVisitAndOrderTextWarning(ex.Message);
                }
            }
        }

        private static int ParseRequiredInteger(TextBox input, string fieldName)
        {
            if (!int.TryParse(input.Text, NumberStyles.Integer, CultureInfo.CurrentCulture, out int value) || value <= 0)
            {
                throw new ArgumentException($"Enter a valid {fieldName} greater than zero.");
            }

            return value;
        }

        private static decimal ParseRequiredDecimal(TextBox input, string fieldName)
        {
            if (!decimal.TryParse(input.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal value) || value <= 0)
            {
                throw new ArgumentException($"Enter a valid {fieldName} greater than zero.");
            }

            return value;
        }

        private void submitVisitButton_Click(object sender, EventArgs e)
        {
            ClearVisitAndOrderTestError();
            try
            {
                if (appointmentDataGridView.SelectedRows.Count == 0 ||
                    appointmentDataGridView.SelectedRows[0].Cells[nameof(appointmentIdColumn)].Value == null)
                {
                    throw new ArgumentException("Please select an appointment.");
                }

                var selectedAppointmentId = Convert.ToInt32(
                    appointmentDataGridView.SelectedRows[0].Cells[nameof(appointmentIdColumn)].Value,
                    CultureInfo.InvariantCulture);

                var systolic = ParseRequiredInteger(systolicTextBox, "systolic pressure");
                var diastolic = ParseRequiredInteger(diastolicTextBox, "diastolic pressure");
                var pulse = ParseRequiredInteger(pulseTextBox, "pulse");
                var bodyTemperature = ParseRequiredDecimal(bodyTemperatureTextBox, "body temperature");
                var height = ParseRequiredDecimal(heightTextBox, "height");
                var weight = ParseRequiredDecimal(weightTextBox, "weight");

                var selectedTests = testCheckedListBox.CheckedItems
                    .Cast<Test>()
                    .ToList();

                _appointmentController.SaveVisitAndTests(
                    selectedAppointmentId,
                    systolic,
                    diastolic,
                    pulse,
                    bodyTemperature,
                    height,
                    weight,
                    symptomsTextBox.Text,
                    initialDiagnosisTextBox.Text,
                    selectedTests);

                MessageBox.Show("Visit and selected tests submitted.");
                systolicTextBox.Clear();
                diastolicTextBox.Clear();
                pulseTextBox.Clear();
                bodyTemperatureTextBox.Clear();
                heightTextBox.Clear();
                weightTextBox.Clear();
                symptomsTextBox.Clear();
                initialDiagnosisTextBox.Clear();

                for (int i = 0; i < testCheckedListBox.Items.Count; i++)
                {
                    testCheckedListBox.SetItemChecked(i, false);
                }
            }
            catch (ArgumentException ex)
            {
                SetVisitAndOrderTextWarning(ex.Message);
            }
            catch (Exception ex)
            {
                SetVisitAndOrderTextWarning("The visit could not be submitted: " + ex.Message);
            }
        }

        private void ConfigureFinalDiagnosisForm()
        {
            ClearFinalDiagnosisForm();
        }

        private void ClearFinalDiagnosisForm()
        {
            ClearFinalDiagnosisWarning();
            visitDataGridView.Rows.Clear();
            finalDiagnosisPatientSearchControl.Clear();
        }

        private void SetFinalDiagnosisWarning(string message)
        {
            finalDiagnosisWarningLabel.Text = message;
        }

        private void ClearFinalDiagnosisWarning()
        {
            finalDiagnosisWarningLabel.Text = "";
        }

        private void finalDiagnosisPatientSearchControl_PatientSelected(object sender, EventArgs e)
        {
            visitDataGridView.Rows.Clear();
            ClearFinalDiagnosisWarning();
            Patient? patient = finalDiagnosisPatientSearchControl.SelectedPatient;
            if (patient == null) return;
            try
            {
                var visits = _appointmentController.GetVisitsWithCompleteOrNoTestsForPatient(patient.Id);
                if (visits.Count == 0)
                {
                    SetFinalDiagnosisWarning("No appointments found for this patient.");
                    return;
                }

                var doctorNames = _appointmentController.GetDoctorsWithNames();
                foreach (var visit in visits)
                {
                    if (visit.FinalDiagnosis == null && visit.InitialDiagnosis != null)
                    {
                        visitDataGridView.Rows.Add(visit.AppointmentId, _appointmentController.GetDoctorNameFromVisit(visit.AppointmentId), visit.InitialDiagnosis);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                SetFinalDiagnosisWarning(ex.Message);
            }
        }

        private void finalDiagnosisSubmitButton_Click(object sender, EventArgs e)
        {
            ClearFinalDiagnosisWarning();
            var finalDiagnosis = finalDiagnosisTextBox.Text;
            if (string.IsNullOrWhiteSpace(finalDiagnosis))
            {
                SetFinalDiagnosisWarning("Please enter a final diagnosis.");
                return;
            }

            if (visitDataGridView.SelectedRows.Count == 0 || visitDataGridView.SelectedRows[0].Cells[nameof(finalDiagnosisAppointmentIdColumn)].Value == null)
            {
                SetFinalDiagnosisWarning("Please select a visit.");
                return;
            }

            var visitId = Convert.ToInt32(visitDataGridView.SelectedRows[0].Cells[nameof(finalDiagnosisAppointmentIdColumn)].Value);
            try
            {
                if (_appointmentController.UpdateFinalDiagnosis(finalDiagnosis, visitId))
                {
                    MessageBox.Show("Final diagnosis updated successfully.");
                    ClearFinalDiagnosisForm();
                }
                else
                {
                    SetFinalDiagnosisWarning("Failed to update final diagnosis.");
                }
            }
            catch (Exception ex)
            {
                SetFinalDiagnosisWarning("An error occurred while updating the final diagnosis: " + ex.Message);
            }
        }

        private Patient? _testResultsPatient;

        private VisitSummary? TestResultsSelectedVisit =>
            testResultsVisitGrid.SelectedRows.Count == 0 ? null : testResultsVisitGrid.SelectedRows[0].DataBoundItem as VisitSummary;

        private VisitTestResult? TestResultsSelectedTest =>
            testResultsTestsGrid.SelectedRows.Count == 0 ? null : testResultsTestsGrid.SelectedRows[0].DataBoundItem as VisitTestResult;

        private void ConfigureTestResultsForm()
        {
            testResultsErrorLabel.Text = string.Empty;
            testResultsPatientInfoLabel.Text = string.Empty;
            ClearTestResultsSelectedTest();
        }

        private void testResultsPatientSearchControl_PatientSelected(object? sender, EventArgs e)
        {
            _testResultsPatient = testResultsPatientSearchControl.SelectedPatient;
            testResultsErrorLabel.Text = string.Empty;
            testResultsVisitGrid.DataSource = null;
            testResultsTestsGrid.DataSource = null;
            ClearTestResultsSelectedTest();

            if (_testResultsPatient == null)
            {
                testResultsPatientInfoLabel.Text = string.Empty;
                return;
            }

            testResultsPatientInfoLabel.Text = $"Patient: {_testResultsPatient.FirstName} {_testResultsPatient.LastName}   |   DOB: {_testResultsPatient.Birthdate:d}";
            LoadTestResultsVisits();
        }

        private void LoadTestResultsVisits()
        {
            if (_testResultsPatient == null) return;

            try
            {
                var visits = _appointmentController.GetVisitsWithTestsForPatient(_testResultsPatient.Id);
                testResultsVisitGrid.DataSource = new BindingList<VisitSummary>(visits);

                if (visits.Count == 0)
                {
                    testResultsErrorLabel.Text = "This patient has no visits with ordered tests.";
                }
            }
            catch (Exception ex)
            {
                testResultsErrorLabel.Text = "Visits could not be loaded: " + ex.Message;
            }
        }

        private void LoadTestResultsTests()
        {
            testResultsTestsGrid.DataSource = null;
            ClearTestResultsSelectedTest();

            var visit = TestResultsSelectedVisit;
            if (visit == null) return;

            try
            {
                var tests = _appointmentController.GetVisitTestResults(visit.AppointmentId);
                testResultsTestsGrid.DataSource = new BindingList<VisitTestResult>(tests);

                testResultsErrorLabel.Text = visit.IsLocked
                    ? "This visit has a final diagnosis, so its test results are read-only."
                    : string.Empty;
            }
            catch (Exception ex)
            {
                testResultsErrorLabel.Text = "Tests could not be loaded: " + ex.Message;
            }
        }

        private void testResultsVisitGrid_SelectionChanged(object? sender, EventArgs e)
        {
            LoadTestResultsTests();
        }

        private void testResultsTestsGrid_SelectionChanged(object? sender, EventArgs e)
        {
            ShowTestResultsSelectedTest();
        }

        // Stops the grids from auto-selecting the first row
        private void testResultsVisitGrid_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            testResultsVisitGrid.ClearSelection();
        }

        private void testResultsTestsGrid_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            testResultsTestsGrid.ClearSelection();
        }

        private void ShowTestResultsSelectedTest()
        {
            var visit = TestResultsSelectedVisit;
            var test = TestResultsSelectedTest;

            if (visit == null || test == null)
            {
                ClearTestResultsSelectedTest();
                return;
            }

            testResultsSelectedTestLabel.Text = $"Test: {test.TestName}   |   Normal range: {test.NormalRange}   |   Doctor: {visit.DoctorName}";
            testResultsDatePerformedPicker.Value = test.DatePerformed ?? DateTime.Now;
            testResultsResultTextBox.Text = test.Result ?? string.Empty;

            bool canEdit = !visit.IsLocked;
            testResultsDatePerformedPicker.Enabled = canEdit;
            testResultsResultTextBox.Enabled = canEdit;
            testResultsSaveButton.Enabled = canEdit;

            if (test.HasNormalRange)
            {
                // Abnormal is calculated from the range, so the nurse can't change it
                testResultsAbnormalCheckBox.Enabled = false;
                UpdateTestResultsAbnormalPreview();
            }
            else
            {
                testResultsAbnormalCheckBox.Enabled = canEdit;
                testResultsAbnormalCheckBox.Checked = test.IsAbnormal ?? false;
            }
        }

        private void ClearTestResultsSelectedTest()
        {
            testResultsSelectedTestLabel.Text = "Select a visit and a test to enter its result.";
            testResultsDatePerformedPicker.Value = DateTime.Now;
            testResultsResultTextBox.Clear();
            testResultsAbnormalCheckBox.Checked = false;
            testResultsDatePerformedPicker.Enabled = false;
            testResultsResultTextBox.Enabled = false;
            testResultsAbnormalCheckBox.Enabled = false;
            testResultsSaveButton.Enabled = false;
        }

        private void testResultsResultTextBox_TextChanged(object? sender, EventArgs e)
        {
            UpdateTestResultsAbnormalPreview();
        }

        // For tests with a range, checks the Abnormal box as the nurse types a number
        private void UpdateTestResultsAbnormalPreview()
        {
            var test = TestResultsSelectedTest;
            if (test == null || !test.HasNormalRange) return;

            try
            {
                testResultsAbnormalCheckBox.Checked = _appointmentController.DetermineIsAbnormal(test, testResultsResultTextBox.Text, false);
            }
            catch (ArgumentException)
            {
                // Not a number yet; leave unchecked until it is
                testResultsAbnormalCheckBox.Checked = false;
            }
        }

        private void testResultsSaveButton_Click(object? sender, EventArgs e)
        {
            testResultsErrorLabel.Text = string.Empty;

            var visit = TestResultsSelectedVisit;
            var test = TestResultsSelectedTest;

            if (visit == null || test == null)
            {
                testResultsErrorLabel.Text = "Please select a visit and a test.";
                return;
            }

            try
            {
                _appointmentController.SaveTestResult(
                    visit,
                    test,
                    testResultsDatePerformedPicker.Value,
                    testResultsResultTextBox.Text,
                    testResultsAbnormalCheckBox.Checked);

                MessageBox.Show($"Result saved for {test.TestName}.", "Saved");
                LoadTestResultsTests();
            }
            catch (ArgumentException ex)
            {
                testResultsErrorLabel.Text = ex.Message;
            }
            catch (Exception ex)
            {
                testResultsErrorLabel.Text = "The result could not be saved: " + ex.Message;
            }
        }

        private Patient? _viewVisitsPatient;

        private VisitSummary? ViewVisitsSelectedVisit =>
            viewVisitsVisitGrid.SelectedRows.Count == 0 ? null : viewVisitsVisitGrid.SelectedRows[0].DataBoundItem as VisitSummary;

        private void ConfigureViewVisitsForm()
        {
            viewVisitsErrorLabel.Text = string.Empty;
            viewVisitsDetailsTextBox.Text = "Select a visit to see its details.";
        }

        private void viewVisitsPatientSearchControl_PatientSelected(object? sender, EventArgs e)
        {
            _viewVisitsPatient = viewVisitsPatientSearchControl.SelectedPatient;
            viewVisitsErrorLabel.Text = string.Empty;
            viewVisitsVisitGrid.DataSource = null;
            viewVisitsTestsGrid.DataSource = null;
            viewVisitsDetailsTextBox.Text = "Select a visit to see its details.";

            if (_viewVisitsPatient == null) return;

            try
            {
                var visits = _appointmentController.GetAllVisitsForPatient(_viewVisitsPatient.Id);
                viewVisitsVisitGrid.DataSource = new BindingList<VisitSummary>(visits);

                if (visits.Count == 0)
                {
                    viewVisitsErrorLabel.Text = "This patient has no visits yet.";
                }
            }
            catch (Exception ex)
            {
                viewVisitsErrorLabel.Text = "Visits could not be loaded: " + ex.Message;
            }
        }

        private void viewVisitsVisitGrid_SelectionChanged(object? sender, EventArgs e)
        {
            viewVisitsTestsGrid.DataSource = null;

            var summary = ViewVisitsSelectedVisit;
            if (summary == null || _viewVisitsPatient == null)
            {
                viewVisitsDetailsTextBox.Text = "Select a visit to see its details.";
                return;
            }

            try
            {
                var visit = _appointmentController.GetVisitById(summary.AppointmentId);
                if (visit == null)
                {
                    viewVisitsErrorLabel.Text = "The visit could not be found.";
                    return;
                }

                var tests = _appointmentController.GetVisitTestResults(summary.AppointmentId);

                viewVisitsDetailsTextBox.Text = BuildVisitDetailsText(_viewVisitsPatient, summary, visit);
                viewVisitsTestsGrid.DataSource = new BindingList<VisitTestResult>(tests);
                viewVisitsErrorLabel.Text = tests.Count == 0 ? "No tests were ordered for this visit." : string.Empty;
            }
            catch (Exception ex)
            {
                viewVisitsErrorLabel.Text = "The visit could not be loaded: " + ex.Message;
            }
        }

        private static string BuildVisitDetailsText(Patient patient, VisitSummary summary, Visit visit)
        {
            string nl = Environment.NewLine;

            return
                $"Patient: {patient.FirstName} {patient.LastName}   DOB: {patient.Birthdate:d}{nl}" +
                $"Doctor: {summary.DoctorName}{nl}" +
                $"Visit date: {summary.AppointmentDateTime:g}{nl}" +
                $"Status: {summary.StatusText}{nl}" +
                $"{nl}" +
                $"Blood pressure: {visit.SystolicBp}/{visit.DiastolicBp} mm/Hg{nl}" +
                $"Pulse: {visit.Pulse} BPM{nl}" +
                $"Temperature: {visit.BodyTemperature:0.0} °F{nl}" +
                $"Height: {visit.Height:0.##} in   Weight: {visit.Weight:0.##} lb{nl}" +
                $"Symptoms: {visit.Symptoms}{nl}" +
                $"{nl}" +
                $"Initial diagnosis: {visit.InitialDiagnosis ?? "(none)"}{nl}" +
                $"Final diagnosis: {visit.FinalDiagnosis ?? "(not entered yet)"}";
        }

        // Shows abnormal test results in red so they stand out
        private void viewVisitsTestsGrid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.CellStyle == null) return;

            if (viewVisitsTestsGrid.Rows[e.RowIndex].DataBoundItem is VisitTestResult { IsAbnormal: true })
            {
                e.CellStyle.ForeColor = Color.Firebrick;
            }
        }

        // Stops the grids from auto-selecting the first row
        private void viewVisitsVisitGrid_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewVisitsVisitGrid.ClearSelection();
        }

        private void viewVisitsTestsGrid_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewVisitsTestsGrid.ClearSelection();
        }
    }
}