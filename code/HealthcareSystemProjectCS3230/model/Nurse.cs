using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.model
{
    public class Nurse : Person
    {
        public int PersonID { get; set; }

        public string Username { get; set; }

        public int ID { get; set; }

        public Nurse(int id, int personID, string username)
        {
            this.ID = id;
            this.PersonID = personID;
            this.Username = username;

        }
    }
}