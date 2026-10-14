using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.model
{
    public class LoginSession(string username, string accountType, string name, int id)
    {
        public string Username { get; set; } = username;
        public string AccountType { get; set; } = accountType;
        public string FullName { get; set; } = name;
        public int id { get; set; } = id;
    }
}
