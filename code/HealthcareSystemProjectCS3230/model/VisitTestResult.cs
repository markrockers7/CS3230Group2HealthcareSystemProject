using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.model
{
    /// <summary>
    /// Represents the results of a visit to a healthcare provider, including details such as the appointment ID, blood pressure, pulse, body temperature, height, weight, symptoms, and diagnoses.
    /// </summary>
    public class VisitTestResult
    {
        /// <summary>
        /// Gets or sets the appointment ID of the visit.
        /// </summary>
        public int AppointmentId { get; set; }
        /// <summary>
        /// Gets or sets the test code.
        /// </summary>
        public string TestCode { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the test name.
        /// </summary>
        public string TestName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the lower bound of the test result.
        /// </summary>
        public decimal? LowValue { get; set; }
        /// <summary>
        /// Gets or sets the upper bound of the test result.
        /// </summary>
        public decimal? HighValue { get; set; }
        /// <summary>
        /// Gets or sets the unit of the test result.
        /// </summary>
        public string? Unit { get; set; }
        /// <summary>
        /// Gets or sets the date the test was performed.
        /// </summary>
        public DateTime? DatePerformed { get; set; }
        /// <summary>
        /// Gets or sets the result of the test.
        /// </summary>
        public string? Result { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the test result is abnormal.
        /// </summary>
        public bool? IsAbnormal { get; set; }
        /// <summary>
        /// Gets a value indicating whether the test has a normal range.
        /// </summary>
        public bool HasNormalRange => LowValue.HasValue || HighValue.HasValue;

        /// <summary>
        /// Gets a string representation of the normal range for the test result.
        /// </summary>
        /// <returns>A string representation of the normal range for the test result.</returns>
        public string NormalRange
        {
            get
            {
                string unit = string.IsNullOrWhiteSpace(Unit) ? string.Empty : " " + Unit;

                if (LowValue.HasValue && HighValue.HasValue)
                    return $"{LowValue.Value:0.##} - {HighValue.Value:0.##}{unit}";
                if (LowValue.HasValue)
                    return $">= {LowValue.Value:0.##}{unit}";
                if (HighValue.HasValue)
                    return $"<= {HighValue.Value:0.##}{unit}";

                return "Negative";
            }
        }
        /// <summary>
        /// Gets a string representation of the test result.
        /// </summary>
        /// <returns>A string representation of the test result.</returns>
        public string ResultText => string.IsNullOrWhiteSpace(Result) ? "Pending" : Result!;
        /// <summary>
        /// Gets a string representation of the abnormality status of the test result.
        /// </summary>
        /// <returns>A string representation of the abnormality status of the test result.</returns>
        public string AbnormalText => IsAbnormal switch
        {
            true => "Yes",
            false => "No",
            null => ""
        };
    }
}
