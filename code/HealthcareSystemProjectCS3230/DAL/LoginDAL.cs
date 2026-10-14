using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using HealthcareSystemProjectCS3230.model;

namespace HealthcareSystemProjectCS3230.DAL
{
    public class LoginDAL
    {
        public static string? verifyLogin(string username, string password)
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
               string accountType = reader.GetString("type");
               return accountType;
            }

            return null;
        }

        public static LoginSession? SetNurseLoginSession(string username, string password)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "SELECT a.username, type, first_name, last_name, n.id FROM account a JOIN nurse n ON a.username = n.username JOIN person p ON n.person_id = p.person_id WHERE a.username = @username AND a.password = @password";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@username", MySqlDbType.VarString).Value = username;
            command.Parameters.Add("@password", MySqlDbType.VarString).Value = password;
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var accountType = reader.GetString("type");
                var validUsername = reader.GetString("username");
                var firstName = reader.GetString("first_name");
                var lastName = reader.GetString("last_name");
                var fullName = firstName + " " + lastName;
                var nurseId = reader.GetInt32("id");
                return new LoginSession(username, accountType, fullName, nurseId);
            }

            return null;
        }

        public static LoginSession? SetAdministratorLoginSession(string username, string password)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query =
                "SELECT ac.username, type, first_name, last_name, ad.id FROM account ac JOIN administrator ad ON ac.username = ad.username JOIN person p ON ad.person_id = p.person_id WHERE ac.username = @username AND ac.password = @password";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@username", MySqlDbType.VarString).Value = username;
            command.Parameters.Add("@password", MySqlDbType.VarString).Value = password;
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var accountType = reader.GetString("type");
                var validUsername = reader.GetString("username");
                var firstName = reader.GetString("first_name");
                var lastName = reader.GetString("last_name");
                var fullName = firstName + " " + lastName;
                var adminID = reader.GetInt32("id");
                return new LoginSession(username, accountType, fullName, adminID);
            }

            return null;
        }

        public static bool AddAccount(string username, string password, string accountType)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "INSERT INTO account (username, password, type) VALUES (@username, @password, @type)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@username", MySqlDbType.VarString).Value = username;
            command.Parameters.Add("@password", MySqlDbType.VarString).Value = password;
            command.Parameters.Add("@type", MySqlDbType.VarString).Value = accountType;
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }
}
