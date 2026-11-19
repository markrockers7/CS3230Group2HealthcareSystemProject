using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.model
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime DateTime { get; set; }
        public string Reason { get; set; }

        /*
         * Initializes an instance of the Appointment class with the provided parameters.
         *
         * @param appointmentId The unique identifier for the appointment.
         * @param doctorId The unique identifier for the doctor associated with the appointment.
         * @param patientId The unique identifier for the patient associated with the appointment.
         * @param dateTime The date and time of the appointment.
         * @param reason The reason for the appointment.
         */
        public Appointment(int appointmentId, int doctorId, int patientId, DateTime dateTime, string reason)
        {
            AppointmentId = appointmentId;
            DoctorId = doctorId;
            PatientId = patientId;
            DateTime = dateTime;
            Reason = reason;
        }
    }
}
