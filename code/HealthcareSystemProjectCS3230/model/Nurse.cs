using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.model
{
    public class Nurse : Person
    {
        /*
         * Represents a nurse in the healthcare system.
         * Inherits from the Person class and adds additional properties specific to nurses.
         */
        public int PersonID { get; set; }

        /*
         * The username associated with the nurse's account.
         * This is used for authentication and identification within the system.
         */
        public string Username { get; set; }

        /*
         * The unique identifier for the nurse.
         */
        public int ID { get; set; }

        /*
         * Initializes a new instance of the Nurse class with the specified ID, person ID, and username.
         *
         * @param id The unique identifier for the nurse.
         * @param personID The unique identifier for the associated person.
         * @param username The username associated with the nurse's account.
         */
        public Nurse(int id, int personID, string username)
        {
            this.ID = id;
            this.PersonID = personID;
            this.Username = username;

        }
    }
}