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

            UpdateLoginButton();
        }

        private void loginButton(object sender, EventArgs e)
        {
            try
            {
                if (_loginController.isValidLogin(usernameTextBox.Text, passwordTextBox.Text))
                {
                    MainMenuForm mainMenuForm = new MainMenuForm();
                    mainMenuForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(LoginUnsuccessfulError);
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
    }
}
