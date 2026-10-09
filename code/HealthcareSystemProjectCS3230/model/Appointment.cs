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
