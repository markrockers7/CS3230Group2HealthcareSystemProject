namespace HealthcareSystemProjectCS3230.model;

public class Test
{
    /// <summary>
    /// Represents the code for a medical test.
    /// </summary>
    public string TestCode { get; set; }

    /// <summary>
    /// Represents the name of a medical test.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Represents the lower limit of the normal range for a medical test.
    /// </summary>
    public double? LowValue { get; set; }

    /// <summary>
    /// Represents the upper limit of the normal range for a medical test.
    /// </summary>
    public double? HighValue { get; set; }

    /// <summary>
    /// Represents the unit of measurement for a medical test.
    /// </summary>
    public string? UnitOfMeasurement { get; set; }
    public override string ToString() => Name;
}