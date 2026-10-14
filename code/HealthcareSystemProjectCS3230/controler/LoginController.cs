using HealthcareSystemProjectCS3230.DAL;
using HealthcareSystemProjectCS3230.model;

namespace HealthcareSystemProjectCS3230.controler
{
    public class LoginController
    {
        public LoginSession LoginSession { get; private set; }

        public Boolean IsValidLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be Whitespace");
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Password cannot be Whitespace");
            }
            var loginSession = LoginDAL.verifyLogin(username, password);
            if (loginSession == "nurse")
            {
                var nurseLogin = LoginDAL.SetNurseLoginSession(username, password);
                if (nurseLogin == null) return false;
                LoginSession = nurseLogin;
                return true;
            } else if (loginSession == "administrator")
            {
                var adminLogin = LoginDAL.SetAdministratorLoginSession(username, password);
                if (adminLogin == null) return false;
                LoginSession = adminLogin;
                return true;
            }

            return false;
        }
    }
}
