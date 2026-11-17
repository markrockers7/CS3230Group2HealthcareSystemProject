using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.model
{
    public class Statistic
    {
        /// <summary>
        /// The code of the test.
        /// </summary>
        public string? TestCode { get; set; }
        /// <summary>
        /// The name of the test
        /// </summary>
        public string? TestName { get; set; }
        /// <summary>
        /// The count of the test performed
        /// </summary>
        public int TestCount { get; set; }
        /// <summary>
        /// The total count of all tests
        /// </summary>
        public int TotalTests { get; set; }
        /// <summary>
        /// Ratio between these performed tests and total tests
        /// </summary>
        public double Percentage { get; set; }
        /// <summary>
        /// How many tests have normal results
        /// </summary>
        public int NormalResults { get; set; }
        /// <summary>
        /// How many tests have abnormal results
        /// </summary>
        public int AbnormalResults { get; set; }

    }
}
