using MySql.Data.MySqlClient;
using HealthcareSystemProjectCS3230.model;

namespace HealthcareSystemProjectCS3230.DAL
{
    /// <summary>
    /// Provides database operations for verifying login credentials and creating login sessions.
    /// </summary>
    public class LoginDAL
    {
        /// <summary>
        /// Verifies an account's username and password.
        /// </summary>
        /// <param name="username">The account username.</param>
        /// <param name="password">The account password.</param>
        /// <returns>The account type if the credentials are valid; otherwise, <see langword="null"/>.</returns>
        public string? VerifyLogin(string username, string password)
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

        /// <summary>
        /// Creates a login session for a nurse with valid credentials.
        /// </summary>
        /// <param name="username">The nurse account username.</param>
        /// <param name="password">The account password.</param>
        /// <returns>The nurse's login session if the credentials and nurse record are valid; otherwise, <see langword="null"/>.</returns>
        public LoginSession? SetNurseLoginSession(string username, string password)
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

        /// <summary>
        /// Creates a login session for an administrator with valid credentials.
        /// </summary>
        /// <param name="username">The administrator account username.</param>
        /// <param name="password">The account password.</param>
        /// <returns>The administrator's login session if the credentials and administrator record are valid; otherwise, <see langword="null"/>.</returns>
        public LoginSession? SetAdministratorLoginSession(string username, string password)
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
    }
}