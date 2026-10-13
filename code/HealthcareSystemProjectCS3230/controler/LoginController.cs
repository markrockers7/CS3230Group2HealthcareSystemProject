using System;
using System.Collections.Generic;
using System.Text;
using HealthcareSystemProjectCS3230.DAL;
using HealthcareSystemProjectCS3230.model;

namespace HealthcareSystemProjectCS3230.controler
{
    public class LoginController
    {
        public LoginSession LoginSession { get; private set; }

        public Boolean isValidLogin(string username, string password)
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
            if (loginSession != null)
            {
                LoginSession = loginSession;
                return true;
            }

            return false;
        }
    }
}
