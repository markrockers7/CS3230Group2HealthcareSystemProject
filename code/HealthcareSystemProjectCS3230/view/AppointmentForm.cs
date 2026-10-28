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

        public AppointmentForm()
        {
            InitializeComponent();
            ConfigureForm();
            LoadDoctors();
        }

        public AppointmentForm(int appointmentId)
        {
            InitializeComponent();
            _appointmentId = appointmentId;
            _isEditMode = true;
            ConfigureForm();
            LoadDoctors();
            LoadExistingAppointment();
        }

        public void setLoginSession(LoginSession session)
        {
            _loginSession = session;
            loggedInLabel.Text = @"Logged in as: " + session.FullName + @" | " + session.Username + @" | " + session.id;
        }

        private void ConfigureForm()
        {
            appointmentDatePicker.Value = DateTime.Today;
            appointmentTimeComboBox.Format += appointmentTimeComboBox_Format;
            availabilityStatusLabel.Text = string.Empty;
        }

        private void LoadDoctors()
        {
            doctorComboBox.DataSource = _appointmentController.GetDoctors();
            doctorComboBox.DisplayMember = "id";
            doctorComboBox.ValueMember = "id";

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

            patientIdTextBox.Text = appointment.PatientId.ToString();
            doctorComboBox.SelectedValue = appointment.DoctorId;
            appointmentDatePicker.Value = appointment.DateTime.Date;
            reasonTextBox.Text = appointment.Reason;
            _currentSlot = appointment.DateTime.TimeOfDay;

            RefreshAvailableSlots();
            SelectSlot(_currentSlot.Value);

            if (!_appointmentController.CanEditAppointment(appointment.DateTime))
            {
                _isReadOnlyEdit = true;
                patientIdTextBox.Enabled = false;
                doctorComboBox.Enabled = false;
                appointmentDatePicker.Enabled = false;
                appointmentTimeComboBox.Enabled = false;
                reasonTextBox.Enabled = false;
                bookButton.Enabled = false;
                availabilityStatusLabel.Text = "This appointment cannot be edited on or after its date.";
            }
        }

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

            appointmentTimeComboBox.Enabled = !_isReadOnlyEdit;
            availabilityStatusLabel.Text = string.Empty;

            if (_isEditMode && _currentSlot.HasValue && selectedDate == appointmentDatePicker.Value.Date)
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
                int patientId = int.Parse(patientIdTextBox.Text.Trim());
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
            }
            catch (MySqlException ex)
            {
                HandleSqlSaveError(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Error");
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
