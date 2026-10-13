using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using HealthcareSystemProjectCS3230.model;

namespace HealthcareSystemProjectCS3230.DAL
{
    public class LoginDAL
    {
        public static LoginSession? verifyLogin(string username, string password)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "SELECT username, type FROM account WHERE username = @username AND password = @password";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@username", MySqlDbType.VarString).Value = username;
            command.Parameters.Add("@password", MySqlDbType.VarString).Value = password;
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
               string validUsername = reader.GetString("username");
               string accountType = reader.GetString("type");
               return new LoginSession(validUsername, accountType);
            }

            return null;
        }
    }
}
