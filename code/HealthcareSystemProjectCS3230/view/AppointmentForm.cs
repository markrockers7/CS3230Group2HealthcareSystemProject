using HealthcareSystemProjectCS3230.controler;
using HealthcareSystemProjectCS3230.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
        }

        // Edit mode
        public AppointmentForm(int appointmentId)
        {
            InitializeComponent();
            _appointmentId = appointmentId;
            _isEditMode = true;
            ConfigureForm();
            LoadDoctors();
            LoadExistingAppointment();
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
                }

                Close();
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
    }
}