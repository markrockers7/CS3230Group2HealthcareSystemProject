using HealthcareSystemProjectCS3230.controler;

namespace HealthcareSystemProjectCS3230.view
{
    public partial class LoginForm : Form
    {
        private const string LoginUnsuccessfulError = "Username and/or password do not match.";

        private readonly LoginController _loginController = new LoginController();

        public LoginForm()
        {
            InitializeComponent();
            LoginWarningLabel.Visible = false;

            UpdateLoginButton();
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (_loginController.IsValidLogin(usernameTextBox.Text, passwordTextBox.Text))
                {
                    Hide();
                    LoginWarningLabel.Visible = false;
                    var mainMenuForm = new MainMenuForm(_loginController.LoginSession);
                    ClearFields();
                    mainMenuForm.ShowDialog();
                    Show();
                }
                else
                {
                    LoginWarningLabel.Text = LoginUnsuccessfulError;
                    LoginWarningLabel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            UpdateLoginButton();
        }

        private void UpdateLoginButton()
        {
            LoginButton.Enabled = !string.IsNullOrWhiteSpace(usernameTextBox.Text) &&
                                  !string.IsNullOrWhiteSpace(passwordTextBox.Text);
        }

        private void ClearFields()
        {
            usernameTextBox.Clear();
            passwordTextBox.Clear();
        }
    }
}
