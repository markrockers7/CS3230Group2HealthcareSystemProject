using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.DAL
{
    public class LoginDAL
    {
        public static string? verifyLogin(string username, string password)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "SELECT username FROM account WHERE username = @username AND password = @password";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@username", MySqlDbType.VarString).Value = username;
            command.Parameters.Add("@password", MySqlDbType.VarString).Value = password;
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetString("username");
            }

            return null;
        }
    }
}
