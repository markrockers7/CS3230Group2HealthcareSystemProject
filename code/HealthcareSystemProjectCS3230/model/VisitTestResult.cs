using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.model
{
    /** Represents the results of a visit to a healthcare provider, including details such as the appointment ID, blood pressure, pulse, body temperature, height, weight, symptoms, and diagnoses.
     */
    public class VisitTestResult
    {
        /*
         * The appointment ID of the visit.
         */
        public int AppointmentId { get; set; }
        /*
         * The upper bound of the visit's blood pressure.
         */
        public string TestCode { get; set; } = string.Empty;
        /*
         * The lower bound of the visit's blood pressure.
         */
        public string TestName { get; set; } = string.Empty;
        /*
         * The pulse of the patient.
         */
        public decimal? LowValue { get; set; }
        /*
         * The body temperature of the patient.
         */
        public decimal? HighValue { get; set; }
        /*
         * The Height of the patient.
         */
        public string? Unit { get; set; }
        /*
         * The Weight of the patient.
         */
        public DateTime? DatePerformed { get; set; }
        /*
         * The symptoms of the patient.
         */
        public string? Result { get; set; }
        /*
         * The inital diagnosis of the patient.
         */
        public bool? IsAbnormal { get; set; }
        /*
         * The final diagnosis of the patient.
         */

        public bool HasNormalRange => LowValue.HasValue || HighValue.HasValue;

        /*
         * Returns a string representation of the VisitTestResult object.
         *
         * @return A string representation of the VisitTestResult object.
         */
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
        /*
         * Returns a string representation of the VisitTestResult object.
         *
         * @return A string representation of the VisitTestResult object.
         */
        public string ResultText => string.IsNullOrWhiteSpace(Result) ? "Pending" : Result!;
        /*
         * Returns a string representation of the VisitTestResult object.
         *
         * @return A string representation of the VisitTestResult object.
         */
        public string AbnormalText => IsAbnormal switch
        {
            true => "Yes",
            false => "No",
            null => ""
        };
    }
}
