namespace HealthcareSystemProjectCS3230.model;

public class Visit
{
    /// <summary>
    /// The appointment ID of the visit.
    /// </summary>
    public int AppointmentId { get; set; }

    /// <summary>
    /// The upper bound of the visit's blood pressure.
    /// </summary>
    public int SystolicBp { get; set; }

    /// <summary>
    /// The lower bound of the visit's blood pressure.
    /// </summary>
    public int DiastolicBp{ get; set; }
    /// <summary>
    /// The pulse of the patient.
    /// </summary>
    public int Pulse { get; set; }
    /// <summary>
    /// The body temperature of the patient.
    /// </summary>
    public double BodyTemperature { get; set; }
    /// <summary>
    /// The Height of the patient.
    /// </summary>
    public double Height { get; set; }
    /// <summary>
    /// The Weight of the patient.
    /// </summary>
    public double Weight { get; set; }
    /// <summary>
    /// The symptoms of the patient.
    /// </summary>
    public string Symptoms { get; set; }
    /// <summary>
    /// The initial diagnosis of the patient.
    /// </summary>
    public string? InitialDiagnosis { get; set; }
    /// <summary>
    /// The final diagnosis of the patient.
    /// </summary>
    public string? FinalDiagnosis { get; set; }
}