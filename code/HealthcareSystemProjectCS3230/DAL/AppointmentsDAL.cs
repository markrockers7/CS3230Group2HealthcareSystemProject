using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace HealthcareSystemProjectCS3230.DAL
{
    public class AppointmentsDAL
    {
        /// <summary>
        /// Adds an appointment
        /// </summary>
        /// <param name="patientId">The patient ID to add an appointment for</param>
        /// <param name="appointmentDateTime">The date and time for the appointment</param>
        /// <param name="doctorId">The ID of the doctor attending the appointment</param>
        /// <param name="reason">The reason for the appointment</param>
        /// <returns>True if the appointment was added, false otherwise</returns>
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
    }
}
