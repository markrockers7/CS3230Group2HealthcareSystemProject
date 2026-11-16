using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.model
{
    public class Statistic
    {
        public string? TestCode { get; set; }
        public string? TestName { get; set; }
        public int TestCount { get; set; }
        public int TotalTests { get; set; }
        public double Percentage { get; set; }
        public int NormalResults { get; set; }
        public int AbnormalResults { get; set; }

    }
}
