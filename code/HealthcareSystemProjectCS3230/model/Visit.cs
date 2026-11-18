namespace HealthcareSystemProjectCS3230.model;

public class Visit
{
    /*
     * The appointment ID of the visit.
     */
    public int AppointmentId { get; set; }
    /*
     * The upper bound of the visit's blood pressure.
     */
    public int SystolicBp { get; set; }
    /*
     * The lower bound of the visit's blood pressure.
     */
    public int DiastolicBp{ get; set; }
    /*
     * The pulse of the patient.
     */
    public int Pulse { get; set; }
    /*
     * The body temperature of the patient.
     */
    public double BodyTemperature { get; set; }
    /*
     * The Height of the patient.
     */
    public double Height { get; set; }
    /*
     * The Weight of the patient.
     */
    public double Weight { get; set; }
    /*
     * The symptoms of the patient.
     */
    public string Symptoms { get; set; }
    /*
     * The inital diagnosis of the patient.
     */
    public string? InitialDiagnosis { get; set; }
    /*
     * The final diagnosis of the patient.
     */
    public string? FinalDiagnosis { get; set; }
}