using HealthcareSystemProjectCS3230.model;

namespace HealthcareSystemProjectCS3230.view
{
    public partial class MainMenuForm : Form
    {
        private LoginSession _loginSession;
        public MainMenuForm(LoginSession loginSession)
        {
            _loginSession = loginSession;
            InitializeComponent();
            SetupSession();
        }


        private void SetupSession()
        {
            FormatUsernameLabel(_loginSession.FullName, _loginSession.Username, _loginSession.id);
            SetButtonVisibility();
        }

        private void FormatUsernameLabel(string fullName, string username, int id)
        {
            usernameLabel.Text = @"Hello, " + fullName + @"!" + Environment.NewLine + @"Username: " + username + Environment.NewLine + @"ID: " + id;
        }

        private void SetButtonVisibility()
        {
            DisableAllButtons();
            if (string.Equals(_loginSession.AccountType, "nurse", StringComparison.CurrentCultureIgnoreCase))
            {
                EnableNurseButtons();
            } else
            {
                nurseManagerButton.Visible = true;
                nurseManagerButton.Enabled = true;
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
            appointmentForm.setLoginSession(_loginSession);
                appointmentForm.ShowDialog();


            Show();
        }

        private void patientSearchButton_Click(object sender, EventArgs e)
        {
            Hide();

            using var patientSearchForm = new PatientSearchForm(_loginSession);
            patientSearchForm.ShowDialog();

            Show();
        }

        private void registerPatientButton_Click(object sender, EventArgs e)
        {
            Hide();
            using var reg = new RegisterPatientForm(_loginSession);
            reg.ShowDialog();
            Show();
        }

        private void editPatientButton_Click(object sender, EventArgs e)
        {
            Hide();
            using var edit = new EditPatientForm(_loginSession);
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
