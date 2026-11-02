using System;
using System.Collections.Generic;
using HealthcareSystemProjectCS3230.model;
using MySql.Data.MySqlClient;

namespace HealthcareSystemProjectCS3230.DAL
{
    public class AppointmentsDAL
    {
        public static bool AddAppointment(int patientId, DateTime appointmentDateTime, int doctorId, string reason)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query =
                "INSERT INTO Appointment (patient_id, appointment_datetime, doctor_id, reason) " +
                "VALUES (@patientId, @appointmentDateTime, @doctorId, @reason)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@patientId", MySqlDbType.Int32).Value = patientId;
            command.Parameters.Add("@appointmentDateTime", MySqlDbType.DateTime).Value = appointmentDateTime;
            command.Parameters.Add("@doctorId", MySqlDbType.Int32).Value = doctorId;
            command.Parameters.Add("@reason", MySqlDbType.VarChar).Value = reason;
            return command.ExecuteNonQuery() > 0;
        }

        public static bool UpdateAppointment(int appointmentId, int patientId, DateTime appointmentDateTime, int doctorId, string reason)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query =
                "UPDATE Appointment " +
                "SET patient_id = @patientId, appointment_datetime = @appointmentDateTime, doctor_id = @doctorId, reason = @reason " +
                "WHERE appointment_id = @appointmentId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@patientId", MySqlDbType.Int32).Value = patientId;
            command.Parameters.Add("@appointmentDateTime", MySqlDbType.DateTime).Value = appointmentDateTime;
            command.Parameters.Add("@doctorId", MySqlDbType.Int32).Value = doctorId;
            command.Parameters.Add("@reason", MySqlDbType.VarChar).Value = reason;
            command.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appointmentId;
            return command.ExecuteNonQuery() > 0;
        }

        public static Appointment? GetAppointmentById(int appointmentId)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query =
                "SELECT appointment_id, doctor_id, patient_id, appointment_datetime, reason " +
                "FROM Appointment WHERE appointment_id = @appointmentId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appointmentId;
            using var reader = command.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }

            return new Appointment(
                reader.GetInt32("appointment_id"),
                reader.GetInt32("doctor_id"),
                reader.GetInt32("patient_id"),
                reader.GetDateTime("appointment_datetime"),
                reader.GetString("reason"));
        }

        public static List<TimeSpan> GetBookedSlotsForDoctorDate(int doctorId, DateTime appointmentDate, int? excludeAppointmentId = null)
        {
            var bookedSlots = new List<TimeSpan>();
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            string query =
                "SELECT appointment_datetime FROM Appointment " +
                "WHERE doctor_id = @doctorId AND DATE(appointment_datetime) = @appointmentDate";
            if (excludeAppointmentId.HasValue)
            {
                query += " AND appointment_id <> @excludeAppointmentId";
            }

            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@doctorId", MySqlDbType.Int32).Value = doctorId;
            command.Parameters.Add("@appointmentDate", MySqlDbType.Date).Value = appointmentDate.Date;
            if (excludeAppointmentId.HasValue)
            {
                command.Parameters.Add("@excludeAppointmentId", MySqlDbType.Int32).Value = excludeAppointmentId.Value;
            }

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                DateTime bookedDateTime = reader.GetDateTime("appointment_datetime");
                bookedSlots.Add(bookedDateTime.TimeOfDay);
            }

            return bookedSlots;
        }
    }
}
