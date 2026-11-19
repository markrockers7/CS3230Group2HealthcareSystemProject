namespace HealthcareSystemProjectCS3230.model;

public class Test
{
    /*
     * Represents the code for a medical test.
     */
    public string TestCode { get; set; }
    /*
     * Represents the name of a medical test.
     */
    public string Name { get; set; }
    /*
     * Represents the lower limit of the normal range for a medical test.
     */
    public double? LowValue { get; set; }
    /*
     * Represents the upper limit of the normal range for a medical test.
     */
    public double? HighValue { get; set; }
    /*
     * Represents the unit of measurement for a medical test.
     */
    public string? UnitOfMeasurement { get; set; }
    public override string ToString() => Name;
}