using HealthcareSystemProjectCS3230.controler;
using HealthcareSystemProjectCS3230.model;
using MySql.Data.MySqlClient;
using System.Globalization;

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
                MessageBox.Show("Could not load doctors: " + ex.Message, "Error");
            }

            RefreshAvailableSlots();
        }

        private void LoadExistingAppointment()
        {
            if (!_appointmentId.HasValue)
            {
                return;
            }

            Appointment? appointment = _appointmentController.GetAppointmentById(_appointmentId.Value);
            if (appointment == null)
            {
                throw new InvalidOperationException("The appointment could not be found.");
            }

            titleLabel.Text = "Edit Appointment";
            Text = "Edit Appointment";
            bookButton.Text = "Save";

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

        private void patientSearchControl_PatientSelected(object? sender, EventArgs e)
        {
            Patient? patient = patientSearchControl.SelectedPatient;

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

            int? excludeAppointmentId = _isEditMode ? _appointmentId : null;
            DateTime selectedDate = appointmentDatePicker.Value.Date;
            List<TimeSpan> availableSlots = _appointmentController.GetAvailableSlots(doctorId, selectedDate, excludeAppointmentId);

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
                }

                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Please check your input");
                RefreshAvailableSlots();
            }
            catch (MySqlException ex)
            {
                HandleSqlSaveError(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Error");
                RefreshAvailableSlots();
            }
        }

        private void HandleSqlSaveError(MySqlException ex)
        {
            if (ex.Number == 1062)
            {
                MessageBox.Show("That time slot was just booked. Please choose another available time.", "Time no longer available");
                RefreshAvailableSlots();
                return;
            }

            if (ex.Number == 3819 || ex.Number == 4025)
            {
                MessageBox.Show("The selected date/time is outside allowed clinic time slots. Please choose a valid slot.", "Invalid appointment time");
                RefreshAvailableSlots();
                return;
            }

            MessageBox.Show("Something went wrong: " + ex.Message, "Error");
            RefreshAvailableSlots();
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
    }
}