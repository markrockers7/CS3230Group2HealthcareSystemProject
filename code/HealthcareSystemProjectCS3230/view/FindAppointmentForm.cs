using System;
using System.ComponentModel;
using System.Windows.Forms;
using HealthcareSystemProjectCS3230.controler;
using HealthcareSystemProjectCS3230.model;

namespace HealthcareSystemProjectCS3230.view
{
    public partial class FindAppointmentForm : Form
    {
        private readonly AppointmentController _appointmentController = new AppointmentController();
        private LoginSession? _loginSession;
        private Patient? _selectedPatient;

        public FindAppointmentForm()
        {
            InitializeComponent();
            statusLabel.Text = string.Empty;
            openButton.Enabled = false;
        }

        public void setLoginSession(LoginSession session)
        {
            _loginSession = session;
            loggedInLabel.Text = @"Logged in as: " + session.FullName + @" | " + session.Username + @" | " + session.id;
        }

        private void patientSearchControl_PatientSelected(object? sender, EventArgs e)
        {
            _selectedPatient = patientSearchControl.SelectedPatient;
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            appointmentsGrid.DataSource = null;
            statusLabel.Text = string.Empty;
            openButton.Enabled = false;

            if (_selectedPatient == null)
            {
                return;
            }

            try
            {
                var appointments = _appointmentController.GetAppointmentsForPatient(_selectedPatient.Id);
                appointmentsGrid.DataSource = new BindingList<AppointmentSummary>(appointments);

                if (appointments.Count == 0)
                {
                    statusLabel.Text = "This patient has no appointments.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Appointments could not be loaded: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private AppointmentSummary? SelectedAppointment
        {
            get
            {
                if (appointmentsGrid.SelectedRows.Count == 0) return null;
                return appointmentsGrid.SelectedRows[0].DataBoundItem as AppointmentSummary;
            }
        }

        private void appointmentsGrid_SelectionChanged(object? sender, EventArgs e)
        {
            var appointment = SelectedAppointment;
            openButton.Enabled = appointment != null;

            if (appointment == null)
            {
                return;
            }

            if (appointment.CanEdit)
            {
                openButton.Text = "Edit Appointment";
                statusLabel.Text = string.Empty;
            }
            else
            {
                openButton.Text = "View Appointment";
                statusLabel.Text = "This appointment can't be edited on or after its date. It will open read-only.";
            }
        }

        // Stops the grid from auto-selecting the first row
        private void appointmentsGrid_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            appointmentsGrid.ClearSelection();
        }

        private void appointmentsGrid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && openButton.Enabled)
            {
                openButton_Click(sender, e);
            }
        }

        private void openButton_Click(object? sender, EventArgs e)
        {
            if (SelectedAppointment is not AppointmentSummary appointment || _selectedPatient == null)
            {
                return;
            }

            using (var form = new AppointmentForm(appointment.AppointmentId, _selectedPatient))
            {
                if (_loginSession != null)
                {
                    form.setLoginSession(_loginSession);
                }
                form.ShowDialog(this);
            }

            LoadAppointments();
        }

        private void closeButton_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}