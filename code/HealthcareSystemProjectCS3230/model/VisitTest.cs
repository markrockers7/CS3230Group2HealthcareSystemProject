namespace HealthcareSystemProjectCS3230.model;

public class VisitTest
{
    public int AppointmentId { get; set; }
    public string TestCode { get; set; }
    public DateTime? DatePreformed { get; set; }
    public string? Result { get; set; }
    public bool? IsAbnormal { get; set; }
}