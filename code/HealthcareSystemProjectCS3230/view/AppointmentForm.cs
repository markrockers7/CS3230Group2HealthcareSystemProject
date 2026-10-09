using HealthcareSystemProjectCS3230.controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HealthcareSystemProjectCS3230.view
{
    public partial class AppointmentForm : Form
    {
        private readonly AppointmentController _appointmentController = new AppointmentController();
        private readonly int _patientId;

        public AppointmentForm()
        {
            InitializeComponent();
            LoadDoctors();
        }

        private void LoadDoctors()
        {
            doctorComboBox.DataSource = _appointmentController.GetDoctors();
            doctorComboBox.DisplayMember = "FullName";
            doctorComboBox.ValueMember = "Id";
        }

        private void bookButton_Click(object sender, EventArgs e)
        {
            try
            {
                int patientId = int.Parse(patientIdTextBox.Text.Trim());

                int doctorId = (int)doctorComboBox.SelectedValue;
                DateTime when = appointmentDateTimePicker.Value;

                _appointmentController.BookAppointment(patientId, doctorId, when, reasonTextBox.Text);

                MessageBox.Show("Appointment booked.");
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Please check your input");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Error");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
