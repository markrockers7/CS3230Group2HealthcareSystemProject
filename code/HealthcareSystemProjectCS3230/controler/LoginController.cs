using HealthcareSystemProjectCS3230.DAL;
using HealthcareSystemProjectCS3230.model;

namespace HealthcareSystemProjectCS3230.controler
{
    /// <summary>
    /// Controller to handle login operations, including validating user credentials and creating login sessions.
    /// </summary>
    public class LoginController(LoginSession? loginSession)
    {
        public LoginSession? LoginSession { get; private set; } = loginSession;

        /// <summary>
        /// Validates the user's login credentials.
        /// </summary>
        /// <param name="username">The user's username.</param>
        /// <param name="password">The user's password.</param>
        /// <returns><c>true</c> if the login is valid; otherwise, <c>false</c>.</returns>
        public Boolean IsValidLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be Whitespace");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be Whitespace");
            }

            var loginDal = new LoginDAL();
            var loginSession = loginDal.VerifyLogin(username, password);
            if (loginSession == "nurse")
            {
                var nurseLogin = loginDal.SetNurseLoginSession(username, password);
                if (nurseLogin == null) return false;
                LoginSession = nurseLogin;
                return true;
            }
            if (loginSession == "administrator")
            {
                var adminLogin = loginDal.SetAdministratorLoginSession(username, password);
                if (adminLogin == null) return false;
                LoginSession = adminLogin;
                return true;
            }

            return false;
        }
    }
}
