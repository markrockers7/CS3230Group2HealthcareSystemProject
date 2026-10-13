using HealthcareSystemProjectCS3230.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.DAL
{
    public class NurseDAL
    {
        public static List<Nurse> GetAllNurses()
        {
            var nurses = new List<Nurse>();
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "SELECT id, person_id, username FROM Nurse";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                nurses.Add(new Nurse(
                    reader.GetInt32("id"),
                    reader.GetInt32("person_id"),
                    reader.GetString("username")));
            }

            return nurses;
        }
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

        public static bool UpdateNurse(string oldUsername, string newUsername)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "UPDATE Nurse SET username = @newUsername WHERE username = @oldUsername";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@newUsername", MySqlDbType.VarString).Value = newUsername;
            command.Parameters.Add("@oldUsername", MySqlDbType.VarString).Value = oldUsername;
            return command.ExecuteNonQuery() > 0;
        }
    }
}