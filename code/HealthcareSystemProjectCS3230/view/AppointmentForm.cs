using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HealthcareSystemProjectCS3230.controler;
using HealthcareSystemProjectCS3230.model;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.ComponentModel;
using System.Text;

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

        private Dictionary<VisitSummary, List<VisitTestResult>> orderTestsTabVisitsAndTests;

        public AppointmentForm()
        {
            InitializeComponent();
            ConfigureForm();
            LoadDoctors();
            EnableAppointmentFields(false);
            ConfigureVisitAndOrderTestForm();
            ConfigureTestResultsForm();
            ConfigureViewVisitsForm();
        }

        public AppointmentForm(int appointmentId)
        {
            InitializeComponent();
            _appointmentId = appointmentId;
            _isEditMode = true;
            ConfigureForm();
            LoadDoctors();
            ConfigureVisitAndOrderTestForm();
            LoadExistingAppointment();
            ConfigureTestResultsForm();
            ConfigureViewVisitsForm();
        }

        /**
         * Edit mode, opened from Find Appointment with the patient already known
         */
        public AppointmentForm(int appointmentId, Patient patient) : this(appointmentId)
        {
            patientNameTextBox.Text = patient.FirstName + " " + patient.LastName;
            patientDobTextBox.Text = patient.Birthdate.ToString("d");
            createAppointmentPatientSearchControl.Visible = false;
        }

        public void setLoginSession(LoginSession session)
        {
            _loginSession = session;
            loggedInLabel.Text = @"Logged in as: " + session.FullName + @" | " + session.Username + @" | " + session.id;
        }

        private void ConfigureForm()
        {
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
                createAppointmentPatientSearchControl.Enabled = false;
                EnableAppointmentFields(false);
                availabilityStatusLabel.Text = "This appointment cannot be edited on or after its date.";
                return;
            }

            EnableAppointmentFields(true);
        }

        /// <summary>
        /// Shows an error and makes the whole form read-only
        /// </summary>
        private void LockForm(string message)
        {
            _isReadOnlyEdit = true;
            createAppointmentPatientSearchControl.Enabled = false;
            EnableAppointmentFields(false);
            errorLabel.Text = message;
        }

        private void patientSearchControl_PatientSelected(object? sender, EventArgs e)
        {
            ClearAppointmentFieldErrors();
            Patient? patient = createAppointmentPatientSearchControl.SelectedPatient;
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
            ClearAppointmentFieldErrors();
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

        private void EnableVisitCheckupFields(bool enabled, bool canFinalize)
        {
            systolicTextBox.Enabled = enabled;
            diastolicTextBox.Enabled = enabled;
            pulseTextBox.Enabled = enabled;
            bodyTemperatureTextBox.Enabled = enabled;
            heightTextBox.Enabled = enabled;
            weightTextBox.Enabled = enabled;
            symptomsTextBox.Enabled = enabled;
            initialDiagnosisTextBox.Enabled = enabled;
            visitCheckupFinalDiagnosisTextBox.Enabled = enabled && canFinalize;
            submitVisitButton.Enabled = enabled;
        }

        private void ClearVisitCheckupFields()
        {
            ClearVisitFieldErrors();
            systolicTextBox.Clear();
            diastolicTextBox.Clear();
            pulseTextBox.Clear();
            bodyTemperatureTextBox.Clear();
            heightTextBox.Clear();
            weightTextBox.Clear();
            symptomsTextBox.Clear();
            initialDiagnosisTextBox.Clear();
            visitCheckupFinalDiagnosisTextBox.Clear();
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


        private void bookButton_Click(object sender, EventArgs e)
        {
            // Keep the existing read-only edit protection.
            if (_isReadOnlyEdit)
                return;

            try
            {
                // Validate every applicable field before calling the controller.
                if (!ValidateAppointmentInput(
                    out int patientId, out int doctorId, out DateTime when))
                {
                    return;
                }

                if (_isEditMode && _appointmentId.HasValue)
                {
                    _appointmentController.UpdateAppointment(
                        _appointmentId.Value, patientId, doctorId, when,
                        reasonTextBox.Text);
                    MessageBox.Show("Appointment updated.");
                }
                else
                {
                    _appointmentController.BookAppointment(
                        patientId, doctorId, when, reasonTextBox.Text);
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
            ClearAppointmentFieldErrors();
            createAppointmentPatientSearchControl.Clear();
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
            orderTestsUnorderedTestsCheckedListBox.DisplayMember = nameof(Test.Name);
            orderTestsUnorderedTestsCheckedListBox.ValueMember = nameof(Test.TestCode);
            orderTestsAlreadyOrderedTestsCheckedListBox.DisplayMember = nameof(Test.Name);
            orderTestsAlreadyOrderedTestsCheckedListBox.ValueMember = nameof(Test.TestCode);
        }

        private void ClearVisitAndOrderTestError()
        {
            ClearVisitFieldErrors();
            visitAndOrderTestErrorLabel.Text = "";
        }

        private void visitCheckupPatientSearch_PatientSelected(object sender, EventArgs e)
        {
            visitCheckupAppointmentDataGridView.Rows.Clear();
            ClearVisitAndOrderTestError();
            Patient? patient = visitCheckupPatientSearchControl.SelectedPatient;
            if (patient != null)
            {
                try
                {
                    var appointments = _appointmentController.GetAllPatientAppointments(patient.Id);
                    if (appointments.Count == 0)
                    {
                        SetVisitAndOrderTextWarning("No appointments found for this patient.");
                        return;
                    }
                    foreach (var appt in appointments)
                    {
                        visitCheckupAppointmentDataGridView.Rows.Add(appt.AppointmentId, appt.DoctorName, appt.DateTime, appt.Reason);
                    }
                }
                catch (ArgumentException ex)
                {
                    SetVisitAndOrderTextWarning(ex.Message);
                }
            }
        }


        private void submitVisitButton_Click(object sender, EventArgs e)
        {
            ClearVisitAndOrderTestError();
            try
            {
                ScheduleVisitAndOrders(new List<Test>());
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

        private DialogResult ConfirmOrder()
        {
            return MessageBox.Show("Are you sure you want to order these tests?", "Confirm Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void ScheduleVisitAndOrders(List<Test> selectedTests)
        {
            // Each check runs, even when an earlier field is invalid.
            if (!ValidateVisitInput(
                out int selectedAppointmentId,
                out int systolic,
                out int diastolic,
                out int pulse,
                out decimal bodyTemperature,
                out decimal height,
                out decimal weight))
            {
                return;
            }

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
                visitCheckupFinalDiagnosisTextBox.Text,
                selectedTests);

            MessageBox.Show("Checkup submitted.");
            ClearVisitCheckupFields();
            ClearVisitAndOrderTestError();
            visitCheckupAppointmentDataGridView.Rows.Clear();
            visitCheckupPatientSearchControl.Clear();
        }

        private Patient? _orderTestsPatient;

        private void orderTestsPatientSearchControl_PatientSelected(object? sender, EventArgs e)
        {
            ClearOrderTestsFieldErrors();
            _orderTestsPatient = orderTestsPatientSearchControl.SelectedPatient;
            orderTestsErrorLabel.Text = string.Empty;
            orderTestsVisitGrid.Rows.Clear();

            if (_orderTestsPatient == null)
                return;

            try
            {
                orderTestsTabVisitsAndTests = _appointmentController.GetAllVisitsAndTheirTestsForPatient(_orderTestsPatient.Id);

                foreach (var visit in orderTestsTabVisitsAndTests.Keys)
                {
                    orderTestsVisitGrid.Rows.Add(
                        visit.AppointmentId,
                        visit.DoctorName,
                        visit.AppointmentDateTime);
                }

                orderTestsVisitGrid.ClearSelection();

                if (orderTestsVisitGrid.Rows.Count == 0)
                    orderTestsErrorLabel.Text = "No visits eligible for additional test orders were found.";
            }
            catch (Exception ex)
            {
                orderTestsErrorLabel.Text = "Visits could not be loaded: " + ex.Message;
            }
        }

        private void orderTestsSubmitButton_Click(object? sender, EventArgs e)
        {
            try
            {
                // Visit selection and test selection are checked together.
                if (!ValidateOrderTestsInput(
                    out int visitId, out List<Test> selectedTests))
                {
                    return;
                }

                if (ConfirmOrder() != DialogResult.Yes)
                    return;

                _appointmentController.AddTestsToVisit(visitId, selectedTests);

                orderTestsUnorderedTestsCheckedListBox.Tag = null;
                for (int index = 0;
                    index < orderTestsUnorderedTestsCheckedListBox.Items.Count;
                    index++)
                {
                    orderTestsUnorderedTestsCheckedListBox.SetItemChecked(index, false);
                }

                orderTestsPatientSearchControl_PatientSelected(null, EventArgs.Empty);
                MessageBox.Show(
                    "Tests ordered successfully.", "Order Tests",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                orderTestsErrorLabel.Text = ex.Message;
            }
            catch (Exception ex)
            {
                orderTestsErrorLabel.Text =
                    "The tests could not be ordered: " + ex.Message;
            }
        }
        private Patient? _testResultsPatient;

        private VisitSummary? TestResultsSelectedVisit =>
            testResultsVisitGrid.SelectedRows.Count == 0 ? null : testResultsVisitGrid.SelectedRows[0].DataBoundItem as VisitSummary;

        private VisitTestResult? TestResultsSelectedTest =>
            testResultsTestsGrid.SelectedRows.Count == 0 ? null : testResultsTestsGrid.SelectedRows[0].DataBoundItem as VisitTestResult;

        private void ConfigureTestResultsForm()
        {
            testResultsValueErrorLabel.SizeChanged += TestResultsValueErrorLabel_SizeChanged;
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
            ClearTestResultsFieldErrors();
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
            ClearTestResultsFieldErrors();
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
                testResultsAbnormalCheckBox.Checked = false;
            }
        }

        private void testResultsSaveButton_Click(object? sender, EventArgs e)
        {
            var visit = TestResultsSelectedVisit;
            var test = TestResultsSelectedTest;

            try
            {
                // The validator finishes all its checks before returning.
                if (!ValidateTestResultsInput(visit, test) ||
                    visit == null || test == null)
                {
                    return;
                }

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
                testResultsErrorLabel.Text =
                    "The result could not be saved: " + ex.Message;
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

        private void viewVisitsTestsGrid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.CellStyle == null) return;

            if (viewVisitsTestsGrid.Rows[e.RowIndex].DataBoundItem is VisitTestResult { IsAbnormal: true })
            {
                e.CellStyle.ForeColor = Color.Firebrick;
            }
        }

        private void viewVisitsVisitGrid_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewVisitsVisitGrid.ClearSelection();
        }

        private void viewVisitsTestsGrid_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewVisitsTestsGrid.ClearSelection();
        }

        private void orderTestsAppointmentGrid_SelectionChanged(object sender, EventArgs e)
        {
            ClearOrderTestsFieldErrors();
            orderTestsUnorderedTestsCheckedListBox.DataSource = null;
            orderTestsAlreadyOrderedTestsCheckedListBox.DataSource = null;

            if (orderTestsVisitGrid.SelectedRows.Count == 0 ||
                orderTestsVisitGrid.SelectedRows[0]
                    .Cells[nameof(orderTestsAppointmentIdColumn)].Value == null)
            {
                return;
            }

            int visitId = Convert.ToInt32(
                orderTestsVisitGrid.SelectedRows[0]
                    .Cells[nameof(orderTestsAppointmentIdColumn)].Value,
                CultureInfo.InvariantCulture);

            var visitEntry = orderTestsTabVisitsAndTests
                .FirstOrDefault(entry => entry.Key.AppointmentId == visitId);

            if (visitEntry.Key == null)
            {
                return;
            }

            var allTests = _appointmentController.GetTests();

            var orderedTestCodes = visitEntry.Value
                .Select(test => test.TestCode)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            orderTestsUnorderedTestsCheckedListBox.DataSource =
                allTests.Where(test => !orderedTestCodes.Contains(test.TestCode)).ToList();

            orderTestsAlreadyOrderedTestsCheckedListBox.DataSource =
                allTests.Where(test => orderedTestCodes.Contains(test.TestCode)).ToList();
        }

        private void visitCheckupAppointmentDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ClearVisitCheckupFields();
            EnableVisitCheckupFields(true, true);
            ClearVisitAndOrderTestError();

            if (visitCheckupAppointmentDataGridView.SelectedRows.Count == 0 ||
                visitCheckupAppointmentDataGridView.SelectedRows[0]
                    .Cells[nameof(appointmentIdColumn)].Value == null)
            {
                return;
            }

            try
            {
                int appointmentId = Convert.ToInt32(
                    visitCheckupAppointmentDataGridView.SelectedRows[0]
                        .Cells[nameof(appointmentIdColumn)].Value,
                    CultureInfo.InvariantCulture);

                Visit? visit = _appointmentController.GetVisitById(appointmentId);
                if (visit == null)
                {
                    // A visit has not yet been made for the selected appointment (new entry)
                    return;
                }

                systolicTextBox.Text = visit.SystolicBp.ToString(CultureInfo.CurrentCulture);
                diastolicTextBox.Text = visit.DiastolicBp.ToString(CultureInfo.CurrentCulture);
                pulseTextBox.Text = visit.Pulse.ToString(CultureInfo.CurrentCulture);
                bodyTemperatureTextBox.Text = visit.BodyTemperature.ToString(CultureInfo.CurrentCulture);
                heightTextBox.Text = visit.Height.ToString(CultureInfo.CurrentCulture);
                weightTextBox.Text = visit.Weight.ToString(CultureInfo.CurrentCulture);
                symptomsTextBox.Text = visit.Symptoms;
                initialDiagnosisTextBox.Text = visit.InitialDiagnosis ?? string.Empty;
                visitCheckupFinalDiagnosisTextBox.Text = visit.FinalDiagnosis ?? string.Empty;

                bool isFinalized = !string.IsNullOrWhiteSpace(visit.FinalDiagnosis);
                bool canBeFinalized = this._appointmentController.DoAllTestsInVisitHaveAResult(visit.AppointmentId);
                StringBuilder warningMessage = new StringBuilder("");

                EnableVisitCheckupFields(!isFinalized, canBeFinalized);

                if (isFinalized)
                {
                    warningMessage.Append("This visit has a final diagnosis and cannot be edited.");
                }
                else if (!canBeFinalized)
                {
                    warningMessage.Append("Some tests for this visit do not have results yet: A final diagnosis cannot be entered.");
                }


                if (warningMessage.ToString().Length > 0)
                {
                    SetVisitAndOrderTextWarning(warningMessage.ToString());
                }
            }
            catch (Exception ex)
            {
                SetVisitAndOrderTextWarning("The visit could not be loaded: " + ex.Message);
            }
        }


        private void TestResultsValueErrorLabel_SizeChanged(object? sender, EventArgs e)
        {
            testResultsSaveButton.Top = Math.Max(
                testResultsAbnormalCheckBox.Bottom,
                testResultsValueErrorLabel.Bottom) + 16;
        }

        #region Field validation

        private static void ClearLabelTexts(params Label[] labels)
        {
            foreach (Label label in labels)
                label.Text = string.Empty;
        }

        private void ClearAppointmentFieldErrors()
        {
            ClearLabelTexts(
                appointmentPatientErrorLabel,
                appointmentDoctorErrorLabel,
                appointmentDateErrorLabel,
                appointmentTimeErrorLabel,
                appointmentReasonErrorLabel);
        }

        private void ClearVisitFieldErrors()
        {
            ClearLabelTexts(
                visitAppointmentErrorLabel,
                systolicErrorLabel,
                diastolicErrorLabel,
                pulseErrorLabel,
                bodyTemperatureErrorLabel,
                heightErrorLabel,
                weightErrorLabel,
                symptomsErrorLabel);
        }

        private void ClearOrderTestsFieldErrors()
        {
            ClearLabelTexts(orderTestsVisitErrorLabel, orderTestsSelectionErrorLabel);
        }

        private void ClearTestResultsFieldErrors()
        {
            ClearLabelTexts(
                testResultsVisitErrorLabel,
                testResultsTestErrorLabel,
                testResultsValueErrorLabel);
        }

        private bool ValidateAppointmentInput(
            out int patientId, out int doctorId, out DateTime when)
        {
            ClearAppointmentFieldErrors();
            errorLabel.Text = string.Empty;

            bool isValid = true;
            patientId = _selectedPatientId.GetValueOrDefault();
            when = default;

            // Use the same timestamp for every date/time check in this submission.
            DateTime now = DateTime.Now;
            DateTime selectedDate = appointmentDatePicker.Value.Date;

            if (!_selectedPatientId.HasValue)
            {
                appointmentPatientErrorLabel.Text =
                    "Please search for and select an active patient.";
                isValid = false;
            }

            if (!TryGetSelectedDoctorId(out doctorId))
            {
                appointmentDoctorErrorLabel.Text = "Please select a doctor.";
                isValid = false;
            }

            // Preserve the create-mode restriction and the existing edit protections.
            if (!_isEditMode && selectedDate < now.Date)
            {
                appointmentDateErrorLabel.Text =
                    "Appointments cannot be booked in the past.";
                isValid = false;
            }

            if (appointmentTimeComboBox.SelectedItem is TimeSpan selectedTime)
            {
                when = selectedDate.Add(selectedTime);

                // Today's date is allowed, but an earlier time today is not.
                // Past dates already have an error beside the date picker.
                if (!_isEditMode && selectedDate == now.Date && when < now)
                {
                    appointmentTimeErrorLabel.Text =
                        "Appointments cannot be booked in the past.";
                    isValid = false;
                }
            }
            else
            {
                appointmentTimeErrorLabel.Text =
                    "Please select an available time slot.";
                isValid = false;
            }

            // Always check Reason, even when the date/time or another field is invalid.
            if (string.IsNullOrWhiteSpace(reasonTextBox.Text))
            {
                appointmentReasonErrorLabel.Text = "Please put a reason.";
                isValid = false;
            }
            else if (reasonTextBox.Text.Length > reasonTextBox.MaxLength)
            {
                appointmentReasonErrorLabel.Text =
                    $"Reason must be {reasonTextBox.MaxLength} characters or fewer.";
                isValid = false;
            }

            // Return only after all applicable fields have been checked.
            return isValid;
        }

        private static bool TryGetSelectedGridId(
            DataGridView grid, string columnName, out int selectedId)
        {
            selectedId = 0;

            if (grid.SelectedRows.Count == 0)
                return false;

            object? rawValue = grid.SelectedRows[0].Cells[columnName].Value;
            if (rawValue == null || rawValue == DBNull.Value)
                return false;

            return int.TryParse(
                Convert.ToString(rawValue, CultureInfo.InvariantCulture),
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out selectedId);
        }

        private static bool ValidatePositiveInteger(
            TextBox input, Label validationLabel, string fieldName, out int value)
        {
            // Preserve the original parsing culture and greater-than-zero rule.
            bool valid = int.TryParse(
                input.Text, NumberStyles.Integer,
                CultureInfo.CurrentCulture, out value) && value > 0;

            validationLabel.Text = valid
                ? string.Empty
                : $"Enter a valid {fieldName} greater than zero.";

            return valid;
        }

        private static bool ValidatePositiveDecimal(
            TextBox input, Label validationLabel, string fieldName, out decimal value)
        {
            bool valid = decimal.TryParse(
                input.Text, NumberStyles.Number,
                CultureInfo.CurrentCulture, out value) && value > 0;

            validationLabel.Text = valid
                ? string.Empty
                : $"Enter a valid {fieldName} greater than zero.";

            return valid;
        }

        private bool ValidateVisitInput(
            out int appointmentId,
            out int systolic,
            out int diastolic,
            out int pulse,
            out decimal bodyTemperature,
            out decimal height,
            out decimal weight)
        {
            ClearVisitAndOrderTestError();
            bool isValid = true;

            if (!TryGetSelectedGridId(
                visitCheckupAppointmentDataGridView,
                nameof(appointmentIdColumn), out appointmentId))
            {
                visitAppointmentErrorLabel.Text = "Please select an appointment.";
                isValid = false;
            }

            // Separate if statements deliberately evaluate ALL fields.
            if (!ValidatePositiveInteger(
                systolicTextBox, systolicErrorLabel,
                "systolic pressure", out systolic))
            {
                isValid = false;
            }

            if (!ValidatePositiveInteger(
                diastolicTextBox, diastolicErrorLabel,
                "diastolic pressure", out diastolic))
            {
                isValid = false;
            }

            if (!ValidatePositiveInteger(
                pulseTextBox, pulseErrorLabel, "pulse", out pulse))
            {
                isValid = false;
            }

            if (!ValidatePositiveDecimal(
                bodyTemperatureTextBox, bodyTemperatureErrorLabel,
                "body temperature", out bodyTemperature))
            {
                isValid = false;
            }

            if (!ValidatePositiveDecimal(
                heightTextBox, heightErrorLabel, "height", out height))
            {
                isValid = false;
            }

            if (!ValidatePositiveDecimal(
                weightTextBox, weightErrorLabel, "weight", out weight))
            {
                isValid = false;
            }

            // Check Symptoms even when one or more vitals are invalid.
            if (string.IsNullOrWhiteSpace(symptomsTextBox.Text))
            {
                symptomsErrorLabel.Text = "Please put the patient's symptoms.";
                isValid = false;
            }

            // Keep the existing diagnosis rules in the controller.
            return isValid;
        }

        private bool ValidateOrderTestsInput(
            out int visitId, out List<Test> selectedTests)
        {
            ClearOrderTestsFieldErrors();
            orderTestsErrorLabel.Text = string.Empty;
            bool isValid = true;

            if (!TryGetSelectedGridId(
                orderTestsVisitGrid, nameof(orderTestsAppointmentIdColumn),
                out visitId))
            {
                orderTestsVisitErrorLabel.Text = "Please select a visit.";
                isValid = false;
            }

            selectedTests = orderTestsUnorderedTestsCheckedListBox
                .CheckedItems.Cast<Test>().ToList();

            if (selectedTests.Count == 0)
            {
                orderTestsSelectionErrorLabel.Text =
                    "Please select at least one test.";
                isValid = false;
            }

            return isValid;
        }

        private bool ValidateTestResultsInput(
            VisitSummary? visit, VisitTestResult? test)
        {
            ClearTestResultsFieldErrors();
            testResultsErrorLabel.Text = string.Empty;
            bool isValid = true;

            if (visit == null)
            {
                testResultsVisitErrorLabel.Text = "Please select a visit.";
                isValid = false;
            }
            else if (visit.IsLocked)
            {
                testResultsErrorLabel.Text =
                    "This visit has a final diagnosis, so its test results are read-only.";
                isValid = false;
            }

            if (test == null)
            {
                testResultsTestErrorLabel.Text = "Please select a test.";
                isValid = false;
            }

            if (testResultsResultTextBox.Text.Length > testResultsResultTextBox.MaxLength)
            {
                testResultsValueErrorLabel.Text =
                    $"Result must be {testResultsResultTextBox.MaxLength} characters or fewer.";
                isValid = false;
            }

            // Reuse the existing result parsing/normal-range logic. Do not
            // invent clinical limits or a new format for non-numeric tests.
            if (test != null && test.HasNormalRange &&
                string.IsNullOrEmpty(testResultsValueErrorLabel.Text))
            {
                try
                {
                    _ = _appointmentController.DetermineIsAbnormal(
                        test, testResultsResultTextBox.Text, false);
                }
                catch (ArgumentException ex)
                {
                    testResultsValueErrorLabel.Text = ex.Message;
                    isValid = false;
                }
            }

            // Date-performed and other controller-only rules stay in
            // SaveTestResult. Unexpected errors still use the general label.
            return isValid;
        }

        #endregion

    }
}