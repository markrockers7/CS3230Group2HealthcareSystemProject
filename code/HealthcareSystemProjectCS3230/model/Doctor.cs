using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.model
{
    public class Doctor
    {
        public int id { get; set; }
        public int personId { get; set; }

        public Doctor(int id, int personId)
        {
            this.id = id;
            this.personId = personId;
        }
    }
}
