using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HealthcareSystemProjectCS3230.model;

namespace HealthcareSystemProjectCS3230.view
{
    public partial class MainMenuForm : Form
    {
        private LoginSession? _loginSession;
        public MainMenuForm()
        {
            InitializeComponent();
        }

        public void SetLoginSession(LoginSession ls)
        {
            _loginSession = ls;
            SetupSession();
        }

        private void SetupSession()
        {
            if (_loginSession != null)
            {
                FormatUsernameLabel(_loginSession.Username);
                SetButtonVisibility();
            }
        }

        private void FormatUsernameLabel(string username)
        {
            usernameLabel.Text = @"Hello, " + username + @"!";
        }

        private void SetButtonVisibility()
        {
            DisableAllButtons();
            if (_loginSession != null)
            {
                if (string.Equals(_loginSession.AccountType, "nurse", StringComparison.CurrentCultureIgnoreCase))
                {
                    EnableNurseButtons();
                } else
                {
                    nurseManagerButton.Visible = true;
                    nurseManagerButton.Enabled = true;
                }
            }
        }

        private void DisableAllButtons()
        {
            registerPatientButton.Enabled = false;
            appointmentButton.Enabled = false;
            patientSearchButton.Enabled = false;
            editPatientButton.Enabled = false;
            nurseManagerButton.Enabled = false;
            nurseManagerButton.Visible = false;
        }

        private void EnableNurseButtons()
        {
            registerPatientButton.Enabled = true;
            appointmentButton.Enabled = true;
            patientSearchButton.Enabled = true;
            editPatientButton.Enabled = true;
        }

        private void appointmentButton_Click(object sender, EventArgs e)
        {
            Hide();

            var appointmentForm = new AppointmentForm();
            appointmentForm.ShowDialog();


            Show();
        }

        private void patientSearchButton_Click(object sender, EventArgs e)
        {
            Hide();

            using var patientSearchForm = new PatientSearchForm();
            patientSearchForm.ShowDialog();

            Show();
        }

        private void registerPatientButton_Click(object sender, EventArgs e)
        {
            Hide();
            using var reg = new RegisterPatientForm();
            reg.ShowDialog();
            Show();
        }

        private void editPatientButton_Click(object sender, EventArgs e)
        {
            Hide();
            using var edit = new EditPatientForm();
            edit.ShowDialog();
            Show();
        }

        private void nurseManagerButton_Click(object sender, EventArgs e)
        {
            Hide();

            var nurseForm = new NurseForm();
            nurseForm.ShowDialog();

            Show();
        }
    }
}
