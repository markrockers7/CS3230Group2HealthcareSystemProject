using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.model
{
    public class Patient : Person
    {

        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
