using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.model
{
    public class LoginSession
    {
        public string Username { get; set; }
        public string AccountType { get; set; }

        public LoginSession(string username, string accountType)
        {
            Username = username;
            AccountType = accountType;
        }
    }
}
