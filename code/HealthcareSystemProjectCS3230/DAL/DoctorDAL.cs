using MySql.Data.MySqlClient;
using HealthcareSystemProjectCS3230.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.DAL
{
    public class DoctorDAL
    {
        public static List<Doctor> GetAllDoctors()
        {
            var doctors = new List<Doctor>();
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "SELECT id, person_id FROM Doctor";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                doctors.Add(new Doctor(
                    reader.GetInt32("id"),
                    reader.GetInt32("person_id")));
            }

            return doctors;
        }

        public static bool IsDoctorBooked(int doctorId, DateTime dateTime)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query =
                "SELECT COUNT(*) FROM Appointment WHERE doctor_id = @doctorId AND appointment_datetime = @dateTime";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@doctorId", MySqlDbType.Int32).Value = doctorId;
            command.Parameters.Add("@dateTime", MySqlDbType.DateTime).Value = dateTime;
            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }
    }
}
