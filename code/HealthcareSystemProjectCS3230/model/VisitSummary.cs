using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.model
{
    /*
     * Represents a summary of an appointment, including details such as the appointment ID, date and time, doctor information, reason for the appointment, and whether the appointment can be edited.
     */
    public class VisitSummary
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public string? InitialDiagnosis { get; set; }
        public string? FinalDiagnosis { get; set; }

        public bool IsLocked => !string.IsNullOrWhiteSpace(FinalDiagnosis);
        public string StatusText => IsLocked ? "Final diagnosis entered" : "Open";
    }
}
