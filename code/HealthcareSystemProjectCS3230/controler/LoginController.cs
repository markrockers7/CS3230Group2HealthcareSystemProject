using System;
using System.Collections.Generic;
using System.Text;
using HealthcareSystemProjectCS3230.DAL;

namespace HealthcareSystemProjectCS3230.controler
{
    public class LoginController
    {
        public string? Username { get; private set; } = null;

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
            this.Username = LoginDAL.verifyLogin(username, password);

            return this.Username != null;
        }
    }
}
