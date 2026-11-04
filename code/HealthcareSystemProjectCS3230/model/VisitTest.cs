namespace HealthcareSystemProjectCS3230.model;

/*
 * Represents a visit to a healthcare provider, including details such as the appointment ID, blood pressure, pulse, body temperature, height, weight, symptoms, and diagnoses.
 */
public class VisitTest
{
    public int AppointmentId { get; set; }
    public string TestCode { get; set; }
    public DateTime? DatePreformed { get; set; }
    public string? Result { get; set; }
    public bool? IsAbnormal { get; set; }
}