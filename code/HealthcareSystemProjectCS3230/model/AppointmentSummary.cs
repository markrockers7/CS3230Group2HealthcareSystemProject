using System;

namespace HealthcareSystemProjectCS3230.model
{
    public class AppointmentSummary
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public bool CanEdit { get; set; }
    }
}
