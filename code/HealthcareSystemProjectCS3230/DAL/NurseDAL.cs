using HealthcareSystemProjectCS3230.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.DAL
{
    public class NurseDAL
    {
        public static Nurse GetNurse(string username)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "SELECT id, person_id FROM Nurse WHERE username = @username";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@username", MySqlDbType.VarString).Value = username;
            using var reader = command.ExecuteReader();
            if (reader.Read()) 
            {
                return new Nurse(
                    reader.GetInt32("id"),
                    reader.GetInt32("person_id"),
                    username);
            }
            return null;
        }
        public static bool AddNurse(int personID, string username)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "INSERT INTO Nurse(person_id, username) VALUES (@personID, @username)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@username", MySqlDbType.VarString).Value = username;
            command.Parameters.Add("@personID", MySqlDbType.Int32).Value = personID;
            return command.ExecuteNonQuery() > 0;
        }
    }
}
