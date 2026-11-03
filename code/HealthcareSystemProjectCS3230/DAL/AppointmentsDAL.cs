using System;
using System.Collections.Generic;
using HealthcareSystemProjectCS3230.model;
using MySql.Data.MySqlClient;

namespace HealthcareSystemProjectCS3230.DAL
{
    public class AppointmentsDAL
    {
        /*          
         * Adds a new appointment to the database.
         *
         * @param patientId The ID of the patient for the appointment.
         * @param appointmentDateTime The date and time of the appointment.
         * @param doctorId The ID of the doctor for the appointment.
         * @param reason The reason for the appointment.
         * @return True if the appointment was added successfully; otherwise, false.
         */
        public bool AddAppointment(int patientId, DateTime appointmentDateTime, int doctorId, string reason)
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

        /*
         * Updates an existing appointment in the database.
         *
         * @param appointmentId The ID of the appointment to update.
         * @param patientId The new patient ID for the appointment.
         * @param appointmentDateTime The new date and time for the appointment.
         * @param doctorId The new doctor ID for the appointment.
         * @param reason The new reason for the appointment.
         * @return True if the appointment was updated successfully; otherwise, false.
         */
        public bool UpdateAppointment(int appointmentId, int patientId, DateTime appointmentDateTime, int doctorId, string reason)
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
        /*
         * Retrieves an appointment from the database by its ID.
         *
         * @param appointmentId The ID of the appointment to retrieve.
         * @return An Appointment object if found; otherwise, null.
         */
        public Appointment? GetAppointmentById(int appointmentId)
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
        /*
         * Retrieves a list of booked time slots for a specific doctor on a given date.
         *
         * @param doctorId The ID of the doctor.
         * @param appointmentDate The date for which to retrieve booked slots.
         * @param excludeAppointmentId An optional appointment ID to exclude from the results (useful for updates).
         * @return A list of TimeSpan objects representing the booked time slots.
         */
        public List<TimeSpan> GetBookedSlotsForDoctorDate(int doctorId, DateTime appointmentDate, int? excludeAppointmentId = null)
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

        /*
         * Retrieves a list of appointments for a specific patient.
         *
         * @param patient The Patient object for which to retrieve appointments.
         * @return A list of Appointment objects for the specified patient.
         */
        public List<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            var appointments = new List<Appointment>();
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query =
                "SELECT appointment_id, doctor_id, patient_id, appointment_datetime, reason " +
                "FROM Appointment WHERE patient_id = @patientId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@patientId", MySqlDbType.Int32).Value = patientId;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                appointments.Add(new Appointment(
                    reader.GetInt32("appointment_id"),
                    reader.GetInt32("doctor_id"),
                    reader.GetInt32("patient_id"),
                    reader.GetDateTime("appointment_datetime"),
                    reader.GetString("reason")
                ));
            }

            return appointments;
        }

        /*
         * Updates the final diagnosis for a visit.
         *
         * @param finalDiagnosis The final diagnosis to update.
         * @return True if the update was successful, false otherwise.
         */
        public bool UpdateVisitFinalDiagnosis(string finalDiagnosis, int visitId)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query =
                "UPDATE Visit " +
                "SET final_diagnosis = @finalDiagnosis " +
                "WHERE appointment_id = @visitId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@finalDiagnosis", MySqlDbType.VarChar).Value = finalDiagnosis;
            command.Parameters.Add("@visitId", MySqlDbType.Int32).Value = visitId;
            return command.ExecuteNonQuery() > 0;
        }
    }
}
