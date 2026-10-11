using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.model
{
    public class Nurse
    {
        public int id { get; set; }
        public int personId { get; set; }

        public string username { get; set; }

        public Nurse(int id, int personId, string username)
        {
            this.id = id;
            this.personId = personId;
            this.username = username;

        }
    }
}
